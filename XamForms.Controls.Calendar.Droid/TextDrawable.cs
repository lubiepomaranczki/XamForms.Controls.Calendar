using System;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;

namespace XamForms.Controls.Droid
{
    internal class TextDrawable : ColorDrawable
    {
        private readonly Paint paint;
        private readonly Context context;
        private readonly Pattern pattern;

        public  TextDrawable(Context context, Color color, Pattern pattern)
            : base(color)
        {
            this.context = context;
            this.pattern = pattern;

            paint = new Paint
            {
                AntiAlias = true
            };
            paint.SetStyle(Paint.Style.Fill);
            paint.TextAlign = Paint.Align.Left;            
        }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);
            paint.Color = pattern.TextColor.ToAndroid();
            paint.TextSize = Android.Util.TypedValue.ApplyDimension(Android.Util.ComplexUnitType.Sp, pattern.TextSize > 0 ? pattern.TextSize : 12, context.Resources.DisplayMetrics);

            var bounds = new Rect();
            paint.GetTextBounds(pattern.Text, 0, pattern.Text.Length, bounds);

            var textAlignment = (int)pattern.TextAlign;
            var x = Bounds.Left;

            if ((textAlignment & 2) == 2) // center
            {
                x = Bounds.CenterX() - Math.Abs(bounds.CenterX());
            }
            else if ((textAlignment & 4) == 4) // right
            {
                x = Bounds.Right - bounds.Width();
            }
            var y = Bounds.Top + Math.Abs(bounds.Top);
            if ((textAlignment & 16) == 16) // middle
            {
                y = Bounds.CenterY() + Math.Abs(bounds.CenterY());
            }
            else if ((textAlignment & 32) == 32) // bottom
            {
                y = Bounds.Bottom - Math.Abs(bounds.Bottom);
            }

            canvas.DrawText(pattern.Text.ToCharArray(), 0, pattern.Text.Length, x, y, paint);
        }
    }
}
