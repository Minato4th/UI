using System;
using System.Collections.Generic;

using myNamespace;

namespace myNamespace
{
    class Appartment
    {
        private Adress adress;
        private Rooms rooms;
        private House house;

        public Appartment()
        {
            adress = new Adress();
            adress.City = "Chisinau";
            adress.Floor = 10;
            adress.StreetName = "Stafan";
            adress.StreetNumber = 25;
            adress.HouseNumber = 5;
            adress.AppartemntNumber = 99;

            house = new House();
            house.SerialName = "New";
            house.SerialNumber = 2017;
            house.Yers = 1;
            house.Floors = 15;


            rooms = new Rooms();
            rooms.NumberOfRooms = 2;

            Room room = new Room();
            room.RoomName = RoomName.Hall;
            room.SideLength1 = 10D;
            room.SideLength2 = 20D;
            room.CalculateArea();
            List<Room> list = new List<Room>();
            list.Add(room);
            room.RoomName = RoomName.Restroom;
            list.Add(room);
            rooms.Room = list;

            //adress = new Adress();
            //adress.SetCity("Chisinau");
            //adress.SetFloor(10);
            //adress.SetStreetName("Stafan");
            //adress.SetStreetNumber(25);
            //adress.SetHoseNumber(5);
            //adress.SetAppartemntNumber(99);

            //house = new House();
            //house.SetSerialName("New");
            //house.SetSerialNumber(2017);
            //house.SetYers(1);
            //house.SetFloors(15);


            //rooms = new Rooms();
            //rooms.SetNumberOfRooms(2);

            //Room room = new Room();
            //room.SetName(RoomName.Hall);
            //room.SetSideLength1(10D);
            //room.SetSideLength2(20D);
            //room.CalculateArea();
            //List<Room> list = new List<Room>();
            //list.Add(room);
            //room.SetName(RoomName.Restroom);
            //list.Add(room);
            //rooms.SetRoom(list);


        }

        public Adress Adress{ get{ return adress; } set{ adress = value; } }

        public Rooms Rooms { get { return rooms; } set { rooms = value; } }

        public House House { get { return house; } set { house = value; } }

        //public Adress GetAdress()
        //{
        //    return adress;
        //}

        //public void SetAdress(Adress value)
        //{
        //    adress = value;
        //}

        //public Rooms GetRooms()
        //{
        //    return rooms;
        //}

        //public void SetRooms(Rooms value)
        //{
        //    rooms = value;
        //}

        //public House GetHouse()
        //{
        //    return house;
        //}

        //public void SetHouse(House value)
        //{
        //    house = value;
        //}

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    class Rooms
    {
        private int numberOfRooms;
        private List<Room> room;


        public Rooms(){}

        public int NumberOfRooms { get { return numberOfRooms; } set { numberOfRooms = value; } }

        public List<Room> Room { get { return room; } set { room = value; } }

        //public int GetNumberOfRooms()
        //{
        //    return numberOfRooms;
        //}

        //public void SetNumberOfRooms(int value)
        //{
        //    numberOfRooms = value;
        //}

        //public List<Room> GetRoom()
        //{
        //    return room;
        //}

        //public void SetRoom(List<Room> value)
        //{
        //    room = value;
        //}

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    class Room
    {
        private RoomName name;
        private double sideLength1;
        private double sideLength2;
        private double area;

        public Room() {}

        public RoomName RoomName { get { return name; } set { name = value; } }

        public double SideLength1 { get { return sideLength1; } set { sideLength1 = value; } }

        public double SideLength2 { get { return sideLength2; } set { sideLength2 = value; } }

        public double Area { get { return area; } set { area = value; } }

        //public RoomName GetName()
        //{
        //    return name;
        //}

        //public void SetName(RoomName value)
        //{
        //    name = value;
        //}

        //public double GetSideLength1()
        //{
        //    return sideLength1;
        //}

        //public void SetSideLength1(double value)
        //{
        //    sideLength1 = value;
        //}

        //public double GetSideLength2()
        //{
        //    return sideLength2;
        //}

        //public void SetSideLength2(double value)
        //{
        //    sideLength2 = value;
        //}

        //public double GetArea()
        //{
        //    return area;
        //}

        public void CalculateArea()
        {
            area = sideLength1 * sideLength2;
        }


    }

    enum RoomName
    {
        Kitchen,
        EntranceHall,
        Hall,
        Bedroom,
        Restroom,
        Bath
    }

    class Adress
    {
        private String city;
        private String streetName;
        private int streetNumber;
        private int hoseNumber;
        private int floor;
        private int appartemntNumber;

        public Adress(){}

        public String City { get { return city; } set { city = value; } }

        public String StreetName { get { return streetName; } set { streetName = value; } }

        public int StreetNumber { get { return streetNumber; } set { streetNumber = value; } }

        public int HouseNumber { get { return hoseNumber; } set { hoseNumber = value; } }

        public int Floor { get { return floor; } set { floor = value; } }

        public int AppartemntNumber { get { return appartemntNumber; } set { appartemntNumber = value; } }

        //public string GetCity()
        //{
        //    return city;
        //}

        //public void SetCity(string value)
        //{
        //    city = value;
        //}

        //public string GetStreetName()
        //{
        //    return streetName;
        //}

        //public void SetStreetName(string value)
        //{
        //    streetName = value;
        //}

        //public int GetStreetNumber()
        //{
        //    return streetNumber;
        //}

        //public void SetStreetNumber(int value)
        //{
        //    streetNumber = value;
        //}

        //public int GetHoseNumber()
        //{
        //    return hoseNumber;
        //}

        //public void SetHoseNumber(int value)
        //{
        //    hoseNumber = value;
        //}

        //public int GetFloor()
        //{
        //    return floor;
        //}

        //public void SetFloor(int value)
        //{
        //    floor = value;
        //}

        //public int GetAppartemntNumber()
        //{
        //    return appartemntNumber;
        //}

        //public void SetAppartemntNumber(int value)
        //{
        //    appartemntNumber = value;
        //}
    }

    class House
    {
        private String serialName;
        private int serialNumber;
        private int yers;
        private int floors;

        public String SerialName { get { return serialName; } set { serialName = value; } }

        public int SerialNumber { get { return serialNumber; } set { serialNumber = value; } }

        public int Yers { get { return yers; } set { yers = value; } }

        public int Floors { get { return floors; } set { floors = value; } }

        //public int GetFloors()
        //{
        //    return floors;
        //}

        //public void SetFloors(int value)
        //{
        //    floors = value;
        //}

        //public House()
        //{

        //}

        //public string GetSerialName()
        //{
        //    return serialName;
        //}

        //public void SetSerialName(string value)
        //{
        //    serialName = value;
        //}

        //public int GetSerialNumber()
        //{
        //    return serialNumber;
        //}

        //public void SetSerialNumber(int value)
        //{
        //    serialNumber = value;
        //}

        //public int GetYers()
        //{
        //    return yers;
        //}

        //public void SetYers(int value)
        //{
        //    yers = value;
        //}
    }
}
