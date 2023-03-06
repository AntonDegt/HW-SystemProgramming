using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SystemProgramming
{
    /// <summary>
    /// Логика взаимодействия для MultiWindow.xaml
    /// </summary>
    public partial class MultiWindow : Window
    {
        public MultiWindow()
        {
            InitializeComponent();
        }

        

        private void ButtonStart1_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                
            }
        }

        private void ButtonStop1_Click(object sender, RoutedEventArgs e)
        {

        }

        private double sum;
        private int precent;
        private Random random = new Random();

        private void plusPrecent()
        {
            double val = sum;
            
            Thread.Sleep(random.Next(250, 350));
            
            val *= 1 + precent / 100;

            sum = val;

            progressBar1.Value += 10;

            Dispatcher.Invoke(() => ConsoleBlock.Text += sum + "\n");
        }
    }
}
