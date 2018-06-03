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

        string stCurrentDir = System.IO.Directory.GetCurrentDirectory();
        public string commandFilePath { get; set; }
        public string inoPath { get; set; }
        public FileLoad()
        {
            Console.WriteLine(stCurrentDir+"にあるdirectry.txtファイルからディレクトリを読み込みます。");
            Console.WriteLine("ファイルが存在しない場合自動的に生成されます。");
            Console.WriteLine("生成後はプログラムを自動終了します。");
            TextLoad();
        }
        string GetDir()
        {
            return stCurrentDir;
        }
        void TextLoad()
        {
            try
            {
                Console.WriteLine("ファイルを読み込みます・・・");
                StreamReader streamreader = new StreamReader(stCurrentDir+@"\directry.txt",Encoding.GetEncoding("Shift_JIS"));
                stCurrentDir = streamreader.ReadLine();
                Console.WriteLine(stCurrentDir);
                commandFilePath = streamreader.ReadLine();
                Console.WriteLine(commandFilePath);
                inoPath = streamreader.ReadLine();
                Console.WriteLine(inoPath);
                streamreader.Close();
                Console.Write("読み込み完了");
            }
            catch(Exception e)
            {
                
                Console.WriteLine("ファイルの読み込みに失敗しました。"+e.Message);
                MakeFile();
                Environment.Exit(0);
            }

        }
        void MakeFile()
        {
            try
            {
                using (System.IO.FileStream hStream = System.IO.File.Create("directry.txt"))
                {

                    // 作成時に返される FileStream を利用して閉じる
                    if (hStream != null)
                    {
                        hStream.Close();
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            StreamWriter sw = new StreamWriter(stCurrentDir+"directry.txt",false, Encoding.GetEncoding("Shift_JIS"));
            sw.WriteLine(stCurrentDir);
            sw.WriteLine(stCurrentDir + @"\command.txt");
            sw.WriteLine(stCurrentDir + @"\switcher.ino");
            sw.Close();
            Console.WriteLine("ファイルを作成しました。 場所:"+stCurrentDir);

        }
            
    }
}
