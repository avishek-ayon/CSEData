using Microsoft.EntityFrameworkCore;
using CSEData.Application.Features.Training.Repositories;
using CSEData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CSEData.Persistence.Features.Training.Repositories
{
    public class CompanyRepository : Repository<Company, int>, ICompanyRepository
    {
        public CompanyRepository(IApplicationDbContext context) : base((DbContext)context)
        { 
        }


        public bool IsDuplicateName(string name)
        {
            var existCompany=_dbSet.FirstOrDefault(x => x.StockCodeName == name);
            if(existCompany != null)
            {
                return true;
            }
            else
            {
                return false;
            }   

        }
        public Company? FindByCompanyName(string companyName)
        {
            return _dbSet.FirstOrDefault(x => x.StockCodeName == companyName);
        }
        
    }
}


