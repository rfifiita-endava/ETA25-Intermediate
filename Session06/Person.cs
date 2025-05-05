namespace ETA25_Intermediate.Session06;

public abstract class Person
{
    public string Name { get; set; }

    protected Person(string name)
    {
        Name = name;
    }

    public abstract void DisplayInfo();

    public virtual string WhoAmI()
    {
        return "I am base class";
    }
}
