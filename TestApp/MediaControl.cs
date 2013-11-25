/**
 * A09 Team Project - MP3 Player
 * Robert Kempton & David Cruz
 */

namespace MP3Player
{
    class MediaControl
    {
        WMPLib.WindowsMediaPlayer wmPlayer;
        public string currentMp3;

        public MediaControl()
        {
            wmPlayer = new WMPLib.WindowsMediaPlayer();
        }

        public void SetProgress(double pos)
        {
            wmPlayer.controls.currentPosition = pos;
        }

        public void SetCurrentMp3(string mp3FilePath)
        {
            currentMp3 = mp3FilePath;
            wmPlayer.URL = currentMp3;
            wmPlayer.controls.stop();
        }

        public void PlayMp3()
        {
            if (currentMp3 != null)
            {
                wmPlayer.controls.play();
            }
        }

        public void PauseMp3()
        {
            if (currentMp3 != null)
            {
                wmPlayer.controls.pause();
            }
        }

        public void StopMp3()
         {
             if (currentMp3 != null)
             {
                wmPlayer.controls.stop();
             }
        }

        public bool IsPlaying()
        {
            return wmPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying;
        }

        public void SetVolume(int volume)
        {
            wmPlayer.settings.volume = volume;
        }

        public double SongDuration()
        {
            return wmPlayer.currentMedia.duration;
        }

    }
}
