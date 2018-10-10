using Cyber_Monkey.Model;
using System.Collections.Generic;
using System.Data.Entity;

namespace Cyber_Monkey.ViewModel
{
    public class MainWindowViewModel : NotifyUIBase
    {
        ApplicationContext db;
        RelayCommand _addCommand;
        RelayCommand _editCommand;
        RelayCommand _deleteCommand;
        IEnumerable<Project> _projects;

        public IEnumerable<Project> Projects
        {
            get { return _projects; }
            set
            {
                _projects = value;
                OnPropertyChanged("Projects");
            }
        }

        public MainWindowViewModel()
        {
            db = new ApplicationContext();
            db.Projects.Load();
            Projects = db.Projects.Local.ToBindingList();
        }
        //Add command
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand((o) =>
                    {
                        ProjectWindow projectWindow = new ProjectWindow(new Project());
                        if (projectWindow.ShowDialog() == true)
                        {
                            Project project = projectWindow.Project;
                            db.Projects.Add(project);
                            db.SaveChanges();
                        }
                    }));
            }
        }
        //Edit command
        public RelayCommand EditCommand
        {
            get
            {
                return _editCommand ??
                    (_editCommand = new RelayCommand((selectedItem) =>
                    {
                        if (selectedItem == null) return;
                        // получаем выделенный объект
                        Project project = selectedItem as Project;

                        Project vm = new Project()
                        {
                            Id = project.Id,
                            Id_Project = project.Id_Project,
                            Text = project.Text
                        };
                        ProjectWindow projectWindow = new ProjectWindow(vm);

                        if (projectWindow.ShowDialog() == true)
                        {
                            // получаем измененный объект
                            project = db.Projects.Find(projectWindow.Project.Id);
                            if (project != null)
                            {
                                project.Id_Project = projectWindow.Project.Id_Project;
                                project.Text = projectWindow.Project.Text;
                                db.Entry(project).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                    }));
            }
        }
        //Delete command
        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ??
                  (_deleteCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      // получаем выделенный объект
                      Project project = selectedItem as Project;
                      db.Projects.Remove(project);
                      db.SaveChanges();
                  }));
            }
        }
    }
}
