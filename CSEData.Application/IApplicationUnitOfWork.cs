using CSEData.Application.Features.Training.Repositories;
using CSEData.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEData.Application
{
    public interface IApplicationUnitOfWork :IUnitOfWork
    {
        ICompanyRepository Companies { get; }
        IPriceRepository Prices { get; }
    }
}
