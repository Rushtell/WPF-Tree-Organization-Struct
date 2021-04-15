using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Home_Work_11
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (WCount.Text != "" && WInDep.Text != "" && DepLeng.Text != "")
            {
                if (Convert.ToInt32(WCount.Text) >= 1 && Convert.ToInt32(WInDep.Text) >= 1 && Convert.ToInt32(DepLeng.Text) >= 2)
                {
                    try
                    {
                        SetRandomWorker.WCount = Convert.ToInt32(WCount.Text);
                        SetRandomWorker.WInDep = Convert.ToInt32(WInDep.Text);
                        SetRandomWorker.DepLeng = Convert.ToInt32(DepLeng.Text);
                        this.DialogResult = true;
                        this.Visibility = Visibility.Hidden;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Wrong data type!", "Wrong", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else MessageBox.Show("Workers count must be more" +
                    " then 0,\nWorkers in departament must be" +
                    " more then 0,\nLength departament must be " +
                    "more then 1", "Wrong", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else MessageBox.Show("Text box cant be empty!", "Wrong", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
