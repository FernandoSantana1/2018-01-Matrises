using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matriz
{
    public partial class Form1 : Form
    {
        //int[,] a = new int[3, 4]  // Matriz 3 x 4
        //{
        //    {0,1,2,3},         //Linha 1
        //    {4,5,6,7},         //Linha 2
        //    {8,9,10,11}        //Linha 3
        //};
        //a[0,0,0] = 1;   "a" -> Matriz "[0,0,0]" -> posições "1" valor a ser recebido 

        ///////////////////////////////////////////////
        double[,] matriz;
        int i = 0; //linhas
        int j = 0; //colunas
        int Contador = 0; //identificar qual btn criar matriz foi clicado

        private void preparaGrid()
        {
            //lendo o numero de linhas da matriz e definindo o tamanho do grid
            dataGridView1.RowCount = matriz.GetLength(0);
            //lendo o numero de colunas da matriz e de finindo o tamanho do grid
            dataGridView1.ColumnCount = matriz.GetLength(1);
            //coloca um texto indicador em cada linha 
            for (int l = 0; l < matriz.GetLength(0); l++)
            {
                dataGridView1.Rows[l].HeaderCell.Value = "Linha " + l.ToString();
            }
            //coloca um texto indicador em cada coluna 
            for (int c = 0; c < matriz.GetLength(1); c++)
            {
                dataGridView1.Columns[c].Name = "Coluna " + c.ToString();
            }

        }
        private void mostragrid()
        {
            //percorre todas as Linhas
            for (int l = 0; l < matriz.GetLength(0); l++)
            {
                //Percorre todas as colunas
                for (int c = 0; c < matriz.GetLength(0); c++)
                {
                    //seta o valor a ser mostrado no grid de dacordo com a posição correspondente da matriz
                    dataGridView1.Rows[l].Cells[c].Value = matriz[l, c];
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
            //mostragrid();
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)  //btn enviar
        {
            if (Contador == 1)//criar matriz 1
            {
                matriz[i, j] = (double)numericUpDown1.Value;
                mostragrid(); //mostrar
                if (j < matriz.GetLength(1))
                {
                    j++; //pular
                }
                if ((i < matriz.GetLength((0)) && (j == matriz.GetLength(1))))
                {
                    i++;
                    j = 0;
                }
                if ((i > matriz.GetLength(0) - 1))
                {
                    button1.Enabled = false; //testar se chegou no limite final
                }
            }
            if (Contador == 2) //criar matriz 2
            {
                matriz[i, j] = (double)numericUpDown1.Value;
                mostragrid2(); //mostrar
                if (j < matriz.GetLength(1))
                {
                    j++; //pular
                }
                if ((i < matriz.GetLength((0)) && (j == matriz.GetLength(1))))
                {
                    i++;
                    j = 0;
                }
                if ((i > matriz.GetLength(0) - 1))
                {
                    button1.Enabled = false; //testar se chegou no limite final
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            matriz = new double[(int)numericUpDown2.Value,
                                (int)numericUpDown3.Value];
            preparaGrid();
            mostragrid();
            i = j = 0;
            button1.Enabled = true;
            Contador = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (matriz.GetLength(0) != matriz.GetLength(1))
            {
                MessageBox.Show("Diagonais apenas para matrizes quadradas!");
                return;
            }
            richTextBox1.Clear();
            richTextBox1.AppendText("Diagonal Principal matriz 1:" + Environment.NewLine);
            for (int l = 0; l < matriz.GetLength(0); l++)
            {
                richTextBox1.AppendText("Matriz[" + l.ToString() + "][" + l.ToString() +
                    "]=" + matriz[l, l].ToString() + Environment.NewLine);
                //mudar a cor
                dataGridView1.Rows[l].Cells[l].Style.BackColor = Color.PaleGreen;
            }

            //secundaria

            richTextBox1.AppendText("Diagonal secundária matriz 1: " + Environment.NewLine);
            for (int l = 0; l < matriz.GetLength(0); l++)
            {
                richTextBox1.AppendText("Matriz[" + (matriz.GetLength(0) - 1 - l).ToString() + "][" +
                    l.ToString() + "]=" + matriz[matriz.GetLength(0) - 1 - l, l].ToString() + Environment.NewLine);
                //mudar a cor
                dataGridView1.Rows[matriz.GetLength(0) - 1 - l].Cells[l].Style.BackColor = Color.CadetBlue;
            }
            ////////////////////////////////////////////////////////////////////////////////////////////   
            if (matriz.GetLength(0) != matriz.GetLength(1))
            {
                MessageBox.Show("Diagonais apenas para matrizes quadradas!");
                return;
            }
            richTextBox1.AppendText("Diagonal Principal matriz 2:" + Environment.NewLine);
            for (int l = 0; l < matriz.GetLength(0); l++)
            {
                richTextBox1.AppendText("Matriz[" + l.ToString() + "][" + l.ToString() +
                    "]=" + matriz[l, l].ToString() + Environment.NewLine);
                //mudar a cor
                dataGridView2.Rows[l].Cells[l].Style.BackColor = Color.CadetBlue;
            }

            //secundaria

            richTextBox1.AppendText("Diagonal secundária matiz 2: " + Environment.NewLine);
            for (int l = 0; l < matriz.GetLength(0); l++)
            {
                richTextBox1.AppendText("Matriz[" + (matriz.GetLength(0) - 1 - l).ToString() + "][" +
                    l.ToString() + "]=" + matriz[matriz.GetLength(0) - 1 - l, l].ToString() + Environment.NewLine);
                //mudar a cor
                dataGridView2.Rows[matriz.GetLength(0) - 1 - l].Cells[l].Style.BackColor = Color.PaleGreen;
            }
        }
        private void preparaGrid2()
        {
            //lendo o numero de linhas da matriz e definindo o tamanho do grid
            dataGridView2.RowCount = matriz.GetLength(0);
            //lendo o numero de colunas da matriz e de finindo o tamanho do grid
            dataGridView2.ColumnCount = matriz.GetLength(1);
            //coloca um texto indicador em cada linha 
            for (int l = 0; l < matriz.GetLength(0); l++)
            {
                dataGridView2.Rows[l].HeaderCell.Value = "Linha " + l.ToString();
            }
            //coloca um texto indicador em cada coluna 
            for (int c = 0; c < matriz.GetLength(1); c++)
            {
                dataGridView2.Columns[c].Name = "Coluna " + c.ToString();
            }

        }
        private void mostragrid2()
        {
            //percorre todas as Linhas
            for (int l = 0; l < matriz.GetLength(0); l++)
            {
                //Percorre todas as colunas
                for (int c = 0; c < matriz.GetLength(0); c++)
                {
                    //seta o valor a ser mostrado no grid de dacordo com a posição correspondente da matriz
                    dataGridView2.Rows[l].Cells[c].Value = matriz[l, c];

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            matriz = new double[(int)numericUpDown2.Value,
                                (int)numericUpDown3.Value];
            preparaGrid2();
            mostragrid2();
            i = j = 0;
            button1.Enabled = true;
            Contador = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            matriz[i, j] = (double)numericUpDown1.Value;
            if (j < matriz.GetLength(1))
            {
                int A = j * j;
                j++; //pular
                MessageBox.Show("A = " + A);
            }
            if ((i < matriz.GetLength((0)) && (j == matriz.GetLength(1))))
            {

                i++;
                j = 0;
                
            }
            if ((i > matriz.GetLength(0) - 1))
            {
                button1.Enabled = false; //testar se chegou no limite final
            }
        }
    }
}
