using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoProcessingLibrary
{
    public static class CallVideos
    {
        //video formats
        static string[] mediaExtensions = {".PNG", ".JPG", ".JPEG", ".BMP", ".GIF", ".WAV", ".MID", ".MIDI", ".WMA", ".MP3", ".OGG", ".RMA", ".AVI", ".MP4", ".DIVX", ".WMV", ".MOV", ".FLV" };

        /// <summary>
        /// selects video from file that given the root
        /// </summary>
        /// <param name="fileRoot">file root/map</param>
        /// <returns>array that consist of video names</returns>
        public static string[] TakeVideoFromFile(string fileRoot)
        {
            try
            {
                if (!string.IsNullOrEmpty(fileRoot))
                {
                    string[] file = Directory.GetFiles(fileRoot);

                    List<string> videos = new List<string>();

                    foreach( string s in file)
                    {
                        if (IsVideoFiles(s))
                        {
                            videos.Add(s);
                        }
                    }
                    return videos.ToArray();
                }
                else
                {
                    string[] videosName = { "" };
                    return videosName;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        //checks if item is video
        public static bool IsVideoFiles(string fileName)
        {
            return -1 != Array.IndexOf(mediaExtensions, Path.GetExtension(fileName).ToUpperInvariant());
        }
    }
}
