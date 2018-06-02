using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace KeyBoardSwitcherByConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Process.Start(@"C:\Users\reud\Dropbox\WorkSpace\Arduino\sketch_may08a\sketch_may08a.ino");
            Thread.Sleep(20000);
            //Microsoft.VisualBasic.Interaction.AppActivate("Arduino");
            for(int i=0;i<100;++i)
            {
                SendKeys.SendWait("{DOWN}");
            }
            for (int i = 0; i < 3000; ++i)
            {
                SendKeys.SendWait("{BS}");
            }
            SendKeys.SendWait("test");

        }
    }
}
