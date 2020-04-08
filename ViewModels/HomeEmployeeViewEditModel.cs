using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.ViewModels
{
    public class HomeEmployeeViewEditModel : HomeEmployeeViewListViewModels
    {
        public string ExistingPath { get; set; }

        public IFormFile ImagePaths { get; set; }
    }
}
