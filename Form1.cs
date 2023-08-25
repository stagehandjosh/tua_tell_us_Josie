using System;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using tua_tell_us_Josie.Properties;
using System.Windows.Forms;
using System.Media;
using System.Web;

namespace tua_tell_us_Josie
{
    public partial class MainForm : Form
    {

        //private Form2 form2;

        #region SETTINGS
        String m_ProductVersion = "1.0.0";
        String m_LicensedUser = "Josie Johnson";
        string m_last_pressed = " ";

        #endregion

        #region COLORS
        Color MainFormBackcolorClr = Color.FromArgb(255, 20, 0, 40);
        Color GrayPnlClr = Color.FromArgb(255, 211, 211, 211);
        Color InfoPnlClr = Color.White;
        Color LBtnClr = Color.FromArgb(255, 76, 175, 80);
        Color LChangeTextBtnClr = Color.FromArgb(255, 165, 214, 167);
        Color LResetBtnClr = Color.FromArgb(255, 165, 214, 167);
        Color LStandByClr = Color.FromArgb(255, 129, 199, 132);
        Color LPressedClr = Color.FromArgb(255, 0, 200, 83);
        Color RBtnClr = Color.FromArgb(255, 244, 67, 54);
        Color RChangeTextBtnClr = Color.FromArgb(255, 239, 154, 154);
        Color RResetBtnClr = Color.FromArgb(255, 239, 154, 154);
        Color RStandByClr = Color.FromArgb(255, 229, 115, 115);
        Color RPressedClr = Color.FromArgb(255, 229, 57, 53);

        #endregion

        #region FONTS
        //Font LabelSmallFnt = new Font("arial", 15.0F, FontStyle.Bold, GraphicsUnit.Pixel);
        Font LabelBigFnt = new Font("arial", 20.0F, FontStyle.Bold, GraphicsUnit.Pixel);
        Font LabelMedFnt = new Font("arial", 18.0F, FontStyle.Bold, GraphicsUnit.Pixel);
        Font BtnStartFnt = new Font("arial", 6.0F, FontStyle.Bold, GraphicsUnit.Pixel);

        #endregion

        #region MAIN SCREEN
        //Panel ModePnl = new Panel();
        Panel ContentPnl = new Panel();
        Panel InfoPnl = new Panel();
        Panel LBtnPnl = new Panel();
        Panel RBtnPnl = new Panel();

        Label ApplicationLbl = new Label();
        Label UserLbl = new Label();
        Label AnswerLbl = new Label();

        PictureBox ApplicationIconPb = new PictureBox();

        Button LBtn = new Button();
        Button LChangeTextBtn = new Button();
        Button LResetBtn = new Button();
        Button RBtn = new Button();
        Button RChangeTextBtn = new Button();
        Button RResetBtn= new Button();

        #endregion

        #region TIMERS
        System.Windows.Forms.Timer WaitTimer = new System.Windows.Forms.Timer(); //wait before fade timer
        System.Windows.Forms.Timer FadeTimer = new System.Windows.Forms.Timer(); //fade to stand by color timer

        #endregion

        #region LAUNCH / RESET SUBS
        public MainForm()
        {
            InitializeComponent();

            //set up main screen - Form1
            InitializeMainForm();

            //add handlers
            ContentPnl.Paint += ContentPnlPaint;
            LBtnPnl.Paint += LBtnPnlPaint;
            LBtn.Paint += LBtnPaint;
            LChangeTextBtn.Paint += LChangeTextBtnPaint;
            LResetBtn.Paint += LResetBtnPaint;
            RBtnPnl.Paint += RBtnPnlPaint;
            RBtn.Paint += RBtnPaint;
            RChangeTextBtn.Paint += RChangeTextBtnPaint;
            RResetBtn.Paint += RResetBtnPaint;

            LBtn.Click += LBtnClick;
            LChangeTextBtn.Click += LChangeTextBtnClick;
            LResetBtn.Click += LResetBtnClick;
            RBtn.Click += RbtnClick;
            RChangeTextBtn.Click += RChangeTextBtnClick;
            RResetBtn.Click += RResetBtnClick;

            //handle key press
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(MainFormKeyDown);

            //timer settings and handlers
            FadeTimer.Interval = 5;
            FadeTimer.Tick += FadeTimerTick;
            WaitTimer.Interval = 1000;
            WaitTimer.Tick += WaitTimerTick;
                       
            //create a reference to form2
            //form2 = new Form2();

            //chekc for a second screen
            //ScreenCheck();
        }

