using CSEData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEData.Application.Features.Training.Services
{
    public interface IPriceService
    {
        void CreatePrice(int companyId, float ltp, int volume, float open,
                                float high, float low, DateTime time);

    }
}
