namespace LoopMusicPlayer
{
    partial class Form1
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
            Play = new Button();
            Stop = new Button();
            Vol = new NumericUpDown();
            I = new TextBox();
            label1 = new Label();
            SI = new Button();
            SL = new Button();
            label2 = new Label();
            L = new TextBox();
            groupBox1 = new GroupBox();
            label3 = new Label();
            groupBox2 = new GroupBox();
            label4 = new Label();
            Time = new Label();
            Indicator = new Label();
            Playing = new Label();
            label5 = new Label();
            Len = new Label();
            ((System.ComponentModel.ISupportInitialize)Vol).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // Play
            // 
            Play.Location = new Point(6, 21);
            Play.Name = "Play";
            Play.Size = new Size(75, 23);
            Play.TabIndex = 0;
            Play.Text = "播放";
            Play.UseVisualStyleBackColor = true;
            Play.Click += Play_Click;
            // 
            // Stop
            // 
            Stop.Location = new Point(6, 50);
            Stop.Name = "Stop";
            Stop.Size = new Size(75, 23);
            Stop.TabIndex = 1;
            Stop.Text = "停止";
            Stop.UseVisualStyleBackColor = true;
            Stop.Click += Stop_Click;
            // 
            // Vol
            // 
            Vol.Location = new Point(146, 47);
            Vol.Name = "Vol";
            Vol.ReadOnly = true;
            Vol.Size = new Size(59, 23);
            Vol.TabIndex = 2;
            Vol.Value = new decimal(new int[] { 10, 0, 0, 0 });
            Vol.ValueChanged += Vol_ValueChanged;
            // 
            // I
            // 
            I.Location = new Point(68, 12);
            I.Name = "I";
            I.Size = new Size(648, 23);
            I.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 18);
            label1.Name = "label1";
            label1.Size = new Size(48, 17);
            label1.TabIndex = 4;
            label1.Text = "Intro：";
            // 
            // SI
            // 
            SI.Location = new Point(722, 12);
            SI.Name = "SI";
            SI.Size = new Size(75, 23);
            SI.TabIndex = 5;
            SI.Text = "选择";
            SI.UseVisualStyleBackColor = true;
            SI.Click += SI_Click;
            // 
            // SL
            // 
            SL.Location = new Point(722, 41);
            SL.Name = "SL";
            SL.Size = new Size(75, 23);
            SL.TabIndex = 8;
            SL.Text = "选择";
            SL.UseVisualStyleBackColor = true;
            SL.Click += SL_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 47);
            label2.Name = "label2";
            label2.Size = new Size(50, 17);
            label2.TabIndex = 7;
            label2.Text = "Loop：";
            // 
            // L
            // 
            L.Location = new Point(68, 41);
            L.Name = "L";
            L.Size = new Size(648, 23);
            L.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(Play);
            groupBox1.Controls.Add(Stop);
            groupBox1.Controls.Add(Vol);
            groupBox1.Location = new Point(14, 70);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(219, 86);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "控制";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(96, 53);
            label3.Name = "label3";
            label3.Size = new Size(44, 17);
            label3.TabIndex = 3;
            label3.Text = "音量：";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(Len);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(Time);
            groupBox2.Controls.Add(Indicator);
            groupBox2.Controls.Add(Playing);
            groupBox2.Location = new Point(239, 70);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(558, 86);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "状态指示";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(147, 49);
            label4.Name = "label4";
            label4.Size = new Size(68, 17);
            label4.TabIndex = 3;
            label4.Text = "当前位置：";
            // 
            // Time
            // 
            Time.AutoSize = true;
            Time.Location = new Point(221, 49);
            Time.Name = "Time";
            Time.Size = new Size(15, 17);
            Time.TabIndex = 2;
            Time.Text = "0";
            // 
            // Indicator
            // 
            Indicator.AutoSize = true;
            Indicator.Location = new Point(6, 24);
            Indicator.Name = "Indicator";
            Indicator.Size = new Size(32, 17);
            Indicator.TabIndex = 1;
            Indicator.Text = "空闲";
            // 
            // Playing
            // 
            Playing.AutoSize = true;
            Playing.Location = new Point(6, 50);
            Playing.Name = "Playing";
            Playing.Size = new Size(100, 17);
            Playing.TabIndex = 0;
            Playing.Text = "正在播放：None";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(147, 24);
            label5.Name = "label5";
            label5.Size = new Size(44, 17);
            label5.TabIndex = 4;
            label5.Text = "长度：";
            // 
            // Len
            // 
            Len.AutoSize = true;
            Len.Location = new Point(221, 24);
            Len.Name = "Len";
            Len.Size = new Size(15, 17);
            Len.TabIndex = 5;
            Len.Text = "0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 161);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(SL);
            Controls.Add(label2);
            Controls.Add(L);
            Controls.Add(SI);
            Controls.Add(label1);
            Controls.Add(I);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Form1";
            Text = "音频播放器";
            ((System.ComponentModel.ISupportInitialize)Vol).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Play;
        private Button Stop;
        private NumericUpDown Vol;
        private TextBox I;
        private Label label1;
        private Button SI;
        private Button SL;
        private Label label2;
        private TextBox L;
        private GroupBox groupBox1;
        private Label label3;
        private GroupBox groupBox2;
        private Label Playing;
        private Label Indicator;
        private Label Time;
        private Label label4;
        private Label Len;
        private Label label5;
    }
}
