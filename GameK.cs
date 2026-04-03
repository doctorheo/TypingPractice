using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace TypingPractice
{
    public partial class GameK : Form
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

        public GameK()
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
                    // 짧고 쉬운 단어
                    words = new string[]
                    {
            "사과", "바나나", "우유", "학교", "친구",
            "하늘", "바다", "나무", "고양이", "강아지"
                    };
                    wordTimer.Interval = 4500; // 널널
                    hp = 7;
                    break;

                case Difficulty.Medium:
                    // 중간 길이 단어
                    words = new string[]
                    {
            "컴퓨터", "마우스", "키보드", "인터넷", "프로그램",
            "게임하기", "유튜브", "카메라", "핸드폰", "이어폰"
                    };
                    wordTimer.Interval = 3000; // 보통
                    hp = 5;
                    break;

                case Difficulty.Hard:
                    // 긴 단어 + 빡셈
                    words = new string[]
                    {
            "프로그래밍", "알고리즘", "인공지능", "데이터베이스",
            "운영체제", "소프트웨어", "네트워크", "객체지향",
            "비동기처리", "멀티스레딩"
                    };
                    wordTimer.Interval = 1800; // 빠름
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

    if (!currentWord.StartsWith(input))
    {
        // 틀림
        input = "";
        lblInput.Text = "";
        Playsound(false);
        return;
    }

    if (input == currentWord)
    {
        // 성공
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