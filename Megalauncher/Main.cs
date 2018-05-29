using Ionic.Zip;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Security.Principal;
using Launcher.Properties;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace Launcher
{
    public partial class Main : Form
    {
        public static string ArmaBasePath = Arma.GetArmaOAPath();
        public static string UpdatesURL = "http://anionix.ddns.net/updates/";
        public static string ServerIP = "100.100.100.100";
        public static string ServerPort = "2302";
        public static string strSteamRegPath = "SOFTWARE\\Valve\\Steam";
        public static string keyFileName = "dayzmod.bikey";
        private List<GameServers> servers = new List<GameServers>(); // Список доступных серверов
        private string DwnFile;
        private string DwnPath;
        private int DwnCountTotal;
        private int DwnCountCurrent = 0;
        private Queue<URLToDownload> downloadList = new Queue<URLToDownload>();
        private Dictionary<string, string> ArmaPaths = new Dictionary<string, string>()
        {
          {"main", ArmaBasePath },
          {"mod", ArmaBasePath + "\\@dayzmod" },
          {"addon", ArmaBasePath + "\\@dayzmod\\addons" },
          {"keys", ArmaBasePath + "\\keys" }
        };
        private Point cursloc = new Point(0, 0);
        private Point formloc;
        private const int WS_CLIPCHILDREN = 33554432;
        private const int WS_MINIMIZEBOX = 131072;
        private const int WS_MAXIMIZEBOX = 65536;
        private const int WS_SYSMENU = 524288;
        private const int CS_DBLCLKS = 8;

        protected override CreateParams CreateParams
        {
          get
          {
            CreateParams createParams = base.CreateParams;
            createParams.Style = 34209792;
            createParams.ClassStyle = 8;
            return createParams;
          }
        }

        public Main()
        {
            InitializeComponent();
        }

        private void setpositions()
        {
          formloc = Location;
          cursloc = Cursor.Position;
        }
        
        public void StartUp(object sender, EventArgs e) // Entry point (Start)
        {
            LoadServersList();
            btn_launch.Enabled = false;
            if (ArmaBasePath == null)
            {
                bool flag = false;
                while (!flag)
                {
                    if (Application.UserAppDataRegistry.GetValue("Arma2Path") != null)
                    {
                        ArmaBasePath = Application.UserAppDataRegistry.GetValue("Arma2Path").ToString();
                    }
                    else
                    {
                        MessageBox.Show("Не могу обнаружить директорию с Arma2. Укажите путь до файла Arma2oa.exe вручную.");
                        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                        {
                            ArmaBasePath = folderBrowserDialog1.SelectedPath;
                        }
                        else
                        {
                            MessageBox.Show("Для запуска необходима Arma2: Combined Operations");
                            Environment.Exit(1);
                        }
                    }
                    if (File.Exists(ArmaBasePath + "\\arma2oa.exe"))
                    {
                        Application.UserAppDataRegistry.SetValue("Arma2Path", (object)ArmaBasePath);
                        flag = true;
                    }
                }
            }
            new Thread(() =>
            {
                UpdateAddon();
            }).Start();
        }

        private void LoadServersList()
        {
            // Добавляем сервера в список доступных
            servers.Add(new GameServers() { name = "Server #1", address = "100.100.100.100", port = "2302" });
            servers.Add(new GameServers() { name = "Server #2", address = "200.200.200.200", port = "2302" });
            foreach (GameServers server in servers)
            {
                comboBox1.Items.Add(server.name);
            }
        }

        private void Launch()
        {
            UpdateStatus("Запускаю игру...");
            Process process = new Process();
            string ArmaPath = Arma.GetArmaPath();
            string ArmaFreePath = Arma.GetArmaFreePath();

            if (System.IO.File.Exists(ArmaBasePath + "\\arma2.exe"))
                ArmaPath = ArmaBasePath;

            if (ArmaPath == null && ArmaFreePath == null)    // Есть ли следы игры в реестре ?
            {
                MessageBox.Show("Немогу найти Arma или Arma Free. Установите игру и запустите хотябы 1 раз.");
                Environment.Exit(0);
            }

            if (!Directory.Exists(ArmaBasePath + "\\Expansion\\beta")) // Проверка, есть ли директория с бэта-патчем
            {
                MessageBox.Show("Для игры необходим последний Beta-патч!");
                Environment.Exit(0);
            } else {
                if (ArmaBasePath.IndexOf("steamapps") > 0) // Если в пути к игре есть слово Steamapps - Считаем, что мы имеем дело со Steam верисией игры
                {
                    try // Получаем путь до выполняемого файла из реестра
                    {
                        RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(strSteamRegPath);
                        if (registryKey != null)
                        process.StartInfo.FileName = registryKey.GetValue("SteamExe").ToString();
                    }
                    catch
                    {
                        MessageBox.Show("Немогу найти Steam");
                        Environment.Exit(0);
                    }

                    try // Фикс запуска Стим версии, в виде подмены исполняемого файла
                    {
                        if (FileVersionInfo.GetVersionInfo(ArmaBasePath + "\\arma2oa.exe").ProductVersion != FileVersionInfo.GetVersionInfo(ArmaBasePath + "\\Expansion\\beta\\arma2oa.exe").ProductVersion)
                        {
                            if (System.IO.File.Exists(ArmaBasePath + "\\arma2oa.bak"))
                                System.IO.File.Delete(ArmaBasePath + "\\arma2oa.bak");
                            System.IO.File.Move(ArmaBasePath + "\\arma2oa.exe", ArmaBasePath + "\\arma2oa.bak");
                            System.IO.File.Copy(ArmaBasePath + "\\Expansion\\beta\\arma2oa.exe", ArmaBasePath + "\\arma2oa.exe", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);    // Если есть какие траблы - выводим
                    }
                    // Строка запуска ...
                    process.StartInfo.Arguments = "-applaunch 33930 -skipIntro -noSplash -noFilePatching -world=empty \"-mod=" + ArmaPath + ";expansion;expansion\\beta;expansion\\beta\\expansion;@dayzmod\" -connect=" + ServerIP + " -port=" + ServerPort;
                }
                else if (ArmaBasePath != ArmaPath && ArmaPath != null) // Arma2 и Arma2: OA установлены в разные папки
                {
                    process.StartInfo.FileName = ArmaBasePath + "\\Expansion\\beta\\arma2oa.exe";
                    process.StartInfo.Arguments = " -skipIntro -noSplash -noFilePatching -world=empty \"-mod=" + ArmaPath + ";expansion;expansion\\beta;expansion\\beta\\expansion;@dayzmod\" -connect=" + ServerIP + " -port=" + ServerPort;
                    process.StartInfo.WorkingDirectory = ArmaBasePath;
                }
                else if (ArmaFreePath != null)    // Используется Arma Free...
                {
                    process.StartInfo.FileName = ArmaBasePath + "\\Expansion\\beta\\arma2oa.exe";
                    process.StartInfo.Arguments = " -skipIntro -noSplash -noFilePatching -world=empty \"-mod=" + ArmaFreePath + ";expansion;expansion\\beta;expansion\\beta\\expansion;@dayzmod\" -connect=" + ServerIP + " -port=" + ServerPort;
                    process.StartInfo.WorkingDirectory = ArmaBasePath;
                }
                else
                { // Arma2 и Arma2: OA в одной папке...
                    process.StartInfo.FileName = ArmaBasePath + "\\Expansion\\beta\\arma2oa.exe";
                    process.StartInfo.Arguments = " -beta=Expansion\\beta;Expansion\\beta\\Expansion -nosplash -skipIntro -mod=@dayzmod -world=empty -connect=" + ServerIP + " -port=" + ServerPort;
                    process.StartInfo.WorkingDirectory = ArmaBasePath;
                }
                /* Debug - Запуск блокнота намного быстре, чем запуск игры :) *
                process.StartInfo.FileName = "notepad.exe";
                process.StartInfo.Arguments = "";
                process.StartInfo.WorkingDirectory = @"D:/";
                */
                
                // Сворачиваем лаунчер в трей
                WindowState = FormWindowState.Minimized;
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(100);
                Hide();

                // Запускаем сам процесс и ждём завершения
                process.Start();
                UpdateStatus("Игра в процессе.");
                process.WaitForExit();
                UpdateStatus("Всё готово для запуска игры");

                // Покаываем
                Show();
                WindowState = FormWindowState.Normal;
                notifyIcon1.Visible = false;
                TopMost = true; // Fix - brign to front
                Focus();
                TopMost = false;
            }
        }

        private void UpdateAddon()
        {
            if (!Directory.Exists(ArmaPaths["mod"])) // Создаём нужные директории
                Directory.CreateDirectory(ArmaPaths["mod"]);

            if (!Directory.Exists(ArmaPaths["addon"]))
                Directory.CreateDirectory(ArmaPaths["addon"]);

            // Получаем данные о файлах
            Dictionary<string, Dictionary<string, string>> serverVersion = GetServerVersion();
            Dictionary<string, string> localFiles = new Dictionary<string, string>();
            if (!File.Exists(ArmaPaths["keys"] + "\\" + keyFileName))
            {
                // Если файла ключа не существует - считаем, что мод вообще не установлен.
                localFiles = null;
            }
            else
            {
                // Добавляем хеш для файла ключа
                localFiles[keyFileName] = GetFileMD5(ArmaPaths["keys"] + "\\" + keyFileName);

                var numFiles = Directory.GetFiles(ArmaPaths["addon"], "*.*").Length;
                var i = 0;
                SetPBarState(true);

                // Подсчитывает МД5 хешы для всех файлов *.pbo в папке мода
                foreach (string addonFile in Directory.GetFiles(ArmaPaths["addon"], "*.*"))
                {
                    string FileName = Path.GetFileName(addonFile);

                    UpdateStatus("Проверяю файл: " + FileName + "... (" + i++ + " из " + numFiles + ")");

                    var value = int.Parse(Math.Truncate((double)i / (double)numFiles * 100.0).ToString());
                    if (progressBar1.InvokeRequired) progressBar1.BeginInvoke(new Action(() => { progressBar1.Value = value; }));
                    else progressBar1.Value = value;

                    localFiles[FileName] = GetFileMD5(addonFile);
                }
                SetPBarState(false);
            }

            // Если с сервера пришол нормальный список файлов...
            if (serverVersion != null)
            {
                // Проверяем список и удоляем отсутсвующие на сервере файлы
                if (localFiles != null)
                {
                    foreach (string str in localFiles.Keys)
                    {
                        if (!serverVersion.ContainsKey(str))
                        {
                            if (System.IO.File.Exists(ArmaPaths["addon"] + "\\" + str))
                                System.IO.File.Delete(ArmaPaths["addon"] + "\\" + str);
                            if (System.IO.File.Exists(ArmaPaths["addon"] + "\\" + str + ".dayzmod.bisign"))
                                System.IO.File.Delete(ArmaPaths["addon"] + "\\" + str + ".dayzmod.bisign");
                        }
                    }
                }
                // Проверяем различия, ставим отличающиеся файлы в очередь на скачку
                foreach (string srvFile in serverVersion.Keys)
                {
                    string FilePath = ArmaPaths[serverVersion[srvFile]["path"]];
                    if (localFiles == null || !localFiles.ContainsKey(srvFile) || serverVersion[srvFile]["md5"] != localFiles[srvFile])
                        downloadList.Enqueue(new URLToDownload()
                        {
                            Path = ArmaPaths[serverVersion[srvFile]["path"]],
                            FileName = Path.GetFileNameWithoutExtension(srvFile) + ".zip"
                        });
                }
                // Если есть обновления - предлагаем скачать их
                if (downloadList.Count > 0)
                {
                    DwnCountTotal = downloadList.Count;
                    UpdateBtnLaunch("Обновить", true);
                    UpdateStatus("Доступно обновление");
                }
                else
                {
                    StartDownloads();
                }
            }
            else
            {
                UpdateBtnLaunch("Запустить", true);
                SetPBarState(false);
                UpdateStatus("Невозможно получить информацию с сервера обновлений!");
            }
        }
        
        private void StartDownloads()
        {
            if (downloadList.Count > 0)
            {
                UpdateBtnLaunch("Обновление...", false);
                DownloadFile(downloadList.Dequeue());
            }
            else
            {
                SetPBarState(false);
                UpdateBtnLaunch("Запустить", true);
                UpdateStatus("Проверка завершена. Приятной игры!");
            }
        }

        /// <summary>
        /// Возвращяет MD5-хэш для указанного файла
        /// </summary>
        /// <param name="FileName">Имя файла</param>
        /// <returns>string</returns>
        private string GetFileMD5(string FileName)
        {
            using (var md5Hash = MD5.Create())
            {
                using (var stream = File.OpenRead(FileName))
                {
                    byte[] hash = md5Hash.ComputeHash(stream);
                    StringBuilder stringBuilder = new StringBuilder();
                    for (int index = 0; index < hash.Length; ++index)
                        stringBuilder.Append(hash[index].ToString("x2"));
                    return ((object)stringBuilder).ToString().ToUpper();
                }
            }
        }
        private Dictionary<string, Dictionary<string, string>> GetServerVersion()
        {
            try
            {
                Dictionary<string, Dictionary<string, string>> versionsList = new Dictionary<string, Dictionary<string, string>>();
                XmlDocument xmlDocument = new XmlDocument();

                xmlDocument.Load(UpdatesURL + "version.xml");
                XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/updates/data");
                for (int index = 0; index < xmlNodeList.Count; ++index)
                {
                    Dictionary<string, string> tmp = new Dictionary<string, string>();
                    string innerText = xmlNodeList.Item(index).SelectSingleNode("name").InnerText;
                    tmp["md5"] = xmlNodeList.Item(index).SelectSingleNode("md5").InnerText;
                    tmp["path"] = xmlNodeList.Item(index).SelectSingleNode("path").InnerText;
                    versionsList[innerText] = tmp;
                }
                return versionsList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void UpdateStatus(string strMessage)
        {
            if (lblStatus.InvokeRequired) lblStatus.BeginInvoke(new Action(() => { lblStatus.Text = strMessage; }));
            else lblStatus.Text = strMessage;
        }
        private void UpdateBtnLaunch(string strMessage, bool active)
        {
            if (btn_launch.InvokeRequired) btn_launch.BeginInvoke(new Action(() =>
            {
                btn_launch.Text = strMessage;
                btn_launch.Enabled = active;
            }));
            else
            {
                btn_launch.Text = strMessage;
                btn_launch.Enabled = active;
            }
        }
        private void SetPBarState(bool state)
        {
            if (progressBar1.InvokeRequired) progressBar1.BeginInvoke(new Action(() => { progressBar1.Visible = state; }));
            else progressBar1.Visible = state;
        }

        private void ExtractProgress(object sender, ExtractProgressEventArgs e)
        {
            if (e.EventType == ZipProgressEventType.Extracting_EntryBytesWritten)
            {
                progressBar1.Value = int.Parse(Math.Truncate(double.Parse(e.BytesTransferred.ToString()) / double.Parse(e.TotalBytesToTransfer.ToString()) * 100.0).ToString());
            }
            else if (e.EventType == ZipProgressEventType.Extracting_BeforeExtractEntry)
            {
                UpdateStatus("Распаковка " + e.CurrentEntry.FileName + " ...");
            }
        }

        private void DownloadFile(URLToDownload args)
        {
            UpdateStatus("Скачиваю " + args.FileName + " ... (" + ++DwnCountCurrent + " из " + DwnCountTotal + ")");
            DwnFile = ArmaPaths["mod"] + "\\" + args.FileName;
            DwnPath = args.Path;
            SetPBarState(true);
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DwnProgressChanged);
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DwnCompleted);
            try
            {
                if (File.Exists(ArmaPaths["mod"] + "\\" + args.FileName))   // Удаление недокаченного файла, если имеется.
                    File.Delete(ArmaPaths["mod"] + "\\" + args.FileName);
                webClient.DownloadFileAsync(new Uri(UpdatesURL + args.FileName), ArmaPaths["mod"] + "\\" + args.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DwnProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            var value = int.Parse(Math.Truncate(double.Parse(e.BytesReceived.ToString()) / double.Parse(e.TotalBytesToReceive.ToString()) * 100.0).ToString());
            if (progressBar1.InvokeRequired) progressBar1.BeginInvoke(new Action(() => { progressBar1.Value = value; }));
            else progressBar1.Value = value;
        }
        private void DwnCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                UpdateStatus("Распаковка " + Path.GetFileNameWithoutExtension(DwnFile) + " ...");
                using (ZipFile zip = ZipFile.Read(DwnFile))
                {
                    zip.ExtractProgress += ExtractProgress;
                    foreach (ZipEntry file in zip)
                    {
                        file.Extract(DwnPath, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                File.Delete(DwnFile);
                StartDownloads();
            }
            else
            {
                MessageBox.Show(e.Error.Message);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void btn_close_normal(object sender, EventArgs e)
        {
            btn_close.Image = (Image) Resources.btn_close_normal;
        }
        private void btn_close_hover(object sender, EventArgs e)
        {
            btn_close.Image = (Image) Resources.btn_close_active;
        }
        private void btn_close_pressed(object sender, EventArgs e)
        {
            btn_close.Image = (Image) Resources.btn_close_pressed;
        }

        private void btn_min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void btn_min_normal(object sender, EventArgs e)
        {
            btn_min.Image = (Image) Resources.btn_minimise_normal;
        }
        private void btn_min_hover(object sender, EventArgs e)
        {
            btn_min.Image = (Image) Resources.btn_minimise_active;
        }
        private void btn_min_pressed(object sender, EventArgs e)
        {
            btn_min.Image = (Image) Resources.btn_minimise_pressed;
        }

        private void btn_site_Click(object sender, EventArgs e)
        {
            Process.Start("http://anionix.ddns.net");
        }
        private void btn_launch_Click(object sender, EventArgs e)
        {
            if (downloadList.Count > 0)
            {
                StartDownloads();
            }
            else
            {
                Launch();
            }
        }
        private void btn_tools_Click(object sender, EventArgs e)
        {
            btn_tools.Enabled = false;
            Tools tools = new Tools();
            tools.FormClosed += (FormClosedEventHandler) ((sndr, args) => btn_tools.Enabled = true);
            ((Control) tools).Show();
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            Process.Start(e.Url.ToString());
            e.Cancel = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Location = new Point(formloc.X - cursloc.X + Cursor.Position.X, formloc.Y - cursloc.Y + Cursor.Position.Y);
        }

        private void headnav_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Stop();
            setpositions();
        }
        private void headnav_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Start();
            setpositions();
        }

        private void btn_normal(object sender, EventArgs e)
        {
            Button button = (Button) sender;
            button.BackgroundImage = (Image) Resources.btn_big_normal;
            button.BackColor = System.Drawing.Color.Transparent;
        }
        private void btn_active(object sender, EventArgs e)
        {
            Button button = (Button) sender;
            button.BackgroundImage = (Image) Resources.btn_big_active;
            button.BackColor = System.Drawing.Color.Transparent;
        }
        private void btn_pressed(object sender, EventArgs e)
        {
            Button button = (Button) sender;
            button.BackgroundImage = (Image) Resources.btn_big_pressed;
            button.BackColor = System.Drawing.Color.Transparent;
        }

        private class URLToDownload
        {
            public string Path { get; set; }
            public string FileName { get; set; }
        }

        private class GameServers
        {
            public string name { get; set; }
            public string address { get; set; }
            public string port { get; set; }
        }

        private void btn_tools_full_Click(object sender, EventArgs e)
        {
            btn_tools.Enabled = false;
            Tools tools = new Tools(true);
            tools.FormClosed += (FormClosedEventHandler)((sndr, args) => btn_tools.Enabled = true);
            ((Control)tools).Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServerIP = servers[comboBox1.SelectedIndex].address;
            ServerPort = servers[comboBox1.SelectedIndex].port;
        }
    }
}
