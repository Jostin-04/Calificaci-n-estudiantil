using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notas3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void vtnCalcular_Click(object sender, EventArgs e)
        {
            double n1 = double.Parse(txtNota1.Text);
            double n2 = double.Parse(txtNota2.Text);
            double n3 = double.Parse(txtNota3.Text);
            double n4 = double.Parse(txtNota4.Text);

            double Promedio = (n1 + n2 + n3 + n4) / 4;
            txtPromedio.Text = Promedio.ToString("0.00");

            if (Promedio >= 70)
            {
                txtResultado.Text = "Aprobado";
                txtCompletivo.Enabled = false;
                txtExtraordinario.Enabled = false;
                return;
            }

            txtCompletivo.Enabled = true;

            if (txtCompletivo.Text == "")
            {
                MessageBox.Show("Ingrese la nota del completivo y presione Calcular otra vez");
                return;
            }

            double NotaCompletivo;
            if (!double.TryParse(txtCompletivo.Text, out NotaCompletivo))
            {
                MessageBox.Show("La nota del completivo no es válida");
                return;
            }

            double totalCompletivo = (Promedio * 0.50) + (NotaCompletivo * 0.50);

            if (totalCompletivo >= 70)
            {
                txtResultado.Text = "Aprobado con " + totalCompletivo+ " en completivo";
                txtExtraordinario.Enabled = false;
                return;
            }

            txtExtraordinario.Enabled = true;

            if (txtExtraordinario.Text == "")
            {
                MessageBox.Show("Ingrese la nota del extraordinario y presione Calcular otra vez");
                return;
            }

            double notaExtra;
            if (!double.TryParse(txtExtraordinario.Text, out notaExtra))
            {
                MessageBox.Show("La nota del extraordinario no es válida");
                return;
            }

            double totalExtraordinario = (Promedio * 0.30) + (notaExtra * 0.70);

            if (totalExtraordinario >= 70)
                txtResultado.Text = "Aprobado con " + totalExtraordinario + " en extraodinario";
            else
                txtResultado.Text = "Reprobado con "+ totalExtraordinario;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNota1.Clear();
            txtNota2.Clear();
            txtNota3.Clear();
            txtNota4.Clear();
            txtPromedio.Clear();
            txtCompletivo.Clear();
            txtExtraordinario.Clear();
            txtResultado.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
