using AngleSharp.Html.Parser;

namespace Scraper.Data
{
    public static class LITScraper
    {
        public static List<LITItem> Scrape()
        {
            var html = GetLITHtml();
            return ParseHtml(html);
        }

        private static string GetLITHtml()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate,
                UseCookies = true
            };
            using var client = new HttpClient(handler);
            

            var url = "https://lakewoodprogramming.com/";
            var html = client.GetStringAsync(url).Result;
            return html;
        }

        private static List<LITItem> ParseHtml(string html)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            var divs = document.QuerySelectorAll("tr");
            var items = new List<LITItem>();
            foreach (var div in divs)
            {
                LITItem item = new();
                items.Add(item);
                var monthElement = div.QuerySelector("tr td");
                if (monthElement != null)
                {
                    item.Month = monthElement.TextContent;
                }

                var ulElement = div.QuerySelector("ul");
                if (ulElement != null)
                {
                    item.Ul = ulElement.TextContent;
                }

            }

            return items;
        }
    }
}