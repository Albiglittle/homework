using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        private void AboutView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
