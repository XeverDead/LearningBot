using LearningBot.Shared.Enums;

namespace LearningBot.Shared.Entities;

public class UserExercise
{
    public int UserId { get; set; }

    public int CourseId { get; set; }

    public int ExerciseId { get; set; }

    public ExerciseStatus Status { get; set; }

    public int Order { get; set; }
}
