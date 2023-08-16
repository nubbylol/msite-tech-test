namespace Program.Models;

public class Department
{
    public Department(string name, string location)
    {
        Name = name;
        Location = location;
    }

    public string Name { get; }
    public string Location { get; }
    public List<Person> Members { get; set; } = new();
}