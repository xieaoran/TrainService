using System;
using System.Globalization;
using System.Windows.Data;

namespace TrainService.Converters
{
    public class TrainSeatFeatureConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var trainSeatFeature = (int) value;
            return trainSeatFeature == 0 ? "无" : "有";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var trainSeatFeatureString = (string) value;
            return trainSeatFeatureString == "无" ? 0 : 3;
        }
    }
}