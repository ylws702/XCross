using System;

using Android.Media;
using Android.OS;
using Xamarin.Forms;
using XCross.Interfaces;

[assembly: Dependency(typeof(XCross.Droid.PlatformSoundPlayer))]
namespace XCross.Droid
{
    class PlatformSoundPlayer : IPlatformSoundPlayer
    {
        AudioTrack previousAudioTrack;
        public void PlaySound(int samplingRate, byte[] pcmData)
        {
            if (previousAudioTrack != null)
            {
                previousAudioTrack.Stop();
                previousAudioTrack.Release();
            }
            AudioTrack audioTrack = new AudioTrack(Stream.Music,
                samplingRate, 
                ChannelOut.Mono,
                Encoding.Pcm16bit,
                pcmData.Length * sizeof(short),
                AudioTrackMode.Static);
            audioTrack.Write(pcmData, 0, pcmData.Length);
            audioTrack.Play();
            previousAudioTrack = audioTrack;
        }
    }
}