using MissionImpossible.Properties;
using System.Drawing;

namespace MissionImpossible.Helpers
{
    static class ImageHelper
    {
        internal static Image LoadImage(string path)
        {
            return string.IsNullOrEmpty(path) ? Resources.DefaultMovieImage : Image.FromFile(path);
        }
    }
}
