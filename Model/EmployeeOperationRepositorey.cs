using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Model
{
    public class EmployeeOperationRepositorey : IEmployeeRepository
    {
       private List<Employee> _employeeList;
         
        public EmployeeOperationRepositorey()
        {
            _employeeList = new List<Employee>()
            {
              new Employee() { PersonslId =1,FirstName="Hari Guntu",UserName="HGuntu",Email="Hguntu@agilit.com",Department=MasterData.CSE},
               new Employee() { PersonslId =2,FirstName="Ravi Teja",UserName="RRavi",Email="RRavi@agilit.com",Department=MasterData.ECE},
               new Employee() { PersonslId =3,FirstName="Pavan Kumar",UserName="PPKumar",Email="Pavan@agilit.com",Department=MasterData.IT},
                new Employee() { PersonslId =4,FirstName="Pavan Kumar",UserName="PPKumar",Email="Pavan@agilit.com",Department=MasterData.IT}
            };
        }

        public Employee AddEmp(Employee employee)
        {
            employee.PersonslId = _employeeList.Max(e => e.PersonslId) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.PersonslId == id);
            if(employee!=null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(pID => pID.PersonslId == id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeList;
        }

        public Employee Update(Employee Updateemployee)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.PersonslId == Updateemployee.PersonslId);
            if (employee != null)
            {
                employee.Department = Updateemployee.Department;
                employee.Email = Updateemployee.Email;
                employee.FirstName = Updateemployee.FirstName;
            }
            return employee;
        }
    }
}
