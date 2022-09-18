namespace Core.Persistence.Repositories;

public class Entity
{
    public int Id { get; set; }
    public bool Status { get; set; }

    public Entity()
    {
    }

    public Entity(int id, bool status) : this()
    {
        Id = id;
        Status = status;    
    }
}