using System.Reflection.Metadata.Ecma335;

namespace AwesomeDevEvents.API.Entities
{
    public class DevEvent
    {
        public DevEvent()
        {
            Speakers = new List<DevEventSpeaker>();
            IsDeleted = false;
        }
        public void Update(string title, string descreption, DateTime startDate, DateTime endDate)
        {
            Title = title;
            Description = descreption;
            StartDate = startDate;
            EndDate = endDate;
        }
        public Guid Id { get; set; }
        public required string Title { get; set; } 
        public required string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<DevEventSpeaker> Speakers { get; set; }
       
        public bool IsDeleted { get; set; }

      
        public void Delete()
        {
            IsDeleted = true;
        }

    }

}
