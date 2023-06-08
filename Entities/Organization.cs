using System.Collections;
using System.Collections.Generic;

namespace Pritt.Entities
{
    public class Organization
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Inn { get; set; }
        public string Kpp { get; set; }
        public string RegistrationAddress { get; set; }
        public OrganizationType OrganizationType { get; set; }
        public bool NaturalOrLegalPerson { get; set; }
        public Locality Locality { get; set; }
        public ICollection<User> Users { get; set; }

    }
}