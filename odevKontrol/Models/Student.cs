namespace odevKontrol.Models
{
    public class Student : BaseEntity
    {
        //  public int Id { get; set; }  --BaseEntity Öncesi--
        public string Name { get; set; }
        public string StudentNumber { get; set; }

        public string DateTime { get; set; }

        //public bool IsActive { get; set; } --BaseEntity Öncesi--

    }
}
