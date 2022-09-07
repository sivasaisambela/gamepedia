using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlayStationStore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display order must be in between 1 to 100!!")]
        public int DisplayOrder { get; set; }

        [Required]
        public Decimal Price { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string Subscriptions { get; set; }
    }
}
