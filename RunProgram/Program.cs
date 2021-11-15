using System;
using VideoProcessingLibrary;
using VideoProcessingLibrary.Model;

namespace RunProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            DetectBlackScene detectBlackScene = new DetectBlackScene();

            Console.WriteLine("Hello World!");

            string filePath = @"C:\Users\user\source\repos\BlackDetectProcess\RunProgram\SourceFile";

            //find all videos inside thr folder
            string[] videos = CallVideos.TakeVideoFromFile(filePath);

            for (int i = 0; i < videos.Length; i++)
            {
               Console.WriteLine(videos[i]);

               //detect black scenes and 
                VideosInfo videosInfo = detectBlackScene.DetectBlack(videos[i],filePath);


                OutputData outputData = new();
                outputData.SaveInText(videosInfo, filePath);
            }

            Console.WriteLine("Process Done");
            Console.ReadLine();
        }
    }
}
