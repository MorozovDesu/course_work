namespace course_work
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbDirection = new System.Windows.Forms.TrackBar();
            this.lblDirection = new System.Windows.Forms.Label();
            this.tbGraviton1 = new System.Windows.Forms.TrackBar();
            this.tbGraviton2 = new System.Windows.Forms.TrackBar();
            this.tbGraviton3 = new System.Windows.Forms.TrackBar();
            this.tbGraviton4 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton4)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(9, 8);
            this.picDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(676, 400);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.picDisplay_Paint);
            this.picDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseClick);
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // tbDirection
            // 
            this.tbDirection.Location = new System.Drawing.Point(9, 411);
            this.tbDirection.Margin = new System.Windows.Forms.Padding(2);
            this.tbDirection.Maximum = 359;
            this.tbDirection.Name = "tbDirection";
            this.tbDirection.Size = new System.Drawing.Size(159, 45);
            this.tbDirection.TabIndex = 1;
            this.tbDirection.Scroll += new System.EventHandler(this.tbDirection_Scroll_1);
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(171, 411);
            this.lblDirection.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(10, 13);
            this.lblDirection.TabIndex = 2;
            this.lblDirection.Text = "-";
            // 
            // tbGraviton1
            // 
            this.tbGraviton1.Location = new System.Drawing.Point(214, 412);
            this.tbGraviton1.Margin = new System.Windows.Forms.Padding(2);
            this.tbGraviton1.Maximum = 100;
            this.tbGraviton1.Name = "tbGraviton1";
            this.tbGraviton1.Size = new System.Drawing.Size(106, 45);
            this.tbGraviton1.TabIndex = 3;
            this.tbGraviton1.Scroll += new System.EventHandler(this.tbGraviton_Scroll);
            // 
            // tbGraviton2
            // 
            this.tbGraviton2.Location = new System.Drawing.Point(336, 412);
            this.tbGraviton2.Margin = new System.Windows.Forms.Padding(2);
            this.tbGraviton2.Maximum = 100;
            this.tbGraviton2.Name = "tbGraviton2";
            this.tbGraviton2.Size = new System.Drawing.Size(105, 45);
            this.tbGraviton2.TabIndex = 4;
            this.tbGraviton2.Scroll += new System.EventHandler(this.tbGraviton2_Scroll);
            // 
            // tbGraviton3
            // 
            this.tbGraviton3.Location = new System.Drawing.Point(460, 411);
            this.tbGraviton3.Margin = new System.Windows.Forms.Padding(2);
            this.tbGraviton3.Maximum = 100;
            this.tbGraviton3.Name = "tbGraviton3";
            this.tbGraviton3.Size = new System.Drawing.Size(69, 45);
            this.tbGraviton3.TabIndex = 5;
            this.tbGraviton3.Scroll += new System.EventHandler(this.tbGraviton3_Scroll_1);
            // 
            // tbGraviton4
            // 
            this.tbGraviton4.Location = new System.Drawing.Point(564, 411);
            this.tbGraviton4.Margin = new System.Windows.Forms.Padding(2);
            this.tbGraviton4.Maximum = 100;
            this.tbGraviton4.Name = "tbGraviton4";
            this.tbGraviton4.Size = new System.Drawing.Size(69, 45);
            this.tbGraviton4.TabIndex = 6;
            this.tbGraviton4.Scroll += new System.EventHandler(this.tbGraviton4_Scroll_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 455);
            this.Controls.Add(this.tbGraviton4);
            this.Controls.Add(this.tbGraviton3);
            this.Controls.Add(this.tbGraviton2);
            this.Controls.Add(this.tbGraviton1);
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.tbDirection);
            this.Controls.Add(this.picDisplay);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar tbDirection;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.TrackBar tbGraviton1;
        private System.Windows.Forms.TrackBar tbGraviton2;
        private System.Windows.Forms.TrackBar tbGraviton3;
        private System.Windows.Forms.TrackBar tbGraviton4;
    }
}

