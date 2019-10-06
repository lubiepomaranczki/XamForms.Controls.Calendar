using System.Collections.Generic;

namespace XamForms.Controls
{
    public class BackgroundPattern
    {
        protected int columns;

        public BackgroundPattern(int columns)
        {
            this.columns = columns;
        }

        public IList<Pattern> Pattern;

        //What is this?
        public float GetTop(int t)
        {
            float r = 0;
            for (int i = t - columns; i > -1; i -= columns)
            {
                r += Pattern[i].HightPercent;
            }
            return r;
        }

        //What is this?
        public float GetLeft(int l)
        {
            float r = 0;
            for (int i = l - 1; i > -1 && (i + 1) % columns != 0; i--)
            {
                r += Pattern[i].WidthPercent;
            }
            return r;
        }
    }
}
