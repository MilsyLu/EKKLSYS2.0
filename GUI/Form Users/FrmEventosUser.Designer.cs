using System;
using System.Windows.Forms;

namespace GUI.Form_Users
{
    partial class FrmEventosUser
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpEventos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flpEventos = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(827, 64);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Próximos Eventos";
            // 
            // flpEventos
            // 
            this.flpEventos.AutoScroll = true;
            this.flpEventos.BackColor = System.Drawing.Color.White;
            this.flpEventos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpEventos.Location = new System.Drawing.Point(0, 64);
            this.flpEventos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpEventos.Name = "flpEventos";
            this.flpEventos.Padding = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.flpEventos.Size = new System.Drawing.Size(827, 378);
            this.flpEventos.TabIndex = 1;
            this.flpEventos.Paint += new System.Windows.Forms.PaintEventHandler(this.flpEventos_Paint);
            // 
            // FrmEventosUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 442);
            this.Controls.Add(this.flpEventos);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmEventosUser";
            this.Text = "Eventos";
            this.Load += new System.EventHandler(this.EventosForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
