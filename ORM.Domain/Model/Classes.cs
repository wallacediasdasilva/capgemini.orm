namespace ORM.Domain.Model
{
    public class Classes
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Coordinator Coordinator { get; set; }
    }
}
