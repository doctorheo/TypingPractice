namespace TypingPractice
{
    partial class CPALANHAE1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPALANHAE1));
            panel1 = new Panel();
            point = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            resultpanel = new Panel();
            resulttext = new TextBox();
            label4 = new Label();
            panel1.SuspendLayout();
            resultpanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(point);
            panel1.Location = new Point(12, 152);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 286);
            panel1.TabIndex = 0;
            // 
            // point
            // 
            point.AutoSize = true;
            point.Font = new Font("맑은 고딕", 20F);
            point.ForeColor = Color.Red;
            point.Location = new Point(3, 9);
            point.Name = "point";
            point.Size = new Size(44, 37);
            point.TabIndex = 6;
            point.Text = "●";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("태나다체 ", 72F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label1.ForeColor = Color.White;
            label1.Location = new Point(316, 9);
            label1.Name = "label1";
            label1.Size = new Size(145, 116);
            label1.TabIndex = 1;
            label1.Text = "ㅁ";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("태나다체 ", 60F, FontStyle.Bold);
            label2.ForeColor = Color.LightGray;
            label2.Location = new Point(550, 22);
            label2.Name = "label2";
            label2.Size = new Size(122, 97);
            label2.TabIndex = 2;
            label2.Text = "ㄹ";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(12, 134);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 3;
            label3.Text = "label3";
            // 
            // resultpanel
            // 
            resultpanel.Anchor = AnchorStyles.None;
            resultpanel.BackColor = Color.White;
            resultpanel.Controls.Add(resulttext);
            resultpanel.Controls.Add(label4);
            resultpanel.Location = new Point(222, 122);
            resultpanel.Name = "resultpanel";
            resultpanel.Size = new Size(335, 217);
            resultpanel.TabIndex = 4;
            resultpanel.Visible = false;
            // 
            // resulttext
            // 
            resulttext.BackColor = Color.White;
            resulttext.Font = new Font("태나다체 ", 15F, FontStyle.Bold);
            resulttext.Location = new Point(64, 92);
            resulttext.Multiline = true;
            resulttext.Name = "resulttext";
            resulttext.ReadOnly = true;
            resulttext.Size = new Size(204, 107);
            resulttext.TabIndex = 1;
            resulttext.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("태나다체 ", 36F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label4.Location = new Point(64, 30);
            label4.Name = "label4";
            label4.Size = new Size(204, 59);
            label4.TabIndex = 0;
            label4.Text = "검사 완료";
            // 
            // CPALANHAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(resultpanel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "CPALANHAE";
            ShowIcon = false;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            resultpanel.ResumeLayout(false);
            resultpanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label point;
        private Label label1;
        private Label label2;
        private Label label3;
        private Panel resultpanel;
        private Label label4;
        private TextBox resulttext;
    }
}