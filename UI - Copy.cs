using System;
using System.Windows.Forms;
using System.Drawing;

using myNamespace;

class UI : Form
{
    private Label m_Label;
    //private LinkLabel m_LinkLabel;
    //private Button m_Button;

    private Appartment appartment;

    public UI()
    {
        Text="Dialog based application";
        StartPosition=FormStartPosition.Manual;
        Location=new System.Drawing.Point(100,100);
        Size =new System.Drawing.Size(600,400);

        appartment = new Appartment();
 
        Closed+=new System.EventHandler(UI_Closed);

        //text
        m_Label = new Label();
        //m_Label.Name = "Label1";
        m_Label.Text = 
            "Adress" + 
            "\n     City: " + appartment.GetAdress().GetCity() +
            "\n     Street Name: " + appartment.GetAdress().GetStreetName() +
            "\n     Street Number: " + appartment.GetAdress().GetStreetNumber() +
            "\n     Flor Number : " + appartment.GetAdress().GetFloor() +
            "\n     Appartment Number : " + appartment.GetAdress().GetAppartemntNumber() +
            "\n" +
            "House" +
            "\n     Serial Name: " + appartment.GetHouse().GetSerialName() +
            "\n     Serial Number: " + appartment.GetHouse().GetSerialNumber() +
            "\n     Serial Number: " + appartment.GetHouse().GetYers() +
            "\n     Flors: " + appartment.GetHouse().GetFloors() +
            "\n" +
            "Rooms" +
            "\n     Number of Rooms : " + appartment.GetRooms().GetNumberOfRooms() +
            "\n     Room : " + appartment.GetRooms().GetRoom()[0].GetName().ToString() +
            "\n     Side1 : " + appartment.GetRooms().GetRoom()[0].GetSideLength1().ToString() +
            "\n     Side2 : " + appartment.GetRooms().GetRoom()[0].GetSideLength2().ToString() +
            "\n     Area : " + appartment.GetRooms().GetRoom()[0].GetArea().ToString();

        m_Label.Location = new System.Drawing.Point(0, 0);
        m_Label.Size = new System.Drawing.Size(600, 600);
        //m_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //m_Label.Font = new System.Drawing.Font("Arial", 10F, FontStyle.Italic | FontStyle.Bold);
        //m_Label.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0);

        //Link
        //m_LinkLabel = new LinkLabel();
        //m_LinkLabel.Name = "Label2";
        //m_LinkLabel.Text = "www.microsoft.com";
        //m_LinkLabel.Location = new System.Drawing.Point(16, 40);
        //m_LinkLabel.Size = new System.Drawing.Size(120, 16);
        //m_LinkLabel.TextAlign = ContentAlignment.MiddleLeft;

        //m_LinkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(Label2_LinkClicked);

        //Button
        //m_Button = new Button();
        //m_Button.Text = "Press me";
        //m_Button.Location = new System.Drawing.Point(18, 70);
        //m_Button.Size = new System.Drawing.Size(100, 24);
        //m_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        //m_Button.Click += new System.EventHandler(Button_Click);
        


        Controls.Add(m_Label);
        //Controls.Add(m_LinkLabel);
        //Controls.Add(m_Button);
    }

    //private void Button_Click(object sender, System.EventArgs e)
    //{
    //    MessageBox.Show("Button was pressed !",
    //                    "Information",
    //                    MessageBoxButtons.OK,
    //                    MessageBoxIcon.Information);
    //}

    //private void Label2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    //{
    //    m_LinkLabel.Links[m_LinkLabel.Links.IndexOf(e.Link)].Visited = true;
    //    System.Diagnostics.Process.Start(m_LinkLabel.Text);
    //}

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
