using System;
using System.Windows.Forms;

namespace Projeto_Muscle_Tec
{
    public partial class TelaInicial : Form
    {
        private Timer timer;

        public TelaInicial()
        {
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 3000; 
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();  
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();

            AbrirProximaTela();
        }

        private void AbrirProximaTela()
        {
            this.Hide(); // Esconde a tela atual

            Login Login = new Login();
            Login.Show();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            
        }
    }
}
