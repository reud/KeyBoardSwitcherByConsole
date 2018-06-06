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
            var fl = new FileLoad();
            var p = new Procedure(fl.commandFilePath);
            var w = new Writer(fl.inoPath,p);
            

        }
    }
}
