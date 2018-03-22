using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using PmSoft.ConstructionManagement.SubsidenceMonitor.Entities;
using PmSoft.ConstructionManagement.Utilities;
using Newtonsoft.Json;
using PmSoft.Common.CommonClass;
using System.Windows.Forms;

namespace PmSoft.ConstructionManagement.SubsidenceMonitor.UI
{
    public partial class WarnSettingsForm : System.Windows.Forms.Form
    {
        string ShowTitle = "警告";
        Document Document { set; get; }
        WarnSettings WarnSettings { set; get; } = new WarnSettings();

        public WarnSettingsForm(Document document)
        {
            InitializeComponent();

            Document = document;
            FaceRecorderForRevit recorder = PMSoftHelper.GetRecorder(nameof(WarnSettings), Document);
            var str = recorder.GetValue(SaveKeyHelper.GetSaveKey(SaveKeyHelper.SaveKeyTypeForSubsidenceMonitor.WarnSettings, 1), "", 1000);
            if (!string.IsNullOrEmpty(str))
            {
                WarnSettings = JsonConvert.DeserializeObject<WarnSettings>(str);
                if (WarnSettings.BuildingSubsidence_Day!=int.MinValue)
                    tb_BuildingSubsidence_Day.Text = WarnSettings.BuildingSubsidence_Day.ToString();
                if (WarnSettings.BuildingSubsidence_DailyMillimeter != int.MinValue)
                    tb_BuildingSubsidence_DailyMillimeter.Text = WarnSettings.BuildingSubsidence_DailyMillimeter.ToString();
                if (WarnSettings.BuildingSubsidence_SumMillimeter != int.MinValue)
                    tb_BuildingSubsidence_SumMillimeter.Text = WarnSettings.BuildingSubsidence_SumMillimeter.ToString();
                if (WarnSettings.SurfaceSubsidence_Day != int.MinValue)
                    tb_SurfaceSubsidence_Day.Text = WarnSettings.SurfaceSubsidence_Day.ToString();
                if (WarnSettings.SurfaceSubsidence_DailyMillimeter != int.MinValue)
                    tb_SurfaceSubsidence_DailyMillimeter.Text = WarnSettings.SurfaceSubsidence_DailyMillimeter.ToString();
                if (WarnSettings.SurfaceSubsidence_SumMillimeter != int.MinValue)
                    tb_SurfaceSubsidence_SumMillimeter.Text = WarnSettings.SurfaceSubsidence_SumMillimeter.ToString();
                if (WarnSettings.STBAP_StandardAxle != int.MinValue)
                    tb_STBAP_AxlePower.Text = WarnSettings.STBAP_StandardAxle.ToString();
                if (WarnSettings.STBAP_MaxAxleRate != int.MinValue)
                    tb_STBAP_MaxAxle.Text = WarnSettings.STBAP_MaxAxleRate.ToString();
                if (WarnSettings.STBAP_MinAxleRate != int.MinValue)
                    tb_STBAP_MinAxle.Text = WarnSettings.STBAP_MinAxleRate.ToString();
                if (WarnSettings.PressedPipeLineSubsidence_Day != int.MinValue)
                    tb_StressedPipeLineSubsidence_Day.Text = WarnSettings.PressedPipeLineSubsidence_Day.ToString();
                if (WarnSettings.PressedPipeLineSubsidence_PipelineMillimeter != int.MinValue)
                    tb_StressedPipeLineSubsidence_PipelineMillimeter.Text = WarnSettings.PressedPipeLineSubsidence_PipelineMillimeter.ToString();
                if (WarnSettings.PressedPipeLineSubsidence_WellMillimeter != int.MinValue)
                    tb_StressedPipeLineSubsidence_WellMillimeter.Text = WarnSettings.PressedPipeLineSubsidence_WellMillimeter.ToString();
                if (WarnSettings.PressedPipeLineSubsidence_SumMillimeter != int.MinValue)
                    tb_StressedPipeLineSubsidence_SumMillimeter.Text = WarnSettings.PressedPipeLineSubsidence_SumMillimeter.ToString();
                if (WarnSettings.UnpressedPipeLineSubsidence_Day != int.MinValue)
                    tb_UnstressedPipeLineSubsidence_Day.Text = WarnSettings.UnpressedPipeLineSubsidence_Day.ToString();
                if (WarnSettings.UnpressedPipeLineSubsidence_PipelineMillimeter != int.MinValue)
                    tb_UnstressedPipeLineSubsidence_PipelineMillimeter.Text = WarnSettings.UnpressedPipeLineSubsidence_PipelineMillimeter.ToString();
                if (WarnSettings.UnpressedPipeLineSubsidence_WellMillimeter != int.MinValue)
                    tb_UnstressedPipeLineSubsidence_WellMillimeter.Text = WarnSettings.UnpressedPipeLineSubsidence_WellMillimeter.ToString();
                if (WarnSettings.UnpressedPipeLineSubsidence_SumMillimeter != int.MinValue)
                    tb_UnstressedPipeLineSubsidence_SumMillimeter.Text = WarnSettings.UnpressedPipeLineSubsidence_SumMillimeter.ToString();
                if (WarnSettings.SkewBack_WellMillimeter != int.MinValue)
                    tb_SkewBack_WellMillimeter.Text = WarnSettings.SkewBack_WellMillimeter.ToString();
                if (WarnSettings.SkewBack_StandardMillimeter != int.MinValue)
                    tb_SkewBack_StandardMillimeter.Text = WarnSettings.SkewBack_StandardMillimeter.ToString();
                if (WarnSettings.SkewBack_Speed != int.MinValue)
                    tb_SkewBack_Speed.Text = WarnSettings.SkewBack_Speed.ToString();
                if (WarnSettings.SkewBack_Day != int.MinValue)
                    tb_SkewBack_Day.Text = WarnSettings.SkewBack_Day.ToString();
                //监测项
                if (WarnSettings.PressedPipeLineSubsidence_WellNow != int.MinValue)
                    tb_StressedPipeLineSubsidence_WellNow.Text = WarnSettings.PressedPipeLineSubsidence_WellNow.ToString();
                if (WarnSettings.UnpressedPipeLineSubsidence_WellNow != int.MinValue)
                    tb_UnstressedPipeLineSubsidence_WellNow.Text = WarnSettings.UnpressedPipeLineSubsidence_WellNow.ToString();
                if (WarnSettings.SkewBack_WellNow != int.MinValue)
                    tb_SkewBack_WellNow.Text = WarnSettings.SkewBack_WellNow.ToString();
                if (WarnSettings.SkewBack_StandardNow != int.MinValue)
                    tb_SkewBack_StandardNow.Text = WarnSettings.SkewBack_StandardNow.ToString();
                if (WarnSettings.SkewBack_Day != int.MinValue)
                    tb_SkewBack_Day.Text = WarnSettings.SkewBack_Day.ToString();
            }
        }

