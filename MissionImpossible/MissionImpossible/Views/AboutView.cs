using System;
using System.Windows.Forms;

namespace MissionImpossible.Views
{
    public partial class AboutView : Form
    {
        public AboutView()
        {
            InitializeComponent();
        }

        private void OnOkButtonClicked(object sender, EventArgs e)
        {
            Close();
        }
    }
}
