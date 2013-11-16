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
<<<<<<< HEAD
            if (file.Name != null && file.Name.Length > 0)
                name = file.Tag.Title;
            else
                name = fi.Name;
            artist = file.Tag.FirstArtist;
            duration = file.Properties.Duration.ToString();
            album = file.Tag.Album;
=======
            
>>>>>>> 0cb483aae5e9abc52ce065572b3b3bdc9b278d83
        }
    }
}
