namespace maktoob.Domain.Entities
{
    public class ChatGroup : Chat
    {
        public string Name { get; set; }
        public Photo CoverPhoto { get; set; }
    }
}