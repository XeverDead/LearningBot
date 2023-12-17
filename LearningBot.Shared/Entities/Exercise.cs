using LearningBot.Shared.Enums;

namespace LearningBot.Shared.Entities;

public class Exercise
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Link { get; set; }

    public ExerciseType Type { get; set; }
}
