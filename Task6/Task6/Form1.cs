using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task6
{
    public partial class Form1:Form
    {
        const int columnwidth = 30;
        Size startSize;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("c1","");
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Width = columnwidth;
            dataGridView1.Rows.Add();
            ResizeDGV(dataGridView1);
            startSize = Size;
        }
        void ClearDGVStyle() {
            for(int i = 0;i < dataGridView1.ColumnCount;i++)
            {
                for(int j = 0;j < dataGridView1.RowCount;j++)
                {
                    dataGridView1.Rows[j].Cells[i].Style.BackColor = SystemColors.Window;
                    dataGridView1.Rows[j].Cells[i].Style.ForeColor = SystemColors.ControlText;
                }
            }
        }
        private void button1_Click(object sender,EventArgs e)
        {
            ClearDGVStyle();
            int[,] array = ArratToDGV.ConvertToArray(dataGridView1);
            int[,] result;
            int[] max = Class2DArray.FindMax(array,out result);
            Size = startSize;

            if (result != null)
            {

                label8.Visible = false;
                dataGridView2.Visible = true;
                ArratToDGV.ConvertToDGV(result, dataGridView2);
                for (int i = 0; i < dataGridView2.ColumnCount; i++)
                {
                    dataGridView2.Columns[i].Width = columnwidth;
                }
                ResizeDGV(dataGridView2);
                label5.Visible = true;
            }
            else
            {
                label5.Visible = false;
                label8.Visible = true;
                dataGridView2.Visible = false;
                label8.Text = "В итоговом массиве не осталось ни одной строки!";
            }
            label7.Text = "Максимальные элементы для каждой строки исходного двумерного массива:\n";
            for(int i = 0;i < max.Length;i++)
            {
                Height += 13;
                label7.Text += $"{i+1}) {max[i]}\n";
            }
            for(int i = 0;i < dataGridView1.ColumnCount;i++)
            {
                for(int j = 0;j < dataGridView1.RowCount;j++)
                {
                    if(Convert.ToInt32(dataGridView1[i,j].Value) == max[j]) {
                        dataGridView1.Rows[j].Cells[i].Style.BackColor = Color.Aqua;
                        dataGridView1.Rows[j].Cells[i].Style.ForeColor = Color.DarkBlue;
                    }
                }
            }
        }
        private void button2_Click(object sender,EventArgs e)
        {
            ClearDGVStyle();
            button1.Enabled = true;
            int[,] array = Class2DArray.RandomFill(Convert.ToInt32(textBox1.Text),Convert.ToInt32(textBox2.Text),dataGridView1.RowCount,dataGridView1.ColumnCount);
            ArratToDGV.ConvertToDGV(array,dataGridView1);
            for(int i = 0;i < dataGridView1.ColumnCount;i++)
            {
                dataGridView1.Columns[i].Width = columnwidth;
            }
        }
        private void numericUpDown1_ValueChanged(object sender,EventArgs e)
        {
            while(dataGridView1.RowCount < numericUpDown1.Value)
                dataGridView1.Rows.Add();
            while(dataGridView1.RowCount > numericUpDown1.Value)
                dataGridView1.Rows.RemoveAt(dataGridView1.RowCount - 1);

            ResizeDGV(dataGridView1);
        }
        private void numericUpDown2_ValueChanged(object sender,EventArgs e)
        {
            while(dataGridView1.ColumnCount < numericUpDown2.Value)
            {
                dataGridView1.Columns.Add($"c{dataGridView1.ColumnCount - 1}","");
                dataGridView1.Columns[dataGridView1.ColumnCount - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[dataGridView1.ColumnCount - 1].Width = columnwidth;
            }
            while(dataGridView1.ColumnCount > numericUpDown2.Value)
                dataGridView1.Columns.RemoveAt(dataGridView1.ColumnCount - 1);

            ResizeDGV(dataGridView1);
        }
        private void radioButton2_CheckedChanged(object sender,EventArgs e)
        {
            if(radioButton2.Checked)
            {
                dataGridView1.ReadOnly = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                button2.Visible = true;
            }
            else
            {
                dataGridView1.ReadOnly = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                button2.Visible = false;
            }
        }
        private void textBox_TextChanged(object sender,EventArgs e)
        {
            int min, max;
            if((int.TryParse(textBox1.Text,out min)) && (int.TryParse(textBox2.Text,out max)))
            {
                if(min < max)
                {
                    button2.Enabled = true;
                    return;
                }
            }
            button2.Enabled = false;
        }

        private void dataGridView1_CellValueChanged(object sender,DataGridViewCellEventArgs e)
        {
            ClearDGVStyle();
            int n = 0;
            for(var i = 0;i < dataGridView1.ColumnCount;i++)
            {
                // Если значение не int.
                if(!int.TryParse(dataGridView1[i,0].Value?.ToString(),out n))
                {
                    // Блокировка кнопки.
                    button1.Enabled = false;
                    return;
                }
            }
            button1.Enabled = true;
        }
        void ResizeDGV(DataGridView dgv)
        {
            if(dgv.RowCount > 7 && dgv.ColumnCount > 7)
            {
                dgv.Size = new Size(columnwidth * 7 + 20,dgv.RowTemplate.Height * 7 + 20);
            }
            else if(dgv.RowCount > 7 && dgv.ColumnCount <= 7)
            {
                dgv.Size = new Size(columnwidth * dgv.ColumnCount + 20,dgv.RowTemplate.Height * 7 + 3);
            }
            else if(dgv.RowCount <= 7 && dgv.ColumnCount > 7)
            {
                dgv.Size = new Size(columnwidth * 7 + 3,dgv.RowTemplate.Height * dgv.RowCount + 20);
            }
            else
            {
                dgv.Size = new Size(columnwidth * dgv.ColumnCount + 3,dgv.RowTemplate.Height * dgv.RowCount + 3);
            }
        }
        
        private void dataGridView_EditingControlShowing(object sender,DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }
        void tb_KeyPress(object sender,KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            // Проверка на то, что введённый символ - символ управления, запятая или минус.
            if((!char.IsControl(e.KeyChar)) && (!char.IsDigit(e.KeyChar)) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            // Проверка на то, что при вводе минуса в текстовом поле нет минуса и он вводится в нулевую позицию.
            if((e.KeyChar == '-') && ((tb.Text.Contains("-")) || (tb.SelectionStart != 0)))
            {
                e.Handled = true;
            }
        }
    }
}

