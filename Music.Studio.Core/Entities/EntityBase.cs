namespace Music.Studio.Core.Entities;

public class EntityBase
{
    public bool isDeleted { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public  string UpdatedBy { get; set; }
    public DateTime UpdatedDate { get; set; }
}