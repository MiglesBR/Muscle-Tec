
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
            this.SuspendLayout();
            // 
            // btnAdicionarTreino
            // 
            this.btnAdicionarTreino.Location = new System.Drawing.Point(12, 410);
            this.btnAdicionarTreino.Name = "btnAdicionarTreino";
            this.btnAdicionarTreino.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionarTreino.TabIndex = 2;
            this.btnAdicionarTreino.Text = "Adicionar";
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
            this.lblExercicioSelecionado.Location = new System.Drawing.Point(260, 12);
            this.lblExercicioSelecionado.Name = "lblExercicioSelecionado";
            this.lblExercicioSelecionado.Size = new System.Drawing.Size(0, 13);
            this.lblExercicioSelecionado.TabIndex = 4;
            // 
            // btnRemoverExercicio
            // 
            this.btnRemoverExercicio.Location = new System.Drawing.Point(260, 28);
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
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // TelaTreinos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}