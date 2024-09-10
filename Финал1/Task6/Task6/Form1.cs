using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task6
{
    public partial class Form1:Form
    {
        // Начальный размер колонок и формы
        const int columnwidth = 30;
        Size startSize;
        // Конструктор
        public Form1()
        {
            InitializeComponent();
            // Добавление строки и столбца в таблицу
            dataGridView1.Columns.Add("c1","");
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Width = columnwidth;
            dataGridView1.Rows.Add();
            // Изменение размера таблицы
            ResizeDGV(dataGridView1);
            // Сохранение начального размера формы в переменной
            startSize = Size;
        }
        // Очистка оформления ячеек таблицы
        void ClearDGVStyle()
        {
            for(int i = 0;i < dataGridView1.ColumnCount;i++)
            {
                for(int j = 0;j < dataGridView1.RowCount;j++)
                {
                    // Установка цвета по умолчанию
                    dataGridView1.Rows[j].Cells[i].Style.BackColor = SystemColors.Window;
                    dataGridView1.Rows[j].Cells[i].Style.ForeColor = SystemColors.ControlText;
                }
            }
        }
        // Обработка нажатия на кнопку "Вычислить"
        private void button1_Click(object sender,EventArgs e)
        {
            // Очистка оформления таблицы
            ClearDGVStyle();
            // Преобразование таблицы в массив
            int[,] array = ArrayToDGV.ConvertToArray(dataGridView1);
            // Объявление переменной для хранения итоговой таблицы
            int[,] result;
            // Массив максимальных элементов
            int[] max = Class2DArray.FindMax(array,out result);
            // Сброс размера формы
            Size = startSize;
            // Если в выходной таблице есть строки
            if (result != null)
            {
                label8.Visible = false;
                dataGridView2.Visible = true;
                ArrayToDGV.ConvertToDGV(result, dataGridView2);
                for (int i = 0; i < dataGridView2.ColumnCount; i++)
                {
                    dataGridView2.Columns[i].Width = columnwidth;
                }
                ResizeDGV(dataGridView2);
                label5.Visible = true;
            }
            // Если в выходной таблице нет строк
            else
            {
                label5.Visible = false;
                label8.Visible = true;
                dataGridView2.Visible = false;
                label8.Text = "В итоговом массиве не осталось ни одной строки!";
            }
            // Вывод максимальных элементов с увеличением высоты формы
            label7.Text = "Максимальные элементы для каждой строки исходного двумерного массива:\n";
            for(int i = 0;i < max.Length;i++)
            {
                Height += 13;
                label7.Text += $"{i+1}) {max[i]}\n";
            }
            // Выделение максимальных элементов строк в dataGridView1
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
        // Обработка нажатия на кнопку случайного заполнения
        private void button2_Click(object sender,EventArgs e)
        {
            // Очистка оформления таблицы
            ClearDGVStyle();
            // Разблокировка кнопки
            button1.Enabled = true;
            // Заполнение массива случайными элементами
            int[,] array = Class2DArray.RandomFill(Convert.ToInt32(textBox1.Text),Convert.ToInt32(textBox2.Text),dataGridView1.RowCount,dataGridView1.ColumnCount);
            ArrayToDGV.ConvertToDGV(array,dataGridView1);
            // Изменение ширины колонок
            for(int i = 0;i < dataGridView1.ColumnCount;i++)
            {
                dataGridView1.Columns[i].Width = columnwidth;
            }
        }
        // Изменение количества строк через элемент управления
        private void numericUpDown1_ValueChanged(object sender,EventArgs e)
        {
            // Сброс оформления таблицы
            ClearDGVStyle();
            // Добавление строк
            while (dataGridView1.RowCount < numericUpDown1.Value)
            {
                dataGridView1.Rows.Add();
            }
            // Удаление строк
            while (dataGridView1.RowCount > numericUpDown1.Value)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.RowCount - 1);
            }
            // Изменение размера таблицы
            ResizeDGV(dataGridView1);
        }
        private void numericUpDown2_ValueChanged(object sender,EventArgs e)
        {
            // Сброс оформления таблицы
            ClearDGVStyle();
            // Добавление столбцов
            while (dataGridView1.ColumnCount < numericUpDown2.Value)
            {
                dataGridView1.Columns.Add($"c{dataGridView1.ColumnCount - 1}","");
                dataGridView1.Columns[dataGridView1.ColumnCount - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[dataGridView1.ColumnCount - 1].Width = columnwidth;
            }
            // Удаление столбцов
            while (dataGridView1.ColumnCount > numericUpDown2.Value)
            {
                dataGridView1.Columns.RemoveAt(dataGridView1.ColumnCount - 1);
            }
            //Изменение размеров таблицы
            ResizeDGV(dataGridView1);
        }
        // Выбор случайного заполнения
        private void radioButton2_CheckedChanged(object sender,EventArgs e)
        {
            // Случайное заполнение включено
            if(radioButton2.Checked)
            {
                dataGridView1.ReadOnly = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                button2.Visible = true;
            }
            // Случайное заполнение выключено
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
        // Обработка изменения текста
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
        
        //Обработка изменения значения ячейки таблицы
        private void dataGridView1_CellValueChanged(object sender,DataGridViewCellEventArgs e)
        {
            ClearDGVStyle();
            int n = 0;
            for(var i = 0;i < dataGridView1.ColumnCount;i++)
            {
                // Если значение не int
                if(!int.TryParse(dataGridView1[i,0].Value?.ToString(),out n))
                {
                    // Блокировка кнопки
                    button1.Enabled = false;
                    return;
                }
            }
            button1.Enabled = true;
        }
        // Изменение размеров таблицы на основании количества строк и столбцов
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
        // Добавление обработчика нажатия на кнопку для ячеек таблицы
        private void dataGridView_EditingControlShowing(object sender,DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }
        // Обработка нажатия на клавишу в текстовом поле и ячейке таблицы
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

