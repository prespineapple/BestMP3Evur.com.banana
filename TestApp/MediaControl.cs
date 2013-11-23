namespace TestApp
{
    class MediaControl
    {
        WMPLib.WindowsMediaPlayer wmPlayer;
        string currentMp3;
        public MediaControl()
        {
            wmPlayer = new WMPLib.WindowsMediaPlayer();
        }

        public void SetProgress(double pos)
        {
            wmPlayer.controls.currentPosition = pos;
        }

        public void setCurrentMp3(string mp3FilePath)
        {
            currentMp3 = mp3FilePath;
            wmPlayer.URL = currentMp3;
            wmPlayer.controls.stop();
        }
        public void playMp3()
        {
            wmPlayer.controls.play();
        }

        public void pauseMp3()
        {
            wmPlayer.controls.pause();
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

        public void setVolume(int volume)
        {
            wmPlayer.settings.volume = volume;
        }

        public double SongDuration()
        {
            return wmPlayer.currentMedia.duration;
        }

    }
}
