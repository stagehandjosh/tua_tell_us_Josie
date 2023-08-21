using System;
using System.Drawing;
using tua_tell_us_Josie.Properties;

namespace tua_tell_us_Josie
{
    public partial class Form1 : Form
    {

        System.Drawing.Color Form1BackcolorClr = System.Drawing.Color.FromArgb(255, 20, 0, 40);

        private Form2 form2;


        public Form1()
        {
            InitializeComponent();

            //set up main screen - Form1
            InitializeForm1();

            //create a reference to form2
            form2 = new Form2();

            //chekc for a second screen
            ScreenCheck();


        }

        public void InitializeForm1()
        {
            //set up main screen
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = true;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackColor = Form1BackcolorClr;
            this.AutoSize = false;
            var Form1ScreenSize = new System.Drawing.Size(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
            this.Size = new Size(Form1ScreenSize.Width, Form1ScreenSize.Height);
            this.Text = "tell us Josie";
            this.Icon = Resources.tua_icon;
        }

        public void ScreenCheck()
        {
            // get all the screens on the system
            System.Windows.Forms.Screen[] screens = System.Windows.Forms.Screen.AllScreens;

            // if there is a second screen
            if (screens.Length > 1)
            {
                // create a new form on the second screen
                //Form2 form2 = new Form2();
                form2.StartPosition = FormStartPosition.Manual;
                form2.Location = screens[1].WorkingArea.Location;
                form2.MaximizeBox = false;
                form2.MinimizeBox = false;
                form2.ControlBox = true;
                form2.WindowState = FormWindowState.Maximized;
                form2.FormBorderStyle = FormBorderStyle.FixedSingle;
                form2.BackColor = Form1BackcolorClr;
                form2.AutoSize = false;
                var Form2ScreenSize = new System.Drawing.Size(screens[1].Bounds.Width, screens[1].Bounds.Height);
                form2.Size = new Size(Form2ScreenSize.Width, Form2ScreenSize.Height);
                form2.Text = "tell us Josie";
                form2.Icon = Resources.tua_icon;

                form2.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    public class Form2 : Form
    {

    }
}