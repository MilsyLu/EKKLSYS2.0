﻿namespace GUI
{
    partial class FrmCursosAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnNuevoCurso = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flpCursos = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.btnRefrescar);
            this.panel1.Controls.Add(this.btnNuevoCurso);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 52);
            this.panel1.TabIndex = 0;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefrescar.Location = new System.Drawing.Point(446, 13);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(77, 26);
            this.btnRefrescar.TabIndex = 2;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // btnNuevoCurso
            // 
            this.btnNuevoCurso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoCurso.Location = new System.Drawing.Point(531, 13);
            this.btnNuevoCurso.Name = "btnNuevoCurso";
            this.btnNuevoCurso.Size = new System.Drawing.Size(77, 26);
            this.btnNuevoCurso.TabIndex = 1;
            this.btnNuevoCurso.Text = "Nuevo";
            this.btnNuevoCurso.UseVisualStyleBackColor = true;
            this.btnNuevoCurso.Click += new System.EventHandler(this.btnNuevoCurso_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cursos Disponibles";
            // 
            // flpCursos
            // 
            this.flpCursos.AutoScroll = true;
            this.flpCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCursos.Location = new System.Drawing.Point(0, 52);
            this.flpCursos.Name = "flpCursos";
            this.flpCursos.Padding = new System.Windows.Forms.Padding(9);
            this.flpCursos.Size = new System.Drawing.Size(620, 307);
            this.flpCursos.TabIndex = 1;
            // 
            // FrmCursosAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 359);
            this.Controls.Add(this.flpCursos);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCursosAdmin";
            this.Text = "Cursos";
            this.Load += new System.EventHandler(this.CursosForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNuevoCurso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpCursos;
        private System.Windows.Forms.Button btnRefrescar;
    }
}