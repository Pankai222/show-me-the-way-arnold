#nullable disable

namespace Arnold_Web_API.Models
{
    public class Contact
    {
        public int IdContact { get; set; }
        public string Emailaddress { get; set; }
        public string Phonenumber { get; set; }
        public int CreatorIdCreator { get; set; }

        public Creator CreatorIdCreatorNavigation { get; set; }
    }
}
