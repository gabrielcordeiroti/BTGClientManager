using System.ComponentModel.DataAnnotations;

namespace BTGClientManager.Domain.Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}
