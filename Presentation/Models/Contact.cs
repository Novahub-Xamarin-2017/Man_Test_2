using System.Collections.Generic;

namespace Presentation.Models
{
    public class Contact
    {
        public string Reason { get; set; }
        public string HelloTo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string Industry { get; set; }
        public string Company { get; set; }
        public string Comments { get; set; }
        public string Token { get; set; }
        public List<Image> Images { get; set; }
    }
}