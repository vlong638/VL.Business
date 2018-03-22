using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Newtonsoft.Json;
using PmSoft.ConstructionManagement.EarthWork.Entity;
using PmSoft.ConstructionManagement.Utilities;
using Subsidence.Business;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VL.Common.Core.Object.Subsidence;
using VL.Common.Logger;
using VL.Common.Testing.Utilities;

namespace PmSoft.ConstructionManagement.EarthWork.UI
{
    public enum ShowDialogType
    {
        Idle,
        AddElements,
        DeleleElements,
        ViewGT6,
        ViewCompletion,
    }

    public partial class EarthworkBlockingForm : System.Windows.Forms.Form
    {
        public TEarthworkBlocking Blocking;
        public TEarthworkBlock Block { set; get; }
        //public EarthworkBlocking Blocking;
        //public EarthworkBlock Block { set; get; }
        public DataGridViewRow Row { set; get; }
        public UIApplication m_UIApp;
        public UIDocument m_UIDoc;
        public Document m_Doc;

        #region 初始化
        /// <summary>
        /// 测试处理
        /// </summary>
        public EarthworkBlockingForm()
        {
            InitializeComponent();

            if (!InitForm())
                return;
            dgv_Blocks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ImplementationInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public EarthworkBlockingForm(UIApplication uiApp)
        {
            InitializeComponent();
            m_UIApp = uiApp;
            m_UIDoc = uiApp.ActiveUIDocument;
            m_Doc = m_UIDoc.Document;
            if (!InitForm())
                return;
            DisplayTab1Controls();
            HideTab2Controls();

            m_UIDoc.ActiveView = VLConstraints.View3D;
            //RenderColor();
        }

        private void RenderColor()
        {
            using (var transaction = new Transaction(m_Doc, "EarthworkBlocking." + nameof(RenderColor)))
            {
                transaction.Start();
                //渲染_所有 淡显
                IList<Element> allElements = GetAllElements(m_Doc);
                var defaultOverrideGraphicSettings = SubsidenceMonitor.Entities.CPSettings.GetTingledOverrideGraphicSettings(m_Doc);
                //0821希望移除土方打开时的透明度设置,复杂项目客户不习惯这种显示方案
                defaultOverrideGraphicSettings.SetSurfaceTransparency(0);
                foreach (var element in allElements)
                    Revit_Helper.ApplyOverrideGraphicSettings(VLConstraints.View3D, element.Id, defaultOverrideGraphicSettings);
                //Blocking.View3D.SetElementOverrides(element.Id, defaultOverrideGraphicSettings);
                //构件颜色渲染
                foreach (var block in Blocking.EarthworkBlocks)
                {
                    block.CPSettings_Obj.ApplySettingWithoutTransaction(Blocking, block.ElementIds.Select(c => new ElementId(c)).ToList());
                }
                transaction.Commit();
            }
        }
        private bool InitForm()
        {
            //初始化参数
            ShowDialogType = ShowDialogType.Idle;
            //dgv_Blocks
            dgv_Blocks.AutoGenerateColumns = false;
            Node_Name.DataPropertyName = nameof(TEarthworkBlock.Name);
            Node_Name.Tag = nameof(TEarthworkBlock.Name);
            Node_ElementCount.DataPropertyName = nameof(TEarthworkBlock.ElementCount);
            Node_ElementCount.Tag = nameof(TEarthworkBlock.ElementCount);
            Node_Description.DataPropertyName = nameof(TEarthworkBlock.Description);
            Node_Description.Tag = nameof(TEarthworkBlock.Description);

            #region 加载数据
            if (!VLConstraints.InitByDocument(m_UIDoc))
            {
                this.Close();
                return false;
            }
            //获取最新的数据日期
            //根据数据日期获取TEarthworkBlocking
            Blocking = new TEarthworkBlocking();
            DateTime issueTime = Blocking.GetLatestIssueTime();
            if (issueTime != DateTime.MinValue)
            {
                Blocking.LoadSolid(issueTime);
                Blocking.RemoveInvalidElementId(VLConstraints.Doc);
            }
            else
            {
                Blocking.IssueDateTime = DateTime.Now.Date;
            }
            AvoidBlackEdge();
            blocking_TargetTime.Text = Blocking.IssueDateTime.ToString("yyyy/MM/dd");
            SetFunctionName(Blocking.IssueDateTime.ToString("yyyy/MM/dd"));
            if (Blocking.EarthworkBlocks.Count() > 0)
                dgv_Blocks.DataSource = Blocking.EarthworkBlocks;
            else
                dgv_Blocks.DataSource = null;
            #endregion

            //dgv_ConstructionInfo
            dgv_ImplementationInfo.AutoGenerateColumns = false;
            ConstructionNode_Name.DataPropertyName = nameof(EarthworkBlockImplementationInfo.Name);
            ConstructionNode_Name.ReadOnly = true;
            ConstructionNode_StartTime.DataPropertyName = nameof(EarthworkBlockImplementationInfo.StartTimeStr);
            ConstructionNode_StartTime.Tag = nameof(DateTime);
            ConstructionNode_ExposureTime.DataPropertyName = nameof(EarthworkBlockImplementationInfo.ExposureTime);
            ConstructionNode_EndTime.DataPropertyName = nameof(EarthworkBlockImplementationInfo.EndTimeStr);
            ConstructionNode_EndTime.Tag = nameof(DateTime);
            ConstructionNode_ElementCount.DataPropertyName = nameof(EarthworkBlockImplementationInfo.ElementCount);
            //初始化按钮
            ToolTip tip = new ToolTip();
            tip.SetToolTip(btn_AddNode, "新增节点");
            tip.SetToolTip(btn_DeleteNode, "删除选中节点");
            tip.SetToolTip(btn_UpNode, "上移节点");
            tip.SetToolTip(btn_DownNode, "下移节点");
            tip.SetToolTip(btn_AddElement, "新增构件");
            tip.SetToolTip(btn_DeleteElement, "删除构件");
            tip.SetToolTip(btn_ViewGt6, "查看(无支撑暴露时间)>6被标红的视图");
            tip.SetToolTip(btn_Preview, "查看按完工和未完工标注颜色的视图");
            //DatePicker
            DatePicker = new DateTimePicker();
            DatePicker.Parent = this;
            DatePicker.Width = 100;
            DatePicker.Format = DateTimePickerFormat.Custom;
            DatePicker.CustomFormat = "yyyy/MM/dd";
            DatePicker.ShowCheckBox = true;
            DatePicker.Hide();
            DatePicker.LostFocus += DatePicker_LostFocus;
            DatePicker.TextChanged += DatePicker_TextChanged;
            //DateTimePicker
            DateTimePicker = new DateTimePicker();
            DatePicker.Parent = this;
            DateTimePicker.Hide();
            DateTimePicker.Format = DateTimePickerFormat.Custom;
            DateTimePicker.CustomFormat = "yyyy/MM/dd HH:mm";
            DateTimePicker.LostFocus += DateTimePicker_LostFocus;
            dgv_ImplementationInfo.Controls.Add(DateTimePicker);
            this.FormClosing += EarthworkBlockingForm_FormClosing;
            //Color Buttons
            RenderColorButton(btn_Completed, Blocking.ColorForSettled_Color);
            RenderColorButton(btn_Uncompleted, Blocking.ColorForUnsettled_Color);
            return true;
        }

        /// <summary>
        /// 根据数据时间,设置首部标题显示
        /// </summary>
        /// <param name="dataDiscription"></param>
        private void SetFunctionName(string dataDiscription)
        {
            this.Text = string.Format("土方(当前数据:{0})", dataDiscription);
        }

        //private string GetBlockingDataByFaceRecorder(string blockingStr)
        //{
        //    PmSoft.Common.CommonClass.FaceRecorderForRevit recorder = PMSoftHelper.GetRecorder(nameof(EarthworkBlockingForm), m_Doc);
        //    recorder.ReadValue(SaveKeyHelper.GetSaveKey(SaveKeyHelper.SaveKeyTypeForEarthWork.EarthworkBlocking, 1), ref blockingStr, recorder.GetValueAsInt(SaveKeyHelper.GetSaveKey(SaveKeyHelper.SaveKeyTypeForEarthWork.EarthworkBlocking_Size, 1), 1000) + 2);
        //    return blockingStr;
        //}

        private void EarthworkBlockingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveDataGridViewSelection();
        }

