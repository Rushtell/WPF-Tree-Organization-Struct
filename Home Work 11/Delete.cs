using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace Home_Work_11
{
    class Delete
    {
        MainWindow w;

        public Delete (MainWindow W)
        {
            if (W.lsAdmins.SelectedIndex == -1 && W.lsWorkers.SelectedIndex == -1) return;
            w = W;
            if (W.TabControl.SelectedIndex == 0)
            {
                DBWorkers.dbWorkers.Remove((Worker)W.lsWorkers.SelectedItem);
                ReSalary();
                Refresh();
            }
            else if (W.TabControl.SelectedIndex == 1)
            {
                if (MessageBox.Show("U realy wanna delete all departaments and workers," +
                    "\nthem administrated this is administrator or manager?", "Delete", 
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DeleteAdmin();
                    ReSalary();
                    Refresh();
                }
            }
            
        }

        private void DeleteAdmin()
        {
            object selectedAdmin = (Manager)w.lsAdmins.SelectedItem;
            int index = DBWorkers.dbManagers.IndexOf((Manager)selectedAdmin);
            if (DBWorkers.dbManagers[index].type == "Manager")
            {
                for (int i = 0; i < DBWorkers.dbWorkers.Count; i++)
                {
                    if (DBWorkers.dbManagers[index].depart == DBWorkers.dbWorkers[i].depart)
                    {
                        DBWorkers.dbWorkers.Remove(DBWorkers.dbWorkers[i]);
                        i -= 1;
                    }
                }
                DBWorkers.dbManagers.Remove((Manager)w.lsAdmins.SelectedItem);
            }
            else
            {
                DeleteNextAdmin(DBWorkers.dbManagers[index]);
            }
        }

        private void DeleteNextAdmin(Manager admin)
        {
            if (admin.type == "Manager")
            {
                for (int i = 0; i < DBWorkers.dbWorkers.Count; i++)
                {
                    if (admin.depart == DBWorkers.dbWorkers[i].depart)
                    {
                        DBWorkers.dbWorkers.Remove(DBWorkers.dbWorkers[i]);
                        i = -1;
                    }
                }
                DBWorkers.dbManagers.Remove(admin);
            }
            else
            {
                for (int i = 0; i < DBWorkers.dbManagers.Count; i++)
                {
                    if (admin.depart == DBWorkers.dbManagers[i].mainDepart)
                    {
                        DeleteNextAdmin(DBWorkers.dbManagers[i]);
                        i = -1;
                    }
                }
                DBWorkers.dbManagers.Remove(admin);
            }
        }

        public static void ReSalary()
        {
            for (int i = 0; i < DBWorkers.dbManagers.Count; i++)
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

        public static void Refresh()
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
        }
    }
}
