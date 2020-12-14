using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoProject
{
    public partial class AddEditService : Form
    {
        public Form Previous { get; }

        public AddEditService(Form previous)
        {
            InitializeComponent();
            Previous = previous;
        }
        private void AddEditService_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = ClassEntity.Service.GetClientsFioTable();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Previous.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
           
        }
    }
}
