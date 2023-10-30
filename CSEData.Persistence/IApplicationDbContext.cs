using Microsoft.EntityFrameworkCore;
using CSEData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEData.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Company> Companies { get; set; }
        DbSet<Price> Prices { get; set; }
    }
}
