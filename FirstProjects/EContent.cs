using FirstProjects.econtactClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstProjects
{
    public partial class EContent : Form
    {
        #region othor
        public EContent()
        {
            InitializeComponent();
        }
        contactClass c = new contactClass();
        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Add
        private void btnAdd_Click(object sender, EventArgs e)
        {
            c.FirstName = textBoxFirstName.Text;
            c.LastName= textBoxLastName.Text;
            c.ContactNo= textBoxContactNo.Text;
            c.Address= textBoxAddress.Text;
            c.Gender = comboBoxGender.Text;
            bool success = c.insert(c);
            if (success = true)
            {
                MessageBox.Show("New Contant Successfully Inserted");
                Clear();
            }
            else
            {
                MessageBox.Show("New Contant Not Successfully Inserted");
            }

            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;

        }
        #endregion

        #region event
        private void dgvContactList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        #endregion

        #region Close
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Clear method
        public void Clear()
        {
            textBoxContactID.Text = "";
            textBoxFirstName.Text="";
            textBoxLastName.Text="";
            textBoxContactNo.Text = "";
            textBoxAddress.Text = "";
            comboBoxGender.Text = "";
        }
        #endregion

        #region Uodate
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            c.ContactID = int.Parse(textBoxContactID.Text);
            c.FirstName = textBoxFirstName.Text;
            c.LastName = textBoxLastName.Text;
            c.ContactNo = textBoxContactNo.Text;
            c.Address = textBoxAddress.Text;
            c.Gender = comboBoxGender.Text;
            bool success = c.update(c);
            if (success = true)
            {
                MessageBox.Show("Contant Successfully Updated");
                Clear();
            }
            else
            {
                MessageBox.Show("Contant Not Successfully Updated");
            }
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }
        

        private void dgvContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            textBoxContactID.Text = dgvContactList.Rows[row].Cells[0].Value.ToString();
            textBoxFirstName.Text= dgvContactList.Rows[row].Cells[1].Value.ToString();
            textBoxLastName.Text = dgvContactList.Rows[row].Cells[2].Value.ToString();
            textBoxContactNo.Text = dgvContactList.Rows[row].Cells[3].Value.ToString();
            textBoxAddress.Text = dgvContactList.Rows[row].Cells[4].Value.ToString();
            comboBoxGender.Text = dgvContactList.Rows[row].Cells[5].Value.ToString();

        }
        #endregion

        #region update
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        #endregion

        #region Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            c.ContactID = Convert.ToInt32(textBoxContactID.Text);
            bool success = c.Delete(c);
            if (success = true)
            {
                MessageBox.Show("Contant Successfully Deleted");
                Clear();
            }
            else
            {
                MessageBox.Show("Contant Not Successfully Deleted");
            }
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }
        #endregion

        #region Search
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBoxSearch.Text;
            SqlConnection conn = new SqlConnection(myconnstrng);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tbl_contact WHERE FirstName LIKE '%"+keyword+"%' OR LastName LIKE '%"+keyword+"%' OR Address LIKE '%"+keyword+"%' OR ContactNo LIKE '%"+keyword+"%'",conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvContactList.DataSource = dt;


        }
        #endregion
    }
}
