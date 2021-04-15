using System;
using System.Collections.Generic;
using System.Text;

namespace Home_Work_11
{
    class Intern : Worker
    {
        public Intern (string firstname, string lastname, int age, string depart) 
            : base (firstname, lastname, age, depart)
        {
            salary = 500;
            type = "Intern";
        }

        public Intern(string firstname, string lastname, int age, string depart, int salary)
            : base(firstname, lastname, age, depart)
        {
            this.salary = salary;
            type = "Intern";
        }
    }
}
