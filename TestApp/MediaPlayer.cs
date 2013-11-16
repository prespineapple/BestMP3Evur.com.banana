
namespace TestApp
{
    class MediaPlayer
    {
        WMPLib.WindowsMediaPlayer wmPlayer;
        string currentMp3;
        public MediaPlayer()
        {
            wmPlayer = new WMPLib.WindowsMediaPlayer();
        }

        public void setCurrentMp3(string mp3FilePath)
        {
            wmPlayer.controls.stop();
            currentMp3 = mp3FilePath;
            wmPlayer.URL = currentMp3;
        }
        public void playMp3()
        {
            wmPlayer.controls.play();
        }

        public void pauseMp3()
        {
            if (isPlaying())
            {
                wmPlayer.controls.pause();
            }
        }

        public void stopMp3()
        {
            if (isPlaying())
            {
                wmPlayer.controls.stop();
            }
        }

        public bool isPlaying()
        {

            return wmPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying;
        }
    }
}
