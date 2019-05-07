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
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Module.Controls.ValidationRules
{
    public class ValueCheckRules : ValidationRule
    {
        #region Properties

        public ValidationParams ValidationParam
        {
            get; set;
        } = new ValidationParams();

        #endregion Properties

        #region Methods

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || string.IsNullOrWhiteSpace(value as string))
            {
                if (ValidationParam.IsAllowEmpty)
                    return ValidationResult.ValidResult;
                return new ValidationResult(false, "Value cannot be null");
            }
            if (ValidationParam.DataType.ToUpper() == "FLOAT")
            {
                float number = 0;
                bool isOk = float.TryParse(value.ToString(), out number);
                if (!isOk)
                    return new ValidationResult(false, "Invalid number format");
                {
                    float minValue = 0;
                    bool isHasMinValue = float.TryParse(ValidationParam.MinValue, out minValue);
                    if (isHasMinValue)
                    {
                        if (number < minValue)
                            return new ValidationResult(false, "Input should greater then "+ minValue.ToString() );
                    }

                    float maxValue = 0;
                    bool isHasMaxValue = float.TryParse(ValidationParam.MaxValue, out maxValue);
                    if (isHasMaxValue)
                    {
                        if (number > maxValue)
                            return new ValidationResult(false, "Input should less then " + maxValue.ToString());
                    }
                }
            }

            if (ValidationParam.DataType.ToUpper() == "DOUBLE")
            {
                double number = 0;
                bool isOk = double.TryParse(value.ToString(), out number);
                if (!isOk)
                    return new ValidationResult(false, "Invalid number format");
                {
                    double minValue = 0;
                    bool isHasMinValue = double.TryParse(ValidationParam.MinValue, out minValue);
                    if (isHasMinValue)
                    {
                        if (number < minValue)
                            return new ValidationResult(false, "Input should greater then " + minValue.ToString());
                    }

                    double maxValue = 0;
                    bool isHasMaxValue = double.TryParse(ValidationParam.MaxValue, out maxValue);
                    if (isHasMaxValue)
                    {
                        if (number > maxValue)
                            return new ValidationResult(false, "Input should less then " + maxValue.ToString());
                    }
                }
            }
            if (ValidationParam.DataType.ToUpper() == "INT")
            {
                int number = 0;
                bool isOk = int.TryParse(value.ToString(), out number);
                if (!isOk)
                    return new ValidationResult(false, "Invalid number format");
                {
                    int minValue = 0;
                    bool isHasMinValue = int.TryParse(ValidationParam.MinValue, out minValue);
                    if (isHasMinValue)
                    {
                        if (number < minValue)
                            return new ValidationResult(false, "Input should greater then " + minValue.ToString());
                    }

                    int maxValue = 0;
                    bool isHasMaxValue = int.TryParse(ValidationParam.MaxValue, out maxValue);
                    if (isHasMaxValue)
                    {
                        if (number > maxValue)
                            return new ValidationResult(false, "Input should less then " + maxValue.ToString());
                    }
                }
            }
            Regex rgx = new Regex(ValidationParam.ValuePattern);
            string strValue = value.ToString();
            if (!rgx.IsMatch(strValue))
            {
                return new ValidationResult(false, "Input format error");
            }
            return ValidationResult.ValidResult;
        }

        #endregion Methods
    }
}