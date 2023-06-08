using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pritt.Entities
{
    public class VaccinationType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Price Cost { get; set; }
        public ICollection<Locality> Localities { get; set; }
    }
}
