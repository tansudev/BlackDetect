

## Detecting black scene

#### What is it?

Project created from Asp.Net 5 Console App , Program run by "RunProgram.csproj" and processed and modeling by "VideoProcessingLibrary.csproj". In that project using a ffmpeg.exe file to detect black scene.

#### What is the [FFMPEG](https://ffmpeg.org/ "Go ffmpeg") ?

A complete, cross-platform solution to record, convert and stream audio and video. FFmpeg is the leading multimedia framework, able to decode, encode, transcode, mux, demux, stream, filter and play pretty much anything that humans and machines have created. It supports the most obscure ancient formats up to the cutting edge.

## Usage

1. first creating ProcessStartInfo to configurate the arguments. Detect video intervals that are (almost) completely black

* code:

_"-i videoName -vf blackdetect=d=0.5:pix_th=0.10 -f null |"_

- black_min_duration, d Set the minimum detected black duration expressed in seconds. It must be a non-negative floating point number.e 
- picture_black_ratio_th, pic_th Set the threshold for considering a picture "black". Express the minimum value for the ratio:
- There no out video so it must me put null 

2. Process start and execute the program.

3. Output data taken

* code:

_process.StandardError.ReadToEnd()

- datas taken as string with standarterror 

4. Splitting and converting output data to obtain more useful formats. Also written to text file to save.


## Contributing

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement". Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (git checkout -b feature/AmazingFeature)
3. Commit your Changes (git commit -m 'Add some AmazingFeature')
4. Push to the Branch (git push origin feature/AmazingFeature)
5. Open a Pull Request

## License

Distributed under the MIT License. See LICENSE.txt for more information.

## Contact

E-mail- tanslp07@gmail.com

Linkedn -[Tansu Deveciler](https://www.linkedin.com/in/pakize-tansu-deveciler-18b388136 "linkedn")


