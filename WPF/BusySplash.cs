using System;

namespace Extender.WPF
{
    /// <remarks>
    /// Contains static methods for the display of a splash screen while work is done.
    /// </remarks>
    public static class BusySplash
    {
        /// <summary>
        /// Displays a splash screen while an Action is invoked, then automatically
        /// closes it.
        /// </summary>
        /// <param name="work">Action to execute while the splash displays.</param>
        /// <param name="splashImagePath">Path to the image to be displayed as the splash screen.</param>
        public static void Show(Action work, string splashImagePath)
        {
            Show(work, splashImagePath, 200);
        }

        /// <summary>
        /// Displays a splash screen while an Action is invoked, then automatically
        /// closes it.
        /// </summary>
        /// <param name="work">Action to execute while the splash displays.</param>
        /// <param name="splashImagePath">Path to the image to be displayed as the splash screen.</param>
        /// <param name="fadeDuration">Duration (in milliseconds) to fade out the splash screen over.</param>
        public static void Show(Action work, string splashImagePath, double fadeDuration)
        {
            System.Windows.SplashScreen splash = new System.Windows.SplashScreen(splashImagePath);
            splash.Show(false);

            if (work != null)
                work.Invoke();

            splash.Close(TimeSpan.FromMilliseconds(fadeDuration));
        }
    }
}
