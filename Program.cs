using ETA25_Intermediate.Session01;

namespace ETA25_Intermediate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            #region Session01
            Person person = new Person();

            var years = EmployeeUtilities.CalculateSeniorityInYears(DateTime.Now.AddYears(-10));

            Person person2 = new Person();
            Console.WriteLine($"The person's first name is {person2.FirstName}, last name is {person2.LastName} and age is {person2.Age}");

            Person person3 = new Person("Radu", "Fifiita", 32);
            Console.WriteLine($"The person's first name is {person3.FirstName}, last name is {person3.LastName} and age is {person3.Age}");

            Person person4 = new Person("Test", "Boundary", 5);
            Console.WriteLine($"The person's first name is {person4.FirstName}, last name is {person4.LastName} and age is {person4.Age}");

            //person4.Age = -1;
            #endregion

            #region Session06
            Session06.Employee employee1 = new Session06.Employee("Radu", "Software Dev");
            Console.WriteLine();
            Console.WriteLine();

            employee1.DisplayInfo();
            Console.WriteLine(employee1.WhoAmI());

            Console.WriteLine("The current salary is: " + employee1.GetSalary());
            employee1.SetSalary(5000);
            Console.WriteLine("The current salary is: " + employee1.GetSalary());
            employee1.SetSalary(10000);


            Session06.Person person5 = new Session06.Employee("DerivedClass", "Department");
            person5.DisplayInfo();

            List<Session06.Person> personsList = new List<Session06.Person>()
            {
                new Session06.Employee("Emp1", "Dept1"),
                new Session06.Employee("Emp2", "Dept1"),
                new Session06.Employee("Emp3", "Dept1")
            };

            personsList.ForEach(person => person.DisplayInfo());

            #endregion

            Console.ReadKey();
        }
    }
}
