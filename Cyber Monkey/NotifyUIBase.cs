using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Cyber_Monkey
{
    public class NotifyUIBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
