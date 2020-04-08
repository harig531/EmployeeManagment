using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Model
{
    public class EmployeePath
    {
        
        [Required]
        [Display(Name = "Full Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "User Name")]
        [MinLength(6, ErrorMessage = "User Name Must be 6 digits")]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        public MasterData Department { get; set; }
        public List<IFormFile> ImagePaths { get; set; }
    }
}
