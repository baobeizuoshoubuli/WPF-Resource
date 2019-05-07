//=============================================================================
//
// SHICHUANG CONFIDENTIAL
// __________________
//
//  [2016] - [2017] SHICHUANG Co., Ltd.
//  All Rights Reserved.
//
//=============================================================================
using Hpdc.Modules.Shell.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hpdc.Modules.Shell.Views
{
    /// <summary>
    /// WaitingAndProgress.xaml
    /// </summary>
    public partial class WaitingAndProgress : UserControl
    {
        #region Constructors

        public WaitingAndProgress()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        public void setPrecent(double d)
        {
            Storyboard b = (Storyboard)this.Resources["FillStoryboard"];
            DoubleAnimationUsingKeyFrames df = (DoubleAnimationUsingKeyFrames)b.Children[0];
            ColorAnimationUsingKeyFrames cf = (ColorAnimationUsingKeyFrames)b.Children[1];
            if (d >= 0 && d <= 10)
            {
                cf.KeyFrames[1].Value = ToColor("#FFFF3300");
            }
            if (d > 10 && d <= 20)
            {
                cf.KeyFrames[1].Value = ToColor("#FFFF6600");
            }
            if (d > 20 && d <= 30)
            {
                cf.KeyFrames[1].Value = ToColor("#FFFF9900");
            }
            if (d > 30 && d <= 40)
            {
                cf.KeyFrames[1].Value = ToColor("#FFFFCC00");
            }
            if (d > 40 && d <= 50)
            {
                cf.KeyFrames[1].Value = ToColor("#FFFFFF00");
            }
            if (d > 50 && d <= 60)
            {
                cf.KeyFrames[1].Value = ToColor("#FFCCFF00");
            }
            if (d > 60 && d <= 70)
            {
                cf.KeyFrames[1].Value = ToColor("#FF99FF00");
            }
            if (d > 70 && d <= 80)
            {
                cf.KeyFrames[1].Value = ToColor("#FF66FF00");
            }
            if (d > 80 && d <= 90)
            {
                cf.KeyFrames[1].Value = ToColor("#FF33FF00");
            }
            if (d > 90 && d <= 100)
            {
                cf.KeyFrames[1].Value = ToColor("#FF00FF00");
            }
            df.KeyFrames[1].Value = d * 3.6;
            b.Begin();
        }

        public Color ToColor(string colorName)
        {
            if (colorName.StartsWith("#"))
                colorName = colorName.Replace("#", string.Empty);
            int v = int.Parse(colorName, System.Globalization.NumberStyles.HexNumber);
            return new Color()
            {
                A = Convert.ToByte((v >> 24) & 255),
                R = Convert.ToByte((v >> 16) & 255),
                G = Convert.ToByte((v >> 8) & 255),
                B = Convert.ToByte((v >> 0) & 255)
            };
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard b1 = (Storyboard)this.Resources["MainStoryboard"];
            b1.Stop();
            ShowArea.Visibility = System.Windows.Visibility.Hidden;
            ShowLabel.Visibility = System.Windows.Visibility.Visible;
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            Storyboard b = (Storyboard)this.Resources["FillStoryboard"];
            ColorAnimationUsingKeyFrames cf = (ColorAnimationUsingKeyFrames)b.Children[1];
            DoubleAnimationUsingKeyFrames df = (DoubleAnimationUsingKeyFrames)b.Children[0];
            df.KeyFrames[0].Value = df.KeyFrames[1].Value;
            cf.KeyFrames[0].Value = cf.KeyFrames[1].Value;
        }

        #endregion Methods
    }

    public partial class WaitingAndProgress
    {
        #region Fields

        public static readonly DependencyProperty CurrentCycleProperty =
            DependencyProperty.Register("CurrentCycle",
                              typeof(int),
                              typeof(WaitingAndProgress),
                              new PropertyMetadata(new int(),
                              new PropertyChangedCallback(OnProgressChanged)));

        public static readonly DependencyProperty CurrentNodeProperty =
            DependencyProperty.Register("CurrentNode",
                typeof(int),
                typeof(WaitingAndProgress),
                new PropertyMetadata(new int(),
                    new PropertyChangedCallback(OnProgressChanged)) );

        public static readonly DependencyProperty CurrentNodeProgressProperty =
       DependencyProperty.Register("CurrentNodeProgress",
           typeof(int),
           typeof(WaitingAndProgress),
           new PropertyMetadata(new int(),
               new PropertyChangedCallback(OnProgressChanged)));

        #endregion Fields

        #region Properties

        public int CurrentCycle
        {
            get { return (int)GetValue(CurrentCycleProperty); }
            set { SetValue(CurrentCycleProperty, value); }
        }

        public int CurrentNode
        {
            get { return (int)GetValue(CurrentNodeProperty); }
            set { SetValue(CurrentNodeProperty, value); }
        }

        public int CurrentNodeProgress
        {
            get { return (int)GetValue(CurrentNodeProgressProperty); }
            set { SetValue(CurrentNodeProgressProperty, value); }
        }

        #endregion Properties

        #region Methods

        private static void OnProgressChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var item = d as WaitingAndProgress;
            item.setPrecent(Convert.ToDouble( e.NewValue));
        }

        #endregion Methods
    }
}