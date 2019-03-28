
using BlueBadge.Models.CourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Contracts
{
    public interface ICourse
    {
        bool CreateCourse(CourseCreate model);

        IEnumerable<CourseListItem> GetCourses();

        CourseDetail GetCourseByID(int courseId);

        bool EditCourse(CourseEdit model);

        bool DeleteCourse(int courseId);
    }
}
