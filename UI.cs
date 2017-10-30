using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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

    private Dictionary<String, Apartment> apartamentMap;

    private Apartment apartment;

    private ListViewItem all;

    private BinaryFormatter formatter;

    public UI()
    {
        Text = "Apatments - Dialog based application";
        StartPosition = FormStartPosition.Manual;
        Location = new System.Drawing.Point(100, 100);
        Size = new System.Drawing.Size(600, 400);

        apartment = new Apartment();
        apartamentMap = new Dictionary<String, Apartment>();

        Closed += new System.EventHandler(UI_Closed);

        //Text
        m_Label = new Label();
        m_Label.Name = "Main Menu";
        m_Label.Text = "Choose the action";
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

        b_Edit.Click += new System.EventHandler(editAppartment);

        Controls.Add(b_Edit);


        //
        b_Delete = new Button();
        b_Delete.Name = "Delete";
        b_Delete.Text = "Delete";
        b_Delete.Location = new System.Drawing.Point(260, 60);
        b_Delete.Size = new System.Drawing.Size(90, 25);
        b_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        b_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;

        b_Delete.Click += new System.EventHandler(deleteAppartment);

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

        b_Save.Click += new System.EventHandler(SerializeData);

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

        b_Load.Click += new System.EventHandler(DeserializeData);

        Controls.Add(b_Load);

        //ComboBox
        cb_Apartments = new ComboBox();
        cb_Apartments.Items.Clear();
        cb_Apartments.Location = new System.Drawing.Point(370, 60);
        cb_Apartments.Size = new System.Drawing.Size(160, 20);
        cb_Apartments.DropDownStyle = ComboBoxStyle.DropDown;
        cb_Apartments.Font = new System.Drawing.Font("Arial", 12F);
        //cb_Apartments.Items.AddRange(new object[]
        //{   "Red",
        //    "Orange",
        //    "Yellow",
        //    "Green",
        //    "Cyan",
        //    "Blue",
        //    "Magenta"});

        cb_Apartments.TextChanged += new EventHandler(SelectApartment);

        Controls.Add(cb_Apartments);

        //List Apartment
        lw_Apartment = new ListView();
        //lw_Apartment.Dock = DockStyle.Top;
        lw_Apartment.Location = new System.Drawing.Point(25, 100);
        lw_Apartment.Size = new System.Drawing.Size(525, 200);
        lw_Apartment.View = View.Details;
        lw_Apartment.Columns.Add("Parametrs", 195, HorizontalAlignment.Left);
        lw_Apartment.Columns.Add("Values", 305, HorizontalAlignment.Left);
        
        Controls.Add(lw_Apartment);

    }

    private void SerializeData(object sender, System.EventArgs e)
    {
        formatter = new BinaryFormatter();

        using (FileStream fs = new FileStream("apartment.dat", FileMode.OpenOrCreate))
        {
            formatter.Serialize(fs, apartamentMap);
        }
    }

    private void DeserializeData(object sender, System.EventArgs e)
    {
        formatter = new BinaryFormatter();

        using (FileStream fs = new FileStream("apartment.dat", FileMode.OpenOrCreate))
        {
            apartamentMap = (Dictionary<String, Apartment>)formatter.Deserialize(fs);

            cb_Apartments.Items.Clear();
            foreach (KeyValuePair<string, Apartment> entry in apartamentMap)
            {
                cb_Apartments.Items.Add(entry.Key);
                //entry.Value or entry.Key

            }
            cb_Apartments.Text = "";
            Controls.Remove(cb_Apartments);
            Controls.Add(cb_Apartments);
        }
    }

    private void SelectApartment(object sender, System.EventArgs e)
    {
        lw_Apartment.Items.Clear();
        if (apartamentMap.Count > 0 && apartamentMap.ContainsKey(cb_Apartments.Text))
        {

            Apartment apartment = apartamentMap[cb_Apartments.Text];
            all = new ListViewItem("Apartment Name");
            all.SubItems.Add(cb_Apartments.Text);
            lw_Apartment.Items.Add(all);

            all = new ListViewItem("Money");
            lw_Apartment.Items.Add(all);

            all = new ListViewItem("Price");
            all.SubItems.Add(Convert.ToString(apartment.Price));
            lw_Apartment.Items.Add(all);

            
            if (apartment.InCredit)
            {
                all = new ListViewItem("In Credit");
                all.SubItems.Add("Yes");
                lw_Apartment.Items.Add(all);

                all = new ListViewItem("Credit Month");
                all.SubItems.Add(Convert.ToString(apartment.Months));
                lw_Apartment.Items.Add(all);

                all = new ListViewItem("Credit Rate");
                all.SubItems.Add(Convert.ToString(Decimal.Round(apartment.CreditRate, 2)) + "%");
                lw_Apartment.Items.Add(all);

                all = new ListViewItem("Monthly Pay");
                all.SubItems.Add(Convert.ToString(Decimal.Round(apartment.MonthlyPay, 2)));
                lw_Apartment.Items.Add(all);
            }
            else
            {
                all = new ListViewItem("In Credit");
                all.SubItems.Add("No");
                lw_Apartment.Items.Add(all);
            }


            all = new ListViewItem("Adress");
            lw_Apartment.Items.Add(all);

            all = new ListViewItem("City");
            all.SubItems.Add(Convert.ToString(apartment.Adress.City));
            lw_Apartment.Items.Add(all);

            all = new ListViewItem("Street Name");
            all.SubItems.Add(Convert.ToString(apartment.Adress.StreetName));
            lw_Apartment.Items.Add(all);

            all = new ListViewItem("Street Number");
            all.SubItems.Add(Convert.ToString(apartment.Adress.StreetNumber));
            lw_Apartment.Items.Add(all);

            all = new ListViewItem("House Number");
            all.SubItems.Add(Convert.ToString(apartment.Adress.HouseNumber));
            lw_Apartment.Items.Add(all);

            all = new ListViewItem("Floor");
            all.SubItems.Add(Convert.ToString(apartment.Adress.Floor));
            lw_Apartment.Items.Add(all);

            all = new ListViewItem("Appartemnt Number");
            all.SubItems.Add(Convert.ToString(apartment.Adress.AppartemntNumber));
            lw_Apartment.Items.Add(all);

            all = new ListViewItem("Rooms");
            lw_Apartment.Items.Add(all);

            all = new ListViewItem("Number of Rooms");
            all.SubItems.Add(Convert.ToString(apartment.Rooms.NumberOfRooms));
            lw_Apartment.Items.Add(all);

            decimal generalArea = 0;
            foreach (Room roomData in apartment.Rooms.Room)
            {
                all = new ListViewItem();
                lw_Apartment.Items.Add(all);

                all = new ListViewItem();
                all.SubItems.Add(Convert.ToString(roomData.RoomName));
                lw_Apartment.Items.Add(all);

                all = new ListViewItem("Length");
                all.SubItems.Add(Convert.ToString(roomData.SideLength1));
                lw_Apartment.Items.Add(all);

                all = new ListViewItem("Width");
                all.SubItems.Add(Convert.ToString(roomData.SideLength2));
                lw_Apartment.Items.Add(all);

                all = new ListViewItem("Area");
                all.SubItems.Add(Convert.ToString(Decimal.Round(roomData.Area, 2)));
                lw_Apartment.Items.Add(all);

                generalArea += roomData.Area;
            }

            all = new ListViewItem("General Area");
            all.SubItems.Add(Convert.ToString(generalArea));
            lw_Apartment.Items.Add(all);

            all = new ListViewItem("House information");
            lw_Apartment.Items.Add(all);

            all = new ListViewItem("Material Type");
            all.SubItems.Add(Convert.ToString(apartment.House.MaterialType));
            lw_Apartment.Items.Add(all);

            all = new ListViewItem("House Type");
            all.SubItems.Add(Convert.ToString(apartment.House.HouseType));
            lw_Apartment.Items.Add(all);

            all = new ListViewItem("Serial Name");
            all.SubItems.Add(Convert.ToString(apartment.House.SerialName));
            lw_Apartment.Items.Add(all);

            all = new ListViewItem("Serial Number");
            all.SubItems.Add(Convert.ToString(apartment.House.SerialNumber));
            lw_Apartment.Items.Add(all);

            all = new ListViewItem("Year of construction");
            all.SubItems.Add(Convert.ToString(apartment.House.Yers));
            lw_Apartment.Items.Add(all);

            all = new ListViewItem("Floors");
            all.SubItems.Add(Convert.ToString(apartment.House.Floors));
            lw_Apartment.Items.Add(all);

        }
        
    }

    //Create Button
    private void createAppartment(object sender, System.EventArgs e)
    {

        if (cb_Apartments.Text.Equals(""))
        {
            messageBoxTemplate("Please insert Name in box", "Name wasn't inserted");

        } else if(apartamentMap.ContainsKey(cb_Apartments.Text))
        {
            messageBoxTemplate("Please insert new name", "Name alredy exist");
        }
        else createAp();

    }

    private void messageBoxTemplate(string text, string caption)
    {
        DialogResult result = MessageBox.Show(
                        text,
                        caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        //MessageBoxDefaultButton.Button1,
                        //MessageBoxOptions.DefaultDesktopOnly
                        );
    }

    private void addingEditingAp(DialogApartment dialog_Apartment, bool add)
    {
        if (dialog_Apartment.DialogResult == DialogResult.OK)
        {
            if(add)apartamentMap.Add(cb_Apartments.Text, dialog_Apartment.ReturnData());
            else apartamentMap[cb_Apartments.Text] = dialog_Apartment.ReturnData();

            cb_Apartments.Items.Clear();
            foreach (KeyValuePair<string, Apartment> entry in apartamentMap)
            {
                cb_Apartments.Items.Add(entry.Key);
                //entry.Value or entry.Key

            }
            cb_Apartments.Text = "";
            Controls.Remove(cb_Apartments);
            Controls.Add(cb_Apartments);
        }
        else
        {
            cb_Apartments.Text = "";
        }
        lw_Apartment.Items.Clear();
    }

    private void createAp()
    {
        DialogApartment dialog_Apartment = new DialogApartment(new Apartment(), false);
        dialog_Apartment.ShowDialog();

        addingEditingAp(dialog_Apartment, true);
    }

    private void editAppartment(object sender, System.EventArgs e)
    {
        if (cb_Apartments.Text.Equals(""))
        {
            //messageBoxTemplate(Convert.ToString(cb_Apartments.Text.Equals("")), cb_Apartments.Text);
            messageBoxTemplate("Please insert Name in box", "Name wasn't inserted");

        }
        else editAp();
    }

    private void editAp()
    {
        DialogApartment dialog_Apartment = new DialogApartment(apartamentMap[cb_Apartments.Text], true);
        dialog_Apartment.ShowDialog();

        addingEditingAp(dialog_Apartment, false);
    }


    private void deleteAppartment(object sender, System.EventArgs e)
    {
        if (cb_Apartments.Text.Equals(""))
        {
            messageBoxTemplate("Please insert Name in box", "Name wasn't inserted");
        }
        else
        {
            DialogResult result = MessageBox.Show(
                        "Do you sure that you want to delete Apartment?",
                        "Approve delete of Apartment",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                        );

            if (result == DialogResult.Yes)
            {
                apartamentMap.Remove(cb_Apartments.Text);
                cb_Apartments.Items.Remove(cb_Apartments.Text);
                cb_Apartments.Text = "";
            }
                
        }
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