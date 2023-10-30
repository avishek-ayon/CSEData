using Microsoft.EntityFrameworkCore;
using CSEData.Application;
using CSEData.Application.Features.Training.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEData.Persistence
{
    public class ApplicationUnitOfWork :UnitOfWork,IApplicationUnitOfWork
    {
        public ICompanyRepository Companies { get;private set; }
        public IPriceRepository Prices { get; private set; }

        public ApplicationUnitOfWork(IApplicationDbContext dbContext,
            ICompanyRepository companyRepository,
            IPriceRepository prices) : base((DbContext)dbContext)
        {
            Companies = companyRepository;
            Prices = prices;
        }
    }
}
