using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Model
{
    public class SqlEmployeeRepostory : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;
        public SqlEmployeeRepostory(EmployeeDbContext context)
        {
            this._context = context;
        }
        public Employee AddEmp(Employee employee)
        {
            _context.employee.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _context.employee.Find(id);
              if(employee!=null)
            {
                _context.employee.Remove(employee);
                _context.SaveChanges();
            }
            return employee;
        }

        public Employee GetEmployee(int id)
        {
            return _context.employee.Find(id);
            
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.employee;
        }

        public Employee Update(Employee Updateemployee)
        {
            var emp = _context.employee.Attach(Updateemployee);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Updateemployee;
        }
    }
}
