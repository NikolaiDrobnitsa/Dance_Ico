using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Dance_Ico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private UserControl1 _labelControl;
        private void Form1_Load(object sender, EventArgs e)
        {
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey myAppKey = registry.OpenSubKey(@"Control Panel\Desktop");
            //myAppKey.GetValue("WallPaper").ToString();
            BackgroundImage = Image.FromFile(myAppKey.GetValue("WallPaper").ToString());
            //PictureBox pictureBox = new PictureBox();
            //System.Drawing.Icon ico = System.Drawing.Icon.ExtractAssociatedIcon(@"D:\call of duty\Cisco Packet Tracer 8.0\bin\PacketTracer.exe");
            //System.Drawing.Icon ico = System.Drawing.Icon.ExtractAssociatedIcon(@"D:\SONY\Adobe.exe");
            ////////Image im = ico.ToBitmap();
            //Icon appIcon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            //Image im = appIcon.ToBitmap();

            //BackgroundImage = im;
            //pictureBox.Size = new Size(100, 100);
            //////pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            //////pictureBox.BackColor = Color.Transparent;
            //////pictureBox.Image = im;

            /////this.Controls.Add(pictureBox);
            //Getinstalledsoftware();
            //MessageBox.Show(Getinstalledsoftware());
            //List<PictureBox> picturebox = new List<PictureBox>();

            //foreach (var file in recentpics)
            //{
            //    var pb = new PictureBox();
            //    pb.Location = new Point(picturebox.Count * 120 + 20, y);
            //    pb.Size = new Size(100, 120);
            //    try
            //    {
            //        pb.Image = Image.FromFile(file.FullName);
            //    }
            //    catch (OutOfMemoryException) { continue; }
            //    pb.SizeMode = PictureBoxSizeMode.StretchImage;
            //    flowLayoutPanel1.Controls.Add(pb);
            //    picturebox.Add(pb);
            //}
            this.Paint += Form1_Paint;
            GetInstalled();
            //Getinstalledsoftware();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawImage(image1, i, 100, 200, 300);
        }

        private void Getinstalledsoftware()
        {
            //Declare the string to hold the list:
            string Software = null;
            List<PictureBox> picturebox = new List<PictureBox>();
            //The registry key:
            string SoftwareKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(SoftwareKey))
            {
                //Let's go through the registry keys and get the info we need:
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {
                            //If the key has value, continue, if not, skip it:
                            if (!(sk.GetValue("DisplayName") == null))
                            {
                                //Is the install location known?
                                if (sk.GetValue("InstallLocation") != null)
                                {
                                    Software += sk.GetValue("InstallLocation");
                                    var pb = new PictureBox();
                                    System.Drawing.Icon appIcon = System.Drawing.Icon.ExtractAssociatedIcon(Software);
                                    //Icon appIcon = Icon.ExtractAssociatedIcon(Software);
                                    
                                    Image im = appIcon.ToBitmap();
                                    pb.Image = im;
                                    pb.SizeMode = PictureBoxSizeMode.AutoSize;
                                    pb.Location = new Point(picturebox.Count * 120 + 20, 10);
                                    picturebox.Add(pb);
                                    this.Controls.Add(pb);
                                }

                                
                            }
                        }
                        catch (Exception ex)
                        {
                            //No, that exception is not getting away... :P
                        }
                    }
                }
            }

            
        }
        private void GetInstalled()
        {
            int posX = 0;
            int posY = 0;
            string Software = null;
            PictureBox pictureBox = new PictureBox();
            string SoftwareKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(SoftwareKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {
                            if (!(sk.GetValue("DisplayName") == null))
                            {
                                if (sk.GetValue("InstallLocation") == null)
                                    Software += sk.GetValue("DisplayName") + " - Install path not known\n";
                                else
                                {
                                    _labelControl = new UserControl1();
                                    _labelControl.Location = new Point(posX, posY);
                                    _labelControl.labelName.Text = sk.GetValue("DisplayName").ToString();
                                    Software = (string)sk.GetValue("DisplayIcon");
                                    Icon icon = Icon.ExtractAssociatedIcon(Software);
                                    Image image = icon.ToBitmap();
                                    Thread.Sleep(100);
                                    _labelControl.labelPicture.Image = image;
                                    this.Controls.Add(_labelControl);
                                    //pictureBox.Image = image;
                                    //pictureBox.Location = new Point(posX, posY);
                                    //this.Controls.Add(pictureBox);
                                    posX += 70;
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
        }
    }
}
