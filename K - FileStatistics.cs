using System;
using System.Collections.Generic;
using System.Linq;

class Solution {
    public int solution(String S) {
        /*
        S = @"my.song.mp3 11b
greatSong.flac 1000b
not3.txt 5b
video.mp4 200b
game.exe 100b
mov!e.mkv 10000b";
        */
        string[] strTemp = S.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        string ext;
        int music = 0, image = 0, movie = 0, other = 0, sp, dot, bytes;

        foreach (string line in strTemp)
        {
            sp = line.IndexOf(" ");
            dot = line.LastIndexOf(".", sp);
            ext = line.Substring(dot + 1, sp - dot - 1);
            bytes = Int32.Parse(line.Substring(sp + 1, line.Length - sp - 2));

            if (ext == "mp3" || ext == "aac" || ext == "flac") 
            {
                music += bytes;
            }
            else if (ext == "jpg" || ext == "bmp" || ext == "gif") 
            {
                image += bytes;
            }
            else if (ext == "mp4" || ext == "avi" || ext == "mkv") 
            {
                movie += bytes;
            }
            else
            {
                other += bytes;
            }
        }

        string result = "music " + music + "b\n" + "image " + image + "b\n" + "movie " + movie + "b\n" + "other " + other + "b\n";
        return result;
    }
}
