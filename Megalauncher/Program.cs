using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Launcher
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }

    internal class Arma
    {
        private static Dictionary<string, string> strArmaOARegLocation = new Dictionary<string, string>()
        {
            {"x86", "SOFTWARE\\Bohemia Interactive Studio\\ArmA 2 OA"},
            {"x64", "SOFTWARE\\Wow6432Node\\Bohemia Interactive Studio\\ArmA 2 OA"}
        };
        private static Dictionary<string, string> strArmaRegLocation = new Dictionary<string, string>()
        {
            {"x86", "SOFTWARE\\Bohemia Interactive Studio\\ArmA 2"},
            {"x64", "SOFTWARE\\Wow6432Node\\Bohemia Interactive Studio\\ArmA 2"}
        };
        private static Dictionary<string, string> strArmaFreeRegLocation = new Dictionary<string, string>()
        {
            {"x86", "SOFTWARE\\Bohemia Interactive Studio\\ArmA 2 Free"},
            {"x64", "SOFTWARE\\Wow6432Node\\Bohemia Interactive Studio\\ArmA 2 Free"}
        };

        internal static byte[] GetArmaOAKey()
        {
            try
            {
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(Arma.strArmaOARegLocation[Arma.GetArch()]);
                if (registryKey != null)
                    return (byte[])registryKey.GetValue("KEY");
                else
                    return (byte[])null;
            }
            catch
            {
                return (byte[])null;
            }
        }
        internal static bool SetArmaOAKey(byte[] hexkey)
        {
            try
            {
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(Arma.strArmaOARegLocation[Arma.GetArch()], true);
                if (registryKey == null)
                    return false;
                registryKey.SetValue("KEY", (object)hexkey);
                registryKey.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        internal static string GetArmaPath()
        {
            try
            {
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(Arma.strArmaRegLocation[Arma.GetArch()]);
                if (registryKey != null)
                    return registryKey.GetValue("MAIN").ToString();
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }
        internal static string GetArmaOAPath()
        {
            try
            {
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(Arma.strArmaOARegLocation[Arma.GetArch()]);
                if (registryKey != null)
                    return registryKey.GetValue("MAIN").ToString();
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }
        internal static string GetArmaFreePath()
        {
            try
            {
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(Arma.strArmaFreeRegLocation[Arma.GetArch()]);
                if (registryKey != null)
                    return registryKey.GetValue("MAIN").ToString();
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Записывает в реестр новое значение путя для армы
        /// </summary>
        /// <param name="addonPath">Новый путь</param>
        /// <param name="addonType">Путь до чего изменяем (arma - Arma, oa - ArmaOA, free - ArmaFree)</param>
        /// <returns>true - если всё ок</returns>
        internal static bool UpdateArmaPath(string addonPath, string addonType)
        {
            try
            {
                switch (addonType)
                {
                    case "armaf":
                    case "ArmaFree":
                    case "free":
                        using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(strArmaFreeRegLocation[GetArch()], true))
                        {
                            if (registryKey == null)
                                return false;
                            registryKey.SetValue("MAIN", addonPath);
                            registryKey.Close();
                        }
                        break;
                    case "ArmaOA":
                    case "armaoa":
                    case "oa":
                        using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(strArmaOARegLocation[GetArch()], true))
                        {
                            if (registryKey == null)
                                return false;
                            registryKey.SetValue("MAIN", addonPath);
                            registryKey.Close();
                        }
                        break;
                    default:
                        using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(strArmaRegLocation[GetArch()], true))
                        {
                            if (registryKey == null)
                                return false;
                            registryKey.SetValue("MAIN", addonPath);
                            registryKey.Close();
                        }
                        break;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        internal static string GetArch()
        {
            switch (IntPtr.Size)
            {
                case 4:
                    return "x86";
                case 8:
                    return "x64";
                default:
                    return "x86";
            }
        }
    }
}