using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcWindowsForms
{
    public partial class Calc : Form
    {

        double numero1 = 0, numero2 = 0;
        char operador;
        public Calc()
        {
            InitializeComponent();
            operaElegido.Text = "Elige operador";
        }

        private void agregarNumero(object sender, EventArgs e)
        {
            if (txtResultado.Text.Length >= 18)
            {
                MessageBox.Show("Limit Reached");
            }
            else
            {
                var boton = ((Button)sender);
                if (txtResultado.Text == "0") txtResultado.Text = "";
                txtResultado.Text += boton.Text;
            }
        }

        private void cE(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
            operaElegido.Text = "Elige operador"; numero2 = 0; operador = '\0';
        }

        private void backSpace(object sender, EventArgs e)
        {
            if (txtResultado.Text != "0")
            {
                txtResultado.Text = txtResultado.Text.Substring(0, txtResultado.Text.Length - 1);
            }
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            numero2 = double.Parse(txtResultado.Text);

            if (operador == '+')
            {
                txtResultado.Text = (numero1+ numero2).ToString();
            }
            else if(operador == '-')
            {
                txtResultado.Text = (numero1- numero2).ToString();
            }
            else if (operador == '/')
            {
                txtResultado.Text = (numero1 / numero2).ToString();
            }
            else if(operador == 'X')
            {
                txtResultado.Text = (numero1 * numero2).ToString();
            }
            

        }

        private void btnC_Click(object sender, EventArgs e)
        {
            numero1 = 0; numero2 = 0; operador = '\0';
            txtResultado.Text = "0";
            operaElegido.Text = "Elige operador";
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            if (!txtResultado.Text.Contains(","))
            {
                txtResultado.Text += ",";
            }
        }

        private void btnSigno_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text.StartsWith("-")) // Si ya hay un signo negativo
            {
                txtResultado.Text = txtResultado.Text.TrimStart('-'); // Elimina el signo negativo existente
            }
            else
            {
                txtResultado.Text = "-" + txtResultado.Text; // Agrega un nuevo signo negativo al principio
            }
        }

        private void operaElegido_TextChanged(object sender, EventArgs e)
        {
            if (operador != '\0' && numero1 != 0)
            {
                operaElegido.Text = $"Tu operador es {operador}";
            }

        }

        

        private void clickOperdor(object sender, EventArgs e)
        {
            var boton = ((Button)sender);
            numero1 = double.Parse(txtResultado.Text);
            operador = Convert.ToChar(boton.Tag);
            if (operador == '²'){
                txtResultado.Text = Math.Pow(numero1,2).ToString();
            }
            else if (operador == '√')
            {
                txtResultado.Text = Math.Sqrt(numero1).ToString();
            }
            else
            {
                txtResultado.Text = "0";
            }
            operaElegido_TextChanged(this, EventArgs.Empty);

        }

        
    }
}
