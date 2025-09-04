using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3NLIDTS_PabloJimenez_04c
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
