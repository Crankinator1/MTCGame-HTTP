namespace MTCGame.Models
{
    public class User
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        
        public string Nickname { get; set; }
        
        public string Image { get; set; }
        
        public string Bio { get; set; }
        public string Token => $"{Username}-msgToken";
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User(string username, string password, string nickname, string image, string bio)
        {
            Username = username;
            Password = password;
            Nickname = nickname;
            Image = image;
            Bio = bio;
        }
    }
}
