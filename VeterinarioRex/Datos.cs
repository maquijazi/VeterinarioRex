using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;

namespace VeterinarioRex
{
    public partial class Datos : Form
    {
        Conexion conexion = new Conexion();
        DataTable veterinary = new DataTable();

        public Datos()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            Application.Exit();
        }

        private void btUSUARIO_Click(object sender, EventArgs e)
        {
            String textoPassword = tbCONTRASEÑA.Text;
            string codHash = BCrypt.Net.BCrypt.HashPassword(textoPassword, BCrypt.Net.BCrypt.GenerateSalt());
            MessageBox.Show(conexion.insertaUsuario(tbDNI.Text, tbNOMBRE.Text, codHash));
        }

        private void botREGCLI_Click(object sender, EventArgs e)
        {
            MessageBox.Show(conexion.insertaCliente(tbDNICLI.Text, tbNOMCLI.Text, tbAPECLI.Text, tbTEL1CLI.Text, 
                tbTEL2CLI.Text, tbEMACLI.Text, tbDIRCLI.Text, tbLOCCLI.Text));
        }

        private void btREGMAS_Click(object sender, EventArgs e)
        {
            MessageBox.Show(conexion.insertaMascota(tbNOMMAS.Text, tbDUEMAS.Text, tbIDEMMAS.Text, tbANIMAS.Text, tbRAZMAS.Text,
                tBVETMAS.Text, tbEDAMAS.Text));
        }

        private void botBUSMAS_Click(object sender, EventArgs e)
        {
            veterinary = conexion.getMascota(tbNOMBUS.Text);
            tbDUEBUS.Text = veterinary.Rows[0]["DUENO"].ToString();
            tdIDEMBUS.Text = veterinary.Rows[0]["IDEM"].ToString();
            tdANIBUS.Text = veterinary.Rows[0]["ANIMAL"].ToString();
            tdRAZBUS.Text = veterinary.Rows[0]["RAZA"].ToString();
            tdVETBUS.Text = veterinary.Rows[0]["VETERINARIO"].ToString();
            tdEDABUS.Text = veterinary.Rows[0]["EDAD"].ToString();
        }

        private void botBUSCLI_Click(object sender, EventArgs e)
        {
            veterinary = conexion.getCliente(tbNOMBUSCLI.Text);
            tbDNIBUS.Text = veterinary.Rows[0]["DNI"].ToString();
            tbAPEBUS.Text = veterinary.Rows[0]["APELLIDOS"].ToString();
            tbTEL1BUS.Text = veterinary.Rows[0]["TELEFONO1"].ToString();
            tbTEL2BUS.Text = veterinary.Rows[0]["TELEFONO1"].ToString();
            tbEMABUSCLIE.Text = veterinary.Rows[0]["EMAIL"].ToString();
            tbDIRBUS.Text = veterinary.Rows[0]["DIRECCION"].ToString();
            tbLOCBUS.Text = veterinary.Rows[0]["LOCALIDAD"].ToString();
        }
    }
}
