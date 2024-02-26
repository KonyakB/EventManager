using Xunit;
using MyEvents;

namespace MyEvents.Tests
{
    public class EventTests
    {
        [Fact]
        public void Event_IsActive_WhenCreated()
        {
            var evnt = new Event("Code Workshop", "Workshop", 50, "Alsion");
            Assert.True(evnt.IsActive);
        }

        [Fact]
        public void CancelEvent_SetsIsActiveToFalse()
        {
            var evnt = new Event("Code Workshop", "Workshop", 50, "Alsion");
            evnt.Cancel();
            Assert.False(evnt.IsActive);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(1)]
        public void RegisterAttendee_DecreasesCapacity(int initialCapacity)
        {
            var evnt = new Event("Code Workshop", "Workshop", initialCapacity, "Alsion");
            bool registrationResult = evnt.RegisterAttendee();

            Assert.True(registrationResult);
            Assert.Equal(initialCapacity - 1, evnt.Capacity);
        }

        [Fact]
        public void RegisterAttendee_ReturnsFalse_WhenEventIsFull()
        {
            var evnt = new Event("Code Workshop", "Workshop", 0, "Alsion"); // Event is already full
            bool registrationResult = evnt.RegisterAttendee();
            Assert.False(registrationResult);
        }
        
        [Fact]
        public void LocationChanged_False_WhenCreated() //not too creative :(
        {
            var evnt = new Event("Code Workshop", "Workshop", 0, "Alsion");
            Assert.False(evnt.LocationChanged);
        }

        [Fact]
        public void LocationChanged_True_WhenChanged()
        {
            var evnt = new Event("Code Workshop", "Workshop", 0, "Alsion");
            evnt.ChangeLocation("Columbia");
            Assert.True(evnt.LocationChanged);
        }
    }
}