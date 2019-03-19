using Microsoft.AspNetCore.Mvc;
using StARKS.Entities;
using StARKS.Repository;
using System;
using System.Linq;

namespace StARKS.Controllers
{
    public class MarkController : Controller
    {
        private IMarkRepository _markRepository;

        public MarkController(IMarkRepository markRepository)
        {
            _markRepository = markRepository;
        }

        #region HttpPost

        /// <summary>
        /// Creating, Updating, Deleting information about student mark for specific course.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Save(int value, int studentId, int courseId)
        {
            try
            {
                if (value >= 6 && value <= 10 || value == 0)
                {
                    var mark = _markRepository.GetMarks().Where(x => x.StudentId == studentId && x.CourseId == courseId).FirstOrDefault();
                    if (mark == null)
                    {
                        _markRepository.Save(MarkDetails(value, studentId, courseId));
                    }
                    else
                    {
                        if (value == 0)
                        {
                            _markRepository.Delete(mark);
                        }
                        else
                        {
                            mark.Value = value;
                            _markRepository.Update(mark);
                        }
                    }
                    return Json(new { success = true });
                }
                return Json(new { success = false });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        #endregion

        #region private

        private Mark MarkDetails(int value, int studentId, int courseId)
        {
            var mark = new Mark
            {
                Value = value,
                StudentId = studentId,
                CourseId = courseId
            };
            return mark;
        }
        #endregion
    }
}
