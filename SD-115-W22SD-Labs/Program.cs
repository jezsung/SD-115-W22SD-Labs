﻿Hotel hotel = new Hotel("GreatHotel", "999 Wow Avenue");
hotel.Clients = new List<Client>
{
    new Client(0, "Zeri", 111),
    new Client(1, "Zed", 222),
    new Client(2, "Yummi", 333),
    new Client(3, "Hecarim", 444),
};
hotel.Rooms = new List<Room>
{
    new Room("101", 2),
    new Room("102", 3),
    new Room("103", 3),
    new Room("201", 4),
    new Room("202", 4),
};

try
{
    Client client1 = hotel.GetClient(1);
    Console.WriteLine(client1.Name);
    Client client5 = hotel.GetClient(5);
    Console.WriteLine(client5.Name);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    Room room101 = hotel.GetRoom("101");
    Console.WriteLine(room101.Number);
    Room room501 = hotel.GetRoom("501");
    Console.WriteLine(room501.Number);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

hotel.AutomaticReservation(1, 3);

foreach(Room room in hotel.GetVacantRooms())
{
    Console.WriteLine(room.Number);
}

foreach(Client client in hotel.TopThreeClient())
{
    Console.WriteLine(client.Name);
}

class Hotel
{
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Client> Clients { get; set; }
    public List<Room> Rooms { get; set; }
    public List<Reservation> Reservations { get; set; }

    public Hotel(string name, string address)
    {
        Name = name;
        Address = address;
        Clients = new List<Client>();
        Rooms = new List<Room>();
        Reservations = new List<Reservation>();
    }

    public Client GetClient(int clientId)
    {
        return Clients.First((client) => client.Id == clientId);
    }

    public Reservation GetReservation(int id)
    {
        return Reservations.First((reservation) => reservation.Id == id);
    }

    public Room GetRoom(string roomNumber)
    {
        return Rooms.First((room) => room.Number == roomNumber);
    }

    public List<Room> GetVacantRooms()
    {
        return Rooms.Where((room) => !room.Occupied).ToList();
    }

    public List<Client> TopThreeClient()
    {
        return Clients.OrderByDescending((client) => client.Reservations.Count).Take(3).ToList();
    }

    public Reservation AutomaticReservation(int clientId, int occupants)
    {
        Room availableRoom = Rooms.First((room) => room.Capacity >= occupants);
        Client client = GetClient(clientId);
        Reservation reservation = new Reservation(occupants, client, availableRoom);
        Reservations.Add(reservation);
        client.Reservations.Add(reservation);
        availableRoom.Occupied = true;
        availableRoom.Reservations.Add(reservation);
        return reservation;
    }
}


class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CreditCard { get; set; }
    public List<Reservation> Reservations { get; set; }

    public Client(int id, string name, int creditCard)
    {
        Id = id;
        Name = name;
        CreditCard = creditCard;
        Reservations = new List<Reservation>();
    }
}

class Room
{
    public string Number { get; set; }
    public int Capacity { get; set; }
    public bool Occupied { get; set; }
    public List<Reservation> Reservations { get; set; }

    public Room(string number, int capacity)
    {
        Number = number;
        Capacity = capacity;
        Occupied = false;
        Reservations = new List<Reservation>();
    }

}

class Reservation
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Occupants { get; set; }
    public bool IsCurrent { get; set; }
    public Client Client { get; set; }
    public Room Room { get; set; }

    private static int IdCounter = 0;

    public Reservation(int occupants, Client client, Room room)
    {
        Id = IdCounter++;
        Date = DateTime.Now;
        Occupants = occupants;
        IsCurrent = true;
        Client = client;
        Room = room;
    }
}