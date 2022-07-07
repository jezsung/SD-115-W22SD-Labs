namespace SD_115_W22SD_Labs.Models
{
    static class Hotel
    {
        public static List<Room> Rooms { get; set; } = new List<Room>
        {
            new Room(101, 2, 1),
            new Room(102, 2, 1),
            new Room(103, 3, 3),
            new Room(104, 3, 0),
            new Room(105, 4, 0),
            new Room(201, 3, 2),
            new Room(202, 3, 0),
            new Room(203, 4, 3),
            new Room(204, 4, 0),
            new Room(205, 5, 2),
        };
    }
}
