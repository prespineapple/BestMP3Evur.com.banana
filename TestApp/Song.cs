using System;
using System.IO;

namespace TestApp
{
    class Song
    {

        private string name;
        private string artist;
        private string duration;
        private string album;
        public Song(String filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            TagLib.File file = TagLib.File.Create(filePath);
            if (file.Name != null && file.Name.Length > 0)
                name = file.Tag.Title;
            else
                name = fi.Name;
            artist = file.Tag.FirstArtist;
            duration = file.Properties.Duration.ToString();
            album = file.Tag.Album;
        }
    }
}
