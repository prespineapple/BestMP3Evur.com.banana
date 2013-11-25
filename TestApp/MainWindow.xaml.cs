/**
 * A09 Team Project - MP3 Player
 * Robert Kempton & David Cruz
 */

using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace MP3Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaControl mp;
        private string nextSong, currentSong;
        public MainWindow()
        {
            InitializeComponent();
            SongList.ItemsSource = new List<Song>();
            mp = new MediaControl();
            VolumeSlider.Value = 100;
        }

        private void GetMp3s(string path)
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
            string path = null;
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = dialog.SelectedPath;
            }

            if (path != null && path.Length > 0)
            {
                //path = "C:\\Windows\\winsxs\\amd64_microsoft-windows-musicsamples_31bf3856ad364e35_6.1.7600.16385_none_06495209cbd8e93b";
                GetMp3s(path);
            }
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mp.SetVolume((int)e.NewValue);
        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentSong == null || !currentSong.Equals(nextSong))
            {
                currentSong = nextSong;
                mp.SetCurrentMp3(nextSong);
            }
            mp.PlayMp3();

        }

        private void PauseBtn_Click(object sender, RoutedEventArgs e)
        {
            mp.PauseMp3();
        }

        private void StopBtn_Click(object sender, RoutedEventArgs e)
        {
            mp.StopMp3();
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            GoToNextSong();
        }

        private void PrevBtn_Click(object sender, RoutedEventArgs e)
        {
            if (mp.currentMp3 != null)
            {
                if (!(SongList.SelectedIndex - 1 < 0))
                {
                    SelectSong(SongList.SelectedIndex - 1);
                }
                else
                {
                    SelectSong(SongList.Items.Count - 1);
                }
                currentSong = nextSong;
            }
        }

        private void SongList_DoubleClick(object sender, RoutedEventArgs m)
        {
            if (SongList != null && SongList.CurrentItem != null)
            {
                PlayBtn_Click(sender, m);
            }
        }

        private void SongList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SongList != null && SongList.CurrentItem != null)
            {
                nextSong = ((Song)SongList.CurrentItem).getFilePath();
            }

        }

        private void SelectSong(int index)
        {
            Song song = (Song)SongList.Items[index];
            mp.SetCurrentMp3(song.getFilePath());
            mp.PlayMp3();
            SongList.CurrentItem = SongList.Items[index];
            SongList.SelectedIndex = index;
        }

        private void GoToNextSong()
        {
            if (mp.currentMp3 != null)
            {
                if (SongList.Items.Count != SongList.SelectedIndex + 1)
                {
                    SelectSong(SongList.SelectedIndex + 1);
                }
                else
                {
                    SelectSong(0);
                }
                currentSong = nextSong;
            }
        }

        private string SecondsToMinSec(double duration)
        {
            int minutes = (int)duration / 60;
            int seconds = (int)duration % 60;
            return string.Format("{0}:{1}", minutes, seconds);
        }

    }
}
