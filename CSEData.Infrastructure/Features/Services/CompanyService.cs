using CSEData.Application;
using CSEData.Application.Features.Training.Repositories;
using CSEData.Application.Features.Training.Services;
using CSEData.Domain.Entities;
using CSEData.Domain.Repositories;
using CSEData.Infrastructure.Features.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEData.Infrastructure.Features.Services
{
    public class CompanyService :ICompanyService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        public CompanyService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        public int CreateCompany(string name)
        {

            if (_unitOfWork.Companies.IsDuplicateName(name))
            {
                return 0;
            }
            else
            {
                Company company = new Company();
                company.StockCodeName = name;
                _unitOfWork.Companies.Add(company);
                _unitOfWork.Save();
                return company.Id;
            }
        }

        public Company? FindByCompanyName(string name)
        {
            return _unitOfWork.Companies.FindByCompanyName(name);
        }



       
    }

}
