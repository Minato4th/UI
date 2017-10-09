using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

using myNamespace;

class DialogApartment : Form
{
    private TabControl tc_Main;

    private TabPage tb_Main;
    private TabPage tb_Adress;
    private TabPage tb_Rooms;
    private TabPage tb_House;

    private Button button1;

    public DialogApartment()
    {
        Text = "Appatments - Dialog based application";
        StartPosition = FormStartPosition.Manual;
        Location = new System.Drawing.Point(100, 100);
        Size = new System.Drawing.Size(600, 400);

        Closed += new System.EventHandler(UI_Closed);

        //TabControl
        tc_Main = new TabControl();
        tc_Main.Name = "ApartmentTabs";
        tc_Main.Font = new Font("Georgia", 16);
        tc_Main.Size = new System.Drawing.Size(582, 300);
        //        tc_Main.Dock = DockStyle.Fill;


        button1 = new Button();

        button1.Name = "button1";
        button1.Text = "Click Me";
        button1.Font = new Font("Verdana", 12);
        button1.Width = 100;
        button1.Height = 30;
        button1.Location = new Point(50, 50);


        //tab - Main
        tb_Main = new TabPage();
        tb_Main.Name = "Main";
        tb_Main.Text = "Main";
        tb_Main.Font = new Font("Verdana", 12);
        tb_Main.Width = 590;
        tb_Main.Height = 300;

        tc_Main.TabPages.Add(tb_Main);
        tb_Main.Controls.Add(button1);


        //tab - Adress
        tb_Adress = new TabPage();
        tb_Adress.Name = "Adress";
        tb_Adress.Text = "Adress";
        tb_Adress.Font = new Font("Verdana", 12);
        tb_Adress.Width = 590;
        tb_Adress.Height = 300;

        tc_Main.TabPages.Add(tb_Adress);
        tb_Adress.Controls.Add(button1);


        //tab - Rooms
        tb_Rooms = new TabPage();
        tb_Rooms.Name = "Rooms";
        tb_Rooms.Text = "Rooms";
        tb_Rooms.Font = new Font("Verdana", 12);
        tb_Rooms.Width = 590;
        tb_Rooms.Height = 300;

        tc_Main.TabPages.Add(tb_Rooms);
        tb_Rooms.Controls.Add(button1);

        //tab - House
        tb_House = new TabPage();
        tb_House.Name = "House";
        tb_House.Text = "House";
        tb_House.Font = new Font("Verdana", 12);
        tb_House.Width = 590;
        tb_House.Height = 300;

        tc_Main.TabPages.Add(tb_House);
        tb_House.Controls.Add(button1);

        Controls.Add(tc_Main);

    }


    
    private void UI_Closed(object sender, EventArgs e)
    {
 
    Dispose();
    }
}
