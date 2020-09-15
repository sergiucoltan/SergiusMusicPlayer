using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace SergiusMusicPlayerApp
{
    public partial class SergiusMusicPlayerApp : Form
    {
        private bool _dragging = false;
        private Point _offset;
        private Point _start_point = new Point(0, 0);

        public SergiusMusicPlayerApp()
        {
            InitializeComponent();
        }

        //Create Global Variables of String Type Array to save the titles or name of the tracks and path of the track
        String[] paths, files;


        private void btnSelectSongs_Click(object sender, EventArgs e)
        {
            //Code to select songs
            OpenFileDialog ofd = new OpenFileDialog();

            //Code to select multiple files
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                files = ofd.SafeFileNames; //Save the names of the track in files array
                paths = ofd.FileNames; //save the paths of the tracks in path array

                //Display the music titles in listbox
                for (int i = 0; i < files.Length; i++)
                {
                    listBoxSongs.Items.Add(files[i]); //Display songs in listbox
                }
            }
        }

        private void listBoxSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Write a code to play music
            WindowsMediaPlayerMusic.URL = paths[listBoxSongs.SelectedIndex];
        }

        private void WindowsMediaPlayerMusic_Enter(object sender, EventArgs e)
        {

        }


        //Make Music Player Windows movable
        private void SergiusMusicPlayerApp_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void SergiusMusicPlayerApp_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void SergiusMusicPlayerApp_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Code to Close the App 
            this.Close();
        }
    }
}
