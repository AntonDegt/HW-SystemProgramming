using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using Microsoft.Win32;

namespace SystemProgramming
{
    /// <summary>
    /// Логика взаимодействия для ProcessWindow.xaml
    /// </summary>
    public partial class ProcessWindow : Window
    {
        private Dictionary<string, List<Process>> processDict = new Dictionary<string, List<Process>>();

        public ProcessWindow()
        {
            InitializeComponent();
        }

        private void ShowProcesses_Click(object sender, RoutedEventArgs e)
        {
            ShowProcesses.IsEnabled = false;
            new Thread(UpdateProcesses).Start();
        }
        private void UpdateProcesses()
        {
            Stopwatch sw = Stopwatch.StartNew();
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                List<Process> list;
                if (processDict.ContainsKey(process.ProcessName))  // процесс с этим именем уже в словаре
                {
                    list = processDict[process.ProcessName];
                    list.Add(process);
                }
                else   // нет такого имени в словаре 
                {
                    list = new List<Process>();
                    list.Add(process);
                    processDict[process.ProcessName] = list;
                }
            }
            sw.Stop();

            Dispatcher.Invoke(() =>
            {
                timeElapsed.Content = sw.ElapsedTicks + " tck";
                treeView.Items.Clear();
                foreach (var pair in processDict)
                {
                    TreeViewItem node = new TreeViewItem() { Header = pair.Key };

                    foreach (Process process in pair.Value)
                    {
                        TreeViewItem subnode = new TreeViewItem() { Header = process.Id };
                        node.Items.Add(subnode);
                    }

                    treeView.Items.Add(node);
                }

                ShowProcesses.IsEnabled = true;
            });
        }
        private Process notepadProcess;
        private void StartNotepad_Click(object sender, RoutedEventArgs e)
        {
            notepadProcess = Process.Start("C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe",
                "-url itstep.org");
            // notepadProcess = Process.Start("notepad.exe", 
            //     @"C:\Users\_dns_\source\repos\SystemProgramming-111\Notes\Processes.txt");

            if (!(notepadProcess is null))
            {
                StopNotepad.IsEnabled = true;
                StartNotepad.IsEnabled = false;
            }
        }

        private void StopNotepad_Click(object sender, RoutedEventArgs e)
        {
            if (!(notepadProcess is null))
            {
                notepadProcess.CloseMainWindow();
                notepadProcess.Kill();
                notepadProcess.WaitForExit();

                StopNotepad.IsEnabled = false;
                StartNotepad.IsEnabled = true;

                notepadProcess = null!;
            }
        }





        #region HW 5
        private void StartNotepadPath_Click(object sender, RoutedEventArgs e)
        {
            if (FilePath.Text.Length > 0)
                Process.Start("Notepad.exe", FilePath.Text);
            else
                MessageBox.Show("File not selected.");
        }

        private void SelectPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                FilePath.Text = openFileDialog.FileName;
        }

        private void OpenBrowser_Click(object sender, RoutedEventArgs e)
        {
            if (LinkBox.Text.Length > 0)
                Process.Start("explorer", LinkBox.Text);
        }
        #endregion
    }
}
