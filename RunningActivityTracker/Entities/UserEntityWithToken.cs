namespace RunningActivityTracker.Entities
{
    public class UserEntityWithToken
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string[] Roles { get; set; }
        public string Token { get; set; }
    }
}