using System.ComponentModel.DataAnnotations;
using AppDev.Domain.Shared;


namespace AppDev.Domain.Entities;

public class User : BaseEntity
{
    public Guid Id { get; set; } = new Guid();
    [Required] public string Name { get; set; }
    [Required] public string Email { get; set; }
    [Required] [MaxLength(10)] public string Contact { get; set; }
    [Required] public string Address { get; set; }
    [Required] public DateTime JoinDate { get; set; }
    [Required] public UserRole Role { get; set; }
    
    
    
}