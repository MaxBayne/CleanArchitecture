using CleanArchitecture.Domain.Abstract;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities
{
    public class Employee : Entity<int>
    {
        public string Name { get;private set; }
        public string Job { get; private set; }
        public decimal Salary { get; private set; }
        public bool IsActive { get; private set; }
        public EmployeeType Type { get; private set; }

        public Employee()
        {
            Name = string.Empty;
            Job = string.Empty;
            Salary = default;
            IsActive = true;
            Type = EmployeeType.Regular;
        }
        public Employee(string name, string job,EmployeeType type, decimal salary)
        {
            Name = name;
            Job = job;
            Salary = salary;
            Type=type;
            IsActive = true;
        }
        public Employee(string name, string job, EmployeeType type, decimal salary, bool isActive)
        {
            Name = name;
            Job = job;
            Salary = salary;
            Type = type;
            IsActive = isActive;
        }

        public void ChangeName(string name)
        {
            Name=name;
        }

        public void ChangeJob(string job)
        {
            Job=job;
        }

        public void ChangeSalary(decimal salary)
        {
            Salary = salary;
        }

        public void EnableEmployee()
        {
            IsActive = true;
        }

        public void DisableEmployee()
        {
            IsActive = false;
        }

        public void ChangeType(EmployeeType type)
        {
            Type=type;
        }
    }
}
