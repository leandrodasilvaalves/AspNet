namespace CRUD_WindowsForm
{
    partial class FrmMain
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
            this.btnCadFunc = new System.Windows.Forms.Button();
            this.btnCadCargo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCadFunc
            // 
            this.btnCadFunc.Location = new System.Drawing.Point(26, 56);
            this.btnCadFunc.Name = "btnCadFunc";
            this.btnCadFunc.Size = new System.Drawing.Size(226, 45);
            this.btnCadFunc.TabIndex = 1;
            this.btnCadFunc.Text = "Cadastro de &Funcionários";
            this.btnCadFunc.UseVisualStyleBackColor = true;
            this.btnCadFunc.Click += new System.EventHandler(this.BtnCadFunc_Click);
            // 
            // btnCadCargo
            // 
            this.btnCadCargo.Location = new System.Drawing.Point(26, 122);
            this.btnCadCargo.Name = "btnCadCargo";
            this.btnCadCargo.Size = new System.Drawing.Size(226, 45);
            this.btnCadCargo.TabIndex = 2;
            this.btnCadCargo.Text = "Cadastro de &Cargos";
            this.btnCadCargo.UseVisualStyleBackColor = true;
            this.btnCadCargo.Click += new System.EventHandler(this.BtnCadCargo_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 253);
            this.Controls.Add(this.btnCadCargo);
            this.Controls.Add(this.btnCadFunc);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crud PostgreSQL";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCadFunc;
        private System.Windows.Forms.Button btnCadCargo;
    }
}