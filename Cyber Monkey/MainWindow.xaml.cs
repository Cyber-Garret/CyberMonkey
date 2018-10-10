using System.Windows;
using Cyber_Monkey.ViewModel;

namespace Cyber_Monkey
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
        ////Add
        //private void Add_Click(object sender, RoutedEventArgs e)
        //{
        //    ProjectWindow projectWindow = new ProjectWindow(new Project());
        //    if (projectWindow.ShowDialog() == true)
        //    {
        //        Project project = projectWindow.Project;
        //        db.Projects.Add(project);
        //        db.SaveChanges();
        //    }
        //}
        ////Edit
        //private void Edit_Click(object sender, RoutedEventArgs e)
        //{
        //    // если ни одного объекта не выделено, выходим
        //    if (projectList.SelectedItem == null) return;
        //    // получаем выделенный объект
        //    Project project = projectList.SelectedItem as Project;

        //    ProjectWindow projectWindow = new ProjectWindow(new Project
        //    {
        //        Id = project.Id,
        //        Id_Project = project.Id_Project,
        //        Text = project.Text
        //    });

        //    if (projectWindow.ShowDialog() == true)
        //    {
        //        // получаем измененный объект
        //        project = db.Projects.Find(projectWindow.Project.Id);
        //        if (project != null)
        //        {
        //            project.Id_Project = projectWindow.Project.Id_Project;
        //            project.Text = projectWindow.Project.Text;
        //            db.Entry(project).State = EntityState.Modified;
        //            db.SaveChanges();
        //        }
        //    }
        //}
        ////Delete
        //private void Delete_Click(object sender, RoutedEventArgs e)
        //{
        //    // если ни одного объекта не выделено, выходим
        //    if (projectList.SelectedItem == null) return;
        //    // получаем выделенный объект
        //    Project project = projectList.SelectedItem as Project;
        //    db.Projects.Remove(project);
        //    db.SaveChanges();
        //}
    }
}
