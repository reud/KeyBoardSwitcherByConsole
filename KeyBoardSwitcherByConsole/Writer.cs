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
            Thread.Sleep(20000);
            //GetBlank();
            //HeloWorld();
            Write();
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
            SenE("void setup{(}{)}{{}");
            SenE("Serial.begin{(}9600{)};");
            SenE("{}}");
            SenE("void loop{(}{)}{{}");
            SenE("Serial.println{(}\"Hello, World\"{)};");
            //SenE("{}}");
        }
        void Write()//実際はProcedure pを引数にとってほしい}

        {
            SenE("#include <Digikeyboard.h>");
            SenE("");//この辺でDefineをしとく
            SenE("const int key1 = 1;");
            SenE("const int key2 = 0;");
            SenE("const int key3 = 2;");
            SenE("bool state = false;");
            SenE("void setup{(}{)} {{}");
            SenE("pinMode{(}key1,INPUT{)};");
            SenE("pinMode{(}key2,INPUT{)};");
            SenE("pinMode{(}key3,INPUT{)};");
            SenE("{}}");
            SenE("void loop{(}{)}{{}");
            SenE("if{(}digitalRead{(}Key1{)} == LOW && digitalRead{(}Key2{)} == LOW && digitalRead{(}Key3{)} == LOW {{}");
            SenE("state = false;{}}");
            //ここから下に機能を書く

            //機能を書くのはここまで
            SenE("else {{}");
            SenE("state = true;");
            SenE("{}}");
            SenE("DigiKeyboard.delay{(}10{)};");
            SenE("//2018.04.08 Firmware for Extension Keyboard powered by DigiSpark USB Development Board");
            SenE("//Written by Atsushi Kambayashi All Rights Reserved.");
        }
        void ButtonWrite(int key,KeyEvent keyEvent)
        {

        }
        void SenE(string s)
        {
            SendKeys.SendWait(s);
            SendKeys.SendWait("{ENTER}");

        }
    }
}
