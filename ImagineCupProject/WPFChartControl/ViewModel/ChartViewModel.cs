﻿using System.ComponentModel;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Media;
using ImagineCupProject.WPFChartControl.Model;
using ImagineCupProject.WPFChartControl.Drawer;

namespace ImagineCupProject.WPFChartControl.ViewModel
{
    class ChartViewModel : INotifyPropertyChanged
    {
        private string xAxisText = string.Empty;
        private string yAxisText = string.Empty;
        private Visibility horizScrollVisibility = Visibility.Collapsed;
        private Visibility vertScrollVisibility = Visibility.Collapsed;
        private Visibility legendVisibility = Visibility.Collapsed;
        private ObservableCollection<LegendItem> legend = new ObservableCollection<LegendItem>();
        private Brush background;
        private double legendWidth;

        public void Update(AbstractChartDrawer drawer)
        {
            XAxisText = drawer.XAxisText;
            YAxisText = drawer.YAxisText;
            HorizScrollVisibility = drawer.HorizScrollVisibility;
            VertScrollVisibility = drawer.VertScrollVisibility;
            LegendVisibility = drawer.Legend != null && drawer.LegendWidth != 0.0d ? Visibility.Visible : Visibility.Collapsed;
            Background = drawer.Background; 
            LegendWidth = drawer.LegendWidth;
            legend.Clear();
            if (drawer.Legend != null)
            {
                foreach (var it in drawer.Legend)
                {
                    legend.Add(it);
                }
            }
        }

        public string XAxisText 
        {
            get
            {
                return xAxisText;
            }

            set
            {
                if (xAxisText != value)
                {
                    xAxisText = value;
                    OnPropertyChanged("XAxisText");
                }
            }
        }

        public string YAxisText
        {
            get
            {
                return yAxisText;
            }

            set
            {
                if (yAxisText != value)
                {
                    yAxisText = value;
                    OnPropertyChanged("YAxisText");
                }
            }
        }

        public Visibility HorizScrollVisibility
        {
            get
            {
                return horizScrollVisibility;
            }

            set
            {
                if (horizScrollVisibility != value)
                {
                    horizScrollVisibility = value;
                    OnPropertyChanged("HorizScrollVisibility");
                }
            }
        }

        public Visibility VertScrollVisibility
        {
            get
            {
                return vertScrollVisibility;
            }

            set
            {
                if (vertScrollVisibility != value)
                {
                    vertScrollVisibility = value;
                    OnPropertyChanged("VertScrollVisibility");
                }
            }
        }

        public Visibility LegendVisibility
        {
            get
            {
                return legendVisibility;
            }

            set
            {
                if (legendVisibility != value)
                {
                    legendVisibility = value;
                    OnPropertyChanged("LegendVisibility");
                }
            }
        }

        public double LegendWidth
        {
            get
            {
                return legendWidth;
            }

            set
            {
                if (legendWidth != value)
                {
                    legendWidth = value;
                    OnPropertyChanged("LegendWidth");
                }
            }
        }

        public ObservableCollection<LegendItem> Legend
        {
            get
            {
                return legend;
            }
        }

        public Brush Background
        {
            get
            {
                return background;
            }

            set
            {
                if (background != value)
                {
                    background = value;
                    OnPropertyChanged("Background");
                }
            }
        }

        #region INotifyPropertyChanged part
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
