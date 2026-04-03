using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Reflection;

namespace TypingPractice
{
    public partial class Main : Form
    {
        public Main()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            Version currentVersion = Assembly.GetExecutingAssembly().GetName().Version;
            ver.Text = "v" + currentVersion.ToString();
        }

        private void Startbutton_Click(object sender, EventArgs e)
        {
            select typeForm = new select();
            typeForm.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gamebutton_Click(object sender, EventArgs e)
        {
            GameE gameForm = new GameE();
            gameForm.Show();
            this.Hide();
        }

        private void creditbutton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("효과음:https://www.myinstants.com/\n코드:한스크, Gemini, ChatGPT\n이미지:ChatGPT", "크레딧", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void settings_Click(object sender, EventArgs e)
        {

        }
    }
}
