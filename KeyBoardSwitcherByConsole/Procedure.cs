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
        public KeyEvent key1;
        public KeyEvent key2;
        public KeyEvent key3;
        public Procedure(string path)
        {
            Console.WriteLine(path);
            StreamReader streamreader = new StreamReader(path+@"\command.txt", Encoding.GetEncoding("Shift_JIS"));
            string tmp = streamreader.ReadLine();
            while (!(tmp==null))
            {
                Console.WriteLine(tmp);
                keyList.Add(tmp);
                tmp = streamreader.ReadLine();

            }
            //ここから分割する
            // /key1/って感じに書き出してクレメンス
            if(!(keyList[0].Equals("/key1/")))
            {
                Console.WriteLine("/key1/が見当たらないです。");
                throw new FieldAccessException();
            }
            else
            {
                int a = 1;
                var pressArg = new List<string>();
                while(!(keyList[a].Equals("/key2/")))
                {
                    Console.WriteLine("現在のListは:"+pressArg);
                    Console.WriteLine("key1=" + keyList[a] + "a=" + a.ToString());
                    pressArg.Add(keyList[a]);
                    ++a;
                }
                key1 = new KeyEvent(pressArg);
                ++a;
                var pressArg2 = new List<string>();

                while (!(keyList[a].Equals("/key3/")))
                {
                    pressArg2.Add(keyList[a]);
                    Console.WriteLine("key2=" + keyList[a]+"a="+a.ToString());
                    ++a;
                }
                key2 = new KeyEvent(pressArg2);
                ++a;
                var switcher = true;
                var pressArg3 = new List<string>();

                while (switcher)
                {
                    
                    try
                    {
                        pressArg3.Add(keyList[a]);
                        Console.WriteLine("key3="+keyList[a] + "a=" + a.ToString());
                    }
                    catch
                    {
                        switcher = false;
                    }
                    ++a;
                }
                key3 = new KeyEvent(pressArg3);
                Console.WriteLine("作成したKeyEventsについて確認します。");
                key1.Show();
                key2.Show();
                key3.Show();

            }
        }
    }
}
