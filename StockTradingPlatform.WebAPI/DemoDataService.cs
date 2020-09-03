using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using StockTradingPlatform.Core.CoreLogic;
using StockTradingPlatform.Core.Model;

namespace StockTradingPlatform.WebAPI
{
    public class DemoDataService: IHostedService
    {
        private readonly CompanyService _companyService;
        private readonly OrderService _orderService;

        public DemoDataService(CompanyService companyService, OrderService orderService)
        {
            _companyService = companyService;
            _orderService = orderService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _companyService.AddCompany(new Company("AMZN"));
            _companyService.AddCompany(new Company("TSLA"));
            _companyService.AddCompany(new Company("BLKFNCH"));

            _companyService.IssueShares("AMZN", 40, 100000);
            _companyService.IssueShares("TSLA", 420, 10000);
            _companyService.IssueShares("BLKFNCH", 60, 600);

            _orderService.AddOrder(new Order("AMZN", 40, 40, 100, OrderType.Buy));
            _orderService.AddOrder(new Order("TSLA", 200, 1000, 2000, OrderType.Buy));
            _orderService.AddOrder(new Order("BLKFNCH", 60, 60, 300, OrderType.Buy));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
