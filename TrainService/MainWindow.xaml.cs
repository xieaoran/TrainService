using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using TrainService.Configs;
using TrainService.LocalData;
using TrainService.NetworkData.Query;
using TrainService.NetworkHelpers;

namespace TrainService
{
    /// <summary>
    ///     MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : RadRibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainWindowViewModel();
            LoadDataSources();
            SetDataContext();
            SetUiSettings();
        }

        private MainWindowViewModel ViewModel { get; set; }

        #region Filtering

        private void Filter()
        {
            var filterResults = new List<TrainData>();
            ViewModel.ShowResult.Clear();
            foreach (var result in ViewModel.QueryResult)
            {
                if (result.StationTrainCode.StartsWith("G") || result.StationTrainCode.StartsWith("C"))
                {
                    if (FilterG.IsChecked != null && FilterG.IsChecked.Value)
                        filterResults.Add(result);
                }
                else if (result.StationTrainCode.StartsWith("D"))
                {
                    if (FilterD.IsChecked != null && FilterD.IsChecked.Value)
                        filterResults.Add(result);
                }
                else if (result.StationTrainCode.StartsWith("Z"))
                {
                    if (FilterZ.IsChecked != null && FilterZ.IsChecked.Value)
                        filterResults.Add(result);
                }
                else if (result.StationTrainCode.StartsWith("T"))
                {
                    if (FilterT.IsChecked != null && FilterT.IsChecked.Value)
                        filterResults.Add(result);
                }
                else if (result.StationTrainCode.StartsWith("K"))
                {
                    if (FilterK.IsChecked != null && FilterK.IsChecked.Value)
                        filterResults.Add(result);
                }
                else
                {
                    if (FilterN.IsChecked != null && FilterN.IsChecked.Value)
                        filterResults.Add(result);
                }
            }
            foreach (var result in filterResults)
            {
                if (result.GuanGuang != "--" && result.GaoRuan != "无")
                {
                    if (FilterGg.IsChecked != null && FilterGg.IsChecked.Value)
                    {
                        ViewModel.ShowResult.Add(result);
                        continue;
                    }
                }
                if (result.ShangWu != "--" && result.ShangWu != "无")
                {
                    if (FilterSw.IsChecked != null && FilterSw.IsChecked.Value)
                    {
                        ViewModel.ShowResult.Add(result);
                        continue;
                    }
                }
                if (result.TeDeng != "--" && result.TeDeng != "无")
                {
                    if (FilterTd.IsChecked != null && FilterTd.IsChecked.Value)
                    {
                        ViewModel.ShowResult.Add(result);
                        continue;
                    }
                }
                if (result.YiDeng != "--" && result.YiDeng != "无")
                {
                    if (FilterZy.IsChecked != null && FilterZy.IsChecked.Value)
                    {
                        ViewModel.ShowResult.Add(result);
                        continue;
                    }
                }
                if (result.ErDeng != "--" && result.ErDeng != "无")
                {
                    if (FilterZe.IsChecked != null && FilterZe.IsChecked.Value)
                    {
                        ViewModel.ShowResult.Add(result);
                        continue;
                    }
                }
                if (result.GaoRuan != "--" && result.GaoRuan != "无")
                {
                    if (FilterGr.IsChecked != null && FilterGr.IsChecked.Value)
                    {
                        ViewModel.ShowResult.Add(result);
                        continue;
                    }
                }
                if (result.YingWoBaoXiang != "--" && result.YingWoBaoXiang != "无")
                {
                    if (FilterYb.IsChecked != null && FilterYb.IsChecked.Value)
                    {
                        ViewModel.ShowResult.Add(result);
                        continue;
                    }
                }
                if (result.RuanWo != "--" && result.RuanWo != "无")
                {
                    if (FilterRw.IsChecked != null && FilterRw.IsChecked.Value)
                    {
                        ViewModel.ShowResult.Add(result);
                        continue;
                    }
                }
                if (result.YingWo != "--" && result.YingWo != "无")
                {
                    if (FilterYw.IsChecked != null && FilterYw.IsChecked.Value)
                    {
                        ViewModel.ShowResult.Add(result);
                        continue;
                    }
                }
                if (result.RuanZuo != "--" && result.RuanZuo != "无")
                {
                    if (FilterRz.IsChecked != null && FilterRz.IsChecked.Value)
                    {
                        ViewModel.ShowResult.Add(result);
                        continue;
                    }
                }
                if (result.YingZuo != "--" && result.YingZuo != "无")
                {
                    if (FilterYz.IsChecked != null && FilterYz.IsChecked.Value)
                    {
                        ViewModel.ShowResult.Add(result);
                        continue;
                    }
                }
                if (result.WuZuo != "--" && result.WuZuo != "无")
                {
                    if (FilterWz.IsChecked != null && FilterWz.IsChecked.Value)
                    {
                        ViewModel.ShowResult.Add(result);
                    }
                }
            }
        }

        #endregion

        #region Initialization

        public void LoadDataSources()
        {
            FromStationInput.ItemsSource = Runtime.Stations;
            FromStationInput.FilteringBehavior = StaticConfig.StationFilteringBehavior;
            ToStationInput.ItemsSource = Runtime.Stations;
            ToStationInput.FilteringBehavior = StaticConfig.StationFilteringBehavior;
        }

        public void SetDataContext()
        {
            FromStationInput.DataContext = ViewModel.QueryRequest;
            ToStationInput.DataContext = ViewModel.QueryRequest;
            DepartureDateInput.DataContext = ViewModel.QueryRequest;
            QueryResults.ItemsSource = ViewModel.ShowResult;
        }

        public void SetUiSettings()
        {
            DepartureDateInput.SelectableDateStart = DateTime.Today;
            DepartureDateInput.SelectableDateEnd = DateTime.Today + TimeSpan.FromDays(59);
        }

        #endregion

        #region UI Helpers

        private void TypeToSeatEnabled()
        {
            var typeFilters = FilterTypePanel.ChildrenOfType<CheckBox>().ToArray();
            var seatFilters = FilterSeatPanel.ChildrenOfType<CheckBox>().ToArray();
            foreach (var seatFilter in seatFilters)
            {
                seatFilter.IsEnabled = true;
            }
            if (typeFilters.Where(f => (string) f.Tag == "CRHType")
                .All(f => f.IsChecked == null || !f.IsChecked.Value))
            {
                foreach (var seatFilter in seatFilters.Where(f => (string) f.Tag == "CRHSeat"))
                {
                    seatFilter.IsEnabled = false;
                }
            }
            if (typeFilters.Where(f => (string) f.Tag == "NTType")
                .All(f => f.IsChecked == null || !f.IsChecked.Value))
            {
                foreach (var seatFilter in seatFilters.Where(f => (string) f.Tag == "NTSeat"))
                {
                    seatFilter.IsEnabled = false;
                }
            }
            if (typeFilters.All(f => f.IsChecked == null || !f.IsChecked.Value))
            {
                FilterWz.IsEnabled = false;
            }
        }

        private void SeatToTypeEnabled()
        {
            var typeFilters = FilterTypePanel.ChildrenOfType<CheckBox>().ToArray();
            var seatFilters = FilterSeatPanel.ChildrenOfType<CheckBox>().ToArray();
            if (seatFilters.All(f => f.IsChecked == null || f.IsChecked.Value == false))
            {
                foreach (var typeFilter in typeFilters)
                {
                    typeFilter.IsEnabled = false;
                }
            }
            else
            {
                foreach (var typeFilter in typeFilters)
                {
                    typeFilter.IsEnabled = true;
                }
            }
        }

        #endregion

        #region UI Event Handlers

        private void NormalQuery(object sender, RoutedEventArgs e)
        {
            ViewModel.QueryResult = QueryHelper.Query(ViewModel.QueryRequest);
            GC.Collect();
            Filter();
        }

        private void FilterTypeClick(object sender, RoutedEventArgs e)
        {
            TypeToSeatEnabled();
            Filter();
        }

        private void FilterSeatClick(object sender, RoutedEventArgs e)
        {
            SeatToTypeEnabled();
            Filter();
        }

        #endregion
    }
}