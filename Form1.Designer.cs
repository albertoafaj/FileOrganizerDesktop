namespace FileOrganizerDesktop
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnCleanDirectories;
        private System.Windows.Forms.Button btnSelectCleaning;
        private System.Windows.Forms.Label lblDirCleaning;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblOrigin = new System.Windows.Forms.Label();
            this.txtOrigin = new System.Windows.Forms.TextBox();
            this.btnOrigin = new System.Windows.Forms.Button();
            this.lblDestination = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.btnDestination = new System.Windows.Forms.Button();
            this.lblExtension = new System.Windows.Forms.Label();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lstLog = new System.Windows.Forms.ListBox();

            this.lblDirCleaning = new System.Windows.Forms.Label();
            this.btnSelectCleaning = new System.Windows.Forms.Button();
            this.btnCleanDirectories = new System.Windows.Forms.Button();

            this.SuspendLayout();
            // 
            // lblOrigin
            // 
            this.lblOrigin.AutoSize = true;
            this.lblOrigin.Location = new System.Drawing.Point(12, 15);
            this.lblOrigin.Name = "lblOrigin";
            this.lblOrigin.Size = new System.Drawing.Size(92, 13);
            this.lblOrigin.TabIndex = 0;
            this.lblOrigin.Text = "Diretório de origem:";
            // 
            // txtOrigin
            // 
            this.txtOrigin.Location = new System.Drawing.Point(15, 31);
            this.txtOrigin.Name = "txtOrigin";
            this.txtOrigin.Size = new System.Drawing.Size(430, 20);
            this.txtOrigin.TabIndex = 1;
            // 
            // btnOrigin
            // 
            this.btnOrigin.Location = new System.Drawing.Point(451, 29);
            this.btnOrigin.Name = "btnOrigin";
            this.btnOrigin.Size = new System.Drawing.Size(75, 23);
            this.btnOrigin.TabIndex = 2;
            this.btnOrigin.Text = "Selecionar";
            this.btnOrigin.UseVisualStyleBackColor = true;
            this.btnOrigin.Click += new System.EventHandler(this.btnOrigin_Click);
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(12, 68);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(94, 13);
            this.lblDestination.TabIndex = 3;
            this.lblDestination.Text = "Diretório de destino:";
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(15, 84);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(430, 20);
            this.txtDestination.TabIndex = 4;
            // 
            // btnDestination
            // 
            this.btnDestination.Location = new System.Drawing.Point(451, 82);
            this.btnDestination.Name = "btnDestination";
            this.btnDestination.Size = new System.Drawing.Size(75, 23);
            this.btnDestination.TabIndex = 5;
            this.btnDestination.Text = "Selecionar";
            this.btnDestination.UseVisualStyleBackColor = true;
            this.btnDestination.Click += new System.EventHandler(this.btnDestination_Click);
            // 
            // lblExtension
            // 
            this.lblExtension.AutoSize = true;
            this.lblExtension.Location = new System.Drawing.Point(12, 122);
            this.lblExtension.Name = "lblExtension";
            this.lblExtension.Size = new System.Drawing.Size(95, 13);
            this.lblExtension.TabIndex = 6;
            this.lblExtension.Text = "Extensão (ex: .txt):";
            // 
            // txtExtension
            // 
            this.txtExtension.Location = new System.Drawing.Point(15, 138);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(100, 20);
            this.txtExtension.TabIndex = 7;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(15, 175);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(511, 30);
            this.btnProcess.TabIndex = 8;
            this.btnProcess.Text = "Processar Arquivos";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lstLog
            // 
            this.lstLog.FormattingEnabled = true;
            this.lstLog.HorizontalScrollbar = true;
            this.lstLog.Location = new System.Drawing.Point(15, 300);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(511, 225);
            this.lstLog.TabIndex = 9;
            // 
            // lblDirCleaning
            // 
            this.lblDirCleaning.AutoSize = true;
            this.lblDirCleaning.Location = new System.Drawing.Point(15, 220);
            this.lblDirCleaning.Name = "lblDirCleaning";
            this.lblDirCleaning.Size = new System.Drawing.Size(180, 13);
            this.lblDirCleaning.TabIndex = 10;
            this.lblDirCleaning.Text = "Diretório para limpar pastas vazias: -";
            // 
            // btnSelectCleaning
            // 
            this.btnSelectCleaning.Location = new System.Drawing.Point(15, 240);
            this.btnSelectCleaning.Name = "btnSelectCleaning";
            this.btnSelectCleaning.Size = new System.Drawing.Size(150, 28);
            this.btnSelectCleaning.TabIndex = 11;
            this.btnSelectCleaning.Text = "Selecionar diretório";
            this.btnSelectCleaning.UseVisualStyleBackColor = true;
            this.btnSelectCleaning.Click += new System.EventHandler(this.btnSelectCleaning_Click);
            // 
            // btnCleanDirectories
            // 
            this.btnCleanDirectories.Location = new System.Drawing.Point(180, 240);
            this.btnCleanDirectories.Name = "btnCleanDirectories";
            this.btnCleanDirectories.Size = new System.Drawing.Size(180, 28);
            this.btnCleanDirectories.TabIndex = 12;
            this.btnCleanDirectories.Text = "Excluir pastas vazias";
            this.btnCleanDirectories.UseVisualStyleBackColor = true;
            this.btnCleanDirectories.Click += new System.EventHandler(this.btnCleanDiretctories_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(542, 540);
            this.Controls.Add(this.btnCleanDirectories);
            this.Controls.Add(this.btnSelectCleaning);
            this.Controls.Add(this.lblDirCleaning);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.txtExtension);
            this.Controls.Add(this.lblExtension);
            this.Controls.Add(this.btnDestination);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.btnOrigin);
            this.Controls.Add(this.txtOrigin);
            this.Controls.Add(this.lblOrigin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Organizador de Arquivos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblOrigin;
        private System.Windows.Forms.TextBox txtOrigin;
        private System.Windows.Forms.Button btnOrigin;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Button btnDestination;
        private System.Windows.Forms.Label lblExtension;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.ListBox lstLog;
    }
}
