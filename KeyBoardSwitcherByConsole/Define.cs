using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyBoardSwitcherByConsole
{
    public class Define
    {
        public String UserSetAs { get; }//get-only プロパティ
        public String IInputAs { get; }
        public String USBHex { get; } = "";
        public Define(String userSetAs,String iInputAs)
        {
            this.UserSetAs = userSetAs;
            this.IInputAs = iInputAs;
        }
        public Define(String userSetAs, String iInputAs,String USBHex)
        {
            this.UserSetAs = userSetAs;
            this.IInputAs = iInputAs;
            this.USBHex = USBHex;
        }
        public String OutputDefineLine()
        {
            if(this.USBHex.Equals(""))
            {
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
