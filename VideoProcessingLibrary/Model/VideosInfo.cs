using System.Collections.Generic;

namespace VideoProcessingLibrary.Model
{
    public class VideosInfo
    {
        public bool DetectedBlack { get; set; }

        public string VideoName { get; set; }

        public List<BlackTime> BlackTimes { get; set; }

        public string VideoLenght { get; set; }
    }
   
}
