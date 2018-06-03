using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyBoardSwitcherByConsole
{
    class Writer
    {
        string path;
        public Writer(string path)
        {
            this.path = path;
            System.Diagnostics.Process.Start(path);
            Thread.Sleep(10000);
            //GetBlank();
            HeloWorld();
        }
        void GetBlank()
        {
            
            
            for (int i = 0; i < 100; ++i)
            {
                SendKeys.SendWait("{DOWN}");
            }
            for (int i = 0; i < 3000; ++i)
            {
                SendKeys.SendWait("{BS}");
            }
        }
        void HeloWorld()
        {
            SenE("void setup(){{}");
            SenE("Serial.begin{(}9600{)};");
            SenE("{}}");
            SenE("void loop(){{}");
            SenE("Serial.println{(}\"Hello, World\"{)};");
            //SenE("{}}");




        }
        void SenE(string s)
        {
            SendKeys.SendWait(s);
            SendKeys.SendWait("{ENTER}");

        }
    }
}
