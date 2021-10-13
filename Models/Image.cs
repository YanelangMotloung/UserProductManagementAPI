using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserProductManagementAPI.Models
{
    public class Image
    {
        [Key]
        [Required]
        public string Imageid { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Height { get; set; }

        [Required]
        public string ImageType { get; set; }

        [Required]
        public string Blob { get; set; }

        [Required]
        public string Width { get; set; }
    }
}
