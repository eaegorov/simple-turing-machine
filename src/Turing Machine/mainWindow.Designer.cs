namespace Turing_Machine
{
    partial class mainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWindow));
            this.machineTimer = new System.Windows.Forms.Timer(this.components);
            this.renderTimer = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.readProgramButton = new System.Windows.Forms.Button();
            this.stepCountLabel = new System.Windows.Forms.Label();
            this.NextStepButton = new System.Windows.Forms.Button();
            this.ContinueButton = new System.Windows.Forms.Button();
            this.CurrentStateLabel = new System.Windows.Forms.Label();
            this.AnswerLabel = new System.Windows.Forms.Label();
            this.ShowOutputButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // machineTimer
            // 
            this.machineTimer.Tick += new System.EventHandler(this.machineTimer_Tick);
            // 
            // renderTimer
            // 
            this.renderTimer.Tick += new System.EventHandler(this.renderTimer_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(27, 223);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(157, 25);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Input";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StartButton.BackColor = System.Drawing.Color.LightGray;
            this.StartButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(185, 223);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(65, 25);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Enter";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // readProgramButton
            // 
            this.readProgramButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.readProgramButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.readProgramButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.readProgramButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readProgramButton.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readProgramButton.ForeColor = System.Drawing.Color.White;
            this.readProgramButton.Location = new System.Drawing.Point(502, 219);
            this.readProgramButton.Name = "readProgramButton";
            this.readProgramButton.Size = new System.Drawing.Size(131, 33);
            this.readProgramButton.TabIndex = 2;
            this.readProgramButton.Text = "Load file";
            this.readProgramButton.UseVisualStyleBackColor = false;
            this.readProgramButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // stepCountLabel
            // 
            this.stepCountLabel.AutoSize = true;
            this.stepCountLabel.BackColor = System.Drawing.Color.Transparent;
            this.stepCountLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.stepCountLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stepCountLabel.Location = new System.Drawing.Point(42, 3);
            this.stepCountLabel.Name = "stepCountLabel";
            this.stepCountLabel.Size = new System.Drawing.Size(44, 14);
            this.stepCountLabel.TabIndex = 3;
            this.stepCountLabel.Text = "Steps";
            // 
            // NextStepButton
            // 
            this.NextStepButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.NextStepButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.NextStepButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextStepButton.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.NextStepButton.Location = new System.Drawing.Point(359, 219);
            this.NextStepButton.Name = "NextStepButton";
            this.NextStepButton.Size = new System.Drawing.Size(87, 33);
            this.NextStepButton.TabIndex = 5;
            this.NextStepButton.Text = "Next step";
            this.NextStepButton.UseVisualStyleBackColor = true;
            this.NextStepButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // ContinueButton
            // 
            this.ContinueButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ContinueButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ContinueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ContinueButton.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.ContinueButton.Location = new System.Drawing.Point(271, 219);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Size = new System.Drawing.Size(82, 33);
            this.ContinueButton.TabIndex = 6;
            this.ContinueButton.Text = "...";
            this.ContinueButton.UseVisualStyleBackColor = true;
            this.ContinueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // CurrentStateLabel
            // 
            this.CurrentStateLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CurrentStateLabel.AutoSize = true;
            this.CurrentStateLabel.BackColor = System.Drawing.Color.GhostWhite;
            this.CurrentStateLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.CurrentStateLabel.Location = new System.Drawing.Point(268, 3);
            this.CurrentStateLabel.Name = "CurrentStateLabel";
            this.CurrentStateLabel.Size = new System.Drawing.Size(85, 14);
            this.CurrentStateLabel.TabIndex = 7;
            this.CurrentStateLabel.Text = "State: None";
            // 
            // AnswerLabel
            // 
            this.AnswerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AnswerLabel.AutoSize = true;
            this.AnswerLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.AnswerLabel.Location = new System.Drawing.Point(24, 262);
            this.AnswerLabel.Name = "AnswerLabel";
            this.AnswerLabel.Size = new System.Drawing.Size(54, 14);
            this.AnswerLabel.TabIndex = 8;
            this.AnswerLabel.Text = "rej/act";
            // 
            // ShowOutputButton
            // 
            this.ShowOutputButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ShowOutputButton.BackColor = System.Drawing.Color.IndianRed;
            this.ShowOutputButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ShowOutputButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowOutputButton.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.ShowOutputButton.ForeColor = System.Drawing.Color.White;
            this.ShowOutputButton.Location = new System.Drawing.Point(27, 175);
            this.ShowOutputButton.Name = "ShowOutputButton";
            this.ShowOutputButton.Size = new System.Drawing.Size(86, 28);
            this.ShowOutputButton.TabIndex = 9;
            this.ShowOutputButton.Text = "About";
            this.ShowOutputButton.UseVisualStyleBackColor = false;
            this.ShowOutputButton.Click += new System.EventHandler(this.ShowOutputButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(170, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(295, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Developer: Evgeniy Egorov, KFU (2017)";
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(645, 305);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ShowOutputButton);
            this.Controls.Add(this.AnswerLabel);
            this.Controls.Add(this.CurrentStateLabel);
            this.Controls.Add(this.ContinueButton);
            this.Controls.Add(this.NextStepButton);
            this.Controls.Add(this.stepCountLabel);
            this.Controls.Add(this.readProgramButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Turing machine (Egorov)";
            this.Load += new System.EventHandler(this.mainWindow_Load);
            this.Resize += new System.EventHandler(this.mainWindow_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Timer machineTimer;
        public System.Windows.Forms.Timer renderTimer;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button readProgramButton;
        private System.Windows.Forms.Label stepCountLabel;
        private System.Windows.Forms.Button NextStepButton;
        private System.Windows.Forms.Button ContinueButton;
        private System.Windows.Forms.Label CurrentStateLabel;
        private System.Windows.Forms.Label AnswerLabel;
        private System.Windows.Forms.Button ShowOutputButton;
        private System.Windows.Forms.Label label2;
    }
}

