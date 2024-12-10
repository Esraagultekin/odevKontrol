using System.ComponentModel.DataAnnotations;



namespace odevKontrol.ViewModels
{
    public class StudentModel : BaseModel
    {
       
            public int Id { get; set; }

            [Display(Name = "Öğrenci Adı")]
            [Required(ErrorMessage = "Lütfen Öğrenci Adı Giriniz!")]
            public string Name { get; set; }

            [Display(Name = "Öğrenci No ")]
            [Required(ErrorMessage = "Lütfen Öğrenci Numarası Giriniz!")]
            public string StudentNumber { get; set; }

            [Display(Name = "Teslim Tarihi")]
            [Required(ErrorMessage = "Lütfen Ödev Teslim Tarihi Giriniz!")]
            public string DateTime { get; set; }




             [Display(Name = "Ödev Teslim Edildi")]
            public bool IsActive { get; set; }
       
    }
}
