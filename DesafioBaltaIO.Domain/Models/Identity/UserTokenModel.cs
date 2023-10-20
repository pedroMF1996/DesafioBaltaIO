namespace DesafioBaltaIO.Domain.Models.Identity
{
    public class UserTokenModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<ClaimModel> Claims { get; set; }
    }
}
