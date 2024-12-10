using odevKontrol.Models;
using odevKontrol.Repositories;
using Microsoft.AspNetCore.Mvc;
using odevKontrol.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace odevKontrol.Controllers
{
    public class HomeworkController : Controller
    {
        private readonly HomeworkRepository _homeworkRepository;
        private readonly StudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyf;
        public HomeworkController(HomeworkRepository homeworkRepository, StudentRepository studentRepository, IMapper mapper, INotyfService notyf)
        {
            _homeworkRepository = homeworkRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
            _notyf = notyf;

        }

        public async Task <IActionResult> Index()
        {
           
            var homeworks = await _homeworkRepository.GetAllAsync();
            var homeworkModels = _mapper.Map<List<HomeworkModel>>(homeworks);
            return View(homeworkModels);

          
        }
        public async Task<IActionResult> Add()
        { 

        var students = await _studentRepository.GetAllAsync();

        var studentsSelectList = students.Select(x => new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString()
        });
        ViewBag.Students = studentsSelectList;
            return View();
    }

    [HttpPost]
        public async Task<IActionResult> Add(HomeworkModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var homework = _mapper.Map<Homework>(model);
           await _homeworkRepository.AddAsync(homework);
            _notyf.Success("Öğrenci ve Ödev Eklendi");
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Update(int id)
        {
            var students = await _studentRepository.GetAllAsync();

            var studentsSelectList = students.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            ViewBag.Students = studentsSelectList;
            var homework = await _homeworkRepository.GetByIdAsync(id);
            var homeworkModel = _mapper.Map<HomeworkModel>(homework);
            return View(homeworkModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(HomeworkModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var homework = await _homeworkRepository.GetByIdAsync(model.Id);
            homework.Name = model.Name;
            homework.Description = model.Description;
            homework.StudentNumber = model.StudentNumber;
            homework.LessonName = model.LessonName;
            homework.IsActive = model.IsActive;
            homework.StudentId = model.StudentId;

            await _homeworkRepository.UpdateAsync(homework);
            _notyf.Success("Öğrenci Ödev Güncellendi...");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var homework = await _homeworkRepository.GetByIdAsync(id);
            var homeworkModel = _mapper.Map<HomeworkModel>(homework);
            return View(homeworkModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(HomeworkModel model)
        {
            await _homeworkRepository.DeleteAsync(model.Id);
            _notyf.Success(" Silindi...");
            return RedirectToAction("Index");

           
        }
    }
}
