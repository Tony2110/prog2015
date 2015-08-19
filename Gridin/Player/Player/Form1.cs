using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.Xml.Serialization;
using DevExpress.XtraReports.UI;

namespace Player
{
    public partial class PlayerForm : Form
    {
        public class PlayList
        {
            public string[] Path { get; set; }
            public string[] Name { get; set; }
            public override string ToString()
            {
                return string.Format("{0}",Name);
            }
        }
        public int SelectedTrack = 0;
        public PlayList PL { get; set; }
        public PlayerForm()
        {
            PL = new PlayList();
            InitializeComponent();
            wmp.settings.autoStart = true;
        }
        void wmp_EndOfStream(int Result)
        {
            //NextTrackButton_Click(null, null);
        }

        WindowsMediaPlayer wmp = new WindowsMediaPlayer();
        private void button1_Click(object sender, EventArgs e)
        {
            if (SelectedTrack == 0) { SelectedTrack = AddFilesBox.Items.Count - 1; AddFilesBox.SelectedIndex = AddFilesBox.Items.Count - 1; }
            else { SelectedTrack -= 1; AddFilesBox.SelectedIndex -= 1; }
            PlaySong();
        }
       
        private void PlayPauseButton_Click(object sender, EventArgs e)
        {
            PlaySong();
            Timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TrackBar.Maximum = Convert.ToInt32(wmp.currentMedia.duration) ;
            if (TrackBar.Value != TrackBar.Maximum)
            TrackBar.Value = Convert.ToInt32(wmp.controls.currentPosition);
            if (wmp != null)
            {
                int s = (int)wmp.currentMedia.duration;
                int h = s / 3600;
                int m = (s - (h * 3600)) / 60;
                s = s - (h * 3600 + m * 60);
                EndTime.Text = String.Format("{0:D}:{1:D2}:{2:D2}", h, m, s);

                s = (int)wmp.controls.currentPosition;
                h = s / 3600;
                m = (s - (h * 3600)) / 60;
                s = s - (h * 3600 + m * 60);
                StartTime.Text = String.Format("{0:D}:{1:D2}:{2:D2}", h, m, s);
            }
            else
            {
                EndTime.Text = "0:00:00";
                StartTime.Text = "0:00:00";
            }
        }

        private void TrackBar_Scroll(object sender, EventArgs e)
        { 
            if (TrackBar.Value == TrackBar.Maximum)
            {
                Timer.Enabled = false;
                TrackBar.Value = TrackBar.Minimum;
                NextTrackButton_Click(null, null);
            }
            else
            wmp.controls.currentPosition = TrackBar.Value;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                PL.Name = OpenFileDialog.SafeFileNames;
                PL.Path = OpenFileDialog.FileNames;
                foreach (var item in PL.Name)
                {
                    AddFilesBox.Items.Add(item);
                }
            }
        }

        private void AddFilesBox_SelectedIndexChanged(object sender, EventArgs e)
        { 
            SelectedTrack = AddFilesBox.SelectedIndex;
            PreviousTrackButton.Enabled = true;
            NextTrackButton.Enabled = true;
            StopTrackButton.Enabled = true;
            PlayButton.Enabled = true;
            DeleteFilesButton.Enabled = true;
        }

        private void NextTrackButton_Click(object sender, EventArgs e)
        {
            if (SelectedTrack == AddFilesBox.Items.Count - 1) { SelectedTrack = 0; AddFilesBox.SelectedIndex = 0; }
            else { SelectedTrack += 1; AddFilesBox.SelectedIndex += 1; }
            PlaySong();
        }
        public void PlaySong()
        {
            wmp.URL = PL.Path[SelectedTrack];
            TrackBar.Value = 0;
            wmp.controls.play();
            TrackBar.Enabled = true;
            Timer.Interval = 1000;
            Timer.Enabled = true;
            PlayPauseLabel.Text = PL.Name[SelectedTrack];
            Volume();
        }

        private void StopTrackButton_Click(object sender, EventArgs e)
        {
            wmp.controls.stop();
        }
        public void Volume()
        {
            if (VolumeTrackBar.Value == 10)
                wmp.settings.volume = 100;
            if (VolumeTrackBar.Value == 9)
                wmp.settings.volume = 90;
            if (VolumeTrackBar.Value == 8)
                wmp.settings.volume = 80;
            if (VolumeTrackBar.Value == 7)
                wmp.settings.volume = 70;
            if (VolumeTrackBar.Value == 6)
                wmp.settings.volume = 60;
            if (VolumeTrackBar.Value == 5)
                wmp.settings.volume = 50;
            if (VolumeTrackBar.Value == 4)
                wmp.settings.volume = 40;
            if (VolumeTrackBar.Value == 3)
                wmp.settings.volume = 30;
            if (VolumeTrackBar.Value == 2)
                wmp.settings.volume = 20;
            if (VolumeTrackBar.Value == 1)
                wmp.settings.volume = 10;
            if (VolumeTrackBar.Value == 0)
                wmp.settings.volume = 0;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Volume();
        }        

        private void PlayerPage_Click(object sender, EventArgs e)
        {
        
        }


        private void StartTime_Click(object sender, EventArgs e)
        {

        }

        private void DeleteFilesButton_Click_1(object sender, EventArgs e)
        {
            AddFilesBox.Items.RemoveAt(AddFilesBox.SelectedIndices[0]);
            PreviousTrackButton.Enabled = false;
            NextTrackButton.Enabled = false;
            PlayButton.Enabled = false;
            DeleteFilesButton.Enabled = false;   
        }

        private void TrackBar_Scroll_1(object sender, EventArgs e)
        {

        }
    }
}
