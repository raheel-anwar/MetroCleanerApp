using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.IO;

namespace MetroCleaner
{
    class UtilityClass
    {
        public static string systemInfo()
        {
            StringBuilder sysInfo = new StringBuilder();

            sysInfo.Append(String.Format("Current User: {0}\n", Environment.UserName));
            sysInfo.Append(String.Format("Machine Name: {0}\n", Environment.MachineName));
            sysInfo.Append(String.Format("User Profile: {0}\n", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)));
            sysInfo.Append(String.Format("System Folder: {0}\n", Environment.SystemDirectory));
            sysInfo.Append(String.Format("Processor Count: {0} Cores\n", Environment.ProcessorCount));

            return sysInfo.ToString();
        }

        public static void customAnimation(Window win, string animationName, DependencyObject obj)
        {
            Storyboard sb = win.FindResource(animationName) as Storyboard;
            Storyboard.SetTarget(sb, obj);
            sb.Begin();
        }

        public static void deleteAll(string path)
        {
            String[] files = Directory.GetFiles(path);
            String[] directory = Directory.GetDirectories(path);

            foreach (string file in files)
            {
                try
                {
                    File.Delete(file);
                }
                catch
                {
                    //TODO add a log file for this.
                    //Just skip is a file can not be deleted.
                }

            }

            foreach (string dir in directory)
            {
                try
                {
                    Directory.Delete(dir, true);
                }
                catch
                {
                    //TODO add a log file for this.
                    //Just skip if a directory can not be deleted.
                }
            }
        }
    }
}
