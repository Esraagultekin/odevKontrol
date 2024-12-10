using AutoMapper;
using odevKontrol.Models;
using odevKontrol.ViewModels;


namespace odevKontrol.Repositories
{
    public class StudentRepository : GenericRepository<Student>
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }
    }

}
    // ---GENERİCREPOSITORY ONCESİ---

//    public class StudentRepository
//    {
//        private readonly AppDbContext _context;
//        private readonly IMapper _mapper;
//        public StudentRepository(AppDbContext context, IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }

//        public List<StudentModel> GetList()
//        {
//            var students = _context.Students.ToList();
//            var studentModels = _mapper.Map<List<StudentModel>>(students);
//            return studentModels;
//        }
//        public StudentModel GetById(int id)
//        {
//            var student = _context.Students.Where(s => s.Id == id).FirstOrDefault();
//            var studentModel = _mapper.Map<StudentModel>(student);

//            return studentModel;
//        }
//        public void Add(StudentModel model)
//        {
//            var student = _mapper.Map<Student>(model);
//            _context.Students.Add(student);
//            _context.SaveChanges();
//        }
//        public void Update(StudentModel model)
//        {
//            var student = _context.Students.Where(s => s.Id == model.Id).FirstOrDefault();
//            if (student != null)
//            {
//                student.Name = model.Name;

//                student.IsActive = model.IsActive;

//                _context.Students.Update(student);
//                _context.SaveChanges();
//            }
//        }
//        public void Delete(int id)
//        {
//            var student = _context.Students.Where(s => s.Id == id).FirstOrDefault();
//            if (student != null)
//            {
//                _context.Students.Remove(student);
//                _context.SaveChanges();
//            }
//        }
//    }
//}
