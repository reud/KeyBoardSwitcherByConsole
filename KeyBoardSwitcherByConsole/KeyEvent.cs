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
        List<string> file;
        public KeyEvent(List<string> file)
        {
            this.file = file;
            //CheckNeedDefineLine
        }
        public int GetSize()
        {
            return file.Capacity;
        }
        public List<string> GetDefineLine()
        {
            var box = new DefineBox();
            var commands = new List<string>();
            for (int m=0;m<file.Capacity;++m)
            {
                commands.AddRange(file[m].Split('+'));                
            }
            for(int s=0;s<commands.Capacity;++s)//重複要素を削除する。
            {
                for(int r=(1+s);r<commands.Capacity;++r)
                {
                    if(commands)
                }
            }
            
        }
        public string GetLine(int i)
        {
            Console.WriteLine("ReadLine:" + file[i]);
            if(file[i].IndexOf("/string/")!=(-1))//arudinoに打ち込む形式で出力する。
            {
                file[i].Replace("/string/", "");
                return "DigiKeyboard.print(\""+file[i]+"\");";
            }
            else
            {
                var box = new DefineBox();
                //同時入力を識別します。
                string[] command = file[i].Split('+');//+で区切る
                var list2 = new List<string>();
                list2.AddRange(command);

                if(list2.Capacity>1)//もしリストの要素が2以上すなわち同時押しがあるなら
                {
                    for(int s=0;s<(list2.Capacity-1);++s)//+の復元作業
                    {
                        list2[s + 1] = "+" + list2[s + 1];//
                    }
                }
                var ret = "";
                var words = 0;
                for(int s=0;s<box.KeySwitch.Capacity;++s)//出力する文字列をここから作成
                {
                    for (int t = 0; t < list2.Capacity; ++t)
                    {
                        if (list2[t].Equals(box.KeySwitch[s].UserSetAs))
                        {
                            if (words == 0)
                            {
                                ++words;
                                ret += box.KeySwitch[s].IInputAs;
                            }
                            else if (words == 1)
                            {
                                ++words;
                                ret += ",";
                                ret += box.KeySwitch[s].IInputAs;
                            }
                            else
                            {
                                ret += " | ";
                                ret += box.KeySwitch[s].IInputAs;
                            }
                        }
                    }
                }
                if(words==0)
                {
                    Console.WriteLine("読み込んだ情報がおかしいです。");
                    Console.WriteLine(ret);
                    throw new FileNotFoundException();
                }

                Console.WriteLine("読み込んだret=" + ret);
                return "DigiKeyboard.sendKeyStroke(\"" + ret + "\");";
            }
        }
    }
}
