using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Pdf;
using Spire.Xls;
using Spire.Xls.Core.Converter;

namespace ExcelCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            var existingFile = new FileInfo("FMCG2.xlsx");
            // Open and read the XlSX file.
            
            using (var package = new ExcelPackage(existingFile))
            {
                // Get the work book in the file
                ExcelWorkbook workBook = package.Workbook;
                if (workBook != null)
                {
                    if (workBook.Worksheets.Count > 0)
                    {
                        var newfile = new FileInfo("new.xlsx");
                        ExcelPackage pck = new ExcelPackage(newfile);
                        var ws = pck.Workbook.Worksheets.Add("data", workBook.Worksheets["Reports"]);
                        pck.Save();
                        //var drawings = workBook.Worksheets["Reports"].Drawings;

                        //workBook.Worksheets["Calculation"].Cells["D4"].Value = 119;
                        //workBook.Worksheets["Calculation"].Cells["D5"].Value = 519;
                        //IEnumerable<int> arr = new List<int>() { 1, 2, 3, 4, 5 };
                        //Int32[] arr2 = new Int32[] { 1, 2, 3, 4, 5 };
                        //ExcelAddress address = new ExcelAddress("D1:D5");
                        //workBook.Worksheets["Calculation"].Select(address);
                        //workBook.Worksheets["Calculation"].SelectedRange.LoadFromCollection<int>(arr);

                        //workBook.Worksheets["Calculation"].Calculate();

                        //MemoryStream memStream1 = new MemoryStream(); // = new MemoryStream(pck.GetAsByteArray());
                        //package.SaveAs(memStream1);
                        //memStream1.Position = 0;
                        //Workbook spireworkbook2 = new Workbook();
                        //MemoryStream memStream2 = new MemoryStream();
                        //spireworkbook.SaveToStream(memStream2);
                        //spireworkbook.LoadFromStream(memStream1);

                        Workbook spireworkbook = new Workbook();
                        spireworkbook.LoadFromFile("new.xlsx", ExcelVersion.Version2007);
                        spireworkbook.SaveToFile("results.pdf", Spire.Xls.FileFormat.PDF); 
                       
                        Console.Read();
                    }
                }
            }
        }
    }
}
