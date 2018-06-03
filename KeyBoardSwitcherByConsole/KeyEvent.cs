using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyBoardSwitcherByConsole
{
    class KeyEvent
    {
        List<string> keyList = new List<string>();
        public KeyEvent(string path)
        {
            StreamReader streamreader = new StreamReader(path, Encoding.GetEncoding("Shift_JIS"));
            string tmp=streamreader.ReadLine();
            while(!(tmp.Equals("")))
            {
                keyList.Add(tmp);
            }
        }
    }
}
