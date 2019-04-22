// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PactiaiOS
{
    [Register ("Meeting_ViewController")]
    partial class Meeting_ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton buttonMeetingSend { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView pickerViewMeetingServiceLiness { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView ScrollViewMeeting { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch switchMeetingAcceptConditions { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField textFieldMeetingMail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField textFieldMeetingMessage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField textFieldMeetingPhoneNumber { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField textFieldMeetingUser { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField textFileldMeetingBusinessName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UILabelMeetingTitle { get; set; }

        [Action ("switchMeetingAcceptConditionChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void switchMeetingAcceptConditionChanged (UIKit.UISwitch sender);

        void ReleaseDesignerOutlets ()
        {
            if (buttonMeetingSend != null) {
                buttonMeetingSend.Dispose ();
                buttonMeetingSend = null;
            }

            if (pickerViewMeetingServiceLiness != null) {
                pickerViewMeetingServiceLiness.Dispose ();
                pickerViewMeetingServiceLiness = null;
            }

            if (ScrollViewMeeting != null) {
                ScrollViewMeeting.Dispose ();
                ScrollViewMeeting = null;
            }

            if (switchMeetingAcceptConditions != null) {
                switchMeetingAcceptConditions.Dispose ();
                switchMeetingAcceptConditions = null;
            }

            if (textFieldMeetingMail != null) {
                textFieldMeetingMail.Dispose ();
                textFieldMeetingMail = null;
            }

            if (textFieldMeetingMessage != null) {
                textFieldMeetingMessage.Dispose ();
                textFieldMeetingMessage = null;
            }

            if (textFieldMeetingPhoneNumber != null) {
                textFieldMeetingPhoneNumber.Dispose ();
                textFieldMeetingPhoneNumber = null;
            }

            if (textFieldMeetingUser != null) {
                textFieldMeetingUser.Dispose ();
                textFieldMeetingUser = null;
            }

            if (textFileldMeetingBusinessName != null) {
                textFileldMeetingBusinessName.Dispose ();
                textFileldMeetingBusinessName = null;
            }

            if (UILabelMeetingTitle != null) {
                UILabelMeetingTitle.Dispose ();
                UILabelMeetingTitle = null;
            }
        }
    }
}