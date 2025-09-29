using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace _3NLIDTS_PabloJimenez_04c
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tbnombre.TextChanged += validarNombre;
            tbapellidos.TextChanged += validarApellido;
            tbedad.TextChanged += validarEdad;
            tbestatura.TextChanged += validarEstatura;
            tbtelefono.TextChanged += validarTelefono;
        }
        private bool esenterovalido(string valor)
        {
            return Regex.IsMatch(valor, @"^[a-zA-Z\s]+$");
        }

        private bool edadvalida(string valor)
        {
            return Regex.IsMatch(valor, @"^[0-9]+$");
        }

        private bool telefonovalida(string valor)
        {
            return Regex.IsMatch(valor, @"^[0-9]+$");
        }

        private void validarNombre(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!esenterovalido(textBox.Text))
            {
                MessageBox.Show("por favor ingrese un nombre valido", "ERROR");
                textBox.Clear();

            }
        }
        private void validarApellido(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!esenterovalido(textBox.Text))
            {
                MessageBox.Show("por favor ingrese un nombre valido", "ERROR");
                textBox.Clear();
            }
        }

        private void validarEdad(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!edadvalida(textBox.Text))
            {
                MessageBox.Show("por favor ingrese una edad valida", "ERROR");
                textBox.Clear();
            }
        }
        private void validarEstatura(object sender, EventArgs e)
        {

        }
        private void validarTelefono(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!telefonovalida(textBox.Text))
            {
                MessageBox.Show("por favor ingrese una edad valida", "ERROR");
                textBox.Clear();
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            tbnombre.Clear();
            tbapellidos.Clear();   
            tbedad.Clear();
            tbestatura.Clear();
            tbtelefono.Clear();
            rdbhombre.Checked = false;
            rdbmujer.Checked = false;
        }

        private void btngenerar_Click(object sender, EventArgs e)
        {
            string nombre = tbnombre.Text;
            string apellidos = tbapellidos.Text;
            string edad = tbedad.Text;
            string estatura = tbestatura.Text;
            string telefono = tbtelefono.Text;
            string genero = "";
            if (rdbhombre.Checked)
            {
                genero = "masculino";
            }
            else if (rdbmujer.Checked) 
            {
                genero = "femenino";
            }
            string datos = $"Nombre: {nombre}\r\nApellidos: {apellidos}\r\n" +
               $"Edad: {edad}\r\nEstatura: {estatura}\r\n" +
               $"Tel: {telefono}\r\nGenero: {genero}";
            MessageBox.Show(datos, "Valores registrados",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Vr.0002
        }
    }
}
