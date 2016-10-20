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
            this.lblIntro = new System.Windows.Forms.Label();
            this.txtMemberCode = new System.Windows.Forms.TextBox();
            this.btnCheckMemberStatus = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMemberCode = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
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
            // lblIntro
            // 
            this.lblIntro.BackColor = System.Drawing.Color.Transparent;
            this.lblIntro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntro.Location = new System.Drawing.Point(12, 139);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(270, 50);
            this.lblIntro.TabIndex = 1;
            this.lblIntro.Text = "Please enter member code to check its status.";
            this.lblIntro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Member Code: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Status:";
            // 
            // lblMemberCode
            // 
            this.lblMemberCode.AutoSize = true;
            this.lblMemberCode.Location = new System.Drawing.Point(152, 198);
            this.lblMemberCode.Name = "lblMemberCode";
            this.lblMemberCode.Size = new System.Drawing.Size(10, 13);
            this.lblMemberCode.TabIndex = 6;
            this.lblMemberCode.Text = "-";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(152, 222);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(10, 13);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "-";
            // 
            // ServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(294, 501);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblMemberCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCheckMemberStatus);
            this.Controls.Add(this.txtMemberCode);
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.label1);
            this.Name = "ServiceForm";
            this.Text = "ServiceForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.TextBox txtMemberCode;
        private System.Windows.Forms.Button btnCheckMemberStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMemberCode;
        private System.Windows.Forms.Label lblStatus;
    }
}