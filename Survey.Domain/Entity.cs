namespace Survey.Domain.Survey
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public bool Active { get; set; } = true;
    }
}