using CSEData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CSEData.Application.Features.Training.Services
{
    public interface ICompanyService
    {
        
        int CreateCompany(string name);
        Company? FindByCompanyName(string name);

        

    }
}
