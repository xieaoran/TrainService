using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TrainService.Annotations;
using TrainService.NetworkData.Query;

namespace TrainService
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            QueryRequest = new QueryRequest();
            QueryResult = new List<TrainData>();
            ShowResult = new ObservableCollection<TrainData>();
        }

        public QueryRequest QueryRequest { get; set; }
        public IList<TrainData> QueryResult { get; set; }
        public ObservableCollection<TrainData> ShowResult { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}