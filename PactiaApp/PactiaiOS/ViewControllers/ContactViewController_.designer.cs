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
    [Register ("ContactViewController")]
    partial class ContactViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton buttonContactSend { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView pickerViewContactServiceLines { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView ScrollViewContact { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch switchContactAcceptCondition { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField textFieldContactMail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField textFieldContactMessage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField textFieldContactPhoneNumber { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField textFieldContactUser { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField textFileldContactBusinessName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UILabelContactTitle { get; set; }

        [Action ("switchContactAcceptConditionChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void switchContactAcceptConditionChanged (UIKit.UISwitch sender);

        void ReleaseDesignerOutlets ()
        {
            if (buttonContactSend != null) {
                buttonContactSend.Dispose ();
                buttonContactSend = null;
            }

            if (pickerViewContactServiceLines != null) {
                pickerViewContactServiceLines.Dispose ();
                pickerViewContactServiceLines = null;
            }

            if (ScrollViewContact != null) {
                ScrollViewContact.Dispose ();
                ScrollViewContact = null;
            }

            if (switchContactAcceptCondition != null) {
                switchContactAcceptCondition.Dispose ();
                switchContactAcceptCondition = null;
            }

            if (textFieldContactMail != null) {
                textFieldContactMail.Dispose ();
                textFieldContactMail = null;
            }

            if (textFieldContactMessage != null) {
                textFieldContactMessage.Dispose ();
                textFieldContactMessage = null;
            }

            if (textFieldContactPhoneNumber != null) {
                textFieldContactPhoneNumber.Dispose ();
                textFieldContactPhoneNumber = null;
            }

            if (textFieldContactUser != null) {
                textFieldContactUser.Dispose ();
                textFieldContactUser = null;
            }

            if (textFileldContactBusinessName != null) {
                textFileldContactBusinessName.Dispose ();
                textFileldContactBusinessName = null;
            }

            if (UILabelContactTitle != null) {
                UILabelContactTitle.Dispose ();
                UILabelContactTitle = null;
            }
        }
    }
}