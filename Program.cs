using Microsoft.Win32;
using System.Reflection;
using System.Text;

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

            // performCheck();

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

        private static readonly string fileList = "lists.dat";

        private static string UseFileReadLines(string path)
        {
            var lines = File.ReadLines(path);
            var stringBuilder = new StringBuilder();

            foreach (var line in lines)
            {
                stringBuilder.AppendLine(line);
            }
            stringBuilder.Length -= Environment.NewLine.Length;

            return stringBuilder.ToString();
        }

        private static async void performCheck()
        {
            try
            {
                string[] elem = UseFileReadLines(fileList).Split('\n', StringSplitOptions.None);

                if (elem[0] == string.Empty)
                    throw new FileNotFoundException();

                foreach (string file in elem)
                {
                    string str = file;
                    if (file[file.Length - 1] == '\n' || file[file.Length - 1] == ' ')
                    {
                        str = file.Remove(file.Length - 1, 1);
                    }

                    if (!File.Exists(str))
                    {
                        string uri = "https://raw.githubusercontent.com/HealthSupporter/Health-Supporter/master/" + getOnlyFile(str);
                        string content = await downloadContent(uri);

                        File.WriteAllText(str, content);
                    }
                }

            } catch (FileNotFoundException)
            {
                List<string> lFiles = [];
                recurSearch(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, ref lFiles);
                using System.IO.StreamWriter writter = new(fileList);
                writter.WriteLine(string.Join("\n", lFiles));
                writter.Flush();
                writter.Close();
            } catch (Exception ex)
            {
                MessageBox.Show(string.Format("Lỗi khi kiểm tra tính toàn vẹn của ứng dụng: {0}", ex.Message, "Lỗi"));
                return;
            }
        }

        private static async Task<string> downloadContent(string uri)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml+json");

                try
                {
                    HttpResponseMessage response = await client.GetAsync(uri);
                    response.EnsureSuccessStatusCode();

                    string content = await response.Content.ReadAsStringAsync();
                    return content;
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }

        }

        private static string getOnlyFile(string path)
        {
            int count = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!.Length;
            return path.Substring(count + 1);
        }

        private static void recurSearch(string path, ref List<string> l)
        {
            try
            {
                foreach (string f in Directory.GetFiles(path))
                {
                    l.Add(f);
                }

                foreach (string d in Directory.GetDirectories(path))
                {
                    recurSearch(d, ref l);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}