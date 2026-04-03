using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace TypingPractice
{
    public partial class GameE : Form
    {
        enum Difficulty { Easy, Medium, Hard }
        Difficulty currentDifficulty;

        Label lblWord;
        Label lblInput;
        Label lblStats;

        System.Windows.Forms.Timer gameTimer;
        System.Windows.Forms.Timer wordTimer;

        Random rand = new Random();

        string[] words = { "test" };
        string currentWord = "";
        string input = "";

        int score = 0;
        int hp = 5;

        DateTime startTime;

        public GameE()
        {
            InitializeComponent();
            InitUI();
            ShowDifficultyMenu();
        }

        void InitUI()
        {
            this.Text = "Typing Game";
            this.Size = new Size(800, 500);
            this.BackColor = Color.Black;
            this.KeyPreview = true;
            this.StartPosition = FormStartPosition.CenterScreen;

            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 200;
            gameTimer.Tick += GameTick;

            wordTimer = new System.Windows.Forms.Timer();
            wordTimer.Tick += WordTimeout;

            this.KeyPress += OnKeyPress;

            this.FormClosing += (s, e) =>
                {
                    Main mainForm = Application.OpenForms["Main"] as Main;
                    if (mainForm != null)
                    {
                        mainForm.Show();
                    }
                };
        }

        // ================= 난이도 선택 =================
        void ShowDifficultyMenu()
        {
            this.Controls.Clear();

            Panel panel = new Panel()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Black
            };

            Label title = new Label()
            {
                Text = "난이도 선택",
                ForeColor = Color.White,
                Font = new Font("맑은 고딕", 30, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 120,
                TextAlign = ContentAlignment.MiddleCenter
            };

            panel.Controls.Add(title);

            panel.Controls.Add(CreateButton("EASY", Color.Lime, Difficulty.Easy));
            panel.Controls.Add(CreateButton("MEDIUM", Color.Orange, Difficulty.Medium));
            panel.Controls.Add(CreateButton("HARD", Color.Red, Difficulty.Hard));

            this.Controls.Add(panel);
        }

        Button CreateButton(string text, Color color, Difficulty diff)
        {
            Button btn = new Button()
            {
                Text = text,
                Dock = DockStyle.Top,
                Height = 80,
                Font = new Font("맑은 고딕", 20, FontStyle.Bold),
                BackColor = color,
                FlatStyle = FlatStyle.Flat
            };

            btn.Click += (s, e) =>
            {
                currentDifficulty = diff;
                StartGameWithDifficulty();

                this.Focus();
            };

            return btn;
        }

        // ================= 난이도 적용 =================
        void StartGameWithDifficulty()
        {
            this.Controls.Clear();

            lblWord = new Label()
            {
                Dock = DockStyle.Top,
                Height = 150,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("맑은 고딕", 40, FontStyle.Bold),
                ForeColor = Color.White
            };

            lblInput = new Label()
            {
                Dock = DockStyle.Top,
                Height = 80,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("맑은 고딕", 24),
                ForeColor = Color.Lime
            };

            lblStats = new Label()
            {
                Dock = DockStyle.Bottom,
                Height = 120,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("맑은 고딕", 14),
                ForeColor = Color.White
            };

            this.Controls.Add(lblStats);
            this.Controls.Add(lblInput);
            this.Controls.Add(lblWord);

            switch (currentDifficulty)
            {
                case Difficulty.Easy:
                    words = new string[] { "cat", "dog", "sun", "book" };
                    wordTimer.Interval = 4000;
                    hp = 7;
                    break;

                case Difficulty.Medium:
                    words = new string[] { "apple", "banana", "orange", "keyboard" };
                    wordTimer.Interval = 3000;
                    hp = 5;
                    break;

                case Difficulty.Hard:
                    words = new string[] { "computer", "programming", "algorithm", "development" };
                    wordTimer.Interval = 2000;
                    hp = 3;
                    break;
            }

            StartGame();
        }

        // ================= 게임 시작 =================
        void StartGame()
        {
            score = 0;
            startTime = DateTime.Now;

            gameTimer.Start();
            NextWord();
        }

        void NextWord()
        {
            currentWord = words[rand.Next(words.Length)];
            input = "";

            lblWord.Text = currentWord;
            lblInput.Text = "";

            wordTimer.Stop();
            wordTimer.Start();
        }

        // ================= 입력 =================
        void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            input += e.KeyChar;
            lblInput.Text = input;

            if (e.KeyChar == (char)Keys.Back && input.Length > 0)
            {
                input = input.Substring(0, input.Length - 1);
                lblInput.Text = input;
                return;
            }

            if (!currentWord.StartsWith(input))
            {
                input = "";
                lblInput.Text = "";
                lblInput.ForeColor = Color.Red;
                Playsound(false);
                return;
            }

            lblInput.ForeColor = Color.Lime;

            if (input == currentWord)
            {
                score += currentWord.Length * 10;
                Playsound(true);
                NextWord();
            }
        }

        // ================= 시간 초과 =================
        void WordTimeout(object sender, EventArgs e)
        {
            hp--;
            Playsound(false);

            if (hp <= 0)
            {
                EndGame();
                return;
            }

            NextWord();
        }

        // ================= 상태 =================
        void GameTick(object sender, EventArgs e)
        {
            double sec = (DateTime.Now - startTime).TotalSeconds;
            double minutes = sec / 60.0;

            double tpm = minutes > 0 ? score / minutes : 0;

            lblStats.Text =
                $"점수: {score}\n" +
                $"HP: {hp}\n" +
                $"타수: {tpm:F0}";
        }

        void EndGame()
        {
            gameTimer.Stop();
            wordTimer.Stop();

            MessageBox.Show($"게임 종료!\n점수: {score}");
            ShowDifficultyMenu();
        }

        // ================= 사운드 =================
        private void Playsound(bool isCorrect)
        {
            Task.Run(() =>
            {
                try
                {
                    string basePath = AppDomain.CurrentDomain.BaseDirectory;
                    string resourcesPath = Path.Combine(basePath, "Resources");

                    string fileName = isCorrect ? "correct.wav" : "wrong.wav";
                    string filePath = Path.Combine(resourcesPath, fileName);

                    if (!File.Exists(filePath))
                        return;

                    SoundPlayer player = new SoundPlayer();
                    player.SoundLocation = filePath;
                    player.Load();
                    player.Play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sound playback error: {ex.Message}");
                }
            });
        }
    }
}