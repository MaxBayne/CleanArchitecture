using CleanArchitecture.Domain.Abstract;

namespace CleanArchitecture.Domain.Entities
{
    public class Employee : BaseEntity<int>
    {
        public string Name { get;private set; }
        public string Job { get; private set; }
        public decimal Salary { get; private set; }
        public bool IsActive { get; private set; }

        public Employee()
        {
            Name = string.Empty;
            Job = string.Empty;
            Salary = default;
            IsActive = true;
        }
        public Employee(string name, string job, decimal salary, bool isActive)
        {
            Name = name;
            Job = job;
            Salary = salary;
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


    }
}
