using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TrainService.Converters;

namespace TrainService.NetworkData.Query
{
    [JsonObject(MemberSerialization.OptIn)]
    public class TrainDatas
    {
        [JsonProperty(PropertyName = "flag")]
        public bool Flag { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "datas")]
        public IList<TrainData> Datas { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class TrainData
    {
        // 内部编号
        [JsonProperty(PropertyName = "train_no")]
        public string TrainNumber { get; set; }

        // 车次
        [JsonProperty(PropertyName = "station_train_code")]
        public string StationTrainCode { get; set; }

        // 始发站编号
        [JsonProperty(PropertyName = "start_station_telecode")]
        public string StartStationTelecode { get; set; }

        // 始发站名称
        [JsonProperty(PropertyName = "start_station_name")]
        public string StartStationName { get; set; }

        // 终到站编号
        [JsonProperty(PropertyName = "end_station_telecode")]
        public string EndStationTelecode { get; set; }

        // 终到站名称
        [JsonProperty(PropertyName = "end_station_name")]
        public string EndStationName { get; set; }

        // 查询起始站编号
        [JsonProperty(PropertyName = "from_station_telecode")]
        public string FromStationTelecode { get; set; }

        // 查询起始站名称
        [JsonProperty(PropertyName = "from_station_name")]
        public string FromStationName { get; set; }

        // 查询目的站编号
        [JsonProperty(PropertyName = "to_station_telecode")]
        public string ToStationTelecode { get; set; }

        // 查询目的站名称
        [JsonProperty(PropertyName = "to_station_name")]
        public string ToStationName { get; set; }

        // 出发时间
        [JsonProperty(PropertyName = "start_time")]
        [JsonConverter(typeof(TimeConverter))]
        public DateTime StartTime { get; set; }

        // 到达时间
        [JsonProperty(PropertyName = "arrive_time")]
        [JsonConverter(typeof(TimeConverter))]
        public DateTime ArriveTime { get; set; }

        // 隔日
        [JsonProperty(PropertyName = "day_difference")]
        public int DayDifference { get; set; }

        // 历时
        [JsonProperty(PropertyName = "lishiValue")]
        public int DurationMinutes { get; set; }

        // 是否可在线预订
        [JsonProperty(PropertyName = "canWebBuy")]
        public string CanWebBuy { get; set; }

        // 是否被管制
        [JsonProperty(PropertyName = "controlled_train_flag")]
        public int ControlledTrainFlag { get; set; }

        // 管制原因
        [JsonProperty(PropertyName = "controlled_train_message")]
        public string ControlledTrainMessage { get; set; }

        // 有无空调 - 无空调 0 | 有空调 3
        [JsonProperty(PropertyName = "train_seat_feature")]
        public int TrainSeatFeature { get; set; }

        // TODO:地区编码 - 待确定
        [JsonProperty(PropertyName = "location_code")]
        public string LocationCode { get; set; }

        // 观光座
        [JsonProperty(PropertyName = "gg_num")]
        public string GuanGuang { get; set; }

        // 高级软卧
        [JsonProperty(PropertyName = "gr_num")]
        public string GaoRuan { get; set; }

        // 其它
        [JsonProperty(PropertyName = "qt_num")]
        public string QiTa { get; set; }

        // 软卧
        [JsonProperty(PropertyName = "rw_num")]
        public string RuanWo { get; set; }

        // 软座
        [JsonProperty(PropertyName = "rz_num")]
        public string RuanZuo { get; set; }

        // 特等座
        [JsonProperty(PropertyName = "tz_num")]
        public string TeDeng { get; set; }

        // 无座
        [JsonProperty(PropertyName = "wz_num")]
        public string WuZuo { get; set; }

        // 硬卧包厢
        [JsonProperty(PropertyName = "yb_num")]
        public string YingWoBaoXiang { get; set; }

        // 硬卧
        [JsonProperty(PropertyName = "yw_num")]
        public string YingWo { get; set; }

        // 硬座
        [JsonProperty(PropertyName = "yz_num")]
        public string YingZuo { get; set; }

        // 二等座
        [JsonProperty(PropertyName = "ze_num")]
        public string ErDeng { get; set; }

        // 一等座
        [JsonProperty(PropertyName = "zy_num")]
        public string YiDeng { get; set; }

        // 商务座
        [JsonProperty(PropertyName = "swz_num")]
        public string ShangWu { get; set; }
    }
}