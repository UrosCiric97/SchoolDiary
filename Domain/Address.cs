using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Address
    {
        public Guid Id { get; set; }
        public string CityName { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public User User { get; set; }
    }
}
