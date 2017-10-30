using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

using myNamespace;

class DialogApartment : Form
{

    
    private TabControl tc_Main;

    private TabPage tb_Main;
    private TabPage tb_Adress;
    private TabPage tb_Rooms;
    private TabPage tb_House;

    private Button save;
    private Button cancel;

    private Apartment apartment;

    // ====================================

    private NumericUpDown tx_Credit;
    private CheckBox inCredit;

    private Label cost;

    private Label monthlyPay;
    private Label creditRate;
    private Label months;
    private TrackBar trackBar;

    // ====================================

    private Label city;
    private Label streetName;
    private Label streetNumber;
    private Label houseNumber;
    private Label floor;
    private Label appartemntNumber;

    private ComboBox tx_City;
    private ComboBox tx_StreetName;
    private NumericUpDown tx_StreetNumber;
    private NumericUpDown tx_HoseNumber;
    private NumericUpDown tx_Floor;
    private NumericUpDown tx_AppartemntNumber;

    // ====================================

    private GroupBox houseType;
    private RadioButton rb_Private;
    private RadioButton rb_MultiStorey;
    private ListBox lb_MaterialType;

    private Label materialType;
    private Label serialName;
    private Label serialNumber;
    private Label yers;
    private Label floors;

    private TextBox tx_serialName;
    private NumericUpDown tx_SerialNumber;
    private NumericUpDown tx_Yers;
    private NumericUpDown tx_Floors;
    
    //=======================================

    private Label numberOfRooms;
    private NumericUpDown s_NumberOfRooms;
    private Label roomName;
    private Label width;
    private Label length;
    private Label area;
    private static Label totalArea;

    private GroupBox groupScroll;
    private Panel scrollPanel;
    private VScrollBar scrollBar;
    private static List<RomControler> romControler;

    private DialogResult result;


