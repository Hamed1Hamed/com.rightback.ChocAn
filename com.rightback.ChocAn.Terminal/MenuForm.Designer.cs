namespace com.rightback.ChocAn.Terminal
{
    partial class MenuForm
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
            this.btnService = new System.Windows.Forms.Button();
            this.btnClaimConfirm = new System.Windows.Forms.Button();
            this.btnServiceDirectory = new System.Windows.Forms.Button();
            this.btnTurnOff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnService
            // 
            this.btnService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnService.ForeColor = System.Drawing.Color.White;
            this.btnService.Location = new System.Drawing.Point(29, 107);
            this.btnService.Name = "btnService";
            this.btnService.Size = new System.Drawing.Size(288, 70);
            this.btnService.TabIndex = 23;
            this.btnService.Text = "Record Service";
            this.btnService.UseVisualStyleBackColor = false;
            this.btnService.Click += new System.EventHandler(this.btnService_Click);
            // 
            // btnClaimConfirm
            // 
            this.btnClaimConfirm.BackColor = System.Drawing.Color.Blue;
            this.btnClaimConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClaimConfirm.ForeColor = System.Drawing.Color.White;
            this.btnClaimConfirm.Location = new System.Drawing.Point(29, 188);
            this.btnClaimConfirm.Name = "btnClaimConfirm";
            this.btnClaimConfirm.Size = new System.Drawing.Size(288, 70);
            this.btnClaimConfirm.TabIndex = 24;
            this.btnClaimConfirm.Text = "Enter Claim Confirmation";
            this.btnClaimConfirm.UseVisualStyleBackColor = false;
            this.btnClaimConfirm.Click += new System.EventHandler(this.btnClaimConfirm_Click);
            // 
            // btnServiceDirectory
            // 
            this.btnServiceDirectory.BackColor = System.Drawing.Color.Olive;
            this.btnServiceDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServiceDirectory.ForeColor = System.Drawing.Color.White;
            this.btnServiceDirectory.Location = new System.Drawing.Point(29, 268);
            this.btnServiceDirectory.Name = "btnServiceDirectory";
            this.btnServiceDirectory.Size = new System.Drawing.Size(288, 70);
            this.btnServiceDirectory.TabIndex = 25;
            this.btnServiceDirectory.Text = "Request Service Directory";
            this.btnServiceDirectory.UseVisualStyleBackColor = false;
            this.btnServiceDirectory.Click += new System.EventHandler(this.btnServiceDirectory_Click);
            // 
            // btnTurnOff
            // 
            this.btnTurnOff.BackColor = System.Drawing.Color.Maroon;
            this.btnTurnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTurnOff.ForeColor = System.Drawing.Color.White;
            this.btnTurnOff.Location = new System.Drawing.Point(29, 351);
            this.btnTurnOff.Name = "btnTurnOff";
            this.btnTurnOff.Size = new System.Drawing.Size(288, 70);
            this.btnTurnOff.TabIndex = 26;
            this.btnTurnOff.Text = "Turn Off";
            this.btnTurnOff.UseVisualStyleBackColor = false;
            this.btnTurnOff.Click += new System.EventHandler(this.btnTurnOff_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::com.rightback.ChocAn.Terminal.Properties.Resources.terminal;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(348, 557);
            this.Controls.Add(this.btnTurnOff);
            this.Controls.Add(this.btnServiceDirectory);
            this.Controls.Add(this.btnClaimConfirm);
            this.Controls.Add(this.btnService);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnService;
        private System.Windows.Forms.Button btnClaimConfirm;
        private System.Windows.Forms.Button btnServiceDirectory;
        private System.Windows.Forms.Button btnTurnOff;
    }
}