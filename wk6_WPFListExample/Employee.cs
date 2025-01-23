using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wk6_WPFListExample
{
    class Employee
    {

        double _salary;
        public int Id { get; set; }
        public string Name { get; set; }

        public double Salary
        {
            get { return _salary; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Salary cannot be less than 0");
                }
                _salary = value;
            }
        }

        public Employee(int id, string name, double salary)
        {
            Salary = salary;   //assign the value to Property to get the condition executed
            Id = id;
            Name = name;

        }

    }
}