        public void InitializeMainForm()
        {
            //set up main screen
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = true;
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = MainFormBackcolorClr;
            this.AutoSize = false;
            var MainFormScreenSize = new System.Drawing.Size(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
            this.Size = new Size(MainFormScreenSize.Width, MainFormScreenSize.Height);
            this.Text = "tell us Josie";
            this.Icon = Resources.tua_icon;

            //set up the content panel
            int ContentPnlHeight = (int)(MainFormScreenSize.Height * .60);
            ContentPnl.SetBounds(10, 100, MainFormScreenSize.Width - 30, ContentPnlHeight - 80);
            ContentPnl.BorderStyle = BorderStyle.None;
            ContentPnl.BackColor = GrayPnlClr;
            ContentPnl.Visible = true;
            this.Controls.Add(ContentPnl);

            double AnswerLblDWidth = ContentPnl.Width;
            AnswerLbl.Width = (int)Math.Truncate(AnswerLblDWidth - (AnswerLblDWidth * .05));
            double AnswerLblDHeight = ContentPnl.Height;
            AnswerLbl.Height = (int)Math.Truncate(AnswerLblDHeight - (AnswerLblDHeight * .18));
            AnswerLbl.Location = new Point(ContentPnl.Width / 2 - AnswerLbl.Width / 2, ContentPnl.Width / 2 - AnswerLbl.Width / 2);
            AnswerLbl.BackColor = Color.Transparent;
            AnswerLbl.Font = BtnStartFnt;
            AnswerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            AnswerLbl.Text = " ";
            AnswerLbl.AutoSize = false;
            AnswerLbl.Visible = true;
            Label f_label = AnswerLbl;
            MakeLabelTextFit(f_label);
            ContentPnl.Controls.Add(AnswerLbl);
           
            // set up the info panel 
            InfoPnl.SetBounds(20, 10, ContentPnl.Width - 40, 50);
            InfoPnl.BorderStyle = BorderStyle.None;
            InfoPnl.BackColor = System.Drawing.Color.Transparent;
            InfoPnl.Visible = true;

            ApplicationLbl.SetBounds(InfoPnl.Width - 180, 10, 130, 30);
            ApplicationIconPb.SetBounds(InfoPnl.Width - 215, 12, 30, 30);
            UserLbl.SetBounds(50, 10, 300, 30);
            
            UserLbl.Font = LabelBigFnt;
            UserLbl.Text = m_LicensedUser;
            UserLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            UserLbl.ForeColor = InfoPnlClr;
            UserLbl.BackColor = Color.Transparent;
            UserLbl.Visible = true;

            ApplicationLbl.Font = LabelMedFnt;
            ApplicationLbl.Text = "tell us Josie...";
            ApplicationLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            ApplicationLbl.ForeColor = InfoPnlClr;
            ApplicationLbl.BackColor = Color.Transparent;
            ApplicationLbl.Visible = true;

            ApplicationIconPb.Image = Resources.tua_better;
            ApplicationIconPb.BorderStyle = BorderStyle.None;
            ApplicationIconPb.SizeMode = PictureBoxSizeMode.StretchImage;
            ApplicationIconPb.Visible = true;
                               
            this.Controls.Add(InfoPnl);
            InfoPnl.Controls.Add(ApplicationLbl);
            InfoPnl.Controls.Add(ApplicationIconPb);
            InfoPnl.Controls.Add(UserLbl);

            //set up the left button panel
            int LBtnPnlWidth = (MainFormScreenSize.Width / 2) - 80;
            int LBtnPnlHeight = (int)(MainFormScreenSize.Height * .40) - 80;
            LBtnPnl.SetBounds(30, (MainFormScreenSize.Height - (LBtnPnlHeight + 20)), LBtnPnlWidth, LBtnPnlHeight);
            LBtnPnl.BackColor = LBtnClr;
            LBtnPnl.Visible = true;
            this.Controls.Add(LBtnPnl);


            //set up the left button
            double LBtnDWidth = LBtnPnlWidth;
            LBtn.Width = (int)Math.Truncate(LBtnDWidth - (LBtnDWidth * .05));
            double LBtnDHeight = LBtnPnlHeight;
            LBtn.Height = (int)Math.Truncate(LBtnDHeight - (LBtnDHeight * .3));
            LBtn.Location = new Point((LBtnPnl.Width / 2) - LBtn.Width / 2, (LBtnPnl.Width / 2) - LBtn.Width / 2);
            LBtn.BackColor = LBtnClr;
            LBtn.Visible = true;
            LBtn.FlatStyle = FlatStyle.Flat;
            LBtn.FlatAppearance.BorderSize = 0;
            LBtn.Font = BtnStartFnt;
            LBtn.Text = "Josh Weitzman";
            LBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            LBtn.AutoSize = false;
            Button f_button = LBtn;
            MakeButtonTextFit(f_button);
            LBtnPnl.Controls.Add(LBtn);

            //set up the left change text button
            double LChangeTextBtnDWidth = LBtnPnlWidth;
            LChangeTextBtn.Width = (int)Math.Truncate(LChangeTextBtnDWidth - (LChangeTextBtnDWidth * .3));
            double LChangeTextBtnDHeight = LBtnPnlHeight;
            LChangeTextBtn.Height = (int)Math.Truncate(LChangeTextBtnDHeight - (LChangeTextBtnDHeight * .85));
            LChangeTextBtn.Location = new Point(LBtn.Location.X, LBtn.Location.Y + LBtn.Height + (int)Math.Truncate(LChangeTextBtnDHeight * .05));
            LChangeTextBtn.BackColor = LChangeTextBtnClr;
            LChangeTextBtn.Visible = true;
            LChangeTextBtn.FlatStyle = FlatStyle.Flat;
            LChangeTextBtn.FlatAppearance.BorderSize = 0;
            LChangeTextBtn.Font = BtnStartFnt;
            LChangeTextBtn.Text = "change text";
            LChangeTextBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            LChangeTextBtn.AutoSize = false;
            f_button = LChangeTextBtn;
            MakeButtonTextFit(f_button);
            LBtnPnl.Controls.Add(LChangeTextBtn);

            //set up the left reset button
            double LResetBtnDWidth = LBtnPnlWidth;
            LResetBtn.Width = (int)Math.Truncate(LResetBtnDWidth - (LResetBtnDWidth * .78));
            double LResetBtnDHeight = LBtnPnlHeight;
            LResetBtn.Height = LChangeTextBtn.Height;
            LResetBtn.Location = new Point(LBtn.Location.X + LChangeTextBtn.Width + (int)Math.Truncate(LChangeTextBtn.Width * .05 ), LChangeTextBtn.Location.Y);
            LResetBtn.BackColor = LResetBtnClr;
            LResetBtn.Visible = true;
            LResetBtn.FlatStyle = FlatStyle.Flat;
            LResetBtn.FlatAppearance.BorderSize = 0;
            LResetBtn.Font = BtnStartFnt;
            LResetBtn.Text = "reset";
            LResetBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            LResetBtn.AutoSize = false;
            f_button = LResetBtn;
            MakeButtonTextFit(f_button);
            LBtnPnl.Controls.Add(LResetBtn);

            //set up the right button panel
            int RBtnPnlWidth = (MainFormScreenSize.Width / 2) - 80;
            int RBtnPnlHeight = (int)(MainFormScreenSize.Height * .40) - 80;
            RBtnPnl.SetBounds((MainFormScreenSize.Width / 2) + 30, (MainFormScreenSize.Height - (RBtnPnlHeight + 20)), RBtnPnlWidth, RBtnPnlHeight);
            RBtnPnl.BackColor = RBtnClr;
            RBtnPnl.Visible = true;
            this.Controls.Add(RBtnPnl);

            //set up the right button
            double RBtnDWidth = RBtnPnlWidth;
            RBtn.Width = (int)Math.Truncate(RBtnDWidth - (RBtnDWidth * .05));
            double RBtnDHeight = RBtnPnlHeight;
            RBtn.Height = (int)Math.Truncate(RBtnDHeight - (RBtnDHeight * .3));
            RBtn.Location = new Point((RBtnPnl.Width / 2) - RBtn.Width / 2, (RBtnPnl.Width / 2) - RBtn.Width / 2);
            RBtn.BackColor = RBtnClr;
            RBtn.Visible = true;
            RBtn.FlatStyle = FlatStyle.Flat;
            RBtn.FlatAppearance.BorderSize = 0;
            RBtn.Font = BtnStartFnt;
            RBtn.Text = "Izzy Weitzman";
            RBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            RBtn.AutoSize = false;
            f_button = RBtn;
            MakeButtonTextFit(f_button);
            RBtnPnl.Controls.Add(RBtn);

            //set up the right change text button
            double RChangeTextBtnDWidth = RBtnPnlWidth;
            RChangeTextBtn.Width = (int)Math.Truncate(RChangeTextBtnDWidth - (RChangeTextBtnDWidth * .3));
            double RChangeTextBtnDHeight = RBtnPnlHeight;
            RChangeTextBtn.Height = (int)Math.Truncate(RChangeTextBtnDHeight - (RChangeTextBtnDHeight * .85));
            RChangeTextBtn.Location = new Point(RBtn.Location.X, RBtn.Location.Y + RBtn.Height + (int)Math.Truncate(RChangeTextBtnDHeight * .05));
            RChangeTextBtn.BackColor = RChangeTextBtnClr;
            RChangeTextBtn.Visible = true;
            RChangeTextBtn.FlatStyle = FlatStyle.Flat;
            RChangeTextBtn.FlatAppearance.BorderSize = 0;
            RChangeTextBtn.Font = BtnStartFnt;
            RChangeTextBtn.Text = "change text";
            RChangeTextBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            RChangeTextBtn.AutoSize = false;
            f_button = RChangeTextBtn;
            MakeButtonTextFit(f_button);
            RBtnPnl.Controls.Add(RChangeTextBtn);

            //set up the right reset button
            double RResetBtnDWidth = RBtnPnlWidth;
            RResetBtn.Width = (int)Math.Truncate(RResetBtnDWidth - (RResetBtnDWidth * .78));
            double RResetBtnDHeight = RBtnPnlHeight;
            RResetBtn.Height = RChangeTextBtn.Height;
            RResetBtn.Location = new Point(RBtn.Location.X + RChangeTextBtn.Width + (int)Math.Truncate(RChangeTextBtn.Width * .05), RChangeTextBtn.Location.Y);
            RResetBtn.BackColor = RResetBtnClr;
            RResetBtn.Visible = true;
            RResetBtn.FlatStyle = FlatStyle.Flat;
            RResetBtn.FlatAppearance.BorderSize = 0;
            RResetBtn.Font = BtnStartFnt;
            RResetBtn.Text = "reset";
            RResetBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            RResetBtn.AutoSize = false;
            f_button = RResetBtn;
            MakeButtonTextFit(f_button);
            RBtnPnl.Controls.Add(RResetBtn);


        }
        #endregion

        #region SUBS AND SYSTEM EVENTS

        private void MainFormKeyDown(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.D1)
            {
                LBtn.PerformClick();
            }
            else if ((int)e.KeyChar == ((int)Keys.D4))
            {
                RBtn.PerformClick();
            }
            else
            {

            }
        }

