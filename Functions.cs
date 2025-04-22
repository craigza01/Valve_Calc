/*
 * Copyright (c) 2025, Craig Fawkes, Munster Technological University, Cork, Ireland
 * Author:
 *    Craig Fawkes <craig.fawkes@mycit.ie>,
 *     
 *
 * This source code is licensed under the MIT license found in the
 * LICENSE file in the root directory of this source tree.
 */

using System;
using System.Buffers;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Windows.Data;

namespace Valve_Calc;
public static class Functions
{
    //public Functions()
    //{
    //}

    public static void lblHide(this System.Windows.Controls.Label lbl)
    {
        if (lbl != null)
        {
            lbl.Content = "";
            lbl.Visibility = System.Windows.Visibility.Hidden;
        }
    }

    public static void lblPopulate(this System.Windows.Controls.Label lbl, string s)
    {
        if (lbl != null)
        {
            lbl.Content = s;
            lbl.Visibility = System.Windows.Visibility.Visible;
        }
    }

    public static void ddlFlowDirectionInit(this System.Windows.Controls.ComboBox cb, string s)
    {
        cb.Items.Clear();
        cb.Items.Add(s);
        cb.SelectedIndex = 0;
    }

    private static readonly SearchValues<char> NumericSearchValues = SearchValues.Create(['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '.']);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void AddNumberToList(ReadOnlySpan<char> numberSpan, List<double> numbers)
    {
        if (double.TryParse(numberSpan, NumberStyles.Any, CultureInfo.InvariantCulture, out var number))
        {
            numbers.Add(number);
        }
    }

    public static string ExtractNumberUsingSpan(this string? inputString)
    {
        var numbers = new List<double>();

        var inputStringSpan = inputString.AsSpan();
        while (true)
        {
            var startIndex = inputStringSpan.IndexOfAny(NumericSearchValues);
            if (startIndex == -1)
                break;

            inputStringSpan = inputStringSpan[startIndex..];

            var endIndex = inputStringSpan.IndexOfAnyExcept(NumericSearchValues);
            if (endIndex == -1)
            {
                AddNumberToList(inputStringSpan, numbers);
                break;
            }

            AddNumberToList(inputStringSpan[..endIndex], numbers);
            inputStringSpan = inputStringSpan[endIndex..];
        }

        return string.Join(",", numbers);
    }

    public static  string GetDescriptionFromAttribute(this Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        if (fieldInfo == null) return value.ToString();
        var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attributes.Any() ? attributes[0].Description : value.ToString();
    }   
    
    
}
