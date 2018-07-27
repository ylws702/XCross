using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XCross.Interfaces;

namespace XCross
{
    class Test2Page:Test1Page
    {
        readonly int errorDuration = 500;
        readonly double[] frequencies = { 523.25, 622.25, 739.99, 880.00 };
        protected override void FlashBoxView(int index)
        {
            SoundPlayer.PlaySound(frequencies[index], flashDuration);
            base.FlashBoxView(index);
        }
        protected override void EndGame()
        {
            SoundPlayer.PlaySound(65.4, errorDuration);
            base.EndGame();
        }
    }
    static class SoundPlayer
    {
        const int samplingRate = 22050;
        public static void PlaySound(double frequency=440,int duration=250)
        {
            short[] shortBuffer = new short[samplingRate * duration / 1000];
            double angleIncrement = frequency / samplingRate;
            double angle = 0;
            for (int i = 0; i < shortBuffer.Length; i++)
            {
                double sample;
                if (angle<0.25)
                {
                    sample = 4 * angle;
                }
                else if (angle<0.75)
                {
                    sample = 4 * (0.5 - angle);
                }
                else
                {
                    sample = 4 * (angle - 1);
                }
                shortBuffer[i] = (short)(32767* sample);
                angle += angleIncrement;
                while (angle>1)
                {
                    angle -= 1;
                }
            }
            byte[] byteBuffer = new byte[2 * shortBuffer.Length];
            Buffer.BlockCopy(shortBuffer, 0, byteBuffer, 0, byteBuffer.Length);
            DependencyService.Get<IPlatformSoundPlayer>().PlaySound(samplingRate, byteBuffer);
        }
    }
}
