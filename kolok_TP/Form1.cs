using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kolok_TP
{
    
    public partial class Form1 : Form
    {
        User _user = new User();
        int _id = 0;
        public Form1()
        {
            InitializeComponent();
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabPage2);
            tabPage2.Select();

        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            _user.ID = _id;
            _id++;

            _user.UserName = tbNameUser.Text;

            _user.UserSecName = tbSecNameUser.Text;

            if (decimal.TryParse(tbWieghtUser.Text, out var number)) {
                _user.UserWeight = number;
                dataGridView1.Rows.Add(_user.ID,_user.UserSecName, _user.UserName, _user.UserWeight);
                MessageBox.Show("Запись успешно прошла");
                tabControl1.TabPages.Remove(tabPage2);
            }
            else MessageBox.Show("Неправильно введены данные");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int delet = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(delet);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabPage3);
            int d = dataGridView1.SelectedCells[0].RowIndex;
            
            textBox3.Text = dataGridView1.Rows[d].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[d].Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.Rows[d].Cells[3].Value.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("C:\\Users\\petro\\OneDrive\\Рабочий стол\\kolokSave\\Save.txt", true);
            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    if (dataGridView1.Columns[i].Visible == false)
                        continue;
                    sw.Write(dataGridView1.Rows[j].Cells[i].Value + " : ");
                }
                sw.WriteLine();
            }
            sw.Close();
            MessageBox.Show("Таблица сохранена в файл");
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            int d = dataGridView1.SelectedCells[0].RowIndex;
            if (decimal.TryParse(tbWieghtUser.Text, out var number))
            {
                _user.UserWeight = number;
                dataGridView1.Rows.Add(d, textBox3.Text,textBox2.Text, textBox1.Text);
                MessageBox.Show("Запись успешно прошла");
                tabControl1.TabPages.Remove(tabPage2);
                dataGridView1.Rows.RemoveAt(d);
            }
            else MessageBox.Show("Неправильно введены данные");
        }
    }
}
