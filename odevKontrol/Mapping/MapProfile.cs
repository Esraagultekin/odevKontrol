using AutoMapper;
using odevKontrol.Mapping;
using odevKontrol.Models;
using odevKontrol.ViewModels;


namespace odevKontrol.Mapping
{




    public class MapProfile : Profile
    {

        public MapProfile() 
        {
            
                CreateMap<Homework, HomeworkModel>().ReverseMap();
                CreateMap<Student, StudentModel>().ReverseMap();
                CreateMap<User, UserModel>().ReverseMap();
                CreateMap<User, RegisterModel>().ReverseMap();

                CreateMap<Todo, TodoModel>().ReverseMap();

            

            //CreateMAp --> homework sınıfını, HomeworkModel sınıfına dönüştürmek için yapılan bir eşleşmedir.
            //ReverseMAp --> dönüşüm kuralının tersini de oluşturur. homeworkModel'dan Homework'e dönüşüm sağlar.
            //Tüm dönüşümleri tutmak için ayrı bir MapProfile oluşturuldu.
            //HomeworkRepository'e using AutoMapper eklendi.
        }
    }
}
