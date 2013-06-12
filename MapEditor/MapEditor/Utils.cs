using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace MapEditor
{
    class Utils
    {
        private static int calcSize(int dimSize)
        {
            int size = 2;
            while (size < dimSize)
                size = size * 2;
            return (size / 2 + size) / 2 < dimSize ? size : size / 2;
        }

        public static Bitmap InteligentResize2(Bitmap bmp)
        {
            int width = calcSize(bmp.Width);
            int height = calcSize(bmp.Height);


            Bitmap result = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(result);
            g.DrawImage(bmp, new Rectangle(0, 0, width, height));
            return result;

        }
        public static Bitmap InteligentResize(Bitmap bmp)
        {
            int width = 40;
            int height = 40;


            Bitmap result = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(result);
            g.DrawImage(bmp, new Rectangle(0, 0, width, height));
            return result;

        }
        public static Point PointToOpengl(Point p)
        {
            return new Point(p.X, -p.Y + (int)EditorEngine.Instance.Camera.Height - 1);
        }

        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);            
            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the source directory does not exist, throw an exception.
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory does not exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }


            // Get the file contents of the directory to copy.
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                // Create the path to the new copy of the file.
                string temppath = Path.Combine(destDirName, file.Name);

                // Copy the file.
                file.CopyTo(temppath, false);
            }

            // If copySubDirs is true, copy the subdirectories.
            if (copySubDirs)
            {

                foreach (DirectoryInfo subdir in dirs)
                {
                    // Create the subdirectory.
                    string temppath = Path.Combine(destDirName, subdir.Name);

                    // Copy the subdirectories.
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }
}
