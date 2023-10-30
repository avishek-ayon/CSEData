using CSEData.Application;
using CSEData.Application.Features.Training.Services;
using CSEData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEData.Infrastructure.Features.Services
{
    public class PriceService : IPriceService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        public PriceService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreatePrice(int companyId, float ltp, int volume, float open, float high, float low,DateTime time)
            
        {
            Price price = new Price()
            {
                CompanyId = companyId,
                PriceLTP = ltp,
                Volume = volume,
                Open = open,
                High = high,
                Low = low,
                Time = time,

            };
            _unitOfWork.Prices.Add(price);
            _unitOfWork.Save();
        }

       
    }
}

