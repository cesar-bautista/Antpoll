using System;

namespace Antpoll.Domain.Entities
{
    public class CompanyEntity
    {
        public byte CompanyId { get; set; }
        public int WorkSpaceId { get; set; }
        public string Code { get; set; }
        public string BusinessName { get; set; }
        public string AlternateCode { get; set; }
        public bool Active { get; set; }
        public bool Canceled { get; set; }
        public string UserRegistration { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
