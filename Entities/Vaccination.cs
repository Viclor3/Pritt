using System;
using System.Collections.Generic;

namespace Pritt.Entities
{
    public class Vaccination
    {
        public int Id { get; set; }
        public Animal Animal { get; set; }
        public DateTime VaccinationDate { get; set; }
        public string SerialNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public User Vet { get; set; }
        public MunicipalContract MunicipalContract { get; set;}
        public VaccinationType  Type { get; set; }
    }
}