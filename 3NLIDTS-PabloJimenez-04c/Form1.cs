using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //libreria para la escritura y lectura
using System.Windows.Forms;
using System.Text.RegularExpressions; // libreria para analisis de formato de texto
using MySql.Data.MySqlClient; //libreria externa para la conexion de base de datos

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

        string ConexionSQL = "Server=localhost;Port:3306;Database=formulario3N;Uid=root;Pwd=;";

        private void InsertarRegistro(string nombre, string apellidos, float estatura, int edad, string telefono, string genero)
        {
            using (MySqlConnection conn = new MySqlConnection(ConexionSQL))
            { 
                conn.Open();
                //Los @ son valores sustituibles que recuperaremos mas tarde
                string insertQuery = "INSERT INTO registro_usuarios (nombre,apellidos,estatura,edad,telefono,genero)" +
                    "VALUES (@Nombre,@Apellidos,@Estatura,@Edad,@Telefono,@Genero)";
                using (MySqlCommand comando = new MySqlCommand (insertQuery,conn)) 
                {
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    comando.Parameters.AddWithValue("@Apellidos", apellidos);
                    comando.Parameters.AddWithValue("@Estatura", estatura);
                    comando.Parameters.AddWithValue("@Edad", edad);
                    comando.Parameters.AddWithValue("@Telefono", telefono);
                    comando.Parameters.AddWithValue("@Genero", genero);
                    comando.ExecuteNonQuery(); //se relaliza la insercion a la base de datos
                }
                conn.Close();
            }

        }

        private bool esenterovalido(string valor)
        {
            return Regex.IsMatch(valor, @"^[a-zA-Z\s]+$");
        }

        private bool edadvalida(string valor)
        {
            return Regex.IsMatch(valor, @"^[0-9]+$");
        }

        private bool estaturavalida(string valor)
        {
            return Regex.IsMatch(valor, @"^\d*(\.\d*)?$");
        }

        private bool telefonovalida(string valor)
        {
            return Regex.IsMatch(valor, @"^[0-9]+$");
        }

        private void validarNombre(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!esenterovalido(textBox.Text) && !string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("Por favor ingrese un nombre valido (solo letras).", "ERROR");
                textBox.Clear();
            }
        }

        private void validarApellido(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!esenterovalido(textBox.Text) && !string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("Por favor ingrese un apellido valido (solo letras).", "ERROR");
                textBox.Clear();
            }
        }

        private void validarEdad(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!edadvalida(textBox.Text) && !string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("Por favor ingrese una edad valida (solo numeros).", "ERROR");
                textBox.Clear();
            }
        }

        private void validarEstatura(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!estaturavalida(textBox.Text) && !string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("Por favor ingrese una estatura valida (ej. 1.75).", "ERROR");
                textBox.Clear();
            }
        }
        private void validarTelefono(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!telefonovalida(textBox.Text) && !string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("Por favor ingrese un telefono valido (solo numeros).", "ERROR");
                textBox.Clear();
            }
        }
        private void guardarDatosEnTXT(string datos)
        {
            try
            {
                string path = "datos.txt";
                File.AppendAllText(path, datos + Environment.NewLine + "-------------------------" + Environment.NewLine);
                MessageBox.Show("Los datos han sido guardados en el archivo datos.txt", "Guardado Exitoso");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al guardar los datos: " + ex.Message, "Error al guardar");
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
            guardarDatosEnTXT(datos);
            //Vr.0003 :)
        }
    }
}
