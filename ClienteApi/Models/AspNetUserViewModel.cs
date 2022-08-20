namespace ClienteApi.Models
{
    public class AspNetUserViewModel
    {
        public String Id { get; set; }
        public String UserName { get; set; }
        public String NormalizedUserName { get; set; }
        public String Email { get; set; }
        public String NormalizedEmail { get; set; }
        public bool EmailConfirmed  { get; set; }
        public String PasswordHash { get; set; }
        public String SecurityStamp  { get; set; }
        
        public String ConcurrencyStamp { get; set; }
        public String PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
    }

}
