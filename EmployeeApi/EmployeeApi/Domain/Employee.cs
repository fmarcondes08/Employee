using System.ComponentModel.DataAnnotations;

namespace TallerCodeChallengeApi.Models;

public class Employee
{
    public int Id { get; set; }
    
    [Required, MaxLength(50)]
    public string FirstName { get; set; }
    
    [Required, MaxLength(60)]
    public string LastName { get; set; }
    
    [Required, EmailAddress, MaxLength(120)]
    public string Email { get; set; }
    
    [Required, MaxLength(60)]
    public string Position { get; set; }
}