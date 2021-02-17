using System.Collections.Generic;

namespace src.RealEstate.Entity.DTOs
{
    public class MailDTO
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public List<string> To { get; set; } = new List<string>();
        public string From { get; set; }
    }
}