using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StARKS.Entities;
using StARKS.Helpers;
using StARKS.Repository;
using System;
using System.Linq;

namespace StARKS.Controllers
{
    public class CourseController : Controller
    {
        private ICourseRepository _courseRepository;
        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        #region HttpGet

        /// <summary>
        /// Getting information about course by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                string value = string.Empty;
                var model = _courseRepository.GetCourse(id);
                if (model != null)
                {
                    value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                }
                return Json(value);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        #endregion

        #region HttpPost

        /// <summary>
        ///  Creating and Updating information about Course.
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Save(Course course)
        {
            try
            {
                if (course != null)
                {
                    var courses = _courseRepository.GetCourses();

                    if (course.CourseId > 0)
                    {

                        if (courses.Any(x => x.Code == course.Code && x.CourseId != course.CourseId))
                        {
                            TempData[MessageInfo.WarningMessage] = "The Code already exists!";
                        }
                        else
                        {
                            var courseById = _courseRepository.GetCourse(course.CourseId);
                            if (courseById != null)
                            {
                                _courseRepository.Update(CourseDetails(courseById, course.Name, course.Code, course.Description));
                                TempData[MessageInfo.SuccessMessage] = "Successfully updated course!";
                            }
                        }
                    }
                    else
                    {
                        if (courses.Any(x => x.Code == course.Code))
                        {
                            TempData[MessageInfo.WarningMessage] = "The Code already exists!";
                        }
                        else
                        {
                            _courseRepository.Save(course);
                            TempData[MessageInfo.SuccessMessage] = "Successfully created new course!";
                        }
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        /// <summary>
        /// Deleting course By id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    var course = _courseRepository.GetCourse(id);
                    if (course != null)
                    {
                        _courseRepository.Delete(course);
                        TempData[MessageInfo.SuccessMessage] = "Successfully deleted course!";
                        return Json(new { success = true });
                    }
                }
                return Json(new { success = false });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        #endregion

        #region Private methods
        private Course CourseDetails(Course course, string name, string code, string description)
        {
            course.Name = name;
            course.Code = code;
            course.Description = description;
            return course;
        }
        #endregion
    }
}