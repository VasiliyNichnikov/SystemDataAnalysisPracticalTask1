using System.Drawing;
using System.IO;

namespace PracticalTask1.Utils
{
    public static class MyFileDotEngine
    {
        public static Bitmap Run(string dot)
        {
            string executable = PathHandler.GetPathDotExe();
            string output = PathHandler.GetPathOutput();
            File.WriteAllText(output, dot);

            System.Diagnostics.Process process = new System.Diagnostics.Process();

            // Stop the process from opening a new window
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            // Setup executable and parameters
            process.StartInfo.FileName = executable;
            process.StartInfo.Arguments = $@"{output} -Tjpg -O";

            // Go
            process.Start();
            // and wait dot.exe to complete and exit
            process.WaitForExit();
            Bitmap bitmap;
            using (Stream bmpStream = File.Open($"{output}.jpg", FileMode.Open))
            {
                Image image = Image.FromStream(bmpStream);
                bitmap = new Bitmap(image);
            }
            File.Delete(output);
            File.Delete($"{output}.jpg");
            return bitmap;
        }
    }
}