
namespace Projeto_Muscle_Tec
{
    partial class AdicionarTreinoForm
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.listBoxExercicios = new System.Windows.Forms.ListBox();
            this.listBoxExerciciosAdicionados = new System.Windows.Forms.ListBox();
            this.btnRemoverExercicio = new System.Windows.Forms.Button();
            this.btnSalvarTreino = new System.Windows.Forms.Button();
            this.btnAdicionarExercicio = new System.Windows.Forms.Button();
            this.txtNomeTreino = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblExercicioSelecionado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // listBoxExercicios
            // 
            this.listBoxExercicios.FormattingEnabled = true;
            this.listBoxExercicios.Location = new System.Drawing.Point(116, 110);
            this.listBoxExercicios.Name = "listBoxExercicios";
            this.listBoxExercicios.Size = new System.Drawing.Size(120, 95);
            this.listBoxExercicios.TabIndex = 3;
            // 
            // listBoxExerciciosAdicionados
            // 
            this.listBoxExerciciosAdicionados.FormattingEnabled = true;
            this.listBoxExerciciosAdicionados.Location = new System.Drawing.Point(257, 110);
            this.listBoxExerciciosAdicionados.Name = "listBoxExerciciosAdicionados";
            this.listBoxExerciciosAdicionados.Size = new System.Drawing.Size(120, 95);
            this.listBoxExerciciosAdicionados.TabIndex = 4;
            // 
            // btnRemoverExercicio
            // 
            this.btnRemoverExercicio.Location = new System.Drawing.Point(211, 211);
            this.btnRemoverExercicio.Name = "btnRemoverExercicio";
            this.btnRemoverExercicio.Size = new System.Drawing.Size(75, 23);
            this.btnRemoverExercicio.TabIndex = 6;
            this.btnRemoverExercicio.Text = "Remover";
            this.btnRemoverExercicio.UseVisualStyleBackColor = true;
            this.btnRemoverExercicio.Click += new System.EventHandler(this.btnRemoverExercicio_Click);
            // 
            // btnSalvarTreino
            // 
            this.btnSalvarTreino.Location = new System.Drawing.Point(292, 211);
            this.btnSalvarTreino.Name = "btnSalvarTreino";
            this.btnSalvarTreino.Size = new System.Drawing.Size(75, 23);
            this.btnSalvarTreino.TabIndex = 7;
            this.btnSalvarTreino.Text = "Salvar";
            this.btnSalvarTreino.UseVisualStyleBackColor = true;
            this.btnSalvarTreino.Click += new System.EventHandler(this.btnSalvarTreino_Click);
            // 
            // btnAdicionarExercicio
            // 
            this.btnAdicionarExercicio.Location = new System.Drawing.Point(130, 211);
            this.btnAdicionarExercicio.Name = "btnAdicionarExercicio";
            this.btnAdicionarExercicio.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionarExercicio.TabIndex = 8;
            this.btnAdicionarExercicio.Text = "Adicionar";
            this.btnAdicionarExercicio.UseVisualStyleBackColor = true;
            this.btnAdicionarExercicio.Click += new System.EventHandler(this.btnAdicionarExercicio_Click);
            // 
            // txtNomeTreino
            // 
            this.txtNomeTreino.Location = new System.Drawing.Point(186, 58);
            this.txtNomeTreino.Name = "txtNomeTreino";
            this.txtNomeTreino.Size = new System.Drawing.Size(100, 20);
            this.txtNomeTreino.TabIndex = 0;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(186, 84);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(100, 20);
            this.txtDescricao.TabIndex = 1;
            this.txtDescricao.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Criar Treino";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Adicionar Descrição";
            // 
            // lblExercicioSelecionado
            // 
            this.lblExercicioSelecionado.AutoSize = true;
            this.lblExercicioSelecionado.Location = new System.Drawing.Point(383, 110);
            this.lblExercicioSelecionado.Name = "lblExercicioSelecionado";
            this.lblExercicioSelecionado.Size = new System.Drawing.Size(105, 13);
            this.lblExercicioSelecionado.TabIndex = 11;
            this.lblExercicioSelecionado.Text = "Descrição exercício:";
            // 
            // AdicionarTreinoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblExercicioSelecionado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdicionarExercicio);
            this.Controls.Add(this.btnSalvarTreino);
            this.Controls.Add(this.btnRemoverExercicio);
            this.Controls.Add(this.listBoxExerciciosAdicionados);
            this.Controls.Add(this.listBoxExercicios);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtNomeTreino);
            this.Name = "AdicionarTreinoForm";
            this.Text = "AdicionarTreinoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ListBox listBoxExercicios;
        private System.Windows.Forms.ListBox listBoxExerciciosAdicionados;
        private System.Windows.Forms.Button btnRemoverExercicio;
        private System.Windows.Forms.Button btnSalvarTreino;
        private System.Windows.Forms.Button btnAdicionarExercicio;
        private System.Windows.Forms.TextBox txtNomeTreino;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblExercicioSelecionado;
    }
}