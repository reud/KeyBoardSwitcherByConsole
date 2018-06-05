using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyBoardSwitcherByConsole
{
    class Procedure//3つのKeyEventを合わせる
    {
        List<string> keyList = new List<string>();
        public Procedure(string path)
        {
            StreamReader streamreader = new StreamReader(path, Encoding.GetEncoding("Shift_JIS"));
            string tmp = streamreader.ReadLine();
            while (!(tmp.Equals("")))
            {
                keyList.Add(tmp);
            }
            for(int i=0;i<keyList.Capacity;++i)
            {
                Console.WriteLine(keyList[i]);

            }
        }
    }
}
