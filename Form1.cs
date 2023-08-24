using System;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using tua_tell_us_Josie.Properties;

namespace tua_tell_us_Josie
{
    public partial class MainForm : Form
    {

        private Form2 form2;

        #region SETTINGS
        String m_ProductVersion = "1.0.0";
        String m_LicensedUser = "Josie Johnson";

        #endregion

        #region COLORS
        System.Drawing.Color MainFormBackcolorClr = System.Drawing.Color.FromArgb(255, 20, 0, 40);
        Color GrayPnlClr = Color.FromArgb(255, 211, 211, 211);
        Color InfoPnlClr = Color.White;
        Color LBtnClr = Color.FromArgb(255, 76, 175, 80);
        Color RBtnClr = Color.FromArgb(255, 244, 67, 54);
        #endregion

        #region FONTS
        Font LabelSmallFnt = new Font("arial", 15.0F, FontStyle.Bold, GraphicsUnit.Pixel);
        Font LabelBigFnt = new Font("arial", 20.0F, FontStyle.Bold, GraphicsUnit.Pixel);
        Font LabelMedFnt = new Font("arial", 18.0F, FontStyle.Bold, GraphicsUnit.Pixel);
        Font BtnStartFnt = new Font("arial", 30.0F, FontStyle.Bold, GraphicsUnit.Pixel);


        #endregion

        #region MAIN SCREEN
        //Panel ModePnl = new Panel();
        Panel ContentPnl = new Panel();
        Panel InfoPnl = new Panel();

        Label ApplicationLbl = new Label();
        Label UserLbl = new Label();
        Label LBtnLbl = new Label();

        PictureBox ApplicationIconPb = new PictureBox();

        Button LBtn = new Button();
        Button RBtn = new Button();

        #endregion

        #region LAUNCH / RESET SUBS
        public MainForm()
        {
            InitializeComponent();

            //set up main screen - Form1
            InitializeMainForm();

            //add handlers
            ContentPnl.Paint += ContentPnlPaint;
            LBtn.Paint += LBtnPaint;
            RBtn.Paint += RBtnPaint;
            RBtn.Click += RbtnClick;
 

            //create a reference to form2
            form2 = new Form2();

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
            
            //set up the left button
            int LBtnWidth = (MainFormScreenSize.Width / 2) - 80;
            int LBtnHeight = (int) (MainFormScreenSize.Height * .40) - 80;
            LBtn.SetBounds(30, (MainFormScreenSize.Height - (LBtnHeight + 20)), LBtnWidth, LBtnHeight);
            LBtn.BackColor = LBtnClr;
            LBtn.Visible = true;
            LBtn.FlatStyle = FlatStyle.Flat;
            LBtn.FlatAppearance.BorderSize = 0;
            LBtn.Font = BtnStartFnt;
            //LBtn.Text = "yj";
            //LBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //LBtn.Padding = new Padding.bottom
            
            LBtn.AutoSize = false;

            LBtnLbl.AutoSize = false;

            double LBtnDWidth = LBtnWidth;
            LBtnLbl.Width = (int)Math.Truncate(LBtnDWidth - (LBtnDWidth * .05));
            double LBtnDHeight = LBtnHeight;
            LBtnLbl.Height = (int)Math.Truncate(LBtnDHeight - (LBtnDHeight * .05));
            LBtnLbl.Location = new Point((LBtn.Width/2)-LBtnLbl.Width/2, (LBtn.Height/2)-LBtn.Height/2);
            LBtnLbl.BackColor = Color.AliceBlue;


            

            LBtnLbl.Font = BtnStartFnt;
            LBtnLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            LBtnLbl.Text = "yes";
            LBtnLbl.Visible = true;

            this.Controls.Add(LBtn);
            LBtn.Controls.Add(LBtnLbl);


            //set up the right button
            int RBtnWidth = (MainFormScreenSize.Width / 2) - 80;
            int RBtnHeight = (int)(MainFormScreenSize.Height * .40) - 80;
            RBtn.SetBounds((MainFormScreenSize.Width / 2) + 30, (MainFormScreenSize.Height - (RBtnHeight + 20)), RBtnWidth, RBtnHeight);
            RBtn.BackColor = RBtnClr;
            RBtn.Visible = true;   
            RBtn.FlatStyle= FlatStyle.Flat;
            RBtn.FlatAppearance.BorderSize = 0;
            this.Controls.Add(RBtn);



            //MessageBox.Show(LBtn.Width.ToString() + "  "+ RBtn.Width.ToString());





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



        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #endregion

        private void MakeButtonTextFit(Button button)
        {
            string text = button.Text;
            Font font = button.Font;

            float fontSize = font.Size;
            while (TextRenderer.MeasureText(text, font).Width <= button.Width - 50)
            {
                fontSize++;
                font = new Font(font.FontFamily, fontSize, font.Style);
            }
            button.Font = font;
        }


        #region CLICK EVENTS

        private void RbtnClick(object sender, EventArgs e)
        {
            Button button = LBtn;

            MakeButtonTextFit(button);
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
        #endregion

    }

    public class Form2 : Form
    {

    }
}