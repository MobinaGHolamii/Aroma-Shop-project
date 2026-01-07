using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public int FkRole { get; set; }

        [ForeignKey(nameof(FkRole))]
        public Role Role { get; set; }
    }
}
