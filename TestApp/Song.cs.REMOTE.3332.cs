using System;

namespace TestApp
{
    class Song
    {
        public Song(String filePath)
        {
            TagLib.File file = TagLib.File.Create(filePath);
            
        }
    }
}
