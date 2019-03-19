using Microsoft.AspNetCore.Mvc;
using StARKS.Models;
using StARKS.Repository;

namespace StARKS.Controllers
{
    public class HomeController : Controller
    {
        private ICourseRepository _courseRepository;

        private IStudentRepository _studentRepository;

        private IMarkRepository _markRepository;

        public HomeController(ICourseRepository courseRepository, IStudentRepository studentRepository, IMarkRepository markRepository)
        {
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
            _markRepository = markRepository;
        }

        #region HttpGet

        /// <summary>
        /// Getting information about students, courses and students marks.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            StarksModel starksModel = new StarksModel()
            {
                Students = _studentRepository.GetStudents(),
                Courses = _courseRepository.GetCourses(),
                StudentMarks = _studentRepository.GetStudentsMarks()
            };
            return View(starksModel);
        }
        #endregion
    }
}