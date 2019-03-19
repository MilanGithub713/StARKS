using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StARKS.Entities;
using StARKS.Helpers;
using StARKS.Repository;
using System;

namespace StARKS.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        #region HttpGet

        /// <summary>
        /// Getting information about student by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                var model = _studentRepository.GetStudent(id);
                string value = string.Empty;
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
        /// Creating and Updating information about Student.
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Save(Student student)
        {
            try
            {
                if (student != null)
                {
                    if (student.StudentId > 0)
                    {
                        TryUpdateModelAsync(student);
                        _studentRepository.Update(student);
                        TempData[MessageInfo.SuccessMessage] = "Successfully updated student!";
                    }
                    else
                    {
                        _studentRepository.Save(student);
                        TempData[MessageInfo.SuccessMessage] = "Successfully created new student!";
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
        /// Deleting student By id.
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
                    var student = _studentRepository.GetStudent(id);
                    if (student != null)
                    {
                        _studentRepository.Delete(student);
                        TempData[MessageInfo.SuccessMessage] = "Successfully deleted student!";
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
    }
}