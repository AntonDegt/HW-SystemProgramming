using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
    /// Логика взаимодействия для SynchroWindow.xaml
    /// </summary>
    public partial class SynchroWindow : Window
    {
        public SynchroWindow()
        {
            InitializeComponent();
        }

        #region 1. lock

        private void ButtonStart1_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 1; i <= 5; ++i)
            {
                new Thread(doWork1).Start(i);
            }
        }

        private readonly object locker = new object();

        private void doWork1(object? state)
        {
            lock (locker)
            {
                Dispatcher.Invoke(() => ConcoleBlock.Text += state?.ToString() + "start\n");
                Thread.Sleep(1000);
                Dispatcher.Invoke(() => ConcoleBlock.Text += state?.ToString() + "finish\n");
            }
        }
        #endregion

        #region 2. Monitor

        private void ButtonStart2_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 5; ++i)
            {
                new Thread(doWork2).Start(i);
            }
        }

        private readonly object monitor = new object();

        private void doWork2(object? state)
        {
            try
            {
                Monitor.Enter(monitor);
                Dispatcher.Invoke(() => ConcoleBlock.Text += state?.ToString() + "start\n");
                Thread.Sleep(1000);
                Dispatcher.Invoke(() => ConcoleBlock.Text += state?.ToString() + "finish\n");
            }
            finally
            {
                Monitor.Exit(monitor);
            }
        }
        #endregion

        #region 3. Monitor

        private void ButtonStart3_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 5; ++i)
            {
                new Thread(doWork3).Start(i);
            }
        }

        private Mutex mutex = new Mutex();

        private void doWork3(object? state)
        {
            mutex.WaitOne();

            Dispatcher.Invoke(() => ConcoleBlock.Text += state?.ToString() + "start\n");
            Thread.Sleep(1000);
            Dispatcher.Invoke(() => ConcoleBlock.Text += state?.ToString() + "finish\n");

            mutex.ReleaseMutex();
        }
        #endregion

        #region 4. EventWaitHandle

        private void ButtonStart4_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 5; ++i)
            {
                new Thread(doWork4).Start(i);
            }
            gates.Set();
        }

        private EventWaitHandle gates = new AutoResetEvent(false);

        private void doWork4(object? state)
        {
            gates.WaitOne();

            Dispatcher.Invoke(() => ConcoleBlock.Text += state?.ToString() + "start\n");
            Thread.Sleep(1000);
            Dispatcher.Invoke(() => ConcoleBlock.Text += state?.ToString() + "finish\n");

            gates.Set();
        }
        #endregion

        #region 5. Semaphore

        private void ButtonStart5_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 5; ++i)
            {
                new Thread(doWork5).Start(i);
            }
            semaphore.Release(2);

            Task.Run( async () =>
            {
                await Task.Delay(200);
                semaphore.Release(1);
            });
        }

        private Semaphore semaphore = new Semaphore(0, 3);

        private void doWork5(object? state)
        {
            semaphore.WaitOne();
            try
            {
                Dispatcher.Invoke(() => ConcoleBlock.Text += state?.ToString() + "start\n");
                Thread.Sleep(1000);
                Dispatcher.Invoke(() => ConcoleBlock.Text += state?.ToString() + "finish\n");
            }
            finally 
            { 
                semaphore.Release(1); 
            }
        }
        #endregion
    }
}
