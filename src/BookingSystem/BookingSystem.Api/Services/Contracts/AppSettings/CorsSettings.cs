namespace BookingSystem.Api.Services.Contracts
{
    public class CorsSettings
    {
        public string CorsPolicyName { get; set; }

        public string[] AllowedCorsOrigins { get; set; }
    }
}
