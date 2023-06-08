using System.Collections;
using System.Collections.Generic;

namespace Pritt.Entities
{
    public class Locality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MunicipalContract> Contracts { get; set; }
        public ICollection<VaccinationType> VaccinationTypes { get; set; } 
    }
}