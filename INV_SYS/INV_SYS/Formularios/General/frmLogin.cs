using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INV_SYS
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private string userid;
        private string userName;
        public string UserId
        {
            get
            {
                return userid;
            }
            set
            {
                userid = "admin";
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = "admin";
            }
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {
            UserId = "admin";
            password = "admin";
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            login();                
        }

        private void login()
        {
            if (txtContrasena.Text.CompareTo("") == 0 || txtUsuario.Text.CompareTo("") == 0)
            {
                MessageBox.Show("Los dos campos son obligatorios, intentelo de nuevo ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                dt = RUsuario.loginUsuario(txtUsuario.Text, txtContrasena.Text);
                if (dt.Rows.Count > 0)
                {                    
                    string pass;
                    userid = dt.Rows[0]["Usuario"].ToString();
                    pass = dt.Rows[0]["Clave"].ToString();
                    if (txtUsuario.Text.ToUpper() == userid.ToUpper() && txtContrasena.Text.ToUpper() == pass.ToUpper())
                    {
                        //MessageBox.Show("Bienvenido @usuario");
                        frmInvSys homeStart = new frmInvSys(userid);
                        homeStart.Show();
                        this.limpiar();
                        this.Hide();
                        homeStart.FormClosed += HomeStart_FormClosed;
                    }
                }
                else
                {
                    limpiar();
                    MessageBox.Show("Error de ingreso. Credenciales incorrectas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            

        }


        private void limpiar()
        {
            txtUsuario.Clear();
            txtContrasena.Clear();
            txtUsuario.Focus();
        }

        private void HomeStart_FormClosed(object sender, FormClosedEventArgs e)
        {
            limpiar();
            this.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
                btnIngresar_Click_1(null,null);
            }
        }
    }
}
