using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.Json;
using System.Runtime.Serialization.Json;


namespace Home_Work_11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Главное окно

        public MainWindow()
        {
            InitializeComponent();

            ViewInListDB();
        }

        #endregion

        #region Кнопки

        private void Chek_Click(object sender, RoutedEventArgs e)
        {
            new SetRandomWorker();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new JsonSerializer();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            ClearDB();
            new JsonDeserializer(this);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            new Delete(this);
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            new Change(this);
        }

        #endregion

        #region Методы работы с базами данных

        // Методы работы с базами данных

        private void ClearDB()
        {
            DBWorkers.dbManagers.Clear();
            DBWorkers.dbWorkers.Clear();
        }

        public void ViewInListDB()
        {
            lsAdmins.ItemsSource = DBWorkers.dbManagers;
            lsWorkers.ItemsSource = DBWorkers.dbWorkers;
        }

        int change = -1;

        private void ChangeTab(int num)
        {
            if (change != num)
            {
                DBWorkers.DBdepartA.Clear();
                DBWorkers.DBdepartW.Clear();
                Salary.Text = "";
                lsAdmins.SelectedIndex = -1;
                lsWorkers.SelectedIndex = -1;
                change = num;
            }
        }

        #endregion

        #region События

        private void lsWorkers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lsWorkers.SelectedIndex != -1)
            {
                CBdepart.ItemsSource = DBWorkers.DBdepartW;
                DBWorkers.DBdepartW.Clear();
                DBWorkers.DBdepartA.Clear();
                new DBWorkers();
                Salary.Text = DBWorkers.dbWorkers[DBWorkers.dbWorkers.IndexOf((Worker)lsWorkers.SelectedItem)].salary.ToString();
                CBdepart.SelectedItem = DBWorkers.dbWorkers[DBWorkers.dbWorkers.IndexOf((Worker)lsWorkers.SelectedItem)].depart;
            }
        }

        private void lsAdmins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lsAdmins.SelectedIndex != -1)
            {
                CBdepart.ItemsSource = DBWorkers.DBdepartA;
                DBWorkers.DBdepartW.Clear();
                DBWorkers.DBdepartA.Clear();
                new DBWorkers();
                Salary.Text = DBWorkers.dbManagers[DBWorkers.dbManagers.IndexOf((Manager)lsAdmins.SelectedItem)].salary.ToString();
                CBdepart.SelectedItem = DBWorkers.dbManagers[DBWorkers.dbManagers.IndexOf((Manager)lsAdmins.SelectedItem)].mainDepart;
            }
        }
        
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabControl.SelectedIndex == 0) ChangeTab(0);
            else if (TabControl.SelectedIndex == 1) ChangeTab(1);
        }

        #endregion
    }
}
