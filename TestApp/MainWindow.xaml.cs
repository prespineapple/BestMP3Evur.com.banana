using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

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
            hammerPants.ItemsSource = new List<Song>();
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
            {
                if ((directory.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    directoryNode.Items.Add(CreateDirectoryNode(directory));
                }
            }
            foreach (var file in directoryInfo.GetFiles())
            {
                if (file.Extension.ToLower().Equals(".mp3"))
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
            string path = null;
            var dialog = new System.Windows.Forms.FolderBrowserDialog();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = dialog.SelectedPath;
            }

            //"C:\\Users\\David\\Pictures\\"
            if (path != null && path.Length > 0)
            {
                getMp3s(path);
                try
                {
                    ListDirectory(FSTreeView, path);
                }
                catch (Exception ex)
                {
                    string messageBoxText = "Invalid Folder Selection.\nUnable to access hidden folders.\n" + ex.Message;
                    string caption = "An Error Occurred";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;
                    System.Windows.MessageBox.Show(messageBoxText, caption, button, icon);
                }
            }
        }

        private void getMp3s(string path)
        {
            List<Song> songs = new List<Song>();
            foreach (var file in new DirectoryInfo(path).GetFiles())
            {
                if (file.Extension.ToLower().Equals(".mp3"))
                {
                    songs.Add(new Song(file.FullName));
                }
            }

            hammerPants.ItemsSource = songs;
        }


    }
}
