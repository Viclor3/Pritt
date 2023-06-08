using System;
using System.Collections.Generic;

namespace Pritt.Entities
{
    public class MunicipalContract
    {
        public int Id { get; set; }
        public string ContractNumber { get; set; }
        public DateTime AgreementDate { get; set; }
        public DateTime ValidityDate { get; set; }
        public Organization Customer { get; set; }
        public Organization Contractor { get; set; }
        public ICollection<Locality> Localities { get; set; }

    }
}