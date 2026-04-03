namespace TypingPractice
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            label2 = new Label();
            ver = new Label();
            Startbutton = new Button();
            gamebutton = new Button();
            creditbutton = new Button();
            settings = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("태나다체 ", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label2.ForeColor = Color.White;
            label2.Location = new Point(298, 74);
            label2.Name = "label2";
            label2.Size = new Size(185, 46);
            label2.TabIndex = 1;
            label2.Text = "타자수련장";
            // 
            // ver
            // 
            ver.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ver.AutoSize = true;
            ver.BackColor = Color.Transparent;
            ver.Font = new Font("태나다체 ", 10F, FontStyle.Bold);
            ver.ForeColor = Color.White;
            ver.Location = new Point(12, 423);
            ver.Name = "ver";
            ver.Size = new Size(65, 18);
            ver.TabIndex = 2;
            ver.Text = "v0.0.0.0";
            // 
            // Startbutton
            // 
            Startbutton.Anchor = AnchorStyles.Top;
            Startbutton.BackColor = Color.Transparent;
            Startbutton.BackgroundImage = (Image)resources.GetObject("Startbutton.BackgroundImage");
            Startbutton.BackgroundImageLayout = ImageLayout.Stretch;
            Startbutton.Font = new Font("태나다체 ", 25F, FontStyle.Bold);
            Startbutton.ForeColor = SystemColors.ControlText;
            Startbutton.Location = new Point(298, 205);
            Startbutton.Name = "Startbutton";
            Startbutton.Size = new Size(185, 69);
            Startbutton.TabIndex = 3;
            Startbutton.Text = "연습 시작";
            Startbutton.UseVisualStyleBackColor = false;
            Startbutton.Click += Startbutton_Click;
            // 
            // gamebutton
            // 
            gamebutton.Anchor = AnchorStyles.Top;
            gamebutton.BackColor = Color.Transparent;
            gamebutton.BackgroundImage = (Image)resources.GetObject("gamebutton.BackgroundImage");
            gamebutton.BackgroundImageLayout = ImageLayout.Stretch;
            gamebutton.Font = new Font("태나다체 ", 25F, FontStyle.Bold);
            gamebutton.ForeColor = SystemColors.ControlText;
            gamebutton.Location = new Point(107, 205);
            gamebutton.Name = "gamebutton";
            gamebutton.Size = new Size(185, 69);
            gamebutton.TabIndex = 4;
            gamebutton.Text = "게임";
            gamebutton.UseVisualStyleBackColor = false;
            gamebutton.Click += gamebutton_Click;
            // 
            // creditbutton
            // 
            creditbutton.Anchor = AnchorStyles.Top;
            creditbutton.BackColor = Color.Transparent;
            creditbutton.BackgroundImage = (Image)resources.GetObject("creditbutton.BackgroundImage");
            creditbutton.BackgroundImageLayout = ImageLayout.Stretch;
            creditbutton.Font = new Font("태나다체 ", 25F, FontStyle.Bold);
            creditbutton.ForeColor = SystemColors.ControlText;
            creditbutton.Location = new Point(489, 205);
            creditbutton.Name = "creditbutton";
            creditbutton.Size = new Size(185, 69);
            creditbutton.TabIndex = 5;
            creditbutton.Text = "크레딧";
            creditbutton.UseVisualStyleBackColor = false;
            creditbutton.Click += creditbutton_Click;
            // 
            // settings
            // 
            settings.Anchor = AnchorStyles.Top;
            settings.BackColor = Color.Transparent;
            settings.BackgroundImage = (Image)resources.GetObject("settings.BackgroundImage");
            settings.BackgroundImageLayout = ImageLayout.Stretch;
            settings.Font = new Font("태나다체 ", 25F, FontStyle.Bold);
            settings.ForeColor = SystemColors.ControlText;
            settings.Location = new Point(298, 280);
            settings.Name = "settings";
            settings.Size = new Size(185, 69);
            settings.TabIndex = 6;
            settings.Text = "설정";
            settings.UseVisualStyleBackColor = false;
            settings.Visible = false;
            settings.Click += settings_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(settings);
            Controls.Add(creditbutton);
            Controls.Add(gamebutton);
            Controls.Add(Startbutton);
            Controls.Add(ver);
            Controls.Add(label2);
            Name = "Main";
            ShowIcon = false;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label ver;
        private Button Startbutton;
        private Button gamebutton;
        private Button creditbutton;
        private Button settings;
    }
}
