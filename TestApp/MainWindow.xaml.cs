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
