using LearningBot.Shared.Enums;

namespace LearningBot.Shared.Entities;

public class UserCourse
{
    public int UserId { get; set; }

    public int CourseId { get; set; }

    public CourseStatus Status { get; set; }
}
