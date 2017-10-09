using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

using myNamespace;

class UI : Form
{
    private Label m_Label;
    private Button b_Create;
    private Button b_Delete;
    private Button b_Edit;
    private Button b_Load;
    private Button b_Save;

    private ComboBox cb_Apartments;

    private ListView lw_Apartment;
    private ColumnHeader m_Parameter;
    private ColumnHeader m_Value;

    private Appartment appartment;

    public UI()
    {
        Text = "Appatments - Dialog based application";
        StartPosition = FormStartPosition.Manual;
        Location = new System.Drawing.Point(100, 100);
        Size = new System.Drawing.Size(600, 400);

        appartment = new Appartment();

        Closed += new System.EventHandler(UI_Closed);

        //Text
        m_Label = new Label();
        m_Label.Name = "Main Menu";
        m_Label.Text = "Choice the action";
        m_Label.Location = new System.Drawing.Point(16, 16);
        m_Label.Size = new System.Drawing.Size(500, 40);
        m_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        m_Label.Font = new System.Drawing.Font("Arial", 16F, FontStyle.Bold);
        m_Label.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);

        Controls.Add(m_Label);

        //Buttons
        b_Create = new Button();
        b_Create.Name = "Create";
        b_Create.Text = "Create";
        b_Create.Location = new System.Drawing.Point(40, 60);
        b_Create.Size = new System.Drawing.Size(90, 25);
        b_Create.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        b_Create.FlatStyle = System.Windows.Forms.FlatStyle.Popup;

        b_Create.Click += new System.EventHandler(createAppartment);

        Controls.Add(b_Create);

        //
        b_Edit = new Button();
        b_Edit.Name = "Edit";
        b_Edit.Text = "Edit";
        b_Edit.Location = new System.Drawing.Point(150, 60);
        b_Edit.Size = new System.Drawing.Size(90, 25);
        b_Edit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        b_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;

        b_Edit.Click += new System.EventHandler(createAppartment);

        Controls.Add(b_Edit);


        //
        b_Delete = new Button();
        b_Delete.Name = "Delete";
        b_Delete.Text = "Delete";
        b_Delete.Location = new System.Drawing.Point(260, 60);
        b_Delete.Size = new System.Drawing.Size(90, 25);
        b_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        b_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;

        b_Delete.Click += new System.EventHandler(createAppartment);

        Controls.Add(b_Delete);


        //
        b_Save = new Button();
        b_Save.Name = "Save";
        b_Save.Text = "Save";
        b_Save.Location = new System.Drawing.Point(105, 315);
        b_Save.Size = new System.Drawing.Size(120, 30);
        b_Save.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        b_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        b_Save.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        b_Save.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Bold);
        b_Save.ForeColor = System.Drawing.Color.FromArgb(50, 205, 50);

        b_Save.Click += new System.EventHandler(createAppartment);

        Controls.Add(b_Save);

        //
        b_Load = new Button();
        b_Load.Name = "Load";
        b_Load.Text = "Load";
        b_Load.Location = new System.Drawing.Point(370, 315);
        b_Load.Size = new System.Drawing.Size(120, 30);
        b_Load.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        b_Load.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        b_Load.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        b_Load.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Bold);
        b_Load.ForeColor = System.Drawing.Color.FromArgb(255, 69, 0);

        b_Load.Click += new System.EventHandler(createAppartment);

        Controls.Add(b_Load);

        //ComboBox
        cb_Apartments = new ComboBox();
        cb_Apartments.Items.Clear();
        cb_Apartments.Location = new System.Drawing.Point(370, 60);
        cb_Apartments.Size = new System.Drawing.Size(160, 20);
        cb_Apartments.DropDownStyle = ComboBoxStyle.DropDown;
        cb_Apartments.Font = new System.Drawing.Font("Arial", 12F);
        cb_Apartments.Items.AddRange(new object[]
        {   "Red",
            "Orange",
            "Yellow",
            "Green",
            "Cyan",
            "Blue",
            "Magenta"});

        cb_Apartments.TextChanged += new EventHandler(SelectApartment);

        Controls.Add(cb_Apartments);

        //List Apartment
        lw_Apartment = new ListView();

        ListView m_FilesList = new ListView();

        //lw_Apartment.Dock = DockStyle.Top;
        lw_Apartment.Location = new System.Drawing.Point(50, 100);
        lw_Apartment.Size = new System.Drawing.Size(500, 200);
        lw_Apartment.View = View.Details;
        lw_Apartment.Columns.Add("Parametrs", 195, HorizontalAlignment.Left);
        lw_Apartment.Columns.Add("Values", 295, HorizontalAlignment.Left);

        Controls.Add(lw_Apartment);

    }

    private void SelectApartment(object sender, System.EventArgs e)
    {

    }

    private void createAppartment(object sender, System.EventArgs e)
    {
        DialogApartment dialog_Apartment = new DialogApartment();
        dialog_Apartment.ShowDialog();
    }

    
    private void UI_Closed(object sender, EventArgs e)
    {
 
    Dispose();
    }
}


class Starter
{

    public static void Main()
    {

        UI ui = new UI();
        ui.ShowDialog();

    }
}
