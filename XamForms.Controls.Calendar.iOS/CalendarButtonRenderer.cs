using XamForms.Controls;
using XamForms.Controls.iOS;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreGraphics;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
#if __UNIFIED__
using Foundation;
#else
using MonoTouch.Foundation;
#endif

[assembly: Xamarin.Forms.ExportRenderer(typeof(CalendarButton), typeof(CalendarButtonRenderer))]
namespace XamForms.Controls.iOS
{
    [Preserve(AllMembers = true)]
    public class CalendarButtonRenderer : ButtonRenderer
    {
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var element = Element as CalendarButton;

            if (Control == null)
            {
                return;
            }

            if (e.PropertyName == nameof(element.TextWithoutMeasure) || e.PropertyName == "Renderer")
            {
                Control.SetTitle(element.TextWithoutMeasure, UIControlState.Normal);
                Control.SetTitle(element.TextWithoutMeasure, UIControlState.Disabled);
            }
            if (e.PropertyName == nameof(element.TextColor) || e.PropertyName == "Renderer")
            {
                Control.SetTitleColor(element.TextColor.ToUIColor(), UIControlState.Disabled);
                Control.SetTitleColor(element.TextColor.ToUIColor(), UIControlState.Normal);
            }
            if (e.PropertyName == nameof(element.BackgroundPattern))
            {
                DrawBackgroundPattern();
            }
            if (e.PropertyName == nameof(element.BackgroundImage))
            {
                DrawBackgroundImage();
            }
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            Control.SetBackgroundImage(null, UIControlState.Normal);
            Control.SetBackgroundImage(null, UIControlState.Disabled);
            DrawBackgroundImage();
            DrawBackgroundPattern();
        }

        protected async void DrawBackgroundImage()
        {
            var element = Element as CalendarButton;
            if (element == null || element.BackgroundImage == null)
            {
                return;
            }

            var image = await GetImage(element.BackgroundImage);
            Control.SetBackgroundImage(image, UIControlState.Normal);
            Control.SetBackgroundImage(image, UIControlState.Disabled);
        }

        protected void DrawBackgroundPattern()
        {
            if (!(Element is CalendarButton element) || element.BackgroundPattern == null || Control.Frame.Width == 0)
            {
                return;
            }

            UIImage image;
            UIGraphics.BeginImageContext(Control.Frame.Size);

            using (CGContext g = UIGraphics.GetCurrentContext())
            {
                for (var i = 0; i < element.BackgroundPattern.Pattern.Count; i++)
                {
                    var p = element.BackgroundPattern.Pattern[i];
                    g.SetFillColor(p.Color.ToCGColor());
                    var l = (int)Math.Ceiling(Control.Frame.Width * element.BackgroundPattern.GetLeft(i));
                    var t = (int)Math.Ceiling(Control.Frame.Height * element.BackgroundPattern.GetTop(i));
                    var w = (int)Math.Ceiling(Control.Frame.Width * element.BackgroundPattern.Pattern[i].WidthPercent);
                    var h = (int)Math.Ceiling(Control.Frame.Height * element.BackgroundPattern.Pattern[i].HightPercent);
                    var r = new CGRect { X = l, Y = t, Width = w, Height = h };
                    g.FillRect(r);
                    DrawText(g, p, r);
                }

                image = UIGraphics.GetImageFromCurrentImageContext();
            }

            UIGraphics.EndImageContext();
            Control.SetBackgroundImage(image, UIControlState.Normal);
            Control.SetBackgroundImage(image, UIControlState.Disabled);
        }

        private Task<UIImage> GetImage(FileImageSource image)
        {
            var handler = new FileImageSourceHandler();
            return handler.LoadImageAsync(image);
        }

        protected void DrawText(CGContext graphicContext, Pattern pattern, CGRect rectangle)
        {
            if (string.IsNullOrEmpty(pattern.Text))
            {
                return;
            }
            var bounds = pattern.Text.StringSize(UIFont.FromName("Helvetica", pattern.TextSize));

            var al = (int)pattern.TextAlign;
            var x = rectangle.X;

            if ((al & 2) == 2) // center
            {
                x = rectangle.X + (int)Math.Round(rectangle.Width / 2.0) - (int)Math.Round(bounds.Width / 2.0);
            }
            else if ((al & 4) == 4) // right
            {
                x = (rectangle.X + rectangle.Width) - bounds.Width - 2;
            }
            var y = rectangle.Y + (int)Math.Round(bounds.Height / 2.0) + 2;
            if ((al & 16) == 16) // middle
            {
                y = rectangle.Y + (int)Math.Ceiling(rectangle.Height / 2.0) + (int)Math.Round(bounds.Height / 5.0);
            }
            else if ((al & 32) == 32) // bottom
            {
                y = (rectangle.Y + rectangle.Height) - 2;
            }

            graphicContext.SaveState();
            graphicContext.TranslateCTM(0, Bounds.Height);
            graphicContext.ScaleCTM(1, -1);
            graphicContext.SetFillColor(pattern.TextColor.ToCGColor());
            graphicContext.SetTextDrawingMode(CGTextDrawingMode.Fill);
            graphicContext.SelectFont("Helvetica", pattern.TextSize, CGTextEncoding.MacRoman);
            graphicContext.ShowTextAtPoint(x, Bounds.Height - y, pattern.Text);
            graphicContext.RestoreState();
        }
    }
}

