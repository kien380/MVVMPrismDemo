using MVVMPrismDemo.Enums;

namespace MVVMPrismDemo.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNo { get; set; }

        public Gender Gender { get; set; }

        public string Avatar
        {
            get => Gender == Gender.Male ? "boy.png" : "girl.png";
        }
    }
}
