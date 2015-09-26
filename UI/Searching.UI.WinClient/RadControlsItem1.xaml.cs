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

namespace Searching.UI.WinClient
{
    public partial class RadControlsItem1 : PhoneApplicationPage
    {

        public RadControlsItem1()
        {
            InitializeComponent();

        }

        private void RadDataBoundListBox_IsCheckModeActiveChanged(object sender, Telerik.Windows.Controls.IsCheckModeActiveChangedEventArgs e)
        {
            RadDataBoundListBox listBox = sender as RadDataBoundListBox;
            if (listBox == null)
            {
                return;
            }

            if (listBox.IsCheckModeActive)
            {
                this.MainPivot.IsLocked = true;
            }
            else
            {
                this.MainPivot.IsLocked = false;
            }

        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            if (this.MainPivot.SelectedIndex == 0)
            {
                this.DataBoundListBox1.IsCheckModeActive ^= true;
            }
            else
            {
                this.DataBoundListBox2.IsCheckModeActive ^= true;
            }
        }
    }
}