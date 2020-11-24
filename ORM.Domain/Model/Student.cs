namespace ORM.Domain.Model
{
    public class Student : Person
    {
        public int RA { get; set; }
        public int ClassesId { get; set; }
    }
}
