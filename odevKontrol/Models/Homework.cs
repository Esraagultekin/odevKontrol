using System.ComponentModel.DataAnnotations;
using System.Text;

namespace odevKontrol.Models
{
    public class Homework : BaseEntity
    {
        //  public int Id { get; set; } --BaseEntity Öncesi--
        public string Name { get; set; }
        public string LessonName { get; set; }

        public string Description { get; set; }
        public long StudentNumber { get; set; }

        //public bool IsActive { get; set; } --BaseEntity Öncesi--

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}

