using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    public class RolePermission
    {
        public int FkRole { get; set; }
        public int FkPermission { get; set; }

        [ForeignKey("FkRole")]
        public Role Role { get; set; }

        [ForeignKey("FkPermission")]
        public Permission Permission { get; set; }
    }
}
