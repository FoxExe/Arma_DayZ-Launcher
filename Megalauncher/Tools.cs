using Ionic.Zip;
using Launcher.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Launcher
{
    public partial class Tools : Form
    {
        string ArmaBetaLink;
        internal static string ArmaBetaUrl = "http://www.arma2.com/beta-patch.php";
        private static readonly string szTemplate = "0123456789ABCDEFGHJKLMNPRSTVWXYZ";
        private Point cursloc = new Point(0, 0);
        private const int WS_CLIPCHILDREN = 33554432;
        private const int WS_MINIMIZEBOX = 131072;
        private const int WS_MAXIMIZEBOX = 65536;
        private const int WS_SYSMENU = 524288;
        private const int CS_DBLCLKS = 8;
        private Point formloc;
        public bool isFull = false;

        public Tools(bool full = false)
        {
            InitializeComponent();

            if (full)
            {
                btn_changekey.Enabled = true;
                btn_changekey.Visible = true;
                box_cdkey.ReadOnly = false;
            }
            try
            {
                string armaPath = Arma.GetArmaOAPath() + "\\Expansion\\beta\\arma2oa.exe";
                byte[] armaOaKey = Arma.GetArmaOAKey();
                string cdkey = RegistryToSerial(armaOaKey);
                string input = cdkey.Substring(0, 4) + "-" + cdkey.Substring(4, 5) + "-" + cdkey.Substring(9, 5) + "-" + cdkey.Substring(14, 5) + "-" + cdkey.Substring(19, 5);
                box_hexkey.Text = BitConverter.ToString(armaOaKey);
                box_cdkey.Text = input;
                box_guid.Text = getMd5Hash("BE" + getMd5Hash(input));
                btn_startUpdate.Visible = false;
                txtbox_arma1.Text = Arma.GetArmaPath();
                txtbox_arma2.Text = Arma.GetArmaOAPath();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            new Thread(() =>
                {
                    if (CheckBetaPatch())
                    {
                        if (btn_startUpdate.InvokeRequired) btn_startUpdate.BeginInvoke(new Action(() => { btn_startUpdate.Visible = true; }));
                            else btn_startUpdate.Visible = true;
                    }
                }).Start();
        }

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
        private void setpositions()
        {
            this.formloc = this.Location;
            this.cursloc = Cursor.Position;
        }

        public byte[] SerialToRegistry(string arma2key)
        {
            if (string.IsNullOrEmpty(arma2key))
                throw new ArgumentNullException("arma2key");
            string str = arma2key.Trim().ToUpper().Replace('O', '0').Replace('I', '1').Replace("-", "").Replace(" ", "");
            if (str.Length != 24)
                throw new ArgumentException(string.Format("\"{0}\" Не является верным ключом (CD-KEY)", (object)arma2key));
            byte[] numArray = new byte[15];
            for (int index1 = 0; index1 < 3; ++index1)
            {
                ulong num1 = 0UL;
                for (int index2 = 0; index2 < 8; ++index2)
                {
                    char ch = str[index1 * 8 + index2];
                    int num2 = Tools.szTemplate.IndexOf(ch);
                    if (num2 < 0)
                        throw new ArgumentException(string.Format("Введённый ключь содержит недопустимые символы: \"{0}\" на позиции {1}", (object)arma2key[str.IndexOf(ch)], (object)str.IndexOf(ch)));
                    num1 |= (ulong)num2 << index2 * 5;
                }
                for (int index2 = 0; index2 < 5; ++index2)
                {
                    numArray[index1 * 5 + 5 - 1 - index2] = (byte)(num1 & (ulong)byte.MaxValue);
                    num1 >>= 8;
                }
            }
            return numArray;
        }
        public string RegistryToSerial(byte[] arma2registry)
        {
            if (arma2registry == null)
                throw new Exception("CD-Key в реестре пуст");
            if (arma2registry.Length != 15)
                throw new Exception("CD-Key в реестре не корректен. (Не 15 байт)");
            string str = "";
            for (int index1 = 0; index1 < 3; ++index1)
            {
                ulong num1 = 0UL;
                for (int index2 = 0; index2 < 5; ++index2)
                    num1 = num1 << 8 | (ulong)arma2registry[index1 * 5 + index2];
                for (int index2 = 0; index2 < 8; ++index2)
                {
                    ulong num2 = num1 >> index2 * 5 & 31UL;
                    char ch = Tools.szTemplate[(int)num2];
                    str = str + (object)ch;
                }
            }
            return str;
        }
        public bool CheckBetaPatch()
        {
            try
            {
                string responseBody = null;
                var request = (HttpWebRequest)WebRequest.Create(ArmaBetaUrl);
                request.Method = "GET";
                request.Timeout = 10000;
                using (var response = request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        var streamReader = new StreamReader(responseStream);
                        responseBody = streamReader.ReadToEnd();
                        streamReader.Close();
                    }
                }

                var latestBetaUrlMatch = Regex.Match(responseBody, @"Latest\s+beta\s+patch:\s*<a\s+href\s*=\s*(?:'|"")([^'""]+)(?:'|"")", RegexOptions.IgnoreCase);
                if (!latestBetaUrlMatch.Success)
                {
                    throw new Exception("Не обнаружено информации о последнем патче");
                }
                string latestDownloadUrl = latestBetaUrlMatch.Groups[1].Value;
                var latestBetaRevisionMatch = Regex.Match(latestDownloadUrl, @"(\d+)\.(?:zip|rar)", RegexOptions.IgnoreCase);
                if (!latestBetaRevisionMatch.Success)
                {
                    throw new Exception("Не обнаружена ссылка на последний бэтапатч");
                }
                var latestRevision = latestBetaRevisionMatch.Groups[1].Value;
                if (latestRevision != null)
                {
                    string betaBuild = null;
                    if (File.Exists(Main.ArmaBasePath + "\\Expansion\\beta\\arma2oa.exe"))
                    {
                        betaBuild = FileVersionInfo.GetVersionInfo(Main.ArmaBasePath + "\\Expansion\\beta\\arma2oa.exe").ProductVersion;
                        var betaMatch = Regex.Match(betaBuild, @"\d+(;\d+)*", RegexOptions.RightToLeft);     // 1.62.0.103419 -> 103419
                        if (!betaMatch.Success)
                        {
                            throw new Exception("Немогу получить версию бэтапатча");
                        }
                        betaBuild = betaMatch.Value;
                    }
                    else if (File.Exists(Main.ArmaBasePath + "\\arma2oa.exe"))
                    {
                        betaBuild = FileVersionInfo.GetVersionInfo(Main.ArmaBasePath + "\\arma2oa.exe").ProductVersion;
                        var betaMatch = Regex.Match(betaBuild, @"\d+(;\d+)*", RegexOptions.RightToLeft);
                        if (!betaMatch.Success)
                        {
                            throw new Exception("Немогу получить версию бэтапатча");
                        }
                        betaBuild = betaMatch.Value;
                    }
                    else
                    {
                        betaBuild = "Не установлен";
                    }

                    if (txt_version.InvokeRequired) txt_version.BeginInvoke(new Action(() => { txt_version.Text = betaBuild; }));
                        else txt_version.Text = betaBuild; // Set local revision
                    if (txt_version2.InvokeRequired) txt_version2.BeginInvoke(new Action(() => { txt_version2.Text = latestRevision; }));
                        else txt_version2.Text = latestRevision; // Set server revision

                    if (betaBuild != latestRevision)
                    {
                        if (btn_startUpdate.InvokeRequired) btn_startUpdate.BeginInvoke(new Action(() => { btn_startUpdate.Visible = true; }));
                        else btn_startUpdate.Visible = true;
                        ArmaBetaLink = latestDownloadUrl;
                        return true;
                    }
                    return false; // Возвращяем False на всякий случай ...
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
                return false;
            }
        }
        private static string getMd5Hash(string input)
        {
            byte[] hash = MD5.Create().ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = 0; index < hash.Length; ++index)
                stringBuilder.Append(hash[index].ToString("x2"));
            return ((object)stringBuilder).ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Location = new Point(this.formloc.X - this.cursloc.X + Cursor.Position.X, this.formloc.Y - this.cursloc.Y + Cursor.Position.Y);
        }

        private void headnav_MouseUp(object sender, MouseEventArgs e)
        {
            this.timer1.Stop();
            this.setpositions();
        }
        private void headnav_MouseDown(object sender, MouseEventArgs e)
        {
            this.timer1.Start();
            this.setpositions();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_changekey_Click(object sender, EventArgs e)
        {
            byte[] numArray = this.SerialToRegistry(this.box_cdkey.Text);
            if (Arma.SetArmaOAKey(numArray))
            {
                string str = this.RegistryToSerial(numArray);
                string input = str.Substring(0, 4) + "-" + str.Substring(4, 5) + "-" + str.Substring(9, 5) + "-" + str.Substring(14, 5) + "-" + str.Substring(19, 5);
                SystemSounds.Exclamation.Play();
                int num = (int)MessageBox.Show("Ключь успешно сохранён");
                this.box_hexkey.Text = BitConverter.ToString(numArray);
                this.box_cdkey.Text = input;
                this.box_guid.Text = Tools.getMd5Hash("BE" + Tools.getMd5Hash(input));
            }
            else
            {
                SystemSounds.Hand.Play();
                int num = (int)MessageBox.Show("Сохранить ключь не удалось");
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            string armaPath = Arma.GetArmaOAPath();
            Directory.Delete(armaPath + "\\@dayzmod", true);
            File.Delete(armaPath + "\\" + Main.keyFileName);
            Application.Restart();
        }
        private void btn_normal(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = (Image)Resources.btn_big_normal;
            button.BackColor = Color.Transparent;
        }
        private void btn_active(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = (Image)Resources.btn_big_active;
            button.BackColor = Color.Transparent;
        }
        private void btn_pressed(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = (Image)Resources.btn_big_pressed;
            button.BackColor = Color.Transparent;
        }

        private void btn_startUpdate_Click(object sender, EventArgs e)
        {
            if (ArmaBetaLink != null)
            {
                var DwnFile = Main.ArmaBasePath + "\\" + Path.GetFileName(ArmaBetaLink);
                WebClient webClient = new WebClient();
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DwnProgressChanged);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DwnCompleted);
                try
                {
                    if (File.Exists(DwnFile))   // Удаление недокаченного файла, если имеется.
                        File.Delete(DwnFile);
                    
                    // Hide buttons, unhide ProgressBar
                    dwl_progress.Visible = true;
                    btn_startUpdate.Enabled = false;
                    btn_delete.Enabled = false;
                    btn_close.Enabled = false;

                    webClient.DownloadFileAsync(new Uri(ArmaBetaLink), DwnFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void DwnProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            dwl_progress.Value = int.Parse(Math.Truncate(double.Parse(e.BytesReceived.ToString()) / double.Parse(e.TotalBytesToReceive.ToString()) * 100.0).ToString());
        }
        private void ExtractProgressChanged(object sender, ExtractProgressEventArgs e)
        {
            if (e.EventType == ZipProgressEventType.Extracting_EntryBytesWritten)
            {
                //UpdateStatus(e.BytesTransferred.ToString());
                dwl_progress.Value = int.Parse(Math.Truncate(double.Parse(e.BytesTransferred.ToString()) / double.Parse(e.TotalBytesToTransfer.ToString()) * 100.0).ToString());
            }
            else if (e.EventType == ZipProgressEventType.Extracting_BeforeExtractEntry)
            {
                 // e.CurrentEntry.FileName
            }
        }
        private void DwnCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                string exeFile = null;
                var DwnFile = Main.ArmaBasePath + "\\" + Path.GetFileName(ArmaBetaLink);
                using (ZipFile zip = ZipFile.Read(DwnFile))
                {
                    zip.ExtractProgress += ExtractProgressChanged;
                    foreach (ZipEntry file in zip)
                    {
                        file.Extract(Main.ArmaBasePath, ExtractExistingFileAction.OverwriteSilently);
                        if (file.FileName.EndsWith(".exe"))
                            exeFile = file.FileName;
                    }
                }

                // make buttons visible, hide progress bar
                dwl_progress.Visible = false;
                btn_startUpdate.Enabled = true;
                btn_delete.Enabled = true;
                btn_close.Enabled = true;

                var p = new Process
                {
                    StartInfo =
                    {
                        CreateNoWindow = false,
                        UseShellExecute = true,
                        WorkingDirectory = Main.ArmaBasePath,
                        FileName = Path.Combine(Main.ArmaBasePath, exeFile)
                    }
                };
                // Start install, wait for closes, then delete temp files
                p.Start();
                p.WaitForExit();
                File.Delete(DwnFile);
                File.Delete(Path.Combine(Main.ArmaBasePath, exeFile));
            }
            else
            {
                MessageBox.Show(e.Error.Message);
            }
        }

        private void btn_path1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Выберете путь до arma.exe";
            openFileDialog1.InitialDirectory = @"%PROGRAMFILES%"; // Open Program Files as start dir
            openFileDialog1.Filter = "Файл запуска Arma|arma2.exe";
            openFileDialog1.FileName = "arma2.exe";
            openFileDialog1.DefaultExt = "exe";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo path = new FileInfo(openFileDialog1.FileName);
                txtbox_arma1.Text = path.DirectoryName;
                Arma.UpdateArmaPath(path.DirectoryName, "arma");
            }
        }

        private void btn_path2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Выберете путь до arma2oa.exe";
            openFileDialog1.InitialDirectory = @"%PROGRAMFILES%"; // Open Program Files as start dir
            openFileDialog1.Filter = "Файл запуска Arma: OA|arma2oa.exe";
            openFileDialog1.FileName = "arma2oa.exe";
            openFileDialog1.DefaultExt = "exe";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo path = new FileInfo(openFileDialog1.FileName);
                txtbox_arma2.Text = path.DirectoryName;
                Arma.UpdateArmaPath(path.DirectoryName, "armaoa");
            }
        }
    }
}
