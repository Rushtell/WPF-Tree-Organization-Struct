using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Home_Work_11
{
    class Administrator : Manager
    {
        public Administrator (string firstname, string lastname, int age, string depart, string mainDepart) 
            : base (firstname, lastname, age, depart, mainDepart)
        {
            realSalary = (int)(0.15 * SumSalary(depart));
            if (realSalary < 1300) salary = 1300;
            else salary = realSalary;
            type = "Administrator";
        }

        public Administrator(string firstname, string lastname, int age, string depart, string mainDepart, int salary, int realSalary)
            : base(firstname, lastname, age, depart, mainDepart)
        {
            this.realSalary = realSalary;
            this.salary = salary;
            type = "Administrator";
        }

        private int SumSalary (string depart)
        {
            int sum = 0;

            for (int i = 0; i < DBWorkers.dbManagers.Count; i++)
            {
                if (depart == DBWorkers.dbManagers[i].mainDepart)
                {
                    sum += (((DBWorkers.dbManagers[i].realSalary / 15) * 100) + DBWorkers.dbManagers[i].salary);
                }
            }

            return sum;
        }

        public static new void ReSalary(Manager manager)
        {
            int sum = 0;

            for (int i = 0; i < DBWorkers.dbManagers.Count; i++)
            {
                if (manager.depart == DBWorkers.dbManagers[i].mainDepart)
                {
                    sum += (((DBWorkers.dbManagers[i].realSalary / 15) * 100) + DBWorkers.dbManagers[i].salary);
                }
            }
            manager.realSalary = (int)(0.15 * sum);
            if ((int)(0.15 * sum) < 1300) manager.salary = 1300;
            else manager.salary = (int)(0.15 * sum);
        }

    }
}
