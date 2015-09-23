using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            var existingFile = new FileInfo("Sample.xlsx");
            // Open and read the XlSX file.
            
            using (var package = new ExcelPackage(existingFile))
            {
                var package2 = new ExcelPackage(existingFile);
                // Get the work book in the file
                ExcelWorkbook workBook = package.Workbook;
                if (workBook != null)
                {
                    if (workBook.Worksheets.Count > 0)
                    {
                        workBook.Worksheets["Calculation"].Cells["D4"].Value = 119;
                        workBook.Worksheets["Calculation"].Cells["D5"].Value = 519;
                        IEnumerable<int> arr = new List<int>() { 1, 2, 3, 4, 5 };
                        Int32[] arr2 = new Int32[] { 1, 2, 3, 4, 5 };
                        ExcelAddress address = new ExcelAddress("D1:D5");
                        workBook.Worksheets["Calculation"].Select(address);
                        workBook.Worksheets["Calculation"].SelectedRange.LoadFromCollection<int>(arr);

                        workBook.Worksheets["Calculation"].Calculate();
                        Console.WriteLine(workBook.Worksheets["Calculation"].Cells["E8"].Value);
                        Console.Read();
                    }
                }
            }
        }
    }
}
