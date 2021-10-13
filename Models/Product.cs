using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserProductManagementAPI.Models
{
    public class Product
    {
        [Required]
        public int Productid { get; set; }
        
        [Key]
        [Required]
        [RegularExpression("^[0-9]{4}[0-12]{2}-d{3}$")]
        public string Productcode { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [ForeignKey("Category")]
        [RegularExpression(@"^[A-Z]{3}[0-9]{3}$")]
        public string CategoryCode { get; set; }

        [Required]
        [Range(0, 999.99)]
        public double Price { get; set; }

        [ForeignKey("Image")]
        public string ImageId { get; set; }

        [Required]
        public DateTime Createddate { get; set; }

        [Required]
        public string CreatedBy { get; set; }




        public Category Category { get; set; }
        public Image Image { get; set; }

    }
}
