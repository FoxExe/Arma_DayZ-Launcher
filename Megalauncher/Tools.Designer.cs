using Launcher.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace Launcher
{
    partial class Tools
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Button btn_delete;
        private Label txt_version_text;
        private Label txt_version2;
        private TextBox box_hexkey;
        private Label label1;
        private TextBox box_cdkey;
        private Label label2;
        private TextBox box_guid;
        private Label label5;
        private Label label3;
        private PictureBox headnav;
        private Timer timer1;
        private Button btn_close;
        private Button btn_changekey;
        private Label label4;
        private Label txt_version;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tools));
            this.box_hexkey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.box_cdkey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.box_guid = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txt_version = new System.Windows.Forms.Label();
            this.txt_version_text = new System.Windows.Forms.Label();
            this.txt_version2 = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_changekey = new System.Windows.Forms.Button();
            this.headnav = new System.Windows.Forms.PictureBox();
            this.btn_startUpdate = new System.Windows.Forms.Button();
            this.dwl_progress = new System.Windows.Forms.ProgressBar();
            this.txt_armaPath1 = new System.Windows.Forms.Label();
            this.txt_armaPath2 = new System.Windows.Forms.Label();
            this.txtbox_arma1 = new System.Windows.Forms.TextBox();
            this.txtbox_arma2 = new System.Windows.Forms.TextBox();
            this.btn_path1 = new System.Windows.Forms.Button();
            this.btn_path2 = new System.Windows.Forms.Button();
            this.cbox_useFree = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.headnav)).BeginInit();
            this.SuspendLayout();
            // 
            // box_hexkey
            // 
            this.box_hexkey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.box_hexkey.Location = new System.Drawing.Point(12, 90);
            this.box_hexkey.MaxLength = 255;
            this.box_hexkey.Name = "box_hexkey";
            this.box_hexkey.ReadOnly = true;
            this.box_hexkey.Size = new System.Drawing.Size(326, 20);
            this.box_hexkey.TabIndex = 2;
            this.box_hexkey.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "HEX-Key:";
            // 
            // box_cdkey
            // 
            this.box_cdkey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.box_cdkey.Location = new System.Drawing.Point(12, 51);
            this.box_cdkey.MaxLength = 255;
            this.box_cdkey.Name = "box_cdkey";
            this.box_cdkey.ReadOnly = true;
            this.box_cdkey.Size = new System.Drawing.Size(326, 20);
            this.box_cdkey.TabIndex = 1;
            this.box_cdkey.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "CD-Key:";
            // 
            // box_guid
            // 
            this.box_guid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.box_guid.Location = new System.Drawing.Point(12, 129);
            this.box_guid.MaxLength = 255;
            this.box_guid.Name = "box_guid";
            this.box_guid.ReadOnly = true;
            this.box_guid.Size = new System.Drawing.Size(326, 20);
            this.box_guid.TabIndex = 3;
            this.box_guid.WordWrap = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "GUID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(12, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Инструменты и информация";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 248);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Версия бетапатча:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_version
            // 
            this.txt_version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_version.AutoSize = true;
            this.txt_version.BackColor = System.Drawing.Color.Transparent;
            this.txt_version.ForeColor = System.Drawing.Color.White;
            this.txt_version.Location = new System.Drawing.Point(119, 248);
            this.txt_version.Margin = new System.Windows.Forms.Padding(0);
            this.txt_version.Name = "txt_version";
            this.txt_version.Size = new System.Drawing.Size(68, 13);
            this.txt_version.TabIndex = 18;
            this.txt_version.Text = "Проверяю...";
            this.txt_version.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_version_text
            // 
            this.txt_version_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_version_text.AutoSize = true;
            this.txt_version_text.BackColor = System.Drawing.Color.Transparent;
            this.txt_version_text.ForeColor = System.Drawing.Color.White;
            this.txt_version_text.Location = new System.Drawing.Point(12, 264);
            this.txt_version_text.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.txt_version_text.Name = "txt_version_text";
            this.txt_version_text.Size = new System.Drawing.Size(105, 13);
            this.txt_version_text.TabIndex = 20;
            this.txt_version_text.Text = "Последняя версия:";
            this.txt_version_text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_version2
            // 
            this.txt_version2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_version2.AutoSize = true;
            this.txt_version2.BackColor = System.Drawing.Color.Transparent;
            this.txt_version2.ForeColor = System.Drawing.Color.White;
            this.txt_version2.Location = new System.Drawing.Point(119, 264);
            this.txt_version2.Margin = new System.Windows.Forms.Padding(0);
            this.txt_version2.Name = "txt_version2";
            this.txt_version2.Size = new System.Drawing.Size(68, 13);
            this.txt_version2.TabIndex = 21;
            this.txt_version2.Text = "Проверяю...";
            this.txt_version2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.BackgroundImage = global::Launcher.Properties.Resources.btn_big_normal;
            this.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.btn_close.Location = new System.Drawing.Point(343, 282);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(105, 29);
            this.btn_close.TabIndex = 15;
            this.btn_close.Text = "Закрыть";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            this.btn_close.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_pressed);
            this.btn_close.MouseEnter += new System.EventHandler(this.btn_active);
            this.btn_close.MouseLeave += new System.EventHandler(this.btn_normal);
            this.btn_close.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_normal);
            // 
            // btn_delete
            // 
            this.btn_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_delete.BackColor = System.Drawing.Color.Transparent;
            this.btn_delete.BackgroundImage = global::Launcher.Properties.Resources.btn_big_normal;
            this.btn_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_delete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_delete.FlatAppearance.BorderSize = 0;
            this.btn_delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.btn_delete.Location = new System.Drawing.Point(176, 282);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(105, 29);
            this.btn_delete.TabIndex = 19;
            this.btn_delete.Text = "Перекачать мод";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            this.btn_delete.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_pressed);
            this.btn_delete.MouseEnter += new System.EventHandler(this.btn_active);
            this.btn_delete.MouseLeave += new System.EventHandler(this.btn_normal);
            this.btn_delete.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_normal);
            // 
            // btn_changekey
            // 
            this.btn_changekey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_changekey.BackColor = System.Drawing.Color.Transparent;
            this.btn_changekey.BackgroundImage = global::Launcher.Properties.Resources.btn_big_normal;
            this.btn_changekey.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_changekey.Enabled = false;
            this.btn_changekey.FlatAppearance.BorderSize = 0;
            this.btn_changekey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_changekey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_changekey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_changekey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.btn_changekey.Location = new System.Drawing.Point(344, 45);
            this.btn_changekey.Name = "btn_changekey";
            this.btn_changekey.Size = new System.Drawing.Size(105, 29);
            this.btn_changekey.TabIndex = 16;
            this.btn_changekey.Text = "Сохранить";
            this.btn_changekey.UseVisualStyleBackColor = false;
            this.btn_changekey.Visible = false;
            this.btn_changekey.Click += new System.EventHandler(this.btn_changekey_Click);
            this.btn_changekey.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_pressed);
            this.btn_changekey.MouseEnter += new System.EventHandler(this.btn_active);
            this.btn_changekey.MouseLeave += new System.EventHandler(this.btn_normal);
            this.btn_changekey.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_normal);
            // 
            // headnav
            // 
            this.headnav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.headnav.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.headnav.Dock = System.Windows.Forms.DockStyle.Top;
            this.headnav.Location = new System.Drawing.Point(0, 0);
            this.headnav.Name = "headnav";
            this.headnav.Size = new System.Drawing.Size(460, 32);
            this.headnav.TabIndex = 12;
            this.headnav.TabStop = false;
            this.headnav.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headnav_MouseDown);
            this.headnav.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headnav_MouseUp);
            // 
            // btn_startUpdate
            // 
            this.btn_startUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_startUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btn_startUpdate.BackgroundImage = global::Launcher.Properties.Resources.btn_big_normal;
            this.btn_startUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_startUpdate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_startUpdate.FlatAppearance.BorderSize = 0;
            this.btn_startUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_startUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_startUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_startUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_startUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.btn_startUpdate.Location = new System.Drawing.Point(12, 282);
            this.btn_startUpdate.Name = "btn_startUpdate";
            this.btn_startUpdate.Size = new System.Drawing.Size(105, 29);
            this.btn_startUpdate.TabIndex = 22;
            this.btn_startUpdate.Text = "Обн. бэта-патч";
            this.btn_startUpdate.UseVisualStyleBackColor = false;
            this.btn_startUpdate.Click += new System.EventHandler(this.btn_startUpdate_Click);
            this.btn_startUpdate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_pressed);
            this.btn_startUpdate.MouseEnter += new System.EventHandler(this.btn_active);
            this.btn_startUpdate.MouseLeave += new System.EventHandler(this.btn_normal);
            this.btn_startUpdate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_normal);
            // 
            // dwl_progress
            // 
            this.dwl_progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dwl_progress.Location = new System.Drawing.Point(13, 283);
            this.dwl_progress.Name = "dwl_progress";
            this.dwl_progress.Size = new System.Drawing.Size(436, 25);
            this.dwl_progress.Step = 1;
            this.dwl_progress.TabIndex = 23;
            this.dwl_progress.Visible = false;
            // 
            // txt_armaPath1
            // 
            this.txt_armaPath1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_armaPath1.AutoSize = true;
            this.txt_armaPath1.BackColor = System.Drawing.Color.Transparent;
            this.txt_armaPath1.ForeColor = System.Drawing.Color.Transparent;
            this.txt_armaPath1.Location = new System.Drawing.Point(12, 165);
            this.txt_armaPath1.Name = "txt_armaPath1";
            this.txt_armaPath1.Size = new System.Drawing.Size(76, 13);
            this.txt_armaPath1.TabIndex = 24;
            this.txt_armaPath1.Text = "Путь до Arma:";
            // 
            // txt_armaPath2
            // 
            this.txt_armaPath2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_armaPath2.AutoSize = true;
            this.txt_armaPath2.BackColor = System.Drawing.Color.Transparent;
            this.txt_armaPath2.ForeColor = System.Drawing.Color.Transparent;
            this.txt_armaPath2.Location = new System.Drawing.Point(12, 204);
            this.txt_armaPath2.Name = "txt_armaPath2";
            this.txt_armaPath2.Size = new System.Drawing.Size(94, 13);
            this.txt_armaPath2.TabIndex = 25;
            this.txt_armaPath2.Text = "Путь до Arma OA:";
            // 
            // txtbox_arma1
            // 
            this.txtbox_arma1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtbox_arma1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbox_arma1.Location = new System.Drawing.Point(12, 181);
            this.txtbox_arma1.MaxLength = 255;
            this.txtbox_arma1.Name = "txtbox_arma1";
            this.txtbox_arma1.ReadOnly = true;
            this.txtbox_arma1.Size = new System.Drawing.Size(326, 20);
            this.txtbox_arma1.TabIndex = 26;
            this.txtbox_arma1.WordWrap = false;
            // 
            // txtbox_arma2
            // 
            this.txtbox_arma2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtbox_arma2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbox_arma2.Location = new System.Drawing.Point(12, 220);
            this.txtbox_arma2.MaxLength = 255;
            this.txtbox_arma2.Name = "txtbox_arma2";
            this.txtbox_arma2.ReadOnly = true;
            this.txtbox_arma2.Size = new System.Drawing.Size(326, 20);
            this.txtbox_arma2.TabIndex = 27;
            this.txtbox_arma2.WordWrap = false;
            // 
            // btn_path1
            // 
            this.btn_path1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_path1.BackColor = System.Drawing.Color.Transparent;
            this.btn_path1.BackgroundImage = global::Launcher.Properties.Resources.btn_big_normal;
            this.btn_path1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_path1.FlatAppearance.BorderSize = 0;
            this.btn_path1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_path1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_path1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_path1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.btn_path1.Location = new System.Drawing.Point(343, 175);
            this.btn_path1.Name = "btn_path1";
            this.btn_path1.Size = new System.Drawing.Size(105, 29);
            this.btn_path1.TabIndex = 28;
            this.btn_path1.Text = "Обзор";
            this.btn_path1.UseVisualStyleBackColor = false;
            this.btn_path1.Click += new System.EventHandler(this.btn_path1_Click);
            this.btn_path1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_pressed);
            this.btn_path1.MouseEnter += new System.EventHandler(this.btn_active);
            this.btn_path1.MouseLeave += new System.EventHandler(this.btn_normal);
            this.btn_path1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_normal);
            // 
            // btn_path2
            // 
            this.btn_path2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_path2.BackColor = System.Drawing.Color.Transparent;
            this.btn_path2.BackgroundImage = global::Launcher.Properties.Resources.btn_big_normal;
            this.btn_path2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_path2.FlatAppearance.BorderSize = 0;
            this.btn_path2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_path2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_path2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_path2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.btn_path2.Location = new System.Drawing.Point(344, 214);
            this.btn_path2.Name = "btn_path2";
            this.btn_path2.Size = new System.Drawing.Size(105, 29);
            this.btn_path2.TabIndex = 29;
            this.btn_path2.Text = "Обзор";
            this.btn_path2.UseVisualStyleBackColor = false;
            this.btn_path2.Click += new System.EventHandler(this.btn_path2_Click);
            this.btn_path2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_pressed);
            this.btn_path2.MouseEnter += new System.EventHandler(this.btn_active);
            this.btn_path2.MouseLeave += new System.EventHandler(this.btn_normal);
            this.btn_path2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_normal);
            // 
            // cbox_useFree
            // 
            this.cbox_useFree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbox_useFree.AutoSize = true;
            this.cbox_useFree.BackColor = System.Drawing.Color.Transparent;
            this.cbox_useFree.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbox_useFree.ForeColor = System.Drawing.Color.White;
            this.cbox_useFree.Location = new System.Drawing.Point(165, 164);
            this.cbox_useFree.Name = "cbox_useFree";
            this.cbox_useFree.Size = new System.Drawing.Size(173, 17);
            this.cbox_useFree.TabIndex = 31;
            this.cbox_useFree.Text = "Использовать Free версию ?";
            this.cbox_useFree.UseVisualStyleBackColor = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Tools
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.CancelButton = this.btn_close;
            this.ClientSize = new System.Drawing.Size(460, 320);
            this.Controls.Add(this.cbox_useFree);
            this.Controls.Add(this.btn_path2);
            this.Controls.Add(this.btn_path1);
            this.Controls.Add(this.txtbox_arma2);
            this.Controls.Add(this.txtbox_arma1);
            this.Controls.Add(this.txt_armaPath2);
            this.Controls.Add(this.txt_armaPath1);
            this.Controls.Add(this.dwl_progress);
            this.Controls.Add(this.btn_startUpdate);
            this.Controls.Add(this.txt_version_text);
            this.Controls.Add(this.txt_version2);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.txt_version);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_changekey);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.box_guid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.box_cdkey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.box_hexkey);
            this.Controls.Add(this.headnav);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Tools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Инструменты";
            ((System.ComponentModel.ISupportInitialize)(this.headnav)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_startUpdate;
        private ProgressBar dwl_progress;
        private Label txt_armaPath1;
        private Label txt_armaPath2;
        private TextBox txtbox_arma1;
        private TextBox txtbox_arma2;
        private Button btn_path1;
        private Button btn_path2;
        private CheckBox cbox_useFree;
        private OpenFileDialog openFileDialog1;

    }
}