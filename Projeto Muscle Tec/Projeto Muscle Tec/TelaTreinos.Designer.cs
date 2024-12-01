
namespace Projeto_Muscle_Tec
{
    partial class TelaTreinos
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
            this.btnAdicionarTreino = new System.Windows.Forms.Button();
            this.treeViewTreinos = new System.Windows.Forms.TreeView();
            this.lblExercicioSelecionado = new System.Windows.Forms.Label();
            this.btnRemoverExercicio = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSessoes = new System.Windows.Forms.TextBox();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.txtMeta = new System.Windows.Forms.TextBox();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAdicionarTreino
            // 
            this.btnAdicionarTreino.Location = new System.Drawing.Point(12, 410);
            this.btnAdicionarTreino.Name = "btnAdicionarTreino";
            this.btnAdicionarTreino.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionarTreino.TabIndex = 2;
            this.btnAdicionarTreino.Text = "Criar Treino";
            this.btnAdicionarTreino.UseVisualStyleBackColor = true;
            this.btnAdicionarTreino.Click += new System.EventHandler(this.btnAdicionarTreino_Click_1);
            // 
            // treeViewTreinos
            // 
            this.treeViewTreinos.Location = new System.Drawing.Point(12, 28);
            this.treeViewTreinos.Name = "treeViewTreinos";
            this.treeViewTreinos.Size = new System.Drawing.Size(242, 376);
            this.treeViewTreinos.TabIndex = 3;
            // 
            // lblExercicioSelecionado
            // 
            this.lblExercicioSelecionado.AutoSize = true;
            this.lblExercicioSelecionado.Location = new System.Drawing.Point(12, 12);
            this.lblExercicioSelecionado.Name = "lblExercicioSelecionado";
            this.lblExercicioSelecionado.Size = new System.Drawing.Size(0, 13);
            this.lblExercicioSelecionado.TabIndex = 4;
            // 
            // btnRemoverExercicio
            // 
            this.btnRemoverExercicio.Location = new System.Drawing.Point(93, 410);
            this.btnRemoverExercicio.Name = "btnRemoverExercicio";
            this.btnRemoverExercicio.Size = new System.Drawing.Size(75, 23);
            this.btnRemoverExercicio.TabIndex = 5;
            this.btnRemoverExercicio.Text = "Remover";
            this.btnRemoverExercicio.UseVisualStyleBackColor = true;
            this.btnRemoverExercicio.Click += new System.EventHandler(this.btnRemoverExercicio_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Sessões";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Altura em cm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Meta";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(267, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Peso";
            // 
            // txtSessoes
            // 
            this.txtSessoes.Location = new System.Drawing.Point(378, 135);
            this.txtSessoes.Name = "txtSessoes";
            this.txtSessoes.ReadOnly = true;
            this.txtSessoes.Size = new System.Drawing.Size(27, 20);
            this.txtSessoes.TabIndex = 22;
            this.txtSessoes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(341, 109);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.ReadOnly = true;
            this.txtAltura.Size = new System.Drawing.Size(100, 20);
            this.txtAltura.TabIndex = 21;
            // 
            // txtMeta
            // 
            this.txtMeta.Location = new System.Drawing.Point(341, 83);
            this.txtMeta.Name = "txtMeta";
            this.txtMeta.ReadOnly = true;
            this.txtMeta.Size = new System.Drawing.Size(100, 20);
            this.txtMeta.TabIndex = 20;
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(341, 57);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.ReadOnly = true;
            this.txtPeso.Size = new System.Drawing.Size(100, 20);
            this.txtPeso.TabIndex = 19;
            // 
            // TelaTreinos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSessoes);
            this.Controls.Add(this.txtAltura);
            this.Controls.Add(this.txtMeta);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemoverExercicio);
            this.Controls.Add(this.lblExercicioSelecionado);
            this.Controls.Add(this.treeViewTreinos);
            this.Controls.Add(this.btnAdicionarTreino);
            this.Name = "TelaTreinos";
            this.Text = "TelaTreinos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAdicionarTreino;
        private System.Windows.Forms.TreeView treeViewTreinos;
        private System.Windows.Forms.Label lblExercicioSelecionado;
        private System.Windows.Forms.Button btnRemoverExercicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSessoes;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.TextBox txtMeta;
        private System.Windows.Forms.TextBox txtPeso;
    }
}