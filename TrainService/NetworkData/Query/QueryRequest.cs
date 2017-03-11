using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TrainService.Annotations;
using TrainService.Configs;
using TrainService.LocalData;

namespace TrainService.NetworkData.Query
{
    public class QueryRequest : INotifyPropertyChanged
    {
        private Station _fromStation;
        private string _purposeCodes;

        private DateTime _queryDate;

        private Station _toStation;

        public QueryRequest()
        {
            PurposeCodes = "ADULT";
            QueryDate = DateTime.Today;
            FromStation = StaticConfig.DefaultFromStation;
            ToStation = StaticConfig.DefaultToStation;
        }

        public string PurposeCodes
        {
            get { return _purposeCodes; }
            set
            {
                if (_purposeCodes == value) return;
                _purposeCodes = value;
                OnPropertyChanged();
            }
        }

        public DateTime QueryDate
        {
            get { return _queryDate; }
            set
            {
                if (_queryDate == value) return;
                _queryDate = value;
                OnPropertyChanged();
            }
        }

        public Station FromStation
        {
            get { return _fromStation; }
            set
            {
                if (_fromStation == value) return;
                _fromStation = value;
                OnPropertyChanged();
            }
        }

        public Station ToStation
        {
            get { return _toStation; }
            set
            {
                if (_toStation == value) return;
                _toStation = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IDictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>
            {
                {"leftTicketDTO.train_date", QueryDate.ToString("yyyy-MM-dd")},
                {"leftTicketDTO.from_station", FromStation.Code},
                {"leftTicketDTO.to_station", ToStation.Code},
                {"purpose_codes", PurposeCodes}
            };
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}