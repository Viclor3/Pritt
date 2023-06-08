using System.Collections.Generic;

namespace Pritt.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password{ get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public Organization Organization { get; set; }
        public Role Role { get; set; }
    }
}