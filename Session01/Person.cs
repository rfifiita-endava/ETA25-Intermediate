using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETA25_Intermediate.Session01;
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    private int age;
    public int Age
    {
        get { return age; }
        set 
        { 
            if (value < 0 || value > 150)
            {
                throw new ArgumentException("The person's age cannot exceed the specfied interval: [0-150]");
            }
            age = value; 
        }
    }
    protected int CNP; 

    public Person()
    {
        // implementation goes here
        FirstName = "John";
        LastName = "Doe";
        age = 1;
    }

    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        this.age = age;
    }
}

