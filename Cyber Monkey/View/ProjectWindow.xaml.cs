using Cyber_Monkey.Model;
using System.Windows;

namespace Cyber_Monkey
{
    /// <summary>
    /// Interaction logic for ProjectWindow.xaml
    /// </summary>
    public partial class ProjectWindow : Window
    {
        public Project Project { get; private set; }

        public ProjectWindow(Project p)
        {
            InitializeComponent();
            Project = p;
            DataContext = Project;
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
