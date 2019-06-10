using System;
using System.Collections.Generic;
using System.Linq;
using NAudio.Wave;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SoundBoard
{
    public class AudioStream
    {
        public int ButtonTab;
        public int ButtonIndex;
        public string ButtonName;
        public string ButtonSoundFile;
        public Boolean ButtonSoundRepeat;
        public Boolean ButtonCustomTime;
        public int ButtonTimeStart;
        public int ButtonTimeEnd;
    }

    class AudioPlayer
    {
        private MainApp mainApp;

        private static List<AudioStream> audioStreamList = new List<AudioStream>();
        private static List<WaveOutEvent> wavePlayer = new List<WaveOutEvent>();
        private static List<AudioFileReader> audioFileReader = new List<AudioFileReader>();

        public AudioPlayer()
        {

        }

        public void AddNewAudioStream(AudioStream audioStream, MainApp mainAppReference)
        {
            mainApp = mainAppReference;

            int removeIndex = -1;
            for (int i = 0; i < audioStreamList.Count; i++)
            {
                if (audioStreamList[i].ButtonName == audioStream.ButtonName)
                {
                    removeIndex = i;
                }
            }

            if (removeIndex != -1)
            {
                Console.WriteLine("AudioPlayer forced stop Song: " + Path.GetFileNameWithoutExtension(audioStream.ButtonSoundFile));
                RemoveAudioStream(removeIndex);
            }
            else
            {
                if (audioStream.ButtonSoundFile == null || audioStream.ButtonSoundFile == "default")
                {
                    return;
                }

                if (audioStreamList.Count >= 10)
                {
                    RemoveAudioStream(0);
                }

                audioStreamList.Add(audioStream);

                mainApp.SetButtonImage(audioStream.ButtonTab, audioStream.ButtonIndex);

                audioFileReader.Add(new AudioFileReader(audioStream.ButtonSoundFile));
                wavePlayer.Add(null);

                if (audioFileReader[audioFileReader.Count - 1].CanRead && audioFileReader[audioFileReader.Count - 1].TotalTime.TotalMinutes < 60)
                {
                    Console.WriteLine("AudioPlayer play Button: " + audioStream.ButtonName + "play Song: " + Path.GetFileNameWithoutExtension(audioStream.ButtonSoundFile));

                    wavePlayer[audioFileReader.Count - 1] = new WaveOutEvent();
                    wavePlayer[audioFileReader.Count - 1].PlaybackStopped += (sender, e) => OnPlaybackStopped(sender, e, audioStream);

                    wavePlayer[audioFileReader.Count - 1].Init(audioFileReader[audioFileReader.Count - 1]);
                    wavePlayer[audioFileReader.Count - 1].Play();
                }
            }
        }

        private void RemoveAudioStream(int index)
        {
            AudioStream removeStream = audioStreamList.ElementAt(index);
            audioStreamList.RemoveAt(index);

            wavePlayer[index]?.Dispose();
            audioFileReader[index]?.Dispose();

            wavePlayer.RemoveAt(index);
            audioFileReader.RemoveAt(index);

            mainApp.RemoveButtonImage(removeStream.ButtonTab, removeStream.ButtonIndex);
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e, AudioStream removeAudioStream)
        {
            Console.WriteLine("AudioPlayer stop Song: " + Path.GetFileNameWithoutExtension(removeAudioStream.ButtonSoundFile));

            int removeIndex = audioStreamList.IndexOf(removeAudioStream);

            if (removeIndex == -1)
            {
                return;
            }

            Boolean repeat = audioStreamList[removeIndex].ButtonSoundRepeat;
            RemoveAudioStream(removeIndex);

            if (repeat)
            {
                AddNewAudioStream(removeAudioStream, mainApp);
            }
        }
    }
}
