namespace AppDev.Domain.Shared;

public abstract class BaseEntity
{
    public DateTime Created { get; set; }
    public DateTime? LastModified { get; set; }
}