        DateTimePicker DateTimePicker;
        DateTimePicker DatePicker;
        #endregion

        #region 模态,元素选取
        public ShowDialogType ShowDialogType { set; get; }
        public List<ElementId> SelectedElementIds { set; get; } = new List<ElementId>();
        public void FinishElementSelection()
        {
            switch (ShowDialogType)
            {
                case ShowDialogType.AddElements:
                    if (SelectedElementIds != null)
                    {
                        Block.Add(Blocking, SelectedElementIds);
                        AvoidBlackEdge();
                    }
                    ShowDialogType = ShowDialogType.Idle;
                    break;
                case ShowDialogType.DeleleElements:
                    if (SelectedElementIds != null)
                        Block.Delete(Blocking, SelectedElementIds);
                    using (var transaction = new Transaction(m_Doc, "EarthworkBlocking." + nameof(FinishElementSelection)))
                    {
                        transaction.Start();
                        m_UIDoc.ActiveView.DisableTemporaryViewMode(TemporaryViewMode.TemporaryHideIsolate);//解除隔离显示
                        transaction.Commit();
                    }
                    ShowDialogType = ShowDialogType.Idle;
                    break;
                default:
                    break;
            }
            ValueChanged(null, null);
            //ShowMessage("添加节点结束", $"节点:{Block.Name}现有:{Block.ElementIds.Count()}个元素");
        }
        #endregion

