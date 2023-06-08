using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pritt.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public ICollection<Animal> Animal { get; set; }
    }
}
