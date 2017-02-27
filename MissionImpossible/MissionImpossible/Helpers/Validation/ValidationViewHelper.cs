using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MissionImpossible.Properties;
using MissionImpossible.Views.Controls;

namespace MissionImpossible.Helpers.Validation
{
    internal static class ValidationViewHelper
    {
        internal static int ToolTipTimeMillis = 5000;

        internal static bool ValidateCustomTextboxes(
            Dictionary<CustomTextBox, ValidationType> inputValTypeMap,
            ToolTip toolTip,
            bool allowEmpty = false)
        {
            foreach (var input in inputValTypeMap)
            {
                if (allowEmpty && input.Key.Text == string.Empty)
                {
                    input.Key.PaintBordersDefault();
                    continue;
                }

                bool validated = ValidationHelper.Validate(input.Key.Text, input.Value);
                if (!validated)
                {
                    input.Key.PaintBordersRed();

                    toolTip.ToolTipTitle = Resources.InvalidInput;
                    toolTip.Show(
                        ValidationHelper.GetErrorMessage(input.Value),
                        input.Key,
                        new Point(input.Key.Width, 0),
                        ToolTipTimeMillis);

                    input.Key.Focus();

                    return false;
                }
                else
                {
                    input.Key.PaintBordersDefault();
                }
            }

            return true;
        }

        internal static bool ValidateListView(ListView listView, ToolTip toolTip)
        {
            foreach (ListViewItem item in listView.Items)
            {
                const ValidationType valType = ValidationType.GeneralValidation;
                bool validated = ValidationHelper.Validate(item.Text, valType);
                if (!validated)
                {
                    if (item.Text == "")
                    {
                        item.Text = Resources.ValidationViewHelper_ValidateListView_NoName;
                    }
                    toolTip.ToolTipTitle = Resources.InvalidInput;
                    toolTip.Show(
                        ValidationHelper.GetErrorMessage(valType),
                        listView,
                        new Point(listView.Width, 0),
                        ToolTipTimeMillis);

                    item.Selected = true;
                    listView.Select();

                    return false;
                }
            }

            return true;
        }
    }
}
