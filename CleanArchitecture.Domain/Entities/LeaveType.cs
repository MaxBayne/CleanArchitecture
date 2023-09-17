using CleanArchitecture.Domain.Bases;

namespace CleanArchitecture.Domain.Entities
{
    /// <summary>
    /// نوع المغادرة
    /// </summary>
    public class LeaveType:BaseEntity
    {
        public LeaveType(string name, int defaultDays)
        {
            Name = name;
            DefaultDays = defaultDays;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
