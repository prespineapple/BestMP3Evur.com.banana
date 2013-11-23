using System;
using System.IO;

namespace TestApp
{
    class Song
    {

        public string title { get; private set; }
        public string artist { get; private set; }
        public string duration { get; private set; }
        public string album { get; private set; }
        private string filePath;
        public Song(String filePath)
        {
            this.filePath = filePath;
            FileInfo fi = new FileInfo(filePath);
            TagLib.File file = TagLib.File.Create(filePath);
            if (file.Tag.Title != null && file.Tag.Title.Length > 0)
                title = file.Tag.Title;
            else
                title = fi.Name;
            artist = file.Tag.FirstPerformer;
            duration = String.Format("{0}:{1}:{2}",file.Properties.Duration.Hours.ToString("D2"),file.Properties.Duration.Minutes.ToString("D2"),file.Properties.Duration.Seconds.ToString("D2"));
            album = file.Tag.Album;
        }

        public string getFilePath()
        {
            return filePath;
        }
    }
}
