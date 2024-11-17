using SkilltonTestTask.Data;
using SkilltonTestTask.Models;

namespace SkilltonTestTask.Repositories
{
    public class EmployeeRepository
    {  
        private SkilltonContext _context;
        public EmployeeRepository()
        {
            _context = new SkilltonContext();
        }
        public Employee GetById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.EmployeeID == id);
        }
        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees;
        }

        public void Update(int id, Employee updatedEmployee)
        {
            var entityToUpdate = _context.Employees.FirstOrDefault(e => e.EmployeeID == id);
            if (entityToUpdate != null)
            {
                entityToUpdate.FirstName = updatedEmployee.FirstName;
                entityToUpdate.LastName = updatedEmployee.LastName;
                entityToUpdate.Email = updatedEmployee.Email;
                entityToUpdate.DateOfBirth = updatedEmployee.DateOfBirth;
                entityToUpdate.Salary = updatedEmployee.Salary;
            }
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var employeeToDelete = _context.Employees.FirstOrDefault(e => e.EmployeeID == id);
            if (employeeToDelete != null)
            {
                _context.Employees.Remove(employeeToDelete);
            }
            _context.SaveChanges();
        }
    }
}
