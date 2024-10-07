using GarageAPI.Enum;

public class LoginViewModel
{
    public long ID { get; set; }

    public string Email { get; set; }

    public string Password { get; set; } // Consider using a secure method for password handling

    public string Name { get; set; }

    public string Surname { get; set; }

    public UserType UserType { get; set; }

    public long GarageID { get; set; }

    // Add other properties as needed
}