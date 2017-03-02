using System;
using System.Globalization;
using System.Windows.Data;

namespace TrainService.Converters
{
    public class DurationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var duration = (int) value;
            var hours = duration/60;
            var minutes = duration - hours*60;
            return $"{hours:D2}:{minutes:D2}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var durationString = (string) value;
            var durationSubStrings = durationString.Split(':');
            var hours = int.Parse(durationSubStrings[0]);
            var minutes = int.Parse(durationSubStrings[1]);
            return hours*60 + minutes;
        }
    }
}