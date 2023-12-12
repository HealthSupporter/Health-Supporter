using Raoni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfImplement_Libraries
{
    internal class Libraries
    {
    }

    public class AppConfiguration
    {
        private readonly string outputConfigFile;
        private readonly int numConfig;
        private static string[] configNames = [];
        private static string[] configValues = [];


        private static readonly string[] separator = ["\n", ": ", "$"];

        public AppConfiguration(string outputFIle, string[] customConfig)
        {
            outputConfigFile = outputFIle;
            numConfig = customConfig.Length;
            configNames = customConfig;
            configValues = new string[numConfig];
        }

        public bool Load()
        {
            string[] input;
            try { input = File.ReadAllLines(outputConfigFile); }
            catch (Exception) { return false; }

            int i = 0;
            foreach (var inputLine in input)
            {
                string[] elem = inputLine.Split(separator, StringSplitOptions.None);
                string name = elem[0].Trim('"');
                string value = elem[1].Trim('"');

                var index = Array.IndexOf(configNames, name);
                if (index != -1)
                {
                    configValues[index] = value;
                    i++;
                }

            }
            
            if (i != numConfig)
                return false;

            return true;
        }

        public bool Load(string fileName)
        {
            string[] input;
            try { input = File.ReadAllLines(fileName); }
            catch (Exception) { return false; }

            int i = 0;
            foreach (var inputLine in input)
            {
                string[] elem = inputLine.Split(separator, StringSplitOptions.None);
                string name = elem[0].Trim('"');
                string value = elem[1].Trim('"');

                var index = Array.IndexOf(configNames, name);
                if (index != -1)
                {
                    configValues[index] = value;
                    i++;
                }
            }

            if (i != numConfig)
                return false;

            return true;
        }

        public string Lookup(string key)
        {
            var index = Array.IndexOf(configNames, key);
            if (index == -1)
                return string.Empty;
            return configValues[index];
        }

        public string Lookup(string key, ref int index)
        {
            var idx = Array.IndexOf(configNames, key);
            index = idx;
            if (idx == -1)
            {
                return string.Empty;
            }
            return configValues[index];
        }

        public string[] GetListOfValue()
        {
            string[] ret = new string[numConfig];
            ret = configValues;
            return ret;
        }

        public string[] GetListOfConfig()
        {
            string[] ret = new string[numConfig];
            ret = configNames;
            return ret;
        }

        public int GetConfigIndex(string key)
        {
            return Array.IndexOf(configNames, key);
        }

        public bool Edit(string key, Variant value)
        {
            int index = -1;
            Lookup(key, ref index);
            if (index == -1) return false;

            configValues[index] = value.ToString();
            return true;
        }

        // Ignore incorrect config
        public void Edit(string[] keys, string[] values)
        {
            int index = -1;
            for (int i = 0; i < keys.Length; i++)
            {
                Lookup(keys[i], ref index);
                if (index == -1) continue;
                configValues[index] = values[i];
            }
        }

        public bool Save()
        {
            File.WriteAllText(outputConfigFile, string.Empty);
            using StreamWriter writer = new(outputConfigFile);
            int i = 0;
            for (int j = 0; j < numConfig; j++)
            {
                string name = configNames[j];
                string value = configValues[j];
                if (name != string.Empty && value != string.Empty)
                {
                    string str = string.Format("{0}: {1}", name, value);
                    try { writer.WriteLine(str); i++; } catch { return false; }
                }
            }
            if (i == numConfig) return true;
            else return false;
        }
    }


    public static class ExtensionMethods
    {
        public static ulong ToTick(this DateTime dt)
        {
            return (ulong)dt.ToUniversalTime().Subtract(
                                    new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                                        ).TotalMilliseconds;
        }

        public static ulong ToTick(this DateTime dt1,  DateTime dt2)
        {
            return (ulong)dt1.ToUniversalTime().Subtract(dt2.ToUniversalTime()).TotalMilliseconds;
        }
    }
}
