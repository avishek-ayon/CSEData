using CSEData.Application.Features.Training.Services;
using HtmlAgilityPack;

namespace CSEData.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ICompanyService _companyService;
        private readonly IPriceService _priceService;

        public Worker(ILogger<Worker> logger, ICompanyService companyService, IPriceService priceService)
        {
            _logger = logger;
            _companyService = companyService;
            _priceService = priceService;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                await ScrapeData();
                await Task.Delay(60000, stoppingToken);
            }
        }
        private async Task ScrapeData()
        {
            try
            {
                var url = "https://www.cse.com.bd/market/current_price"; // URL of the website to scrape

                var web = new HtmlWeb();
                var doc = await web.LoadFromWebAsync(url);
                var companyTime = doc.DocumentNode.SelectSingleNode("//div[@class='market_status']");
                var marketStatus = companyTime.ChildNodes[1].ChildNodes[1].InnerText;
                if (marketStatus == "Open")
                {
                    var companyNameNodes = doc.DocumentNode.SelectNodes("//table[@id='dataTable']/tbody/tr");

                    var dateNode = companyTime.ChildNodes[3];
                    var timeNode = companyTime.ChildNodes[5].ChildNodes[1];

                    if (companyNameNodes != null)
                    {
                       
                        foreach (var node in companyNameNodes)
                        {

                            var columns = node.SelectNodes("td");

                            if (columns != null && columns.Count >= 10)
                            {
                                string StockCodeName = columns[1].InnerText;
                                int sl = int.Parse(columns[0].InnerText.Trim());
                                float ltp = float.Parse(columns[2].InnerText.Trim());
                                int Volume = int.Parse(columns[9].InnerText);
                                float open = float.Parse(columns[3].InnerText);
                                float high = float.Parse(columns[4].InnerText);
                                float low = float.Parse(columns[5].InnerText);
                                string d = dateNode.InnerText.Replace("&nbsp;", "").Trim() + " " +
                                            timeNode.InnerText.Replace("&nbsp;", "").Replace("(BST)", "").Trim();
                                d = d.Replace("'", "");
                                DateTime date = DateTime.Parse(d);

                               

                                var id = _companyService.CreateCompany(StockCodeName);

                                if (id == 0)
                                {
                                    var company = _companyService.FindByCompanyName(StockCodeName);
                                    if (company != null)
                                    {
                                        id = company.Id;
                                    }
                                }
                                _priceService.CreatePrice(id, ltp, Volume, open, high, low, date);

                            }
                                                 

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while scraping data");
            }
        }
    }
}