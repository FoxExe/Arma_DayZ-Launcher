using Launcher.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace Launcher
{
    partial class Main
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private PictureBox btn_tools_full;
        private Label lblStatus;
        private ProgressBar progressBar1;
        private FolderBrowserDialog folderBrowserDialog1;
        private WebBrowser webBrowser1;
        private PictureBox headnav;
        private Timer timer1;
        private PictureBox btn_close;
        private PictureBox btn_min;
        private Button btn_launch;
        private Button btn_site;
        private Button btn_tools;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label headerText;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.headnav = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_close = new System.Windows.Forms.PictureBox();
            this.btn_min = new System.Windows.Forms.PictureBox();
            this.btn_launch = new System.Windows.Forms.Button();
            this.btn_site = new System.Windows.Forms.Button();
            this.btn_tools = new System.Windows.Forms.Button();
            this.btn_tools_full = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            headerText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.headnav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_tools_full)).BeginInit();
            this.SuspendLayout();
            // 
            // headerText
            // 
            headerText.AutoSize = true;
            headerText.BackColor = System.Drawing.Color.Transparent;
            headerText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            headerText.ForeColor = System.Drawing.Color.Gray;
            headerText.Location = new System.Drawing.Point(6, 6);
            headerText.Name = "headerText";
            headerText.Size = new System.Drawing.Size(177, 16);
            headerText.TabIndex = 17;
            headerText.Text = "Dayz mod Launcher";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.ForeColor = System.Drawing.Color.Silver;
            this.lblStatus.Location = new System.Drawing.Point(6, 436);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Запуск...";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar1.Location = new System.Drawing.Point(7, 452);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(448, 16);
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Visible = false;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.SelectedPath = "%ProgramFiles%";
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(7, 38);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(785, 384);
            this.webBrowser1.TabIndex = 7;
            this.webBrowser1.Url = new System.Uri("http://anionix.ru", System.UriKind.Absolute);
            this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser1_Navigating);
            // 
            // headnav
            // 
            this.headnav.BackColor = System.Drawing.Color.Transparent;
            this.headnav.Dock = System.Windows.Forms.DockStyle.Top;
            this.headnav.Location = new System.Drawing.Point(0, 0);
            this.headnav.Name = "headnav";
            this.headnav.Size = new System.Drawing.Size(800, 32);
            this.headnav.TabIndex = 8;
            this.headnav.TabStop = false;
            this.headnav.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headnav_MouseDown);
            this.headnav.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headnav_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_close.Image = global::Launcher.Properties.Resources.btn_close_normal;
            this.btn_close.Location = new System.Drawing.Point(779, 7);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(13, 12);
            this.btn_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_close.TabIndex = 11;
            this.btn_close.TabStop = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            this.btn_close.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_close_pressed);
            this.btn_close.MouseEnter += new System.EventHandler(this.btn_close_hover);
            this.btn_close.MouseLeave += new System.EventHandler(this.btn_close_normal);
            this.btn_close.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_close_normal);
            // 
            // btn_min
            // 
            this.btn_min.BackColor = System.Drawing.Color.Transparent;
            this.btn_min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_min.Image = global::Launcher.Properties.Resources.btn_minimise_normal;
            this.btn_min.Location = new System.Drawing.Point(760, 7);
            this.btn_min.Name = "btn_min";
            this.btn_min.Size = new System.Drawing.Size(13, 12);
            this.btn_min.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_min.TabIndex = 12;
            this.btn_min.TabStop = false;
            this.btn_min.Click += new System.EventHandler(this.btn_min_Click);
            this.btn_min.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_min_pressed);
            this.btn_min.MouseEnter += new System.EventHandler(this.btn_min_hover);
            this.btn_min.MouseLeave += new System.EventHandler(this.btn_min_normal);
            this.btn_min.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_min_normal);
            // 
            // btn_launch
            // 
            this.btn_launch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_launch.BackColor = System.Drawing.Color.Transparent;
            this.btn_launch.BackgroundImage = global::Launcher.Properties.Resources.btn_big_normal;
            this.btn_launch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_launch.FlatAppearance.BorderSize = 0;
            this.btn_launch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_launch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_launch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_launch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.btn_launch.Location = new System.Drawing.Point(687, 439);
            this.btn_launch.Name = "btn_launch";
            this.btn_launch.Size = new System.Drawing.Size(105, 29);
            this.btn_launch.TabIndex = 14;
            this.btn_launch.Text = "Запустить";
            this.btn_launch.UseVisualStyleBackColor = false;
            this.btn_launch.Click += new System.EventHandler(this.btn_launch_Click);
            this.btn_launch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_pressed);
            this.btn_launch.MouseEnter += new System.EventHandler(this.btn_active);
            this.btn_launch.MouseLeave += new System.EventHandler(this.btn_normal);
            this.btn_launch.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_normal);
            // 
            // btn_site
            // 
            this.btn_site.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_site.BackColor = System.Drawing.Color.Transparent;
            this.btn_site.BackgroundImage = global::Launcher.Properties.Resources.btn_big_normal;
            this.btn_site.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_site.FlatAppearance.BorderSize = 0;
            this.btn_site.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_site.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_site.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_site.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.btn_site.Location = new System.Drawing.Point(576, 439);
            this.btn_site.Name = "btn_site";
            this.btn_site.Size = new System.Drawing.Size(105, 29);
            this.btn_site.TabIndex = 15;
            this.btn_site.Text = "На сайт";
            this.btn_site.UseVisualStyleBackColor = false;
            this.btn_site.Click += new System.EventHandler(this.btn_site_Click);
            this.btn_site.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_pressed);
            this.btn_site.MouseEnter += new System.EventHandler(this.btn_active);
            this.btn_site.MouseLeave += new System.EventHandler(this.btn_normal);
            this.btn_site.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_normal);
            // 
            // btn_tools
            // 
            this.btn_tools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_tools.BackColor = System.Drawing.Color.Transparent;
            this.btn_tools.BackgroundImage = global::Launcher.Properties.Resources.btn_big_normal;
            this.btn_tools.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_tools.FlatAppearance.BorderSize = 0;
            this.btn_tools.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_tools.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_tools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tools.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.btn_tools.Location = new System.Drawing.Point(465, 439);
            this.btn_tools.Name = "btn_tools";
            this.btn_tools.Size = new System.Drawing.Size(105, 29);
            this.btn_tools.TabIndex = 16;
            this.btn_tools.Text = "Инструменты";
            this.btn_tools.UseVisualStyleBackColor = false;
            this.btn_tools.Click += new System.EventHandler(this.btn_tools_Click);
            this.btn_tools.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_pressed);
            this.btn_tools.MouseEnter += new System.EventHandler(this.btn_active);
            this.btn_tools.MouseLeave += new System.EventHandler(this.btn_normal);
            this.btn_tools.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_normal);
            // 
            // btn_tools_full
            // 
            this.btn_tools_full.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_tools_full.BackColor = System.Drawing.Color.Transparent;
            this.btn_tools_full.Location = new System.Drawing.Point(459, 464);
            this.btn_tools_full.Name = "btn_tools_full";
            this.btn_tools_full.Size = new System.Drawing.Size(3, 3);
            this.btn_tools_full.TabIndex = 18;
            this.btn_tools_full.TabStop = false;
            this.btn_tools_full.Click += new System.EventHandler(this.btn_tools_full_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Лаунчер ожидает завершения игры";
            this.notifyIcon1.BalloonTipTitle = "Я здесь !";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Dayz mod Launcher";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(355, 428);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.Text = "Выбор сервера";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Launcher.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_tools_full);
            this.Controls.Add(headerText);
            this.Controls.Add(this.btn_tools);
            this.Controls.Add(this.btn_site);
            this.Controls.Add(this.btn_launch);
            this.Controls.Add(this.btn_min);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.headnav);
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dayz mod Launcher";
            this.Load += new System.EventHandler(this.StartUp);
            ((System.ComponentModel.ISupportInitialize)(this.headnav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_tools_full)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NotifyIcon notifyIcon1;
        private ComboBox comboBox1;

        

    }
}

