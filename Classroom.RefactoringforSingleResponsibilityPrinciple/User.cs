public class User
{
    public string Email { get; internal set; }
    public User GetUserById(int userId)
    {
        return new User();
    }
}