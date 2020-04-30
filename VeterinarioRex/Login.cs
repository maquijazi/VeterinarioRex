using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeterinarioRex
{
    public partial class Login : Form
    {
        Conexion conexion = new Conexion();

        public Login()
        {
            InitializeComponent();
        }

        

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (conexion.loginVeterinario(textBoxDNI.Text, textBoxPASSWORD.Text))
            {
                Datos v = new Datos();
                v.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("El USUARIO o CONTRASEÑA son incorrectos");
            }
           

        }
        //Método para que se cierre entera la aplicación
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            Application.Exit();
        }
    }
}
