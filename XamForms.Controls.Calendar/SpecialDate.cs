using System;
using Xamarin.Forms;

namespace XamForms.Controls
{
    public class SpecialDate
    {
        public SpecialDate(DateTime date)
        {
            Date = date;
        }

        public DateTime Date { get; set; }
        public Color? TextColor { get; set; }
        public Color? BackgroundColor { get; set; }
        public Color? BorderColor { get; set; }
        public FontAttributes? FontAttributes { get; set; }
        public string FontFamily { get; set; }
        public int? BorderWidth { get; set; }
        public double? FontSize { get; set; }
        public bool Selectable { get; set; }

        /// <summary>
        /// Gets or sets the background image (only working on iOS and Android).
        /// </summary>
        /// <value>The background pattern.</value>
        public FileImageSource BackgroundImage { get; set; }

        /// <summary>
        /// Gets or sets the background pattern (only working on iOS and Android).
        /// </summary>
        /// <value>The background pattern.</value>
        public BackgroundPattern BackgroundPattern { get; set; }
    }
}
