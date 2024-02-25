using LearningBot.Shared.Entities;

namespace LearningBot.UI.Models;

public class CourseModel : ModelBase<Course>
{
    public CourseModel() : base()
    {
    }

    public CourseModel(Course entity) : base(entity)
    {
    }

    public string Name
    {
        get => Entity.Name;
        set
        {
            Entity.Name = value;
            OnPropertyChanged();
        }
    }
}
