using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace TypingPractice
{
    public partial class CPALANHAE2 : Form
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

        private char[] practiceChars = { 'ㅂ', 'ㅈ', 'ㄷ', 'ㄱ' };

        public CPALANHAE2(int level)
        {
            InitializeComponent();
            SetupUI();
            practiceChars = GetCharsForLevel(level);
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

        private char[] GetCharsForLevel(int level)
        {
            switch (level)
            {
                case 1: return new char[] { 'ㅁ', 'ㄴ', 'ㅇ', 'ㄹ', 'ㅓ', 'ㅏ', 'ㅣ', ';'};
                case 2: return new char[] { 'ㅂ', 'ㅈ', 'ㄷ', 'ㄱ' };
                case 3: return new char[] { 'ㅅ', 'ㅛ', 'ㅎ', 'ㅗ', 'ㅠ', 'ㅜ' };
                case 4: return new char[] { 'ㅕ', 'ㅑ', 'ㅐ', 'ㅔ' };
                case 5: return new char[] { 'ㅋ', 'ㅌ', 'ㅊ', 'ㅍ' };
                case 6: return new char[] { 'ㅜ', 'ㅡ', ',', '.' };
                case 7: return new char[] { 'ㅂ', 'ㅈ', 'ㄷ', 'ㄱ', 'ㅅ' };
                case 8: return new char[] { 'ㅕ', 'ㅑ', 'ㅐ', 'ㅔ' };
                default: return practiceChars;
            }
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

        private void Playsound(bool isCorrect)
        {
            Task.Run(() =>
            {
                try
                {
                    // 실행 파일 기준 Resources 폴더 경로 구성
                    string basePath = AppDomain.CurrentDomain.BaseDirectory;
                    string resourcesPath = Path.Combine(basePath, "Resources");

                    // 조건에 따라 파일 선택
                    string fileName = isCorrect ? "correct.wav" : "wrong.wav";
                    string filePath = Path.Combine(resourcesPath, fileName);

                    // 파일 존재 여부 확인
                    if (!File.Exists(filePath))
                    {
                        return;
                    }

                    SoundPlayer player = new SoundPlayer();

                    player.SoundLocation = filePath;
                    player.Load();
                    player.Play();
                }
                catch (Exception ex)
                {
                    // 필요 시 로그 처리 가능
                    MessageBox.Show($"Sound playback error: {ex.Message}");
                }
            });
        }

        private void CPALANHAE_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isGameRunning) return; // ⭐ 입력 차단

            char input = ConvertKeyToChar(e.KeyCode);
            if (input == '\0') return;

            totalCount++;

            if (input == currentChar)
            {
                Playsound(true);

                correctCount++;

                currentChar = nextChar;
                nextChar = GetRandomChar();

                UpdatePointFromChar(currentChar);
            }
            else
            {
                Playsound(false);
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

                case Keys.Q: return 'ㅂ';
                case Keys.W: return 'ㅈ';
                case Keys.E: return 'ㄷ';
                case Keys.R: return 'ㄱ';

                case Keys.T: return 'ㅅ';
                case Keys.Y: return 'ㅛ';
                case Keys.U: return 'ㅕ';
                case Keys.I: return 'ㅑ';
                case Keys.O: return 'ㅐ';
                case Keys.P: return 'ㅔ';

                //case Keys.A: return 'ㅁ';
                //case Keys.S: return 'ㄴ';
                //case Keys.D: return 'ㅇ';
                //case Keys.F: return 'ㄹ';
                case Keys.G: return 'ㅎ';
                case Keys.H: return 'ㅗ';
                //case Keys.J: return 'ㅓ';
                //case Keys.K: return 'ㅏ';
                //case Keys.L: return 'ㅣ';
                case Keys.Z: return 'ㅋ';
                case Keys.X: return 'ㅌ';
                case Keys.C: return 'ㅊ';
                case Keys.V: return 'ㅍ';
                case Keys.B: return 'ㅠ';
                case Keys.N: return 'ㅜ';
                case Keys.M: return 'ㅡ';
                case Keys.Oemcomma: return ',';
                case Keys.OemPeriod: return '.';

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
            isGameRunning = false;
            statsTimer.Stop();

            resultpanel.Visible = true;

            double seconds = (DateTime.Now - startTime).TotalSeconds;
            if (seconds < 1) seconds = 1; // 0나누기 방지

            // 1. 일반적인 '타수' (정확하게 친 글자 기준 분당 속도)
            double cpm = (correctCount / seconds) * 60;

            // 2. 정확도
            double accuracy = (totalCount == 0) ? 0 : ((double)correctCount / totalCount) * 100;

            resulttext.Lines = new string[]
            {
                $"평균 타수: {cpm:F0}타",
                $"정확도: {accuracy:F1}%",
                $"소요 시간: {seconds:F1}초",
                $"오타 수: {totalCount - correctCount}개"
            };
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

                case 'ㅂ': UpdatePointPosition(1, 1); break;
                case 'ㅈ': UpdatePointPosition(1, 2); break;
                case 'ㄷ': UpdatePointPosition(1, 3); break;
                case 'ㄱ': UpdatePointPosition(1, 4); break;

                case 'ㅅ': UpdatePointPosition(1, 5); break;
                case 'ㅛ': UpdatePointPosition(1, 6); break;
                case 'ㅎ': UpdatePointPosition(2, 5); break;
                case 'ㅗ': UpdatePointPosition(2, 6); break;
                case 'ㅠ': UpdatePointPosition(3, 5); break;
                case 'ㅜ': UpdatePointPosition(3, 6); break;

                case 'ㅕ': UpdatePointPosition(1, 7); break;
                case 'ㅑ': UpdatePointPosition(1, 8); break;
                case 'ㅐ': UpdatePointPosition(1, 9); break;
                case 'ㅔ': UpdatePointPosition(1, 10); break;

                case 'ㅋ': UpdatePointPosition(3, 1); break;
                case 'ㅌ': UpdatePointPosition(3, 2); break;
                case 'ㅊ': UpdatePointPosition(3, 3); break;
                case 'ㅍ': UpdatePointPosition(3, 4); break;

                //case 'ㅜ': UpdatePointPosition(3, 6); break;
                case 'ㅡ': UpdatePointPosition(3, 7); break;
                case ',': UpdatePointPosition(3, 8); break;
                case '.': UpdatePointPosition(3, 9); break;
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

            point.Location = new Point(x + 10, y + 10);
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
}