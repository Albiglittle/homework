using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MissionImpossible.Helpers;
using MissionImpossible.Helpers.Sort;
using MissionImpossible.Models;
using MissionImpossible.Properties;

namespace MissionImpossible.Views
{
    internal partial class MoviesView : Form
    {
        internal delegate void EditFilmEventHandler(string movieName);
        internal delegate void DeleteFilmEventHandler(List<string> movieNames);
        internal delegate void FindFilmEventHandler();
        internal delegate void AboutOpenEventHandler();
        internal delegate void OnSortEventHandler();
        internal delegate void OnReloadEventHandler();

        internal event EditFilmEventHandler EditFilm;
        internal event DeleteFilmEventHandler DeleteMovie;
        internal event FindFilmEventHandler FindFilm;
        internal event AboutOpenEventHandler AboutOpen;
        internal event OnSortEventHandler OnSort;
        internal event OnReloadEventHandler OnReload;

        private const int NameColumnIndex = 0;
        private const int YearColumnIndex = 2;

        private int _columnCount;
        private bool _isSortStarted;
        internal bool SortStarted
        {
            get { return _isSortStarted; }
            set { _isSortStarted = value; }
        }

        private SortDirection _sortDirection = SortDirection.Asc;
        private SortColumn _sortColumn = SortColumn.Name;
        internal SortDirection SortDirection
        {
            get { return _sortDirection; }
            set { _sortDirection = value; }
        }
        internal SortColumn SortColumn
        {
            get { return _sortColumn; }
            set { _sortColumn = value; }
        }

        internal ToolStripMenuItem ExitMenuItem { get { return exitToolStripMenuItem; } }
        internal ToolStripMenuItem FindMovieMenuItem { get { return findFilmToolStripMenuItem; } }


        private void AddMovieGridCellCaptions()
        {
            DataGridViewColumn[] columns =
            {
                new DataGridViewTextBoxColumn
                {
                    Name = Resources.AttributeName,
                    MaxInputLength = 32,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    },
                    Width = 150,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                },

                new DataGridViewImageColumn
                {
                    Name = Resources.AttributePoster,
                    Width = 200,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                },

                new DataGridViewTextBoxColumn
                {
                    Name = Resources.AttributeYear,
                    MaxInputLength = 4,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    },
                    Width = 50,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                },

                new DataGridViewTextBoxColumn
                {
                    Name = Resources.AttributeActor,
                    MaxInputLength = 32,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter,
                        WrapMode = DataGridViewTriState.True

                    },
                    Width = 160,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                },

                new DataGridViewTextBoxColumn
                {
                    Name = Resources.AttributeCountry,
                    MaxInputLength = 32,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    },
                    Width = 100,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                },

                new DataGridViewTextBoxColumn
                {
                    Name = Resources.AttributeDirector,
                    MaxInputLength = 32,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    },
                    Width = 150,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                }

            };

            _columnCount = columns.Length;

            gridView.Columns.AddRange(columns);
        }

        private void SetMovieGridStyle()
        {
            gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            gridView.AllowUserToAddRows = false;
            gridView.AllowUserToResizeRows = false;
            gridView.RowHeadersVisible = false;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
        }

        private void InitMovieGrid()
        {
            AddMovieGridCellCaptions();
            SetMovieGridStyle();

            for (int i = 0; i < _columnCount; i++)
            {
                gridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                gridView.Columns[i].ReadOnly = true;
            }
        }

        internal MoviesView()
        {
            InitializeComponent();

            KeyPreview = true;

            InitMovieGrid();

            Width = 900;

            ShowMovieGrid();
        }

        internal void SetGridTitle(string title)
        {
            InvokeIfNeeded(gridTitleLabel, () => gridTitleLabel.Text = title);
        }

        private static void InvokeIfNeeded(Control control, Action doit)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(doit);
            }
            else
            {
                doit();
            }
        }

        internal void ShowMovieGrid()
        {
            gridView.Show();
            gridTitleLabel.Show();
        }

        internal void UpdateGridView(List<Movie> movies)
        {
            gridView.Rows.Clear();

            for (int i = 0; i < movies.Count; i++)
            {
                gridView.Rows.Add(
                    movies[i].Name,
                    ImageHelper.LoadImage(movies[i].ImagePath),
                    movies[i].Year,
                    string.Format("{0}", string.Join(", ", movies[i].Actors.Select(x => x.Name))),
                    movies[i].Country,
                    movies[i].Director.Name
                    );
                gridView.Rows[i].Height = 190;
            }
        }

        private List<string> GetSelectedMovies()
        {
            var movieNames = new List<string>();
            foreach (DataGridViewRow row in gridView.SelectedRows)
            {
                var movieName = (string)row.Cells[0].Value;
                movieNames.Add(movieName);
            }
            return movieNames;
        }
        
        private void OnEditFilmToolStripMenuItemClicked(object sender, EventArgs e)
        {
            var selectedMovies = GetSelectedMovies();
            if (selectedMovies.Count > 0)
            {
                if (EditFilm != null) EditFilm(selectedMovies[0]);
            }
        }

        private void OnFindFilmToolStripMenuItemClicked(object sender, EventArgs e)
        {
            if (FindFilm != null) FindFilm();
        }

        private void OnAboutToolStripMenuItemClicked(object sender, EventArgs e)
        {
            if (AboutOpen != null) AboutOpen();
        }

        private void OnExitToolStripMenuItemClicked(object sender, EventArgs e)
        {
            Close();
        }

        private void CatalogView_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(Resources.ExitPrompt, Text, MessageBoxButtons.OKCancel);
            if (result.HasFlag(DialogResult.Cancel))
            {
                e.Cancel = true;
            }
        }

        private void deleteMovieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteMovie(GetSelectedMovies());
        }

        private Object _thisLock = new Object();

        private void OnMovieGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            var currentRowIndex = e.RowIndex;
            if (currentRowIndex != -1 || _isSortStarted) return;
            if (e.ColumnIndex == YearColumnIndex)
            {
                _isSortStarted = true;
                _sortDirection = _sortDirection == SortDirection.Asc ? SortDirection.Desc : SortDirection.Asc;
                _sortColumn = SortColumn.Year;
                if (OnSort != null) OnSort();
            }
            else if (e.ColumnIndex == NameColumnIndex)
            {
                _isSortStarted = true;
                _sortDirection = _sortDirection == SortDirection.Asc ? SortDirection.Desc : SortDirection.Asc;
                _sortColumn = SortColumn.Name;
                if (OnSort != null) OnSort();
            }
        }

        private void OnReloadToolStripMenuItemClicked(object sender, EventArgs e)
        {
            if (OnReload != null) OnReload();
        }

        private void MoviesView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

        }
    }
}
