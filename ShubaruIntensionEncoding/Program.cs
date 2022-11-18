using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using OperationBlueThunderBird.FakeBlueScreen;

namespace OperationBlueThunderBird;
internal class Program
{
    public static void Main()
    {
        FakeBsod.Run(true);
    }
}