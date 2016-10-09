//MIT License

//Copyright(c) 2016 Dheeraj Kumar Gunti

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

using System;
using UIKit;
using System.Drawing;
using Foundation;
using CoreAnimation;
using System.Collections.Generic;
using CoreGraphics;

namespace KBPicker
{
    /// <summary>
    /// Alliance picker.
    /// </summary>
    public class Picker : UIViewController
    {
        #region Private Declarations

        private string[] Months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

        private UIView PickerView { get; set; }

        private UIView TransperantView { get; set; }

        private UIView SelectedView { get; set; }

        private UIButton CloseBtn { get; set; }

        private UITableView ItemListTable { get; set; }

        private UILabel LblTitle { get; set; }

        private float TableHeight { get; set; }

        private float ViewHeight { get; set; }

        private UITextView PlainTextView { get; set; }

        private UIView DateView { get; set; }

        private UIView MonthView { get; set; }

        private UIView YearView { get; set; }

        private UIView HourView { get; set; }

        private UIView MinuteView { get; set; }

        private UIView MeridianView { get; set; }

        private UIButton DatePlus { get; set; }

        private UIButton DateMinus { get; set; }

        private UIButton MonthPlus { get; set; }

        private UIButton MonthMinus { get; set; }

        private UIButton YearPlus { get; set; }

        private UIButton YearMinus { get; set; }

        private UILabel DateLabel { get; set; }

        private UILabel MonthLabel { get; set; }

        private UILabel YearLabel { get; set; }

        private UILabel HourLabel { get; set; }

        private UILabel MinuteLabel { get; set; }

        private UILabel MeridianLabel { get; set; }

        private UIButton HourPlus { get; set; }

        private UIButton HourMinus { get; set; }

        private UIButton MinutePlus { get; set; }

        private UIButton MinuteMinus { get; set; }

        private UIButton MeridianPlus { get; set; }

        private UIButton MeridianMinus { get; set; }

        private UIButton ChooseDateButton { get; set; }

        private UILabel LblNodataMessage { get; set; }

        private UIImageView LoginImageView { get; set; }

        private UIImageView LoginUserName { get; set; }

        private UIImageView LoginPassword { get; set; }

        private UITextField LoginName { get; set; }

        private UITextField LoginPass { get; set; }

        private UIView seperator1 { get; set; }

        private UIView seperator2 { get; set; }

        #endregion

        #region Public Declarations

        /// <summary>
        /// List Items
        /// </summary>
        /// <value>The plain picker items.</value>
        public List<string> PlainPickerItems { get; set; }

        /// <summary>
        /// Source Text Field To Show the Value
        /// </summary>
        /// <value>The source field.</value>
        public UITextField SourceField { get; set; }

        /// <summary>
        /// Header Title
        /// </summary>
        /// <value>The header title.</value>
        public string HeaderTitle { get; set; }

        /// <summary>
        /// Type of Picker - Date, List, Time, Plain
        /// </summary>
        /// <value>The type.</value>
        public PickerType Type { get; set; }

        /// <summary>
        /// Date Format - DMY, MDY, YDM, YMD
        /// </summary>
        /// <value>The date format.</value>
        public SelectDateFormat DateFormat { get; set; }

        /// <summary>
        /// Plain Text
        /// </summary>
        /// <value>The plain description.</value>
        public string PlainDescription { get; set; }

        /// <summary>
        /// Date Separator
        /// </summary>
        /// <value>The seperator.</value>
        public string Seperator { get; set; }

        /// <summary>
        /// Is Full Month Required
        /// </summary>
        /// <value><c>true</c> if this instance is full month required; otherwise, <c>false</c>.</value>
        public bool IsFullMonthRequired { get; set; }

        /// <summary>
        /// Login Click Event Handler
        /// </summary>
        public event EventHandler<EventArgs> LoginClicked;

        /// <summary>
        /// Sets the Login Button Value
        /// </summary>
        /// <value>The login name string.</value>
        public string LoginNameString { get; set; }

        /// <summary>
        /// Max Length for User Name
        /// </summary>
        /// <value>The length of the user name max.</value>
        public int UserNameMaxLength { get; set; }

        /// <summary>
        /// Max Length for Password
        /// </summary>
        /// <value>The length of the password max.</value>
        public int PasswordMaxLength { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }

        /// <summary>
        /// Border Color for Date, Time, DateTime controls 
        /// </summary>
        /// <value>The color of the border.</value>
        public CGColor BorderColor { get; set; }

        /// <summary>
        /// Background Color for Date, Time, DateTime controls
        /// </summary>
        /// <value>The color of the backgrond.</value>
        public UIColor BackgrondColor { get; set; }

        /// <summary>
        /// Background color for Choose Date, Time and DateTime
        /// </summary>
        /// <value>The color of the choo button.</value>
        public UIColor ChooseButtonColor { get; set; }

        /// <summary>
        /// Color for Plus and Minus 
        /// </summary>
        /// <value>The color of the plus minus.</value>
        public UIColor PlusMinusColor { get; set; }

        /// <summary>
        /// Background color for Picker
        /// </summary>
        /// <value>The color of the picker.</value>
        public UIColor PickerColor { get; set; }

        /// <summary>
        /// Text Color for List Picker
        /// </summary>
        /// <value>The color of the list text.</value>
        public UIColor ListTextColor { get; set; }

        /// <summary>
        /// Title Color for Picker
        /// </summary>
        /// <value>The color of the picker title.</value>
        public UIColor PickerTitleColor { get; set; }

        /// <summary>
        /// Font for Picker 
        /// </summary>
        /// <value>The picker font.</value>
        public UIFont PickerFont { get; set; }

        #endregion

        public Picker(UIViewController CurrentView)
        {
            SelectedView = CurrentView.View;
        }

        public void Show()
        {
            //Applying default color if no color specified.
            if (BorderColor == null)
            {
                BorderColor = (UIColor.FromRGB(65, 145, 215)).CGColor;
            }

            //Applying default color if no color specified.
            if (BackgrondColor == null)
            {
                BackgrondColor = UIColor.FromRGB(65, 145, 215);
            }

            if (PlusMinusColor == null)
            {
                PlusMinusColor = UIColor.White;
            }

            if (PickerColor == null)
            {
                PickerColor = UIColor.White;
            }

            if (Type == PickerType.List)
            {
                ListPicker();
            }
            else if (Type == PickerType.Date)
            {
                DatePicker();
            }
            else if (Type == PickerType.Time)
            {
                TimePicker();
            }
            else if (Type == PickerType.Plain)
            {
                PlainPicker();
            }
            else if (Type == PickerType.Login)
            {
                Login();
            }
            else if (Type == PickerType.DateTime)
            {
                DateTimePicker();
            }
        }

        public void Hide()
        {
            var transition = CATransition.CreateAnimation();
            transition.Duration = 0.25;
            transition.Speed = 1f;
            transition.Type = CATransition.TransitionPush;
            transition.Subtype = CATransition.TransitionFromTop;
            PickerView.Layer.AddAnimation(transition, "slide");
            PickerView.Layer.RemoveAnimation("slide");
            PickerView.Hidden = true;
            TransperantView.Hidden = true;
        }

