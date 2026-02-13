namespace E_Commerce.Domain.User
{
    public class CreateUser : BaseModel
    {
        public required string UserName { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}
