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
        int commandsN=0;

        public KeyEvent(List<string> file)
        {
            this.file = file;
            Console.WriteLine("インスタンスを作成しました。");
            for(int i=0;i<file.Count;++i)
            {
                Console.WriteLine("要素" + i.ToString() + ":" + file[i]);
            }
            //CheckNeedDefineLine
        }
        public void Show()
        {
            for (int i = 0; i < file.Count; ++i)
            {
                Console.WriteLine("Show関数です。要素" + i.ToString() + ":" + file[i]);
            }
        }
        public int GetSize()
        {
            return file.Count;
        }
        public List<string> GetDefineLine()
        {
            var box = new DefineBox();
            var commands = new List<string>();
            var tmp = new List<string>();
            for (int m=0;m<file.Capacity;++m)
            {
                tmp.AddRange(file[m].Split('+'));
                if(tmp.Capacity>1)
                {
                    for(int t=1;t<tmp.Capacity;++t)
                    {
                        tmp[t] = "+" + tmp[t];
                    }
                }
                commands.AddRange(tmp);
                tmp.Clear();
            }

            for(int s=0;s<commands.Capacity;++s)//重複要素を削除する。
            {
                for(int r=(1+s);r<commands.Capacity;++r)
                {
                    if(commands[r].Equals(commands[s]))
                    {
                        commands.RemoveAt(r);
                    }
                }
            }
            //ここからHexを持つワードを探す。
            var ret = new List<string>();
            for(int s=0;s<commands.Capacity;++s)
            {
                for(int i=0;i<box.KeySwitch.Capacity;++i)
                {
                    if(commands[s].Equals(box.KeySwitch[i]))
                    {
                        if(box.KeySwitch[i].CheckIsHaveUSBHex())
                        {
                            ret.Add("#define " + box.KeySwitch[i].IInputAs + " " + box.KeySwitch[i].USBHex);
                        }
                    }
                }
            }
            return ret;
        }
        public string GetLine(int i)
        {
            Console.WriteLine("KeyEvents.GetLineでの現在のリスト:");
            for (int s = 0; s< file.Count; ++s)
            {
                Console.WriteLine("要素" + i.ToString() + ":" + file[s]);
            }
            Console.WriteLine("ReadLine:" + file[i]);
            if(file[i].IndexOf("/string/")!=(-1))//arudinoに打ち込む形式で出力する。
            {
                
                file[i]=file[i].Replace("/string/", "");
                Console.WriteLine("文字列:" + file[i]);
                return "DigiKeyboard.print{(}\""+file[i]+"\"{)};";
            }
            else
            {
                var box = new DefineBox();
                //同時入力を識別します。
                string[] command = file[i].Split('+');//+で区切る
                commandsN = command.Length;
                Console.WriteLine("KeyEventのGetLineでの要素はこれらです");
                for(i=0;i<command.Length;++i)
                {
                    Console.WriteLine(command[i]);
                }
                var list2 = new List<string>();
                list2.AddRange(command);

                if(command.Length > 1)//もしリストの要素が2以上すなわち同時押しがあるなら
                {
                    Console.WriteLine(command.Length + "が重さ");
                    for(int s=1;s<(command.Length);++s)//+の復元作業
                    {
                        Console.WriteLine("s:"+s.ToString()+"s=" + s.ToString() + ":" + list2[s]);
                        list2[s] = "+" + list2[s];//
                    }
                }
                var ret = "";
                var words = 0;
                for(int s=0;s< box.KeySwitch.Count; ++s)//出力する文字列をここから作成
                {
                    for (int t = 0; t <command.Length ; ++t)
                    {
                        if (list2[t].Equals(box.KeySwitch[s].UserSetAs))
                        {
                            Console.WriteLine("正当なWordでした！");
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
                return "DigiKeyboard.sendKeyStroke{(}\"" + ret + "\"{)};";
            }
        }
    }
}