        void Login()
        {
            ViewHeight = 250;
            CreateLayout();
            CreateTransition();
            CreateControls();
            LoginImageView = new UIImageView(UIImage.FromFile("loginImage.png"));
            LoginImageView.Frame = new CGRect((PickerView.Frame.Width) / 2 - 25, 12, 60, 60);
            LoginUserName = new UIImageView(UIImage.FromFile("1393098673_Unknown_person.png"));
            LoginUserName.Frame = new CGRect(5, 0, 24, 24);
            LoginPassword = new UIImageView(UIImage.FromFile("1393098701_login.png"));
            LoginPassword.Frame = new CGRect(5, 0, 24, 24);
            LoginName = new UITextField(new CGRect(20, 90, 250, 35));
            LoginName.ShouldReturn = (t) =>
            {
                if (string.IsNullOrWhiteSpace(LoginName.Text))
                {
                    seperator1.BackgroundColor = UIColor.Red;
                    LoginUserName.Image = UIImage.FromFile("person_error.png");
                }
                else
                {
                    seperator1.BackgroundColor = UIColor.LightGray;
                    LoginUserName.Image = UIImage.FromFile("person.png");
                }
                LoginName.EndEditing(true);
                return true;
            };
            LoginName.BorderStyle = UITextBorderStyle.None;
            LoginName.Placeholder = "Login Name";
            LoginName.RightView = LoginUserName;
            LoginName.AutocapitalizationType = UITextAutocapitalizationType.None;
            LoginName.RightViewMode = UITextFieldViewMode.Always;
            LoginPass = new UITextField(new CGRect(20, 130, 250, 35));
            LoginPass.ShouldReturn = (t) =>
            {
                if (string.IsNullOrWhiteSpace(LoginPass.Text))
                {
                    seperator2.BackgroundColor = UIColor.Red;
                    LoginPassword.Image = UIImage.FromFile("login_error.png");
                }
                else
                {
                    seperator2.BackgroundColor = UIColor.LightGray;
                    LoginPassword.Image = UIImage.FromFile("login.png");
                }
                LoginPass.EndEditing(true);
                return true;
            };
            LoginPass.BorderStyle = UITextBorderStyle.None;
            LoginPass.SecureTextEntry = true;
            LoginPass.Placeholder = "Password";
            LoginPass.RightView = LoginPassword;
            LoginPass.RightViewMode = UITextFieldViewMode.Always;
            if (PickerFont == null)
            {
                LoginName.Font = UIFont.FromName("GillSans", 13);
                LoginPass.Font = UIFont.FromName("GillSans", 13);
            }
            else
            {
                LoginName.Font = PickerFont;
                LoginName.Font.WithSize(13);
                LoginPass.Font = PickerFont;
                LoginPass.Font.WithSize(13);
            }
            seperator1 = new UIView(new CGRect(20, 127, 250, 1));
            seperator1.BackgroundColor = UIColor.LightGray;
            seperator2 = new UIView(new CGRect(20, 167, 250, 1));
            seperator2.BackgroundColor = UIColor.LightGray;
            ChooseDateButton = new UIButton();
            if (!string.IsNullOrWhiteSpace(LoginNameString))
            {
                ChooseDateButton.SetTitle(LoginNameString, UIControlState.Normal);
            }
            else
            {
                ChooseDateButton.SetTitle("Login", UIControlState.Normal);
            }
            ChooseDateButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            if (PickerFont == null)
            {
                ChooseDateButton.Font = UIFont.FromName("GillSans", 15);
            }
            else
            {
                ChooseDateButton.Font = PickerFont;
                ChooseDateButton.Font.WithSize(14);
            }
            ChooseDateButton.Frame = new CGRect(20, 180, 250, 40);
            if (ChooseButtonColor == null)
            {
                ChooseDateButton.SetBackgroundImage(UIImage.FromFile("btn.png"), UIControlState.Normal);
            }
            else
            {
                ChooseDateButton.BackgroundColor = ChooseButtonColor;
            }
            ChooseDateButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (string.IsNullOrWhiteSpace(LoginName.Text))
                {
                    seperator1.BackgroundColor = UIColor.Red;
                    LoginUserName.Image = UIImage.FromFile("person_error.png");
                }
                else
                {
                    seperator1.BackgroundColor = UIColor.LightGray;
                    LoginUserName.Image = UIImage.FromFile("person.png");
                }

                if (string.IsNullOrWhiteSpace(LoginPass.Text))
                {
                    seperator2.BackgroundColor = UIColor.Red;
                    LoginPassword.Image = UIImage.FromFile("login_error.png");
                }
                else
                {
                    seperator2.BackgroundColor = UIColor.LightGray;
                    LoginPassword.Image = UIImage.FromFile("login.png");
                }

                if (!string.IsNullOrWhiteSpace(LoginName.Text) && !string.IsNullOrWhiteSpace(LoginPass.Text))
                {
                    UserName = LoginName.Text.Trim();
                    Password = LoginPass.Text.Trim();
                    if (this.LoginClicked != null)
                    {
                        this.LoginClicked(this, new EventArgs());
                    }
                    Hide();
                }
            };

            LoginName.ShouldChangeCharacters = (textField, range, replacement) =>
            {
                var newLength = textField.Text.Length + replacement.Length - range.Length;
                return newLength <= UserNameMaxLength;
            };

            LoginPass.ShouldChangeCharacters = (textField, range, replacement) =>
            {
                var newLength = textField.Text.Length + replacement.Length - range.Length;
                return newLength <= PasswordMaxLength;
            };

            PickerView.AddSubview(seperator1);
            PickerView.AddSubview(seperator2);
            PickerView.AddSubview(ChooseDateButton);
            PickerView.AddSubview(LoginName);
            PickerView.AddSubview(LoginPass);
            PickerView.AddSubview(LoginImageView);
            PickerView.AddSubview(LblTitle);
            PickerView.AddSubview(CloseBtn);
            LblTitle.Text = string.Empty;
            PickerView.Frame = new CGRect((SelectedView.Bounds.Width - 290) / 2, (SelectedView.Bounds.Height / 2) - 150,
                290, ViewHeight);
            SelectedView.AddSubview(TransperantView);
            SelectedView.AddSubview(PickerView);
        }

        void ListPicker()
        {
            if (SourceField != null)
            {
                SourceField.Enabled = false;
            }
            if (PlainPickerItems != null)
            {
                TableHeight = (PlainPickerItems.Count * 30) + 10;
            }
            else
            {
                TableHeight = 100;
                ViewHeight = 250;
            }

            if (TableHeight > 250)
            {
                ViewHeight = 250;
            }
            else
            {
                ViewHeight = TableHeight + 60;
            }
            CreateLayout();
            CreateTransition();
            CreateControls();
            CreateList(SourceField);
            PickerView.AddSubview(LblTitle);
            PickerView.AddSubview(CloseBtn);
            SelectedView.AddSubview(TransperantView);
            PickerView.AddSubview(ItemListTable);
            SelectedView.AddSubview(PickerView);
        }