        void ShowMessage(string title, string message)
        {
            TaskDialog.Show(title, message);
        }
        string MessageSuffix = "不是有效的数值";
        private void btn_Submit_Click(object sender, System.EventArgs e)
        {
            //int $1;\r\nif(int.TryParse(tb_$1.Text, out $1))\r\nWarnSettings.$1 = $1;\r\nelse\r\n ShowMessage(ShowTitle, "$1" + "不是有效的数值");
            //建筑物沉降
            int BuildingSubsidence_Day;
            if (int.TryParse(tb_BuildingSubsidence_Day.Text, out BuildingSubsidence_Day))
                WarnSettings.BuildingSubsidence_Day = BuildingSubsidence_Day;
            else
            {
                ShowMessage(ShowTitle, WarnSettings.Tag_BuildingSubsidence_Day + MessageSuffix);
                return;
            }
            int BuildingSubsidence_DailyMillimeter;
            if (int.TryParse(tb_BuildingSubsidence_DailyMillimeter.Text, out BuildingSubsidence_DailyMillimeter))
                WarnSettings.BuildingSubsidence_DailyMillimeter = BuildingSubsidence_DailyMillimeter;
            else
            {
                ShowMessage(ShowTitle, WarnSettings.Tag_BuildingSubsidence_DailyMillimeter + MessageSuffix);
                return;
            }
            int BuildingSubsidence_SumMillimeter;
            if (int.TryParse(tb_BuildingSubsidence_SumMillimeter.Text, out BuildingSubsidence_SumMillimeter))
                WarnSettings.BuildingSubsidence_SumMillimeter = BuildingSubsidence_SumMillimeter;
            else
            {
                ShowMessage(ShowTitle, WarnSettings.Tag_BuildingSubsidence_SumMillimeter + MessageSuffix);
                return;
            }
            //地表沉降
            int SurfaceSubsidence_Day;
            if (int.TryParse(tb_SurfaceSubsidence_Day.Text, out SurfaceSubsidence_Day))
                WarnSettings.SurfaceSubsidence_Day = SurfaceSubsidence_Day;
            else
            {
                ShowMessage(ShowTitle, WarnSettings.Tag_SurfaceSubsidence_Day + MessageSuffix);
                return;
            }
            int SurfaceSubsidence_DailyMillimeter;
            if (int.TryParse(tb_SurfaceSubsidence_DailyMillimeter.Text, out SurfaceSubsidence_DailyMillimeter))
                WarnSettings.SurfaceSubsidence_DailyMillimeter = SurfaceSubsidence_DailyMillimeter;
            else
            {
                ShowMessage(ShowTitle, WarnSettings.Tag_SurfaceSubsidence_DailyMillimeter + MessageSuffix);
                return;
            }
            int SurfaceSubsidence_SumMillimeter;
            if (int.TryParse(tb_SurfaceSubsidence_SumMillimeter.Text, out SurfaceSubsidence_SumMillimeter))
                WarnSettings.SurfaceSubsidence_SumMillimeter = SurfaceSubsidence_SumMillimeter;
            else
            {
                ShowMessage(ShowTitle, WarnSettings.Tag_SurfaceSubsidence_SumMillimeter + MessageSuffix);
                return;
            }
            //钢支撑轴力
            int STBAP_AxlePower;
            if (int.TryParse(tb_STBAP_AxlePower.Text, out STBAP_AxlePower))
                WarnSettings.STBAP_StandardAxle = STBAP_AxlePower;
            else
            {
                ShowMessage(ShowTitle, WarnSettings.Tag_STBAP_AxlePower + MessageSuffix);
                return;
            }
            int STBAP_MaxAxle;
            if (int.TryParse(tb_STBAP_MaxAxle.Text, out STBAP_MaxAxle))
                WarnSettings.STBAP_MaxAxleRate = STBAP_MaxAxle;
            else
            {
                ShowMessage(ShowTitle, WarnSettings.Tag_STBAP_MaxAxle + MessageSuffix);
                return;
            }
            int STBAP_MinAxle;
            if (int.TryParse(tb_STBAP_MinAxle.Text, out STBAP_MinAxle))
                WarnSettings.STBAP_MinAxleRate = STBAP_MinAxle;
            else
            {
                ShowMessage(ShowTitle, WarnSettings.Tag_STBAP_MinAxle + MessageSuffix);
                return;
            }
            //管线沉降(有压)
            int StressedPipeLineSubsidence_Day;
            if (int.TryParse(tb_StressedPipeLineSubsidence_Day.Text, out StressedPipeLineSubsidence_Day))
                WarnSettings.PressedPipeLineSubsidence_Day = StressedPipeLineSubsidence_Day;
            else
            {
                ShowMessage(ShowTitle, WarnSettings.Tag_PressedPipeLineSubsidence_Day + MessageSuffix);
                return;
            }
            int StressedPipeLineSubsidence_PipelineMillimeter;
            if (int.TryParse(tb_StressedPipeLineSubsidence_PipelineMillimeter.Text, out StressedPipeLineSubsidence_PipelineMillimeter))
                WarnSettings.PressedPipeLineSubsidence_PipelineMillimeter = StressedPipeLineSubsidence_PipelineMillimeter;
            else
            {
                ShowMessage(ShowTitle, WarnSettings.Tag_PressedPipeLineSubsidence_PipelineMillimeter + MessageSuffix);
                return;
            }
            if (!CheckPressedPipeLineSubsidenceWellMillimeter())
                return;
            int StressedPipeLineSubsidence_SumMillimeter;
            if (int.TryParse(tb_StressedPipeLineSubsidence_SumMillimeter.Text, out StressedPipeLineSubsidence_SumMillimeter))
                WarnSettings.PressedPipeLineSubsidence_SumMillimeter = StressedPipeLineSubsidence_SumMillimeter;
            else
            {
                ShowMessage(ShowTitle, WarnSettings.Tag_PressedPPipeLineSubsidence_SumMillimeter + MessageSuffix);
                return;
            }
            //管线沉降(无压)
            int UnstressedPipeLineSubsidence_Day;
            if (int.TryParse(tb_UnstressedPipeLineSubsidence_Day.Text, out UnstressedPipeLineSubsidence_Day))
                WarnSettings.UnpressedPipeLineSubsidence_Day = UnstressedPipeLineSubsidence_Day;
            else
            {
                ShowMessage(ShowTitle, WarnSettings.Tag_UnpressedPipeLineSubsidence_Day + MessageSuffix);
                return;
            }
            int UnstressedPipeLineSubsidence_PipelineMillimeter;
            if (int.TryParse(tb_UnstressedPipeLineSubsidence_PipelineMillimeter.Text, out UnstressedPipeLineSubsidence_PipelineMillimeter))
                WarnSettings.UnpressedPipeLineSubsidence_PipelineMillimeter = UnstressedPipeLineSubsidence_PipelineMillimeter;
            else
            {
                ShowMessage(ShowTitle, WarnSettings.Tag_UnpressedPipeLineSubsidence_PipelineMillimeter + MessageSuffix);
                return;
            }
            if (!CheckUnstressedPipeLineSubsidenceWellMillimeter())
                return;
            int UnstressedPipeLineSubsidence_SumMillimeter;
            if (int.TryParse(tb_UnstressedPipeLineSubsidence_SumMillimeter.Text, out UnstressedPipeLineSubsidence_SumMillimeter))
                WarnSettings.UnpressedPipeLineSubsidence_SumMillimeter = UnstressedPipeLineSubsidence_SumMillimeter;
            else
            {
                ShowMessage(ShowTitle, WarnSettings.Tag_UnpressedPipeLineSubsidence_SumMillimeter + MessageSuffix);
                return;
            }
            //墙体水平位移(侧斜)
            if (!CheckSkewBackWellMillimeter())
                return;
            if (!Checktb_SkewBackStandardMillimeter())
                return;
            int SkewBack_Speed;
            if (int.TryParse(tb_SkewBack_Speed.Text, out SkewBack_Speed))
                WarnSettings.SkewBack_Speed = SkewBack_Speed;
            else
            {
                ShowMessage(ShowTitle, WarnSettings.Tag_SkewBack_Speed + MessageSuffix);
                return;
            }
            int SkewBack_Day;
            if (int.TryParse(tb_SkewBack_Day.Text, out SkewBack_Day))
                WarnSettings.SkewBack_Day = SkewBack_Day;
            else
            {
                ShowMessage(ShowTitle, WarnSettings.Tag_SkewBack_Day + MessageSuffix);
                return;
            }
            FaceRecorderForRevit recorder = PMSoftHelper.GetRecorder(nameof(WarnSettings), Document);
            var jsonObj = JsonConvert.SerializeObject(WarnSettings);
            recorder.WriteValue(SaveKeyHelper.GetSaveKey(SaveKeyHelper.SaveKeyTypeForSubsidenceMonitor.WarnSettings, 1), jsonObj);
            this.Close();
        }

