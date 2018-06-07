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
        Procedure procedure;
        public Writer(string path,Procedure cmdPath)
        {
            this.path = path;
            System.Diagnostics.Process.Start(path);
            Thread.Sleep(20000);
            GetBlank();
            //HeloWorld();
            this.procedure = cmdPath;
            Write();
        }
        void GetBlank()
        {

            Console.WriteLine("deleting");
            for (int i = 0; i < 100; ++i)
            {
                SendKeys.SendWait("{DOWN}");
            }
            for (int i = 0; i < 10; ++i)
            {
                SendKeys.SendWait("{RIGHT}");
            }
            for (int i = 0; i < 3000; ++i)
            {
                SendKeys.SendWait("{BS}");
            }
            Console.WriteLine("deleted");
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
            SenE("#include <DigiKeyboard.h>");
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
            SenE("if{(}digitalRead{(}key1{)} == LOW && digitalRead{(}key2{)} == LOW && digitalRead{(}key3{)} == LOW{)}{{}");
            SenE("state = false;{}}");
            //ここから下に機能を書く
            ButtonWrite(1, procedure.key1);
            ButtonWrite(2, procedure.key2);
            ButtonWrite(3, procedure.key3);
            //機能を書くのはここまで
            SenE("else {{}");
            SenE("state = true;");
            SenE("{}}");
            SenE("DigiKeyboard.delay{(}10{)};");
            SenE("//2018.04.08 Firmware for Extension Keyboard powered by DigiSpark USB Development Board");
            SenE("//Written by Atsushi Kambayashi All Rights Reserved.");
            SendKeys.SendWait("{DOWN}");
            SendKeys.SendWait("{DOWN}");
            SendKeys.SendWait("{DOWN}");
            SendKeys.SendWait("{DOWN}");
            SendKeys.SendWait("{DOWN}");
            SendKeys.SendWait("{DOWN}");
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{BS}");
            SendKeys.SendWait("{BS}");
            SendKeys.SendWait("{BS}");
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{BS}");
            SendKeys.SendWait("{BS}");
            SendKeys.SendWait("{BS}");

        }
        void ButtonWrite(int key,KeyEvent keyEvent)
        {
            Console.WriteLine("key" + key.ToString() + "について書き込みます。");
            keyEvent.Show();
            SenE("else if{(}digitalRead{(}key" + key.ToString() + "{)}==HIGH{)}{{}");
            SenE("DigiKeyboard.delay{(}10{)};");
            SenE("if{(}!state{)}{{}");
            SenE("DigiKeyboard.update{(}{)};");
            int s = keyEvent.GetSize();
            for (int i=0;i<s;++i)
            {
                SenE(keyEvent.GetLine(i));
                SenE("DigiKeyboard.delay{(}200{)};");
            }
            SenE("state=true;");
            SenE("{}}");
            SenE("{}}");
            Console.WriteLine("書き込みは終了しました。");
        }
        void SenE(string s)
        {
            SendKeys.SendWait(s);
            SendKeys.SendWait("{ENTER}");

        }
    }
}