        private void WaitTimerTick(object sender, EventArgs e) //wait before color fade
        {
            WaitTimer.Stop();
            FadeTimer.Start();
        }

        private void FadeTimerTick( object sender, EventArgs e) //fades backcolor to standby color
        {
            //get the new color
            if (m_last_pressed == "L")
            {
                //break out the new color
                int new_r = LStandByClr.R;
                int new_g = LStandByClr.G;
                int new_b = LStandByClr.B;

                //break out the current color
                int old_r = ContentPnl.BackColor.R;
                int old_g = ContentPnl.BackColor.G;
                int old_b = ContentPnl.BackColor.B;

                if (old_r == new_r && old_g == new_g && old_b == new_b)
                { FadeTimer.Stop(); }
                else
                {
                    if (old_r > new_r) { old_r--; };
                    if (old_r < new_r) { old_r++; };
                    if (old_g > new_g) { old_g--; };
                    if (old_g < new_g) { old_g++; };
                    if (old_b > new_b) { old_b--; };
                    if (old_b < new_b) { old_b++; };

                    ContentPnl.BackColor = Color.FromArgb(old_r, old_g, old_b);
                    ContentPnl.Refresh();
                }
            }
            
            else if (m_last_pressed == "R")
            {
                int new_r = RStandByClr.R;
                int new_g = RStandByClr.G; 
                int new_b = RStandByClr.B;

                //break out the current color
                int old_r = ContentPnl.BackColor.R;
                int old_g = ContentPnl.BackColor.G;
                int old_b = ContentPnl.BackColor.B;

                if (old_r == new_r && old_g == new_g && old_b == new_b)
                { FadeTimer.Stop(); }
                else
                {
                    if (old_r > new_r) { old_r--; };
                    if (old_r < new_r) { old_r++; };
                    if (old_g > new_g) { old_g--; };
                    if (old_g < new_g) { old_g++; };
                    if (old_b > new_b) { old_b--; };
                    if (old_b < new_b) { old_b++; };

                    ContentPnl.BackColor = Color.FromArgb(old_r, old_g, old_b);
                    ContentPnl.Refresh();
                }
            }
           

        }

