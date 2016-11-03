using com.rightback.ChocAn.Terminal.com.rightback.webservices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace com.rightback.ChocAn.Terminal
{
    public partial class ServiceCodesForm : Form
    {

        private ServiceViewModel[] serviceCodes;

        private String selectedServiceCode;

        public ServiceCodesForm()
        {
            InitializeComponent();
        }

        public String getSelectedServiceCode()
        {
            return this.selectedServiceCode;
        }

        private void ServiceCodesForm_Load(object sender, EventArgs e)
        { 
            this.bindData();      
        }

        private void bindData()
        {
            this.bindData(String.Empty);
        }

        private void bindData(String searchString)
        {
            //load services
            if (this.serviceCodes == null)
            {
                TerminalService terminalService = new TerminalService();
                this.serviceCodes = terminalService.getServices();
            }

            List<ServiceViewModel> filteredList = new List<ServiceViewModel>(this.serviceCodes);

            //filter codes
            if (!String.IsNullOrWhiteSpace(searchString))
            {
                filteredList = filteredList
                    .Where(c => c.Code.StartsWith(searchString))
                    .ToList();
            }



            gvServiceCodes.DataSource = filteredList;
        }

        private void txtServiceCode_TextChanged(object sender, EventArgs e)
        {
            this.bindData(txtServiceCode.Text);


        }

        private void gvServiceCodes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;

          this.closeWithSelection( gvServiceCodes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
        }

        private void txtServiceCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Return)
            {
                if(!String.IsNullOrWhiteSpace(txtServiceCode.Text) && txtServiceCode.Text.Length==6)
                {
                    this.closeWithSelection(txtServiceCode.Text);
                    
                }
            }
        }

        private void closeWithSelection(String selection)
        {
            this.selectedServiceCode = selection;
            this.Close();
        }
    }
}
