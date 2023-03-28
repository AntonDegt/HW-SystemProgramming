using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для DllWindow.xaml
    /// </summary>
    public partial class DllWindow : Window
    {

        #region User32
        [DllImport("User32.dll")]
        public static extern
            int MessageBoxA(
                IntPtr hWnd, // HWND
                String lpText, // LPCSTR
                String lpCaption, // LPCSTR
                uint uType // UINT
            );

        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern
            int MessageBoxW(
                IntPtr hWnd, // HWND
                String lpText, // LPCSTR
                String lpCaption, // LPCSTR
                uint uType // UINT
            );


        public DllWindow()
        {
            InitializeComponent();
        }

        private void MsgA_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxA(IntPtr.Zero, "Message", "Title", 1);
        }

        private void MsgW_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxW( IntPtr.Zero, "Message", "Title", 1 );
        }

        private void Msg1_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxA(IntPtr.Zero, "Retey", "Not connected", 0x35);
        }

        private void ErrorAlart_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxW(IntPtr.Zero, "Retey", "Not connected", 0x10);
        }
        #endregion

        #region Kernel32
        [DllImport("Kernel32.dll", EntryPoint = "CreateThread")]
        public static extern
            IntPtr CreateThread(
                    IntPtr lpThreadAttributes,
                    uint dwStackSize,
                    ThreadMethod lpStartAddress,
                    IntPtr lpParameter,
                    uint dwCreationFlags,
                    IntPtr lpThreadId
            );

        public delegate void ThreadMethod();

        public void SayHello()
        {
            Dispatcher.Invoke(() => Console.Text += "SayHello!\n");
        }

        private void ThreadB_Click(object sender, RoutedEventArgs e)
        {
            CreateThread(IntPtr.Zero, 0, SayHello, IntPtr.Zero, 0, IntPtr.Zero);
        }
        #endregion

        #region HW Kernel32
        [DllImport("Kernel32.dll")]
        public static extern bool Beep(
            int frequency, 
            int duration
        );

        private void BeepThread1_Click(object sender, RoutedEventArgs e)
        {
            Thread beepThread = new Thread(() => BeepThread(1000));
            beepThread.Start();
        }
        private void BeepThread2_Click(object sender, RoutedEventArgs e)
        {
            Thread beepThread = new Thread(() => BeepThread(500));
            beepThread.Start();
        }

        void BeepThread(int frequency)
        {
            for(int i = 0; i < 5; i++)
            {
                Beep(frequency, 500);
                Dispatcher.Invoke(() => Console.Text += $"B: {frequency}\n");
                Thread.Sleep(100);
            }
        }
        #endregion
    }
}