        //public void ScreenCheck()
        //{
        //    // get all the screens on the system
        //    System.Windows.Forms.Screen[] screens = System.Windows.Forms.Screen.AllScreens;

        //    // if there is a second screen
        //    if (screens.Length > 1)
        //    {
        //        // create a new form on the second screen
        //        //Form2 form2 = new Form2();
        //        form2.StartPosition = FormStartPosition.Manual;
        //        form2.Location = screens[1].WorkingArea.Location;
        //        form2.MaximizeBox = false;
        //        form2.MinimizeBox = false;
        //        form2.ControlBox = true;
        //        form2.WindowState = FormWindowState.Maximized;
        //        form2.FormBorderStyle = FormBorderStyle.FixedSingle;
        //        form2.BackColor = MainFormBackcolorClr;
        //        form2.AutoSize = false;
        //        var Form2ScreenSize = new System.Drawing.Size(screens[1].Bounds.Width, screens[1].Bounds.Height);
        //        form2.Size = new Size(Form2ScreenSize.Width, Form2ScreenSize.Height);
        //        form2.Text = "tell us Josie";
        //        form2.Icon = Resources.tua_icon;

        //        form2.Show();
        //    }
        //}


        #endregion

        #region FUNCTIONS
        private void MakeLabelTextFit(Label f_label)
        {
            string text = f_label.Text;
            Font font = f_label.Font;
            
            float fontSize = font.Size;
            while ((TextRenderer.MeasureText(text, font).Width <= f_label.Width - 50) & (TextRenderer.MeasureText(text, font).Height <= f_label.Height - 20))
            {
                fontSize++;
                font = new Font(font.FontFamily, fontSize, font.Style);
            }
            f_label.Font = font;
        }
       
