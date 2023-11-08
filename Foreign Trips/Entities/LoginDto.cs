namespace Foreign_Trips.Entities
{
    public class LoginDto
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public long ID { get; set; } = 0!;
        public string Photo { get; set; } = null!;
        public string Token { get; set; }
        

        public LoginDto(string userName, string password, string role, long id, string photo, string token)
        {
            Username = userName;
            Password = password;
            Role = role;
            ID = id;
            Photo = photo;
            Token = token;
            

        }


    }
}

