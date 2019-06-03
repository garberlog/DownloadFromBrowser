using System;
using System.IO;
using System.Text.RegularExpressions;

namespace DownloadFromBrowser {
    class Program {
        static void Main(string[] args) {
            //location to save files to
            string filepath = "C:\\Users\\Logan\\Downloads" + "\\";

            //just checks to prevent crashes
            if (args.Length > 0) {
                //gets the file name
                int pos = args[0].LastIndexOf('\\');
                string filename = args[0].Substring(pos + 1);

                //gets the file extension (if exists)
                string fileExt = "";
                pos = filename.IndexOf('.');
                if (pos != -1) {
                    fileExt = filename.Substring(pos);
                    filename = filename.Substring(0, pos);
                }


                //puts file together without extension
                filepath += filename;

                //makes sure it has a unique name
                while (File.Exists(filepath + fileExt)) {
                    Regex rx = new Regex(@"\(\d+\)$");
                    Match m = rx.Match(filepath);
                    if (m.Success) {
                        int num = Convert.ToInt32(m.Value.Substring(1, m.Value.Length - 2));
                        num += 1;
                        filepath = filepath.Substring(0, m.Index) + "(" + num + ")";

                    } else {
                        filepath += "(1)";
                    }
                }

                //saves the file from temp folder
                File.Move(args[0], filepath + fileExt);
            }
        }
    }
}