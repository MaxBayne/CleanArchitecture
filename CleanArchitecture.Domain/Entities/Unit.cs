using CleanArchitecture.Domain.Abstract;

namespace CleanArchitecture.Domain.Entities;

public class Unit: BaseEntity<int>
{
    public string Name { get; private set; }

    public Unit()
    {
        Name=string.Empty;
    }
    public Unit(string name)
    {
        Name = name;
    }

    public void ChangeName(string name)
    {
        Name = name;
    }
    
}