using Newtonsoft.Json;
using TrainService.LocalData;
using TrainService.UiHelpers;

namespace TrainService.Configs
{
    public static class StaticConfig
    {
        public const string PostContentType = "application/json";
        public const string QueryApi = "https://kyfw.12306.cn/otn/leftTicket/query";
        public const int Timeout = 10000;

        public static JsonSerializerSettings JsonSerializeSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            Error = (sender, args) => { args.ErrorContext.Handled = true; }
        };

        public static StationFilteringBehavior StationFilteringBehavior = new StationFilteringBehavior();

        public static Station DefaultFromStation = new Station
        {
            Code = "HBB",
            Name = "哈尔滨",
            PinyinInitials = "HEB"
        };

        public static Station DefaultToStation = new Station
        {
            Code = "BJP",
            Name = "北京",
            PinyinInitials = "BJ"
        };
    }
}