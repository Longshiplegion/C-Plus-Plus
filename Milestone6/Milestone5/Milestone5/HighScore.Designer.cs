namespace Milestone5
{
    partial class HighScore
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
            listBox1 = new ListBox();
            PlayAgainButton = new Button();
            QuitButton = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(33, 22);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(727, 334);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // PlayAgainButton
            // 
            PlayAgainButton.Location = new Point(203, 394);
            PlayAgainButton.Name = "PlayAgainButton";
            PlayAgainButton.Size = new Size(101, 23);
            PlayAgainButton.TabIndex = 1;
            PlayAgainButton.Text = "Play Again?";
            PlayAgainButton.UseVisualStyleBackColor = true;
            PlayAgainButton.Click += PlayAgainButton_Click;
            // 
            // QuitButton
            // 
            QuitButton.Location = new Point(436, 394);
            QuitButton.Name = "QuitButton";
            QuitButton.Size = new Size(75, 23);
            QuitButton.TabIndex = 2;
            QuitButton.Text = "Quit";
            QuitButton.UseVisualStyleBackColor = true;
            QuitButton.Click += QuitButton_Click;
            // 
            // HighScore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(QuitButton);
            Controls.Add(PlayAgainButton);
            Controls.Add(listBox1);
            Name = "HighScore";
            Text = "HighScore";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button PlayAgainButton;
        private Button QuitButton;
    }
}