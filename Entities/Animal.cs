using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Controls;

namespace Pritt.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string ChipNumber { get; set; }
        public Species Category { get; set; }
        public string Nickname { get; set; }
        public Gender Sex { get; set; }
        public ICollection<ProductImage> Photos { get; set; }
        public string SpecialSigns { get; set; }
        public Locality Locality { get; set; }

    }
}