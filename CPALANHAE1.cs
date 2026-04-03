using System;
using System.Drawing;
using System.Windows.Forms;

namespace TypingPractice
{
    public partial class CPALANHAE1 : Form
    {
        private FadeLabel Count;
        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.Timer statsTimer;

        private string[] texts = { "3", "2", "1", "시작!" };
        private int index = 0;

        private float fontSize = 20f;
        private int alpha = 255;

        // 🔥 상태
        private bool isGameRunning = false;

        // 🔥 타자 연습
        private char currentChar;
        private char nextChar;

        private int correctCount = 0;
        private int totalCount = 0;
        private int maxCount = 100;

        private DateTime startTime;
        private Random rand = new Random();

        private char[] practiceChars = { 'ㅁ', 'ㄴ', 'ㅇ', 'ㄹ', 'ㅓ', 'ㅏ', 'ㅣ', ';' };

        public CPALANHAE1()
        {
            InitializeComponent();
            SetupUI();
            StartAnimation();
            StartPractice();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += (s, e) =>
            {
                Main mainForm = Application.OpenForms["Main"] as Main;
                if (mainForm != null)
                {
                    mainForm.Show();
                }
            };
        }

        private void StartPractice()
        {
            this.KeyPreview = true;
            this.KeyDown += CPALANHAE_KeyDown;

            startTime = DateTime.Now;

            currentChar = GetRandomChar();
            nextChar = GetRandomChar();

            isGameRunning = true; // ⭐ 시작

            UpdateLabels();
            UpdatePointFromChar(currentChar);

            statsTimer = new System.Windows.Forms.Timer();
            statsTimer.Interval = 100;
            statsTimer.Tick += (s, e) =>
            {
                if (isGameRunning)
                    UpdateLabels();
            };
            statsTimer.Start();
        }

        private char GetRandomChar()
        {
            return practiceChars[rand.Next(practiceChars.Length)];
        }

        private void CPALANHAE_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isGameRunning) return; // ⭐ 입력 차단

            char input = ConvertKeyToChar(e.KeyCode);
            if (input == '\0') return;

            totalCount++;

            if (input == currentChar)
            {
                correctCount++;

                currentChar = nextChar;
                nextChar = GetRandomChar();

                UpdatePointFromChar(currentChar);
            }

            UpdateLabels();

            if (totalCount >= maxCount)
            {
                ShowResult();
            }
        }

        private char ConvertKeyToChar(Keys key)
        {
            switch (key)
            {
                case Keys.A: return 'ㅁ';
                case Keys.S: return 'ㄴ';
                case Keys.D: return 'ㅇ';
                case Keys.F: return 'ㄹ';

                case Keys.J: return 'ㅓ';
                case Keys.K: return 'ㅏ';
                case Keys.L: return 'ㅣ';
                case Keys.Oem1: return ';';

                default: return '\0';
            }
        }

        private void UpdateLabels()
        {
            label1.Text = currentChar.ToString();
            label2.Text = nextChar.ToString();

            double seconds = (DateTime.Now - startTime).TotalSeconds;

            double tps = totalCount / Math.Max(seconds, 1);
            double accuracy = totalCount == 0 ? 0 : (double)correctCount / totalCount * 100;

            label3.Text = $"타수: {tps:F1}/s  정확도: {accuracy:F1}%";
        }

        private void ShowResult()
        {
            isGameRunning = false; // ⭐ 완전 종료

            statsTimer.Stop();

            panel1.Visible = false;
            resultpanel.Visible = true;

            double seconds = (DateTime.Now - startTime).TotalSeconds;

            double tps = totalCount / Math.Max(seconds, 1);
            double accuracy = totalCount == 0 ? 0 : (double)correctCount / totalCount * 100;

            resulttext.Text =
                $"총 입력: {totalCount}타\n" +
                $"정확 입력: {correctCount}타\n" +
                $"정확도: {accuracy:F1}%\n" +
                $"속도: {tps:F1} 타/초";
        }

        private void UpdatePointFromChar(char c)
        {
            switch (c)
            {
                case 'ㅁ': UpdatePointPosition(2, 1); break;
                case 'ㄴ': UpdatePointPosition(2, 2); break;
                case 'ㅇ': UpdatePointPosition(2, 3); break;
                case 'ㄹ': UpdatePointPosition(2, 4); break;

                case 'ㅓ': UpdatePointPosition(2, 7); break;
                case 'ㅏ': UpdatePointPosition(2, 8); break;
                case 'ㅣ': UpdatePointPosition(2, 9); break;
                case ';': UpdatePointPosition(2, 10); break;
            }
        }

        private void UpdatePointPosition(int krow, int kindex)
        {
            int startX = 50;
            int gapX = 50;
            int gapY = 57;

            int x;
            int y = krow * gapY;

            if (kindex == 0) x = startX;
            else if (kindex == 1)
            {
                if (krow == 1) x = 76;
                else if (krow == 2) x = 89;
                else if (krow == 3) x = 116;
                else x = startX + gapX;
            }
            else
            {
                int secondX;
                if (krow == 1) secondX = 76;
                else if (krow == 2) secondX = 89;
                else if (krow == 3) secondX = 116;
                else secondX = startX + gapX;

                x = secondX + (gapX * (kindex - 1));
            }

            point.Location = new Point(x+10, y+10);
        }

        private void SetupUI()
        {
            Count = new FadeLabel();
            Count.Size = new Size(300, 150);
            Count.Location = new Point(
                (this.ClientSize.Width - Count.Width) / 2,
                (this.ClientSize.Height - Count.Height) / 2
            );

            Count.Font = new Font("Arial", 20, FontStyle.Bold);
            Count.ForeColor = Color.Black;
            Count.Text = texts[index];

            this.Controls.Add(Count);

            this.Resize += (s, e) =>
            {
                Count.Location = new Point(
                    (this.ClientSize.Width - Count.Width) / 2,
                    (this.ClientSize.Height - Count.Height) / 2
                );
            };
        }

        private void StartAnimation()
        {
            panel1.Visible = false;
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 30;
            animationTimer.Tick += Animate;
            animationTimer.Start();
        }

        private void Animate(object sender, EventArgs e)
        {
            fontSize += 1.5f;
            alpha -= 10;

            if (alpha <= 0)
            {
                index++;

                if (index >= texts.Length)
                {
                    Count.Visible = false;
                    animationTimer.Stop();
                    panel1.Visible = true;
                    return;
                }

                Count.Text = texts[index];
                fontSize = 20f;
                alpha = 255;
            }

            Count.Font = new Font(Count.Font.FontFamily, fontSize, FontStyle.Bold);
            Count.Alpha = alpha;
            Count.Invalidate();
        }
    }

    public class FadeLabel : Control
    {
        public int Alpha { get; set; } = 255;

        protected override void OnPaint(PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(Alpha, this.ForeColor)))
            {
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                e.Graphics.DrawString(this.Text, this.Font, brush, this.ClientRectangle, sf);
            }
        }
    }
}