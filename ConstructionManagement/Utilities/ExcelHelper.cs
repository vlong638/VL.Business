using Microsoft.Office.Interop.Excel;
using PmSoft.ConstructionManagement.SubsidenceMonitor.Entities;
using System;
using System.IO;

namespace PmSoft.ConstructionManagement.Utilities
{
    class ExcelHelper
    {
        public static Worksheet GetWorksheet(string path, EIssueType issueType)
        {
            if (!File.Exists(path))
                throw new NotImplementedException("无效的文件路径");

            ApplicationClass excelApp = new ApplicationClass();
            var workbook = excelApp.Workbooks.Open(path);
            if (workbook == null)
                throw new NotImplementedException("Workbook文档对象无效");
            var sheetName = issueType.GetSheetName();
            if (workbook.Worksheets[sheetName] == null)
                throw new NotImplementedException("Worksheet名称无效");
            return workbook.Worksheets[sheetName] as Worksheet;
        }
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
        public static string GetSheetName(this EIssueType issueType)
        {
            switch (issueType)
            {
                case EIssueType.建筑物沉降:
                    return "建筑物沉降";
                case EIssueType.地表沉降:
                    return "地表沉降";
                case EIssueType.管线沉降_无压:
                case EIssueType.管线沉降_有压:
                    return "管线沉降";
                case EIssueType.侧斜监测:
                    return "";
                case EIssueType.钢支撑轴力监测:
                    return "钢支撑轴力";
                default:
                    throw new NotImplementedException();
            }
        }
        public static string GetCellValueAsString(this Worksheet sheet, int rowIndex, int columnIndex)
        {
            var cell = sheet.Cells[rowIndex, columnIndex] as Range;
            if (cell.Text == null)
                return "";

            return cell.Text.ToString();
        }
    }
}
