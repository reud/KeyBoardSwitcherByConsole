using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyBoardSwitcherByConsole
{
    public class Define
    {
        public string UserSetAs { get; }//get-only プロパティ
        public string IInputAs { get; }
        public string USBHex { get; } = "";
        public Define(string userSetAs,string iInputAs)
        {
            this.UserSetAs = userSetAs;
            this.IInputAs = iInputAs;
        }
        public Define(string userSetAs, string iInputAs,string USBHex)
        {
            this.UserSetAs = userSetAs;
            this.IInputAs = iInputAs;
            this.USBHex = USBHex;
        }
        public string OutputDefineLine()
        {
            if(this.USBHex.Equals(""))
            {
                Console.WriteLine("You dont have to define this parameter");
                throw new ArgumentNullException();
            }
            else
            {
                return "#define " + this.IInputAs + " " + this.USBHex;
            }
        }
        public bool CheckIsHaveUSBHex()
        {
            if (this.USBHex.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
