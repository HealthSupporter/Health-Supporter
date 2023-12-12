using Microsoft.Win32;

namespace ExerciseApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (false == DetectEnviroment("3.5"))
            {
                MessageBox.Show("Phiên bản .NET hiện tại đã cũ, vui lòng cập nhật lên phiên bản mới hơn");
                return;
            }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new ExerciseApp());
            Application.Exit();
        }


        private static bool DetectEnviroment(string minimumVersion)
        {
            const string TARGET_KEY = "SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full";
            try
            {
                using (RegistryKey? key = Registry.LocalMachine.OpenSubKey(TARGET_KEY))
                {
                    if (key != null)
                    {
                        object? version = key.GetValue("Version");
                        if (version != null)
                        {
                            string[] sysMinMajVersion = ((string) version).Split(".");
                            string[] reqMinMajVersion = minimumVersion.Split(".");
                            
                            int existingMajor, existingMinor, requireMajor, requireMinor;
                            int.TryParse(sysMinMajVersion[0], out existingMajor);
                            int.TryParse(sysMinMajVersion[1], out existingMinor);
                            int.TryParse(reqMinMajVersion[0], out requireMajor);
                            int.TryParse(reqMinMajVersion[1], out requireMinor);

                            if (requireMajor < existingMajor)
                            {
                                return true;
                            } else if (requireMajor == existingMajor && requireMinor <= existingMinor)
                            {
                                return true;
                            } else
                            {
                                return false;
                            }
                        }
                    }
                }
            } catch (Exception)
            {
                return false;
            }

            return false;
        }
    }
}