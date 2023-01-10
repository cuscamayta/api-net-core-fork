using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;

namespace Thermon.Computrace.Web.Api.Services
{
    public class ExcelService
    {

        public static byte[] ExporttoExcel<T>(List<T> table, string filename)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using ExcelPackage pack = new ExcelPackage();
            ExcelWorksheet ws = pack.Workbook.Worksheets.Add(filename);

            ws.Cells["A1:F1"].Value = "BILL OF MATERIALS";
            ws.Cells["A1:F1"].Merge = true; //Merge columns start and end range
            ws.Cells["A1:F1"].Style.Font.Bold = true; //Font should be bold
            ws.Cells["A1:F1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Alignment is center
            ws.Cells["A1:F1"].Style.Font.Size = 16;
            //ws.Cells["A1:F1"].Merge = true;
            //ws.Cells["A1:F1"].Value = "Bill Of Materials";

            ws.Cells["A2:F2"].Merge = true;
            //ws.Cells["A2:F2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Alignment is center
            ws.Cells["A2:F2"].Value = "Computrace Version 0.1";

            ws.Cells["A1:F2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells["A4"].Value = "Current Date";
            ws.Cells["B4"].Value = DateTime.Now.ToLongDateString();
            ws.Cells["A5"].Value = "Customer";
            ws.Cells["B5"].Value = "N/A";
            ws.Cells["A6"].Value = "Purchase Order Number";
            ws.Cells["B6"].Value = "";



            ws.Cells["A10"].LoadFromCollection(table, true, TableStyles.Light1);
            ws.Cells.AutoFitColumns();
            return pack.GetAsByteArray();
        }
    }
}
