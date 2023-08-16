using Program.Models;

namespace Program.Implementations;

public class DataContext
{
    public List<Person> Persons { get; private set; } = new();
    public List<Department> Departments { get; private set; } = new();
    
    public DataContext()
    {
        SeedData();
    }

    public List<string> GetSurnames(string departmentName)
    {
        var department = Departments.FirstOrDefault(x => x.Name == departmentName);

        if (department == null)
        {
            throw new NotImplementedException();
        }

        return GetSurnames(department);
    }

    public List<string> GetSurnames(Department department)
    {
        return department.Members.Select(x => x.Surname).ToList();
    }
    
    private void SeedData()
    {
        var purchasingDepartment = new Department("Purchasing", "Top floor");
        var salesDepartment = new Department("Sales", "Bottom floor");
        Departments = new List<Department> { purchasingDepartment, salesDepartment };
        Persons = new List<Person>
        {
            new Person("Mr", "Smith", "John", new List<Department> { purchasingDepartment }),
            new Person("Mr", "Jones", "Steve", new List<Department> { purchasingDepartment }),
            new Person("Mrs", "Bradshaw", "Lisa", new List<Department> { purchasingDepartment, salesDepartment }),
            new Person("Miss", "Thompson", "Joanne", new List<Department> { salesDepartment }),
            new Person("Mr", "Johnson", "David", new List<Department> { salesDepartment }),
        };

        foreach (var person in Persons)
        {
            foreach (var department in Departments)
            {
                if (person.Departments.Exists(x => x == department))
                {
                    department.Members.Add(person);
                }
            }
        }
    }
}