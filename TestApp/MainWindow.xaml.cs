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

        private void ListDirectory(System.Windows.Controls.TreeView treeView, string path)
        {
            treeView.Items.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Items.Add(CreateDirectoryNode(rootDirectoryInfo));
        }

        private static TreeViewItem CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeViewItem();

            directoryNode.Header = directoryInfo.Name;
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Items.Add(CreateDirectoryNode(directory));
            foreach (var file in directoryInfo.GetFiles())
            {
                if(file.Extension.ToLower().Equals(".gif"))
                {
                    var tn = new TreeViewItem();
                    tn.Header = file.Name;
                    directoryNode.Items.Add(tn);
                }
            }
            return directoryNode;
        }

        private void SelectDirectoryButton_Click(object sender, RoutedEventArgs e)
        {
            string path = string.Empty;
            var dialog = new System.Windows.Forms.FolderBrowserDialog();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = dialog.SelectedPath;
            }

            //"C:\\Users\\David\\Pictures\\"
            if (!path.Equals(string.Empty))
            {
                try
                {
                    ListDirectory(FSTreeView, path);
                }catch(Exception ex)
                {
                    string messageBoxText = "Invalid Folder Selection.\nUnable to access hidden folders.\n"+ex.Message;
                    string caption = "An Error Occurred";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;
                    System.Windows.MessageBox.Show(messageBoxText, caption, button, icon);
                }
            }
        }


    }
}