        #region Tab_土方分块
        /// <summary>
        /// 加载选中行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EarthworkBlockingForm_Load(object sender, EventArgs e)
        {
            if (dgv_Blocks.Rows.Count > 0)
                dgv_Blocks.Rows[0].Selected = true;

            //tabControl1_SelectedIndexChanged(null, null);
        }
        /// <summary>
        /// 首列序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Blocks_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(this.dgv_Blocks.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture)
                , this.dgv_Blocks.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }
        /// <summary>
        /// 单击选行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Blocks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rIndex = e.RowIndex;
            if (rIndex != -1)
                dgv_Blocks.Rows[rIndex].Selected = true;
        }
        /// <summary>
        /// 双击编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Blocks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int CIndex = e.ColumnIndex;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewTextBoxColumn textbox = dgv_Blocks.Columns[e.ColumnIndex] as DataGridViewTextBoxColumn;
                if (textbox != null) //如果该列是TextBox列
                {
                    dgv_Blocks.BeginEdit(true); //开始编辑状态
                }
            }
        }
        /// <summary>
        /// 新增节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddNode_Click(object sender, System.EventArgs e)
        {
            Blocking.Add(Blocking.CreateNew());
            Updatedgv_BlockWithSelectionChanged(-1, Blocking.EarthworkBlocks.Count - 1);
            ValueChanged(sender, e);
        }
        /// <summary>
        // 更新DataGridView
        /// </summary>
        private void Updatedgv_Block()
        {
            dgv_Blocks.DataSource = null;
            if (Blocking.EarthworkBlocks.Count > 0)
                dgv_Blocks.DataSource = Blocking.EarthworkBlocks;
            dgv_Blocks.Refresh();
        }
        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DeleteNode_Click(object sender, System.EventArgs e)
        {
            var rows = dgv_Blocks.SelectedRows;
            var index = -1;
            if (rows.Count > 0)
            {
                index = rows[0].Index > 0 ? rows[0].Index - 1 : 0;//删除项为0时 选中项重置为0
            }
            foreach (DataGridViewRow row in rows)
            {
                var data = row.DataBoundItem as TEarthworkBlock;
                if (data != null)
                    Blocking.Delete(data);
            }
            Updatedgv_BlockWithSelectionChanged(-1, index);
            ValueChanged(sender, e);
        }
        private bool IsSingleBlockSelected(DataGridViewSelectedRowCollection rows)
        {
            if (rows == null || rows.Count == 0 || rows[0].DataBoundItem == null)
            {
                if (dgv_Blocks.DataSource != null && Blocking.EarthworkBlocks.Count > 0 && dgv_Blocks.CurrentCell != null)
                {
                    Row = rows[dgv_Blocks.CurrentCell.RowIndex];
                    Block = Row.DataBoundItem as TEarthworkBlock;
                    return true;
                }
                ShowMessage("请选中节点");
                return false;
            }
            if (rows.Count > 1)
            {
                ShowMessage("暂不支持多项处理");
                return false;
            }
            Row = rows[0];
            Block = Row.DataBoundItem as TEarthworkBlock;
            return true;
        }
        /// <summary>
        /// 上移节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_UpNode_Click(object sender, System.EventArgs e)
        {
            var rows = dgv_Blocks.SelectedRows;
            if (IsSingleBlockSelected(rows))
            {
                var row = rows[0];
                if (Blocking.MoveStep1Foward(row.DataBoundItem as TEarthworkBlock))
                {
                    Updatedgv_BlockWithSelectionChanged(row.Index, row.Index - 1);
                }
            }
            ValueChanged(sender, e);
        }
        /// <summary>
        /// 下移节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DownNode_Click(object sender, System.EventArgs e)
        {
            var rows = dgv_Blocks.SelectedRows;
            if (IsSingleBlockSelected(rows))
            {
                var row = rows[0];
                if (Blocking.MoveStep1Backward(row.DataBoundItem as TEarthworkBlock))
                {
                    Updatedgv_BlockWithSelectionChanged(row.Index, row.Index + 1);
                }
            }
            ValueChanged(sender, e);
        }
        /// <summary>
        /// 刷新DataGridView数据并且更新选中
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        private void Updatedgv_BlockWithSelectionChanged(int startIndex, int endIndex)
        {
            Updatedgv_Block();
            if (startIndex >= 0)
                dgv_Blocks.Rows[startIndex].Selected = false;
            if (dgv_Blocks.Rows.Count > 0 && endIndex >= 0)
            {
                dgv_Blocks.Rows[endIndex].Selected = true;
                var cell = dgv_Blocks.Rows.Count > 0 ? dgv_Blocks.Rows[endIndex].Cells[0] : null;
                dgv_Blocks.CurrentCell = cell;
            }
        }
        /// <summary>
        /// 在选中项前插入新节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_InsertBefore_Click(object sender, System.EventArgs e)
        {
            var rows = dgv_Blocks.SelectedRows;
            if (IsSingleBlockSelected(rows))
            {
                var row = rows[0];
                Blocking.InsertBefore(row.Index, Blocking.CreateNew());
                Updatedgv_BlockWithSelectionChanged(row.Index, row.Index);
            }
            ValueChanged(sender, e);
        }
        /// <summary>
        /// 在选中项后插入新节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_InsertAfter_Click(object sender, System.EventArgs e)
        {
            var rows = dgv_Blocks.SelectedRows;
            if (IsSingleBlockSelected(rows))
            {
                var row = rows[0];
                Blocking.InsertAfter(row.Index, Blocking.CreateNew());
                Updatedgv_BlockWithSelectionChanged(row.Index, row.Index + 1);
            }
            ValueChanged(sender, e);
        }
        /// <summary>
        /// 组合选中项和前项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CombineBefore_Click(object sender, System.EventArgs e)
        {
            var rows = dgv_Blocks.SelectedRows;
            if (IsSingleBlockSelected(rows))
            {
                var row = rows[0];
                if (row.Index == 0)
                    return;
                Blocking.CombineBefore(row.Index);
                Updatedgv_BlockWithSelectionChanged(-1, row.Index - 1);
            }
            ValueChanged(sender, e);
        }
        /// <summary>
        /// 组合选中项和后项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CombineAfter_Click(object sender, System.EventArgs e)
        {
            var rows = dgv_Blocks.SelectedRows;
            if (IsSingleBlockSelected(rows))
            {
                var row = rows[0];
                if (row.Index == Blocking.EarthworkBlocks.Count() - 1)
                    return;
                Blocking.CombineAfter(row.Index);
                Updatedgv_BlockWithSelectionChanged(-1, row.Index);
            }
            ValueChanged(sender, e);
        }
        #region 构件变更
        static List<int> SelectedRows { get; set; } = new List<int>();
        static List<int> SelectedCell { get; set; } = new List<int>();
        /// <summary>
        /// 保存列表选中项,由于采用了模态形式,页面显示总是刷新掉选中项
        /// </summary>
        void SaveDataGridViewSelection()
        {
            SelectedRows = new List<int>();
            foreach (DataGridViewRow row in dgv_Blocks.SelectedRows)
            {
                SelectedRows.Add(row.Index);
            }
            SelectedCell = new List<int>();
            if (dgv_Blocks.SelectedCells.Count > 0)
            {
                SelectedCell.Add(dgv_Blocks.SelectedCells[0].RowIndex);
                SelectedCell.Add(dgv_Blocks.SelectedCells[0].ColumnIndex);
            }
        }
        /// <summary>
        /// 加载列表选中项
        /// </summary>
        public void LoadDataGridViewSelection()
        {
            if (dgv_Blocks.Rows.Count == 0)
                return;
            if (SelectedRows.Count() > 0)
            {
                foreach (int rowIndex in SelectedRows)
                {
                    if (dgv_Blocks.Rows.Count > rowIndex)
                        dgv_Blocks.Rows[rowIndex].Selected = true;
                }
            }
            if (SelectedCell.Count() > 0)
            {
                dgv_Blocks.CurrentCell = dgv_Blocks[SelectedCell[1], SelectedCell[0]];
            }
        }
        /// <summary>
        /// 增加构件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddElement_Click(object sender, System.EventArgs e)
        {
            m_UIDoc.ActiveView = VLConstraints.View3D;
            var rows = dgv_Blocks.SelectedRows;
            if (!IsSingleBlockSelected(rows))
            {
                return;
            }
            DialogResult = DialogResult.Retry;
            ShowDialogType = ShowDialogType.AddElements;
            //SaveDataGridViewSelection();
            Close();
        }
        /// <summary>
        /// 删除构件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DeleteElement_Click(object sender, System.EventArgs e)
        {
            m_UIDoc.ActiveView = VLConstraints.View3D;
            var rows = dgv_Blocks.SelectedRows;
            if (!IsSingleBlockSelected(rows))
            {
                return;
            }
            using (var transaction = new Transaction(m_Doc, "EarthworkBlocking." + nameof(btn_DeleteElement_Click)))
            {
                transaction.Start();
                List<ElementId> elementIdsToShow = new List<ElementId>();
                foreach (var elementId in Block.ElementIds)
                {
                    var group = m_UIDoc.ActiveView.Document.GetElement(new ElementId(elementId)) as Group;
                    if (group != null)
                    {
                        foreach (var memberId in group.GetMemberIds())
                        {
                            elementIdsToShow.Add(memberId);
                        }
                    }
                    else
                    {
                        elementIdsToShow.Add(new ElementId(elementId));
                    }
                }
                m_UIDoc.ActiveView.IsolateElementsTemporary(elementIdsToShow);//隔离显示
                transaction.Commit();
            }
            DialogResult = DialogResult.Retry;
            ShowDialogType = ShowDialogType.DeleleElements;
            //SaveDataGridViewSelection();
            Close();
        }
        #endregion

        /// <summary>
        /// 颜色/透明配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CPSettings_Click(object sender, System.EventArgs e)
        {
            var rows = dgv_Blocks.SelectedRows;
            if (IsSingleBlockSelected(rows))
            {
                var row = rows[0];
                var block = row.DataBoundItem as TEarthworkBlock;
                EarthworkBlockCPSettingsForm form = new EarthworkBlockCPSettingsForm(this, block);
                form.ShowDialog();
                //form.BringToFront();
            }
        }

        /// <summary>
        /// 列表编辑结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Blocks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewTextBoxColumn textbox = dgv_Blocks.Columns[e.ColumnIndex] as DataGridViewTextBoxColumn;
            if (textbox != null && textbox.Tag.ToString() == nameof(TEarthworkBlock.Name))
            {
                var data = dgv_Blocks.Rows[e.RowIndex].DataBoundItem as TEarthworkBlock;
                if (data.EarthworkBlockImplementationInfo_Obj.IsSettled && PreName != data.Name)
                {
                    data.EarthworkBlockImplementationInfo_Obj.IsConflicted = true;
                    Blocking.IsImplementationInfoConflicted = true;
                }
            }
            ValueChanged(sender, e);
            foreach (DataGridViewCell cell in dgv_Blocks.SelectedCells)
                dgv_Blocks.Rows[cell.RowIndex].Selected = true;
        }
        public string PreName = "";

        /// <summary>
        /// 列表开始编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Blocks_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewTextBoxColumn textbox = dgv_Blocks.Columns[e.ColumnIndex] as DataGridViewTextBoxColumn;
            var data = dgv_Blocks.Rows[e.RowIndex].DataBoundItem as TEarthworkBlock;
            if (data == null)
            {
                ShowMessage("请添加节点后编辑");
                e.Cancel = true;//解除编辑状态
                return;
            }
            if (textbox != null && textbox.Tag.ToString() == nameof(TEarthworkBlock.Name))
            {
                if (data.EarthworkBlockImplementationInfo_Obj.IsSettled)
                    PreName = data.Name;
            }
        }
        //TODO 存在更改时,关闭时提示保存
        bool IsChanged { set; get; } = false;
        private void ValueChanged(object sender, EventArgs e)
        {
            IsChanged = true;
        }
        /// <summary>
        /// 页面加载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EarthworkBlockingForm_Shown(object sender, EventArgs e)
        {
            LoadDataGridViewSelection();
        }
        #endregion

        #region Tab_Common
        /// <summary>
        /// 确定-提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Commit_Click(object sender, System.EventArgs e)
        {
            //Blocking.Commit(blocking_TargetTime.Text == DateLatest ? DateTime.Now : Convert.ToDateTime(blocking_TargetTime.Text));
            Blocking.Commit(Convert.ToDateTime(blocking_TargetTime.Text));
            DialogResult = DialogResult.OK;
            Close();
        }/// <summary>
         /// 取消
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        /// <summary>
        /// 消息反馈
        /// </summary>
        /// <param name="content"></param>
        /// <param name="title"></param>
        public void ShowMessage(string content, string title = "警告")
        {
            MessageBox.Show(content);
        }
        /// <summary>
        /// tab切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                LoadDataGridViewSelection();
                DisplayTab1Controls();
                HideTab2Controls();
            }
            else
            {
                SaveDataGridViewSelection();

                if (Blocking.IsImplementationInfoConflicted)
                {
                    ShowMessage("分段内容有变动，请修改相应工期设置");
                    Blocking.IsImplementationInfoConflicted = false;
                }
                if (string.IsNullOrEmpty(btn_SortByDate.Text))
                    btn_SortByDate.Text = SortAll;
                UpdateDgv_ImplementationInfoDataSource();//打开"实际施工节点信息管理".加载对应的窗体信息,因为dgv_实际施工节点信息管理总是受dgv_土方分块影响

                DisplayTab2Controls();
                HideTab1Controls();
            }
        }

        private void DisplayTab2Controls()
        {
            lable_OrderByTime.Show();
            btn_SortByDate.Show();
            lbl_BlockingColor.Show();
            lbl_Completed.Show();
            lbl_Uncompleted.Show();
            btn_Completed.Show();
            btn_Uncompleted.Show();
            btn_ViewGt6.Show();
            btn_Preview.Show();
        }
        private void HideTab2Controls()
        {
            lable_OrderByTime.Hide();
            btn_SortByDate.Hide();
            lbl_BlockingColor.Hide();
            lbl_Completed.Hide();
            lbl_Uncompleted.Hide();
            btn_Completed.Hide();
            btn_Uncompleted.Hide();
            btn_ViewGt6.Hide();
            btn_Preview.Hide();
        }

        private void DisplayTab1Controls()
        {
            blocking_DateTime.Show();
            blocking_Load.Show();
            blocking_Save.Show();
            blocking_TargetTime.Show();
            blocking_Left.Show();
            blocking_Right.Show();
        }
        private void HideTab1Controls()
        {
            blocking_DateTime.Hide();
            blocking_Load.Hide();
            blocking_Save.Hide();
            blocking_TargetTime.Hide();
            blocking_Left.Hide();
            blocking_Right.Hide();
        }
        #endregion

        #region Tab_实际施工节点信息管理
        /// <summary>
        /// dgv_Implementation更新首列序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_ImplementationInfo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(this.dgv_Blocks.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture)
                , this.dgv_Blocks.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }
        //public EarthworkBlockImplementationInfo ImplementationInfo { set; get; }
        ///// <summary>
        ///// 选中项变更
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void dgv_ImplementationInfo_SelectionChanged(object sender, EventArgs e)
        //{
        //    var cell = dgv_ImplementationInfo.CurrentCell;
        //    if (Blocking.Blocks.Count > 0 && ImplementationInfo != Blocking.Blocks[cell.RowIndex].ImplementationInfo)
        //    {
        //        ImplementationInfo = Blocking.Blocks[cell.RowIndex].ImplementationInfo;
        //        RenderColorButton(btn_Completed, ImplementationInfo.ColorForSettled);
        //        RenderColorButton(btn_Uncompleted, ImplementationInfo.ColorForUnsettled);
        //    }
        //}
        /// <summary>
        /// 渲染选中颜色到按钮
        /// </summary>
        /// <param name="button"></param>
        /// <param name="color"></param>
        private void RenderColorButton(Button button, System.Drawing.Color color)
        {
            int width = button.Width;
            var height = button.Height;
            var image = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(0, 0, width, height));
            button.Image = image;
        }
        /// <summary>
        /// 设置"已完工"颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Completed_Click(object sender, EventArgs e)
        {
            if (dgv_ImplementationInfo.Rows.Count == 0)
                return;

            //禁止使用自定义颜色  
            colorDialog1.AllowFullOpen = false;
            //提供自己给定的颜色  
            colorDialog1.CustomColors = new int[] { 6916092, 15195440, 16107657, 1836924, 3758726, 12566463, 7526079, 7405793, 6945974, 241502, 2296476, 5130294, 3102017, 7324121, 14993507, 11730944 };
            colorDialog1.ShowHelp = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Blocking.ColorForSettled_Color = colorDialog1.Color;
                RenderColorButton(btn_Completed, Blocking.ColorForSettled_Color);
                ValueChanged(sender, e);
            }
        }
        /// <summary>
        /// 设置"未完工"颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Uncompleted_Click(object sender, EventArgs e)
        {
            if (dgv_ImplementationInfo.Rows.Count == 0)
                return;

            //禁止使用自定义颜色  
            colorDialog1.AllowFullOpen = false;
            //提供自己给定的颜色  
            colorDialog1.CustomColors = new int[] { 6916092, 15195440, 16107657, 1836924, 3758726, 12566463, 7526079, 7405793, 6945974, 241502, 2296476, 5130294, 3102017, 7324121, 14993507, 11730944 };
            colorDialog1.ShowHelp = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Blocking.ColorForUnsettled_Color = colorDialog1.Color;
                RenderColorButton(btn_Uncompleted, Blocking.ColorForUnsettled_Color);
                ValueChanged(sender, e);
            }
        }
        public List<int> CellLocation;
        /// <summary>
        /// 进入编辑状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_ImplementationInfo_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewTextBoxColumn textbox = dgv_ImplementationInfo.Columns[e.ColumnIndex] as DataGridViewTextBoxColumn;
            if (textbox != null) //如果该列是TextBox列
            {
                //冲被编突辑认为已被受理,则解除冲突
                var data = dgv_ImplementationInfo.Rows[e.RowIndex].DataBoundItem as EarthworkBlockImplementationInfo;
                if (data == null)
                {
                    ShowMessage("请添加节点后编辑");
                    e.Cancel = true;//解除编辑状态
                    return;
                }
                if (data.IsConflicted)
                {
                    data.IsConflicted = false;
                    foreach (DataGridViewCell cell in dgv_ImplementationInfo.Rows[e.RowIndex].Cells)
                    {
                        cell.Style.BackColor = System.Drawing.Color.White;
                    }
                }
                if (textbox.Tag != null && textbox.Tag.ToString() == nameof(DateTime))
                {
                    if (dgv_ImplementationInfo.Rows.Count != 0)
                    {
                        DataGridViewCellCancelEventArgs = null;
                        var text = dgv_ImplementationInfo[e.ColumnIndex, e.RowIndex].Value.ToString();
                        DateTimePicker.Value = string.IsNullOrEmpty(text) ? DateTime.Now : DateTime.Parse(text);
                        DataGridViewCellCancelEventArgs = e;
                        var rectangle = dgv_ImplementationInfo.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        DateTimePicker.Size = new Size(rectangle.Width, rectangle.Height);
                        DateTimePicker.Location = new System.Drawing.Point(rectangle.X, rectangle.Y);
                        DateTimePicker.Show();
                        //DateTimePicker.Focus();
                    }
                }
            }
        }
        DataGridViewCellCancelEventArgs DataGridViewCellCancelEventArgs;//有DataGridViewCellCancelEventArgs的是GridView中的日期编辑
        /// <summary>
        /// DateTimePicker失去焦点,认为此时完成编辑,隐藏控件,并退出编辑模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePicker_LostFocus(object sender, EventArgs e)
        {
            EndEdit_DateTimePicker();
        }
        private void EndEdit_DateTimePicker()
        {
            if (!DateTimePicker.Visible)
                return;
            if (DataGridViewCellCancelEventArgs != null)
            {
                if (DateTimePicker.Value > DateTime.Now.AddMinutes(1))
                {
                    DateTimePicker.Value = DateTime.Now;
                    MessageBox.Show("限制输入晚于系统的时间");
                    return;
                }
                var data = (dgv_ImplementationInfo.Rows[DataGridViewCellCancelEventArgs.RowIndex].DataBoundItem as EarthworkBlockImplementationInfo);
                if (dgv_ImplementationInfo.Columns[DataGridViewCellCancelEventArgs.ColumnIndex].DataPropertyName == nameof(EarthworkBlockImplementationInfo.StartTimeStr)
                    && (data.EndTime != DateTime.MinValue && DateTimePicker.Value > data.EndTime))
                {
                    MessageBox.Show("开始时间不可晚于结束时间");
                    return;
                }
                if (dgv_ImplementationInfo.Columns[DataGridViewCellCancelEventArgs.ColumnIndex].DataPropertyName == nameof(EarthworkBlockImplementationInfo.EndTimeStr)
                    && DateTimePicker.Value < data.StartTime)
                {
                    MessageBox.Show("结束时间不可早于开始时间");
                    return;
                }
                dgv_ImplementationInfo[DataGridViewCellCancelEventArgs.ColumnIndex, DataGridViewCellCancelEventArgs.RowIndex].Value = DateTimePicker.Value;
                dgv_ImplementationInfo.EndEdit();
                Blocking.EarthworkBlocks[DataGridViewCellCancelEventArgs.RowIndex].EarthworkBlockImplementationInfo= JsonConvert.SerializeObject(data);

            }
            DateTimePicker.Hide();
        }

        /// <summary>
        /// 退出编辑状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_ImplementationInfo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //发生变更检测 可能没有更改内容,优化一下更好~
            ValueChanged(sender, e);
            foreach (DataGridViewCell cell in dgv_ImplementationInfo.SelectedCells)
                cell.Selected = false;
        }
        /// <summary>
        /// 根据时间过滤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SortByTime_Click(object sender, EventArgs e)
        {
            CurrentEditType = EditType.SortTime;
            DataGridViewCellCancelEventArgs = null;
            EndEdit_DateTimePicker();
            if (IsDatePickerFocused)
            {
                IsDatePickerFocused = false;
            }
            else
            {
                var btn = btn_SortByDate;
                DatePicker.ShowCheckBox = true;
                DatePicker.Location = new System.Drawing.Point(btn.Location.X - (DatePicker.Width - btn.Width) / 2, btn.Location.Y + 24);
                DatePicker.Show();
                DatePicker.BringToFront();
                DatePicker.Focus();
                IsDatePickerFocused = true;
            }
        }
        /// <summary>
        /// DatePicker失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatePicker_LostFocus(object sender, EventArgs e)
        {
            DatePicker_TextChanged(null, null);
            DatePicker.Hide();
        }
        enum EditType
        {
            SortTime,//过滤时间
            DataTime,//数据时间
        }
        EditType CurrentEditType;
        //string DateLatest = "最新";
        string SortAll = "全部";
        /// <summary>
        /// 文本改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatePicker_TextChanged(object sender, EventArgs e)
        {
            switch (CurrentEditType)
            {
                case EditType.SortTime:
                    if (DatePicker.Checked)
                        btn_SortByDate.Text = DatePicker.Text;
                    else
                        btn_SortByDate.Text = SortAll;
                    break;
                case EditType.DataTime:
                    if (DatePicker.Checked)
                        blocking_TargetTime.Text = DatePicker.Text;
                    else
                        blocking_TargetTime.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 时间过滤_文本更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SortByDate_TextChanged(object sender, EventArgs e)
        {
            UpdateDgv_ImplementationInfoDataSource();
        }

        private void UpdateDgv_ImplementationInfoDataSource()
        {
            List<EarthworkBlockImplementationInfo> infos = new List<EarthworkBlockImplementationInfo>();
            if (btn_SortByDate.Text == SortAll)
            {
                dgv_ImplementationInfo.DataSource = null;
                if (Blocking.EarthworkBlocks.Count > 0)
                    infos = Blocking.GetBlockingImplementationInfos();
            }
            else
            {
                var date = DateTime.Parse(btn_SortByDate.Text);
                dgv_ImplementationInfo.DataSource = null;
                if (Blocking.EarthworkBlocks.Count > 0)
                    infos = Blocking.GetBlockingImplementationInfos().Where(c => c.StartTime.Date == date.Date || c.EndTime.Date == date.Date).ToList();
            }
            //dgv_ImplementationInfo.DataSource = infos;
            if (infos.Count() > 0)
            {
                dgv_ImplementationInfo.DataSource = infos;
                var conflicts = infos.Where(c => c.IsConflicted == true);
                foreach (var conflict in conflicts)
                {
                    var index = infos.IndexOf(conflict);
                    foreach (DataGridViewCell cell in dgv_ImplementationInfo.Rows[index].Cells)
                    {
                        cell.Style.BackColor = System.Drawing.Color.Red;//将冲突行置为红色显示
                    }
                }
            }
        }

        bool IsDatePickerFocused { get; set; }
        public object TransactionHelpe { get; private set; }

        /// <summary>
        /// Form的Click事件,主要用于DateTimePicker控件的焦点解除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EarthworkBlockingForm_Click(object sender, EventArgs e)
        {
            CheckDateTimePickerFocus(e);
        }
        private void CheckDateTimePickerFocus(EventArgs e)
        {
            if (DatePicker.Focused)
            {
                var contained = DatePicker.Bounds.Contains((e as MouseEventArgs).X, (e as MouseEventArgs).Y);
                this.Focus();
            }
            if (DateTimePicker.Focused)
            {
                var contained = DateTimePicker.Bounds.Contains((e as MouseEventArgs).X, (e as MouseEventArgs).Y);
                this.Focus();
            }
        }
        /// <summary>
        /// 获取所有元素
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        static IList<Element> GetAllElements(Document doc)
        {
            //按元素隐藏
            return new FilteredElementCollector(doc).WherePasses(new LogicalOrFilter(new ElementIsElementTypeFilter(false), new ElementIsElementTypeFilter(true))).ToElements();
        }
        /// <summary>
        /// 查看(无支撑暴露时间)>6被标红的视图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ViewGt6_Click(object sender, EventArgs e)
        {
            var doc = m_Doc;
            string viewName = "无支撑暴露时间大于6的节点";
            var view = Revit_Document_Helper.GetElementByNameAs<View3D>(doc, viewName);
            if (view == null)
            {
                using (var transaction = new Transaction(doc, "EarthworkBlocking." + nameof(btn_ViewGt6_Click)))
                {
                    transaction.Start();
                    try
                    {
                        var viewFamilyType = new FilteredElementCollector(doc).OfClass(typeof(ViewFamilyType)).ToElements()
                            .First(c => c.Name == "三维视图");
                        view = View3D.CreateIsometric(doc, viewFamilyType.Id);
                        view.Name = viewName;
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.RollBack();
                        ShowMessage($"视图({viewName})新建失败,错误详情:" + ex.ToString(), "消息");
                    }
                }
            }
            //// 渲染处理
            using (var transaction = new Transaction(doc, "EarthworkBlocking." + nameof(btn_ViewGt6_Click)))
            {
                transaction.Start();
                var overrideGraphicSettings = new OverrideGraphicSettings();
                var allElements = GetAllElements(doc);
                foreach (var element in allElements)
                    Revit_Helper.ApplyOverrideGraphicSettings(view, element.Id, overrideGraphicSettings);
                //view.SetElementOverrides(element.Id, overrideGraphicSettings);
                foreach (var block in Blocking.EarthworkBlocks)
                {
                    EarthworkBlockCPSettings setting = new EarthworkBlockCPSettings();
                    setting.FillerId = EarthworkBlockCPSettings.GetDefaultFillPatternId(doc).IntegerValue;
                    if (block.EarthworkBlockImplementationInfo_Obj.ExposureTime > 6)
                    {
                        setting.Color = System.Drawing.Color.Red;
                    }
                    else
                    {
                        setting.SurfaceTransparency = 50;//<6的提升透明度
                    }
                    setting.ApplySettingForDisplay(view, block.ElementIds.Select(c => new ElementId(c)).ToList());
                }
                transaction.Commit();
            }
            m_UIDoc.ActiveView = view;
            ShowDialogType = ShowDialogType.ViewGT6;
            DialogResult = DialogResult.Retry;
            //SaveDataGridViewSelection();
            this.Close();
            //ShowMessage("消息", $"三维视图({viewName})更新成功");
        }
        /// <summary>
        /// 查看按完工和未完工标注颜色的视图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Preview_Click(object sender, System.EventArgs e)
        {
            var doc = m_Doc;
            string viewName = "节点施工进度";
            var view = Revit_Document_Helper.GetElementByNameAs<View3D>(doc, viewName);
            if (view == null)
            {
                using (var transaction = new Transaction(doc, "EarthworkBlocking." + nameof(btn_Preview_Click)))
                {
                    transaction.Start();
                    try
                    {
                        var viewFamilyType = new FilteredElementCollector(doc).OfClass(typeof(ViewFamilyType)).ToElements()
                            .First(c => c.Name == "三维视图");
                        view = View3D.CreateIsometric(doc, viewFamilyType.Id);
                        view.Name = viewName;
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.RollBack();
                        ShowMessage($"视图({viewName})新建失败,错误详情:" + ex.ToString(), "消息");
                    }
                }
            }
            // 渲染处理
            using (var transaction = new Transaction(doc, "EarthworkBlocking." + nameof(btn_Preview_Click)))
            {
                transaction.Start();
                var overrideGraphicSettings = new OverrideGraphicSettings();
                var allElements = GetAllElements(doc);
                foreach (var element in allElements)
                    Revit_Helper.ApplyOverrideGraphicSettings(view, element.Id, overrideGraphicSettings);
                //view.SetElementOverrides(element.Id, overrideGraphicSettings);
                foreach (var block in Blocking.EarthworkBlocks)
                {
                    EarthworkBlockCPSettings setting = new EarthworkBlockCPSettings();
                    setting.FillerId = EarthworkBlockCPSettings.GetDefaultFillPatternId(doc).IntegerValue;
                    setting.SurfaceTransparency = 0;
                    if (block.EarthworkBlockImplementationInfo_Obj.IsSettled)
                    {
                        setting.Color = Blocking.ColorForSettled_Color;
                    }
                    else
                    {
                        setting.Color = Blocking.ColorForUnsettled_Color;
                    }
                    setting.ApplySettingForDisplay(view, block.ElementIds.Select(c => new ElementId(c)).ToList());
                }
                transaction.Commit();
            }
            m_UIDoc.ActiveView = view;
            ShowDialogType = ShowDialogType.ViewCompletion;
            DialogResult = DialogResult.Retry;
            //SaveDataGridViewSelection();
            this.Close();
            //ShowMessage("消息", $"三维视图({viewName})更新成功");
        }
        #endregion
        private void tabControl1_Click(object sender, EventArgs e)
        {
            EndEdit_DateTimePicker();
        }
        private void dgv_ImplementationInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EndEdit_DateTimePicker();
        }
        private void btn_ExcelImport_Click(object sender, EventArgs e)
        {
            SaveDataGridViewSelection();
            //选择文件
            string path;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Excel 文件(*.xls,*.xlsx)|*.xls;*.xlsx";
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            path = dialog.FileName;
            if (!File.Exists(path))
            {
                ShowMessage("无效的文件路径");
                return;
            }
            //打开Excel
            Microsoft.Office.Interop.Excel.ApplicationClass excelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
            var workbook = excelApp.Workbooks.Open(path);
            if (workbook == null)
            {
                ShowMessage("Workbook文档对象无效");
                return;
            }
            //获取Sheet
            var sheetName = "土方分块";
            Microsoft.Office.Interop.Excel.Worksheet sheet = null;
            foreach (Microsoft.Office.Interop.Excel.Worksheet s in workbook.Worksheets)
            {
                if (s.Name == sheetName)
                {
                    sheet = s;
                    break;
                }
            }
            if (sheet == null)
            {
                ShowMessage("未找到\"土方分块\"Sheet页");
                return;
            }
            //表头校验
            if (sheet.GetCellValueAsString(1, 1).Trim() != "节点名称")
            {
                ShowMessage("表头校验未通过-节点名称");
                return;
            }
            if (sheet.GetCellValueAsString(1, 2).Trim() != "开始时间")
            {
                ShowMessage("表头校验未通过-开始时间");
                return;
            }
            if (sheet.GetCellValueAsString(1, 3).Trim() != "无支撑暴露时间")
            {
                ShowMessage("表头校验未通过-无支撑暴露时间");
                return;
            }
            if (sheet.GetCellValueAsString(1, 4).Trim() != "结束时间")
            {
                ShowMessage("表头校验未通过-结束时间");
                return;
            }
            if (sheet.GetCellValueAsString(1, 5).Trim() != "说明")
            {
                ShowMessage("表头校验未通过-说明");
                return;
            }
            //内容解析
            int rowIndex = 2;
            bool isEndTimeEarlier = false;
            bool isStartTimeError = false;
            bool isEndTimeError = false;
            bool isTimeSpanError = false;
            TEarthworkBlocking blocking;
            if (cb_ImportOverwrite.Checked)
            {
                blocking = new TEarthworkBlocking();
            }
            else
            {
                blocking = Blocking;
            }
            while (!string.IsNullOrEmpty(sheet.GetCellValueAsString(rowIndex, 1)))
            {
                var name = sheet.GetCellValueAsString(rowIndex, 1);
                var startTimeStr = sheet.GetCellValueAsString(rowIndex, 2);
                var timeSpanStr = sheet.GetCellValueAsString(rowIndex, 3);
                var endTimeStr = sheet.GetCellValueAsString(rowIndex, 4);
                var description = sheet.GetCellValueAsString(rowIndex, 5);
                rowIndex++;
                DateTime startTime, endTime;
                double timeSpan;
                if (!DateTime.TryParse(startTimeStr, out startTime))
                {
                    isStartTimeError = true;
                    continue;
                }
                if (!DateTime.TryParse(endTimeStr, out endTime))
                {
                    isEndTimeError = true;
                    continue;
                }
                if (startTime > endTime)
                {
                    isEndTimeEarlier = true;
                    continue;
                }
                if (!double.TryParse(timeSpanStr, out timeSpan))
                {
                    isTimeSpanError = true;
                    continue;
                }
                var block = new TEarthworkBlock(DateTime.MinValue,blocking.GetEarthworkBlockMaxId())
                {
                    Name = name,
                    Description = description,
                    EarthworkBlockImplementationInfo_Obj = new EarthworkBlockImplementationInfo()
                    {
                        StartTime = startTime,
                        EndTime = endTime,
                        ExposureTime = timeSpan,
                    }
                };
                blocking.Add(block);
            }
            if (isEndTimeEarlier || isStartTimeError || isEndTimeError || isTimeSpanError)
            {
                ShowMessage("部分导入的数据格式存在异常,或者不符合数据的规范");
            }
            ExcelHelper.KillProcess();
            Blocking = blocking;
            Blocking.RemoveInvalidElementId(m_Doc);
            Updatedgv_Block();
            if (cb_ImportOverwrite.Checked)
            {
                Updatedgv_BlockWithSelectionChanged(-1, 1);
            }
            else
            {
                LoadDataGridViewSelection();
            }
        }

        #region 扩展周期存储
        public DateTime TargetIssueTime { get { return Convert.ToDateTime(blocking_TargetTime.Text); } set { blocking_TargetTime.Text = value.ToString(); } }

        private void blocking_Save_Click(object sender, EventArgs e)
        {
            if (TargetIssueTime>DateTime.Now)
            {
                ShowMessage("保存不可超出当前的系统时间");
                return;
            }
            TransactionHelper.HandleTransactionEvent(SQLiteHelper.GetConnectingString(), (session) =>
            {
                Blocking.Commit(TargetIssueTime);
                ShowMessage("保存成功");
            }, (ex) => { ShowMessage("保存失败"); });
        }

        /// <summary>
        /// 向前搜索上一个有数据的日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void blocking_Left_Click(object sender, EventArgs e)
        {
            var previous = Blocking.GetPreviousIssueTime(TargetIssueTime);
            if (previous == DateTime.MinValue)
            {
                ShowMessage("已到最前,无上一份数据");
                return;
            }
            TargetIssueTime = previous;
            blocking_Load_Click(null, null);
        }

        /// <summary>
        /// 向\后搜索下一个有数据的日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void blocking_Right_Click(object sender, EventArgs e)
        {
            var next = Blocking.GetNextIssueTime(TargetIssueTime);
            if (next == DateTime.MinValue)
            {
                ShowMessage("已到最末,无下一份数据");
                return;
            }
            TargetIssueTime = next;
            blocking_Load_Click(null, null);
        }

        private void blocking_Load_Click(object sender, EventArgs e)
        {
            TransactionHelper.HandleTransactionEvent(SQLiteHelper.GetConnectingString(), (session) =>
            {
                if (!Blocking.CheckExistence(session, TargetIssueTime))
                {
                    ShowMessage("该日期无数据存在");
                    return;
                }
                Blocking.LoadSolid(TargetIssueTime);
                SetFunctionName(Blocking.IssueDateTime.ToString("yyyy/MM/dd"));
                Blocking.RemoveInvalidElementId(VLConstraints.Doc);
                if (Blocking.EarthworkBlocks.Count() > 0)
                    dgv_Blocks.DataSource = Blocking.EarthworkBlocks;
                else
                    dgv_Blocks.DataSource = null;
            });
            RenderColorButton(btn_Completed, Blocking.ColorForSettled_Color);
            RenderColorButton(btn_Uncompleted, Blocking.ColorForUnsettled_Color);
            AvoidBlackEdge();
            SelectedRows.Clear();
            SelectedCell.Clear();
            if (dgv_Blocks.Rows.Count > 0)
            {
                dgv_Blocks.Rows[0].Selected = true;
                SelectedRows.Add(0);
            }
        }

        public void AvoidBlackEdge()
        {
            using (var transaction = new Transaction(VLConstraints.Doc, "EarthworkBlocking.Regenerate"))
            {
                transaction.Start();
                VLConstraints.UIDoc.RefreshActiveView();//两次刷新才能避免黑框问题
                VLConstraints.UIDoc.RefreshActiveView();
                transaction.Commit();
            }
        }

        private void blocking_TargetTime_Click(object sender, EventArgs e)
        {
            CurrentEditType = EditType.DataTime;
            DataGridViewCellCancelEventArgs = null;
            EndEdit_DateTimePicker();
            if (IsDatePickerFocused)
            {
                IsDatePickerFocused = false;
            }
            else
            {
                var btn = blocking_TargetTime;
                DatePicker.ShowCheckBox = false;
                DatePicker.Checked = true;
                DatePicker.Location = new System.Drawing.Point(btn.Location.X - (DatePicker.Width - btn.Width) / 2, btn.Location.Y + 24);
                DatePicker.Show();
                DatePicker.BringToFront();
                DatePicker.Focus();
                IsDatePickerFocused = true;
            }
        }
        #endregion

    }
}
