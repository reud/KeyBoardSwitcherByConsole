using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyBoardSwitcherByConsole
{
    class FileLoad
    {

        string stCurrentDir = System.IO.Directory.GetCurrentDirectory();
        FileLoad()
        {
            Console.WriteLine(stCurrentDir+"にあるdirectry.txtファイルからディレクトリを読み込みます。");
            Console.WriteLine("ファイルが存在しない場合自動的に生成されます。");
            Console.WriteLine("生成後はプログラムを自動終了します。");
            TextLoad();
        }
        void TextLoad()
        {
            try
            {
                Console.WriteLine("ファイルを読み込みます・・・");
                StreamReader streamreader = new StreamReader("directry.txt", Encoding.GetEncoding("Shift_JIS"));
            }
            catch(Exception e)
            {
                Console.WriteLine("ファイルの読み込みに失敗しました。");
                MakeFile();
            }
        }
        void MakeFile()
        {
            using (System.IO.FileStream hStream = System.IO.File.Create("directry.txt"))
            {
                // 作成時に返される FileStream を利用して閉じる
                if (hStream != null)
                {
                    hStream.Close();
                }
            }
            Console.WriteLine("");
        }
            
    }
}