        private void MakeButtonTextFit(Button f_button)
        {
            string text = f_button.Text;
            Font font = f_button.Font;

            float fontSize = font.Size;
            while ((TextRenderer.MeasureText(text, font).Width <= f_button.Width - 50) & (TextRenderer.MeasureText(text, font).Height <= f_button.Height - 20))
            {
                fontSize++;
                font = new Font(font.FontFamily, fontSize, font.Style);
            }
            f_button.Font = font;
        }

        #endregion


        #region CLICK EVENTS
        private void LBtnClick(object sender, EventArgs e)
        {
            AnswerLbl.Font = BtnStartFnt;
            AnswerLbl.Text = LBtn.Text;
            Label f_label = AnswerLbl;
            MakeLabelTextFit(f_label);
            m_last_pressed = "L";
            ContentPnl.BackColor = LPressedClr;
            SoundPlayer player = new SoundPlayer(Properties.Resources.disco_beat);
            player.Play();  
            WaitTimer.Start();
            
        }

        private void LChangeTextBtnClick(object sender, EventArgs e) 
        {

        }

        private void LResetBtnClick(object sender, EventArgs e)
        {
            LBtn.Text = "yes";
        }

        private void RbtnClick(object sender, EventArgs e)
        {
            AnswerLbl.Font = BtnStartFnt;
            AnswerLbl.Text = RBtn.Text;
            Label f_label = AnswerLbl;
            MakeLabelTextFit(f_label);
            m_last_pressed = "R";
            ContentPnl.BackColor = RPressedClr;
            SoundPlayer player = new SoundPlayer(Properties.Resources.rock_beat);
            player.Play();
            WaitTimer.Start();
        }

