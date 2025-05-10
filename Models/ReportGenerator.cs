using ClosedXML.Excel;
using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace Invest_Application
{
    public static class ReportGenerator
    {
        private static readonly string smallSeparator = "-----------------------------\n";
        private static readonly string titleLine = "--------------------------------------\n";
        private static readonly string largeSeparator = "-----------------------------------------------------------------------\n";

        private static void FillHeader(IXLWorksheet worksheet, int lCol, ref int row, string headerTitle, int headerTitleRow, int dateRow)
        {
            worksheet.Range(headerTitleRow, lCol, headerTitleRow, lCol + 6).Merge();
            worksheet.Cell(headerTitleRow, lCol).Value = headerTitle;

            worksheet.Range(dateRow, lCol, dateRow, lCol + 6).Merge();
            worksheet.Cell(dateRow, lCol).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            worksheet.Cell(row, lCol + 0).Value = "Name";
            worksheet.Cell(row, lCol + 1).Value = "Quantity";
            worksheet.Cell(row, lCol + 2).Value = "Purchase Date";
            worksheet.Cell(row, lCol + 3).Value = "Purchase Price";
            worksheet.Cell(row, lCol + 4).Value = "Total Purchase Price";
            worksheet.Cell(row, lCol + 5).Value = "Current Value";
            worksheet.Cell(row, lCol + 6).Value = "ROI";
            row++;
        }
        private static void FillGeneralHeader(IXLWorksheet worksheet, int lCol, ref int row, string headerTitle, int headerTitleRow, int dateRow)
        {
            worksheet.Range(headerTitleRow, lCol, headerTitleRow, lCol + 4).Merge();
            worksheet.Cell(headerTitleRow, lCol).Value = headerTitle;

            worksheet.Range(dateRow, lCol, dateRow, lCol + 4).Merge();
            worksheet.Cell(dateRow, lCol).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            worksheet.Cell(row, lCol + 0).Value = "Type";
            worksheet.Cell(row, lCol + 1).Value = "Count";
            worksheet.Cell(row, lCol + 2).Value = "Total Purchase Price";
            worksheet.Cell(row, lCol + 3).Value = "Current Value";
            worksheet.Cell(row, lCol + 4).Value = "ROI";
            row++;
        }
        private static void FillGold(List<Gold> lst, IXLWorksheet worksheet, int lCol, ref int row)
        {

            foreach (Gold accet in lst)
            {
                worksheet.Cell(row, lCol + 0).Value = accet.Name;
                worksheet.Cell(row, lCol + 1).Value = accet.Quantity;
                worksheet.Cell(row, lCol + 2).Value = accet.PurchaseDate;
                worksheet.Cell(row, lCol + 3).Value = accet.PurchasePrice;
                worksheet.Cell(row, lCol + 4).Value = accet.TotalPurchasePrice();
                worksheet.Cell(row, lCol + 5).Value = accet.CurrentPrice();
                worksheet.Cell(row, lCol + 6).Value = Math.Round(accet.CalculateROI(), 2) + "%";
                row++;
            }
        }

        private static void FillStock(List<Stock> lst, IXLWorksheet worksheet, int lCol, ref int row)
        {

            foreach (Stock accet in lst)
            {
                worksheet.Cell(row, lCol + 0).Value = accet.Name;
                worksheet.Cell(row, lCol + 1).Value = accet.Quantity;
                worksheet.Cell(row, lCol + 2).Value = accet.PurchaseDate;
                worksheet.Cell(row, lCol + 3).Value = accet.PurchasePrice;
                worksheet.Cell(row, lCol + 4).Value = accet.TotalPurchasePrice();
                worksheet.Cell(row, lCol + 5).Value = accet.CurrentPrice();
                worksheet.Cell(row, lCol + 6).Value = Math.Round(accet.CalculateROI(), 2) + "%";
                row++;
            }
        }

        private static void FillRealEstate(List<RealEstate> lst, IXLWorksheet worksheet, int lCol, ref int row)
        {

            foreach (RealEstate accet in lst)
            {
                worksheet.Cell(row, lCol + 0).Value = accet.Name;
                worksheet.Cell(row, lCol + 1).Value = accet.Quantity;
                worksheet.Cell(row, lCol + 2).Value = accet.PurchaseDate;
                worksheet.Cell(row, lCol + 3).Value = accet.PurchasePrice;
                worksheet.Cell(row, lCol + 4).Value = accet.TotalPurchasePrice();
                worksheet.Cell(row, lCol + 5).Value = accet.CurrentPrice();
                worksheet.Cell(row, lCol + 6).Value = Math.Round(accet.CalculateROI(), 2) + "%";
                row++;
            }
        }

        private static void FillCrypto(List<Crypto> lst, IXLWorksheet worksheet, int lCol, ref int row)
        {

            foreach (Crypto accet in lst)
            {
                worksheet.Cell(row, lCol + 0).Value = accet.Name;
                worksheet.Cell(row, lCol + 1).Value = accet.Quantity;
                worksheet.Cell(row, lCol + 2).Value = accet.PurchaseDate;
                worksheet.Cell(row, lCol + 3).Value = accet.PurchasePrice;
                worksheet.Cell(row, lCol + 4).Value = accet.TotalPurchasePrice();
                worksheet.Cell(row, lCol + 5).Value = accet.CurrentPrice();
                worksheet.Cell(row, lCol + 6).Value = Math.Round(accet.CalculateROI(), 2) + "%";
                row++;
            }
        }
        private static void StyleSheet(IXLWorksheet worksheet, int lCol, int rCol, int headRow, int headerTitleRow, int dateRow)
        {
            worksheet.Range(headerTitleRow, lCol, headerTitleRow, rCol).Style.Font.Bold = true;
            worksheet.Range(headerTitleRow, lCol, headerTitleRow, rCol).Style.Font.FontSize = 20;

            worksheet.Range(dateRow, lCol, dateRow, rCol).Style.Font.Bold = true;
            worksheet.Range(dateRow, lCol, dateRow, rCol).Style.Font.FontSize = 16;

            for (int i = lCol; i <= rCol; i++)
            {
                worksheet.Column(i).Width = 25;
                worksheet.Cell(headRow, i).Style.Font.Bold = true;
                worksheet.Cell(headRow, i).Style.Font.FontSize = 14;
                worksheet.Cell(headRow, i).Style.Fill.BackgroundColor = XLColor.Yellow;
            }
            worksheet.CellsUsed().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.CellsUsed().Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        }

        public static void GenerateExcelReport(string username)
        {
            if (File.Exists(AppPaths.GetExcelSaveFile(username)))
            {
                DateTime creationDate = File.GetCreationTime(AppPaths.GetExcelSaveFile(username));
                TimeSpan difference = DateTime.Now - creationDate;
                if (difference <= TimeSpan.FromSeconds(5))
                {
                    return;
                }
                File.Delete(AppPaths.GetExcelSaveFile(username));
            }
            int goldCount = DatabaseOrganizer.GetUserGoldCount(username);
            int stockCount = DatabaseOrganizer.GetUserStockCount(username);
            int realEstateCount = DatabaseOrganizer.GetUserRealEstateCount(username);
            int cryptoCount = DatabaseOrganizer.GetUserCryptoCount(username);
            using (var workbook = new XLWorkbook())
            {

                int headerRow = 2;
                int dateRow = headerRow + 2;
                int subHeaderRow = dateRow + 2;
                if (goldCount > 0 || stockCount > 0 || realEstateCount > 0 || cryptoCount > 0)
                {
                    int row = subHeaderRow;
                    int lCol = 2;
                    int rCol = lCol + 4;
                    var worksheet = workbook.Worksheets.Add("General");
                    FillGeneralHeader(worksheet, lCol, ref row, "General", headerRow, dateRow);

                    // Gold Summary
                    worksheet.Cell(row, lCol + 0).Value = "Gold";
                    worksheet.Cell(row, lCol + 1).Value = goldCount;
                    worksheet.Cell(row, lCol + 2).Value = InvestmentAnalyzer.GetGoldPurchaseValue(username);
                    worksheet.Cell(row, lCol + 3).Value = InvestmentAnalyzer.GetGoldCurrentValue(username);
                    worksheet.Cell(row, lCol + 4).Value = Math.Round(InvestmentAnalyzer.GetGoldROI(username), 2) + "%";
                    row++;

                    // Stock Summary
                    worksheet.Cell(row, lCol + 0).Value = "Stock";
                    worksheet.Cell(row, lCol + 1).Value = stockCount;
                    worksheet.Cell(row, lCol + 2).Value = InvestmentAnalyzer.GetStockPurchaseValue(username);
                    worksheet.Cell(row, lCol + 3).Value = InvestmentAnalyzer.GetStockCurrentValue(username);
                    worksheet.Cell(row, lCol + 4).Value = Math.Round(InvestmentAnalyzer.GetStockROI(username), 2) + "%";
                    row++;

                    // Crypto Summary
                    worksheet.Cell(row, lCol + 0).Value = "Crypto";
                    worksheet.Cell(row, lCol + 1).Value = cryptoCount;
                    worksheet.Cell(row, lCol + 2).Value = InvestmentAnalyzer.GetCryptoPurchaseValue(username);
                    worksheet.Cell(row, lCol + 3).Value = InvestmentAnalyzer.GetCryptoCurrentValue(username);
                    worksheet.Cell(row, lCol + 4).Value = Math.Round(InvestmentAnalyzer.GetCryptoROI(username), 2) + "%";
                    row++;

                    // Real Estate Summary
                    worksheet.Cell(row, lCol + 0).Value = "Real Estate";
                    worksheet.Cell(row, lCol + 1).Value = realEstateCount;
                    worksheet.Cell(row, lCol + 2).Value = InvestmentAnalyzer.GetRealEstatePurchaseValue(username);
                    worksheet.Cell(row, lCol + 3).Value = InvestmentAnalyzer.GetRealEstateCurrentValue(username);
                    worksheet.Cell(row, lCol + 4).Value = Math.Round(InvestmentAnalyzer.GetRealEstateROI(username), 2) + "%";
                    row++;

                    // Total Summary
                    row++;
                    worksheet.Cell(row, lCol + 0).Value = "Total";
                    worksheet.Cell(row, lCol + 1).Value = goldCount + stockCount + realEstateCount + cryptoCount;
                    worksheet.Cell(row, lCol + 2).Value = InvestmentAnalyzer.GetTotalPurchaseValue(username);
                    worksheet.Cell(row, lCol + 3).Value = InvestmentAnalyzer.GetTotalCurrentValue(username);
                    worksheet.Cell(row, lCol + 4).Value = Math.Round(InvestmentAnalyzer.GetTotalROI(username), 2) + "%";

                    StyleSheet(worksheet, lCol, rCol, subHeaderRow, headerRow, dateRow);
                }
                if (goldCount > 0 || stockCount > 0 || realEstateCount > 0 || cryptoCount > 0)
                {
                    int row = subHeaderRow;
                    int lCol = 2;
                    int rCol = lCol + 6;
                    var worksheet = workbook.Worksheets.Add("All");
                    FillHeader(worksheet, lCol, ref row, "All Assets Investment", headerRow, dateRow);
                    FillGold(DatabaseOrganizer.GetAllUserGold(username), worksheet, lCol, ref row);
                    FillStock(DatabaseOrganizer.GetAllUserStock(username), worksheet, lCol, ref row);
                    FillCrypto(DatabaseOrganizer.GetAllUserCrypto(username), worksheet, lCol, ref row);
                    FillRealEstate(DatabaseOrganizer.GetAllUserRealEstate(username), worksheet, lCol, ref row);
                    StyleSheet(worksheet, lCol, rCol, subHeaderRow, headerRow, dateRow);
                }
                if (goldCount > 0)
                {
                    int row = subHeaderRow;
                    int lCol = 2;
                    int rCol = lCol + 6;
                    var worksheet = workbook.Worksheets.Add("Gold Investment");
                    FillHeader(worksheet, lCol, ref row, "Gold Investment", headerRow, dateRow);
                    FillGold(DatabaseOrganizer.GetAllUserGold(username), worksheet, lCol, ref row);
                    StyleSheet(worksheet, lCol, rCol, subHeaderRow, headerRow, dateRow);
                }

                if (stockCount > 0)
                {
                    int row = subHeaderRow;
                    int lCol = 2;
                    int rCol = lCol + 6;
                    var worksheet = workbook.Worksheets.Add("Stock Investment");
                    FillHeader(worksheet, lCol, ref row, "Stock Investment", headerRow, dateRow);
                    FillStock(DatabaseOrganizer.GetAllUserStock(username), worksheet, lCol, ref row);
                    StyleSheet(worksheet, lCol, rCol, subHeaderRow, headerRow, dateRow);
                }

                if (cryptoCount > 0)
                {
                    int row = subHeaderRow;
                    int lCol = 2;
                    int rCol = lCol + 6;
                    var worksheet = workbook.Worksheets.Add("Crypto Investment");
                    FillHeader(worksheet, lCol, ref row, "Crypto Investment", headerRow, dateRow);
                    FillCrypto(DatabaseOrganizer.GetAllUserCrypto(username), worksheet, lCol, ref row);
                    StyleSheet(worksheet, lCol, rCol, subHeaderRow, headerRow, dateRow);
                }

                if (realEstateCount > 0)
                {
                    int row = subHeaderRow;
                    int lCol = 2;
                    int rCol = lCol + 6;
                    var worksheet = workbook.Worksheets.Add("Real Estate Investment");
                    FillHeader(worksheet, lCol, ref row, "Real Estate Investment", headerRow, dateRow);
                    FillRealEstate(DatabaseOrganizer.GetAllUserRealEstate(username), worksheet, lCol, ref row);
                    StyleSheet(worksheet, lCol, rCol, subHeaderRow, headerRow, dateRow);
                }
                workbook.SaveAs(AppPaths.GetExcelSaveFile(username));
            }
        }

        static void WriteLinesToPdf(string[] lines, string outputPdfPath)
        {
            XFont font = new XFont("Arial", 12, XFontStyle.Regular); ;
            double marginLeft = 40;
            double marginTop = 40;
            double marginBottom = 40;
            // Create document
            var document = new PdfDocument();
            document.Info.Title = "Paged Text";

            // Start first page
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);
            var brush = XBrushes.Black;

            // Calculate line height once
            double lineHeight = font.GetHeight() + 2;

            // Y cursor
            double y = marginTop;

            foreach (var line in lines)
            {
                // If next line would overflow bottom margin, start a new page
                if (line + "\n" == largeSeparator || y + lineHeight > page.Height - marginBottom)
                {
                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    y = marginTop;
                }

                // Draw the text
                gfx.DrawString(line, font, brush, marginLeft, y);

                // Advance cursor
                y += lineHeight;
            }

            // Save file
            document.Save(outputPdfPath);
        }

        public static void GeneratePdfReport(string username)
        {
            if (File.Exists(AppPaths.GetPdfSaveFile(username)))
            {
                DateTime creationDate = File.GetCreationTime(AppPaths.GetPdfSaveFile(username));
                TimeSpan difference = DateTime.Now - creationDate;
                if (difference <= TimeSpan.FromSeconds(5))
                {
                    return;
                }
                File.Delete(AppPaths.GetPdfSaveFile(username));
            }
            GenerateTextReport(username);
            var textLines = File.ReadAllLines(AppPaths.GetTextSaveFile());
            WriteLinesToPdf(textLines, AppPaths.GetPdfSaveFile(username));
        }
        private static void LoadGeneral(ref string content, IXLWorksheet worksheet)
        {
            bool startInserting = false;
            bool added = false;
            foreach (var row in worksheet.RowsUsed())
            {
                if (startInserting)
                {
                    List<string> line = new List<string>();
                    foreach (var cell in row.CellsUsed())
                    {
                        line.Add(cell.GetValue<string>());
                    }
                    if (added)
                    {
                        content += smallSeparator;
                    }
                    content += "Type: " + line[0] + "\n";
                    content += "Count: " + line[1] + "\n";
                    content += "Total Purchase Price: " + line[2] + "\n";
                    content += "Current Value: " + line[3] + "\n";
                    content += "ROI: " + line[4] + "\n";
                    added = true;
                }
                else
                {
                    foreach (var cell in row.CellsUsed())
                    {
                        if (cell.GetValue<string>() == "Type")
                        {
                            startInserting = true;
                            break;
                        }
                    }
                }
            }
        }

        private static void LoadAssets(ref string content, IXLWorksheet worksheet)
        {
            bool startInserting = false;
            bool added = false;
            foreach (var row in worksheet.RowsUsed())
            {
                if (startInserting)
                {
                    List<string> line = new List<string>();
                    foreach (var cell in row.CellsUsed())
                    {
                        line.Add(cell.GetValue<string>());
                    }
                    if (added)
                    {
                        content += smallSeparator;
                    }
                    content += "Type: " + line[0] + "\n";
                    content += "Quantity: " + line[1] + "\n";
                    content += "Purchase Date: " + line[2] + "\n";
                    content += "Purchase Price: " + line[3] + "\n";
                    content += "Total Purchase Price: " + line[4] + "\n";
                    content += "Current Value: " + line[5] + "\n";
                    content += "ROI: " + line[6] + "\n";
                    added = true;
                }
                else
                {
                    foreach (var cell in row.CellsUsed())
                    {
                        if (cell.GetValue<string>() == "Name")
                        {
                            startInserting = true;
                            break;
                        }
                    }
                }
            }
        }


        public static void GenerateTextReport(string username)
        {
            if (File.Exists(AppPaths.GetTextSaveFile()))
            {
                DateTime creationDate = File.GetCreationTime(AppPaths.GetTextSaveFile());
                TimeSpan difference = DateTime.Now - creationDate;
                if (difference <= TimeSpan.FromSeconds(5))
                {
                    return;
                }
                File.Delete(AppPaths.GetTextSaveFile());
            }
            string content = "";

            content += "Username: " + username + "\n";
            content += "Date: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "\n";
            content += titleLine;

            using var workbook = new XLWorkbook(AppPaths.GetExcelSaveFile(username));

            content += " # General Analysis:\n";
            content += titleLine;
            LoadGeneral(ref content, workbook.Worksheet(1));

            content += largeSeparator;
            content += " #  All Assets:\n";
            content += titleLine;
            LoadAssets(ref content, workbook.Worksheet(2));
            int cur = 3;
            if (DatabaseOrganizer.GetUserGoldCount(username) > 0)
            {
                content += largeSeparator;
                content += " # Gold Investment:\n";
                content += titleLine;
                LoadAssets(ref content, workbook.Worksheet(cur));
                cur++;
            }

            if (DatabaseOrganizer.GetUserStockCount(username) > 0)
            {
                content += largeSeparator;
                content += " # Stock Investment:\n";
                content += titleLine;
                LoadAssets(ref content, workbook.Worksheet(cur));
                cur++;
            }

            if (DatabaseOrganizer.GetUserCryptoCount(username) > 0)
            {
                content += largeSeparator;
                content += " # Crypto Investment:\n";
                content += titleLine;
                LoadAssets(ref content, workbook.Worksheet(cur));
                cur++;
            }

            if (DatabaseOrganizer.GetUserRealEstateCount(username) > 0)
            {
                content += largeSeparator;
                content += " # Real Estate Investment:\n";
                content += titleLine;
                LoadAssets(ref content, workbook.Worksheet(cur));
                cur++;
            }
            File.WriteAllText(AppPaths.GetTextSaveFile(), content);
        }
        public static void SaveExcelReport(string username, string destinationPath)
        {
            GenerateExcelReport(username);
            destinationPath = Path.Combine(destinationPath, Path.GetFileName(AppPaths.GetExcelSaveFile(username)));
            if (File.Exists(destinationPath))
            {
                File.Delete(destinationPath);
            }
            File.Copy(AppPaths.GetExcelSaveFile(username), destinationPath);
        }
        public static void SavePdfReport(string username, string destinationPath)
        {
            GeneratePdfReport(username);
            destinationPath = Path.Combine(destinationPath, Path.GetFileName(AppPaths.GetPdfSaveFile(username)));
            if (File.Exists(destinationPath))
            {
                File.Delete(destinationPath);
            }
            File.Copy(AppPaths.GetPdfSaveFile(username), destinationPath);
        }
    }
}
