namespace RentApi.Models
{
    public class Contract
    {
        public int Id { get; set; }

        public int TenantId { get; set; }
        public User Tenant { get; set; }

        public int PropertyId { get; set; }
        public Property Property { get; set; }

        public bool IsActive { get; set; } = true;
    }
}