    public DialogApartment(Apartment apartment, bool isOld)
    {
        

        Text = "Apatments - Dialog based application";
        StartPosition = FormStartPosition.Manual;
        Location = new System.Drawing.Point(200, 200);
        Size = new System.Drawing.Size(600, 400);

        //FormClosingEvantHandler += new System.EventHandler(UI_Closed);
        //Closed += new System.EventHandler(UI_Closed);

        FormClosing += new System.Windows.Forms.FormClosingEventHandler(UI_Closed);

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
        save.Click += new System.EventHandler(saveApartment);

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
        cancel.Click += new System.EventHandler(UI_Closed);

        Controls.Add(cancel);


        //Main page

        //Texts
        cost = new Label();
        cost.Name = "Cost";
        cost.Text = "General cost of apartments";
        cost.Location = new System.Drawing.Point(16, 16);
        cost.Size = new System.Drawing.Size(200, 60);
        //cost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        cost.Font = new System.Drawing.Font("Arial", 10F);

        //Text Boxes-Spiner
        tx_Credit = new NumericUpDown();
        tx_Credit.Location = new System.Drawing.Point(250, 16);
        tx_Credit.Size = new System.Drawing.Size(100, 60);
        tx_Credit.Font = new System.Drawing.Font("Arial", 10F);
        tx_Credit.Minimum = new Decimal(0);
        tx_Credit.Maximum = new Decimal(9999999999);
        tx_Credit.Increment = new Decimal(1);
        //s_NumberOfRooms.DecimalPlaces = 0;
        tx_Credit.Value = new Decimal(0);
        tx_Credit.ValueChanged += new EventHandler(TrackBar_Scroll);

        //tx_Credit = new TextBox();
        //tx_Credit.Text = "";
        //tx_Credit.Location = new System.Drawing.Point(250, 16);
        //tx_Credit.Size = new System.Drawing.Size(100, 60);
        //tx_Credit.Font = new System.Drawing.Font("Arial", 10F);
        //tx_Credit.Multiline = false; // multi line
        //tx_Credit.MaxLength = 9;
        //tx_Credit.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        //tx_Credit.WordWrap = false;
        //tx_Credit.TextChanged += new EventHandler(TextBox_TextChanged);

        //Controls.Add(m_TextBox);


        //CheckBox
        inCredit = new CheckBox();
        inCredit.Text = "Will be bought in credit";
        inCredit.Checked = true;
        inCredit.CheckAlign = ContentAlignment.MiddleRight;
        inCredit.Location = new System.Drawing.Point(16, 50);
        inCredit.Size = new System.Drawing.Size(248, 20);
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
        trackBar.Value = 0;
        
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

        //tx_City = new TextBox();
        //tx_City.Text = "";
        //tx_City.Location = new System.Drawing.Point(250, 16);
        //tx_City.Size = new System.Drawing.Size(200, 20);
        //tx_City.Font = new System.Drawing.Font("Arial", 10F);
        //tx_City.Multiline = false; // multi line
        //tx_City.MaxLength = 100;
        //tx_City.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        //tx_City.WordWrap = false;
        ////tx_City.TextChanged += new EventHandler(TextBox_TextChanged);

        tx_City = new ComboBox();
        tx_City.Items.Clear();
        tx_City.Location = new System.Drawing.Point(250, 16);
        tx_City.Size = new System.Drawing.Size(200, 20);
        tx_City.Font = new System.Drawing.Font("Arial", 10F);
        tx_City.DropDownStyle = ComboBoxStyle.DropDown;
        tx_City.Items.AddRange(new object[]
        {   "Chisinau",
            "Belti",
            "Leovo",
            "Cahul",
            "Orhei"
        });

        tx_City.KeyDown += new KeyEventHandler(Grid_KeyUp_City);



        streetName = new Label();
        streetName.Name = "Street";
        streetName.Text = "Street";
        streetName.Location = new System.Drawing.Point(16, 46);
        streetName.Size = new System.Drawing.Size(200, 20);
        streetName.Font = new System.Drawing.Font("Arial", 10F);
        streetName.TextAlign = ContentAlignment.MiddleLeft;

        //tx_StreetName = new TextBox();
        //tx_StreetName.Text = "";
        //tx_StreetName.Location = new System.Drawing.Point(250, 46);
        //tx_StreetName.Size = new System.Drawing.Size(200, 20);
        //tx_StreetName.Font = new System.Drawing.Font("Arial", 10F);
        //tx_StreetName.Multiline = false; // multi line
        //tx_StreetName.MaxLength = 100;
        //tx_StreetName.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        //tx_StreetName.WordWrap = false;
        ////tx_StreetName.TextChanged += new EventHandler(TextBox_TextChanged);


        tx_StreetName = new ComboBox();
        tx_StreetName.Items.Clear();
        tx_StreetName.Location = new System.Drawing.Point(250, 46);
        tx_StreetName.Size = new System.Drawing.Size(200, 20);
        tx_StreetName.Font = new System.Drawing.Font("Arial", 10F);
        tx_StreetName.DropDownStyle = ComboBoxStyle.DropDown;
        tx_StreetName.Items.AddRange(new object[]
        {   "Stefan cel Mare",
            "Puskin",
            "Dacia",
            "Alba Iulia"       
        });

        tx_StreetName.KeyDown += new KeyEventHandler(Grid_KeyUp_Street);

        streetNumber = new Label();
        streetNumber.Name = "Street Number";
        streetNumber.Text = "Street Number";
        streetNumber.Location = new System.Drawing.Point(16, 76);
        streetNumber.Size = new System.Drawing.Size(200, 20);
        streetNumber.Font = new System.Drawing.Font("Arial", 10F);
        streetNumber.TextAlign = ContentAlignment.MiddleLeft;

        tx_StreetNumber = new NumericUpDown();
        tx_StreetNumber.Location = new System.Drawing.Point(250, 76);
        tx_StreetNumber.Size = new System.Drawing.Size(200, 20);
        tx_StreetNumber.Font = new System.Drawing.Font("Arial", 10F);
        tx_StreetNumber.Minimum = new Decimal(0);
        tx_StreetNumber.Maximum = new Decimal(999);
        tx_StreetNumber.Increment = new Decimal(1);
        tx_StreetNumber.Value = new Decimal(0);


        //tx_StreetNumber = new TextBox();
        //tx_StreetNumber.Text = "";
        //tx_StreetNumber.Location = new System.Drawing.Point(250, 76);
        //tx_StreetNumber.Size = new System.Drawing.Size(200, 20);
        //tx_StreetNumber.Font = new System.Drawing.Font("Arial", 10F);
        //tx_StreetNumber.Multiline = false; // multi line
        //tx_StreetNumber.MaxLength = 100;
        //tx_StreetNumber.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        //tx_StreetNumber.WordWrap = false;
        //tx_StreetNumber.TextChanged += new EventHandler(TextBox_TextChanged);


        houseNumber = new Label();
        houseNumber.Name = "House Number";
        houseNumber.Text = "House Number";
        houseNumber.Location = new System.Drawing.Point(16, 106);
        houseNumber.Size = new System.Drawing.Size(200, 20);
        houseNumber.Font = new System.Drawing.Font("Arial", 10F);
        houseNumber.TextAlign = ContentAlignment.MiddleLeft;

        tx_HoseNumber = new NumericUpDown();
        tx_HoseNumber.Location = new System.Drawing.Point(250, 106);
        tx_HoseNumber.Size = new System.Drawing.Size(200, 20);
        tx_HoseNumber.Font = new System.Drawing.Font("Arial", 10F);
        tx_HoseNumber.Minimum = new Decimal(0);
        tx_HoseNumber.Maximum = new Decimal(999);
        tx_HoseNumber.Increment = new Decimal(1);
        tx_HoseNumber.Value = new Decimal(0);

        //tx_HoseNumber = new TextBox();
        //tx_HoseNumber.Text = "";
        //tx_HoseNumber.Location = new System.Drawing.Point(250, 106);
        //tx_HoseNumber.Size = new System.Drawing.Size(200, 20);
        //tx_HoseNumber.Font = new System.Drawing.Font("Arial", 10F);
        //tx_HoseNumber.Multiline = false; // multi line
        //tx_HoseNumber.MaxLength = 100;
        //tx_HoseNumber.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        //tx_HoseNumber.WordWrap = false;
        //tx_HoseNumber.TextChanged += new EventHandler(TextBox_TextChanged);


        floor = new Label();
        floor.Name = "Floor";
        floor.Text = "Floor";
        floor.Location = new System.Drawing.Point(16, 136);
        floor.Size = new System.Drawing.Size(200, 20);
        floor.Font = new System.Drawing.Font("Arial", 10F);
        floor.TextAlign = ContentAlignment.MiddleLeft;

        tx_Floor = new NumericUpDown();
        tx_Floor.Location = new System.Drawing.Point(250, 136);
        tx_Floor.Size = new System.Drawing.Size(200, 20);
        tx_Floor.Font = new System.Drawing.Font("Arial", 10F);
        tx_Floor.Minimum = new Decimal(0);
        tx_Floor.Maximum = new Decimal(999);
        tx_Floor.Increment = new Decimal(1);
        tx_Floor.Value = new Decimal(0);

        //tx_Floor = new TextBox();
        //tx_Floor.Text = "";
        //tx_Floor.Location = new System.Drawing.Point(250, 136);
        //tx_Floor.Size = new System.Drawing.Size(200, 20);
        //tx_Floor.Font = new System.Drawing.Font("Arial", 10F);
        //tx_Floor.Multiline = false; // multi line
        //tx_Floor.MaxLength = 100;
        //tx_Floor.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        //tx_Floor.WordWrap = false;
        //tx_Floor.TextChanged += new EventHandler(TextBox_TextChanged);


        appartemntNumber = new Label();
        appartemntNumber.Name = "Apartment Number";
        appartemntNumber.Text = "Apartment Number";
        appartemntNumber.Location = new System.Drawing.Point(16, 166);
        appartemntNumber.Size = new System.Drawing.Size(200, 20);
        appartemntNumber.Font = new System.Drawing.Font("Arial", 10F);
        appartemntNumber.TextAlign = ContentAlignment.MiddleLeft;

        tx_AppartemntNumber = new NumericUpDown();
        tx_AppartemntNumber.Location = new System.Drawing.Point(250, 166);
        tx_AppartemntNumber.Size = new System.Drawing.Size(200, 20);
        tx_AppartemntNumber.Font = new System.Drawing.Font("Arial", 10F);
        tx_AppartemntNumber.Minimum = new Decimal(0);
        tx_AppartemntNumber.Maximum = new Decimal(999);
        tx_AppartemntNumber.Increment = new Decimal(1);
        tx_AppartemntNumber.Value = new Decimal(0);

        //tx_AppartemntNumber = new TextBox();
        //tx_AppartemntNumber.Text = "";
        //tx_AppartemntNumber.Location = new System.Drawing.Point(250, 166);
        //tx_AppartemntNumber.Size = new System.Drawing.Size(200, 20);
        //tx_AppartemntNumber.Font = new System.Drawing.Font("Arial", 10F);
        //tx_AppartemntNumber.Multiline = false; // multi line
        //tx_AppartemntNumber.MaxLength = 100;
        //tx_AppartemntNumber.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        //tx_AppartemntNumber.WordWrap = false;
        //tx_AppartemntNumber.TextChanged += new EventHandler(TextBox_TextChanged);


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
        //s_NumberOfRooms.DecimalPlaces = 0;
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

        length = new Label();
        length.Name = "Length";
        length.Text = "Length";
        length.Location = new System.Drawing.Point(350, 60);
        length.Size = new System.Drawing.Size(50, 20);
        length.Font = new System.Drawing.Font("Arial", 10F);
        length.TextAlign = ContentAlignment.MiddleLeft;

        area = new Label();
        area.Name = "Area";
        area.Text = "Area";
        area.Location = new System.Drawing.Point(475, 60);
        area.Size = new System.Drawing.Size(50, 20);
        area.Font = new System.Drawing.Font("Arial", 10F);
        area.TextAlign = ContentAlignment.MiddleLeft;

        //totalArea = TotalArea(1);

        groupScroll = new GroupBox();
        groupScroll.Location = new System.Drawing.Point(0, 85);
        groupScroll.Size = new System.Drawing.Size(575, 185);

        scrollPanel = new Panel();
        scrollPanel.Size = new System.Drawing.Size(575, 400);

        scrollBar = new VScrollBar();
        scrollBar.LargeChange = 200;
        scrollBar.Location = new System.Drawing.Point(560, 0);
        scrollBar.Minimum = 0;
        scrollBar.Maximum = 400;
        scrollBar.Enabled = false;
        scrollBar.Size = new System.Drawing.Size(13, 177);
        scrollBar.ValueChanged += new System.EventHandler(scrollBar_ValueChanged);


        //House

        //GroupBox with radio button
        rb_Private = new RadioButton();
        rb_Private.Text = HouseType.Private.ToString();
        rb_Private.Checked = false;
        rb_Private.Location = new System.Drawing.Point(16, 16);
        rb_Private.Size = new System.Drawing.Size(120, 20);
        rb_Private.Click += new System.EventHandler(RadioButton_Click);
        rb_MultiStorey = new RadioButton();
        rb_MultiStorey.Text = HouseType.MultiStorey.ToString();
        rb_MultiStorey.Checked = true;
        rb_MultiStorey.Location = new System.Drawing.Point(16, 36);
        rb_MultiStorey.Size = new System.Drawing.Size(120, 20);
        rb_MultiStorey.Click += new System.EventHandler(RadioButton_Click);

        houseType = new GroupBox();
        houseType.Text = "Choose House Type";
        houseType.Location = new System.Drawing.Point(16, 16);
        houseType.Size = new System.Drawing.Size(160, 60);
        houseType.Font = new System.Drawing.Font("Arial", 10);

        houseType.Controls.AddRange(new Control[]
        {
            rb_Private,
            rb_MultiStorey,
        });


        //ListBox
        lb_MaterialType = new ListBox();
        lb_MaterialType.Items.Clear();
        lb_MaterialType.IntegralHeight = false;
        lb_MaterialType.Location = new System.Drawing.Point(16, 120);
        lb_MaterialType.Size = new System.Drawing.Size(160, 90);
        lb_MaterialType.Items.AddRange(new object[]
        {   MaterialType.Wood.ToString(),
            MaterialType.Block.ToString(),
            MaterialType.Brick.ToString(),
            MaterialType.Panel.ToString(),
            MaterialType.Monolithic.ToString()
        });
        lb_MaterialType.SelectionMode = SelectionMode.One;
        lb_MaterialType.SetSelected(1, true);
        lb_MaterialType.SelectedIndexChanged += new EventHandler(ListBox_SelectedIndexChanged);

        materialType = new Label();
        materialType.Text = "Material Type";
        materialType.Location = new System.Drawing.Point(16, 100);
        materialType.Size = new System.Drawing.Size(100, 20);
        materialType.Font = new System.Drawing.Font("Arial", 10F);
        materialType.TextAlign = ContentAlignment.MiddleLeft;


        serialName = new Label();
        serialName.Text = "Serial Name";
        serialName.Location = new System.Drawing.Point(250, 16);
        serialName.Size = new System.Drawing.Size(100, 20);
        serialName.Font = new System.Drawing.Font("Arial", 10F);
        serialName.TextAlign = ContentAlignment.MiddleLeft;

        tx_serialName = new TextBox();
        tx_serialName.Text = "";
        tx_serialName.Location = new System.Drawing.Point(350, 16);
        tx_serialName.Size = new System.Drawing.Size(200, 20);
        tx_serialName.Font = new System.Drawing.Font("Arial", 10F);
        tx_serialName.Multiline = false; // multi line
        tx_serialName.MaxLength = 100;
        tx_serialName.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        tx_serialName.WordWrap = false;
        //tx_serialName.TextChanged += new EventHandler(TextBox_TextChanged);


        serialNumber = new Label();
        serialNumber.Text = "Serial Number";
        serialNumber.Location = new System.Drawing.Point(250, 66);
        serialNumber.Size = new System.Drawing.Size(100, 20);
        serialNumber.Font = new System.Drawing.Font("Arial", 10F);
        serialNumber.TextAlign = ContentAlignment.MiddleLeft;

        tx_SerialNumber = new NumericUpDown();
        tx_SerialNumber.Location = new System.Drawing.Point(350, 66);
        tx_SerialNumber.Size = new System.Drawing.Size(200, 20);
        tx_SerialNumber.Font = new System.Drawing.Font("Arial", 10F);
        tx_SerialNumber.Minimum = new Decimal(0);
        tx_SerialNumber.Maximum = new Decimal(9999);
        tx_SerialNumber.Increment = new Decimal(1);
        tx_SerialNumber.Value = new Decimal(0);

        //tx_SerialNumber = new TextBox();
        //tx_SerialNumber.Text = "";
        //tx_SerialNumber.Location = new System.Drawing.Point(350, 66);
        //tx_SerialNumber.Size = new System.Drawing.Size(200, 20);
        //tx_SerialNumber.Font = new System.Drawing.Font("Arial", 10F);
        //tx_SerialNumber.Multiline = false; // multi line
        //tx_SerialNumber.MaxLength = 100;
        //tx_SerialNumber.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        //tx_SerialNumber.WordWrap = false;
        //tx_SerialNumber.TextChanged += new EventHandler(TextBox_TextChanged);

        yers = new Label();
        yers.Text = "Yers";
        yers.Location = new System.Drawing.Point(250, 116);
        yers.Size = new System.Drawing.Size(100, 20);
        yers.Font = new System.Drawing.Font("Arial", 10F);
        yers.TextAlign = ContentAlignment.MiddleLeft;

        tx_Yers = new NumericUpDown();
        tx_Yers.Location = new System.Drawing.Point(350, 116);
        tx_Yers.Size = new System.Drawing.Size(200, 20);
        tx_Yers.Font = new System.Drawing.Font("Arial", 10F);
        tx_Yers.Minimum = new Decimal(1800);
        tx_Yers.Maximum = new Decimal(2800);
        tx_Yers.Increment = new Decimal(1);
        tx_Yers.Value = new Decimal(1800);

        //tx_Yers = new TextBox();
        //tx_Yers.Text = "";
        //tx_Yers.Location = new System.Drawing.Point(350, 116);
        //tx_Yers.Size = new System.Drawing.Size(200, 20);
        //tx_Yers.Font = new System.Drawing.Font("Arial", 10F);
        //tx_Yers.Multiline = false; // multi line
        //tx_Yers.MaxLength = 100;
        //tx_Yers.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        //tx_Yers.WordWrap = false;
        //tx_Yers.TextChanged += new EventHandler(TextBox_TextChanged);


        floors = new Label();
        floors.Text = "Number of Flors";
        floors.Location = new System.Drawing.Point(250, 166);
        floors.Size = new System.Drawing.Size(100, 40);
        floors.Font = new System.Drawing.Font("Arial", 10F);
        floors.TextAlign = ContentAlignment.MiddleLeft;

        tx_Floors = new NumericUpDown();
        tx_Floors.Location = new System.Drawing.Point(350, 166);
        tx_Floors.Size = new System.Drawing.Size(200, 20);
        tx_Floors.Font = new System.Drawing.Font("Arial", 10F);
        tx_Floors.Minimum = new Decimal(0);
        tx_Floors.Maximum = new Decimal(999);
        tx_Floors.Increment = new Decimal(1);
        tx_Floors.Value = new Decimal(0);

        //tx_Floors = new TextBox();
        //tx_Floors.Text = "";
        //tx_Floors.Location = new System.Drawing.Point(350, 166);
        //tx_Floors.Size = new System.Drawing.Size(200, 20);
        //tx_Floors.Font = new System.Drawing.Font("Arial", 10F);
        //tx_Floors.Multiline = false; // multi line
        //tx_Floors.MaxLength = 100;
        //tx_Floors.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        //tx_Floors.WordWrap = false;
        //tx_Floors.TextChanged += new EventHandler(TextBox_TextChanged);

        //Controls.Add(houseType);
        OneRoomControl();
        this.apartment = apartment;

        if (isOld)
        {
            insertApartamentData();
        }

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
        //tb_Rooms.Controls.Add(totalArea);
        

        groupScroll.Controls.Add(scrollBar);
        groupScroll.Controls.Add(scrollPanel);
        tb_Rooms.Controls.Add(groupScroll);

        tc_Main.TabPages.Add(tb_Rooms);
        //tb_Rooms.Controls.Add(button1);

        //tab - House
        tb_House = new TabPage();
        tb_House.Name = "House";
        tb_House.Text = "House";
        tb_House.Font = new Font("Verdana", 12);
        tb_House.Width = 590;
        tb_House.Height = 300;

        tb_House.Controls.Add(lb_MaterialType);
        tb_House.Controls.Add(materialType);
        tb_House.Controls.Add(houseType);
        tb_House.Controls.Add(serialName);
        tb_House.Controls.Add(tx_serialName);
        tb_House.Controls.Add(serialNumber);
        tb_House.Controls.Add(tx_SerialNumber);
        tb_House.Controls.Add(floors);
        tb_House.Controls.Add(tx_Floors);
        tb_House.Controls.Add(yers);
        tb_House.Controls.Add(tx_Yers);

        tc_Main.TabPages.Add(tb_House);


        Controls.Add(tc_Main);
    }

