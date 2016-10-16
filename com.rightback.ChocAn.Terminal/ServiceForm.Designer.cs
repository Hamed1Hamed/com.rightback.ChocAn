namespace com.rightback.ChocAn.Terminal
{
    partial class ServiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lblMemberStatus = new System.Windows.Forms.Label();
            this.txtMemberCode = new System.Windows.Forms.TextBox();
            this.btnCheckMemberStatus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(106, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Member Code";
            // 
            // lblMemberStatus
            // 
            this.lblMemberStatus.AutoSize = true;
            this.lblMemberStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblMemberStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberStatus.Location = new System.Drawing.Point(40, 141);
            this.lblMemberStatus.Name = "lblMemberStatus";
            this.lblMemberStatus.Size = new System.Drawing.Size(207, 25);
            this.lblMemberStatus.TabIndex = 1;
            this.lblMemberStatus.Text = "MEMBERSSTATUS";
            this.lblMemberStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMemberCode
            // 
            this.txtMemberCode.Location = new System.Drawing.Point(76, 77);
            this.txtMemberCode.Name = "txtMemberCode";
            this.txtMemberCode.Size = new System.Drawing.Size(136, 20);
            this.txtMemberCode.TabIndex = 2;
            this.txtMemberCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCheckMemberStatus
            // 
            this.btnCheckMemberStatus.Location = new System.Drawing.Point(76, 103);
            this.btnCheckMemberStatus.Name = "btnCheckMemberStatus";
            this.btnCheckMemberStatus.Size = new System.Drawing.Size(136, 23);
            this.btnCheckMemberStatus.TabIndex = 3;
            this.btnCheckMemberStatus.Text = "Check Member";
            this.btnCheckMemberStatus.UseVisualStyleBackColor = true;
            this.btnCheckMemberStatus.Click += new System.EventHandler(this.btnCheckMemberStatus_Click);
            // 
            // ServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(295, 500);
            this.Controls.Add(this.btnCheckMemberStatus);
            this.Controls.Add(this.txtMemberCode);
            this.Controls.Add(this.lblMemberStatus);
            this.Controls.Add(this.label1);
            this.Name = "ServiceForm";
            this.Text = "ServiceForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMemberStatus;
        private System.Windows.Forms.TextBox txtMemberCode;
        private System.Windows.Forms.Button btnCheckMemberStatus;
    }
}