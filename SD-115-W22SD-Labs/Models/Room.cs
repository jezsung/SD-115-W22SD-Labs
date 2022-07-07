namespace SD_115_W22SD_Labs.Models
{
    class Room
    {
        public int Number { get; set; }
        public int Capacity { get; set; }
        public int Occupants { get; set; }
        public bool Occupied
        {
            get { return Occupants > 0; }
        }

        public Room(int number, int capacity, int occupants)
        {
            Number = number;
            Capacity = capacity;
            Occupants = occupants;
        }
    }
}