    private void insertApartamentData()
    {
        tx_Credit.Text = Convert.ToString(apartment.Price);
        inCredit.Checked = apartment.InCredit;
        months.Text = "Number of Months                                 " + Convert.ToUInt32(apartment.Months);
        creditRate.Text = "Credit Rate                                            " + Convert.ToUInt32(apartment.CreditRate) + "%";
        monthlyPay.Text = "Monthly Pay                                           " + Decimal.Round(apartment.MonthlyPay, 2);
        trackBar.Value = apartment.Months;


        tx_City.Text = apartment.Adress.City;
        tx_StreetName.Text = apartment.Adress.StreetName;
        tx_StreetNumber.Value = Convert.ToDecimal(apartment.Adress.StreetNumber);
        tx_HoseNumber.Value = Convert.ToDecimal(apartment.Adress.HouseNumber);
        tx_Floor.Value = Convert.ToDecimal(apartment.Adress.Floor);
        tx_AppartemntNumber.Value = Convert.ToDecimal(apartment.Adress.AppartemntNumber);


        switch (Convert.ToString(apartment.House.MaterialType))
        {
            case ("Wood"):
                lb_MaterialType.SetSelected(0, true);
                break;

            case ("Block"):
                lb_MaterialType.SetSelected(1, true);
                break;

            case ("Brick"):
                lb_MaterialType.SetSelected(2, true);
                break;

            case ("Panel"):
                lb_MaterialType.SetSelected(3, true);
                break;

            case ("Monolithic"):
                lb_MaterialType.SetSelected(4, true);
                break;
        }

        rb_Private.Checked = false;
        rb_MultiStorey.Checked = false;

        if (rb_Private.Text.ToString() == Convert.ToString(apartment.House.HouseType)) rb_Private.Checked = true;
        else rb_MultiStorey.Checked = true;


        tx_serialName.Text = apartment.House.SerialName;
        tx_SerialNumber.Value = Convert.ToDecimal(apartment.House.SerialNumber);
        tx_Yers.Value = Convert.ToDecimal(apartment.House.Yers);
        tx_Floors.Value = Convert.ToDecimal(apartment.House.Floors);

        //Room data
        scrollPanel.Controls.Remove(totalArea);
        totalArea.Dispose();
        //Text = Text + " In Insert ";

        for (int i = 0; i < (int)s_NumberOfRooms.Value; i++)
        {
            scrollPanel.Controls.Remove(romControler[i].CB_Room);
            scrollPanel.Controls.Remove(romControler[i].CalcArea);
            scrollPanel.Controls.Remove(romControler[i].TX_Width);
            scrollPanel.Controls.Remove(romControler[i].TX_Length);

            romControler[i].CB_Room.Dispose();
            romControler[i].CalcArea.Dispose();
            romControler[i].TX_Width.Dispose();
            romControler[i].TX_Length.Dispose();

            romControler.RemoveAt(i);
        }

        //s_NumberOfRooms.Value = Convert.ToDecimal(apartment.Rooms.NumberOfRooms);
        s_NumberOfRooms.Text = Convert.ToString(apartment.Rooms.NumberOfRooms);

        romControler = new List<RomControler>();

        for (int i = 0; i < (int)apartment.Rooms.Room.Count; i++)
        {

            RomControler room = new RomControler(35 * i);
            switch (Convert.ToString(apartment.Rooms.Room[i].RoomName))
            {
                case ("Kitchen"):
                    room.CB_Room.Text = room.CB_Room.Items[0].ToString();
                    break;

                case ("EntranceHall"):
                    room.CB_Room.Text = room.CB_Room.Items[1].ToString();
                    break;

                case ("Hall"):
                    room.CB_Room.Text = room.CB_Room.Items[2].ToString();
                    break;

                case ("Bedroom"):
                    room.CB_Room.Text = room.CB_Room.Items[3].ToString();
                    break;

                case ("Restroom"):
                    room.CB_Room.Text = room.CB_Room.Items[4].ToString();
                    break;

                case ("Bath"):
                    room.CB_Room.Text = room.CB_Room.Items[5].ToString();
                    break;
            }

            room.TX_Width.Value = apartment.Rooms.Room[i].SideLength1;
            room.TX_Length.Value = apartment.Rooms.Room[i].SideLength2;
            room.CalcArea.Text = Convert.ToString(apartment.Rooms.Room[i].Area);
            romControler.Add(room);

            scrollPanel.Controls.Add(romControler[i].CB_Room);
            scrollPanel.Controls.Add(romControler[i].CalcArea);
            scrollPanel.Controls.Add(romControler[i].TX_Width);
            scrollPanel.Controls.Add(romControler[i].TX_Length);
        }

        scrollPanel.Size = new System.Drawing.Size(575, 35 * (int)(s_NumberOfRooms.Value) + 400);

        if ((int)(s_NumberOfRooms.Value) * 45 > 200)
        {
            scrollBar.Maximum = (int)(s_NumberOfRooms.Value) * 45;
            scrollBar.Enabled = true;
        }
        else
        {
            scrollBar.Enabled = false;
        }

        totalArea = TotalArea((int)apartment.Rooms.Room.Count);
        scrollPanel.Controls.Add(totalArea);
        DialogApartment.changeArea();
    }


