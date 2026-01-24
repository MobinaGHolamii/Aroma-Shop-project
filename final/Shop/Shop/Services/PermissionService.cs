using Shop.Data;
using System.Linq;

namespace Shop.Services
{
    public class PermissionService
    {
        private readonly ShopDbContext _context;

        public PermissionService(ShopDbContext context)
        {
            _context = context;
        }

        public bool UserHasPermission(int userId, string permissionName)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null) return false;

            if (user.FkRole == 1) return true;

            return (from rp in _context.RolePermissions
                    join p in _context.Permissions
                        on rp.FkPermission equals p.Id
                    where rp.FkRole == user.FkRole
                          && p.Name == permissionName
                    select rp).Any();
        }
    }
}

