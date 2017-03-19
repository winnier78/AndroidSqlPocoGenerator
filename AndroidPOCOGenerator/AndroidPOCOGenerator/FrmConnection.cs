using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndroidPOCOGenerator
{
    public partial class FrmConnection : Form
    {
        public FrmConnection()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (Connect())
                {
                    SgBase.Instance.DBType = SgBase.toString(cmbDbTypes.SelectedItem);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
               

                if (Connect())
                {
                    MessageBox.Show("Test Successful");
                }
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Test conexion
        /// </summary>
        private bool Connect()
        {
            try
            {
                bool connected = false;

                if (txtServer.Text.Length == 0)
                {
                    MessageBox.Show("Especify Server");
                    txtServer.Focus();
                    return connected;
                }

                if (SgBase.toString(cmbDbTypes.SelectedItem) != SgBase.DataBases.MsSql.ToString() || !ckIntegrated.Checked)
                {
                    if (txtUser.Text.Length == 0)
                    {
                        MessageBox.Show("Especify User");
                        txtUser.Focus();
                        return connected;
                    }
                }

                switch (SgBase.toString(cmbDbTypes.SelectedItem))
                {
                    case "MsSql":
                        connected = SgMsSqlCon.Connect(txtServer.Text,txtUser.Text,txtPassword.Text,ckIntegrated.Checked,txtCatalog.Text);
                        break;
                    case "Oracle":
                        break;
                    case "Sqlite":
                        break;
                    default:
                        break;
                }

                return connected;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void FrmConnection_Load(object sender, EventArgs e)
        {
            try
            {
                cmbDbTypes.Items.Add(SgBase.DataBases.MsSql.ToString());
                cmbDbTypes.Items.Add(SgBase.DataBases.Oracle.ToString());
                cmbDbTypes.Items.Add(SgBase.DataBases.Sqlite.ToString());

                cmbDbTypes.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cmbDbTypes_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SgBase.toString(cmbDbTypes.SelectedItem) == SgBase.DataBases.MsSql.ToString())
                {
                    ckIntegrated.Visible = true;
                }
                else
                {
                    ckIntegrated.Visible = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
