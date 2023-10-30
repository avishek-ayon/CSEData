using Microsoft.EntityFrameworkCore.Query;
using CSEData.Domain.Entities;
using CSEData.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CSEData.Application.Features.Training.Repositories
{
    public interface ICompanyRepository : IRepositoryBase<Company,int>
    {
        bool IsDuplicateName(string name);

        Company? FindByCompanyName(string companyName);


    }
}