        private bool Checktb_SkewBackStandardMillimeter()
        {
            int SkewBack_StandardMillimeter;
            if (int.TryParse(tb_SkewBack_StandardMillimeter.Text, out SkewBack_StandardMillimeter))
            {
                WarnSettings.SkewBack_StandardMillimeter = SkewBack_StandardMillimeter;
                return true;
            }
            else
            {
                ShowMessage(ShowTitle, WarnSettings.Tag_SkewBack_StandardMillimeter + MessageSuffix);
                return false;
            }
        }

        private bool CheckSkewBackWellMillimeter()
        {
            int SkewBack_WellMillimeter;
            if (int.TryParse(tb_SkewBack_WellMillimeter.Text, out SkewBack_WellMillimeter))
            {
                WarnSettings.SkewBack_WellMillimeter = SkewBack_WellMillimeter;
                return true;
            }
            else
            {
                ShowMessage(ShowTitle, WarnSettings.Tag_SkewBack_WellMillimeter + MessageSuffix);
                return false;
            }
        }

        private bool CheckUnstressedPipeLineSubsidenceWellMillimeter()
        {
            int UnstressedPipeLineSubsidence_WellMillimeter;
            if (int.TryParse(tb_UnstressedPipeLineSubsidence_WellMillimeter.Text, out UnstressedPipeLineSubsidence_WellMillimeter))
            {
                WarnSettings.UnpressedPipeLineSubsidence_WellMillimeter = UnstressedPipeLineSubsidence_WellMillimeter;
                return true;
            }
            else
            {
                ShowMessage(ShowTitle, WarnSettings.Tag_UnpressedPipeLineSubsidence_WellMillimeter + MessageSuffix);
                return false;
            }
        }

