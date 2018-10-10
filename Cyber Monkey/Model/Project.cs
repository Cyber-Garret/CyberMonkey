namespace Cyber_Monkey.Model
{
    public class Project : NotifyUIBase
    {
        private int _id_project;
        private string _text;

        public int Id { get; set; }

        public int Id_Project
        {
            get { return _id_project; }
            set
            {
                _id_project = value;
                OnPropertyChanged("Id_Project");
            }
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }
    }
}
