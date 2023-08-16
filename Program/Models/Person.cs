namespace Program.Models;

public class Person
{
    public Person(string title, string surname, string foreName, List<Department> departments)
    {
        Title = title;
        Surname = surname;
        ForeName = foreName;
        Departments = departments;
    }

    public string Title { get; }
    public string Surname { get; }
    public string ForeName { get; }
    public List<Department> Departments { get; } = new ();
}