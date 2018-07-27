using System;
using System.Collections.Generic;
using System.Text;

namespace XCross
{
    interface IPlatformInfo
    {
        string GetModel();

        string GetVersion();
    }
}
