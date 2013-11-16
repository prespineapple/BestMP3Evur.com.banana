using System;
using System.Collections.Generic;
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
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;

namespace TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void ImportMusicBtn_Click(object sender, RoutedEventArgs e)
        {
            string path = null;
            var dialog = new System.Windows.Forms.FolderBrowserDialog();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = dialog.SelectedPath;
            }

            if (path != null && path.Length > 0)
            {
                getMp3s(path);

            }
        }

        private void getMp3s(string path)
        {
            foreach (var file in new DirectoryInfo(path).GetFiles())
            {
                if (file.Extension.ToLower().Equals(".mp3"))
                {
                    DataGridViewRow row = hammerPants.Rows;
                }
            }
        }


    }
}
