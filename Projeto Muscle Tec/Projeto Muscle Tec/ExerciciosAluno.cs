using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Muscle_Tec
{
    public partial class ExerciciosAluno : Form
    {
        public ExerciciosAluno(DataTable exercicios)
        {
            InitializeComponent();
            dataGridView1.DataSource = exercicios;
        }
    }
}
