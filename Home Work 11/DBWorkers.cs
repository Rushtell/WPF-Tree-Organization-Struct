using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Home_Work_11
{
    class DBWorkers
    {
        public DBWorkers()
        {
            for (int i = 0; i < dbWorkers.Count; i++)
            {
                if (DBdepartW.Contains(dbWorkers[i].depart) == false)
                {
                    DBdepartW.Add($"{dbWorkers[i].depart}");
                }
            }
            for (int i = 0; i < dbManagers.Count; i++)
            {
                if (DBdepartA.Contains(dbManagers[i].mainDepart) == false)
                {
                    DBdepartA.Add($"{dbManagers[i].mainDepart}");
                }
            }
        }

        static public ObservableCollection<Worker> dbWorkers = new ObservableCollection<Worker>();
        static public ObservableCollection<Manager> dbManagers = new ObservableCollection<Manager>();

        static public ObservableCollection<string> DBdepartW = new ObservableCollection<string>();
        static public ObservableCollection<string> DBdepartA = new ObservableCollection<string>();
    }
}
