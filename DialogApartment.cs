using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

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

    private TextBox tx_Credit;
    private CheckBox inCredit;

    private Label cost;

    private Label monthlyPay;
    private Label creditRate;
    private Label months;
    private TrackBar trackBar;

    private Label city;
    private Label streetName;
    private Label streetNumber;
    private Label houseNumber;
    private Label floor;
    private Label appartemntNumber;

    private TextBox tx_City;
    private TextBox tx_StreetName;
    private TextBox tx_StreetNumber;
    private TextBox tx_HoseNumber;
    private TextBox tx_Floor;
    private TextBox tx_AppartemntNumber;



    private GroupBox m_GB_Color;
    private RadioButton m_RB_Red;
    private RadioButton m_RB_Green;
    private RadioButton m_RB_Blue;


    private Label numberOfRooms;
    private NumericUpDown s_NumberOfRooms;
    private Label roomName;
    private Label width;
    private Label length;
    private Label area;
    private Label totalArea;

    //private ComboBox cb_Room;
    //private Label calcArea;
    //private TextBox tx_Width;
    //private TextBox tx_Length;
    private Panel scrollPanel;
    private VScrollBar scrollBar;
    private List<RomControler> romControler;

    private ListBox m_ListBox;


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


        //Main page

        //Texts
        cost = new Label();
        cost.Name = "Cost";
        cost.Text = "General cost of appartments";
        cost.Location = new System.Drawing.Point(16, 16);
        cost.Size = new System.Drawing.Size(200, 60);
        //cost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        cost.Font = new System.Drawing.Font("Arial", 10F);

        //Text Boxes
        tx_Credit = new TextBox();
        tx_Credit.Text = "";
        tx_Credit.Location = new System.Drawing.Point(250, 16);
        tx_Credit.Size = new System.Drawing.Size(100, 60);
        tx_Credit.Font = new System.Drawing.Font("Arial", 10F);
        tx_Credit.Multiline = false; // multi line
        tx_Credit.MaxLength = 9;
        tx_Credit.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        tx_Credit.WordWrap = false;
        tx_Credit.TextChanged += new EventHandler(TextBox_TextChanged);

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
        months = new Label();
        months.Location = new System.Drawing.Point(16, 150);
        months.Size = new System.Drawing.Size(600, 20);
        months.Font = new System.Drawing.Font("Arial", 10F);
        months.TextAlign = ContentAlignment.MiddleLeft;

        creditRate = new Label();
        creditRate.Location = new System.Drawing.Point(16, 185);
        creditRate.Size = new System.Drawing.Size(600, 20);
        creditRate.Font = new System.Drawing.Font("Arial", 10F);
        creditRate.TextAlign = ContentAlignment.MiddleLeft;

        monthlyPay = new Label();
        monthlyPay.Location = new System.Drawing.Point(16, 220);
        monthlyPay.Size = new System.Drawing.Size(600, 20);
        monthlyPay.Font = new System.Drawing.Font("Arial", 10F);
        monthlyPay.TextAlign = ContentAlignment.MiddleLeft;

        //Controls.Add(m_Level_Label);

        trackBar = new TrackBar();
        trackBar.Minimum = 0;
        trackBar.Maximum = 240;
        trackBar.Value = 60;
        
        trackBar.Location = new System.Drawing.Point(50, 100);
        trackBar.Size = new System.Drawing.Size(500, 20);
        trackBar.Orientation = Orientation.Horizontal;
        trackBar.TickStyle = TickStyle.TopLeft;
        trackBar.TickFrequency = 10;
        trackBar.Scroll += new EventHandler(TrackBar_Scroll);

        months.Text =     "Number of Months                                 " + trackBar.Value;
        creditRate.Text = "Credit Rate                                            " + trackBar.Value + "%";
        monthlyPay.Text = "Monthly Pay                                           " + trackBar.Value;


        //Adress box

        city = new Label();
        city.Name = "City";
        city.Text = "City";
        city.Location = new System.Drawing.Point(16, 16);
        city.Size = new System.Drawing.Size(200, 20);
        city.Font = new System.Drawing.Font("Arial", 10F);
        city.TextAlign = ContentAlignment.MiddleLeft;

        tx_City = new TextBox();
        tx_City.Text = "";
        tx_City.Location = new System.Drawing.Point(250, 16);
        tx_City.Size = new System.Drawing.Size(200, 20);
        tx_City.Font = new System.Drawing.Font("Arial", 10F);
        tx_City.Multiline = false; // multi line
        tx_City.MaxLength = 100;
        tx_City.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        tx_City.WordWrap = false;
        tx_City.TextChanged += new EventHandler(TextBox_TextChanged);


        streetName = new Label();
        streetName.Name = "Street";
        streetName.Text = "Street";
        streetName.Location = new System.Drawing.Point(16, 46);
        streetName.Size = new System.Drawing.Size(200, 20);
        streetName.Font = new System.Drawing.Font("Arial", 10F);
        streetName.TextAlign = ContentAlignment.MiddleLeft;

        tx_StreetName = new TextBox();
        tx_StreetName.Text = "";
        tx_StreetName.Location = new System.Drawing.Point(250, 46);
        tx_StreetName.Size = new System.Drawing.Size(200, 20);
        tx_StreetName.Font = new System.Drawing.Font("Arial", 10F);
        tx_StreetName.Multiline = false; // multi line
        tx_StreetName.MaxLength = 100;
        tx_StreetName.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        tx_StreetName.WordWrap = false;
        tx_StreetName.TextChanged += new EventHandler(TextBox_TextChanged);


        streetNumber = new Label();
        streetNumber.Name = "Street Number";
        streetNumber.Text = "Street Number";
        streetNumber.Location = new System.Drawing.Point(16, 76);
        streetNumber.Size = new System.Drawing.Size(200, 20);
        streetNumber.Font = new System.Drawing.Font("Arial", 10F);
        streetNumber.TextAlign = ContentAlignment.MiddleLeft;

        tx_StreetNumber = new TextBox();
        tx_StreetNumber.Text = "";
        tx_StreetNumber.Location = new System.Drawing.Point(250, 76);
        tx_StreetNumber.Size = new System.Drawing.Size(200, 20);
        tx_StreetNumber.Font = new System.Drawing.Font("Arial", 10F);
        tx_StreetNumber.Multiline = false; // multi line
        tx_StreetNumber.MaxLength = 100;
        tx_StreetNumber.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        tx_StreetNumber.WordWrap = false;
        tx_StreetNumber.TextChanged += new EventHandler(TextBox_TextChanged);


        houseNumber = new Label();
        houseNumber.Name = "House Number";
        houseNumber.Text = "House Number";
        houseNumber.Location = new System.Drawing.Point(16, 106);
        houseNumber.Size = new System.Drawing.Size(200, 20);
        houseNumber.Font = new System.Drawing.Font("Arial", 10F);
        houseNumber.TextAlign = ContentAlignment.MiddleLeft;

        tx_HoseNumber = new TextBox();
        tx_HoseNumber.Text = "";
        tx_HoseNumber.Location = new System.Drawing.Point(250, 106);
        tx_HoseNumber.Size = new System.Drawing.Size(200, 20);
        tx_HoseNumber.Font = new System.Drawing.Font("Arial", 10F);
        tx_HoseNumber.Multiline = false; // multi line
        tx_HoseNumber.MaxLength = 100;
        tx_HoseNumber.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        tx_HoseNumber.WordWrap = false;
        tx_HoseNumber.TextChanged += new EventHandler(TextBox_TextChanged);


        floor = new Label();
        floor.Name = "Floor";
        floor.Text = "Floor";
        floor.Location = new System.Drawing.Point(16, 136);
        floor.Size = new System.Drawing.Size(200, 20);
        floor.Font = new System.Drawing.Font("Arial", 10F);
        floor.TextAlign = ContentAlignment.MiddleLeft;

        tx_Floor = new TextBox();
        tx_Floor.Text = "";
        tx_Floor.Location = new System.Drawing.Point(250, 136);
        tx_Floor.Size = new System.Drawing.Size(200, 20);
        tx_Floor.Font = new System.Drawing.Font("Arial", 10F);
        tx_Floor.Multiline = false; // multi line
        tx_Floor.MaxLength = 100;
        tx_Floor.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        tx_Floor.WordWrap = false;
        tx_Floor.TextChanged += new EventHandler(TextBox_TextChanged);


        appartemntNumber = new Label();
        appartemntNumber.Name = "Appartment Number";
        appartemntNumber.Text = "Appartment Number";
        appartemntNumber.Location = new System.Drawing.Point(16, 166);
        appartemntNumber.Size = new System.Drawing.Size(200, 20);
        appartemntNumber.Font = new System.Drawing.Font("Arial", 10F);
        appartemntNumber.TextAlign = ContentAlignment.MiddleLeft;

        tx_AppartemntNumber = new TextBox();
        tx_AppartemntNumber.Text = "";
        tx_AppartemntNumber.Location = new System.Drawing.Point(250, 166);
        tx_AppartemntNumber.Size = new System.Drawing.Size(200, 20);
        tx_AppartemntNumber.Font = new System.Drawing.Font("Arial", 10F);
        tx_AppartemntNumber.Multiline = false; // multi line
        tx_AppartemntNumber.MaxLength = 100;
        tx_AppartemntNumber.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        tx_AppartemntNumber.WordWrap = false;
        tx_AppartemntNumber.TextChanged += new EventHandler(TextBox_TextChanged);


        //Rooms box

        //Spinn
        numberOfRooms = new Label();
        numberOfRooms.Name = "Number of Rooms";
        numberOfRooms.Text = "Number of Rooms";
        numberOfRooms.Location = new System.Drawing.Point(16, 16);
        numberOfRooms.Size = new System.Drawing.Size(200, 20);
        numberOfRooms.Font = new System.Drawing.Font("Arial", 10F);
        numberOfRooms.TextAlign = ContentAlignment.MiddleLeft;

        s_NumberOfRooms = new NumericUpDown();
        s_NumberOfRooms.Location = new System.Drawing.Point(250, 16);
        s_NumberOfRooms.Size = new System.Drawing.Size(160, 20);
        s_NumberOfRooms.Minimum = new Decimal(1);
        s_NumberOfRooms.Maximum = new Decimal(999);
        s_NumberOfRooms.Increment = new Decimal(1);
        s_NumberOfRooms.DecimalPlaces = 1;
        s_NumberOfRooms.Value = new Decimal(1);
        s_NumberOfRooms.ValueChanged += new EventHandler(NumericUpDown_ValueChanged);


        roomName = new Label();
        roomName.Name = "Room";
        roomName.Text = "Room";
        roomName.Location = new System.Drawing.Point(16, 60);
        roomName.Size = new System.Drawing.Size(50, 20);
        roomName.Font = new System.Drawing.Font("Arial", 10F);
        roomName.TextAlign = ContentAlignment.MiddleLeft;

        width = new Label();
        width.Name = "Width";
        width.Text = "Width";
        width.Location = new System.Drawing.Point(200, 60);
        width.Size = new System.Drawing.Size(50, 20);
        width.Font = new System.Drawing.Font("Arial", 10F);
        width.TextAlign = ContentAlignment.MiddleLeft;

        //tx_Width = new TextBox();
        //tx_Width.Text = "";
        //tx_Width.Location = new System.Drawing.Point(175, 85);
        //tx_Width.Size = new System.Drawing.Size(100, 20);
        //tx_Width.Font = new System.Drawing.Font("Arial", 10F);
        //tx_Width.Multiline = false; // multi line
        //tx_Width.MaxLength = 100;
        //tx_Width.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        //tx_Width.WordWrap = false;
        //tx_Width.TextChanged += new EventHandler(TextBox_TextChanged);

        length = new Label();
        length.Name = "Length";
        length.Text = "Length";
        length.Location = new System.Drawing.Point(350, 60);
        length.Size = new System.Drawing.Size(50, 20);
        length.Font = new System.Drawing.Font("Arial", 10F);
        length.TextAlign = ContentAlignment.MiddleLeft;

        //tx_Length = new TextBox();
        //tx_Length.Text = "";
        //tx_Length.Location = new System.Drawing.Point(325, 85);
        //tx_Length.Size = new System.Drawing.Size(100, 20);
        //tx_Length.Font = new System.Drawing.Font("Arial", 10F);
        //tx_Length.Multiline = false; // multi line
        //tx_Length.MaxLength = 100;
        //tx_Length.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        //tx_Length.WordWrap = false;
        //tx_Length.TextChanged += new EventHandler(TextBox_TextChanged);

        area = new Label();
        area.Name = "Area";
        area.Text = "Area";
        area.Location = new System.Drawing.Point(500, 60);
        area.Size = new System.Drawing.Size(50, 20);
        area.Font = new System.Drawing.Font("Arial", 10F);
        area.TextAlign = ContentAlignment.MiddleLeft;

        totalArea = TotalArea(1);

        scrollPanel = new Panel();
        scrollPanel.Size = new System.Drawing.Size(560, 400);
        //scrollPanel.Location = new System.Drawing.Point(0, 100);
        //scrollPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

        scrollBar = new VScrollBar();
        scrollBar.LargeChange = 200;
        scrollBar.Location = new System.Drawing.Point(560, 65);
        scrollBar.Minimum = 0;
        scrollBar.Maximum = 400;
        scrollBar.Size = new System.Drawing.Size(13, 197);
        //scrollBar.Enabled = false;
        scrollBar.ValueChanged += new System.EventHandler(scrollBar_ValueChanged);

        //calcArea = new Label();
        //calcArea.Name = "Calc Area";
        //calcArea.Text = "10";
        //calcArea.Location = new System.Drawing.Point(500, 85);
        //calcArea.Size = new System.Drawing.Size(50, 20);
        //calcArea.Font = new System.Drawing.Font("Arial", 10F);
        //calcArea.TextAlign = ContentAlignment.MiddleLeft;

        //totalArea = new Label();
        //totalArea.Name = "Total Area";
        //totalArea.Text = "Total Area            1";
        //totalArea.Location = new System.Drawing.Point(400, 175);
        //totalArea.Size = new System.Drawing.Size(250, 20);
        //totalArea.Font = new System.Drawing.Font("Arial", 10F);
        //totalArea.TextAlign = ContentAlignment.MiddleLeft;


        //numberOfRooms = new Label();
        //numberOfRooms.Name = "Number Of Rooms";
        //numberOfRooms.Text = "Number Of Rooms";
        //numberOfRooms.Location = new System.Drawing.Point(16, 100);
        //numberOfRooms.Size = new System.Drawing.Size(100, 20);
        //numberOfRooms.Font = new System.Drawing.Font("Arial", 10F);
        //numberOfRooms.TextAlign = ContentAlignment.MiddleLeft;

        //ComboBox
        //cb_Room = new ComboBox();
        //cb_Room.Items.Clear();
        //cb_Room.Location = new System.Drawing.Point(16, 85);
        //cb_Room.Size = new System.Drawing.Size(120, 20);
        //cb_Room.DropDownStyle = ComboBoxStyle.DropDown;
        //cb_Room.Font = new System.Drawing.Font("Arial", 10F);
        //cb_Room.Items.AddRange(new object[]
        //{   "Red",
        //    "Orange",
        //    "Yellow",
        //    "Green",
        //    "Cyan",
        //    "Blue",
        //    "Magenta"});

        //cb_Room.TextChanged += new EventHandler(SelectRoom);




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
        tb_Main.Controls.Add(tx_Credit);
        tb_Main.Controls.Add(inCredit);
        tb_Main.Controls.Add(cost);
        tb_Main.Controls.Add(monthlyPay);
        tb_Main.Controls.Add(creditRate);
        tb_Main.Controls.Add(months);
        tb_Main.Controls.Add(trackBar);
        


        //tab - Adress
        tb_Adress = new TabPage();
        tb_Adress.Name = "Adress";
        tb_Adress.Text = "Adress";
        tb_Adress.Font = new Font("Verdana", 12);
        tb_Adress.Width = 590;
        tb_Adress.Height = 300;

        tb_Adress.Controls.Add(city);
        tb_Adress.Controls.Add(tx_City);
        tb_Adress.Controls.Add(streetName);
        tb_Adress.Controls.Add(tx_StreetName);
        tb_Adress.Controls.Add(streetNumber);
        tb_Adress.Controls.Add(tx_StreetNumber);
        tb_Adress.Controls.Add(houseNumber);
        tb_Adress.Controls.Add(tx_HoseNumber);
        tb_Adress.Controls.Add(floor);
        tb_Adress.Controls.Add(tx_Floor);
        tb_Adress.Controls.Add(appartemntNumber);
        tb_Adress.Controls.Add(tx_AppartemntNumber);

        tc_Main.TabPages.Add(tb_Adress); 
        


        //tab - Rooms
        tb_Rooms = new TabPage();
        tb_Rooms.Name = "Rooms";
        tb_Rooms.Text = "Rooms";
        tb_Rooms.Font = new Font("Verdana", 12);
        tb_Rooms.Width = 590;
        tb_Rooms.Height = 300;

        //tb_Rooms.Controls.Add(cb_Room);
        tb_Rooms.Controls.Add(s_NumberOfRooms);
        tb_Rooms.Controls.Add(numberOfRooms);
        tb_Rooms.Controls.Add(roomName);
        tb_Rooms.Controls.Add(width);
        tb_Rooms.Controls.Add(length);
        tb_Rooms.Controls.Add(area);
        tb_Rooms.Controls.Add(totalArea);
        OneRoomControl();

        tb_Rooms.Controls.Add(scrollBar);
        tb_Rooms.Controls.Add(scrollPanel);

        //tb_Rooms.Controls.Add(calcArea);
        //tb_Rooms.Controls.Add(tx_Length);
        //tb_Rooms.Controls.Add(tx_Width);


        //romControler = new List<RomControler>();
        //romControler.Add(new RomControler());
        //tb_Rooms.Controls.Add(romControler[0].CB_Room);
        //tb_Rooms.Controls.Add(romControler[0].CalcArea);
        //tb_Rooms.Controls.Add(romControler[0].TX_Width);
        //tb_Rooms.Controls.Add(romControler[0].TX_Length);

        tc_Main.TabPages.Add(tb_Rooms);
        //tb_Rooms.Controls.Add(button1);

        //tab - House
        tb_House = new TabPage();
        tb_House.Name = "House";
        tb_House.Text = "House";
        tb_House.Font = new Font("Verdana", 12);
        tb_House.Width = 590;
        tb_House.Height = 300;

        tb_House.Controls.Add(m_ListBox);
        tb_House.Controls.Add(m_GB_Color);

        tc_Main.TabPages.Add(tb_House);



        Controls.Add(tc_Main);
    }

    private void scrollBar_ValueChanged(object sender, System.EventArgs e)
    {
        scrollPanel.Top = -scrollBar.Value;

    }

    private void SelectRoom(object sender, System.EventArgs e)
    {

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

    private void OneRoomControl()
    {
        romControler = new List<RomControler>();
        romControler.Add(new RomControler(0));

        scrollPanel.Controls.Add(romControler[0].CB_Room);
        scrollPanel.Controls.Add(romControler[0].CalcArea);
        scrollPanel.Controls.Add(romControler[0].TX_Width);
        scrollPanel.Controls.Add(romControler[0].TX_Length);
    }

    private Label TotalArea(Int32 pos)
    {
        Label totalArea = new Label();
        totalArea.Name = "Total Area";
        totalArea.Text = "Total Area            1";
        totalArea.Location = new System.Drawing.Point(400, 85 + 35 * pos);
        totalArea.Size = new System.Drawing.Size(150, 20);
        totalArea.Font = new System.Drawing.Font("Arial", 10F);
        totalArea.TextAlign = ContentAlignment.MiddleLeft;

        return totalArea;
    }

    private void NumericUpDown_ValueChanged(object sender, System.EventArgs e)
    {

        if(romControler != null)
        {
            for (int i = 0; i < romControler.Count; i++)
            {
                scrollPanel.Controls.Remove(romControler[i].CB_Room);
                scrollPanel.Controls.Remove(romControler[i].CalcArea);
                scrollPanel.Controls.Remove(romControler[i].TX_Length);
                scrollPanel.Controls.Remove(romControler[i].TX_Width);

                romControler[i].CB_Room.Dispose();
                romControler[i].CalcArea.Dispose();
                romControler[i].TX_Width.Dispose();
                romControler[i].TX_Length.Dispose();
            }
            scrollPanel.Controls.Remove(totalArea);
            totalArea.Dispose();
        }
        

        romControler = new List<RomControler>();
        int incr = 35;
        for (int i = 0; i < s_NumberOfRooms.Value; i++)
        {   
            romControler.Add(new RomControler(incr * i));
        }

        totalArea = TotalArea((Int32)(s_NumberOfRooms.Value));
        scrollPanel.Controls.Add(totalArea);

        foreach (RomControler i in romControler)
        {
            scrollPanel.Controls.Add(i.CB_Room);
            scrollPanel.Controls.Add(i.CalcArea);
            scrollPanel.Controls.Add(i.TX_Width);
            scrollPanel.Controls.Add(i.TX_Length);
        }

        //if (scrollPanel.Height < 85 + 35 * s_NumberOfRooms.Value)
        //{
        //    scrollPanel.Size = new System.Drawing.Size(560, 200);
        //}

    }

    private void TrackBar_Scroll(object sender, System.EventArgs e)
    {
        months.Text =     "Number of Months                                 " + trackBar.Value;
        creditRate.Text = "Credit Rate                                            " + trackBar.Value + "%";
        monthlyPay.Text = "Monthly Pay                                           " + trackBar.Value;
    }

    private void UI_Closed(object sender, EventArgs e)
    {
 
    Dispose();
    }
}

