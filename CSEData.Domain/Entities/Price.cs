using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.WebRequestMethods;

namespace CSEData.Domain.Entities
{
    public class Price: IEntity<int>
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }

        [Column(TypeName ="float")]
        public float PriceLTP { get; set; }
        public int Volume { get; set; }

        [Column(TypeName = "float")]
        public float Open { get; set; }

        [Column(TypeName = "float")]
        public float High { get; set; }

        [Column(TypeName = "float")]
        public float Low { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime Time { get; set; }
        public Company Company { get; set; }
    }
}
