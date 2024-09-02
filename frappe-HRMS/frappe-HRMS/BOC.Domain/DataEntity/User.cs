using BOC.Domain.Base;
using BOC.Domain.Enum;

namespace BOC.Domain.DataEntity
{
    public class User : BaseEntity
    {
        public string? Username { get; private set; }
        public RoleEnums Role { get; private set; }
        public string? FirstName { get; private set; }
        public string? Password { get; set; }
        public string? LastName { get; private set; }
        public string Fullname => $"{FirstName} {LastName}";
        public string? CellPhone { get; private set; }
        public string? Email { get; private set; }
        public bool IsActive { get; set; } = true;
    }
}
