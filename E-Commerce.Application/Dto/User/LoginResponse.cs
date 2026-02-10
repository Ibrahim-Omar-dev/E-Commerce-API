namespace E_Commerce.Application.Dto.User
{
    public record LoginResponse
    {
        public bool Issucess = false;
        public string Token = null!;
        public string RefreshToken = null!;
        public string Message = null!;
    }
}
