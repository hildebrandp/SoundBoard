using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NAudio.Wave;
using System.Timers;
using System.Collections.Generic;

namespace SoundBoard.forms
{
    public partial class EditButton : Form
    {
        List<buttonItem> buttonItems;

        private Boolean playing = false;

        private WaveOutEvent wavePlayer;
        private AudioFileReader audioFileReader;

        private System.Timers.Timer timer = null;
        private long songLength = 0;
        private TimeSpan songTime;

        public string ButtonName { get; set; }
        public string ButtonPicture { get; set; }
        public string ButtonColor { get; set; }
        public string ButtonSoundFile { get; set; }
        public Boolean ButtonSoundRepeat { get; set; }
        public Boolean ButtonCustomTime { get; set; }
        public int ButtonTimeStart { get; set; }
        public int ButtonTimeEnd { get; set; }

        public EditButton(List<buttonItem> buttonItems, string windowTitle)
        {
            InitializeComponent();

            this.Text = windowTitle;
            this.buttonItems = buttonItems;
            label1.Text = Properties.Resources.EditButtonTextNewButton;
            textBox1.Text = Properties.Resources.EditButtonName;
            label2.Text = Properties.Resources.EditButtonTextPathPicture;
            pathPicture.Text = Properties.Resources.EditButtonPicture;
            label3.Text = Properties.Resources.EditButtonTextPathSong;
            pathSong.Text = Properties.Resources.EditButtonSong;
            customTime.Text = Properties.Resources.EditButtonTextCostumTime;
            label4.Text = Properties.Resources.EditButtonTextStartTime;
            label5.Text = Properties.Resources.EditButtonTextEndTime;
            label6.Text = Properties.Resources.EditButtonSongName;
            label7.Text = Properties.Resources.EditButtonTextDuration;
            label8.Text = Properties.Resources.EditButtonTextPosition;
            buttonAccept.Text = Properties.Resources.ButtonAccept;
            buttonCancel.Text = Properties.Resources.ButtonCancel;
            buttonPlayPause.Image = Properties.Resources.ic_action_play;
            repeat.Text = Properties.Resources.EditButtonRepeat;

            timeStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);
            timeEnd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);

            ButtonName = "New Button";
            ButtonPicture = null;
            ButtonColor = null;
            ButtonSoundFile = null;
            ButtonSoundRepeat = false;
            ButtonCustomTime = false;
            ButtonTimeStart = 0;
            ButtonTimeEnd = 0;

