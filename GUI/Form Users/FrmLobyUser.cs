using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using GUI.Form_Admin;

namespace GUI.Form_Users
{
    public partial class FrmLobyUser : Form
    {
        //Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        //Constructor
        public FrmLobyUser()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 50);
            pnMenuLobyUser.Controls.Add(leftBorderBtn);
            //FORM
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        //estrucutura de los botones
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        //Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                if (senderBtn != null)
                {
                    DisableButton();
                    currentBtn = (IconButton)senderBtn;
                    currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                    currentBtn.ForeColor = color;
                    currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                    currentBtn.IconColor = color;
                    currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                    currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                    //left border
                    leftBorderBtn.BackColor = color;
                    leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                    leftBorderBtn.Visible = true;
                    leftBorderBtn.BringToFront();
                    //iconCurrentChildForm 
                    iconCurrentChildForm.IconChar = currentBtn.IconChar;
                    iconCurrentChildForm.IconColor = color;
                }
            }
        }

        private void OpenChildForm(Form childform)
        {
            if (currentChildForm != null)
            {
                //open only form
                currentChildForm.Close();
            }
            currentChildForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            pnDesktop.Controls.Add(childform);
            pnDesktop.Tag = childform;
            childform.BringToFront();
            childform.Show();
            lblTitleChildForm.Text = childform.Text;
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(23, 37, 84);
                currentBtn.ForeColor = Color.Cyan;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Cyan;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        //private void btnDashboard_Click(object sender, EventArgs e)
        //{
        //    ActivateButton(sender, RGBColors.color1);
        //    OpenChildForm(new FrmDashboard());
        //}

        private void btnEventos_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new FrmEventosUser());
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FrmCursosUser());
        }

        //private void btnParticipantes_Click(object sender, EventArgs e)
        //{
        //    ActivateButton(sender, RGBColors.color4);
        //    OpenChildForm(new FrmParticipantes());
        //}

        //private void btnReportes_Click(object sender, EventArgs e)
        //{
        //    ActivateButton(sender, RGBColors.color5);
        //    OpenChildForm(new FrmReportes());
        //}

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FrmConfiguracionUser());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);

            this.Hide();

            // Mostrar el formulario de login
            FrmLogin loginForm = new FrmLogin();
            loginForm.Show();

            // Cerrar completamente este formulario si ya no se necesita
            this.Close();
        }

        private void FrmLobyAdmin_Load(object sender, EventArgs e)
        {
            // Configurar la ventana para que se abra de manera central  
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Location = new Point(
                (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2
            );
        }

        private void picLogoReset_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.Cyan;
            lblTitleChildForm.Text = "Home";
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panelVistaInterna_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            PerfilForm perfilForm = new PerfilForm();
            perfilForm.ShowDialog(); // Muestra el formulario como un diálogo modal
        }
    }
}
