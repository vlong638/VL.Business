﻿using Microsoft.Office.Interop.Excel;
using PmSoft.ConstructionManagement.SubsidenceMonitor.Entities;
using PmSoft.ConstructionManagement.SubsidenceMonitor.Operators;
using System.Collections.Generic;

namespace PmSoft.ConstructionManagement.SubsidenceMonitor.Interfaces
{/// <summary>
 /// (职责模型)
 /// 多项Data,可前后翻页,可新增,可删除
 /// 选中项作为MemorableData
 /// </summary>
 /// <typeparam name="IStorage"></typeparam>
 /// <typeparam name="IDataCollection"></typeparam>
    public abstract class MultipleSingleMemorableData<IStorage, IListData, IDetailData>
        where IListData : IContainer<IDetailData>
        where IDetailData : ILazyLoadData
    {
        public MultipleSingleMemorableData()
        {
        }
        public MultipleSingleMemorableData(IStorage storage, IListData list)
        {
            Init(storage, list);
        }

        public void Init(IStorage storage, IListData list)
        {
            Storage = storage;
            List = list;
            ChangeCurrent(0);
        }

        bool HasPrevious
        {
            get
            {
                if (Datas.Count > 1 && DataIndex != 0)
                    return true;
                else
                    return false;
            }
        }
        bool HasNext
        {
            get
            {
                if (Datas.Count > 1 && DataIndex != Datas.Count - 1)
                    return true;
                else
                    return false;
            }
        }
        public bool CanCreateNew
        {
            get
            {
                return !IsCreateNew;
            }
        }
        public bool CanDelete
        {
            get
            {
                return !IsCreateNew;
            }
        }
        public bool CanSave
        {
            get
            {
                return IsEdited;
            }
        }
        bool IsCreateNew { set; get; }
        bool IsEdited { set; get; }
        protected IStorage Storage { set; get; }
        public IListData List { set; get; }
        public List<IDetailData> Datas { get { return List.Datas; } }
        public int DataIndex { set; get; }
        MemorableData<IStorage, IDetailData, List<ElementParameterValueSet>> _memorableData;
        public MemorableData<IStorage, IDetailData, List<ElementParameterValueSet>> MemorableData
        {
            set
            {
                if (value == null)
                {
                    _memorableData = value;
                    return;
                }
                else
                {
                    if (!value.Data.IsLoad)
                        value.Data.LoadData(0);
                    else
                        value.Data.LoadData(1);
                    _memorableData = value;
                    _memorableData.Start();
                }
            }
            get
            {
                return _memorableData;
            }
        }
        public delegate void RenderDelegate2(bool hasPrevious, bool hasNext, bool canCreateNew, bool canDelete, bool canSave);
        /// <summary>
        /// 文档编辑时候有新增,删除,等状态,这里统一负责这些状态对应的渲染的处理
        /// </summary>
        public event RenderDelegate2 OnStateChanged;
        public delegate void RenderDelegate1(IDetailData data);
        /// <summary>
        /// 一天可能录入多份文档,这是文档级的变更
        /// </summary>
        public event RenderDelegate1 OnDataChanged;
        public delegate bool ConfirmDelegate();
        /// <summary>
        /// 更换当前项时确认以继续,删除新项
        /// </summary>
        public event ConfirmDelegate OnConfirmChangeCurrentWhileHasCreateNew;
        /// <summary>
        /// 更换当前项时确认以继续,回滚当前编辑
        /// </summary>
        public event ConfirmDelegate OnConfirmChangeCurrentWhileIsEdited;
        /// <summary>
        /// 确认删除
        /// </summary>
        public event ConfirmDelegate OnConfirmDelete;

        /// <summary>
        /// 新增
        /// </summary>
        public void CreateNew()
        {
            ChangeCurrent(Datas.Count);
            IsCreateNew = true;
        }
        protected abstract IDetailData createNew();
        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        public BLLResult Commit()
        {
            var result = MemorableData.Commit(IsCreateNew);
            if (result.IsSuccess)
            {
                IsEdited = false;
                IsCreateNew = false;
                OnStateChanged?.Invoke(HasPrevious, HasNext, CanCreateNew, CanDelete, CanSave);
                MemorableData.Start();
            }
            return result;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public BLLResult Delete()
        {
            if (OnConfirmDelete != null)
            {
                if (!OnConfirmDelete())
                    return new BLLResult() { IsSuccess = false, Message = "" };// "删除取消"
            }
            bool needMove = !HasNext && HasPrevious;
            var result = MemorableData.Delete();
            if (result.IsSuccess)
            {
                if (needMove)
                    DataIndex = DataIndex - 1;//前移一项
                IsEdited = false;
                Datas.Remove(MemorableData.Data);
                ChangeCurrent(DataIndex);
            }
            return result;
        }
        /// <summary>
        /// 取消
        /// </summary>
        public void Cancel()
        {
            MemorableData.Rollback();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        public void Edited()
        {
            IsEdited = true;
            OnStateChanged?.Invoke(HasPrevious, HasNext, CanCreateNew, CanDelete, CanSave);
        }
        /// <summary>
        /// 更改选中项
        /// </summary>
        /// <param name="index"></param>
        void ChangeCurrent(int index)
        {
            bool isContinue;
            isContinue = CheckChanges();
            if (!isContinue)
                return;
            DataIndex = index;
            if (index > Datas.Count - 1)//只有新增时index超过Datas的最大值
            {
                IsCreateNew = true;
                Datas.Add(createNew());
            }
            else
            {
                IsCreateNew = false;
            }
            UpdateMemorableData();//将选中内容刷到MemorableData
            OnDataChanged?.Invoke(Datas[DataIndex]);
            OnStateChanged?.Invoke(HasPrevious, HasNext, CanCreateNew, CanDelete, CanSave);
        }
        bool CheckChanges()
        {
            bool isContinue = true;
            if (IsCreateNew)
            {
                if (OnConfirmChangeCurrentWhileHasCreateNew != null)
                {
                    isContinue = OnConfirmChangeCurrentWhileHasCreateNew();
                    if (isContinue)
                        Datas.RemoveAt(Datas.Count - 1);//新增项总是在最后
                }
            }
            else if (IsEdited)
            {
                if (OnConfirmChangeCurrentWhileIsEdited != null)
                {
                    isContinue = OnConfirmChangeCurrentWhileIsEdited();
                    if (isContinue)
                        Rollback();//编辑强制换页时已编辑的内容回退
                }
            }
            return isContinue;
        }
        protected abstract void UpdateMemorableData();
        /// <summary>
        /// 上一页
        /// </summary>
        public void Previous()
        {
            if (HasPrevious)
                ChangeCurrent(DataIndex - 1);
        }
        /// <summary>
        /// 下一页
        /// </summary>
        public void Next()
        {
            if (HasNext)
                ChangeCurrent(DataIndex + 1);
        }
        /// <summary>
        /// 比如正在新增,isDeleteNew决定了是否删除新增
        /// </summary>
        /// <param name="isDeleteNew"></param>
        public void Rollback(bool isDeleteNew = false)
        {
            if (IsCreateNew && isDeleteNew)
            {
                MemorableData = null;
                Datas.RemoveAt(DataIndex);
            }
            else
            {
                //0509 09:57 在编辑后回退,无编辑不回退
                if (IsEdited)
                {
                    MemorableData.Rollback();
                    if (Datas.Count > 0)
                        Datas[DataIndex] = MemorableData.Data;
                    OnDataChanged?.Invoke(Datas[DataIndex]);
                    OnStateChanged?.Invoke(HasPrevious, HasNext, CanCreateNew, CanDelete, CanSave);
                }
            }
        }
        /// <summary>
        /// 导入Excel
        /// </summary>
        public ParseResult ImportExcel(Workbook workbook)
        {
            var result = importExcel(workbook);
            if (result == ParseResult.Success)
            {
                //0711TODO KO 获取对应的NodeCode的ElementIds
                Datas[DataIndex].LoadData(1);
                IsEdited = true;
                OnDataChanged?.Invoke(Datas[DataIndex]);
                OnStateChanged?.Invoke(HasPrevious, HasNext, !IsCreateNew, CanDelete, IsEdited);
            }
            return result;
        }
        protected abstract ParseResult importExcel(Workbook workbook);
    }
}
