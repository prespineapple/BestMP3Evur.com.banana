using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer mp;
        public MainWindow()
        {
            InitializeComponent();
            hammerPants.ItemsSource = new List<Song>();
            mp = new MediaPlayer();
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

        private void ImportMusicBtn_Click(object sender, RoutedEventArgs e)
        {
            //mp.setCurrentMp3("C:\\Users\\god\\Dropbox\\running_music\\Classified feat. David Myles - Inner Ninja.mp3");
            //mp.playMp3();
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
    }
}
