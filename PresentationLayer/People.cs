using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class People : Form
    {
        public People()
        {
            InitializeComponent();
        }

        private void _RefreshPeopleLV()
        {

            DataTable dtPeople = BusinessLayer.clsPeople.Find();

            lvPeople.Items.Clear();
            lvPeople.Columns.Clear();

            lvPeople.View = View.Details;

            foreach (DataColumn column in dtPeople.Columns)
            {
                lvPeople.Columns.Add(column.Caption);
            }

            foreach (DataRow row in dtPeople.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());

                for (int i = 1; i < dtPeople.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }

                lvPeople.Items.Add(item);
            }

            lvPeople.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            int CountListRows = lvPeople.Items.Count;

            lblCount.Text = CountListRows.ToString();
        }

        private void People_Load(object sender, EventArgs e)
        {
            _RefreshPeopleLV();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            
        }
    }
}
