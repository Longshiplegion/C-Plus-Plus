namespace Milestone5
{
    partial class GameForm
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
            panel1 = new Panel();
            PlayAgain = new Button();
            label1 = new Label();
            InitialTextBox = new TextBox();
            SubmitButton = new Button();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(40, 37);
            panel1.Name = "panel1";
            panel1.Size = new Size(655, 354);
            panel1.TabIndex = 0;
            // 
            // PlayAgain
            // 
            PlayAgain.Location = new Point(620, 418);
            PlayAgain.Name = "PlayAgain";
            PlayAgain.Size = new Size(75, 23);
            PlayAgain.TabIndex = 1;
            PlayAgain.Text = "Play Again";
            PlayAgain.UseVisualStyleBackColor = true;
            PlayAgain.Visible = false;
            PlayAgain.Click += PlayAgain_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(83, 421);
            label1.Name = "label1";
            label1.Size = new Size(131, 15);
            label1.TabIndex = 0;
            label1.Text = "Please enter your initals";
            label1.UseMnemonic = false;
            label1.Visible = false;
            // 
            // InitialTextBox
            // 
            InitialTextBox.Location = new Point(233, 418);
            InitialTextBox.Name = "InitialTextBox";
            InitialTextBox.Size = new Size(100, 23);
            InitialTextBox.TabIndex = 2;
            InitialTextBox.Visible = false;
            // 
            // SubmitButton
            // 
            SubmitButton.Location = new Point(351, 418);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(75, 23);
            SubmitButton.TabIndex = 3;
            SubmitButton.Text = "Submit";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Visible = false;
            SubmitButton.Click += SubmitButton_Click;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SubmitButton);
            Controls.Add(InitialTextBox);
            Controls.Add(label1);
            Controls.Add(PlayAgain);
            Controls.Add(panel1);
            Name = "GameForm";
            Text = "GameForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button PlayAgain;
        private Label label1;
        private TextBox InitialTextBox;
        private Button SubmitButton;
    }
}