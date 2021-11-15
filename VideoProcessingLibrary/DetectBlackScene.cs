using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoProcessingLibrary.Model;

namespace VideoProcessingLibrary
{
    public class DetectBlackScene
    {
        /// <summary>
        /// Necessary configurations are made for the ffmpeg.exe file to work.
        /// </summary>
        /// <param name="videoName">video name to be processed</param>
        /// <returns> return type "ProcessStartInfo" </returns>
        public ProcessStartInfo DetectBlackInfo(string videoName,string path)
        {
            //videoName = "Film_burn_pack.mov";

            var startInfo = new ProcessStartInfo
            {
                FileName = path +@"\ffmpeg.exe",
                Arguments = $@"-i {videoName} -vf blackdetect=d=0.5:pix_th=0.10 -f null |",
                WorkingDirectory = path,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
            };
            return startInfo;
        }

        /// <summary>
        /// starts black detect process 
        /// </summary>
        /// <param name="videoName"></param>
        /// <returns>video name to be processed</returns>
        public VideosInfo DetectBlack(string videoName, string textpath)
        {
            try
            {
                string processOutput = null;
                string[] BlackScenes = { "" };
                OutputData outputData = new();
                VideosInfo videosInfo = new();
                //if it wanted to be used middle of process it can used with Task
                //var task = Task.Run(() =>
                //{

                using var process = new Process { StartInfo = DetectBlackInfo(videoName,textpath ) };
                process.Start();

                processOutput = process.StandardError.ReadToEnd();

                if (processOutput != null)
                {
                    //Console.WriteLine(processOutput);
                                        
                    videosInfo = outputData.SplitData(processOutput);                   

                }
                process.WaitForExit();
                return videosInfo;

                // });


            }
            catch (Exception)
            {
                throw;
            }
        }







    }
}
