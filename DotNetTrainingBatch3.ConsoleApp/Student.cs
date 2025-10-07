using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp
{
    public class Student : Father
    {
        public string myName;

        public string MyName { get; set; }

        // Backing field
        private string _name;

        // Public property
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string CallTest(string familyName)
        {
            // Accessing the protected method from the base class
            return Test1(familyName);
        }

        public Student()
        {
            Test1("");
        }

        abstract class StudentAnimal
        {
            public abstract void animalSound();
            public void sleep()
            {
                Console.WriteLine("Zzz");
            }
        }
    }

    abstract class Animal
    {
        public abstract void animalSound();
        public void sleep()
        {
            Console.WriteLine("Zzz");
        }
    }
}
