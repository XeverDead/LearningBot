using LearningBot.ApiClient.Resources.Interfaces;
using LearningBot.UI.Models;
using LearningBot.UI.Utils;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace LearningBot.UI.ViewModels;

public class CourseListViewModel : ViewModelBase
{
    private readonly ICourseResource _courseResource;

    private CourseModel _selectedCourse;

    private Command _createCourseCommand;
    private Command _editCourseCommand;

    public CourseListViewModel(ICourseResource courseResource)
    {
        _courseResource = courseResource;
    }

    public ObservableCollection<CourseModel> Courses { get; set; } = new ObservableCollection<CourseModel>();

    public CourseModel SelectedCourse
    {
        get => _selectedCourse;
        set
        {
            _selectedCourse = value;
            OnPropertyChanged();
        }
    }

    public Command CreateCourseCommand => _createCourseCommand ??= new Command(x => ShowCoursePage(new CourseModel()));

    public Command EditCourseCommand => _editCourseCommand ??= new Command(x => ShowCoursePage(SelectedCourse), x => SelectedCourse != null);

    public async Task Init()
    {
        Courses.Clear();

        var courses = await _courseResource.GetAll();
        courses.ForEach(x => Courses.Add(new CourseModel(x)));
    }

    private void ShowCoursePage(CourseModel course)
    {
        MessageBox.Show("Not implemented yet");
    }
}
