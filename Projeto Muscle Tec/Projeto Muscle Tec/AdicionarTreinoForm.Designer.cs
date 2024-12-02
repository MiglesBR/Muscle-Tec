
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
            this.listBoxExercicios.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxExercicios.FormattingEnabled = true;
            this.listBoxExercicios.ItemHeight = 21;
            this.listBoxExercicios.Location = new System.Drawing.Point(256, 111);
            this.listBoxExercicios.Name = "listBoxExercicios";
            this.listBoxExercicios.Size = new System.Drawing.Size(213, 109);
            this.listBoxExercicios.TabIndex = 3;
            // 
            // listBoxExerciciosAdicionados
            // 
            this.listBoxExerciciosAdicionados.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxExerciciosAdicionados.FormattingEnabled = true;
            this.listBoxExerciciosAdicionados.ItemHeight = 21;
            this.listBoxExerciciosAdicionados.Location = new System.Drawing.Point(475, 111);
            this.listBoxExerciciosAdicionados.Name = "listBoxExerciciosAdicionados";
            this.listBoxExerciciosAdicionados.Size = new System.Drawing.Size(213, 109);
            this.listBoxExerciciosAdicionados.TabIndex = 4;
            this.listBoxExerciciosAdicionados.SelectedIndexChanged += new System.EventHandler(this.listBoxExerciciosAdicionados_SelectedIndexChanged);
            // 
            // btnRemoverExercicio
            // 
            this.btnRemoverExercicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.btnRemoverExercicio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoverExercicio.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoverExercicio.ForeColor = System.Drawing.Color.White;
            this.btnRemoverExercicio.Location = new System.Drawing.Point(416, 262);
            this.btnRemoverExercicio.Name = "btnRemoverExercicio";
            this.btnRemoverExercicio.Size = new System.Drawing.Size(112, 40);
            this.btnRemoverExercicio.TabIndex = 6;
            this.btnRemoverExercicio.Text = "Remover";
            this.btnRemoverExercicio.UseVisualStyleBackColor = false;
            this.btnRemoverExercicio.Click += new System.EventHandler(this.btnRemoverExercicio_Click);
            // 
            // btnSalvarTreino
            // 
            this.btnSalvarTreino.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.btnSalvarTreino.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalvarTreino.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarTreino.ForeColor = System.Drawing.Color.White;
            this.btnSalvarTreino.Location = new System.Drawing.Point(534, 262);
            this.btnSalvarTreino.Name = "btnSalvarTreino";
            this.btnSalvarTreino.Size = new System.Drawing.Size(112, 40);
            this.btnSalvarTreino.TabIndex = 7;
            this.btnSalvarTreino.Text = "Salvar";
            this.btnSalvarTreino.UseVisualStyleBackColor = false;
            this.btnSalvarTreino.Click += new System.EventHandler(this.btnSalvarTreino_Click);
            // 
            // btnAdicionarExercicio
            // 
            this.btnAdicionarExercicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.btnAdicionarExercicio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdicionarExercicio.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarExercicio.ForeColor = System.Drawing.Color.White;
            this.btnAdicionarExercicio.Location = new System.Drawing.Point(298, 262);
            this.btnAdicionarExercicio.Name = "btnAdicionarExercicio";
            this.btnAdicionarExercicio.Size = new System.Drawing.Size(112, 40);
            this.btnAdicionarExercicio.TabIndex = 8;
            this.btnAdicionarExercicio.Text = "Adicionar";
            this.btnAdicionarExercicio.UseVisualStyleBackColor = false;
            this.btnAdicionarExercicio.Click += new System.EventHandler(this.btnAdicionarExercicio_Click);
            // 
            // txtNomeTreino
            // 
            this.txtNomeTreino.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeTreino.Location = new System.Drawing.Point(311, 72);
            this.txtNomeTreino.Name = "txtNomeTreino";
            this.txtNomeTreino.Size = new System.Drawing.Size(322, 33);
            this.txtNomeTreino.TabIndex = 0;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(311, 33);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(322, 33);
            this.txtDescricao.TabIndex = 1;
            this.txtDescricao.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(172, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nome Treino:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(112, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Adicionar Descrição:";
            // 
            // lblExercicioSelecionado
            // 
            this.lblExercicioSelecionado.AutoSize = true;
            this.lblExercicioSelecionado.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExercicioSelecionado.Location = new System.Drawing.Point(112, 323);
            this.lblExercicioSelecionado.Name = "lblExercicioSelecionado";
            this.lblExercicioSelecionado.Size = new System.Drawing.Size(186, 25);
            this.lblExercicioSelecionado.TabIndex = 11;
            this.lblExercicioSelecionado.Text = "Descrição exercício:";
            // 
            // AdicionarTreinoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 501);
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