    private void saveApartment(object sender, System.EventArgs e)
    {
        apartment.Price = Convert.ToDecimal(tx_Credit.Text);
        apartment.InCredit = inCredit.Checked;
        apartment.CreditRate = (trackBar.Value > 0) ? Convert.ToDecimal(trackBar.Value)/10 : 0;
        apartment.MonthlyPay = (trackBar.Value > 0) 
            ? (Convert.ToDecimal(tx_Credit.Text) * Convert.ToDecimal(trackBar.Value) / 10 / 100 + Convert.ToDecimal(tx_Credit.Text)) / trackBar.Value 
            : 0;
        apartment.Months = Convert.ToInt32(trackBar.Value);

        apartment.Adress = new Adress();
        apartment.Adress.City = tx_City.Text;
        apartment.Adress.StreetName = tx_StreetName.Text;
        apartment.Adress.StreetNumber = Convert.ToInt32(tx_StreetNumber.Text);
        apartment.Adress.HouseNumber = Convert.ToInt32(tx_HoseNumber.Text);
        apartment.Adress.Floor = Convert.ToInt32(tx_Floor.Text);
        apartment.Adress.AppartemntNumber = Convert.ToInt32(tx_AppartemntNumber.Text);


        apartment.Rooms = new Rooms();
        apartment.Rooms.NumberOfRooms = Convert.ToInt32(s_NumberOfRooms.Text);
        apartment.Rooms.Room = new List<Room>();

        foreach(RomControler roomData in romControler)
        {
            Room room = new Room();
            room.RoomName = (RoomName)Enum.Parse(typeof(RoomName), roomData.CB_Room.Text.ToString());
            room.SideLength1 = roomData.TX_Width.Value;
            room.SideLength2 = roomData.TX_Length.Value;
            room.Area = Convert.ToDecimal(roomData.CalcArea.Text);

            apartment.Rooms.Room.Add(room);
        }

        
        apartment.House = new House();
        apartment.House.MaterialType = (MaterialType)Enum.Parse(typeof(MaterialType), lb_MaterialType.SelectedItem.ToString());
        apartment.House.HouseType = (rb_Private.Checked) ? (HouseType)Enum.Parse(typeof(HouseType), rb_Private.Text.ToString()) 
            : (HouseType)Enum.Parse(typeof(HouseType), rb_MultiStorey.Text.ToString());
        apartment.House.SerialName = tx_serialName.Text;
        apartment.House.SerialNumber = Convert.ToInt32(tx_SerialNumber.Value);
        apartment.House.Yers = Convert.ToInt32(tx_Yers.Value);
        apartment.House.Floors = Convert.ToInt32(tx_Floors.Value);

        result = DialogResult.Yes;

        this.DialogResult = DialogResult.OK;
    }

