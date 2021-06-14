using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Net.Mail;

namespace SendEmailCV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage();
            //mail.From = new MailAddress(fromEmail, credenciales[1].ToString());
            ConexionDB cnDB = new();
            cnDB.ConexionBase();
            SqlConnection sqlCon= cnDB.ConexionBase();
            string query = "select CE.idempleado, em.Email,em.Nombre,em.ApellidoPaterno,em.ApellidoMaterno, ce.IdMentor from CapacitacionEmpleado as CE, Empleado as em where CE.Concluida =0 and ce.IdEmpleado = em.IdEmpleado";
            SqlCommand SqlCMD = new SqlCommand(query, sqlCon);
            SqlDataReader filas = SqlCMD.ExecuteReader();

            //Lectura de archivo txt

            string archivioSendEmail= ConfigurationManager.AppSettings["archivioSendEmail"].ToString();
            string textoActualizar = File.ReadAllText(archivioSendEmail);
            string text = "Los datos: ";
            while (filas.Read())
            {
                text += filas.GetValue(2) + " " + filas.GetValue(3) + " " + filas.GetValue(4);
            }
            textoActualizar = textoActualizar.Replace("@listaEmpleados", text);

        }
    }
}
