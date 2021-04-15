using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Home_Work_11
{
    class Manager : Worker
    {
        public int realSalary { get; set; }
        public string mainDepart { get; set; }

        public Manager (string firstname, string lastname, int age, string depart, string mainDepart)
            : base (firstname, lastname, age, depart)
        {
            this.mainDepart = mainDepart;
            realSalary = (int)(0.15 * SumSalary(depart));
            if (realSalary < 1300) salary = 1300;
            else salary = realSalary;
            type = "Manager";
        }

        public Manager(string firstname, string lastname, int age, string depart, string mainDepart,int salary, int realSalary)
            : base(firstname, lastname, age, depart)
        {
            this.mainDepart = mainDepart;
            this.realSalary = realSalary;
            this.salary = salary;
            type = "Manager";
        }

        private int SumSalary (string depart)
        {
            int sum = 0;

            for (int i = 0; i < DBWorkers.dbWorkers.Count; i++)
            {
                if (DBWorkers.dbWorkers[i].depart == depart)
                {
                    sum += DBWorkers.dbWorkers[i].salary;
                }
            }

            return sum;
        }

        public static void ReSalary (Manager manager)
        {
            int sum = 0;

            for (int i = 0; i < DBWorkers.dbWorkers.Count; i++)
            {
                if (DBWorkers.dbWorkers[i].depart == manager.depart)
                {
                    sum += DBWorkers.dbWorkers[i].salary;
                }
            }
            manager.realSalary = (int)(0.15 * sum);
            if ((int)(0.15 * sum) < 1300) manager.salary = 1300;
            else manager.salary = (int)(0.15 * sum);
        }
    }
}