    public Apartment ReturnData()
    {
        return apartment;
    }

    private void Grid_KeyUp_City(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            if (!tx_City.Items.Contains(tx_City.Text))
            {
                tb_Adress.Controls.Remove(tx_City);
                tx_City.Items.Add(tx_City.Text);
                tb_Adress.Controls.Add(tx_City);
            }

        }
        else if (e.KeyCode == Keys.Delete)
        {
            tb_Adress.Controls.Remove(tx_City);
            tx_City.Items.Remove(tx_City.Text);
            tb_Adress.Controls.Add(tx_City);
        }
    }


    private void Grid_KeyUp_Street(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            if (!tx_StreetName.Items.Contains(tx_StreetName.Text))
            {
                tb_Adress.Controls.Remove(tx_StreetName);
                tx_StreetName.Items.Add(tx_StreetName.Text);
                tb_Adress.Controls.Add(tx_StreetName);
            }

        }
        else if (e.KeyCode == Keys.Delete)
        {
            tb_Adress.Controls.Remove(tx_StreetName);
            tx_StreetName.Items.Remove(tx_StreetName.Text);
            tb_Adress.Controls.Add(tx_StreetName);
        }
    }

    private void scrollBar_ValueChanged(object sender, System.EventArgs e)
    {
        scrollPanel.Top = -scrollBar.Value;

    }

    private void SelectRoom(object sender, System.EventArgs e)
    {

    }

    //private void TextBox_TextChanged(object sender, System.EventArgs e)
    //{

    //    //TextBox text = (TextBox)sender;
    //    //apartment.Price = Convert.ToDecimal(text.Text);

    //    //this.Text = "Dialog based application :" +
    //    //m_TextBox.Text.Replace("\r\n", " ");
    //}


    //CheckBox
    private void inCreditClic(object sender, System.EventArgs e)
    {
        months.Enabled = inCredit.Checked;
        creditRate.Enabled = inCredit.Checked;
        monthlyPay.Enabled = inCredit.Checked;
        trackBar.Enabled = inCredit.Checked;
    }

    private void TrackBar_Scroll(object sender, System.EventArgs e)
    {
        int inMonths = trackBar.Value;
        decimal inCreditRate = inMonths / 10;
        string stInMonthlyPay = tx_Credit.Text;
        decimal inMonthlyPay = 0;

        if (stInMonthlyPay.Length > 0 && inMonths != 0)
        {
            inMonthlyPay = (Convert.ToDecimal(tx_Credit.Text) * inCreditRate/100 + Convert.ToDecimal(tx_Credit.Text) ) / inMonths;
        }
        

        //decimal inMonths = Convert.ToDecimal(trackBar.Value);
        //decimal inCreditRate = inMonths / 100;
        //decimal inMonthlyPay = Convert.ToDecimal(cost) * inCreditRate / inMonths;

        months.Text = "Number of Months                                 " + inMonths;
        creditRate.Text = "Credit Rate                                            " + inCreditRate + "%";
        monthlyPay.Text = "Monthly Pay                                           " + Decimal.Round(inMonthlyPay, 2);
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
        //foreach (int idx in lb_MaterialType.SelectedIndices)
        //{
        //    str += "" + idx + " - " + lb_MaterialType.Items[idx] + "\r\n";
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

        totalArea = TotalArea(1);
        scrollPanel.Controls.Add(totalArea);
    }

    private Label TotalArea(Int32 pos)
    {
        Label totalArea = new Label();
        totalArea.Name = "Total Area";
        totalArea.Text = "Total Area            0";
        totalArea.Location = new System.Drawing.Point(340, 0 + 35 * pos);
        totalArea.Size = new System.Drawing.Size(250, 20);
        totalArea.Font = new System.Drawing.Font("Arial", 12F);
        totalArea.TextAlign = ContentAlignment.MiddleLeft;

        return totalArea;
    }

    private void NumericUpDown_ValueChanged(object sender, System.EventArgs e)
    {

        scrollPanel.Controls.Remove(totalArea);
        totalArea.Dispose();

        if (s_NumberOfRooms.Value > romControler.Count)
        {

            romControler.Add(new RomControler(35 * ((int)s_NumberOfRooms.Value - 1)));

            scrollPanel.Controls.Add(romControler[(int)s_NumberOfRooms.Value - 1].CB_Room);
            scrollPanel.Controls.Add(romControler[(int)s_NumberOfRooms.Value - 1].CalcArea);
            scrollPanel.Controls.Add(romControler[(int)s_NumberOfRooms.Value - 1].TX_Width);
            scrollPanel.Controls.Add(romControler[(int)s_NumberOfRooms.Value - 1].TX_Length);

        } else if (s_NumberOfRooms.Value < romControler.Count)
        {

            DialogResult result = MessageBox.Show(
                        "Do you sure that you want to delete last room?",
                        "Approve delete of room",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                        //MessageBoxDefaultButton.Button1,
                        //MessageBoxOptions.DefaultDesktopOnly
                        );

            if (result == DialogResult.Yes)
            {
                scrollPanel.Controls.Remove(romControler[(int)s_NumberOfRooms.Value].CB_Room);
                scrollPanel.Controls.Remove(romControler[(int)s_NumberOfRooms.Value].CalcArea);
                scrollPanel.Controls.Remove(romControler[(int)s_NumberOfRooms.Value].TX_Width);
                scrollPanel.Controls.Remove(romControler[(int)s_NumberOfRooms.Value].TX_Length);

                romControler[(int)s_NumberOfRooms.Value].CB_Room.Dispose();
                romControler[(int)s_NumberOfRooms.Value].CalcArea.Dispose();
                romControler[(int)s_NumberOfRooms.Value].TX_Width.Dispose();
                romControler[(int)s_NumberOfRooms.Value].TX_Length.Dispose();

                romControler.RemoveAt((int)s_NumberOfRooms.Value);
            }
            else s_NumberOfRooms.Value = s_NumberOfRooms.Value + 1;

        }


        scrollPanel.Size = new System.Drawing.Size(575, 35 * (int)(s_NumberOfRooms.Value) + 400);

        if ((int)(s_NumberOfRooms.Value) * 45 > 200)
        {
            scrollBar.Maximum = (int)(s_NumberOfRooms.Value) * 45;
            scrollBar.Enabled = true;
        }
        else
        {
            scrollBar.Enabled = false;
        }


        totalArea = TotalArea((Int32)(s_NumberOfRooms.Value));
        scrollPanel.Controls.Add(totalArea);
        DialogApartment.changeArea();

    }


    private void UI_Closed(object sender, FormClosingEventArgs e)
    {

        if (result != DialogResult.Yes && result != DialogResult.No)
        {
            result = MessageBox.Show(
                            "Do you sure that you want to leave without saving?",
                            "Approve exit",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information
                            );
        }

        if (result == DialogResult.Yes)
        {
            e.Cancel = false;
            Dispose();
        }
        else
        {
            result = DialogResult.None;
            e.Cancel = true;
        }


        //if (result == DialogResult.Yes)
        //{
        //    e.Cancel = false;
        //    Dispose();
        //}
        //else if (result == DialogResult.Yes)
        //{
        //    e.Cancel = true;
        //}
        //else
        //{
        //    result = MessageBox.Show(
        //                "Do you sure that you want to leave without saving?",
        //                "Approve exit",
        //                MessageBoxButtons.YesNo,
        //                MessageBoxIcon.Information
        //                );

        //    if (result == DialogResult.Yes)
        //    {
        //        e.Cancel = false;
        //        Dispose();
        //    }
        //    else e.Cancel = true;

        //}
    }

    private void UI_Closed(object sender, EventArgs e)
    {
        result = MessageBox.Show(
                        "Do you sure that you want to leave without saving?",
                        "Approve exit",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                        );
        if (result == DialogResult.Yes)
        {
            Close();
        }
        
    }

    public static void changeArea()
    {
        decimal summ = 0;
        foreach (RomControler i in romControler)
        {
            summ = summ + Convert.ToDecimal(i.CalcArea.Text);
        }

        totalArea.Text = "Total Area            " + Decimal.Round(summ, 2);
    }
}

