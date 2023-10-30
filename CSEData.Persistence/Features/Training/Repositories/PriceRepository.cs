using Microsoft.EntityFrameworkCore;
using CSEData.Application.Features.Training.Repositories;
using CSEData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CSEData.Persistence.Features.Training.Repositories
{
    public class PriceRepository : Repository<Price, int>, IPriceRepository
    {
        public PriceRepository(IApplicationDbContext context) : base((DbContext)context)
        {

        }

       
    }
}
