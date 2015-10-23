
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.DataForm;

namespace Searching.UI.WinClient.Forms
{
    public partial class RegistrationForm : PhoneApplicationPage
    {
        const string PasswordFieldName = "Password";
        const string PasswordConfirmationFieldName = "PasswordConfirm";
        const string PasswordFieldsDifferMessage = "The Password and Confirmation Password must match.";

        public RegistrationForm()
        {
            InitializeComponent();
        }

        void OnDataFormValidatingDataField(object sender, ValidatingDataFieldEventArgs e)
        {
            if (e.AssociatedDataField.PropertyKey != PasswordConfirmationFieldName)
            {
                return;
            }
            PasswordField originalPassword = this.DataForm.FindFieldByPropertyName(PasswordFieldName) as PasswordField;
            if (originalPassword != null)
            {
                if ((string)originalPassword.Value != (string)e.AssociatedDataField.Value)
                {
                    e.IsInputValid = false;
                    e.ValidationMessage = PasswordFieldsDifferMessage;
                }
            }
        }
    }
}
