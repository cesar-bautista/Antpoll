using System;

namespace Antpoll.Domain.Entities
{
    public class ApplicationEntity
    {
        public byte ApplicationId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Translations { get; set; }
        public string Assets { get; set; }
        public string Version { get; set; }
        public bool Active { get; set; }
        public DateTime CreationDate { get; set; }
    }   
}
