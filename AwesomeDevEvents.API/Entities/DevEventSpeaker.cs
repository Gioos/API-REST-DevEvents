namespace AwesomeDevEvents.API.Entities
{
    public class DevEventSpeaker
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string TalkTitle { get; set; }
        public string TalkDescription { get; set; } = "";
        public string LinkedInProfile { get; set; } = "";

    }
}