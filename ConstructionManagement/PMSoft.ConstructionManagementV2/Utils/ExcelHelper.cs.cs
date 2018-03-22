using Microsoft.Office.Interop.Excel;
using PMSoft.ConstructionManagementV2.DomainModel;
using System;
using System.IO;

namespace PMSoft.ConstructionManagementV2.Utils
{
    public class ExcelHelper
    {
        public static Workbook GetWorkbook(string path)
        {
            if (!File.Exists(path))
                throw new NotImplementedException("无效的文件路径");

            ApplicationClass excelApp = new ApplicationClass();
            var workbook = excelApp.Workbooks.Open(path);
            if (workbook == null)
                throw new NotImplementedException("无效的Excel文档对象");
            return workbook;
        }
        public static Worksheet GetWorksheet(Workbook workbook,string sheetName)
        {
            if (workbook.Worksheets[sheetName] == null)
                throw new NotImplementedException("指定的Worksheet名称不存在");
            return workbook.Worksheets[sheetName] as Worksheet;
        }
        /// <summary>
        /// Microsoft.Office.Interop.Excel方案存在Excel线程未退出的问题,需要主动清理
        /// </summary>
        /// <param name="name"></param>
        public static void KillProcess(string name = "Excel")
        {
            System.Diagnostics.Process myproc = new System.Diagnostics.Process();//得到所有打开的进程
            try
            {
                foreach (System.Diagnostics.Process thisproc in System.Diagnostics.Process.GetProcessesByName(name))
                {
                    if (!thisproc.CloseMainWindow())
                    {
                        thisproc.Kill();
                    }
                }
            }
            catch { }
        }
    }
    static class ExcelEx
    {
        public static string GetCellValueAsString(this Worksheet sheet, int rowIndex, int columnIndex)
        {
            var cell = sheet.Cells[rowIndex, columnIndex] as Range;
            if (cell.Text == null)
                return "";

            return cell.Text.ToString();
        }
    }

    public abstract class IssueTypeEntity<T>
    {
        public abstract EIssueType EIssueType { get;}

        public T Import(string path)
        {
            return Import(ExcelHelper.GetWorkbook(path));
        }
        public abstract T Import(Workbook workbook);
        public abstract bool WorksheetCheck(Worksheet worksheet);
    }
    /// <summary>
    /// 土方分块
    /// </summary>
    public class IssueTypeEntity_TFFK : IssueTypeEntity<TEarthworkBlocking>
    {
        public override EIssueType EIssueType
        {
            get
            {
                return EIssueType.TFFK;
            }
        }

        public override TEarthworkBlocking Import(Workbook workbook)
        {
            var sheet = ExcelHelper.GetWorksheet(workbook, EIssueType.GetSheetName());
            if (!WorksheetCheck(sheet))
                return null;

            int rowIndex = 2;
            bool isEndTimeEarlier = false;
            bool isStartTimeError = false;
            bool isEndTimeError = false;
            bool isTimeSpanError = false;
            TEarthworkBlocking blocking;
            blocking = new TEarthworkBlocking();
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
                var block = new TEarthworkBlock(DateTime.MinValue, blocking.GetEarthworkBlockMaxId())
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

        }
        public override bool WorksheetCheck(Worksheet worksheet)
        {
            if (worksheet.GetCellValueAsString(1, 1).Trim() != "节点名称")
            {
                MessageHelper.ShowMessage("表头校验未通过-节点名称");
                return false;
            }
            if (worksheet.GetCellValueAsString(1, 2).Trim() != "开始时间")
            {
                MessageHelper.ShowMessage("表头校验未通过-开始时间");
                return false;
            }
            if (worksheet.GetCellValueAsString(1, 3).Trim() != "无支撑暴露时间")
            {
                MessageHelper.ShowMessage("表头校验未通过-无支撑暴露时间");
                return false;
            }
            if (worksheet.GetCellValueAsString(1, 4).Trim() != "结束时间")
            {
                MessageHelper.ShowMessage("表头校验未通过-结束时间");
                return false;
            }
            if (worksheet.GetCellValueAsString(1, 5).Trim() != "说明")
            {
                MessageHelper.ShowMessage("表头校验未通过-说明");
                return false;
            }
            return true;
        }
    }
    static class IssueTypeEntityEx
    {
        public static string GetSheetName(this EIssueType issueType)
        {
            switch (issueType)
            {
                case EIssueType.TFFK:
                    return "土方分块";
                case EIssueType.ZQDSPWY:
                    return "桩（墙）顶水平位移";
                case EIssueType.ZQDCJ:
                    return "桩（墙）顶沉降";
                case EIssueType.ZBDBCJ:
                    return "周边地表沉降";
                case EIssueType.GXCJ:
                    return "管线沉降";
                case EIssueType.TZC:
                    return "砼支撑";
                case EIssueType.GZC:
                    return "钢支撑";
                case EIssueType.SW:
                    return "水位";
                case EIssueType.CX://侧斜无固定SheetName,特殊处理为CXn
                case EIssueType.None:
                default:
                    throw new NotImplementedException();
            }
        }
    }
}