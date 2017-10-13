using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

using myNamespace;


/// <summary>
/// Combo box есть
/// CheckBox
/// </summary>

class DialogApartment : Form
{
    private TabControl tc_Main;

    private TabPage tb_Main;
    private TabPage tb_Adress;
    private TabPage tb_Rooms;
    private TabPage tb_House;

    private Button save;
    private Button cancel;

    private CheckBox inCredit;

    private Label cost;

    private Label monthlyPay;
    private Label creditRate;
    private TrackBar trackBar;

    private TextBox m_TextBox;

    private GroupBox m_GB_Color;
    private RadioButton m_RB_Red;
    private RadioButton m_RB_Green;
    private RadioButton m_RB_Blue;

    private ListBox m_ListBox;

    private NumericUpDown m_NumericUpDown;
    

    public DialogApartment()
    {
        Text = "Appatments - Dialog based application";
        StartPosition = FormStartPosition.Manual;
        Location = new System.Drawing.Point(200, 200);
        Size = new System.Drawing.Size(600, 400);

        Closed += new System.EventHandler(UI_Closed);


        // main methods and controlers in tabs
        //Button
        save = new Button();

        save.Name = "Save";
        save.Text = "Save";
        save.Location = new System.Drawing.Point(105, 315);
        save.Size = new System.Drawing.Size(120, 30);
        save.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        save.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        save.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Bold);
        save.ForeColor = System.Drawing.Color.FromArgb(50, 205, 50);

        Controls.Add(save);

        cancel = new Button();