        private void RChangeTextBtnClick(object sender, EventArgs e)
        {

        }

        private void RResetBtnClick(object sender, EventArgs e)
        {
            RBtn.Text = "no";
        }

        #endregion


        #region PAINT EVENTS
        private void ContentPnlPaint(object? sender, PaintEventArgs e)
        {
            var ContentPnlPath = new System.Drawing.Drawing2D.GraphicsPath();
            ContentPnlPath.StartFigure();
            ContentPnlPath.AddArc(ContentPnl.DisplayRectangle.X + ContentPnl.DisplayRectangle.Width - 50, ContentPnl.DisplayRectangle.Y, 50, 50, 270, 90);
            ContentPnlPath.AddArc(ContentPnl.DisplayRectangle.X + ContentPnl.DisplayRectangle.Width - 50, ContentPnl.DisplayRectangle.Y + ContentPnl.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            ContentPnlPath.AddArc(ContentPnl.DisplayRectangle.X, ContentPnl.DisplayRectangle.Y + ContentPnl.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            ContentPnlPath.AddArc(ContentPnl.DisplayRectangle.X, ContentPnl.DisplayRectangle.Y, 50, 50, 180, 90);
            ContentPnlPath.CloseFigure();
            ContentPnl.Region = new System.Drawing.Region(ContentPnlPath);
        }
        
        private void LBtnPnlPaint(object? sender, PaintEventArgs e)
        {
            var LBtnPnlPath = new System.Drawing.Drawing2D.GraphicsPath();
            LBtnPnlPath.StartFigure();
            LBtnPnlPath.AddArc(LBtnPnl.DisplayRectangle.X + LBtnPnl.DisplayRectangle.Width - 50, LBtnPnl.DisplayRectangle.Y, 50, 50, 270, 90);
            LBtnPnlPath.AddArc(LBtnPnl.DisplayRectangle.X + LBtnPnl.DisplayRectangle.Width - 50, LBtnPnl.DisplayRectangle.Y + LBtnPnl.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            LBtnPnlPath.AddArc(LBtnPnl.DisplayRectangle.X, LBtnPnl.DisplayRectangle.Y + LBtnPnl.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            LBtnPnlPath.AddArc(LBtnPnl.DisplayRectangle.X, LBtnPnl.DisplayRectangle.Y, 50, 50, 180, 90);
            LBtnPnlPath.CloseFigure();
            LBtnPnl.Region = new System.Drawing.Region(LBtnPnlPath);
        }

        private void LBtnPaint(object? sender, PaintEventArgs e)
        {
            var LBtnPath = new System.Drawing.Drawing2D.GraphicsPath();
            LBtnPath.StartFigure();
            LBtnPath.AddArc(LBtn.DisplayRectangle.X + LBtn.DisplayRectangle.Width - 50, LBtn.DisplayRectangle.Y, 50, 50, 270, 90);
            LBtnPath.AddArc(LBtn.DisplayRectangle.X + LBtn.DisplayRectangle.Width - 50, LBtn.DisplayRectangle.Y + LBtn.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            LBtnPath.AddArc(LBtn.DisplayRectangle.X, LBtn.DisplayRectangle.Y + LBtn.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            LBtnPath.AddArc(LBtn.DisplayRectangle.X, LBtn.DisplayRectangle.Y, 50, 50, 180, 90);
            LBtnPath.CloseFigure();
            LBtn.Region = new System.Drawing.Region(LBtnPath);
        }

        private void LChangeTextBtnPaint(object? sender, PaintEventArgs e)
        {
            var LBtnPnlPath = new System.Drawing.Drawing2D.GraphicsPath();
            LBtnPnlPath.StartFigure();
            LBtnPnlPath.AddArc(LChangeTextBtn.DisplayRectangle.X + LChangeTextBtn.DisplayRectangle.Width - 50, LChangeTextBtn.DisplayRectangle.Y, 50, 50, 270, 90);
            LBtnPnlPath.AddArc(LChangeTextBtn.DisplayRectangle.X + LChangeTextBtn.DisplayRectangle.Width - 50, LChangeTextBtn.DisplayRectangle.Y + LChangeTextBtn.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            LBtnPnlPath.AddArc(LChangeTextBtn.DisplayRectangle.X, LChangeTextBtn.DisplayRectangle.Y + LChangeTextBtn.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            LBtnPnlPath.AddArc(LChangeTextBtn.DisplayRectangle.X, LChangeTextBtn.DisplayRectangle.Y, 50, 50, 180, 90);
            LBtnPnlPath.CloseFigure();
            LChangeTextBtn.Region = new System.Drawing.Region(LBtnPnlPath);
        }

        private void LResetBtnPaint(object? sender, PaintEventArgs e)
        {
            var LBtnPnlPath = new System.Drawing.Drawing2D.GraphicsPath();
            LBtnPnlPath.StartFigure();
            LBtnPnlPath.AddArc(LResetBtn.DisplayRectangle.X + LResetBtn.DisplayRectangle.Width - 50, LResetBtn.DisplayRectangle.Y, 50, 50, 270, 90);
            LBtnPnlPath.AddArc(LResetBtn.DisplayRectangle.X + LResetBtn.DisplayRectangle.Width - 50, LResetBtn.DisplayRectangle.Y + LResetBtn.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            LBtnPnlPath.AddArc(LResetBtn.DisplayRectangle.X, LResetBtn.DisplayRectangle.Y + LResetBtn.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            LBtnPnlPath.AddArc(LResetBtn.DisplayRectangle.X, LResetBtn.DisplayRectangle.Y, 50, 50, 180, 90);
            LBtnPnlPath.CloseFigure();
            LResetBtn.Region = new System.Drawing.Region(LBtnPnlPath);
        }

        private void RBtnPnlPaint(object sender, PaintEventArgs e)
        {
            var RBtnPath = new System.Drawing.Drawing2D.GraphicsPath();
            RBtnPath.StartFigure();
            RBtnPath.AddArc(RBtnPnl.DisplayRectangle.X + RBtnPnl.DisplayRectangle.Width - 50, RBtnPnl.DisplayRectangle.Y, 50, 50, 270, 90);
            RBtnPath.AddArc(RBtnPnl.DisplayRectangle.X + RBtnPnl.DisplayRectangle.Width - 50, RBtnPnl.DisplayRectangle.Y + RBtnPnl.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            RBtnPath.AddArc(RBtnPnl.DisplayRectangle.X, RBtnPnl.DisplayRectangle.Y + RBtnPnl.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            RBtnPath.AddArc(RBtnPnl.DisplayRectangle.X, RBtnPnl.DisplayRectangle.Y, 50, 50, 180, 90);
            RBtnPath.CloseFigure();
            RBtnPnl.Region = new System.Drawing.Region(RBtnPath);
        }

        private void RBtnPaint(object? sender, PaintEventArgs e)
        {
            var RBtnPath = new System.Drawing.Drawing2D.GraphicsPath();
            RBtnPath.StartFigure();
            RBtnPath.AddArc(RBtn.DisplayRectangle.X + RBtn.DisplayRectangle.Width - 50, RBtn.DisplayRectangle.Y, 50, 50, 270, 90);
            RBtnPath.AddArc(RBtn.DisplayRectangle.X + RBtn.DisplayRectangle.Width - 50, RBtn.DisplayRectangle.Y + RBtn.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            RBtnPath.AddArc(RBtn.DisplayRectangle.X, RBtn.DisplayRectangle.Y + RBtn.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            RBtnPath.AddArc(RBtn.DisplayRectangle.X, RBtn.DisplayRectangle.Y, 50, 50, 180, 90);
            RBtnPath.CloseFigure();
            RBtn.Region = new System.Drawing.Region(RBtnPath);
        }

        private void RChangeTextBtnPaint(object? sender, PaintEventArgs e)
        {
            var LBtnPnlPath = new System.Drawing.Drawing2D.GraphicsPath();
            LBtnPnlPath.StartFigure();
            LBtnPnlPath.AddArc(RChangeTextBtn.DisplayRectangle.X + RChangeTextBtn.DisplayRectangle.Width - 50, RChangeTextBtn.DisplayRectangle.Y, 50, 50, 270, 90);
            LBtnPnlPath.AddArc(RChangeTextBtn.DisplayRectangle.X + RChangeTextBtn.DisplayRectangle.Width - 50, RChangeTextBtn.DisplayRectangle.Y + RChangeTextBtn.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            LBtnPnlPath.AddArc(RChangeTextBtn.DisplayRectangle.X, RChangeTextBtn.DisplayRectangle.Y + RChangeTextBtn.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            LBtnPnlPath.AddArc(RChangeTextBtn.DisplayRectangle.X, RChangeTextBtn.DisplayRectangle.Y, 50, 50, 180, 90);
            LBtnPnlPath.CloseFigure();
            RChangeTextBtn.Region = new System.Drawing.Region(LBtnPnlPath);
        }

        private void RResetBtnPaint(object? sender, PaintEventArgs e)
        {
            var LBtnPnlPath = new System.Drawing.Drawing2D.GraphicsPath();
            LBtnPnlPath.StartFigure();
            LBtnPnlPath.AddArc(RResetBtn.DisplayRectangle.X + RResetBtn.DisplayRectangle.Width - 50, RResetBtn.DisplayRectangle.Y, 50, 50, 270, 90);
            LBtnPnlPath.AddArc(RResetBtn.DisplayRectangle.X + RResetBtn.DisplayRectangle.Width - 50, RResetBtn.DisplayRectangle.Y + RResetBtn.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            LBtnPnlPath.AddArc(RResetBtn.DisplayRectangle.X, RResetBtn.DisplayRectangle.Y + RResetBtn.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            LBtnPnlPath.AddArc(RResetBtn.DisplayRectangle.X, RResetBtn.DisplayRectangle.Y, 50, 50, 180, 90);
            LBtnPnlPath.CloseFigure();
            RResetBtn.Region = new System.Drawing.Region(LBtnPnlPath);
        }

        #endregion

    }

    //public class Form2 : Form
    //{

    //}
}