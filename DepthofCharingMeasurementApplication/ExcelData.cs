using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DepthofCharingMeasurementApplication
{
    using Excel = Microsoft.Office.Interop.Excel;

    public class ExcelData
    {
        public DataView Data
        {
            get
            {
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook;
                Excel.Worksheet worksheet;
                Excel.Range range;
                workbook = excelApp.Workbooks.Open(Environment.CurrentDirectory + "\\Excel.xlsx");

                worksheet = workbook.ActiveSheet;
                //worksheet = (Excel.Worksheet)workbook.Sheets;

                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Position");
                dt.Columns.Add("Web Site");

                if (worksheet != null)
                {
                    int column = 0;
                    int row = 0;

                    range = worksheet.UsedRange;
                    
                    
                    for (row = 2; row <= range.Rows.Count; row++)
                    {
                        DataRow dr = dt.NewRow();
                        for (column = 1; column <= range.Columns.Count; column++)
                        {
                            Console.WriteLine("Testing " + (range.Cells[row, column] as Excel.Range).Value2.ToString());
                            dr[column - 1] = (range.Cells[row, column] as Excel.Range).Value2.ToString();
                        }
                        dt.Rows.Add(dr);
                        dt.AcceptChanges();
                    }
                    workbook.Close(true, Missing.Value, Missing.Value);
                    excelApp.Quit();
                    return dt.DefaultView;
                }
                return dt.DefaultView;
            }
        }
    }
}
