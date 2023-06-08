using System.Collections;
using System.Collections.Generic;

namespace Pritt.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool CanEditAnimalCards { get; set; }
        public bool CanEditOrganizationCards { get; set; }
        public bool CanEditMunicipalContractCards { get; set; }
        public bool IsOMSU { get; set; }
    }
}