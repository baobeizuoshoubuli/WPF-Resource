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
using System.Windows.Controls;
using System.Windows.Input;

namespace Module.Controls
{
    /// <summary>
    /// Interaction logic for EditableTextBoxWithRulexaml.xaml
    /// </summary>
    public partial class TextBoxWithRule : UserControl
    {
        #region Fields

        public static readonly DependencyProperty ValidationParamProperty =
     DependencyProperty.Register("ValidationParam", typeof(ValidationParams), typeof(TextBoxWithRule));

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
            "Text",
            typeof(string),
            typeof(TextBoxWithRule),
            new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

  
        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register(
            "IsReadOnly",
            typeof(bool),
            typeof(TextBoxWithRule),
            new PropertyMetadata(false));


        #endregion Fields



        #region Constructors

        public TextBoxWithRule()
        {
            InitializeComponent();
            base.Focusable = true;
            base.FocusVisualStyle = null;
            this.KeyDown += TextBoxWithRule_KeyDown;

        }

        private void TextBoxWithRule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
                UIElement focusElement = Keyboard.FocusedElement as UIElement;
                if (focusElement != null)
                {
                    focusElement.MoveFocus(request);
                }
                e.Handled = true;
            }
        }

        #endregion Constructors       
        #region Properties

        public ValidationParams ValidationParam
        {
            get { return (ValidationParams)GetValue(ValidationParamProperty); }
            set { SetValue(ValidationParamProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }

        }

        #endregion Properties
    }
}