using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserProductManagementAPI.Models
{
    public class Login
    {
        [Required(ErrorMessage = " Email is Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = " Password is Required")]
        public string Password { get; set; }

    }
}
