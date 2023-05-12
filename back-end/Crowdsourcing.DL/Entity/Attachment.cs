namespace Crowdsourcing.DL.Entity
{
    public class Attachment
    {
        public int Id { get; set; }
        public string? AttachmentLink { get; set; } 

        // Foreign Key From Class Message
        public int MessageId { get; set; }
        public Message Message { get; set; }

    }
}
