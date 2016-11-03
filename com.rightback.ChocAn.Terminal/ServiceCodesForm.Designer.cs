namespace com.rightback.ChocAn.Terminal
{
    partial class ServiceCodesForm
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
            this.gvServiceCodes = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceCodeSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtServiceCode = new System.Windows.Forms.TextBox();
            this.lblServiceCode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvServiceCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceCodeSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gvServiceCodes
            // 
            this.gvServiceCodes.AllowUserToAddRows = false;
            this.gvServiceCodes.AllowUserToDeleteRows = false;
            this.gvServiceCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvServiceCodes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.gvServiceCodes.Location = new System.Drawing.Point(22, 58);
            this.gvServiceCodes.Name = "gvServiceCodes";
            this.gvServiceCodes.ReadOnly = true;
            this.gvServiceCodes.Size = new System.Drawing.Size(369, 148);
            this.gvServiceCodes.TabIndex = 0;
            this.gvServiceCodes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvServiceCodes_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Code";
            this.dataGridViewTextBoxColumn1.HeaderText = "Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // serviceCodeSource
            // 
            this.serviceCodeSource.AllowNew = false;
            // 
            // txtServiceCode
            // 
            this.txtServiceCode.Location = new System.Drawing.Point(93, 29);
            this.txtServiceCode.Name = "txtServiceCode";
            this.txtServiceCode.Size = new System.Drawing.Size(155, 20);
            this.txtServiceCode.TabIndex = 1;
            this.txtServiceCode.TextChanged += new System.EventHandler(this.txtServiceCode_TextChanged);
            this.txtServiceCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServiceCode_KeyPress);
            // 
            // lblServiceCode
            // 
            this.lblServiceCode.AutoSize = true;
            this.lblServiceCode.Location = new System.Drawing.Point(19, 32);
            this.lblServiceCode.Name = "lblServiceCode";
            this.lblServiceCode.Size = new System.Drawing.Size(68, 13);
            this.lblServiceCode.TabIndex = 2;
            this.lblServiceCode.Text = "ServiceCode";
            // 
            // ServiceCodesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 380);
            this.Controls.Add(this.lblServiceCode);
            this.Controls.Add(this.txtServiceCode);
            this.Controls.Add(this.gvServiceCodes);
            this.Name = "ServiceCodesForm";
            this.Text = "ServiceCodesForm";
            this.Load += new System.EventHandler(this.ServiceCodesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvServiceCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceCodeSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvServiceCodes;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.BindingSource serviceCodeSource;
        private System.Windows.Forms.TextBox txtServiceCode;
        private System.Windows.Forms.Label lblServiceCode;
    }
}