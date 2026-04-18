using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortableList.Models
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column("ProductOrder")]
        public int Order { get; set; }
        public bool Selected { get; set; }
    }
}
