namespace Parcial_TemaUno.Windows
{
    partial class frmCuboAE
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
            components = new System.ComponentModel.Container();
            label2 = new Label();
            txt1 = new TextBox();
            label3 = new Label();
            cboColores = new ComboBox();
            label5 = new Label();
            cboBordes = new ComboBox();
            btnCancelar = new Button();
            btnOk = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 60);
            label2.Name = "label2";
            label2.Size = new Size(111, 20);
            label2.TabIndex = 0;
            label2.Text = "Arista del Cubo";
            // 
            // txt1
            // 
            txt1.Location = new Point(169, 57);
            txt1.Name = "txt1";
            txt1.Size = new Size(125, 27);
            txt1.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 169);
            label3.Name = "label3";
            label3.Size = new Size(99, 20);
            label3.TabIndex = 0;
            label3.Text = "Color Relleno";
            // 
            // cboColores
            // 
            cboColores.DropDownStyle = ComboBoxStyle.DropDownList;
            cboColores.FormattingEnabled = true;
            cboColores.Location = new Point(169, 166);
            cboColores.Name = "cboColores";
            cboColores.Size = new Size(151, 28);
            cboColores.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(47, 241);
            label5.Name = "label5";
            label5.Size = new Size(106, 20);
            label5.TabIndex = 0;
            label5.Text = "Tipo De Borde";
            // 
            // cboBordes
            // 
            cboBordes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBordes.FormattingEnabled = true;
            cboBordes.Location = new Point(169, 238);
            cboBordes.Name = "cboBordes";
            cboBordes.Size = new Size(151, 28);
            cboBordes.TabIndex = 2;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.cancel_24px;
            btnCancelar.Location = new Point(428, 216);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(109, 93);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.TextImageRelation = TextImageRelation.TextAboveImage;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOk
            // 
            btnOk.Image = Properties.Resources.ok_24px;
            btnOk.Location = new Point(428, 54);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(109, 93);
            btnOk.TabIndex = 3;
            btnOk.Text = "OK";
            btnOk.TextImageRelation = TextImageRelation.TextAboveImage;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmObjetoAE
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(564, 329);
            Controls.Add(btnOk);
            Controls.Add(btnCancelar);
            Controls.Add(cboBordes);
            Controls.Add(label5);
            Controls.Add(cboColores);
            Controls.Add(txt1);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "frmObjetoAE";
            Text = "frmObjetoAE";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox txt1;
        private Label label3;
        private ComboBox cboColores;
        private Label label5;
        private ComboBox cboBordes;
        private Button btnCancelar;
        private Button btnOk;
        private ErrorProvider errorProvider1;
    }
}