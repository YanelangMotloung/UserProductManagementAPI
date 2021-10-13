using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserProductManagementAPI.Models
{
    public class Category
    {
        [Required]
        [Key]
        [RegularExpression(@"^[A-Z]{3}[0-9]{3}$")]
        public string CategoryCode { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string CreatedBy { get; set; }
    }
}
