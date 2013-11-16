using System;
using System.IO;

namespace TestApp
{
    class Song
    {

        private string title;
        private string artist;
        private string duration;
        private string album;
        public Song(String filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            TagLib.File file = TagLib.File.Create(filePath);
            if (file.Name != null && file.Name.Length > 0)
                title = file.Tag.Title;
            else
                title = fi.Name;
            artist = file.Tag.FirstArtist;
            duration = file.Properties.Duration.ToString();
            album = file.Tag.Album;
        }
    }
}
