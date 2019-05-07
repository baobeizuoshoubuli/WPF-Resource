//=============================================================================
//
// SHICHUANG CONFIDENTIAL
// __________________
//
//  [2016] - [2018] SHICHUANG Co., Ltd.
//  All Rights Reserved.
//
//=============================================================================

using System;
using System.Windows;

namespace Module.Controls
{
    public class BindingProxy : Freezable
    {
        #region Fields

        public static readonly DependencyProperty ValidationParamProperty =
            DependencyProperty.Register("ValidationParam", typeof(ValidationParams), typeof(BindingProxy), new PropertyMetadata(null));

        #endregion Fields

        #region Properties

        public ValidationParams ValidationParam
        {
            get { return (ValidationParams)GetValue(ValidationParamProperty); }
            set { SetValue(ValidationParamProperty, value); }
        }

        #endregion Properties

        #region Methods

        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }

        #endregion Methods
    }

    public class ValidationParams : DependencyObject
    {
        #region Fields

        public static readonly DependencyProperty IsAllowEmptyProperty =
    DependencyProperty.Register("IsAllowEmpty", typeof(bool), typeof(ValidationParams), new PropertyMetadata(false));

        public static readonly DependencyProperty MinValueProperty =
    DependencyProperty.Register("MinValue", typeof(string), typeof(ValidationParams), new PropertyMetadata(""));

        public static readonly DependencyProperty MaxValueProperty =
    DependencyProperty.Register("MaxValue", typeof(string), typeof(ValidationParams), new PropertyMetadata(""));

        public static readonly DependencyProperty ValuePatternProperty =
    DependencyProperty.Register("ValuePattern", typeof(string), typeof(ValidationParams), new PropertyMetadata(""));

        public static readonly DependencyProperty DataTypeProperty =
    DependencyProperty.Register("DataType", typeof(string), typeof(ValidationParams), new PropertyMetadata("string"));

        #endregion Fields

        #region Properties

        public bool IsAllowEmpty
        {
            get { return (bool)GetValue(IsAllowEmptyProperty); }
            set { SetValue(IsAllowEmptyProperty, value); }
        }

        public string MinValue
        {
            get { return (string)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        public string MaxValue
        {
            get { return (string)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        public string ValuePattern
        {
            get { return (string)GetValue(ValuePatternProperty); }
            set { SetValue(ValuePatternProperty, value); }
        }

        public string DataType
        {
            get { return (string)GetValue(DataTypeProperty); }
            set { SetValue(DataTypeProperty, value); }
        }

        #endregion Properties
    }
}