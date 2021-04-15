using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Threading;
using System.Windows.Threading;

namespace Home_Work_11
{
    class SetRandomWorker
    {
        public static int WCount { get; set; }
        public static int WInDep { get; set; }
        public static int DepLeng { get; set; }

        public SetRandomWorker()
        {
            Start();
        }

        private void Start()
        {
            if (DBWorkers.dbWorkers.Count > 0)
            {
                MessageBoxResult check = MessageBox.Show("List is not empty, u realy want clear all data?", "Info", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (check == MessageBoxResult.Yes)
                {
                    Window1 w1 = new Window1();
                    DBWorkers.dbWorkers.Clear();
                    DBWorkers.dbManagers.Clear();
                    if (w1.ShowDialog() == true)
                    {
                        new RandomWorkers(WCount, WInDep, DepLeng);
                    }
                }
            }
            else
            {
                Window1 w1 = new Window1();
                if (w1.ShowDialog() == true)
                {
                    new RandomWorkers(WCount, WInDep, DepLeng);
                }
            }
        }
    }
}
