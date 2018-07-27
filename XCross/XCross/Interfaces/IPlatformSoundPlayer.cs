using System;
using System.Collections.Generic;
using System.Text;

namespace XCross.Interfaces
{
    interface IPlatformSoundPlayer
    {
        void PlaySound(int samplingRate, byte[] pcmData);
    }
}