        void DateTimePicker()
        {
            if (SourceField != null)
            {
                SourceField.Enabled = false;
            }
            DateTime currentDateTime = DateTime.Now;
            ViewHeight = 350;
            CreateLayout();
            CreateTransition();
            CreateControls();
            var frame = PickerView.Frame;
            frame.Y = 100;
            PickerView.Frame = frame;

            DateView = new UIView(new CGRect(30, 50, 65, 102));
            DateView.Layer.BorderColor = BorderColor;
            DateView.Layer.BorderWidth = 1f;
            MonthView = new UIView(new CGRect(100, 50, 80, 102));
            MonthView.Layer.BorderColor = BorderColor;
            MonthView.Layer.BorderWidth = 1f;
            YearView = new UIView(new CGRect(185, 50, 73, 102));
            YearView.Layer.BorderColor = BorderColor;
            YearView.Layer.BorderWidth = 1f;
            //Controls
            DatePlus = new UIButton(new CGRect(0, 0, 65, 30));
            DatePlus.BackgroundColor = BackgrondColor;
            DatePlus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            DatePlus.SetTitle("+", UIControlState.Normal);
            DateMinus = new UIButton(new CGRect(0, 72, 65, 30));
            DateMinus.BackgroundColor = BackgrondColor;
            DateMinus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            DateMinus.SetTitle("-", UIControlState.Normal);
            MonthPlus = new UIButton(new CGRect(0, 0, 80, 30));
            MonthPlus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            MonthPlus.BackgroundColor = BackgrondColor;
            MonthPlus.SetTitle("+", UIControlState.Normal);
            MonthMinus = new UIButton(new CGRect(0, 72, 80, 30));
            MonthMinus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            MonthMinus.BackgroundColor = BackgrondColor;
            MonthMinus.SetTitle("-", UIControlState.Normal);
            YearPlus = new UIButton(new CGRect(0, 0, 73, 30));
            YearPlus.BackgroundColor = BackgrondColor;
            YearPlus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            YearPlus.SetTitle("+", UIControlState.Normal);
            YearMinus = new UIButton(new CGRect(0, 72, 73, 30));
            YearMinus.BackgroundColor = BackgrondColor;
            YearMinus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            YearMinus.SetTitle("-", UIControlState.Normal);

            HourView = new UIView(new CGRect(40, DateView.Frame.Y + DateView.Frame.Height + 10, 65, 102));
            HourView.Layer.BorderColor = BorderColor;
            HourView.Layer.BorderWidth = 1f;
            MinuteView = new UIView(new CGRect(110, DateView.Frame.Y + DateView.Frame.Height + 10, 65, 102));
            MinuteView.Layer.BorderColor = BorderColor;
            MinuteView.Layer.BorderWidth = 1f;
            MeridianView = new UIView(new CGRect(180, DateView.Frame.Y + DateView.Frame.Height + 10, 65, 102));
            MeridianView.Layer.BorderColor = BorderColor;
            MeridianView.Layer.BorderWidth = 1f;
            if (string.IsNullOrWhiteSpace(Seperator))
            {
                Seperator = ":";
            }
            //Controls
            HourPlus = new UIButton(new CGRect(0, 0, 65, 30));
            HourPlus.BackgroundColor = BackgrondColor;
            HourPlus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            HourPlus.SetTitle("+", UIControlState.Normal);
            HourMinus = new UIButton(new CGRect(0, 72, 65, 30));
            HourMinus.BackgroundColor = BackgrondColor;
            HourMinus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            HourMinus.SetTitle("-", UIControlState.Normal);
            MinutePlus = new UIButton(new CGRect(0, 0, 65, 30));
            MinutePlus.BackgroundColor = BackgrondColor;
            MinutePlus.SetTitle("+", UIControlState.Normal);
            MinutePlus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            MinuteMinus = new UIButton(new CGRect(0, 72, 65, 30));
            MinuteMinus.BackgroundColor = BackgrondColor;
            MinuteMinus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            MinuteMinus.SetTitle("-", UIControlState.Normal);
            MeridianPlus = new UIButton(new CGRect(0, 0, 65, 30));
            MeridianPlus.BackgroundColor = BackgrondColor;
            MeridianPlus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            MeridianPlus.SetTitle("+", UIControlState.Normal);
            MeridianMinus = new UIButton(new CGRect(0, 72, 65, 30));
            MeridianMinus.BackgroundColor = BackgrondColor;
            MeridianMinus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            MeridianMinus.SetTitle("-", UIControlState.Normal);

            ChooseDateButton = new UIButton();
            ChooseDateButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            ChooseDateButton.Frame = new CGRect(30, MinuteView.Frame.Y + MinuteView.Frame.Height + 10, 230, 45);
            if (PickerFont == null)
            {
                ChooseDateButton.Font = UIFont.FromName("GillSans", 15);
            }
            else
            {
                ChooseDateButton.Font = PickerFont;
                ChooseDateButton.Font.WithSize(14);
            }
            if (ChooseButtonColor == null)
            {
                ChooseDateButton.SetBackgroundImage(UIImage.FromFile("btn.png"), UIControlState.Normal);
            }
            else
            {
                ChooseDateButton.BackgroundColor = ChooseButtonColor;
            }
            ChooseDateButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (SourceField != null)
                {
                    SourceField.Enabled = true;
                    SourceField.Text = ChooseDateButton.Title(UIControlState.Normal).ToString().Replace("Select Date", "").Trim();
                    Hide();
                }
            };
            //Labels
            DateLabel = new UILabel(new CGRect(0, 32, 64, 40));
            DateLabel.TextAlignment = UITextAlignment.Center;
            DateLabel.TextColor = UIColor.Black;
            DateLabel.Font = UIFont.BoldSystemFontOfSize(17);
            MonthLabel = new UILabel(new CGRect(0, 32, 78, 40));
            MonthLabel.TextColor = UIColor.Black;
            MonthLabel.Font = UIFont.BoldSystemFontOfSize(17);
            MonthLabel.TextAlignment = UITextAlignment.Center;
            YearLabel = new UILabel(new CGRect(0, 32, 72, 40));
            YearLabel.TextColor = UIColor.Black;
            YearLabel.Font = UIFont.BoldSystemFontOfSize(17);
            YearLabel.TextAlignment = UITextAlignment.Center;
            DateView.Layer.CornerRadius = 1;
            MonthView.Layer.CornerRadius = 1;
            YearView.Layer.CornerRadius = 1;
            DateView.BackgroundColor = UIColor.White;
            MonthView.BackgroundColor = UIColor.White;
            YearView.BackgroundColor = UIColor.White;
            DateTime currentDate = DateTime.Now;
            if (string.IsNullOrWhiteSpace(Seperator))
            {
                Seperator = "/";
            }
            //Touch Events
            DateLabel.Text = currentDate.Day.ToString();
            DatePlus.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (Convert.ToInt32(DateLabel.Text) < 31)
                {
                    DateLabel.Text = Convert.ToString(Convert.ToInt32(DateLabel.Text) + 1);
                    ChooseDateButton.SetTitle(SelectedDateFormat(DateLabel, MonthLabel, YearLabel, Seperator)
                    + " " + HourLabel.Text + ":" + MinuteLabel.Text + " " + MeridianLabel.Text, UIControlState.Normal);
                }
            };

            DateMinus.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (Convert.ToInt32(DateLabel.Text) > 1)
                {
                    DateLabel.Text = Convert.ToString(Convert.ToInt32(DateLabel.Text) - 1);
                    ChooseDateButton.SetTitle(SelectedDateFormat(DateLabel, MonthLabel, YearLabel, Seperator)
                    + " " + HourLabel.Text + ":" + MinuteLabel.Text + " " + MeridianLabel.Text, UIControlState.Normal);
                }
            };

            var value = Months.GetValue(currentDate.Month - 1);
            MonthLabel.Text = value.ToString();
            int i = Array.FindIndex(Months, row => row.Equals(MonthLabel.Text));
            MonthPlus.TouchUpInside += (object sender, EventArgs e) =>
            {
                i = Array.FindIndex(Months, row => row.Equals(MonthLabel.Text));
                if (i < 11)
                {
                    i++;
                    MonthLabel.Text = Months[i];
                    ChooseDateButton.SetTitle(SelectedDateFormat(DateLabel, MonthLabel, YearLabel, Seperator)
                    + " " + HourLabel.Text + ":" + MinuteLabel.Text + " " + MeridianLabel.Text, UIControlState.Normal);
                }
            };

            MonthMinus.TouchUpInside += (object sender, EventArgs e) =>
            {
                int j = Array.FindIndex(Months, row => row.Equals(MonthLabel.Text));
                if (j > 0)
                {
                    j--;
                    MonthLabel.Text = Months[j];
                    ChooseDateButton.SetTitle(SelectedDateFormat(DateLabel, MonthLabel, YearLabel, Seperator)
                    + "  " + HourLabel.Text + ":" + MinuteLabel.Text + " " + MeridianLabel.Text, UIControlState.Normal);
                }
            };

            int ii = 2100;
            YearLabel.Text = currentDate.Year.ToString();
            YearPlus.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (Convert.ToInt32(YearLabel.Text) < ii)
                {
                    YearLabel.Text = Convert.ToString(Convert.ToInt32(YearLabel.Text) + 1);
                    ChooseDateButton.SetTitle(SelectedDateFormat(DateLabel, MonthLabel, YearLabel, Seperator)
                    + " " + HourLabel.Text + ":" + MinuteLabel.Text + " " + MeridianLabel.Text, UIControlState.Normal);
                }
            };

            int jj = 1900;
            YearMinus.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (Convert.ToInt32(YearLabel.Text) > jj)
                {
                    YearLabel.Text = Convert.ToString(Convert.ToInt32(YearLabel.Text) - 1);
                    ChooseDateButton.SetTitle(SelectedDateFormat(DateLabel, MonthLabel, YearLabel, Seperator)
                    + " " + HourLabel.Text + ":" + MinuteLabel.Text + " " + MeridianLabel.Text, UIControlState.Normal);
                }
            };

            //Labels
            HourLabel = new UILabel(new CGRect(0, 32, 64, 40));
            HourLabel.TextAlignment = UITextAlignment.Center;
            HourLabel.TextColor = UIColor.Black;
            HourLabel.Font = UIFont.BoldSystemFontOfSize(17);
            HourLabel.Text = currentDateTime.ToString("hh");
            HourPlus.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (Convert.ToInt32(HourLabel.Text) >= 0 && Convert.ToInt32(HourLabel.Text) < 11)
                {
                    HourLabel.Text = Convert.ToString(Convert.ToInt32(HourLabel.Text) + 1);
                    if (HourLabel.Text.Length == 1)
                    {
                        HourLabel.Text = "0" + HourLabel.Text;
                    }
                }
                else
                {
                    HourLabel.Text = "00";
                    MeridianLabel.Text = MeridianLabel.Text == "AM" ? "PM" : "AM";
                }
                ChooseDateButton.SetTitle(SelectedDateFormat(DateLabel, MonthLabel, YearLabel, Seperator)
                + " " + HourLabel.Text + ":" + MinuteLabel.Text + " " + MeridianLabel.Text, UIControlState.Normal);
            };
            HourMinus.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (Convert.ToInt32(HourLabel.Text) > 0 && Convert.ToInt32(HourLabel.Text) <= 11)
                {
                    HourLabel.Text = Convert.ToString(Convert.ToInt32(HourLabel.Text) - 1);
                    if (HourLabel.Text.Length == 1)
                    {
                        HourLabel.Text = "0" + HourLabel.Text;
                    }
                }
                else
                {
                    HourLabel.Text = "11";
                    MeridianLabel.Text = MeridianLabel.Text == "AM" ? "PM" : "AM";
                }
                ChooseDateButton.SetTitle(SelectedDateFormat(DateLabel, MonthLabel, YearLabel, Seperator)
                + "  " + HourLabel.Text + ":" + MinuteLabel.Text + " " + MeridianLabel.Text, UIControlState.Normal);
            };

            MinuteLabel = new UILabel(new CGRect(0, 32, 64, 40));
            MinuteLabel.TextColor = UIColor.Black;
            MinuteLabel.Font = UIFont.BoldSystemFontOfSize(17);
            MinuteLabel.TextAlignment = UITextAlignment.Center;
            MinuteLabel.Text = currentDateTime.ToString("mm");
            MinutePlus.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (Convert.ToInt32(MinuteLabel.Text) >= 0 && Convert.ToInt32(MinuteLabel.Text) < 59)
                {
                    MinuteLabel.Text = Convert.ToString(Convert.ToInt32(MinuteLabel.Text) + 1);
                    if (MinuteLabel.Text.Length == 1)
                    {
                        MinuteLabel.Text = "0" + MinuteLabel.Text;
                    }
                }
                else
                {
                    MinuteLabel.Text = "00";
                    if (Convert.ToInt32(HourLabel.Text) >= 0 && Convert.ToInt32(HourLabel.Text) < 11)
                    {
                        HourLabel.Text = Convert.ToString(Convert.ToInt32(HourLabel.Text) + 1);
                        if (HourLabel.Text.Length == 1)
                        {
                            HourLabel.Text = "0" + HourLabel.Text;
                        }
                    }
                    else
                    {
                        HourLabel.Text = "00";
                        MeridianLabel.Text = MeridianLabel.Text == "AM" ? "PM" : "AM";
                    }
                }
                ChooseDateButton.SetTitle(SelectedDateFormat(DateLabel, MonthLabel, YearLabel, Seperator)
                + " " + HourLabel.Text + ":" + MinuteLabel.Text + " " + MeridianLabel.Text, UIControlState.Normal);
            };
            MinuteMinus.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (Convert.ToInt32(MinuteLabel.Text) > 0 && Convert.ToInt32(MinuteLabel.Text) <= 59)
                {
                    MinuteLabel.Text = Convert.ToString(Convert.ToInt32(MinuteLabel.Text) - 1);
                    if (MinuteLabel.Text.Length == 1)
                    {
                        MinuteLabel.Text = "0" + MinuteLabel.Text;
                    }
                }
                else
                {
                    MinuteLabel.Text = "59";
                    if (Convert.ToInt32(HourLabel.Text) > 0 && Convert.ToInt32(HourLabel.Text) <= 11)
                    {
                        HourLabel.Text = Convert.ToString(Convert.ToInt32(HourLabel.Text) - 1);
                        if (HourLabel.Text.Length == 1)
                        {
                            HourLabel.Text = "0" + HourLabel.Text;
                        }
                    }
                    else
                    {
                        HourLabel.Text = "11";
                        MeridianLabel.Text = MeridianLabel.Text == "AM" ? "PM" : "AM";
                    }
                }
                ChooseDateButton.SetTitle(SelectedDateFormat(DateLabel, MonthLabel, YearLabel, Seperator)
                + "  " + HourLabel.Text + ":" + MinuteLabel.Text + " " + MeridianLabel.Text, UIControlState.Normal);
            };

            MeridianLabel = new UILabel(new CGRect(0, 32, 64, 40));
            MeridianLabel.TextColor = UIColor.Black;
            MeridianLabel.Font = UIFont.BoldSystemFontOfSize(17);
            MeridianLabel.TextAlignment = UITextAlignment.Center;
            MeridianLabel.Text = currentDateTime.ToString("tt");
            MeridianPlus.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (MeridianLabel.Text.Equals("PM"))
                {
                    MeridianLabel.Text = "AM";
                }
                else
                {
                    MeridianLabel.Text = "PM";
                }
                ChooseDateButton.SetTitle(SelectedDateFormat(DateLabel, MonthLabel, YearLabel, Seperator)
                + "  " + HourLabel.Text + ":" + MinuteLabel.Text + " " + MeridianLabel.Text, UIControlState.Normal);
            };
            MeridianMinus.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (MeridianLabel.Text.Equals("PM"))
                {
                    MeridianLabel.Text = "AM";
                }
                else
                {
                    MeridianLabel.Text = "PM";
                }
                ChooseDateButton.SetTitle(SelectedDateFormat(DateLabel, MonthLabel, YearLabel, Seperator)
                + "  " + HourLabel.Text + ":" + MinuteLabel.Text + " " + MeridianLabel.Text, UIControlState.Normal);
            };

            ChooseDateButton.SetTitle(SelectedDateFormat(DateLabel, MonthLabel, YearLabel, Seperator)
            + "  " + HourLabel.Text + ":" + MinuteLabel.Text + " " + MeridianLabel.Text, UIControlState.Normal);

            //Date Control
            DateView.AddSubview(DatePlus);
            DateView.AddSubview(DateMinus);
            DateView.AddSubview(DateLabel);
            MonthView.AddSubview(MonthPlus);
            MonthView.AddSubview(MonthMinus);
            MonthView.AddSubview(MonthLabel);
            YearView.AddSubview(YearPlus);
            YearView.AddSubview(YearMinus);
            YearView.AddSubview(YearLabel);
            //Time Control
            HourView.AddSubview(HourPlus);
            HourView.AddSubview(HourMinus);
            HourView.AddSubview(HourLabel);
            MinuteView.AddSubview(MinutePlus);
            MinuteView.AddSubview(MinuteMinus);
            MinuteView.AddSubview(MinuteLabel);
            MeridianView.AddSubview(MeridianPlus);
            MeridianView.AddSubview(MeridianMinus);
            MeridianView.AddSubview(MeridianLabel);

            PickerView.AddSubview(DateView);
            PickerView.AddSubview(MonthView);
            PickerView.AddSubview(YearView);

            PickerView.AddSubview(HourView);
            PickerView.AddSubview(MinuteView);
            PickerView.AddSubview(MeridianView);

            PickerView.AddSubview(ChooseDateButton);
            PickerView.AddSubview(LblTitle);
            PickerView.AddSubview(CloseBtn);
            SelectedView.AddSubview(TransperantView);
            SelectedView.AddSubview(PickerView);
        }

        void TimePicker()
        {
            if (SourceField != null)
            {
                SourceField.Enabled = false;
            }
            DateTime currentDateTime = DateTime.Now;
            ViewHeight = 220;
            CreateLayout();
            CreateTransition();
            CreateControls();
            DateView = new UIView(new CGRect(40, 50, 65, 102));
            DateView.Layer.BorderColor = BorderColor;
            DateView.Layer.BorderWidth = 1f;
            MonthView = new UIView(new CGRect(110, 50, 65, 102));
            MonthView.Layer.BorderColor = BorderColor;
            MonthView.Layer.BorderWidth = 1f;
            YearView = new UIView(new CGRect(180, 50, 65, 102));
            YearView.Layer.BorderColor = BorderColor;
            YearView.Layer.BorderWidth = 1f;
            if (string.IsNullOrWhiteSpace(Seperator))
            {
                Seperator = ":";
            }
            //Controls
            DatePlus = new UIButton(new CGRect(0, 0, 65, 30));
            DatePlus.BackgroundColor = BackgrondColor;
            DatePlus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            DatePlus.SetTitle("+", UIControlState.Normal);
            DateMinus = new UIButton(new CGRect(0, 72, 65, 30));
            DateMinus.BackgroundColor = BackgrondColor;
            DateMinus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            DateMinus.SetTitle("-", UIControlState.Normal);
            MonthPlus = new UIButton(new CGRect(0, 0, 65, 30));
            MonthPlus.BackgroundColor = BackgrondColor;
            MonthPlus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            MonthPlus.SetTitle("+", UIControlState.Normal);
            MonthMinus = new UIButton(new CGRect(0, 72, 65, 30));
            MonthMinus.BackgroundColor = BackgrondColor;
            MonthMinus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            MonthMinus.SetTitle("-", UIControlState.Normal);
            YearPlus = new UIButton(new CGRect(0, 0, 65, 30));
            YearPlus.BackgroundColor = BackgrondColor;
            YearPlus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            YearPlus.SetTitle("+", UIControlState.Normal);
            YearMinus = new UIButton(new CGRect(0, 72, 65, 30));
            YearMinus.BackgroundColor = BackgrondColor;
            YearMinus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            YearMinus.SetTitle("-", UIControlState.Normal);
            ChooseDateButton = new UIButton();
            ChooseDateButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            ChooseDateButton.Frame = new CGRect(40, 160, 208, 40);
            if (PickerFont == null)
            {
                ChooseDateButton.Font = UIFont.FromName("GillSans", 15);
            }
            else
            {
                ChooseDateButton.Font = PickerFont;
                ChooseDateButton.Font.WithSize(14);
            }
            if (ChooseButtonColor == null)
            {
                ChooseDateButton.SetBackgroundImage(UIImage.FromFile("btn.png"), UIControlState.Normal);
            }
            else
            {
                ChooseDateButton.BackgroundColor = ChooseButtonColor;
            }
            ChooseDateButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (SourceField != null)
                {
                    SourceField.Enabled = true;
                    SourceField.Text = ChooseDateButton.Title(UIControlState.Normal).ToString().Replace("Select Time", "").Trim();
                    Hide();
                }
            };
            //Labels
            DateLabel = new UILabel(new CGRect(0, 32, 64, 40));
            DateLabel.TextAlignment = UITextAlignment.Center;
            DateLabel.TextColor = UIColor.Black;
            DateLabel.Font = UIFont.BoldSystemFontOfSize(17);
            DateLabel.Text = currentDateTime.ToString("hh");
            DatePlus.TouchUpInside += (object sender, EventArgs e) =>
            {
                DatePlusMethod();
                ChooseDateButton.SetTitle("Select Time    " + DateLabel.Text + Seperator + MonthLabel.Text + " " + YearLabel.Text, UIControlState.Normal);
            };
            DateMinus.TouchUpInside += (object sender, EventArgs e) =>
            {
                DateMinusMethod();
                ChooseDateButton.SetTitle("Select Time    " + DateLabel.Text + Seperator + MonthLabel.Text + " " + YearLabel.Text, UIControlState.Normal);
            };

            MonthLabel = new UILabel(new CGRect(0, 32, 64, 40));
            MonthLabel.TextColor = UIColor.Black;
            MonthLabel.Font = UIFont.BoldSystemFontOfSize(17);
            MonthLabel.TextAlignment = UITextAlignment.Center;
            MonthLabel.Text = currentDateTime.ToString("mm");
            MonthPlus.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (Convert.ToInt32(MonthLabel.Text) >= 0 && Convert.ToInt32(MonthLabel.Text) < 59)
                {
                    MonthLabel.Text = Convert.ToString(Convert.ToInt32(MonthLabel.Text) + 1);
                    if (MonthLabel.Text.Length == 1)
                    {
                        MonthLabel.Text = "0" + MonthLabel.Text;
                    }
                }
                else
                {
                    MonthLabel.Text = "00";
                    DatePlusMethod();
                }
                ChooseDateButton.SetTitle("Select Time   " + DateLabel.Text + Seperator + MonthLabel.Text + " " + YearLabel.Text, UIControlState.Normal);
            };
            MonthMinus.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (Convert.ToInt32(MonthLabel.Text) > 0 && Convert.ToInt32(MonthLabel.Text) <= 59)
                {
                    MonthLabel.Text = Convert.ToString(Convert.ToInt32(MonthLabel.Text) - 1);
                    if (MonthLabel.Text.Length == 1)
                    {
                        MonthLabel.Text = "0" + MonthLabel.Text;
                    }
                }
                else
                {
                    MonthLabel.Text = "59";
                    DateMinusMethod();
                }
                ChooseDateButton.SetTitle("Select Time   " + DateLabel.Text + Seperator + MonthLabel.Text + " " + YearLabel.Text, UIControlState.Normal);
            };

            YearLabel = new UILabel(new CGRect(0, 32, 64, 40));
            YearLabel.TextColor = UIColor.Black;
            YearLabel.Font = UIFont.BoldSystemFontOfSize(17);
            YearLabel.TextAlignment = UITextAlignment.Center;
            YearLabel.Text = currentDateTime.ToString("tt");
            YearPlus.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (YearLabel.Text.Equals("PM"))
                {
                    YearLabel.Text = "AM";
                }
                else
                {
                    YearLabel.Text = "PM";
                }
                ChooseDateButton.SetTitle("Select Time    " + DateLabel.Text + Seperator + MonthLabel.Text + " " + YearLabel.Text, UIControlState.Normal);
            };
            YearMinus.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (YearLabel.Text.Equals("PM"))
                {
                    YearLabel.Text = "AM";
                }
                else
                {
                    YearLabel.Text = "PM";
                }
                ChooseDateButton.SetTitle("Select Time    " + DateLabel.Text + Seperator + MonthLabel.Text + " " + YearLabel.Text, UIControlState.Normal);
            };

            ChooseDateButton.SetTitle("Select Time    " + DateLabel.Text + Seperator + MonthLabel.Text + " " + YearLabel.Text, UIControlState.Normal);
            DateView.AddSubview(DatePlus);
            DateView.AddSubview(DateMinus);
            DateView.AddSubview(DateLabel);
            MonthView.AddSubview(MonthPlus);
            MonthView.AddSubview(MonthMinus);
            MonthView.AddSubview(MonthLabel);
            YearView.AddSubview(YearPlus);
            YearView.AddSubview(YearMinus);
            YearView.AddSubview(YearLabel);
            PickerView.AddSubview(DateView);
            PickerView.AddSubview(MonthView);
            PickerView.AddSubview(YearView);
            PickerView.AddSubview(ChooseDateButton);
            PickerView.AddSubview(LblTitle);
            PickerView.AddSubview(CloseBtn);
            SelectedView.AddSubview(TransperantView);
            SelectedView.AddSubview(PickerView);
        }

        void DatePlusMethod()
        {
            if (Convert.ToInt32(DateLabel.Text) >= 0 && Convert.ToInt32(DateLabel.Text) < 11)
            {
                DateLabel.Text = Convert.ToString(Convert.ToInt32(DateLabel.Text) + 1);
                if (DateLabel.Text.Length == 1)
                {
                    DateLabel.Text = "0" + DateLabel.Text;
                }
            }
            else
            {
                DateLabel.Text = "00";
                YearLabel.Text = YearLabel.Text == "AM" ? "PM" : "AM";
            }
        }

        void DateMinusMethod()
        {
            if (Convert.ToInt32(DateLabel.Text) > 0 && Convert.ToInt32(DateLabel.Text) <= 11)
            {
                DateLabel.Text = Convert.ToString(Convert.ToInt32(DateLabel.Text) - 1);
                if (DateLabel.Text.Length == 1)
                {
                    DateLabel.Text = "0" + DateLabel.Text;
                }
            }
            else
            {
                DateLabel.Text = "11";
                YearLabel.Text = YearLabel.Text == "AM" ? "PM" : "AM";
            }
        }

        void DatePicker()
        {
            if (SourceField != null)
            {
                SourceField.Enabled = false;
            }
            ViewHeight = 220;
            CreateLayout();
            CreateTransition();
            CreateControls();
            //Date Views
            DateView = new UIView(new CGRect(30, 50, 65, 102));
            DateView.Layer.BorderColor = BorderColor;
            DateView.Layer.BorderWidth = 1f;
            MonthView = new UIView(new CGRect(100, 50, 80, 102));
            MonthView.Layer.BorderColor = BorderColor;
            MonthView.Layer.BorderWidth = 1f;
            YearView = new UIView(new CGRect(185, 50, 73, 102));
            YearView.Layer.BorderColor = BorderColor;
            YearView.Layer.BorderWidth = 1f;
            //Controls
            DatePlus = new UIButton(new CGRect(0, 0, 65, 30));
            DatePlus.BackgroundColor = BackgrondColor;
            DatePlus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            DatePlus.SetTitle("+", UIControlState.Normal);
            DateMinus = new UIButton(new CGRect(0, 72, 65, 30));
            DateMinus.BackgroundColor = BackgrondColor;
            DateMinus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            DateMinus.SetTitle("-", UIControlState.Normal);
            MonthPlus = new UIButton(new CGRect(0, 0, 80, 30));
            MonthPlus.BackgroundColor = BackgrondColor;
            MonthPlus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            MonthPlus.SetTitle("+", UIControlState.Normal);
            MonthMinus = new UIButton(new CGRect(0, 72, 80, 30));
            MonthMinus.BackgroundColor = BackgrondColor;
            MonthMinus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            MonthMinus.SetTitle("-", UIControlState.Normal);
            YearPlus = new UIButton(new CGRect(0, 0, 73, 30));
            YearPlus.BackgroundColor = BackgrondColor;
            YearPlus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            YearPlus.SetTitle("+", UIControlState.Normal);
            YearMinus = new UIButton(new CGRect(0, 72, 73, 30));
            YearMinus.BackgroundColor = BackgrondColor;
            YearMinus.SetTitleColor(PlusMinusColor, UIControlState.Normal);
            YearMinus.SetTitle("-", UIControlState.Normal);
            ChooseDateButton = new UIButton();
            ChooseDateButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            ChooseDateButton.Frame = new CGRect(30, 160, 230, 40);
            if (PickerFont == null)
            {
                ChooseDateButton.Font = UIFont.FromName("GillSans", 15);
            }
            else
            {
                ChooseDateButton.Font = PickerFont;
                ChooseDateButton.Font.WithSize(14);
            }
            if (ChooseButtonColor == null)
            {
                ChooseDateButton.SetBackgroundImage(UIImage.FromFile("btn.png"), UIControlState.Normal);
            }
            else
            {
                ChooseDateButton.BackgroundColor = ChooseButtonColor;
            }
            ChooseDateButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (SourceField != null)
                {
                    SourceField.Enabled = true;
                    SourceField.Text = ChooseDateButton.Title(UIControlState.Normal).ToString().Replace("Select Date", "").Trim();
                    Hide();
                }
            };
            //Labels
            DateLabel = new UILabel(new CGRect(0, 32, 64, 40));
            DateLabel.TextAlignment = UITextAlignment.Center;
            DateLabel.TextColor = UIColor.Black;
            DateLabel.Font = UIFont.BoldSystemFontOfSize(17);
            MonthLabel = new UILabel(new CGRect(0, 32, 78, 40));
            MonthLabel.TextColor = UIColor.Black;
            MonthLabel.Font = UIFont.BoldSystemFontOfSize(17);
            MonthLabel.TextAlignment = UITextAlignment.Center;
            YearLabel = new UILabel(new CGRect(0, 32, 72, 40));
            YearLabel.TextColor = UIColor.Black;
            YearLabel.Font = UIFont.BoldSystemFontOfSize(17);
            YearLabel.TextAlignment = UITextAlignment.Center;
            DateView.Layer.CornerRadius = 1;
            MonthView.Layer.CornerRadius = 1;
            YearView.Layer.CornerRadius = 1;
            DateView.BackgroundColor = UIColor.White;
            MonthView.BackgroundColor = UIColor.White;
            YearView.BackgroundColor = UIColor.White;
            DateTime currentDate = DateTime.Now;
            if (string.IsNullOrWhiteSpace(Seperator))
            {
                Seperator = "/";
            }
            //Touch Events
            DateLabel.Text = currentDate.Day.ToString();
            DatePlus.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (Convert.ToInt32(DateLabel.Text) < 31)
                {
                    DateLabel.Text = Convert.ToString(Convert.ToInt32(DateLabel.Text) + 1);
                    ChooseDateButton.SetTitle("Select Date    " + SelectedDateFormat(DateLabel, MonthLabel, YearLabel, Seperator), UIControlState.Normal);
                }
            };

            DateMinus.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (Convert.ToInt32(DateLabel.Text) > 1)
                {
                    DateLabel.Text = Convert.ToString(Convert.ToInt32(DateLabel.Text) - 1);
                    ChooseDateButton.SetTitle("Select Date    " + SelectedDateFormat(DateLabel, MonthLabel, YearLabel, Seperator), UIControlState.Normal);
                }
            };

            var value = Months.GetValue(currentDate.Month - 1);
            MonthLabel.Text = value.ToString();
            int i = Array.FindIndex(Months, row => row.Equals(MonthLabel.Text));
            MonthPlus.TouchUpInside += (object sender, EventArgs e) =>
            {
                i = Array.FindIndex(Months, row => row.Equals(MonthLabel.Text));
                if (i < 11)
                {
                    i++;
                    MonthLabel.Text = Months[i];
                    ChooseDateButton.SetTitle("Select Date    " + SelectedDateFormat(DateLabel, MonthLabel, YearLabel, Seperator), UIControlState.Normal);
                }
            };

            MonthMinus.TouchUpInside += (object sender, EventArgs e) =>
            {
                int j = Array.FindIndex(Months, row => row.Equals(MonthLabel.Text));
                if (j > 0)
                {
                    j--;
                    MonthLabel.Text = Months[j];
                    ChooseDateButton.SetTitle("Select Date    " + SelectedDateFormat(DateLabel, MonthLabel, YearLabel, Seperator), UIControlState.Normal);
                }
            };

            int ii = 2100;
            YearLabel.Text = currentDate.Year.ToString();
            YearPlus.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (Convert.ToInt32(YearLabel.Text) < ii)
                {
                    YearLabel.Text = Convert.ToString(Convert.ToInt32(YearLabel.Text) + 1);
                    ChooseDateButton.SetTitle("Select Date    " + SelectedDateFormat(DateLabel, MonthLabel, YearLabel, Seperator), UIControlState.Normal);
                }
            };

            int jj = 1900;
            YearMinus.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (Convert.ToInt32(YearLabel.Text) > jj)
                {
                    YearLabel.Text = Convert.ToString(Convert.ToInt32(YearLabel.Text) - 1);
                    ChooseDateButton.SetTitle("Select Date    " + SelectedDateFormat(DateLabel, MonthLabel, YearLabel, Seperator), UIControlState.Normal);
                }
            };

            ChooseDateButton.SetTitle("Select Date    " + SelectedDateFormat(DateLabel, MonthLabel, YearLabel, Seperator), UIControlState.Normal);
            DateView.AddSubview(DatePlus);
            DateView.AddSubview(DateMinus);
            DateView.AddSubview(DateLabel);
            MonthView.AddSubview(MonthPlus);
            MonthView.AddSubview(MonthMinus);
            MonthView.AddSubview(MonthLabel);
            YearView.AddSubview(YearPlus);
            YearView.AddSubview(YearMinus);
            YearView.AddSubview(YearLabel);
            PickerView.AddSubview(DateView);
            PickerView.AddSubview(MonthView);
            PickerView.AddSubview(YearView);
            PickerView.AddSubview(ChooseDateButton);
            PickerView.AddSubview(LblTitle);
            PickerView.AddSubview(CloseBtn);
            SelectedView.AddSubview(TransperantView);
            SelectedView.AddSubview(PickerView);
        }

        string SelectedDateFormat(UILabel date, UILabel month, UILabel year, string seperator)
        {
            string returnValue = string.Empty;
            string monthLabel = month.Text;
            if (IsFullMonthRequired == false)
            {
                int i = Array.FindIndex(Months, row => row.Equals(MonthLabel.Text));
                string strIndex = Convert.ToString(i + 1);
                if (strIndex.Length == 1)
                {
                    strIndex = "0" + strIndex;
                }
                monthLabel = strIndex;
            }
            if (DateFormat == SelectDateFormat.DMY)
            {
                returnValue = date.Text + seperator + monthLabel + seperator + year.Text;
            }
            else if (DateFormat == SelectDateFormat.MDY)
            {
                returnValue = monthLabel + seperator + date.Text + seperator + year.Text;
            }
            else if (DateFormat == SelectDateFormat.YDM)
            {
                returnValue = year.Text + seperator + date.Text + seperator + monthLabel;
            }
            else if (DateFormat == SelectDateFormat.YMD)
            {
                returnValue = year.Text + seperator + monthLabel + seperator + date.Text;
            }
            else
            {
                returnValue = date.Text + seperator + monthLabel + seperator + year.Text;
            }

            return returnValue;
        }

        void PlainPicker()
        {
            PlainTextView = new UITextView();
            PlainTextView.Editable = false;
            PlainTextView.TextAlignment = UITextAlignment.Justified;
            var plainFrame = PlainTextView.Frame;
            var txtAttributes = new UIStringAttributes();
            if (PickerFont == null)
            {
                txtAttributes.Font = UIFont.FromName("GillSans", 13);
            }
            else
            {
                txtAttributes.Font = PickerFont;
                txtAttributes.Font.WithSize(13);
            }
            PlainTextView.AttributedText = new NSAttributedString(PlainDescription, txtAttributes);
            const float textWidth = 270f;
            plainFrame.X = 10;
            plainFrame.Y = 40;
            plainFrame.Width = 270;
            var text = new NSMutableAttributedString(PlainDescription);
            text.AddAttribute(UIStringAttributeKey.Font, UIFont.FromName("GillSans", 13), new NSRange(0, text.Length));
            var ctxt = new NSStringDrawingContext();
            var boundingRect = text.GetBoundingRect(new SizeF(270, float.MaxValue), NSStringDrawingOptions.UsesFontLeading | NSStringDrawingOptions.UsesLineFragmentOrigin, ctxt);
            plainFrame.Height = boundingRect.Height;
            PlainTextView.Frame = plainFrame;
            PlainTextView.BackgroundColor = UIColor.Clear;
            PlainTextView.ScrollEnabled = false;
            if (boundingRect.Height > 350)
            {
                PlainTextView.ScrollEnabled = true;
                ViewHeight = 410;
            }
            else
            {
                if (boundingRect.Height > 50)
                {
                    PlainTextView.ScrollEnabled = true;
                    ViewHeight = (float)(boundingRect.Height + 55);
                }
                else
                {
                    ViewHeight = (float)(boundingRect.Height + 30);
                }
            }
            CreateLayout();
            CreateTransition();
            CreateControls();
            PickerView.AddSubview(LblTitle);
            PickerView.AddSubview(PlainTextView);
            PickerView.AddSubview(CloseBtn);
            SelectedView.AddSubview(TransperantView);
            SelectedView.AddSubview(PickerView);
        }

        void CreateTransition()
        {
            var transition = CATransition.CreateAnimation();
            transition.Duration = 0.25;
            transition.Speed = 1f;
            transition.Type = CATransition.TransitionPush;
            transition.Subtype = CATransition.TransitionFromBottom;
            PickerView.Layer.AddAnimation(transition, "slide");
            PickerView.Layer.RemoveAnimation("slide");
        }

        void CreateLayout()
        {
            PickerView = new UIView(new CGRect((SelectedView.Bounds.Width - 290) / 2, (SelectedView.Bounds.Height / 2) - 130,
                290, ViewHeight));
            TransperantView = new UIView(new CGRect(0, 0,
                SelectedView.Bounds.Width, SelectedView.Bounds.Height));
            TransperantView.BackgroundColor = UIColor.DarkGray;
            TransperantView.Alpha = 0.6f;
            TransperantView.Hidden = false;
            PickerView.Hidden = false;
            PickerView.BackgroundColor = PickerColor;
            PickerView.Layer.CornerRadius = 2f;
            PickerView.Layer.BackgroundColor = (PickerColor).CGColor;
        }

        void CreateControls()
        {
            CloseBtn = new UIButton(UIButtonType.Custom);
            CloseBtn.SetImage(UIImage.FromFile("btn_close.png"), UIControlState.Normal);
            CloseBtn.SetTitleColor(UIColor.White, UIControlState.Normal);
            CloseBtn.Frame = new CGRect(PickerView.Frame.Width - 35, 10, 25, 25);
            CloseBtn.TouchUpInside += (object sender, EventArgs e) =>
            {
                Hide();
            };
            LblTitle = new UILabel(new CGRect(5, 7, 250, 40));
            LblTitle.Text = "     " + HeaderTitle;
            if (PickerTitleColor != null)
            {
                LblTitle.TextColor = PickerTitleColor;
            }
            else
            {
                LblTitle.TextColor = UIColor.DarkGray;
            }
            LblTitle.TextAlignment = UITextAlignment.Center;
            if (PickerFont == null)
            {
                LblTitle.Font = UIFont.FromName("GillSans", 15);
            }
            else
            {
                LblTitle.Font = PickerFont;
                LblTitle.Font.WithSize(15);
            }
        }

        void CreateList(UITextField field)
        {
            if (TableHeight > 250)
            {
                TableHeight = 180;
            }
            ItemListTable = new UITableView(new CGRect(20, 50, 250, TableHeight));
            ItemListTable.BackgroundColor = UIColor.Clear;
            if (PlainPickerItems != null)
            {
                var source = new PlainDataSource(PlainPickerItems);
                source.TextColor = ListTextColor;
                source.TextFont = PickerFont;
                source.ValueSelected += (object sender, EventArgs e) =>
                {
                    if (field != null)
                    {
                        field.Enabled = true;
                        field.Text = source.SelectedItem;
                        Hide();
                    }
                };
                ItemListTable.Source = source;
                ItemListTable.Hidden = false;
            }
            else
            {
                ItemListTable.Hidden = true;
                LblNodataMessage = new UILabel(new CGRect(20, 60, 250, 50));
                LblNodataMessage.Lines = 2;
                LblNodataMessage.Text = "Nothing to display here. \n Send List Source to display data";
                if (PickerFont == null)
                {
                    LblNodataMessage.Font = UIFont.FromName("GillSans", 13);
                }
                else
                {
                    LblNodataMessage.Font = PickerFont;
                    LblNodataMessage.Font.WithSize(13);
                }
                LblNodataMessage.BackgroundColor = UIColor.Clear;
                LblNodataMessage.TextAlignment = UITextAlignment.Center;
                PickerView.AddSubview(LblNodataMessage);
            }
        }
    }
}