        private bool CheckPressedPipeLineSubsidenceWellMillimeter()
        {
            int StressedPipeLineSubsidence_WellMillimeter;
            if (int.TryParse(tb_StressedPipeLineSubsidence_WellMillimeter.Text, out StressedPipeLineSubsidence_WellMillimeter))
            {
                WarnSettings.PressedPipeLineSubsidence_WellMillimeter = StressedPipeLineSubsidence_WellMillimeter;
                return true;
            }
            else
            {
                ShowMessage(ShowTitle, WarnSettings.Tag_PressedPipeLineSubsidence_WellMillimeter + MessageSuffix);
                return false;
            }
        }

        private void btn_Cancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void tb_StressedPipeLineSubsidence_WellNow_Leave(object sender, System.EventArgs e)
        {
            if (!CheckPressedPipeLineSubsidenceWellMillimeter())
                return;
            string key = "检测项 - (有压)自流井沉降值";
            var value = 0;
            if (!int.TryParse(tb_StressedPipeLineSubsidence_WellNow.Text, out value))
            {
                ShowMessage(ShowTitle, $"请输入有效的{key}");
                return;
            }
            WarnSettings.PressedPipeLineSubsidence_WellNow = value;
            double warnValue = WarnSettings.PressedPipeLineSubsidence_WellMillimeter;
            if (warnValue == int.MinValue)
            {
                ShowMessage(ShowTitle, $"未设置{key}的预警值");
                return;
            }
            if (value >= warnValue * WarnSettings.CloseCoefficient && value < warnValue * WarnSettings.OverCoefficient)
            {
                ShowMessage(ShowTitle, $"输入的{key}接近设定的预警值");
            }
            if (value >= warnValue * WarnSettings.OverCoefficient)
            {
                ShowMessage(ShowTitle, $"输入的{key}超出了设定的预警值");
            }
        }
        private void tb_UnstressedPipeLineSubsidence_WellNow_Leave(object sender, System.EventArgs e)
        {
            if (!CheckUnstressedPipeLineSubsidenceWellMillimeter())
                return;
            string key = "检测项-(无压)自流井沉降值";
            var value = 0;
            if (!int.TryParse(tb_UnstressedPipeLineSubsidence_WellNow.Text, out value))
            {
                ShowMessage(ShowTitle, $"请输入有效的{key}");
                return;
            }
            WarnSettings.UnpressedPipeLineSubsidence_WellNow = value;
            double warnValue = WarnSettings.UnpressedPipeLineSubsidence_WellMillimeter;
            if (warnValue == int.MinValue)
            {
                ShowMessage(ShowTitle, $"未设置{key}的预警值");
                return;
            }
            if (value >= warnValue * WarnSettings.CloseCoefficient && value < warnValue * WarnSettings.OverCoefficient)
            {
                ShowMessage(ShowTitle, $"输入的{key}接近设定的预警值");
            }
            if (value >= warnValue * WarnSettings.OverCoefficient)
            {
                ShowMessage(ShowTitle, $"输入的{key}超出了设定的预警值");
            }
        }
        private void tb_SkewBack_WellNow_Leave(object sender, System.EventArgs e)
        {
            if (!CheckSkewBackWellMillimeter())
                return;
            string key = "检测项-端头井累计值";
            var value = 0;
            if (!int.TryParse(tb_SkewBack_WellNow.Text, out value))
            {
                ShowMessage(ShowTitle, $"请输入有效的{key}");
                return;
            }
            WarnSettings.SkewBack_WellNow = value;
            double warnValue = WarnSettings.SkewBack_WellMillimeter;
            if (warnValue == int.MinValue)
            {
                ShowMessage(ShowTitle, $"未设置{key}的预警值");
                return;
            }
            if (value >= warnValue * WarnSettings.CloseCoefficient && value < warnValue * WarnSettings.OverCoefficient)
            {
                ShowMessage(ShowTitle, $"输入的{key}接近设定的预警值");
            }
            if (value >= warnValue * WarnSettings.OverCoefficient)
            {
                ShowMessage(ShowTitle, $"输入的{key}超出了设定的预警值");
            }
        }
        private void tb_SkewBack_StandardNow_Leave(object sender, System.EventArgs e)
        {
            if (!Checktb_SkewBackStandardMillimeter())
                return;
            string key = "检测项-端头井累计值";
            var value = 0;
            if (!int.TryParse(tb_SkewBack_StandardNow.Text, out value))
            {
                ShowMessage(ShowTitle, $"请输入有效的{key}");
                return;
            }
            WarnSettings.SkewBack_StandardNow = value;
            double warnValue = WarnSettings.SkewBack_StandardMillimeter;
            if (warnValue == int.MinValue)
            {
                ShowMessage(ShowTitle, $"未设置{key}的预警值");
                return;
            }
            if (value >= warnValue * WarnSettings.CloseCoefficient && value < warnValue * WarnSettings.OverCoefficient)
            {
                ShowMessage(ShowTitle, $"输入的{key}接近设定的预警值");
            }
            if (value >= warnValue * WarnSettings.OverCoefficient)
            {
                ShowMessage(ShowTitle, $"输入的{key}超出了设定的预警值");
            }
        }
    }
}
