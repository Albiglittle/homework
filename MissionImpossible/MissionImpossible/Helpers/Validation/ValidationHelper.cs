using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MissionImpossible.Properties;

namespace MissionImpossible.Helpers.Validation
{
    internal static class ValidationHelper
    {
        private static readonly Dictionary<ValidationType, Tuple<Func<string, bool>, string>> ValidationMap =
            new Dictionary<ValidationType, Tuple<Func<string, bool>, string>>
        {
            { ValidationType.TitleValidation, new Tuple<Func<string, bool>, string>(ValidateTitle, Resources.ErrorTitleIsIncorrect) },
            { ValidationType.YearValidation, new Tuple<Func<string, bool>, string>(ValidateYear, Resources.ErrorYearIsIncorrect) },
            { ValidationType.GeneralValidation, new Tuple<Func<string, bool>, string>(ValidateGeneral, Resources.ErrorInvalidCharacters) }
        };

        internal static bool Validate(string text, ValidationType validationType)
        {
            return ValidationMap[validationType].Item1(text);
        }

        internal static string GetErrorMessage(ValidationType validationType)
        {
            return ValidationMap[validationType].Item2;
        }

        private static bool ValidateTitle(string text)
        {
            return Regex.IsMatch(text.ToLower(), @"^[а-яА-ЯA-Za-z0-9-!?\.\s ]+$");
        }

        private static bool ValidateYear(string text)
        {
            const int firstMovieYear = 1895;

            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            int year;
            if (!int.TryParse(text, out year))
            {
                return false;
            }

            return year >= firstMovieYear && year <= DateTime.Now.Year;
        }

        private static bool ValidateGeneral(string text)
        {
            return Regex.IsMatch(text, @"^[а-яА-ЯA-Za-z *?]+$");
        }
    }
}
