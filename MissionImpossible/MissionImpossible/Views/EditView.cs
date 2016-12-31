using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MissionImpossible.Models;
using System.Linq;
using MissionImpossible.Helpers;
using MissionImpossible.Helpers.Validation;
using MissionImpossible.Properties;
using MissionImpossible.Views.Controls;

namespace MissionImpossible.Views
{
    public partial class EditView : Form
    {
        internal delegate void SaveMovieEventHandler();
        internal event SaveMovieEventHandler SaveMovie;

        readonly Movie _movie;

        public EditView(Movie movie)
        {
            InitializeComponent();

            _movie = movie;

            editFormName.Text = _movie.Name;
            editFormYear.Text = _movie.Year.ToString();
            editFormDirector.Text = _movie.Director.Name;
            editFormCountry.Text = _movie.Country;

            editFormActorsListView.LabelEdit = true;
            editFormActorsListView.Items.Clear();
            editFormActorsListView.Items.AddRange(_movie.Actors.Select(x => new ListViewItem(x.Name)).ToArray());

            InitHelpProvider();
        }

        private void InitHelpProvider()
        {
            var textBoxes = new[]
            {
                editFormName,
                editFormYear,
                editFormDirector,
                editFormCountry
            };

            Array.ForEach(textBoxes, x => { helpProvider.SetShowHelp(x, true); });

            helpProvider.SetHelpString(editFormName, Resources.NameToolTip);
            helpProvider.SetHelpString(editFormYear, Resources.YearToolTip);
            helpProvider.SetHelpString(editFormDirector, Resources.DirectorToolTip);
            helpProvider.SetHelpString(editFormCountry, Resources.CountryToolTip);

            HelpButton = true;
        }

        private void editMovieOkBtn_Click(object sender, EventArgs e)
        {
            if (!CheckInputFields())
            {
                return;
            }

            _movie.Name = editFormName.Text;
            _movie.Year = uint.Parse(editFormYear.Text);
            _movie.Director.Name = editFormDirector.Text;
            
            var actors = new List<Actor>(); 
            for (int i = 0; i < editFormActorsListView.Items.Count; i++)
            {
                actors.Add(new Actor { Name = editFormActorsListView.Items[i].Text });
            }
            _movie.Actors = actors;

            if (SaveMovie != null) SaveMovie();
        }

        private bool CheckInputFields()
        {
            Dictionary<CustomTextBox, ValidationType> inputValTypeMap = new Dictionary<CustomTextBox, ValidationType> 
            {
                { editFormName, ValidationType.TitleValidation },
                { editFormYear, ValidationType.YearValidation },
                { editFormDirector, ValidationType.GeneralValidation },
                { editFormCountry, ValidationType.GeneralValidation }
            };

            if (!ValidationViewHelper.ValidateCustomTextboxes(inputValTypeMap, toolTip))
            {
                return false;
            }

            return ValidationViewHelper.ValidateListView(editFormActorsListView, toolTip);
        }

        private void OnCloseButtonPressed(object sender, EventArgs e)
        {
            Close();
        }
    }
}