        cancel.Name = "Cancel";
        cancel.Text = "Cancel";
        cancel.Location = new System.Drawing.Point(370, 315);
        cancel.Size = new System.Drawing.Size(120, 30);
        cancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        cancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        cancel.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Bold);
        cancel.ForeColor = System.Drawing.Color.FromArgb(255, 69, 0);

        Controls.Add(cancel);

        //Texts
        cost = new Label();
        cost.Name = "Cost";
        cost.Text = "General cost of appartments";
        cost.Location = new System.Drawing.Point(16, 16);
        cost.Size = new System.Drawing.Size(200, 60);
        //cost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        cost.Font = new System.Drawing.Font("Arial", 10F);

       


        //Text Boxes
        m_TextBox = new TextBox();
        m_TextBox.Text = "";
        m_TextBox.Location = new System.Drawing.Point(250, 16);
        m_TextBox.Size = new System.Drawing.Size(100, 60);
        m_TextBox.Font = new System.Drawing.Font("Arial", 10F);
        m_TextBox.Multiline = false; // multi line
        m_TextBox.MaxLength = 9;
        m_TextBox.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        m_TextBox.WordWrap = false;
        m_TextBox.TextChanged += new EventHandler(TextBox_TextChanged);

        //Controls.Add(m_TextBox);

        //CheckBox
        inCredit = new CheckBox();
        inCredit.Text = "Will be bought in credit";
        inCredit.Checked = false;
        inCredit.CheckAlign = ContentAlignment.MiddleRight;
        inCredit.Location = new System.Drawing.Point(16, 50);
        inCredit.Size = new System.Drawing.Size(250, 20);
        inCredit.Font = new System.Drawing.Font("Arial", 10F);
        inCredit.Click += new System.EventHandler(inCreditClic);

        //Controls.Add(inCredit);

        //TrackBar
        monthlyPay = new Label();
        monthlyPay.Location = new System.Drawing.Point(16, 125);
        monthlyPay.Size = new System.Drawing.Size(250, 20);
        monthlyPay.TextAlign = ContentAlignment.MiddleLeft;

        creditRate = new Label();
        creditRate.Location = new System.Drawing.Point(16, 175);
        creditRate.Size = new System.Drawing.Size(250, 20);
        creditRate.TextAlign = ContentAlignment.MiddleLeft;

        //Controls.Add(m_Level_Label);

        trackBar = new TrackBar();
        trackBar.Minimum = 0;
        trackBar.Maximum = 120;
        trackBar.Value = 60;
        
        trackBar.Location = new System.Drawing.Point(250, 75);
        trackBar.Size = new System.Drawing.Size(220, 20);
        trackBar.Orientation = Orientation.Horizontal;
        trackBar.TickStyle = TickStyle.TopLeft;
        trackBar.TickFrequency = 10;
        trackBar.Scroll += new EventHandler(TrackBar_Scroll);

        monthlyPay.Text = "Monthly Pay = " + trackBar.Value;
        creditRate.Text = "Credit Rate = " + trackBar.Value + "%";

        //ListBox
        m_ListBox = new ListBox();
        m_ListBox.Items.Clear();
        m_ListBox.IntegralHeight = false;
        m_ListBox.Location = new System.Drawing.Point(310, 16);
        m_ListBox.Size = new System.Drawing.Size(160, 90);
        m_ListBox.Items.AddRange(new object[]
        {   "Red",
            "Orange",
            "Yellow",
            "Green",
            "Cyan",
            "Blue",
            "Magenta"
        });
        m_ListBox.SelectionMode = SelectionMode.MultiSimple;
        m_ListBox.SetSelected(1, true);
        m_ListBox.SelectedIndexChanged += new EventHandler(ListBox_SelectedIndexChanged);
        //Controls.Add(m_ListBox);

        //Spinn
        m_NumericUpDown = new NumericUpDown();
        m_NumericUpDown.Location = new System.Drawing.Point(480, 76);
        m_NumericUpDown.Size = new System.Drawing.Size(160, 20);
        m_NumericUpDown.Minimum = new Decimal(-10);
        m_NumericUpDown.Maximum = new Decimal(10);
        m_NumericUpDown.Increment = new Decimal(0.1);
        m_NumericUpDown.DecimalPlaces = 1;
        m_NumericUpDown.Value = new Decimal(0.0);
        m_NumericUpDown.ValueChanged += new EventHandler(NumericUpDown_ValueChanged);

        //Controls.Add(m_NumericUpDown);

        

        //Controls.Add(m_TrackBar);


        //GroupBox with radio button
        m_RB_Red = new RadioButton();
        m_RB_Red.Text = "Red";
        m_RB_Red.Checked = false;
        m_RB_Red.Location = new System.Drawing.Point(16, 16);
        m_RB_Red.Size = new System.Drawing.Size(80, 20);
        m_RB_Red.Click += new System.EventHandler(RadioButton_Click);
        m_RB_Green = new RadioButton();
        m_RB_Green.Text = "Green";
        m_RB_Green.Checked = true;
        m_RB_Green.Location = new System.Drawing.Point(16, 36);
        m_RB_Green.Size = new System.Drawing.Size(80, 20);
        m_RB_Green.Click += new System.EventHandler(RadioButton_Click);
        m_RB_Blue = new RadioButton();
        m_RB_Blue.Text = "Blue";
        m_RB_Blue.Checked = false;
        m_RB_Blue.Location = new System.Drawing.Point(16, 56);
        m_RB_Blue.Size = new System.Drawing.Size(80, 20);
        m_RB_Blue.Click += new System.EventHandler(RadioButton_Click);


        m_GB_Color = new GroupBox();
        m_GB_Color.Text = "Choose color";
        m_GB_Color.Location = new System.Drawing.Point(18, 100);
        m_GB_Color.Size = new System.Drawing.Size(100, 80);

        m_GB_Color.Controls.AddRange(new Control[]
        {
            m_RB_Red,
            m_RB_Green,
            m_RB_Blue
        });

        //Controls.Add(m_GB_Color);




        // tabs
        //TabControl
        tc_Main = new TabControl();
        tc_Main.Name = "ApartmentTabs";
        tc_Main.Font = new Font("Georgia", 16);
        tc_Main.Size = new System.Drawing.Size(582, 300);
        //        tc_Main.Dock = DockStyle.Fill;


        //tab - Main
        tb_Main = new TabPage();
        tb_Main.Name = "Main";
        tb_Main.Text = "Main";
        tb_Main.Font = new Font("Verdana", 12);
        tb_Main.Width = 590;
        tb_Main.Height = 300;

        tc_Main.TabPages.Add(tb_Main);
        tb_Main.Controls.Add(m_TextBox);
        tb_Main.Controls.Add(inCredit);
        tb_Main.Controls.Add(cost);
        tb_Main.Controls.Add(monthlyPay);
        tb_Main.Controls.Add(creditRate);
        tb_Main.Controls.Add(trackBar);


        //tab - Adress
        tb_Adress = new TabPage();
        tb_Adress.Name = "Adress";
        tb_Adress.Text = "Adress";
        tb_Adress.Font = new Font("Verdana", 12);
        tb_Adress.Width = 590;
        tb_Adress.Height = 300;

        tc_Main.TabPages.Add(tb_Adress); 
        tb_Adress.Controls.Add(m_ListBox);
        tb_Adress.Controls.Add(m_NumericUpDown);
        
        tb_Adress.Controls.Add(m_GB_Color);


        //tab - Rooms
        tb_Rooms = new TabPage();
        tb_Rooms.Name = "Rooms";
        tb_Rooms.Text = "Rooms";
        tb_Rooms.Font = new Font("Verdana", 12);
        tb_Rooms.Width = 590;
        tb_Rooms.Height = 300;

        tc_Main.TabPages.Add(tb_Rooms);
        //tb_Rooms.Controls.Add(button1);

        //tab - House
        tb_House = new TabPage();
        tb_House.Name = "House";
        tb_House.Text = "House";
        tb_House.Font = new Font("Verdana", 12);
        tb_House.Width = 590;
        tb_House.Height = 300;

        tc_Main.TabPages.Add(tb_House);
        //tb_House.Controls.Add(button1);

        Controls.Add(tc_Main);
    }

    private void TextBox_TextChanged(object sender, System.EventArgs e)
    {
        //this.Text = "Dialog based application :" +
        //m_TextBox.Text.Replace("\r\n", " ");
    }


    //CheckBox
    private void inCreditClic(object sender, System.EventArgs e)
    {
        save.Enabled = inCredit.Checked;
    }


    //GroupBox with radio button
    private void RadioButton_Click(object sender, System.EventArgs e)
    {
        
        //RadioButton rb = (RadioButton)sender;
        
        //switch (rb.Text)
        //{
        //    case "Red":
        //        {
        //            m_Button.ForeColor = Color.Red;
        //            break;
        //        }
        //    case "Green":
        //        {
        //            m_Button.ForeColor = Color.Green;
        //            break;
        //        }
        //    case "Blue":
        //        {
        //            m_Button.ForeColor = Color.Blue;
        //            break;
        //        }
        //}
    }

    private void ListBox_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //string str;
        //str = "Список выбранных элементов списка:\r\n";
        //foreach (int idx in m_ListBox.SelectedIndices)
        //{
        //    str += "" + idx + " - " + m_ListBox.Items[idx] + "\r\n";
        //}
        //m_TextBox.Text = str;
    }

    private void NumericUpDown_ValueChanged(object sender, System.EventArgs e)
    {
        //m_TextBox.Text = "Spinner value = " + m_NumericUpDown.Value;
    }

    private void TrackBar_Scroll(object sender, System.EventArgs e)
    {
        monthlyPay.Text = "Monthly Pay = " + trackBar.Value;
        creditRate.Text = "Credit Rate = " + trackBar.Value + "%";
    }

    private void UI_Closed(object sender, EventArgs e)
    {
 
    Dispose();
    }
}