            timer = new System.Timers.Timer();
            timer.Interval = 50;
            timer.Elapsed += Timer_Elapsed;
        }

        public EditButton(List<buttonItem> buttonItems, string windowTitle, string ButtonName, string ButtonPicture, string ButtonColor, string ButtonSoundFile, 
            Boolean ButtonSoundRepeat, Boolean ButtonCustomTime, int ButtonTimeStart, int ButtonTimeEnd)
        {
            this.buttonItems = buttonItems;
            this.ButtonName = ButtonName;
            this.ButtonPicture = ButtonPicture;
            this.ButtonColor = ButtonColor;
            this.ButtonSoundFile = ButtonSoundFile;
            this.ButtonSoundRepeat = ButtonSoundRepeat;
            this.ButtonCustomTime = ButtonCustomTime;
            this.ButtonTimeStart = ButtonTimeStart;
            this.ButtonTimeEnd = ButtonTimeEnd;

            InitializeComponent();
            this.Text = windowTitle;
            label1.Text = Properties.Resources.EditButtonTextNewButton;
            textBox1.Text = ButtonName;
            label2.Text = Properties.Resources.EditButtonTextPathPicture;
            pathPicture.Text = ButtonPicture;
            label3.Text = Properties.Resources.EditButtonTextPathSong;
            pathSong.Text = ButtonSoundFile;
            customTime.Text = Properties.Resources.EditButtonTextCostumTime;
            customTime.Checked = ButtonCustomTime;
            label4.Text = Properties.Resources.EditButtonTextStartTime;
            label5.Text = Properties.Resources.EditButtonTextEndTime;
            label6.Text = Properties.Resources.EditButtonSongName;
            label7.Text = Properties.Resources.EditButtonTextDuration;
            label8.Text = Properties.Resources.EditButtonTextPosition;
            buttonAccept.Text = Properties.Resources.ButtonAccept;
            buttonCancel.Text = Properties.Resources.ButtonCancel;
            buttonPlayPause.Image = Properties.Resources.ic_action_play;
            repeat.Text = Properties.Resources.EditButtonRepeat;
            repeat.Checked = ButtonSoundRepeat;

            if (ButtonTimeStart == 0)
            {
                timeStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);
            }
            else
            {
                int minutes = ButtonTimeStart / 60;
                int seconds = ButtonTimeStart % 60;
                timeStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, minutes, seconds);
            }

            if (ButtonTimeStart == 0)
            {
                timeEnd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);
            }
            else
            {
                int minutes = ButtonTimeStart / 60;
                int seconds = ButtonTimeStart % 60;
                timeEnd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, minutes, seconds);
            }

            if (ButtonSoundFile.Length > 0)
            {
                testAudioFile(ButtonSoundFile);
            }

            timer = new System.Timers.Timer();
            timer.Interval = 50;
            timer.Elapsed += Timer_Elapsed;
        }

        private void pathPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select a Icon File";
            openDialog.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openDialog.FileName;

                Image buttonIcon = Image.FromFile(file);
                if (buttonIcon.Height > 512 || buttonIcon.Width > 512)
                {
                    MessageBox.Show(Properties.Resources.EditButtonTextImageSize, Properties.Resources.Warning);
                    ButtonPicture = null;

                    pictureBox1.Image = Properties.Resources.ic_action_play;
                    pathPicture.Text = Properties.Resources.EditButtonPicture;
                }
                else
                {
                    pictureBox1.Image = buttonIcon;
                    pathPicture.Text = file;
                    ButtonPicture = file;
                }
            }
        }

        private void pathSong_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select a Sound File";
            openDialog.Filter = "Sound Files (*.mp3;*.wave;*.flac)|*.mp3;*.wave;*.flac";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openDialog.FileName;

                testAudioFile(file);
            }
        }

        private void testAudioFile(string file)
        {
            if (file == null || file == "default")
            {
                return;
            }

            audioFileReader = new AudioFileReader(file);

            if (audioFileReader.CanRead)
            {
                if (audioFileReader.TotalTime.TotalMinutes >= 60)
                {
                    MessageBox.Show(Properties.Resources.EditButtonSongTooLong, Properties.Resources.Warning);
                    songDuration.Text = "";
                    pathSong.Text = Properties.Resources.EditButtonSong;
                    textBox2.Text = "";
                    ButtonSoundFile = null;

                    buttonPlayPause.Enabled = false;
                    return;
                }

                var duration = audioFileReader.TotalTime.Minutes.ToString("00") + ":" + audioFileReader.TotalTime.Seconds.ToString("00") + "." + audioFileReader.TotalTime.Milliseconds.ToString("0");
                songDuration.Text = duration.ToString();
                pathSong.Text = file;
                textBox2.Text = Path.GetFileNameWithoutExtension(file);
                ButtonSoundFile = file;

                buttonPlayPause.Enabled = true;
                songProgress.Value = 0;
                songPosition.Text = "00:00.000";
                songTime = audioFileReader.TotalTime;
                timeEnd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, songTime.Minutes, songTime.Seconds);

                if (textBox1.Text == Properties.Resources.EditButtonName)
                {
                    textBox1.Text = Path.GetFileNameWithoutExtension(file);
                }
            }
            else
            {
                songDuration.Text = "";
                pathSong.Text = Properties.Resources.EditButtonSong;
                textBox2.Text = "";
                ButtonSoundFile = null;

                buttonPlayPause.Enabled = false;
            }

            audioFileReader = null;
        }

        private void costumTime_CheckedChanged(object sender, EventArgs e)
        {
            if (customTime.Checked)
            {
                ButtonCustomTime = true;
                timeStart.Enabled = true;
                timeEnd.Enabled = true;
            }
            else
            {
                ButtonCustomTime = false;
                timeStart.Enabled = false;
                timeEnd.Enabled = false;
            }
        }

        private void timeStart_ValueChanged(object sender, EventArgs e)
        {
            int startSeconds = (timeStart.Value.Minute * 60) + timeStart.Value.Second;
            int endSeconds = (timeEnd.Value.Minute * 60) + timeEnd.Value.Second;
            int songSeconds = (songTime.Minutes * 60) + songTime.Seconds;

            if (startSeconds > songSeconds)
            {
                MessageBox.Show(Properties.Resources.EditButtonTimeStartHigherSong, Properties.Resources.Warning);
                timeStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);
            }
            else if (startSeconds > endSeconds)
            {
                MessageBox.Show(Properties.Resources.EditButtonTimeStartHigherEnd, Properties.Resources.Warning);
                timeStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);
            }
        }

        private void timeEnd_ValueChanged(object sender, EventArgs e)
        {
            int startSeconds = (timeStart.Value.Minute * 60) + timeStart.Value.Second;
            int endSeconds = (timeEnd.Value.Minute * 60) + timeEnd.Value.Second;
            int songSeconds = (songTime.Minutes * 60) + songTime.Seconds;

            if (endSeconds > songSeconds)
            {
                MessageBox.Show(Properties.Resources.EditButtonTimeEndHigherSong, Properties.Resources.Warning);
                timeEnd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, songTime.Minutes, songTime.Seconds);
            }
            else if (endSeconds < startSeconds)
            {
                MessageBox.Show(Properties.Resources.EditButtonTimeEndSmallerEnd, Properties.Resources.Warning);
                timeEnd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, songTime.Minutes, songTime.Seconds);
            }
        }

        private void buttonPlayPause_Click(object sender, EventArgs e)
        {
            if (!playing)
            {
                playing = true;
                buttonPlayPause.Image = Properties.Resources.ic_action_stop;

                if (wavePlayer == null)
                {
                    wavePlayer = new WaveOutEvent();
                    wavePlayer.PlaybackStopped += OnPlaybackStopped;
                }
                if (audioFileReader == null)
                {
                    audioFileReader = new AudioFileReader(ButtonSoundFile);
                    wavePlayer.Init(audioFileReader);
                }

                songLength = audioFileReader.Length;
                songProgress.Value = 0;
                songProgress.Maximum = unchecked((int)songLength);
                wavePlayer.Play();
                timer.Start();
            }
            else
            {
                playing = false;
                buttonPlayPause.Image = Properties.Resources.ic_action_play;

                timer?.Stop();
                wavePlayer?.Stop();
            }
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            playing = false;
            buttonPlayPause.Image = Properties.Resources.ic_action_play;

            timer?.Stop();
            wavePlayer?.Dispose();
            audioFileReader?.Dispose();
            wavePlayer = null;
            audioFileReader = null;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (playing)
            {
                this.BeginInvoke(new MethodInvoker(delegate
                {
                    this.songPosition.Text = audioFileReader.CurrentTime.Minutes.ToString("00") + ":" + audioFileReader.CurrentTime.Seconds.ToString("00") + "." + audioFileReader.CurrentTime.Milliseconds.ToString("000");
                    this.songProgress.Value = unchecked((int)audioFileReader.Position);
                }));
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString().Length < 3)
            {
                MessageBox.Show(Properties.Resources.EditButtonNameTooShort, Properties.Resources.Warning);
            }
            else if (textBox1.Text.ToString().Length > 50)
            {
                MessageBox.Show(Properties.Resources.EditButtonNameTooLong, Properties.Resources.Warning);
            }
            else if (checkIfNameExists(textBox1.Text))
            {
                MessageBox.Show(Properties.Resources.EditButtonTextNameExists, Properties.Resources.Warning);
            }
            else
            {
                ButtonName = textBox1.Text.ToString();
                ButtonTimeStart = (timeStart.Value.Minute * 60) + timeStart.Value.Second;
                ButtonTimeEnd = (timeEnd.Value.Minute * 60) + timeEnd.Value.Second;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private Boolean checkIfNameExists(string name)
        {
            for (int i = 0; i < buttonItems.Count; i++)
            {
                if (buttonItems[i].ButtonName == name)
                {
                    return true;
                }
            }

            return false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            String allowedChars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-_ ";
            if (!char.IsControl(e.KeyChar) && !allowedChars.Contains(e.KeyChar.ToString().ToLower()))
            {
                e.Handled = true;
            }
        }

        private void repeat_CheckedChanged(object sender, EventArgs e)
        {
            if (repeat.Checked)
            {
                ButtonSoundRepeat = true;
            }
            else
            {
                ButtonSoundRepeat = false;
            }
        }

        private void EditButton_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer?.Stop();
            audioFileReader?.Dispose();
            wavePlayer?.Dispose();
            wavePlayer = null;
            audioFileReader = null;
        }
    }
}
