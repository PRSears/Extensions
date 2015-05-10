
namespace Extender.WPF
{
    /// <summary>
    /// Contains static methods for the display and handling of a confirmation dialog box.
    /// </summary>
    public static class ConfirmationDialog
    {
        /// <summary>
        /// Displays a message box with YesNo controls prompting the user for a confirmation.
        /// </summary>
        /// <param name="title">Text to include as the title of the message box.</param>;
        /// <param name="text">Message displayed to the user in the message box.</param>
        /// <returns>Returns True if the user clicked yes, false otherwise.</returns>
        public static bool Show(string title, string text)
        {
            System.Windows.Forms.DialogResult r = System.Windows.Forms.MessageBox.Show
            (
                text,
                title,
                System.Windows.Forms.MessageBoxButtons.YesNo
            );

            if (r == System.Windows.Forms.DialogResult.Yes)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Displays a message box containing a generic confirmation message
        /// with YesNo controls prompting the user for a confirmation.
        /// </summary>
        /// <returns>Returns True if the user clicked yes, false otherwise.</returns>
        public static bool Show()
        {
            return ConfirmationDialog.Show
            (
                "Confirm",
                "Are you sure?\nAny unsaved changes will be lost."
            );
        }
    }
}
