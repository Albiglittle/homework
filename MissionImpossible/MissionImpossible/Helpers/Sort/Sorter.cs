using System;
using System.Collections.Generic;
using System.Linq;
using MissionImpossible.Models;

namespace MissionImpossible.Helpers.Sort
{
    public static class Sorter
    {
        public static IEnumerable<Movie> Sort(IEnumerable<Movie> movies, SortHelper query)
        {
            switch (query.Column)
            {
                case SortColumn.Name:
                    return query.Direction == SortDirection.Asc
                        ? movies.OrderBy(x => x.Name)
                        : movies.OrderByDescending(x => x.Name);

                case SortColumn.Year:
                    return query.Direction == SortDirection.Asc
                        ? movies.OrderBy(x => x.Year)
                        : movies.OrderByDescending(x => x.Year);

                default:
                    throw new ArgumentException();
            }
        }
    }
}
