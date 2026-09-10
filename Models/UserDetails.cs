public class UserDetails
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string PasswordHash { get; set; }

    public string UserType { get; set; } // Student or Teacher
}