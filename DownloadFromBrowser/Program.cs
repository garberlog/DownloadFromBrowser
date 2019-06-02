using System.IO;

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
                filepath = (filepath + filename);

                //makes sure it has a unique name
                while (File.Exists(filepath)) {
                    filepath = (filepath + 1);
                }

                //saves the file from temp folder
                File.Move(args[0], filepath);
            }
        }
    }
}