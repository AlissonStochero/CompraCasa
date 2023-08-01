namespace App.Domain.Entities;

public class BaseEntity
{
    public BaseEntity()
    {
        
    }
    public int Id { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime AlteradoEm { get; set; }
}
