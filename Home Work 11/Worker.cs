using System;
using System.Collections.Generic;
using System.Text;

namespace Home_Work_11
{
    class Worker
    {
        Random r = new Random();
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int age { get; set; }
        public int salary { get; set; }
        public string depart { get; set; }
        public string type { get; set; }

        public Worker (string firstname, string lastname, int age, string depart)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.age = age;
            this.salary = r.Next(1000, 1201);
            this.depart = depart;
            type = "Worker";
        }

        public Worker (string firstname, string lastname, int age, string depart, int salary)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.age = age;
            this.salary = salary;
            this.depart = depart;
            type = "Worker";
        }
    }
}
