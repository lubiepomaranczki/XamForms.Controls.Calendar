using Xamarin.Forms;

namespace XamForms.Controls
{
    public struct Pattern
    {
        public float WidthPercent { get; set; }
        public float HightPercent { get; set; }
        public Color Color { get; set; }

        public string Text { get; set; }
        public Color TextColor { get; set; }
        public float TextSize { get; set; }
        public TextAlign TextAlign { get; set; }
    }
}
