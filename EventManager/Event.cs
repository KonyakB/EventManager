namespace MyEvents
{
    public class Event
    {
        public string Name { get; }
        public string Type { get; }
        public int Capacity { get; private set; }
        public bool IsActive { get; private set; }
        public string Location { get; private set; }
        public bool LocationChanged { get; private set; }

        public Event(string name, string type, int capacity, string location)
        {
            Name = name;
            Type = type;
            Capacity = capacity;
            IsActive = true;
            Location = location;
            LocationChanged = false;
        }

        public void Cancel()
        {
            IsActive = false;
        }

        public bool RegisterAttendee()
        {
            if (IsActive && Capacity > 0)
            {
                Capacity--;
                return true;
            }
            return false;
        }

        public void ChangeLocation(string newLocation)
        {
            Location = newLocation;
			LocationChanged = true;
        }
    }
}