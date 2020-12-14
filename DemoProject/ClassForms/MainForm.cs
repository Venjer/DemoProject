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
    public partial class MainForm : Form
    {
        static public string discountFilter1;
        static public string discountFilter2;
        static public string searchString;
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!ClassEntity.DBConnection.Connect())
                Close();
            dataGridView1.DataSource = ClassEntity.Service.GetServiceTable();
            comboBox1.SelectedIndex = 0;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClassEntity.DBConnection.Disconnect();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns["Cost"], ListSortDirection.Ascending);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns["Cost"], ListSortDirection.Descending);
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["Image"].Value = System.Drawing.Image.FromFile(dataGridView1.Rows[i].Cells["MainImagePath"].Value.ToString().Trim());
                dataGridView1.Rows[i].Cells["DurationInSeconds"].Value = int.Parse(dataGridView1.Rows[i].Cells["DurationInSeconds"].Value.ToString()) / 60;
                if (double.Parse(dataGridView1.Rows[i].Cells["Discount"].Value.ToString()) != 0)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AddEditService(this).ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    discountFilter1 = "0";
                    discountFilter2 = "1";
                    break;
                case 1:
                    discountFilter1 = "0";
                    discountFilter2 = "0.05";
                    break;
                case 2:
                    discountFilter1 = "0.05";
                    discountFilter2 = "0.15";
                    break;
                case 3:
                    discountFilter1 = "0.15";
                    discountFilter2 = "0.3";
                    break;
                case 4:
                    discountFilter1 = "0.3";
                    discountFilter2 = "0.7";
                    break;
                case 5:
                    discountFilter1 = "0.7";
                    discountFilter2 = "1";
                    break;
            }
            dataGridView1.DataSource = ClassEntity.Service.GetServiceTable();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(searchString == "")
                return;
            searchString = "";
            searchString += $"and Title like '%{textBox2.Text}%' or Description like '%{textBox2.Text}%'";
            dataGridView1.DataSource = ClassEntity.Service.GetServiceTable();
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["Image"].Value = System.Drawing.Image.FromFile(dataGridView1.Rows[i].Cells["MainImagePath"].Value.ToString().Trim());
                dataGridView1.Rows[i].Cells["DurationInSeconds"].Value = int.Parse(dataGridView1.Rows[i].Cells["DurationInSeconds"].Value.ToString()) / 60;
                if (double.Parse(dataGridView1.Rows[i].Cells["Discount"].Value.ToString()) != 0)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
                }
            }
            label2.Text = ClassEntity.Service.GetCount();
        }
    }
}
