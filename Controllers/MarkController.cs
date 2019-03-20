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
        /// <param name="markValue"></param>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Save(int? markValue, int studentId, int courseId)
        {
            try
            {
                if (markValue >= 6 && markValue <= 10 || markValue == null)
                {
                    var mark = _markRepository.GetMarks().Where(x => x.StudentId == studentId && x.CourseId == courseId).FirstOrDefault();
                    if (mark == null)
                    {
                        _markRepository.Save(MarkDetails(markValue, studentId, courseId));
                    }
                    else
                    {
                        if (markValue == null)
                        {
                            _markRepository.Delete(mark);
                        }
                        else
                        {
                            mark.Value = markValue;
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

        private Mark MarkDetails(int? markValue, int studentId, int courseId)
        {
            var mark = new Mark
            {
                Value = markValue,
                StudentId = studentId,
                CourseId = courseId
            };
            return mark;
        }
        #endregion
    }
}
