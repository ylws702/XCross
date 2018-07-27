using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.MediaProperties;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using XCross.Interfaces;

[assembly: Dependency(typeof(XCross.UWP.PlatformSoundPlayer))]
namespace XCross.UWP
{
    public class PlatformSoundPlayer : IPlatformSoundPlayer
    {
        SharedSoundPlayer sharedSoundPlayer;
        
        public void PlaySound(int samplingRate,byte[] pcmData)
        {
            if (sharedSoundPlayer==null)
            {
                sharedSoundPlayer = new SharedSoundPlayer();
            }
            sharedSoundPlayer.PlaySound(samplingRate, pcmData);
        }
        
    }
    class SharedSoundPlayer
    {

        MediaElement mediaElement = new MediaElement();
        //TimeSpan duration;
        public void PlaySound(int samplingRate, byte[] pcmData)
        {
            AudioEncodingProperties audioEncodingProperties =
                AudioEncodingProperties.CreatePcm((uint)samplingRate, 1, 16);
            AudioStreamDescriptor audioStreamDescriptor =
                new AudioStreamDescriptor(audioEncodingProperties);
            MediaStreamSource mediaStreamSource =
                new MediaStreamSource(audioStreamDescriptor);

            bool samplePlayed = false;
            mediaStreamSource.SampleRequested += (sender, args) =>
              {
                  if (samplePlayed)
                  {
                      return;
                  }
                  IBuffer buffer = pcmData.AsBuffer();
                  MediaStreamSample mediaStreamSample =
                  MediaStreamSample.CreateFromBuffer(buffer, TimeSpan.Zero);
                  mediaStreamSample.Duration =
                  TimeSpan.FromSeconds(pcmData.Length / 2.0 / samplingRate);
                  args.Request.Sample = mediaStreamSample;
                  samplePlayed = true;
              };
            mediaElement.SetMediaStreamSource(mediaStreamSource);
        }
    }
}