class RomControler
{
    private ComboBox cb_Room;
    private Label calcArea;
    private TextBox tx_Width;
    private TextBox tx_Length;

    public RomControler(int incr)
    {

        cb_Room = new ComboBox();
        cb_Room.Items.Clear();
        cb_Room.Location = new System.Drawing.Point(16, 85 + incr);
        cb_Room.Size = new System.Drawing.Size(120, 20);
        cb_Room.DropDownStyle = ComboBoxStyle.DropDown;
        cb_Room.Font = new System.Drawing.Font("Arial", 10F);
        cb_Room.Items.AddRange(new object[]
        {   "Red",
            "Orange",
            "Yellow",
            "Green",
            "Cyan",
            "Blue",
            "Magenta"});

        cb_Room.TextChanged += new EventHandler(SelectRoom);

        tx_Width = new TextBox();
        tx_Width.Text = "";
        tx_Width.Location = new System.Drawing.Point(175, 85 + incr);
        tx_Width.Size = new System.Drawing.Size(100, 20);
        tx_Width.Font = new System.Drawing.Font("Arial", 10F);
        tx_Width.Multiline = false; // multi line
        tx_Width.MaxLength = 100;
        tx_Width.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        tx_Width.WordWrap = false;
        tx_Width.TextChanged += new EventHandler(TextBox_TextChanged);

        tx_Length = new TextBox();
        tx_Length.Text = "";
        tx_Length.Location = new System.Drawing.Point(325, 85 + incr);
        tx_Length.Size = new System.Drawing.Size(100, 20);
        tx_Length.Font = new System.Drawing.Font("Arial", 10F);
        tx_Length.Multiline = false; // multi line
        tx_Length.MaxLength = 100;
        tx_Length.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        tx_Length.WordWrap = false;
        tx_Length.TextChanged += new EventHandler(TextBox_TextChanged);

        calcArea = new Label();
        calcArea.Name = "Calc Area";
        calcArea.Text = "10";
        calcArea.Location = new System.Drawing.Point(500, 85 + incr);
        calcArea.Size = new System.Drawing.Size(50, 20);
        calcArea.Font = new System.Drawing.Font("Arial", 10F);
        calcArea.TextAlign = ContentAlignment.MiddleLeft;
    }

    private void SelectRoom(object sender, System.EventArgs e)
    {

    }

    private void TextBox_TextChanged(object sender, System.EventArgs e)
    {
        
    }

    public ComboBox CB_Room { get { return cb_Room; } set { cb_Room = value; } }
    public Label CalcArea { get { return calcArea; } set { calcArea = value; } }
    public TextBox TX_Width { get { return tx_Width; } set { tx_Width = value; } }
    public TextBox TX_Length { get { return tx_Length; } set { tx_Length = value; } }

}
