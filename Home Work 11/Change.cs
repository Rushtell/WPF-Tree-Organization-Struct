using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Home_Work_11
{
    class Change
    {
        public Change (MainWindow W)
        {
            if (W.TabControl.SelectedIndex == 0)
            {
                DBWorkers.dbWorkers[DBWorkers.dbWorkers.IndexOf((Worker)W.lsWorkers.SelectedItem)].salary = Convert.ToInt32(W.Salary.Text);  
                DBWorkers.dbWorkers[DBWorkers.dbWorkers.IndexOf((Worker)W.lsWorkers.SelectedItem)].depart = W.CBdepart.Text;
                ReSalary(0);
                Refresh();
            }
            else if (W.TabControl.SelectedIndex == 1)
            {
                DBWorkers.dbManagers[DBWorkers.dbManagers.IndexOf((Manager)W.lsAdmins.SelectedItem)].salary = Convert.ToInt32(W.Salary.Text);
                DBWorkers.dbManagers[DBWorkers.dbManagers.IndexOf((Manager)W.lsAdmins.SelectedItem)].mainDepart = W.CBdepart.Text;
                int index = 0;
                for (int i = 0; i < DBWorkers.dbManagers.Count; i++)
                {
                    if (((Manager)W.lsAdmins.SelectedItem).mainDepart == DBWorkers.dbManagers[i].depart)
                    {
                        index = i;
                        break;
                    }
                }
                ReSalary(index);
                Refresh();
            }
            W.lsWorkers.SelectedIndex = -1;
            W.lsAdmins.SelectedIndex = -1;
        }

        private void ReSalary(int index)
        {
            for (int i = index; i < DBWorkers.dbManagers.Count; i++)
            {
                if (DBWorkers.dbManagers[i].type == "Manager")
                {
                    Manager.ReSalary(DBWorkers.dbManagers[i]);
                }
                else
                {
                    Administrator.ReSalary(DBWorkers.dbManagers[i]);
                }
            }
        }

        private void Refresh()
        {
            ObservableCollection<Manager> db2 = new ObservableCollection<Manager>();
            for (int i = 0; i < DBWorkers.dbManagers.Count; i++)
            {
                db2.Add(DBWorkers.dbManagers[i]);
            }
            DBWorkers.dbManagers.Clear();
            for (int i = 0; i < db2.Count; i++)
            {
                DBWorkers.dbManagers.Add(db2[i]);
            }

            ObservableCollection<Worker> db3 = new ObservableCollection<Worker>();
            for (int i = 0; i < DBWorkers.dbWorkers.Count; i++)
            {
                db3.Add(DBWorkers.dbWorkers[i]);
            }
            DBWorkers.dbWorkers.Clear();
            for (int i = 0; i < db3.Count; i++)
            {
                DBWorkers.dbWorkers.Add(db3[i]);
            }
        }
    }
}
