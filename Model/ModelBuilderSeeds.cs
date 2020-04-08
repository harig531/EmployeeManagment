using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Model
{
    public static class ModelBuilderSeeds
    {
        public static void seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   PersonslId = 1,
                   Department = MasterData.CSE,
                   Email = "Hari@gmail.com",
                   FirstName =
                   "Hari",
                   UserName = "hguntu"
               },
                new Employee
                {
                    PersonslId = 2,
                    Department = MasterData.IT,
                    Email = "1111@gmail.com",
                    FirstName =
                   "Hari",
                    UserName = "hguntu"
                }
            );
        }
    }
}
