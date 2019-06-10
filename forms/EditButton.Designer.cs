namespace SoundBoard.forms
{
    partial class EditButton
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pathPicture = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pathSong = new System.Windows.Forms.TextBox();
            this.customTime = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timeStart = new System.Windows.Forms.DateTimePicker();
            this.timeEnd = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonPlayPause = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.songProgress = new System.Windows.Forms.ProgressBar();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.songDuration = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.songPosition = new System.Windows.Forms.TextBox();
            this.repeat = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(301, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // pathPicture
            // 
            this.pathPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathPicture.Location = new System.Drawing.Point(12, 94);
            this.pathPicture.Name = "pathPicture";
            this.pathPicture.ReadOnly = true;
            this.pathPicture.Size = new System.Drawing.Size(395, 26);
            this.pathPicture.TabIndex = 3;
            this.pathPicture.Click += new System.EventHandler(this.pathPicture_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            // 
            // pathSong
            // 
            this.pathSong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathSong.Location = new System.Drawing.Point(12, 151);
            this.pathSong.Name = "pathSong";
            this.pathSong.ReadOnly = true;
            this.pathSong.Size = new System.Drawing.Size(395, 26);
            this.pathSong.TabIndex = 6;
            this.pathSong.Click += new System.EventHandler(this.pathSong_Click);
            // 
            // customTime
            // 
            this.customTime.AutoSize = true;
            this.customTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customTime.Location = new System.Drawing.Point(17, 183);
            this.customTime.Name = "customTime";
            this.customTime.Size = new System.Drawing.Size(106, 24);
            this.customTime.TabIndex = 7;
            this.customTime.Text = "checkBox1";
            this.customTime.UseVisualStyleBackColor = true;
            this.customTime.CheckedChanged += new System.EventHandler(this.costumTime_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(213, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "label5";
            // 
            // timeStart
            // 
            this.timeStart.CustomFormat = "mm:ss";
            this.timeStart.Enabled = false;
            this.timeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeStart.Location = new System.Drawing.Point(12, 238);
            this.timeStart.Name = "timeStart";
            this.timeStart.ShowUpDown = true;
            this.timeStart.Size = new System.Drawing.Size(190, 26);
            this.timeStart.TabIndex = 10;
            this.timeStart.Value = new System.DateTime(2019, 6, 9, 0, 0, 0, 0);
            this.timeStart.ValueChanged += new System.EventHandler(this.timeStart_ValueChanged);
            // 
            // timeEnd
            // 
            this.timeEnd.CustomFormat = "mm:ss";
            this.timeEnd.Enabled = false;
            this.timeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeEnd.Location = new System.Drawing.Point(217, 238);
            this.timeEnd.MinDate = new System.DateTime(2019, 6, 9, 0, 0, 0, 0);
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.ShowUpDown = true;
            this.timeEnd.Size = new System.Drawing.Size(190, 26);
            this.timeEnd.TabIndex = 11;
            this.timeEnd.Value = new System.DateTime(2019, 6, 9, 0, 0, 0, 0);
            this.timeEnd.ValueChanged += new System.EventHandler(this.timeEnd_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::SoundBoard.Properties.Resources.ic_action_play;
            this.pictureBox1.Location = new System.Drawing.Point(332, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 277);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "label6";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(12, 300);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(395, 26);
            this.textBox2.TabIndex = 14;
            // 
            // buttonPlayPause
            // 
            this.buttonPlayPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPlayPause.Enabled = false;
            this.buttonPlayPause.Location = new System.Drawing.Point(9, 333);
            this.buttonPlayPause.Name = "buttonPlayPause";
            this.buttonPlayPause.Size = new System.Drawing.Size(79, 84);
            this.buttonPlayPause.TabIndex = 15;
            this.buttonPlayPause.UseVisualStyleBackColor = true;
            this.buttonPlayPause.Click += new System.EventHandler(this.buttonPlayPause_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(93, 333);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "label7";
            // 
            // songProgress
            // 
            this.songProgress.Location = new System.Drawing.Point(94, 394);
            this.songProgress.MarqueeAnimationSpeed = 10;
            this.songProgress.Name = "songProgress";
            this.songProgress.Size = new System.Drawing.Size(313, 23);
            this.songProgress.Step = 1;
            this.songProgress.TabIndex = 18;
            // 
            // buttonAccept
            // 
            this.buttonAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAccept.Location = new System.Drawing.Point(278, 423);
            this.buttonAccept.Margin = new System.Windows.Forms.Padding(3, 3, 13, 13);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(130, 45);
            this.buttonAccept.TabIndex = 19;
            this.buttonAccept.Text = "button2";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(142, 423);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(130, 45);
            this.buttonCancel.TabIndex = 20;
            this.buttonCancel.Text = "button3";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // songDuration
            // 
            this.songDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songDuration.Location = new System.Drawing.Point(217, 330);
            this.songDuration.Name = "songDuration";
            this.songDuration.ReadOnly = true;
            this.songDuration.Size = new System.Drawing.Size(190, 26);
            this.songDuration.TabIndex = 21;
            this.songDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(93, 364);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "label8";
            // 
            // songPosition
            // 
            this.songPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songPosition.Location = new System.Drawing.Point(217, 362);
            this.songPosition.Name = "songPosition";
            this.songPosition.ReadOnly = true;
            this.songPosition.Size = new System.Drawing.Size(190, 26);
            this.songPosition.TabIndex = 23;
            this.songPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // repeat
            // 
            this.repeat.AutoSize = true;
            this.repeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeat.Location = new System.Drawing.Point(217, 183);
            this.repeat.Name = "repeat";
            this.repeat.Size = new System.Drawing.Size(106, 24);
            this.repeat.TabIndex = 24;
            this.repeat.Text = "checkBox1";
            this.repeat.UseVisualStyleBackColor = true;
            this.repeat.CheckedChanged += new System.EventHandler(this.repeat_CheckedChanged);
            // 
            // EditButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(441, 499);
            this.Controls.Add(this.repeat);
            this.Controls.Add(this.songPosition);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.songDuration);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.songProgress);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonPlayPause);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.timeEnd);
            this.Controls.Add(this.timeStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.customTime);
            this.Controls.Add(this.pathSong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pathPicture);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditButton";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditButton";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditButton_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pathPicture;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pathSong;
        private System.Windows.Forms.CheckBox customTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker timeStart;
        private System.Windows.Forms.DateTimePicker timeEnd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonPlayPause;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar songProgress;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox songDuration;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox songPosition;
        private System.Windows.Forms.CheckBox repeat;
    }
}