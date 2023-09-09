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
        private ChangeTextForm ChangeTextForm;
        private Form2 form2;
        private SettingsForm SettingsForm;
        
        #region SETTINGS
        String m_ProductVersion = "1.0.0";
        String m_LicensedUser = "Josie Johnson";
        string m_last_pressed = " ";
        Boolean m_multi_screens = Settings.Default.multi_screens;
        //Boolean m_multi_screens = GetSavedSettingValue 
        //Boolean m_multi_screens = false;

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
        Color ChangeTextFormClr = Color.FromArgb(255, 255, 247, 157);
        Color SettingsFormClr = Color.FromArgb(255, 255, 245, 157);
        Color SettingsBtnClr = Color.FromArgb(255, 213, 79);


        #endregion

        #region FONTS
        //Font LabelSmallFnt = new Font("arial", 15.0F, FontStyle.Bold, GraphicsUnit.Pixel);
        Font LabelBigFnt = new Font("arial", 20.0F, FontStyle.Bold, GraphicsUnit.Pixel);
        Font LabelMedFnt = new Font("arial", 18.0F, FontStyle.Bold, GraphicsUnit.Pixel);
        Font QuitBtnFnt = new Font("arial", 24.0F, FontStyle.Bold, GraphicsUnit.Pixel);
        Font BtnStartFnt = new Font("arial", 6.0F, FontStyle.Bold, GraphicsUnit.Pixel);

        #endregion

        #region MAIN SCREEN
        Form SettingsFrm = new SettingsForm();
        Form LChangeTextFrm = new ChangeTextForm();
        Form RChangeTextFrm = new ChangeTextForm();

        //Panel ModePnl = new Panel();
        Panel ContentPnl = new Panel();
        Panel InfoPnl = new Panel();
        Panel LBtnPnl = new Panel();
        Panel RBtnPnl = new Panel();

        Label ApplicationLbl = new Label();
        Label UserLbl = new Label();
        Label AnswerLbl = new Label();
        Label SoundGroupBoxLbl = new Label();
        Label MultiScreensGroupBoxLbl = new Label();

        PictureBox ApplicationIconPb = new PictureBox();
        PictureBox QuitBtnPB = new PictureBox();

        Button QuitBtn = new Button();
        Button SettingsBtn = new Button();
        Button SettingsFormOKBtn = new Button();
        Button SettingsFormCancelBtn = new Button();
        Button ContentPanelResetBtn = new Button();
        Button LBtn = new Button();
        Button LChangeTextBtn = new Button();
        Button LResetBtn = new Button();
        Button LChangeTextFormOKBtn = new Button();
        Button LChangeTextFormCancelBtn = new Button();
        Button RBtn = new Button();
        Button RChangeTextBtn = new Button();
        Button RResetBtn= new Button();
        Button RChangeTextFormOKBtn = new Button();
        Button RChangeTextFormCancelBtn = new Button();

        TextBox LChangeTextFormTxt = new TextBox();
        TextBox RChangeTextFormTxt = new TextBox();

        GroupBox SoundGrpBx = new GroupBox();
        GroupBox MultiScreensGrpBx = new GroupBox(); 

        RadioButton SoundYes = new RadioButton();
        RadioButton SoundNo = new RadioButton();    
        RadioButton MultiScreensYes = new RadioButton();
        RadioButton MultiScreensNo = new RadioButton();

        #endregion

        #region SCREEN 2
        Form LChangeTextFrm2 = new ChangeTextForm();
        Form RChangeTextFrm2 = new ChangeTextForm();

        //Panel ModePnl = new Panel();
        Panel ContentPnl2 = new Panel();
        Panel InfoPnl2 = new Panel();
        Panel LBtnPnl2 = new Panel();
        Panel RBtnPnl2 = new Panel();

        Label ApplicationLbl2 = new Label();
        Label UserLbl2 = new Label();
        Label AnswerLbl2 = new Label();

        PictureBox ApplicationIconPb2 = new PictureBox();
        PictureBox QuitBtnPB2 = new PictureBox();

        Button QuitBtn2 = new Button();
        Button SettingsBtn2 = new Button();
        Button ContentPanelResetBtn2= new Button();
        Button LBtn2 = new Button();
        Button LChangeTextBtn2 = new Button();
        Button LResetBtn2 = new Button();
        Button LChangeTextFormOKBtn2 = new Button();
        Button LChangeTextFormCancelBtn2 = new Button();
        Button RBtn2 = new Button();
        Button RChangeTextBtn2 = new Button();
        Button RResetBtn2 = new Button();
        Button RChangeTextFormOKBtn2 = new Button();
        Button RChangeTextFormCancelBtn2 = new Button();

        TextBox LChangeTextFormTxt2 = new TextBox();
        TextBox RChangeTextFormTxt2 = new TextBox();


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

            //set up the ChangeTextForms
            InitializeChangeTextForms();

            //set up the SettingsForm
            InitializeSettingsForm();

            //add handlers
            ContentPnl.Paint += ContentPnlPaint;
            QuitBtn.Paint += QuitBtnPaint;
            LBtnPnl.Paint += LBtnPnlPaint;
            LBtn.Paint += LBtnPaint;
            LChangeTextBtn.Paint += LChangeTextBtnPaint;
            LResetBtn.Paint += LResetBtnPaint;
            RBtnPnl.Paint += RBtnPnlPaint;
            RBtn.Paint += RBtnPaint;
            RChangeTextBtn.Paint += RChangeTextBtnPaint;
            RResetBtn.Paint += RResetBtnPaint;

            ContentPnl2.Paint += ContentPnlPaint2;
            QuitBtn2.Paint += QuitBtnPaint2;
            LBtnPnl2.Paint += LBtnPnlPaint2;
            LBtn2.Paint += LBtnPaint2;
            LChangeTextBtn2.Paint += LChangeTextBtnPaint2;
            LResetBtn2.Paint += LResetBtnPaint2;
            RBtnPnl2.Paint += RBtnPnlPaint2;
            RBtn2.Paint += RBtnPaint2;
            RChangeTextBtn2.Paint += RChangeTextBtnPaint2;
            RResetBtn2.Paint += RResetBtnPaint2;

            QuitBtn.Click += QuitBtnClick;
            SettingsBtn.Click += SettingsBtnClick;
            ContentPanelResetBtn.Click += ContentPanelResetBtnClick;
            LBtn.Click += LBtnClick;
            LChangeTextBtn.Click += LChangeTextBtnClick;
            LResetBtn.Click += LResetBtnClick;
            RBtn.Click += RbtnClick;
            RChangeTextBtn.Click += RChangeTextBtnClick;
            RResetBtn.Click += RResetBtnClick;

            QuitBtn2.Click += QuitBtnClick;
            SettingsBtn2.Click += SettingsBtnClick;
            ContentPanelResetBtn2.Click += ContentPanelResetBtnClick;
            LBtn2.Click += LBtnClick;
            LChangeTextBtn2.Click += LChangeTextBtnClick;
            LResetBtn2.Click += LResetBtnClick;
            RBtn2.Click += RbtnClick;
            RChangeTextBtn2.Click += RChangeTextBtnClick;
            RResetBtn2.Click += RResetBtnClick;

            //create a reference to form2
            form2 = new Form2();

            //handle key press
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(MainFormKeyDown);
            form2.KeyPreview = true;
            form2.KeyPress += new KeyPressEventHandler(Form2KeyDown);

            //timer settins and handlers
            FadeTimer.Interval = 5;
            FadeTimer.Tick += FadeTimerTick;
            WaitTimer.Interval = 1000;
            WaitTimer.Tick += WaitTimerTick;
                       
            //check for a second screen
            if (m_multi_screens == true)
            {
                ScreenCheck();
            }
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

            ApplicationLbl.SetBounds((InfoPnl.Width/2) - 50, 10, 130, 30);
            ApplicationIconPb.SetBounds((InfoPnl.Width/2) - 85, 12, 30, 30);
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

            SettingsBtn.SetBounds((InfoPnl.Width - 140), 5, 45, 45);
            SettingsBtn.BackColor = MainFormBackcolorClr;
            //SettingsBtn.ForeColor = Color.White;
            SettingsBtn.Visible = true;
            SettingsBtn.FlatStyle = FlatStyle.Flat;
            SettingsBtn.FlatAppearance.BorderSize = 0;
            SettingsBtn.BackgroundImage = Resources.anothere_settings;
            SettingsBtn.BackgroundImageLayout = ImageLayout.Stretch;
            SettingsBtn.AutoSize = false;

            QuitBtn.SetBounds((InfoPnl.Width - 70), 5, 45, 45);
            QuitBtn.BackColor = Color.Purple;
            QuitBtn.Visible = true;
            QuitBtn.FlatStyle = FlatStyle.Flat;
            QuitBtn.FlatAppearance.BorderSize = 0;
            QuitBtn.BackgroundImage = Resources.really_new_quit_button;
            QuitBtn.BackgroundImageLayout = ImageLayout.Zoom;
            QuitBtn.AutoSize = false;

            this.Controls.Add(InfoPnl);
            InfoPnl.Controls.Add(ApplicationLbl);
            InfoPnl.Controls.Add(ApplicationIconPb);
            InfoPnl.Controls.Add(UserLbl);
            InfoPnl.Controls.Add(QuitBtn);
            InfoPnl.Controls.Add(SettingsBtn);
            
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
            LBtn.Text = "yes";
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
            LChangeTextBtn.FlatAppearance.BorderColor = LChangeTextBtnClr;
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
            LResetBtn.FlatAppearance.BorderColor = LResetBtnClr;
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
            RBtn.Text = "no";
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
            RChangeTextBtn.FlatAppearance.BorderColor = RChangeTextBtnClr;
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
            RResetBtn.FlatAppearance.BorderColor = RResetBtnClr;
            RResetBtn.Font = BtnStartFnt;
            RResetBtn.Text = "reset";
            RResetBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            RResetBtn.AutoSize = false;
            f_button = RResetBtn;
            MakeButtonTextFit(f_button);
            RBtnPnl.Controls.Add(RResetBtn);


        }

        public void InitializeChangeTextForms()
        {
            LChangeTextFrm.StartPosition = FormStartPosition.Manual;
            double ChangeTextFrmDWidth = ContentPnl.Width;
            LChangeTextFrm.Width = (int)Math.Truncate(ChangeTextFrmDWidth - (ChangeTextFrmDWidth * .25));
            double ChangeTextFrmDHeight = ContentPnl.Height;
            LChangeTextFrm.Height = (int)Math.Truncate(ChangeTextFrmDHeight - (ChangeTextFrmDHeight * .25));
            LChangeTextFrm.Location = new Point(ContentPnl.Width / 2 - LChangeTextFrm.Width / 2, ContentPnl.Location.Y + ((ContentPnl.Height / 2) - (LChangeTextFrm.Height) / 2));
            LChangeTextFrm.MinimizeBox = false;
            LChangeTextFrm.MaximizeBox = false;
            LChangeTextFrm.ControlBox = false;
            LChangeTextFrm.BackColor = LChangeTextBtnClr;
            LChangeTextFrm.AutoSize = false;
            LChangeTextFrm.FormBorderStyle = FormBorderStyle.None;
            LChangeTextFrm.Paint += LChangeTextFrmPaint;

            double ChangeTextTxtDWidth = LChangeTextFrm.Width;
            LChangeTextFormTxt.Width = (int)Math.Truncate(ChangeTextTxtDWidth - (ChangeTextTxtDWidth * .25));
            LChangeTextFormTxt.Font = BtnStartFnt;
            TextBox f_text = LChangeTextFormTxt;
            Form f_form = LChangeTextFrm;
            SetTextBoxFont(f_text, f_form);
            LChangeTextFormTxt.Location = new Point(LChangeTextFrm.Width / 2 - LChangeTextFormTxt.Width / 2,  (LChangeTextFrm.Height / 2) - (LChangeTextFormTxt.Height) / 2);
            LChangeTextFrm.Controls.Add(LChangeTextFormTxt);

            LChangeTextFormOKBtn.Width = LResetBtn.Width;
            LChangeTextFormOKBtn.Height = LResetBtn.Height;
            LChangeTextFormOKBtn.Location = new Point(LChangeTextFrm.Width - LChangeTextFormOKBtn.Width - ((int) Math.Truncate( LChangeTextFrm.Width * .05)) , ( LChangeTextFrm.Height - LChangeTextFormOKBtn.Height)  - (int)Math.Truncate(LChangeTextFrm.Height * .05));
            LChangeTextFormOKBtn.BackColor = LBtnClr;
            LChangeTextFormOKBtn.Visible = true;
            LChangeTextFormOKBtn.FlatStyle = FlatStyle.Flat;
            LChangeTextFormOKBtn.FlatAppearance.BorderSize = 0;
            LChangeTextFormOKBtn.FlatAppearance.BorderColor = LBtnClr;
            LChangeTextFormOKBtn.Font = BtnStartFnt;
            LChangeTextFormOKBtn.Text = "OK";
            LChangeTextFormOKBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            LChangeTextFormOKBtn.AutoSize = false;
            Button f_button = LChangeTextFormOKBtn;
            MakeButtonTextFit(f_button);
            LChangeTextFormOKBtn.DialogResult = DialogResult.OK;
            LChangeTextFormOKBtn.Paint += LChangeTxtFrmOKBtnPaint;

            LChangeTextFormCancelBtn.Width = LResetBtn.Width;
            LChangeTextFormCancelBtn.Height = LResetBtn.Height;
            LChangeTextFormCancelBtn.Location = new Point( LChangeTextFormOKBtn.Location.X - ( LChangeTextFormOKBtn.Width + ((int)Math.Truncate(LChangeTextFrm.Width * .05))), (LChangeTextFormOKBtn.Location.Y));
            LChangeTextFormCancelBtn.BackColor = LBtnClr;
            LChangeTextFormCancelBtn.Visible = true;
            LChangeTextFormCancelBtn.FlatStyle = FlatStyle.Flat;
            LChangeTextFormCancelBtn.FlatAppearance.BorderSize = 0;
            LChangeTextFormCancelBtn.FlatAppearance.BorderColor = LBtnClr;
            LChangeTextFormCancelBtn.Font = BtnStartFnt;
            LChangeTextFormCancelBtn.Text = "Cancel";
            LChangeTextFormCancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            LChangeTextFormCancelBtn.AutoSize = false;
            Button f_button2 = LChangeTextFormCancelBtn;
            MakeButtonTextFit(f_button2);
            LChangeTextFormCancelBtn.DialogResult = DialogResult.Cancel; 
            LChangeTextFormCancelBtn.Paint += LChangeTxtFrmCancelBtnPaint;

            LChangeTextFrm.AcceptButton = LChangeTextFormOKBtn;
            LChangeTextFrm.CancelButton = LChangeTextFormCancelBtn;
            LChangeTextFrm.Controls.Add(LChangeTextFormOKBtn);
            LChangeTextFrm.Controls.Add(LChangeTextFormCancelBtn);

            RChangeTextFrm.StartPosition = FormStartPosition.Manual;
            //double ChangeTextFrmDWidth = ContentPnl.Width;
            RChangeTextFrm.Width = (int)Math.Truncate(ChangeTextFrmDWidth - (ChangeTextFrmDWidth * .25));
            //double ChangeTextFrmDHeight = ContentPnl.Height;
            RChangeTextFrm.Height = (int)Math.Truncate(ChangeTextFrmDHeight - (ChangeTextFrmDHeight * .25));
            RChangeTextFrm.Location = new Point(ContentPnl.Width / 2 - LChangeTextFrm.Width / 2, ContentPnl.Location.Y + ((ContentPnl.Height / 2) - (LChangeTextFrm.Height) / 2));
            RChangeTextFrm.MinimizeBox = false;
            RChangeTextFrm.MaximizeBox = false;
            RChangeTextFrm.ControlBox = false;
            RChangeTextFrm.BackColor = RChangeTextBtnClr;
            RChangeTextFrm.AutoSize = false;
            RChangeTextFrm.FormBorderStyle = FormBorderStyle.None;
            RChangeTextFrm.Paint += RChangeTextFrmPaint;

            //double ChangeTextTxtDWidth = RChangeTextFrm.Width;
            RChangeTextFormTxt.Width = (int)Math.Truncate(ChangeTextTxtDWidth - (ChangeTextTxtDWidth * .25));
            RChangeTextFormTxt.Font = BtnStartFnt;
            f_text = RChangeTextFormTxt;
            f_form = RChangeTextFrm;
            SetTextBoxFont(f_text, f_form);
            RChangeTextFormTxt.Location = new Point(RChangeTextFrm.Width / 2 - RChangeTextFormTxt.Width / 2, (RChangeTextFrm.Height / 2) - (RChangeTextFormTxt.Height) / 2);
            RChangeTextFrm.Controls.Add(RChangeTextFormTxt);

            RChangeTextFormOKBtn.Width = RResetBtn.Width;
            RChangeTextFormOKBtn.Height = RResetBtn.Height;
            RChangeTextFormOKBtn.Location = new Point(RChangeTextFrm.Width - RChangeTextFormOKBtn.Width - ((int)Math.Truncate(RChangeTextFrm.Width * .05)), (LChangeTextFrm.Height - RChangeTextFormOKBtn.Height) - (int)Math.Truncate(RChangeTextFrm.Height * .05));
            RChangeTextFormOKBtn.BackColor = RBtnClr;
            RChangeTextFormOKBtn.Visible = true;
            RChangeTextFormOKBtn.FlatStyle = FlatStyle.Flat;
            RChangeTextFormOKBtn.FlatAppearance.BorderSize = 0;
            RChangeTextFormOKBtn.FlatAppearance.BorderColor = LBtnClr;
            RChangeTextFormOKBtn.Font = BtnStartFnt;
            RChangeTextFormOKBtn.Text = "OK";
            RChangeTextFormOKBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            f_button = RChangeTextFormOKBtn;
            MakeButtonTextFit(f_button);
            RChangeTextFormOKBtn.DialogResult = DialogResult.OK;
            RChangeTextFormOKBtn.Paint += RChangeTxtFrmOKBtnPaint;

            RChangeTextFormCancelBtn.Width = RResetBtn.Width;
            RChangeTextFormCancelBtn.Height = RResetBtn.Height;
            RChangeTextFormCancelBtn.Location = new Point(RChangeTextFormOKBtn.Location.X - (RChangeTextFormOKBtn.Width + ((int)Math.Truncate(RChangeTextFrm.Width * .05))), (RChangeTextFormOKBtn.Location.Y));
            RChangeTextFormCancelBtn.BackColor = RBtnClr;
            RChangeTextFormCancelBtn.Visible = true;
            RChangeTextFormCancelBtn.FlatStyle = FlatStyle.Flat;
            RChangeTextFormCancelBtn.FlatAppearance.BorderSize = 0;
            RChangeTextFormCancelBtn.FlatAppearance.BorderColor = LBtnClr;
            RChangeTextFormCancelBtn.Font = BtnStartFnt;
            RChangeTextFormCancelBtn.Text = "Cancel";
            RChangeTextFormCancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            RChangeTextFormCancelBtn.AutoSize = false;
            f_button2 = RChangeTextFormCancelBtn;
            MakeButtonTextFit(f_button2);
            RChangeTextFormCancelBtn.DialogResult = DialogResult.Cancel;
            RChangeTextFormCancelBtn.Paint += RChangeTxtFrmCancelBtnPaint;

            RChangeTextFrm.AcceptButton = RChangeTextFormOKBtn;
            RChangeTextFrm.CancelButton = RChangeTextFormCancelBtn;
            RChangeTextFrm.Controls.Add(RChangeTextFormOKBtn);
            RChangeTextFrm.Controls.Add(RChangeTextFormCancelBtn);

        }

        public void InitializeSettingsForm()
        {
            SettingsFrm.StartPosition = FormStartPosition.Manual;
            double SettingsFrmDWidth = ContentPnl.Width;
            SettingsFrm.Width = (int)Math.Truncate(SettingsFrmDWidth - (SettingsFrmDWidth * .25));
            double SettingsFrmDHeight = ContentPnl.Height;
            SettingsFrm.Height = (int)Math.Truncate(SettingsFrmDHeight - (SettingsFrmDHeight * .25));
            SettingsFrm.Location = new Point(ContentPnl.Width / 2 - SettingsFrm.Width / 2, ContentPnl.Location.Y + ((ContentPnl.Height / 2) - (SettingsFrm.Height) / 2));
            SettingsFrm.MinimizeBox = false;
            SettingsFrm.MaximizeBox = false;
            SettingsFrm.ControlBox = false;
            SettingsFrm.BackColor = SettingsFormClr;
            SettingsFrm.AutoSize = false;
            SettingsFrm.FormBorderStyle = FormBorderStyle.None;
            Control f_control3 = SettingsFrm;
            PaintThisControl(f_control3);
           
            double MultiScreensGrpBxDWidth = SettingsFrm.Width;
            MultiScreensGrpBx.Width = (int)Math.Truncate(MultiScreensGrpBxDWidth - (MultiScreensGrpBxDWidth * .8));
            double MultiScreensGrpBxDHeight = SettingsFrm.Height;
            MultiScreensGrpBx.Height = (int)Math.Truncate(SettingsFrm.Height - LResetBtn.Height - (MultiScreensGrpBxDHeight * .3));
            MultiScreensGrpBx.BackColor = GrayPnlClr;
            MultiScreensGroupBoxLbl.Width = (MultiScreensGrpBx.Width - (int)Math.Truncate(MultiScreensGrpBx.Width * .1 ));
            MultiScreensGroupBoxLbl.Height = ((int)Math.Truncate(MultiScreensGrpBx.Height * .25));
            MultiScreensGroupBoxLbl.Location = new Point((int)Math.Truncate(MultiScreensGrpBx.ClientRectangle.X + (MultiScreensGrpBx.ClientRectangle.Width * .05)), (int)Math.Truncate(MultiScreensGrpBx.ClientRectangle.Y + (MultiScreensGrpBx.ClientRectangle.Height * .1)));
            MultiScreensGroupBoxLbl.Font = BtnStartFnt;
            MultiScreensGroupBoxLbl.Text = "Multi Screens:";
            MultiScreensGroupBoxLbl.AutoSize = false;
            MultiScreensGroupBoxLbl.BackColor = GrayPnlClr;
            MultiScreensGroupBoxLbl.Visible = true;
            MultiScreensGrpBx.AutoSize = false;
            Label f_label = MultiScreensGroupBoxLbl;
            MakeLabelTextFit(f_label);
            
            MultiScreensYes.Font = MultiScreensGroupBoxLbl.Font;
            MultiScreensYes.Text = "ON";
            MultiScreensYes.Visible = true;
            MultiScreensYes.AutoSize = true;
            MultiScreensYes.Location = new Point((int)Math.Truncate(MultiScreensGrpBx.ClientRectangle.X + (MultiScreensGrpBx.ClientRectangle.Width * .35)), MultiScreensGroupBoxLbl.Location.Y + MultiScreensGroupBoxLbl.Height + (int)Math.Truncate(MultiScreensGrpBx.Height * .1 ));

            MultiScreensNo.Font = MultiScreensGroupBoxLbl.Font;
            MultiScreensNo.Text = "OFF";
            MultiScreensNo.Visible = true;
            MultiScreensNo.AutoSize = true;
            MultiScreensNo.Location = new Point(MultiScreensYes.Location.X, (int)Math.Truncate((MultiScreensYes.Location.Y * 1.5)));
            
            if (Settings.Default.multi_screens == true)
            {
                MultiScreensYes.Checked = true;
                MultiScreensNo.Checked = false;
            }
            else
            {
                MultiScreensYes.Checked = false;
                MultiScreensNo.Checked = true;
            }
            MultiScreensGrpBx.Controls.Add(MultiScreensGroupBoxLbl);
            MultiScreensGrpBx.Controls.Add(MultiScreensYes);
            MultiScreensGrpBx.Controls.Add(MultiScreensNo);
            Control f_control5 = MultiScreensGrpBx;
            PaintThisControl(f_control5);

            SoundGrpBx.Width = MultiScreensGrpBx.Width;
            SoundGrpBx.Height = MultiScreensGrpBx.Height;   
            SoundGrpBx.BackColor = GrayPnlClr;
            SoundGroupBoxLbl.Width = MultiScreensGroupBoxLbl.Width;
            SoundGroupBoxLbl.Height = MultiScreensGroupBoxLbl.Height;
            SoundGroupBoxLbl.Location = new Point(MultiScreensGroupBoxLbl.Location.X, MultiScreensGroupBoxLbl.Location.Y);
            SoundGroupBoxLbl.Font = MultiScreensGroupBoxLbl.Font;
            SoundGroupBoxLbl.Text = "Sounds:";
            SoundGroupBoxLbl.AutoSize = false;
            SoundGroupBoxLbl.BackColor = GrayPnlClr;
            SoundGroupBoxLbl.Visible = true;
            SoundGrpBx.AutoSize = false;
            //SoundGrpBx.Controls.Add(SoundGroupBoxLbl);
            //Control f_control4 = SoundGrpBx;
            //PaintThisControl(f_control4);

            SoundYes.Font = MultiScreensGroupBoxLbl.Font;
            SoundYes.Text = "ON";
            SoundYes.Visible = true;
            SoundYes.AutoSize = true;
            SoundYes.Location = new Point(MultiScreensYes.Location.X, MultiScreensYes.Location.Y);
            //MultiScreensYes.Location = new Point((int)Math.Truncate(MultiScreensGrpBx.ClientRectangle.X + (MultiScreensGrpBx.ClientRectangle.Width * .35)), MultiScreensGroupBoxLbl.Location.Y + MultiScreensGroupBoxLbl.Height + (int)Math.Truncate(MultiScreensGrpBx.Height * .1));

            SoundNo.Font = MultiScreensGroupBoxLbl.Font;
            SoundNo.Text = "OFF";
            SoundNo.Visible = true;
            SoundNo.AutoSize = true;
            SoundNo.Location = new Point(MultiScreensNo.Location.X, MultiScreensNo.Location.Y);
            //MultiScreensNo.Location = new Point(MultiScreensYes.Location.X, (int)Math.Truncate((MultiScreensYes.Location.Y * 1.5)));

            if (Settings.Default.sound == true)
            {
                SoundYes.Checked = true;
                SoundNo.Checked = false;
            }
            else
            {
                SoundYes.Checked = false;
                SoundNo.Checked = true;
            }
            SoundGrpBx.Controls.Add(SoundGroupBoxLbl);
            SoundGrpBx.Controls.Add(SoundYes);
            SoundGrpBx.Controls.Add(SoundNo);
            Control f_control4 = SoundGrpBx;
            PaintThisControl(f_control4);

            MultiScreensGrpBx.Location = new Point((int)Math.Truncate(SettingsFrm.ClientRectangle.X + MultiScreensGrpBxDWidth * .01), (int)Math.Truncate(SettingsFrm.ClientRectangle.Y + MultiScreensGrpBxDHeight * .05));
            SoundGrpBx.Location = new Point((int)Math.Truncate(MultiScreensGrpBx.Location.X + MultiScreensGrpBx.Width + SettingsFrm.Width * .01), MultiScreensGrpBx.Location.Y);
            SettingsFrm.Controls.Add(MultiScreensGrpBx);
            SettingsFrm.Controls.Add(SoundGrpBx);

            SettingsFormOKBtn.Width = LResetBtn.Width;
            SettingsFormOKBtn.Height = LResetBtn.Height;
            SettingsFormOKBtn.Location = new Point(SettingsFrm.Width - SettingsFormOKBtn.Width - ((int)Math.Truncate(SettingsFrm.Width * .05)), (SettingsFrm.Height - SettingsFormOKBtn.Height) - (int)Math.Truncate(SettingsFrm.Height * .1));
            SettingsFormOKBtn.BackColor = SettingsBtnClr;
            SettingsFormOKBtn.Visible = true;
            SettingsFormOKBtn.FlatStyle = FlatStyle.Flat;
            SettingsFormOKBtn.FlatAppearance.BorderSize = 0;
            SettingsFormOKBtn.FlatAppearance.BorderColor = SettingsBtnClr;
            SettingsFormOKBtn.Font = BtnStartFnt;
            SettingsFormOKBtn.Text = "OK";
            SettingsFormOKBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            SettingsFormOKBtn.AutoSize = false;
            Button f_button = SettingsFormOKBtn;
            MakeButtonTextFit(f_button);
            SettingsFormOKBtn.DialogResult = DialogResult.OK;
            Control f_control = SettingsFormOKBtn;
            PaintThisControl(f_control);
            //SettingsFormOKBtn.Paint += SettingsFrmOKBtnPaint;


            SettingsFormCancelBtn.Width = LResetBtn.Width;
            SettingsFormCancelBtn.Height = LResetBtn.Height;
            SettingsFormCancelBtn.Location = new Point(SettingsFormOKBtn.Location.X - (SettingsFormOKBtn.Width + ((int)Math.Truncate(SettingsFrm.Width * .05))), (SettingsFormOKBtn.Location.Y));
            SettingsFormCancelBtn.BackColor = SettingsBtnClr;
            SettingsFormCancelBtn.Visible = true;
            SettingsFormCancelBtn.FlatStyle = FlatStyle.Flat;
            SettingsFormCancelBtn.FlatAppearance.BorderSize = 0;
            SettingsFormCancelBtn.FlatAppearance.BorderColor = SettingsBtnClr;
            SettingsFormCancelBtn.Font = BtnStartFnt;
            SettingsFormCancelBtn.Text = "Cancel";
            SettingsFormCancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            SettingsFormCancelBtn.AutoSize = false;
            Button f_button2 = SettingsFormCancelBtn;
            MakeButtonTextFit(f_button2);
            SettingsFormCancelBtn.DialogResult = DialogResult.Cancel;
            Control f_control2 = SettingsFormCancelBtn;
            PaintThisControl(f_control2);
            //SettingsFormCancelBtn.Paint += LChangeTxtFrmCancelBtnPaint;

            SettingsFrm.AcceptButton = SettingsFormOKBtn;
            SettingsFrm.CancelButton = SettingsFormCancelBtn;
            SettingsFrm.Controls.Add(SettingsFormOKBtn);
            SettingsFrm.Controls.Add(SettingsFormCancelBtn);
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

        private void Form2KeyDown(object sender, System.Windows.Forms.KeyPressEventArgs e)
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
                    ContentPnl2.BackColor = Color.FromArgb(old_r, old_g, old_b);
                    ContentPnl2.Refresh();
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
                    ContentPnl2.BackColor = Color.FromArgb(old_r, old_g, old_b);
                    ContentPnl2.Refresh();
                }
            }
           

        }

        public void ScreenCheck()
        {
            // get all the screens on the system
            System.Windows.Forms.Screen[] screens = System.Windows.Forms.Screen.AllScreens;

            // if there is a second screen
            if (screens.Length > 1)
            {
                //set up screen2 
                form2.MaximizeBox = false;
                form2.MinimizeBox = false;
                form2.ControlBox = true;
                form2.WindowState = FormWindowState.Normal;
                form2.FormBorderStyle = FormBorderStyle.None;
                form2.BackColor = MainFormBackcolorClr;
                form2.AutoSize = false;
                form2.StartPosition = FormStartPosition.Manual;
                form2.Location = screens[1].WorkingArea.Location;
                var Form2ScreenSize = new System.Drawing.Size(screens[1].Bounds.Width, screens[1].Bounds.Height);
                form2.Size = new Size(Form2ScreenSize.Width, Form2ScreenSize.Height);
                form2.Text = "tell us Josie";
                form2.Icon = Resources.tua_icon;

                //set up the screen2 content panel
                int ContentPnlHeight2 = (int)(Form2ScreenSize.Height * .60);
                ContentPnl2.SetBounds(10, 100, Form2ScreenSize.Width - 30, ContentPnlHeight2 - 80);
                ContentPnl2.BorderStyle = BorderStyle.None;
                ContentPnl2.BackColor = GrayPnlClr;
                ContentPnl2.Visible = true;
                form2.Controls.Add(ContentPnl2);

                double AnswerLblDWidth2 = ContentPnl2.Width;
                AnswerLbl2.Width = (int)Math.Truncate(AnswerLblDWidth2 - (AnswerLblDWidth2 * .05));
                double AnswerLblDHeight2 = ContentPnl2.Height;
                AnswerLbl2.Height = (int)Math.Truncate(AnswerLblDHeight2 - (AnswerLblDHeight2 * .18));
                AnswerLbl2.Location = new Point(ContentPnl2.Width / 2 - AnswerLbl2.Width / 2, ContentPnl2.Width / 2 - AnswerLbl2.Width / 2);
                AnswerLbl2.BackColor = Color.Transparent;
                AnswerLbl2.Font = BtnStartFnt;
                AnswerLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                AnswerLbl2.Text = " ";
                AnswerLbl2.AutoSize = false;
                AnswerLbl2.Visible = true;
                Label f_label = AnswerLbl2;
                MakeLabelTextFit(f_label);
                ContentPnl2.Controls.Add(AnswerLbl2);

                // set up the info panel 
                InfoPnl2.SetBounds(20, 10, ContentPnl2.Width - 40, 50);
                InfoPnl2.BorderStyle = BorderStyle.None;
                InfoPnl2.BackColor = System.Drawing.Color.Transparent;
                InfoPnl2.Visible = true;

                ApplicationLbl2.SetBounds((InfoPnl2.Width / 2) - 50, 10, 130, 30);
                ApplicationIconPb2.SetBounds((InfoPnl2.Width / 2) - 85, 12, 30, 30);
                UserLbl2.SetBounds(50, 10, 300, 30);

                UserLbl2.Font = LabelBigFnt;
                UserLbl2.Text = m_LicensedUser;
                UserLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                UserLbl2.ForeColor = InfoPnlClr;
                UserLbl2.BackColor = Color.Transparent;
                UserLbl2.Visible = true;

                ApplicationLbl2.Font = LabelMedFnt;
                ApplicationLbl2.Text = "tell us Josie...";
                ApplicationLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                ApplicationLbl2.ForeColor = InfoPnlClr;
                ApplicationLbl2.BackColor = Color.Transparent;
                ApplicationLbl2.Visible = true;

                ApplicationIconPb2.Image = Resources.tua_better;
                ApplicationIconPb2.BorderStyle = BorderStyle.None;
                ApplicationIconPb2.SizeMode = PictureBoxSizeMode.StretchImage;
                ApplicationIconPb2.Visible = true;

                //SettingsBtn2.SetBounds((InfoPnl2.Width - 130), 10, 50, 50);
                SettingsBtn2.SetBounds((InfoPnl2.Width - 140), 5, 45, 45);
                SettingsBtn2.BackColor = MainFormBackcolorClr;
                //SettingsBtn.ForeColor = Color.White;
                SettingsBtn2.Visible = true;
                SettingsBtn2.FlatStyle = FlatStyle.Flat;
                SettingsBtn2.FlatAppearance.BorderSize = 0;
                SettingsBtn2.BackgroundImage = Resources.anothere_settings;
                SettingsBtn2.BackgroundImageLayout = ImageLayout.Stretch;
                SettingsBtn2.AutoSize = false;

                QuitBtn2.SetBounds((InfoPnl2.Width - 70), 5, 45, 45);
                QuitBtn2.BackColor = Color.Purple;
                QuitBtn2.Visible = true;
                QuitBtn2.FlatStyle = FlatStyle.Flat;
                QuitBtn2.FlatAppearance.BorderSize = 0;
                QuitBtn2.BackgroundImage = Resources.really_new_quit_button;
                QuitBtn2.BackgroundImageLayout = ImageLayout.Zoom;
                QuitBtn2.AutoSize = false;

                form2.Controls.Add(InfoPnl2);
                InfoPnl2.Controls.Add(ApplicationLbl2);
                InfoPnl2.Controls.Add(ApplicationIconPb2);
                InfoPnl2.Controls.Add(UserLbl2);
                InfoPnl2.Controls.Add(SettingsBtn2);
                InfoPnl2.Controls.Add(QuitBtn2);

                //set up the left button panel 2
                int LBtnPnlWidth2 = (Form2ScreenSize.Width / 2) - 80;
                int LBtnPnlHeight2 = (int)(Form2ScreenSize.Height * .40) - 80;
                LBtnPnl2.SetBounds(30, (Form2ScreenSize.Height - (LBtnPnlHeight2 + 20)), LBtnPnlWidth2, LBtnPnlHeight2);
                LBtnPnl2.BackColor = LBtnClr;
                LBtnPnl2.Visible = true;
                form2.Controls.Add(LBtnPnl2);

                //set up the left button 2
                double LBtnDWidth2 = LBtnPnlWidth2;
                LBtn2.Width = (int)Math.Truncate(LBtnDWidth2 - (LBtnDWidth2 * .05));
                double LBtnDHeight2 = LBtnPnlHeight2;
                LBtn2.Height = (int)Math.Truncate(LBtnDHeight2 - (LBtnDHeight2 * .3));
                LBtn2.Location = new Point((LBtnPnl2.Width / 2) - LBtn2.Width / 2, (LBtnPnl2.Width / 2) - LBtn2.Width / 2);
                LBtn2.BackColor = LBtnClr;
                LBtn2.Visible = true;
                LBtn2.FlatStyle = FlatStyle.Flat;
                LBtn2.FlatAppearance.BorderSize = 0;
                LBtn2.Font = BtnStartFnt;
                LBtn2.Text = LBtn.Text; 
                LBtn2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                LBtn2.AutoSize = false;
                Button f_button = LBtn2;
                MakeButtonTextFit(f_button);
                LBtnPnl2.Controls.Add(LBtn2);

                //set up the left change text button 2
                double LChangeTextBtnDWidth2 = LBtnPnlWidth2;
                LChangeTextBtn2.Width = (int)Math.Truncate(LChangeTextBtnDWidth2 - (LChangeTextBtnDWidth2 * .3));
                double LChangeTextBtnDHeight2 = LBtnPnlHeight2;
                LChangeTextBtn2.Height = (int)Math.Truncate(LChangeTextBtnDHeight2 - (LChangeTextBtnDHeight2 * .85));
                LChangeTextBtn2.Location = new Point(LBtn2.Location.X, LBtn2.Location.Y + LBtn2.Height + (int)Math.Truncate(LChangeTextBtnDHeight2 * .05));
                LChangeTextBtn2.BackColor = LChangeTextBtnClr;
                LChangeTextBtn2.Visible = true;
                LChangeTextBtn2.FlatStyle = FlatStyle.Flat;
                LChangeTextBtn2.FlatAppearance.BorderSize = 0;
                LChangeTextBtn2.FlatAppearance.BorderColor = LChangeTextBtnClr;
                LChangeTextBtn2.Font = BtnStartFnt;
                LChangeTextBtn2.Text = "change text";
                LChangeTextBtn2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                LChangeTextBtn2.AutoSize = false;
                f_button = LChangeTextBtn2;
                MakeButtonTextFit(f_button);
                LBtnPnl2.Controls.Add(LChangeTextBtn2);

                //set up the left reset button 2
                double LResetBtnDWidth2 = LBtnPnlWidth2;
                LResetBtn2.Width = (int)Math.Truncate(LResetBtnDWidth2 - (LResetBtnDWidth2 * .78));
                double LResetBtnDHeight2 = LBtnPnlHeight2;
                LResetBtn2.Height = LChangeTextBtn2.Height;
                LResetBtn2.Location = new Point(LBtn2.Location.X + LChangeTextBtn2.Width + (int)Math.Truncate(LChangeTextBtn2.Width * .05), LChangeTextBtn2.Location.Y);
                LResetBtn2.BackColor = LResetBtnClr;
                LResetBtn2.Visible = true;
                LResetBtn2.FlatStyle = FlatStyle.Flat;
                LResetBtn2.FlatAppearance.BorderSize = 0;
                LResetBtn2.FlatAppearance.BorderColor = LResetBtnClr;
                LResetBtn2.Font = BtnStartFnt;
                LResetBtn2.Text = "reset";
                LResetBtn2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                LResetBtn2.AutoSize = false;
                f_button = LResetBtn2;
                MakeButtonTextFit(f_button);
                LBtnPnl2.Controls.Add(LResetBtn2);

                //set up the right button panel 2
                int RBtnPnlWidth2 = (Form2ScreenSize.Width / 2) - 80;
                int RBtnPnlHeight2 = (int)(Form2ScreenSize.Height * .40) - 80;
                RBtnPnl2.SetBounds((Form2ScreenSize.Width / 2) + 30, (Form2ScreenSize.Height - (RBtnPnlHeight2 + 20)), RBtnPnlWidth2, RBtnPnlHeight2);
                RBtnPnl2.BackColor = RBtnClr;
                RBtnPnl2.Visible = true;
                form2.Controls.Add(RBtnPnl2);

                //set up the right button 2
                double RBtnDWidth2 = RBtnPnlWidth2;
                RBtn2.Width = (int)Math.Truncate(RBtnDWidth2 - (RBtnDWidth2 * .05));
                double RBtnDHeight2 = RBtnPnlHeight2;
                RBtn2.Height = (int)Math.Truncate(RBtnDHeight2 - (RBtnDHeight2 * .3));
                RBtn2.Location = new Point((RBtnPnl2.Width / 2) - RBtn2.Width / 2, (RBtnPnl2.Width / 2) - RBtn2.Width / 2);
                RBtn2.BackColor = RBtnClr;
                RBtn2.Visible = true;
                RBtn2.FlatStyle = FlatStyle.Flat;
                RBtn2.FlatAppearance.BorderSize = 0;
                RBtn2.Font = BtnStartFnt;
                RBtn2.Text = RBtn.Text; 
                RBtn2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                RBtn2.AutoSize = false;
                f_button = RBtn2;
                MakeButtonTextFit(f_button);
                RBtnPnl2.Controls.Add(RBtn2);

                //set up the right change text button 2
                double RChangeTextBtnDWidth2 = RBtnPnlWidth2;
                RChangeTextBtn2.Width = (int)Math.Truncate(RChangeTextBtnDWidth2 - (RChangeTextBtnDWidth2 * .3));
                double RChangeTextBtnDHeight2 = RBtnPnlHeight2;
                RChangeTextBtn2.Height = (int)Math.Truncate(RChangeTextBtnDHeight2 - (RChangeTextBtnDHeight2 * .85));
                RChangeTextBtn2.Location = new Point(RBtn2.Location.X, RBtn2.Location.Y + RBtn2.Height + (int)Math.Truncate(RChangeTextBtnDHeight2 * .05));
                RChangeTextBtn2.BackColor = RChangeTextBtnClr;
                RChangeTextBtn2.Visible = true;
                RChangeTextBtn2.FlatStyle = FlatStyle.Flat;
                RChangeTextBtn2.FlatAppearance.BorderSize = 0;
                RChangeTextBtn2.FlatAppearance.BorderColor = RChangeTextBtnClr;
                RChangeTextBtn2.Font = BtnStartFnt;
                RChangeTextBtn2.Text = "change text";
                RChangeTextBtn2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                RChangeTextBtn2.AutoSize = false;
                f_button = RChangeTextBtn2;
                MakeButtonTextFit(f_button);
                RBtnPnl2.Controls.Add(RChangeTextBtn2);

                //set up the right reset button 2
                double RResetBtnDWidth2 = RBtnPnlWidth2;
                RResetBtn2.Width = (int)Math.Truncate(RResetBtnDWidth2 - (RResetBtnDWidth2 * .78));
                double RResetBtnDHeight2 = RBtnPnlHeight2;
                RResetBtn2.Height = RChangeTextBtn2.Height;
                RResetBtn2.Location = new Point(RBtn2.Location.X + RChangeTextBtn2.Width + (int)Math.Truncate(RChangeTextBtn2.Width * .05), RChangeTextBtn2.Location.Y);
                RResetBtn2.BackColor = RResetBtnClr;
                RResetBtn2.Visible = true;
                RResetBtn2.FlatStyle = FlatStyle.Flat;
                RResetBtn2.FlatAppearance.BorderSize = 0;
                RResetBtn2.FlatAppearance.BorderColor = RResetBtnClr;
                RResetBtn2.Font = BtnStartFnt;
                RResetBtn2.Text = "reset";
                RResetBtn2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                RResetBtn2.AutoSize = false;
                f_button = RResetBtn2;
                MakeButtonTextFit(f_button);
                RBtnPnl2.Controls.Add(RResetBtn2);

                form2.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
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

        private void MakeGroupBoxTextFit(GroupBox f_groupbox)
        {
            string text = f_groupbox.Text;
            Font font = f_groupbox.Font;

            float fontSize = font.Size;
            while ((TextRenderer.MeasureText(text, font).Width <= f_groupbox.Width /2) & (TextRenderer.MeasureText(text, font).Height <= f_groupbox.Height / 10))
            {
                fontSize++;
                font = new Font(font.FontFamily, fontSize, font.Style);
            }
            f_groupbox.Font = font;
        }


        private void PaintThisControl(Control f_control)
        {
            //this is the new paint function - works for all objects

            Region region = f_control.Region;

            var ControlPath = new System.Drawing.Drawing2D.GraphicsPath();
            ControlPath.StartFigure();
            ControlPath.AddArc(f_control.DisplayRectangle.X + f_control.DisplayRectangle.Width - 50, f_control.DisplayRectangle.Y, 50, 50, 270, 90);
            ControlPath.AddArc(f_control.DisplayRectangle.X + f_control.DisplayRectangle.Width - 50, f_control.DisplayRectangle.Y + f_control.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            ControlPath.AddArc(f_control.DisplayRectangle.X, f_control.DisplayRectangle.Y + f_control.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            ControlPath.AddArc(f_control.DisplayRectangle.X, f_control.DisplayRectangle.Y, 50, 50, 180, 90);
            ControlPath.CloseFigure();
            f_control.Region = new System.Drawing.Region(ControlPath);
        }

        private void SetTextBoxFont(TextBox f_text, Form f_form)
        {
            Font font = f_text.Font;

            float fontSize = font.Size;
            while (TextRenderer.MeasureText("X", font).Height <= (int)Math.Truncate(f_form.Height * .5) & (fontSize <= 70))
            {
                fontSize++;
                font = new Font(font.FontFamily, fontSize, font.Style);
            }
            f_text.Font = font;
        }

        #endregion

        #region CLICK EVENTS
        private void SettingsBtnClick(object sender, EventArgs e)
        {
            SettingsFrm.Select();
            SettingsFrm.ShowDialog();

            if(SettingsFrm.DialogResult == DialogResult.OK)
            {
                //deal with sound result
                if (SoundYes.Checked == true){Settings.Default.sound = true;} else {Settings.Default.sound = false;}

                //deal with multi screens result
                if (MultiScreensYes.Checked == true){ Settings.Default.multi_screens = true;} else {Settings.Default.multi_screens = false;}

                //now save all the settings           
                Settings.Default.Save();

                //now reload program to deal with change in multi screens
                Application.Restart();
                                    
            }
            else
            //result is cancel - so reset the radiobuttons to match the saved settings
            {
                if(Settings.Default.sound == true) { SoundYes.Checked = true; SoundNo.Checked = false; } else { SoundYes.Checked = false; SoundNo.Checked = true; }
                if(Settings.Default.multi_screens == true ) { MultiScreensYes.Checked = true; MultiScreensNo.Checked = false; } else { MultiScreensYes.Checked = false; MultiScreensNo.Checked = true; }

                SettingsFrm.Visible = false;
            }

        }

        private void QuitBtnClick(object sender, EventArgs e)
        {
            Close();
        }
        
        private void ContentPanelResetBtnClick(object sender, EventArgs e)
        {
            AnswerLbl.Font = BtnStartFnt;
            AnswerLbl.Text = "";
            m_last_pressed = " ";
            ContentPnl.BackColor = GrayPnlClr;
            ContentPnl.Refresh();

            AnswerLbl2.Font = BtnStartFnt;
            AnswerLbl2.Text = "";
            ContentPnl2.BackColor = GrayPnlClr;
            ContentPnl2.Refresh();
        }

        private void LBtnClick(object sender, EventArgs e)
        {
            AnswerLbl.Font = BtnStartFnt;
            AnswerLbl.Text = LBtn.Text;
            Label f_label = AnswerLbl;
            MakeLabelTextFit(f_label);
            m_last_pressed = "L";
            ContentPnl.BackColor = LPressedClr;

            AnswerLbl2.Font = BtnStartFnt;
            AnswerLbl2.Text = LBtn.Text;
            Label f_label2 = AnswerLbl2;
            MakeLabelTextFit(f_label2);
            ContentPnl2.BackColor = LPressedClr;

            if (Settings.Default.sound == true)
            {
                SoundPlayer player = new SoundPlayer(Properties.Resources.disco_beat);
                player.Play();
            }    
            WaitTimer.Start();
            
        }

        private void LChangeTextBtnClick(object sender, EventArgs e) 
        {
            LChangeTextFormTxt.Select();
            LChangeTextFrm.ShowDialog();
            if (LChangeTextFrm.DialogResult == DialogResult.OK)
            {
                //first make sure it's not blank
                if (LChangeTextFormTxt.Text == "")
                {
                    LChangeTextFrm.Visible = false;
                }
                else
                {
                    LBtn.Text = LChangeTextFormTxt.Text;
                    LBtn.Font = BtnStartFnt;
                    Button f_button = LBtn;
                    MakeButtonTextFit(f_button);

                    LBtn2.Text = LChangeTextFormTxt.Text;
                    LBtn2.Font = BtnStartFnt;
                    Button f_button2 = LBtn2;
                    MakeButtonTextFit(f_button2);

                    LChangeTextFormTxt.Text = "";
                    LChangeTextFrm.Visible = false;
                } 
            }
           else
            {
                LChangeTextFormTxt.Text = "";
                LChangeTextFrm.Visible = false;
            }
            ContentPanelResetBtn.PerformClick();
        }

        private void LResetBtnClick(object sender, EventArgs e)
        {
            LBtn.Text = "yes";
            LBtn2.Text = "yes";
        }

        private void RbtnClick(object sender, EventArgs e)
        {
            AnswerLbl.Font = BtnStartFnt;
            AnswerLbl.Text = RBtn.Text;
            Label f_label = AnswerLbl;
            MakeLabelTextFit(f_label);
            m_last_pressed = "R";
            ContentPnl.BackColor = RPressedClr;

            AnswerLbl2.Font = BtnStartFnt;
            AnswerLbl2.Text = RBtn.Text;
            Label f_label2 = AnswerLbl2;
            MakeLabelTextFit(f_label2);
            ContentPnl2.BackColor = RPressedClr;

            if (Settings.Default.sound == true)
            {
                SoundPlayer player = new SoundPlayer(Properties.Resources.rock_beat);
                player.Play();
            }
            WaitTimer.Start();
        }

        private void RChangeTextBtnClick(object sender, EventArgs e)
        {
            RChangeTextFormTxt.Select();
            RChangeTextFrm.ShowDialog();
            if (RChangeTextFrm.DialogResult == DialogResult.OK)
            {
                //first make sure it's not blank
                if (RChangeTextFormTxt.Text == "")
                {
                    RChangeTextFrm.Visible = false;
                }
                else
                {
                    RBtn.Text = RChangeTextFormTxt.Text;
                    RBtn.Font = BtnStartFnt;
                    Button f_button = RBtn;
                    MakeButtonTextFit(f_button);

                    RBtn2.Text = RChangeTextFormTxt.Text;
                    RBtn2.Font = BtnStartFnt;
                    Button f_button2 = RBtn2;
                    MakeButtonTextFit(f_button2);

                    RChangeTextFormTxt.Text = "";
                    RChangeTextFrm.Visible = false;
                }
            }
            else
            {
                RChangeTextFormTxt.Text = "";
                LChangeTextFrm.Visible = false;
            }
            ContentPanelResetBtn.PerformClick();
        }

        private void RResetBtnClick(object sender, EventArgs e)
        {
            RBtn.Text = "no";
            RBtn2.Text = "no";
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

        private void QuitBtnPaint(object? sender, PaintEventArgs e)
        {
            var LBtnPnlPath = new System.Drawing.Drawing2D.GraphicsPath();
            LBtnPnlPath.StartFigure();
            LBtnPnlPath.AddArc(QuitBtn.DisplayRectangle.X + QuitBtn.DisplayRectangle.Width - 50, QuitBtn.DisplayRectangle.Y, 50, 50, 270, 90);
            LBtnPnlPath.AddArc(QuitBtn.DisplayRectangle.X + QuitBtn.DisplayRectangle.Width - 50, QuitBtn.DisplayRectangle.Y + QuitBtn.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            LBtnPnlPath.AddArc(QuitBtn.DisplayRectangle.X, QuitBtn.DisplayRectangle.Y + QuitBtn.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            LBtnPnlPath.AddArc(QuitBtn.DisplayRectangle.X, QuitBtn.DisplayRectangle.Y, 50, 50, 180, 90);
            LBtnPnlPath.CloseFigure();
            QuitBtn.Region = new System.Drawing.Region(LBtnPnlPath);
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

        private void LChangeTextFrmPaint(object sender, PaintEventArgs e)
        {
            var ContentPnlPath = new System.Drawing.Drawing2D.GraphicsPath();
            ContentPnlPath.StartFigure();
            ContentPnlPath.AddArc(LChangeTextFrm.DisplayRectangle.X + LChangeTextFrm.DisplayRectangle.Width - 50, LChangeTextFrm.DisplayRectangle.Y, 50, 50, 270, 90);
            ContentPnlPath.AddArc(LChangeTextFrm.DisplayRectangle.X + LChangeTextFrm.DisplayRectangle.Width - 50, LChangeTextFrm.DisplayRectangle.Y + LChangeTextFrm.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            ContentPnlPath.AddArc(LChangeTextFrm.DisplayRectangle.X, LChangeTextFrm.DisplayRectangle.Y + LChangeTextFrm.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            ContentPnlPath.AddArc(LChangeTextFrm.DisplayRectangle.X, LChangeTextFrm.DisplayRectangle.Y, 50, 50, 180, 90);
            ContentPnlPath.CloseFigure();
            LChangeTextFrm.Region = new System.Drawing.Region(ContentPnlPath);
        }

        private void LChangeTxtFrmOKBtnPaint(object? sender, PaintEventArgs e)
        {
            var LBtnPnlPath = new System.Drawing.Drawing2D.GraphicsPath();
            LBtnPnlPath.StartFigure();
            LBtnPnlPath.AddArc(LChangeTextFormOKBtn.DisplayRectangle.X + LChangeTextFormOKBtn.DisplayRectangle.Width - 50, LChangeTextFormOKBtn.DisplayRectangle.Y, 50, 50, 270, 90);
            LBtnPnlPath.AddArc(LChangeTextFormOKBtn.DisplayRectangle.X + LChangeTextFormOKBtn.DisplayRectangle.Width - 50, LChangeTextFormOKBtn.DisplayRectangle.Y + LChangeTextFormOKBtn.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            LBtnPnlPath.AddArc(LChangeTextFormOKBtn.DisplayRectangle.X, LChangeTextFormOKBtn.DisplayRectangle.Y + LChangeTextFormOKBtn.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            LBtnPnlPath.AddArc(LChangeTextFormOKBtn.DisplayRectangle.X, LChangeTextFormOKBtn.DisplayRectangle.Y, 50, 50, 180, 90);
            LBtnPnlPath.CloseFigure();
            LChangeTextFormOKBtn.Region = new System.Drawing.Region(LBtnPnlPath);
        }

        private void LChangeTxtFrmCancelBtnPaint(object? sender, PaintEventArgs e)
        {
            var LBtnPnlPath = new System.Drawing.Drawing2D.GraphicsPath();
            LBtnPnlPath.StartFigure();
            LBtnPnlPath.AddArc(LChangeTextFormCancelBtn.DisplayRectangle.X + LChangeTextFormCancelBtn.DisplayRectangle.Width - 50, LChangeTextFormCancelBtn.DisplayRectangle.Y, 50, 50, 270, 90);
            LBtnPnlPath.AddArc(LChangeTextFormCancelBtn.DisplayRectangle.X + LChangeTextFormCancelBtn.DisplayRectangle.Width - 50, LChangeTextFormCancelBtn.DisplayRectangle.Y + LChangeTextFormCancelBtn.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            LBtnPnlPath.AddArc(LChangeTextFormCancelBtn.DisplayRectangle.X, LChangeTextFormCancelBtn.DisplayRectangle.Y + LChangeTextFormCancelBtn.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            LBtnPnlPath.AddArc(LChangeTextFormCancelBtn.DisplayRectangle.X, LChangeTextFormCancelBtn.DisplayRectangle.Y, 50, 50, 180, 90);
            LBtnPnlPath.CloseFigure();
            LChangeTextFormCancelBtn.Region = new System.Drawing.Region(LBtnPnlPath);
        }

        private void RChangeTextFrmPaint(object sender, PaintEventArgs e)
        {
            var ContentPnlPath = new System.Drawing.Drawing2D.GraphicsPath();
            ContentPnlPath.StartFigure();
            ContentPnlPath.AddArc(RChangeTextFrm.DisplayRectangle.X + RChangeTextFrm.DisplayRectangle.Width - 50, RChangeTextFrm.DisplayRectangle.Y, 50, 50, 270, 90);
            ContentPnlPath.AddArc(RChangeTextFrm.DisplayRectangle.X + RChangeTextFrm.DisplayRectangle.Width - 50, RChangeTextFrm.DisplayRectangle.Y + RChangeTextFrm.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            ContentPnlPath.AddArc(RChangeTextFrm.DisplayRectangle.X, RChangeTextFrm.DisplayRectangle.Y + RChangeTextFrm.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            ContentPnlPath.AddArc(RChangeTextFrm.DisplayRectangle.X, RChangeTextFrm.DisplayRectangle.Y, 50, 50, 180, 90);
            ContentPnlPath.CloseFigure();
            RChangeTextFrm.Region = new System.Drawing.Region(ContentPnlPath);
        }

        private void RChangeTxtFrmOKBtnPaint(object? sender, PaintEventArgs e)
        {
            var LBtnPnlPath = new System.Drawing.Drawing2D.GraphicsPath();
            LBtnPnlPath.StartFigure();
            LBtnPnlPath.AddArc(RChangeTextFormOKBtn.DisplayRectangle.X + RChangeTextFormOKBtn.DisplayRectangle.Width - 50, RChangeTextFormOKBtn.DisplayRectangle.Y, 50, 50, 270, 90);
            LBtnPnlPath.AddArc(RChangeTextFormOKBtn.DisplayRectangle.X + RChangeTextFormOKBtn.DisplayRectangle.Width - 50, RChangeTextFormOKBtn.DisplayRectangle.Y + RChangeTextFormOKBtn.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            LBtnPnlPath.AddArc(RChangeTextFormOKBtn.DisplayRectangle.X, RChangeTextFormOKBtn.DisplayRectangle.Y + RChangeTextFormOKBtn.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            LBtnPnlPath.AddArc(RChangeTextFormOKBtn.DisplayRectangle.X, RChangeTextFormOKBtn.DisplayRectangle.Y, 50, 50, 180, 90);
            LBtnPnlPath.CloseFigure();
            RChangeTextFormOKBtn.Region = new System.Drawing.Region(LBtnPnlPath);
        }

        private void RChangeTxtFrmCancelBtnPaint(object? sender, PaintEventArgs e)
        {
            var LBtnPnlPath = new System.Drawing.Drawing2D.GraphicsPath();
            LBtnPnlPath.StartFigure();
            LBtnPnlPath.AddArc(RChangeTextFormCancelBtn.DisplayRectangle.X + RChangeTextFormCancelBtn.DisplayRectangle.Width - 50, RChangeTextFormCancelBtn.DisplayRectangle.Y, 50, 50, 270, 90);
            LBtnPnlPath.AddArc(RChangeTextFormCancelBtn.DisplayRectangle.X + RChangeTextFormCancelBtn.DisplayRectangle.Width - 50, RChangeTextFormCancelBtn.DisplayRectangle.Y + RChangeTextFormCancelBtn.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            LBtnPnlPath.AddArc(RChangeTextFormCancelBtn.DisplayRectangle.X, RChangeTextFormCancelBtn.DisplayRectangle.Y + RChangeTextFormCancelBtn.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            LBtnPnlPath.AddArc(RChangeTextFormCancelBtn.DisplayRectangle.X, RChangeTextFormCancelBtn.DisplayRectangle.Y, 50, 50, 180, 90);
            LBtnPnlPath.CloseFigure();
            RChangeTextFormCancelBtn.Region = new System.Drawing.Region(LBtnPnlPath);
        }

        private void ContentPnlPaint2(object? sender, PaintEventArgs e)
        {
            var ContentPnlPath = new System.Drawing.Drawing2D.GraphicsPath();
            ContentPnlPath.StartFigure();
            ContentPnlPath.AddArc(ContentPnl2.DisplayRectangle.X + ContentPnl2.DisplayRectangle.Width - 50, ContentPnl2.DisplayRectangle.Y, 50, 50, 270, 90);
            ContentPnlPath.AddArc(ContentPnl2.DisplayRectangle.X + ContentPnl2.DisplayRectangle.Width - 50, ContentPnl2.DisplayRectangle.Y + ContentPnl2.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            ContentPnlPath.AddArc(ContentPnl2.DisplayRectangle.X, ContentPnl2.DisplayRectangle.Y + ContentPnl2.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            ContentPnlPath.AddArc(ContentPnl2.DisplayRectangle.X, ContentPnl2.DisplayRectangle.Y, 50, 50, 180, 90);
            ContentPnlPath.CloseFigure();
            ContentPnl2.Region = new System.Drawing.Region(ContentPnlPath);
        }

        private void QuitBtnPaint2(object? sender, PaintEventArgs e)
        {
            var LBtnPnlPath = new System.Drawing.Drawing2D.GraphicsPath();
            LBtnPnlPath.StartFigure();
            LBtnPnlPath.AddArc(QuitBtn2.DisplayRectangle.X + QuitBtn2.DisplayRectangle.Width - 50, QuitBtn2.DisplayRectangle.Y, 50, 50, 270, 90);
            LBtnPnlPath.AddArc(QuitBtn2.DisplayRectangle.X + QuitBtn2.DisplayRectangle.Width - 50, QuitBtn2.DisplayRectangle.Y + QuitBtn2.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            LBtnPnlPath.AddArc(QuitBtn2.DisplayRectangle.X, QuitBtn2.DisplayRectangle.Y + QuitBtn2.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            LBtnPnlPath.AddArc(QuitBtn2.DisplayRectangle.X, QuitBtn2.DisplayRectangle.Y, 50, 50, 180, 90);
            LBtnPnlPath.CloseFigure();
            QuitBtn2.Region = new System.Drawing.Region(LBtnPnlPath);
        }

        private void LBtnPnlPaint2(object? sender, PaintEventArgs e)
        {
            var LBtnPnlPath = new System.Drawing.Drawing2D.GraphicsPath();
            LBtnPnlPath.StartFigure();
            LBtnPnlPath.AddArc(LBtnPnl2.DisplayRectangle.X + LBtnPnl2.DisplayRectangle.Width - 50, LBtnPnl2.DisplayRectangle.Y, 50, 50, 270, 90);
            LBtnPnlPath.AddArc(LBtnPnl2.DisplayRectangle.X + LBtnPnl2.DisplayRectangle.Width - 50, LBtnPnl2.DisplayRectangle.Y + LBtnPnl2.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            LBtnPnlPath.AddArc(LBtnPnl2.DisplayRectangle.X, LBtnPnl2.DisplayRectangle.Y + LBtnPnl2.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            LBtnPnlPath.AddArc(LBtnPnl2.DisplayRectangle.X, LBtnPnl2.DisplayRectangle.Y, 50, 50, 180, 90);
            LBtnPnlPath.CloseFigure();
            LBtnPnl2.Region = new System.Drawing.Region(LBtnPnlPath);
        }

        private void LBtnPaint2(object? sender, PaintEventArgs e)
        {
            var LBtnPath = new System.Drawing.Drawing2D.GraphicsPath();
            LBtnPath.StartFigure();
            LBtnPath.AddArc(LBtn2.DisplayRectangle.X + LBtn2.DisplayRectangle.Width - 50, LBtn2.DisplayRectangle.Y, 50, 50, 270, 90);
            LBtnPath.AddArc(LBtn2.DisplayRectangle.X + LBtn2.DisplayRectangle.Width - 50, LBtn2.DisplayRectangle.Y + LBtn2.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            LBtnPath.AddArc(LBtn2.DisplayRectangle.X, LBtn2.DisplayRectangle.Y + LBtn2.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            LBtnPath.AddArc(LBtn2.DisplayRectangle.X, LBtn2.DisplayRectangle.Y, 50, 50, 180, 90);
            LBtnPath.CloseFigure();
            LBtn2.Region = new System.Drawing.Region(LBtnPath);
        }

        private void LChangeTextBtnPaint2(object? sender, PaintEventArgs e)
        {
            var LBtnPnlPath = new System.Drawing.Drawing2D.GraphicsPath();
            LBtnPnlPath.StartFigure();
            LBtnPnlPath.AddArc(LChangeTextBtn2.DisplayRectangle.X + LChangeTextBtn2.DisplayRectangle.Width - 50, LChangeTextBtn2.DisplayRectangle.Y, 50, 50, 270, 90);
            LBtnPnlPath.AddArc(LChangeTextBtn2.DisplayRectangle.X + LChangeTextBtn2.DisplayRectangle.Width - 50, LChangeTextBtn2.DisplayRectangle.Y + LChangeTextBtn2.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            LBtnPnlPath.AddArc(LChangeTextBtn2.DisplayRectangle.X, LChangeTextBtn2.DisplayRectangle.Y + LChangeTextBtn2.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            LBtnPnlPath.AddArc(LChangeTextBtn2.DisplayRectangle.X, LChangeTextBtn2.DisplayRectangle.Y, 50, 50, 180, 90);
            LBtnPnlPath.CloseFigure();
            LChangeTextBtn2.Region = new System.Drawing.Region(LBtnPnlPath);
        }

        private void LResetBtnPaint2(object? sender, PaintEventArgs e)
        {
            var LBtnPnlPath = new System.Drawing.Drawing2D.GraphicsPath();
            LBtnPnlPath.StartFigure();
            LBtnPnlPath.AddArc(LResetBtn2.DisplayRectangle.X + LResetBtn2.DisplayRectangle.Width - 50, LResetBtn2.DisplayRectangle.Y, 50, 50, 270, 90);
            LBtnPnlPath.AddArc(LResetBtn2.DisplayRectangle.X + LResetBtn2.DisplayRectangle.Width - 50, LResetBtn2.DisplayRectangle.Y + LResetBtn2.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            LBtnPnlPath.AddArc(LResetBtn2.DisplayRectangle.X, LResetBtn2.DisplayRectangle.Y + LResetBtn2.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            LBtnPnlPath.AddArc(LResetBtn2.DisplayRectangle.X, LResetBtn2.DisplayRectangle.Y, 50, 50, 180, 90);
            LBtnPnlPath.CloseFigure();
            LResetBtn2.Region = new System.Drawing.Region(LBtnPnlPath);
        }

        private void RBtnPnlPaint2(object sender, PaintEventArgs e)
        {
            var RBtnPath = new System.Drawing.Drawing2D.GraphicsPath();
            RBtnPath.StartFigure();
            RBtnPath.AddArc(RBtnPnl2.DisplayRectangle.X + RBtnPnl2.DisplayRectangle.Width - 50, RBtnPnl2.DisplayRectangle.Y, 50, 50, 270, 90);
            RBtnPath.AddArc(RBtnPnl2.DisplayRectangle.X + RBtnPnl2.DisplayRectangle.Width - 50, RBtnPnl2.DisplayRectangle.Y + RBtnPnl2.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            RBtnPath.AddArc(RBtnPnl2.DisplayRectangle.X, RBtnPnl2.DisplayRectangle.Y + RBtnPnl2.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            RBtnPath.AddArc(RBtnPnl2.DisplayRectangle.X, RBtnPnl2.DisplayRectangle.Y, 50, 50, 180, 90);
            RBtnPath.CloseFigure();
            RBtnPnl2.Region = new System.Drawing.Region(RBtnPath);
        }

        private void RBtnPaint2(object? sender, PaintEventArgs e)
        {
            var RBtnPath = new System.Drawing.Drawing2D.GraphicsPath();
            RBtnPath.StartFigure();
            RBtnPath.AddArc(RBtn2.DisplayRectangle.X + RBtn2.DisplayRectangle.Width - 50, RBtn2.DisplayRectangle.Y, 50, 50, 270, 90);
            RBtnPath.AddArc(RBtn2.DisplayRectangle.X + RBtn2.DisplayRectangle.Width - 50, RBtn2.DisplayRectangle.Y + RBtn2.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            RBtnPath.AddArc(RBtn2.DisplayRectangle.X, RBtn2.DisplayRectangle.Y + RBtn2.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            RBtnPath.AddArc(RBtn2.DisplayRectangle.X, RBtn2.DisplayRectangle.Y, 50, 50, 180, 90);
            RBtnPath.CloseFigure();
            RBtn2.Region = new System.Drawing.Region(RBtnPath);
        }

        private void RChangeTextBtnPaint2(object? sender, PaintEventArgs e)
        {
            var LBtnPnlPath = new System.Drawing.Drawing2D.GraphicsPath();
            LBtnPnlPath.StartFigure();
            LBtnPnlPath.AddArc(RChangeTextBtn2.DisplayRectangle.X + RChangeTextBtn2.DisplayRectangle.Width - 50, RChangeTextBtn2.DisplayRectangle.Y, 50, 50, 270, 90);
            LBtnPnlPath.AddArc(RChangeTextBtn2.DisplayRectangle.X + RChangeTextBtn2.DisplayRectangle.Width - 50, RChangeTextBtn2.DisplayRectangle.Y + RChangeTextBtn2.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            LBtnPnlPath.AddArc(RChangeTextBtn2.DisplayRectangle.X, RChangeTextBtn2.DisplayRectangle.Y + RChangeTextBtn2.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            LBtnPnlPath.AddArc(RChangeTextBtn2.DisplayRectangle.X, RChangeTextBtn2.DisplayRectangle.Y, 50, 50, 180, 90);
            LBtnPnlPath.CloseFigure();
            RChangeTextBtn2.Region = new System.Drawing.Region(LBtnPnlPath);
        }

        private void RResetBtnPaint2(object? sender, PaintEventArgs e)
        {
            var LBtnPnlPath = new System.Drawing.Drawing2D.GraphicsPath();
            LBtnPnlPath.StartFigure();
            LBtnPnlPath.AddArc(RResetBtn2.DisplayRectangle.X + RResetBtn2.DisplayRectangle.Width - 50, RResetBtn2.DisplayRectangle.Y, 50, 50, 270, 90);
            LBtnPnlPath.AddArc(RResetBtn2.DisplayRectangle.X + RResetBtn2.DisplayRectangle.Width - 50, RResetBtn2.DisplayRectangle.Y + RResetBtn2.DisplayRectangle.Height - 50, 50, 50, 0, 90);
            LBtnPnlPath.AddArc(RResetBtn2.DisplayRectangle.X, RResetBtn2.DisplayRectangle.Y + RResetBtn2.DisplayRectangle.Height - 50, 50, 50, -270, 90);
            LBtnPnlPath.AddArc(RResetBtn2.DisplayRectangle.X, RResetBtn2.DisplayRectangle.Y, 50, 50, 180, 90);
            LBtnPnlPath.CloseFigure();
            RResetBtn2.Region = new System.Drawing.Region(LBtnPnlPath);
        }

        #endregion

    }

    public class ChangeTextForm : Form
    {

    }
    public class Form2 : Form
    {

    }
    public class SettingsForm : Form
    {

    }

}