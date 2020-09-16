using System.Windows.Media;

namespace TinyneProject.Models
{
    /// <summary>
    /// Static class for <seealso cref="Note"/>'s instance extension
    /// </summary>
    public static class NoteManager
    {
        /// <summary>
        /// Aliases for note's background resources
        /// </summary>
        public enum BackgroundBrushes
        {
            /// <summary>
            /// Corresponds to the RedBackgroundBrush
            /// </summary>
            Default,
            /// <summary>
            /// Corresponds to the RedBackgroundBrush
            /// </summary>
            Red,
            /// <summary>
            /// Corresponds to the GreenBackgroundBrush
            /// </summary>
            Green,
            /// <summary>
            /// Corresponds to the BlueBackgroundBrush
            /// </summary>
            Blue,
            /// <summary>
            /// Corresponds to the YellowBackgroundBrush
            /// </summary>
            Yellow,
            /// <summary>
            /// Corresponds to the BlackBackgroundBrush
            /// </summary>
            Black
        }

        /// <summary>
        /// Gets the name of the resource corresponding to the <paramref name="brush"/>
        /// </summary>
        /// <param name="brush"></param>
        /// <returns></returns>
        public static string Name(this BackgroundBrushes brush)
        {
            switch (brush)
            {
                case BackgroundBrushes.Default:
                    return "RedBackgroundBrush";
                case BackgroundBrushes.Red:
                    return "RedBackgroundBrush";
                case BackgroundBrushes.Green:
                    return "GreenBackgroundBrush";
                case BackgroundBrushes.Blue:
                    return "BlueBackgroundBrush";
                case BackgroundBrushes.Yellow:
                    return "YellowBackgroundBrush";
                case BackgroundBrushes.Black:
                    return "BlackBackgroundBrush";
                default:
                    return "RedBackgroundBrush";
            }
        }


        /// <summary>
        /// Gets background brush according to the <paramref name="brush"/>
        /// </summary>
        /// <param name="brush"></param>
        /// <returns></returns>
        public static SolidColorBrush GetBrush(BackgroundBrushes brush)
        {
            SolidColorBrush colorBrush = null;
            try
            {
                colorBrush = (SolidColorBrush)App.Current.FindResource(brush.Name());
            }
            catch
            {
                colorBrush = (SolidColorBrush)App.Current.FindResource(BackgroundBrushes.Default.Name());
            }
            return colorBrush;
        }


        /// <summary>
        /// Gets default background brush
        /// </summary>
        /// <returns></returns>
        public static SolidColorBrush SetBrush()
        {
            return NoteManager.GetBrush(BackgroundBrushes.Default);
        }
    }
}
