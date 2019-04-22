using UIKit;
using System.Collections.Generic;
using System;
namespace XamariniOSUIPicker
{
    public class UIPickerViewServiceLinesModel : UIPickerViewModel
    {
        List<string> ServiceLines;
        public EventHandler ValueChanged;
        public string SelectedValue;
        public UIPickerViewServiceLinesModel(List<string> ServiceLines)
        {
            this.ServiceLines = ServiceLines;
        }
        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return ServiceLines.Count;
        }
        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }
        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return ServiceLines[(int)row];
        }
        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            var serviceLines = ServiceLines[(int)row];
            SelectedValue = serviceLines;
            ValueChanged?.Invoke(null, null);
        }
    }
}