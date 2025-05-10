using ClosedXML.Excel;

namespace Invest_Application
{
    public static class ReportGenerator
    {
        public static void GenerateReport()
        {
            // Get the path to the user's desktop
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Define the file name and full path
            string filePath = Path.Combine(desktopPath, "SampleExcel.xlsx");

            // Create a new workbook and worksheet
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");
                worksheet.Cell("A1").Value = "Hello";
                worksheet.Cell("B1").Value = "World";

                // Save to the Desktop
                workbook.SaveAs(filePath);
            }
        }
    }
}
