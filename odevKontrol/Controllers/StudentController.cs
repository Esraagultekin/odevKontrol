using Microsoft.AspNetCore.Mvc;
using AspNetCoreHero.ToastNotification;
using odevKontrol.Repositories;
using odevKontrol.ViewModels;
using odevKontrol.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;


namespace odevKontrol.Controllers
{

    
    public class StudentController : Controller
    {
        private readonly StudentRepository _studentRepository;
        private readonly HomeworkRepository _homeworkRepository;
        private readonly INotyfService _notyf;
        private readonly IMapper _mapper;

        public StudentController(StudentRepository studentRepository, INotyfService notyf, HomeworkRepository homeworkRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _notyf = notyf;
            _homeworkRepository = homeworkRepository;
            _mapper = mapper;
        }

        public async Task <IActionResult> Index()
        {
            var students = await _studentRepository.GetAllAsync();
            var studentModels = _mapper.Map<List<StudentModel>>(students);  
            return View(studentModels);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Add(StudentModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var student = _mapper.Map<Student>(model);    //genericRepository sonrası 
           await _studentRepository.AddAsync(student);
            _notyf.Success("Öğrenci Ödev Durumu  Eklendi...");
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            var studentModel = _mapper.Map<StudentModel>(student);
            return View(studentModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(StudentModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
          var student= await _studentRepository.GetByIdAsync(model.Id);
            student.Name = model.Name;
            student.StudentNumber = model.StudentNumber;
            student.DateTime = model.DateTime;
            student.IsActive = model.IsActive;
            
            await _studentRepository.UpdateAsync(student);
    
            _notyf.Success("Öğrenci Ödev Durumu Güncellendi...");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult>Delete(int id)
        {
          
            var student = await _studentRepository.GetByIdAsync(id);
            var studentModel = _mapper.Map<StudentModel>(student);
            return View(studentModel);
        }


        [HttpPost]
        public async Task<IActionResult>Delete(StudentModel model)
        {
            



            var homeworks = await _homeworkRepository.GetAllAsync();
            if (homeworks.Count(c => c.StudentId == model.Id) > 0)
            {
                _notyf.Error("Üzerinde Ödev Kayıtlı Olan Öğrenci Silinemez! Ödev Teslim Durumunu Değiştirebilirsiniz!");
                return RedirectToAction("Index");
            }

           await _studentRepository.DeleteAsync(model.Id);
            _notyf.Success("Öğrenci Ödev Durumu Silindi...");
            return RedirectToAction("Index");

        }
       
    }
}
