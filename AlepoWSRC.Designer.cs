using System;

namespace AlepoWSRC
{
    partial class AlepoWSRC
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlepoWSRC));
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.mainPanel = new Guna.UI.WinForms.GunaGradient2Panel();
            this.loadProgress = new Guna.UI.WinForms.GunaProgressBar();
            this.lblDesc = new Guna.UI.WinForms.GunaLabel();
            this.lblDataUsage = new Guna.UI.WinForms.GunaLabel();
            this.iconPic = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.AlepoWSRCTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.AlepoMenu = new Guna.UI.WinForms.GunaContextMenuStrip();
            this.showUsageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPic)).BeginInit();
            this.AlepoMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.TargetControl = this;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Black;
            this.mainPanel.Controls.Add(this.loadProgress);
            this.mainPanel.Controls.Add(this.lblDesc);
            this.mainPanel.Controls.Add(this.lblDataUsage);
            this.mainPanel.Controls.Add(this.iconPic);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(21)))), ((int)(((byte)(38)))));
            this.mainPanel.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(48)))), ((int)(((byte)(80)))));
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(250, 100);
            this.mainPanel.TabIndex = 3;
            // 
            // loadProgress
            // 
            this.loadProgress.BackColor = System.Drawing.Color.Transparent;
            this.loadProgress.BorderColor = System.Drawing.Color.Black;
            this.loadProgress.ColorStyle = Guna.UI.WinForms.ColorStyle.Default;
            this.loadProgress.IdleColor = System.Drawing.Color.Gainsboro;
            this.loadProgress.Location = new System.Drawing.Point(53, 76);
            this.loadProgress.Name = "loadProgress";
            this.loadProgress.ProgressMaxColor = System.Drawing.Color.RoyalBlue;
            this.loadProgress.ProgressMinColor = System.Drawing.Color.CornflowerBlue;
            this.loadProgress.Radius = 1;
            this.loadProgress.Size = new System.Drawing.Size(152, 5);
            this.loadProgress.TabIndex = 10;
            this.loadProgress.Value = 10;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblDesc.Font = new System.Drawing.Font("Roboto Lt", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(138)))), ((int)(((byte)(171)))));
            this.lblDesc.Location = new System.Drawing.Point(99, 53);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(109, 14);
            this.lblDesc.TabIndex = 9;
            this.lblDesc.Text = "Remaining Volume";
            // 
            // lblDataUsage
            // 
            this.lblDataUsage.AutoSize = true;
            this.lblDataUsage.BackColor = System.Drawing.Color.Transparent;
            this.lblDataUsage.Font = new System.Drawing.Font("Roboto Lt", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataUsage.ForeColor = System.Drawing.Color.White;
            this.lblDataUsage.Location = new System.Drawing.Point(99, 24);
            this.lblDataUsage.Name = "lblDataUsage";
            this.lblDataUsage.Size = new System.Drawing.Size(91, 25);
            this.lblDataUsage.TabIndex = 8;
            this.lblDataUsage.Text = "1.13 TB";
            // 
            // iconPic
            // 
            this.iconPic.BackColor = System.Drawing.Color.Transparent;
            this.iconPic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("iconPic.BackgroundImage")));
            this.iconPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconPic.BaseColor = System.Drawing.Color.White;
            this.iconPic.InitialImage = null;
            this.iconPic.Location = new System.Drawing.Point(43, 20);
            this.iconPic.Name = "iconPic";
            this.iconPic.Size = new System.Drawing.Size(50, 50);
            this.iconPic.TabIndex = 7;
            this.iconPic.TabStop = false;
            this.iconPic.Click += new System.EventHandler(this.iconPic_Click);
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = this.mainPanel;
            // 
            // AlepoWSRCTray
            // 
            this.AlepoWSRCTray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.AlepoWSRCTray.BalloonTipText = "AlepoWSRCTray";
            this.AlepoWSRCTray.BalloonTipTitle = "AlepoWSRCTray";
            this.AlepoWSRCTray.ContextMenuStrip = this.AlepoMenu;
            this.AlepoWSRCTray.Icon = ((System.Drawing.Icon)(resources.GetObject("AlepoWSRCTray.Icon")));
            this.AlepoWSRCTray.Text = "AlepoWSRC";
            this.AlepoWSRCTray.Visible = true;
            this.AlepoWSRCTray.DoubleClick += new System.EventHandler(this.AlepoWSRCTray_DoubleClick);
            // 
            // AlepoMenu
            // 
            this.AlepoMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showUsageToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.AlepoMenu.Name = "AlepoMenu";
            this.AlepoMenu.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.AlepoMenu.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.AlepoMenu.RenderStyle.ColorTable = null;
            this.AlepoMenu.RenderStyle.RoundedEdges = true;
            this.AlepoMenu.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.AlepoMenu.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.AlepoMenu.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.AlepoMenu.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.AlepoMenu.RenderStyle.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.SystemDefault;
            this.AlepoMenu.Size = new System.Drawing.Size(181, 70);
            // 
            // showUsageToolStripMenuItem
            // 
            this.showUsageToolStripMenuItem.Name = "showUsageToolStripMenuItem";
            this.showUsageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showUsageToolStripMenuItem.Text = "Show Usage";
            this.showUsageToolStripMenuItem.Click += new System.EventHandler(this.showUsageToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // AlepoWSRC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(250, 100);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AlepoWSRC";
            this.Text = "AlepoWSRC";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AlepoWSRC_Load);
            this.Shown += new System.EventHandler(this.AlepoWSRC_Shown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPic)).EndInit();
            this.AlepoMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

    

        #endregion

        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaGradient2Panel mainPanel;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
        private Guna.UI.WinForms.GunaProgressBar loadProgress;
        private Guna.UI.WinForms.GunaLabel lblDesc;
        private Guna.UI.WinForms.GunaLabel lblDataUsage;
        private Guna.UI.WinForms.GunaPictureBox iconPic;
        private System.Windows.Forms.NotifyIcon AlepoWSRCTray;
        private Guna.UI.WinForms.GunaContextMenuStrip AlepoMenu;
        private System.Windows.Forms.ToolStripMenuItem showUsageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}

