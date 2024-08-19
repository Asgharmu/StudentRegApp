using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsApp
{
    public class Student
    {
        public string Name { get; set; }
        public string Year { get; set; }
        public int Semester { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Year {Year}, Semester {Semester}";
        }
    }
}

