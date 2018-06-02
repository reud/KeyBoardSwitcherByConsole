using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyBoardSwitcherByConsole
{
    public class FileLoad
    {
        public const String SPACE = " ";
        string stCurrentDir = System.IO.Directory.GetCurrentDirectory();
        public FileLoad()
        {
            Console.WriteLine(stCurrentDir+"にあるdirectry.txtファイルからディレクトリを読み込みます。");
            Console.WriteLine("ファイルが存在しない場合自動的に生成されます。");
            Console.WriteLine("生成後はプログラムを自動終了します。");
            stCurrentDir = TextLoad();
            Console.WriteLine("ファイルを読み込みました。");
            Console.WriteLine("作業ディレクトリは" + stCurrentDir);
            Console.WriteLine("となりました。");
            System.IO.Directory.SetCurrentDirectory(stCurrentDir);
            LoadAlgoFile();
        }
        String TextLoad()
        {
            StreamReader streamreader;
            try
            {
                Console.WriteLine("ファイルを読み込みます・・・");
                streamreader = new StreamReader("directry.txt", Encoding.GetEncoding("Shift_JIS"));
            }
            catch(Exception e)
            {
                Console.WriteLine("ファイルの読み込みに失敗しました。");
                Console.WriteLine("ファイルを作成致します");
                streamreader = MakeFile();
            }

            return streamreader.ReadLine();
        }
        StreamReader MakeFile()
        {
            using (System.IO.FileStream hStream = System.IO.File.Create("directry.txt"))
            {
                // 作成時に返される FileStream を利用して閉じる
                if (hStream != null)
                {
                    hStream.Close();
                }
            }
            Console.WriteLine("作成したファイルを読み込みます・・・");
            StreamWriter streamWriter = new StreamWriter("directry.txt",false, Encoding.GetEncoding("Shift_JIS"));
            Console.WriteLine("現在のカレントディレクトリをdirectry.txtに記入します。");
            streamWriter.WriteLine(stCurrentDir);
            streamWriter.Close();
            Console.WriteLine("ファイルを書き込みました");
            Console.WriteLine("ファイルを読み込みます・・・");
            StreamReader streamreader= new StreamReader("directry.txt", Encoding.GetEncoding("Shift_JIS"));
            return streamreader;
        }
        void LoadAlgoFile()
        {
            Console.WriteLine("手続きファイルを読み込みます");

        }
            
    }
}
