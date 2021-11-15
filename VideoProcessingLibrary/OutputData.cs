using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoProcessingLibrary.Model;

namespace VideoProcessingLibrary
{
    public class OutputData
    {
        public VideosInfo SplitData(string data)
        {           
            string[] lines = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            VideosInfo videosInfo = new();
            List<BlackTime> listedBlackTime = new();

            //The lines starting with "[black detective] and "Input" are transferred to the model by reading the entire array            

            if (data != null)
            {
                //Console.WriteLine(processOutput);

                string[] liness = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (var line in liness)
                    if (line.Contains("[blackdetect"))
                    {
                        BlackTime blackTime = new();

                        //Console.WriteLine(line);
                        string[] blackScene = line.Split(' ');

                        foreach (var item in blackScene)
                        {
                            
                            if (item.Contains("start"))
                            {                                
                                blackTime.Black_Start = item.Substring(12, item.Length - 12);

                            }
                            else if (item.Contains("end"))
                            {
                                blackTime.Black_End = item.Substring(10, item.Length - 10);
                                
                            }
                            else if (item.Contains("duration"))
                            {
                                blackTime.Black_Duration = item.Substring(15, item.Length - 15);                                
                            }                            
                        }
                        listedBlackTime.Add(blackTime);
                    }
                    else if (line.Contains("Input"))
                    {
                        int index = line.LastIndexOf('\\');
                        int pointindex = line.LastIndexOf('.');
                        videosInfo.VideoName = line.Substring(index + 1, pointindex - index - 1);
                        
                    }
                    else if (line.Contains("Duration:"))
                    {
                        videosInfo.VideoLenght =  line.Substring(12, line.IndexOf(',') - 12);
                        
                    }

                videosInfo.BlackTimes = listedBlackTime;
                return videosInfo;
            }

            return new VideosInfo();
        }


        /// <summary>
        /// Gelen değerleri txt varsa dosyaya kayıt eder.dosya yoksa dosya oluşturup öyle kayıt yapar.
        /// </summary>
        /// <param name="line">kayıt edilmek istenen değerler</param>
        public void SaveInText(VideosInfo videosInfo,string txtPath)
        {
            txtPath += @"\Output.txt";
            string text = "";
            if (videosInfo != null)
            {
                text += "Video Name :" + videosInfo.VideoName + "\n"; 
                text += "Video Duration :" + videosInfo.VideoLenght + "\n";               
                text += "Video Black Scene number :" + videosInfo.BlackTimes.Count()+ "\n";
                text += Environment.NewLine;
                int i = 1;
                foreach (var item in videosInfo.BlackTimes)
                {
                    text += "Black scenes " + i + "\n" ;
                    text += "Black start :" + item.Black_Start +"\n";
                    text += "Black end :" + item.Black_End + "\n";
                    text += "Black duration :" + item.Black_Duration + "\n";
                    text += Environment.NewLine;
                    i++;
                }

                i = 1;
                text += "**********************************";
            }


            if (!File.Exists(txtPath))
            {
                // Create a file to write to.
                using StreamWriter sw = File.CreateText(txtPath);
                sw.WriteLine(text);                
            }
            else
            {
                //add in to file
                using (StreamWriter sw = File.AppendText(txtPath))
                {
                    sw.WriteLine(text);
                   
                }
            }
        }

        

    }
}
