namespace DirectoryReplicate
{
    partial class frmReplicate
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
            this.lblSource = new System.Windows.Forms.Label();
            this.lblDestination = new System.Windows.Forms.Label();
            this.tbxSource = new System.Windows.Forms.TextBox();
            this.tbxDestination = new System.Windows.Forms.TextBox();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.btnBrowseDestination = new System.Windows.Forms.Button();
            this.btnReplicate = new System.Windows.Forms.Button();
            this.btnViewLog = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pbReplicate = new System.Windows.Forms.ProgressBar();
            this.cbxSubdirectories = new System.Windows.Forms.CheckBox();
            this.lblProgressBar = new System.Windows.Forms.Label();
            this.lblSourceError = new System.Windows.Forms.Label();
            this.lblDestinationError = new System.Windows.Forms.Label();
            this.frmReplicateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.frmReplicateBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(74, 38);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(60, 20);
            this.lblSource.TabIndex = 0;
            this.lblSource.Text = "Source";
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(44, 111);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(90, 20);
            this.lblDestination.TabIndex = 1;
            this.lblDestination.Text = "Destination";
            // 
            // tbxSource
            // 
            this.tbxSource.Location = new System.Drawing.Point(140, 35);
            this.tbxSource.Name = "tbxSource";
            this.tbxSource.ReadOnly = true;
            this.tbxSource.Size = new System.Drawing.Size(338, 26);
            this.tbxSource.TabIndex = 2;
            this.tbxSource.TabStop = false;
            // 
            // tbxDestination
            // 
            this.tbxDestination.Location = new System.Drawing.Point(140, 108);
            this.tbxDestination.Name = "tbxDestination";
            this.tbxDestination.ReadOnly = true;
            this.tbxDestination.Size = new System.Drawing.Size(338, 26);
            this.tbxDestination.TabIndex = 3;
            this.tbxDestination.TabStop = false;
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.Location = new System.Drawing.Point(501, 29);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(110, 38);
            this.btnBrowseSource.TabIndex = 1;
            this.btnBrowseSource.Text = "Browse";
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // btnBrowseDestination
            // 
            this.btnBrowseDestination.Location = new System.Drawing.Point(501, 102);
            this.btnBrowseDestination.Name = "btnBrowseDestination";
            this.btnBrowseDestination.Size = new System.Drawing.Size(110, 38);
            this.btnBrowseDestination.TabIndex = 2;
            this.btnBrowseDestination.Text = "Browse";
            this.btnBrowseDestination.UseVisualStyleBackColor = true;
            this.btnBrowseDestination.Click += new System.EventHandler(this.btnBrowseDestination_Click);
            // 
            // btnReplicate
            // 
            this.btnReplicate.Location = new System.Drawing.Point(140, 199);
            this.btnReplicate.Name = "btnReplicate";
            this.btnReplicate.Size = new System.Drawing.Size(110, 38);
            this.btnReplicate.TabIndex = 4;
            this.btnReplicate.Text = "&Replicate";
            this.btnReplicate.UseVisualStyleBackColor = true;
            this.btnReplicate.Click += new System.EventHandler(this.btnReplicate_Click);
            // 
            // btnViewLog
            // 
            this.btnViewLog.Location = new System.Drawing.Point(140, 327);
            this.btnViewLog.Name = "btnViewLog";
            this.btnViewLog.Size = new System.Drawing.Size(110, 38);
            this.btnViewLog.TabIndex = 5;
            this.btnViewLog.Text = "View &Log";
            this.btnViewLog.UseVisualStyleBackColor = true;
            this.btnViewLog.Click += new System.EventHandler(this.btnViewLog_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(501, 327);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 38);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pbReplicate
            // 
            this.pbReplicate.Location = new System.Drawing.Point(140, 261);
            this.pbReplicate.Name = "pbReplicate";
            this.pbReplicate.Size = new System.Drawing.Size(471, 38);
            this.pbReplicate.TabIndex = 9;
            // 
            // cbxSubdirectories
            // 
            this.cbxSubdirectories.AutoSize = true;
            this.cbxSubdirectories.Location = new System.Drawing.Point(140, 156);
            this.cbxSubdirectories.Name = "cbxSubdirectories";
            this.cbxSubdirectories.Size = new System.Drawing.Size(200, 24);
            this.cbxSubdirectories.TabIndex = 3;
            this.cbxSubdirectories.Text = "Include Sub Directories";
            this.cbxSubdirectories.UseVisualStyleBackColor = true;
            this.cbxSubdirectories.CheckedChanged += new System.EventHandler(this.cbxSubdirectories_CheckedChanged);
            // 
            // lblProgressBar
            // 
            this.lblProgressBar.AutoSize = true;
            this.lblProgressBar.Location = new System.Drawing.Point(33, 279);
            this.lblProgressBar.Name = "lblProgressBar";
            this.lblProgressBar.Size = new System.Drawing.Size(101, 20);
            this.lblProgressBar.TabIndex = 11;
            this.lblProgressBar.Text = "Progress Bar";
            // 
            // lblSourceError
            // 
            this.lblSourceError.AutoSize = true;
            this.lblSourceError.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSourceError.Location = new System.Drawing.Point(140, 9);
            this.lblSourceError.Name = "lblSourceError";
            this.lblSourceError.Size = new System.Drawing.Size(174, 20);
            this.lblSourceError.TabIndex = 999;
            this.lblSourceError.Text = "Directory does not exist";
            this.lblSourceError.Visible = false;
            // 
            // lblDestinationError
            // 
            this.lblDestinationError.AutoSize = true;
            this.lblDestinationError.ForeColor = System.Drawing.Color.DarkRed;
            this.lblDestinationError.Location = new System.Drawing.Point(140, 85);
            this.lblDestinationError.Name = "lblDestinationError";
            this.lblDestinationError.Size = new System.Drawing.Size(174, 20);
            this.lblDestinationError.TabIndex = 13;
            this.lblDestinationError.Text = "Directory does not exist";
            this.lblDestinationError.Visible = false;
            // 
            // frmReplicateBindingSource
            // 
            this.frmReplicateBindingSource.DataSource = typeof(DirectoryReplicate.frmReplicate);
            // 
            // frmReplicate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 381);
            this.Controls.Add(this.lblDestinationError);
            this.Controls.Add(this.lblSourceError);
            this.Controls.Add(this.lblProgressBar);
            this.Controls.Add(this.cbxSubdirectories);
            this.Controls.Add(this.pbReplicate);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnViewLog);
            this.Controls.Add(this.btnReplicate);
            this.Controls.Add(this.btnBrowseDestination);
            this.Controls.Add(this.btnBrowseSource);
            this.Controls.Add(this.tbxDestination);
            this.Controls.Add(this.tbxSource);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.lblSource);
            this.Name = "frmReplicate";
            this.Text = "Replicate";
            ((System.ComponentModel.ISupportInitialize)(this.frmReplicateBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.TextBox tbxSource;
        private System.Windows.Forms.TextBox tbxDestination;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.Button btnBrowseDestination;
        private System.Windows.Forms.Button btnReplicate;
        private System.Windows.Forms.Button btnViewLog;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ProgressBar pbReplicate;
        private System.Windows.Forms.CheckBox cbxSubdirectories;
        private System.Windows.Forms.Label lblProgressBar;
        private System.Windows.Forms.BindingSource frmReplicateBindingSource;
        private System.Windows.Forms.Label lblSourceError;
        private System.Windows.Forms.Label lblDestinationError;
    }
}

