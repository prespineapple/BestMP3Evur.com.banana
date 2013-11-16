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
        private MediaControl mp;
        private string nextSong;
        public MainWindow()
        {
            InitializeComponent();
            SongList.ItemsSource = new List<Song>();
            mp = new MediaControl();
            VolumeSlider.Value = 100;
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

            SongList.ItemsSource = songs;
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

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mp.setVolume((int)e.NewValue);
        }

        private void StopBtn_Click(object sender, RoutedEventArgs e)
        {
            mp.stopMp3();
        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            mp.setCurrentMp3(nextSong);
            mp.playMp3();
        }

        private void PauseBtn_Click(object sender, RoutedEventArgs e)
        {
            mp.pauseMp3();
        }

        private void SongList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nextSong = ((Song)SongList.CurrentItem).getFilePath();
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SongList.Items.Count != SongList.SelectedIndex + 1)
            {
                SelectSong(SongList.SelectedIndex+1);
            }
            else
            {
                SelectSong(0);
            }
        }

        public void SelectSong(int index)
        {
            Song song = (Song)SongList.Items[index];
            mp.setCurrentMp3(song.getFilePath());
            mp.playMp3();
            SongList.CurrentItem = SongList.Items[index];
            SongList.SelectedIndex = index;
        }
    }
}
