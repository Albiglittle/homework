using System;
using System.Windows.Forms;
using MissionImpossible.Helpers;
using System.Collections.Generic;
using MissionImpossible.Helpers.Validation;
using MissionImpossible.Views.Controls;

namespace MissionImpossible.Views
{
    internal partial class SearchView : Form
    {
        internal delegate void SearchEventHandler(string name, string year, string country, string director, string actor);

        internal event SearchEventHandler Search;

        internal bool ButtonEnable
        {
            get { return searchFormBtnSearch.Enabled; }
            set { searchFormBtnSearch.Enabled = value; }
        }

        internal SearchView(Form parentView)
        {
            InitializeComponent();

            Owner = parentView;
            CenterToParent();
        }

        private void searchFormBtnClear_Click(object sender, EventArgs e)
        {
            searchFormBtnClear.Enabled = false;

            searchViewName.Text = string.Empty;
            searchViewYear.Text = string.Empty;
            searchViewCountry.Text = string.Empty;
            searchViewDirector.Text = string.Empty;
            searchViewActor.Text = string.Empty;

            searchFormBtnClear.Enabled = true;
        }

        private void searchFormBtnSearch_Click(object sender, EventArgs e)
        {
            searchFormBtnSearch.Enabled = false;

            Dictionary<CustomTextBox, ValidationType> inputValTypeMap = new Dictionary<CustomTextBox, ValidationType>
            {
                { searchViewName, ValidationType.TitleValidation },
                { searchViewYear, ValidationType.YearValidation },
                { searchViewCountry, ValidationType.GeneralValidation },
                { searchViewDirector, ValidationType.GeneralValidation },
                { searchViewActor, ValidationType.GeneralValidation }
            };

            if (!ValidationViewHelper.ValidateCustomTextboxes(inputValTypeMap, toolTip, true))
            {
                searchFormBtnSearch.Enabled = true;
                return;
            }

            if (Search != null)
                Search(
                    searchViewName.Text,
                    searchViewYear.Text,
                    searchViewCountry.Text,
                    searchViewDirector.Text,
                    searchViewActor.Text);
        }
    }
}
