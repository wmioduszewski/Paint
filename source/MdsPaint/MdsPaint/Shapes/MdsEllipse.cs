﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MdsPaint.Shapes
{
    public class MdsEllipse : MdsShape
    {
        public override void Draw(Bitmap bmp, Pen pen, Point start, Point end, bool isCanonical)
        {
            using (var gfx = Graphics.FromImage(bmp))
            {
                var rect = GetRectangle(start, end,isCanonical);
                if (rect.Width > 0 && rect.Height > 0)
                    gfx.DrawEllipse(pen, rect);
            }
        }

        public override void Fill(Bitmap bmp, Brush brush, Point start, Point end, bool isCanonical)
        {
            using (var gfx = Graphics.FromImage(bmp))
            {
                var rect = GetRectangle(start, end, isCanonical);
                if (rect.Width > 0 && rect.Height > 0)
                    gfx.FillEllipse(brush, rect);
            }
        }
    }
}