class RomControler
{
    private ComboBox cb_Room;
    private Label calcArea;
    private NumericUpDown tx_Width;
    private NumericUpDown tx_Length;

    public RomControler(int incr)
    {

        cb_Room = new ComboBox();
        cb_Room.Items.Clear();
        cb_Room.Location = new System.Drawing.Point(16, 0 + incr);
        cb_Room.Size = new System.Drawing.Size(120, 20);
        cb_Room.DropDownStyle = ComboBoxStyle.DropDown;
        cb_Room.Font = new System.Drawing.Font("Arial", 10F);
        cb_Room.Items.AddRange(new object[]
        {
            RoomName.Kitchen.ToString(),
            RoomName.EntranceHall.ToString(),
            RoomName.Hall.ToString(),
            RoomName.Bedroom.ToString(),
            RoomName.Restroom.ToString(),
            RoomName.Bath.ToString()
        });
        cb_Room.Text = cb_Room.Items[0].ToString();
        //cb_Room.SelectedText += new EventHandler(something);

        //cb_Room.TextChanged += new EventHandler(SelectRoom);

        tx_Width = new NumericUpDown();
        tx_Width.Location = new System.Drawing.Point(175, 0 + incr);
        tx_Width.Size = new System.Drawing.Size(100, 20);
        tx_Width.Font = new System.Drawing.Font("Arial", 10F);
        tx_Width.Minimum = new Decimal(0);
        tx_Width.Maximum = new Decimal(999);
        tx_Width.Increment = new Decimal(1);
        tx_Width.DecimalPlaces = 2;
        tx_Width.Value = new Decimal(0);
        tx_Width.ValueChanged += new EventHandler(WidthLength_ValueChanged);

        //tx_Width = new TextBox();
        //tx_Width.Text = "";
        //tx_Width.Location = new System.Drawing.Point(175, 0 + incr);
        //tx_Width.Size = new System.Drawing.Size(100, 20);
        //tx_Width.Font = new System.Drawing.Font("Arial", 10F);
        //tx_Width.Multiline = false; // multi line
        //tx_Width.MaxLength = 100;
        //tx_Width.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        //tx_Width.WordWrap = false;
        //tx_Width.TextChanged += new EventHandler(TextBox_TextChanged);

        tx_Length = new NumericUpDown();
        tx_Length.Location = new System.Drawing.Point(325, 0 + incr);
        tx_Length.Size = new System.Drawing.Size(100, 20);
        tx_Length.Font = new System.Drawing.Font("Arial", 10F);
        tx_Length.Minimum = new Decimal(0);
        tx_Length.Maximum = new Decimal(999);
        tx_Length.Increment = new Decimal(1);
        tx_Length.DecimalPlaces = 2;
        tx_Length.Value = new Decimal(0);
        tx_Length.ValueChanged += new EventHandler(WidthLength_ValueChanged);

        //tx_Length = new TextBox();
        //tx_Length.Text = "";
        //tx_Length.Location = new System.Drawing.Point(325, 0 + incr);
        //tx_Length.Size = new System.Drawing.Size(100, 20);
        //tx_Length.Font = new System.Drawing.Font("Arial", 10F);
        //tx_Length.Multiline = false; // multi line
        //tx_Length.MaxLength = 100;
        //tx_Length.ScrollBars = ScrollBars.None; //None, Horizontal, Vertical, Both
        //tx_Length.WordWrap = false;
        //tx_Length.TextChanged += new EventHandler(TextBox_TextChanged);

        calcArea = new Label();
        calcArea.Name = "Calc Area";
        calcArea.Text = "0.00";
        calcArea.Location = new System.Drawing.Point(475, 0 + incr);
        calcArea.Size = new System.Drawing.Size(125, 20);
        calcArea.Font = new System.Drawing.Font("Arial", 10F);
        calcArea.TextAlign = ContentAlignment.MiddleLeft;
    }

    private void WidthLength_ValueChanged(object sender, System.EventArgs e)
    {
        calcArea.Text = Convert.ToString(Decimal.Round(tx_Width.Value * tx_Length.Value, 2));
        DialogApartment.changeArea();
    }


    //private void TextBox_TextChanged(object sender, System.EventArgs e)
    //{

    //}

    public ComboBox CB_Room { get { return cb_Room; } set { cb_Room = value; } }
    public Label CalcArea { get { return calcArea; } set { calcArea = value; } }
    public NumericUpDown TX_Width { get { return tx_Width; } set { tx_Width = value; } }
    public NumericUpDown TX_Length { get { return tx_Length; } set { tx_Length = value; } }

}
