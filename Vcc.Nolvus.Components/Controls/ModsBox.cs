﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Vcc.Nolvus.Core.Events;

namespace Vcc.Nolvus.Components.Controls
{
    public class ModsBox : ListBox
    {        
        public ModsBox()
        {
            this.SetStyle(
               ControlStyles.OptimizedDoubleBuffer |
               ControlStyles.ResizeRedraw |
               ControlStyles.UserPaint,
               true);

            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 35;
            BackColor = Color.FromArgb(54, 54, 54);
            SelectionMode = SelectionMode.None;                                                            
        }        

        private int GetGlobalProgress(int Value)
        {
            return ((Width - 100) / 100) * Value;            
        }

        protected override void OnPaint(PaintEventArgs e)
        {           
            Region iRegion = new Region(e.ClipRectangle);
            e.Graphics.FillRegion(new SolidBrush(this.BackColor), iRegion);
            if (this.Items.Count > 0)
            {
                for (int i = 0; i < this.Items.Count; ++i)
                {
                    System.Drawing.Rectangle irect = this.GetItemRectangle(i);
                    if (e.ClipRectangle.IntersectsWith(irect))
                    {
                        if ((this.SelectionMode == SelectionMode.One && this.SelectedIndex == i)
                        || (this.SelectionMode == SelectionMode.MultiSimple && this.SelectedIndices.Contains(i))
                        || (this.SelectionMode == SelectionMode.MultiExtended && this.SelectedIndices.Contains(i)))
                        {
                            OnDrawItem(new DrawItemEventArgs(e.Graphics, this.Font,
                                irect, i,
                                DrawItemState.Selected, this.ForeColor,
                                this.BackColor));
                        }
                        else
                        {
                            OnDrawItem(new DrawItemEventArgs(e.Graphics, this.Font,
                                irect, i,
                                DrawItemState.Default, this.ForeColor,
                                this.BackColor));
                        }
                        iRegion.Complement(irect);
                    }
                }
            }
            base.OnPaint(e);
        }

        //private Image DisplayGradient(Image InputImage)
        //{            
        //    Bitmap adjImage = new Bitmap(InputImage.Width, InputImage.Height);

        //    Graphics g = Graphics.FromImage(adjImage);

        //    LinearGradientBrush linearGradientBrush = new LinearGradientBrush(
        //        new Rectangle(0, 0, adjImage.Width, adjImage.Height),
        //        Color.White,
        //        Color.Transparent,
        //        0f);

        //    Rectangle rect = new Rectangle(0, 0, adjImage.Width, adjImage.Height);
        //    g.FillRectangle(linearGradientBrush, rect);

        //    int x;
        //    int y;
        //    for (x = 0; x < adjImage.Width; ++x)
        //    {
        //        for (y = 0; y < adjImage.Height; ++y)
        //        {
        //            Color inputPixelColor = (InputImage as Bitmap).GetPixel(x, y);
        //            Color adjPixelColor = adjImage.GetPixel(x, y);
        //            Color newColor = Color.FromArgb(adjPixelColor.A, inputPixelColor.R, inputPixelColor.G, inputPixelColor.B);
        //            adjImage.SetPixel(x, y, newColor);
        //        }
        //    }

        //    return adjImage;
        //}

        protected override void OnDrawItem(DrawItemEventArgs e)
        {                        
            FontFamily FamilyTitle = new FontFamily("Segoe UI Light");
            Font IFont = new Font(FamilyTitle, (float)9, FontStyle.Bold);
            Font InfoFont = new Font(FontFamily.GenericSansSerif, (float)7, FontStyle.Regular);            

            if (e.Index != -1 && !DesignMode)
            {
                var Top = 0;

                if (e.Index > 0)
                {
                    Top = (ItemHeight * e.Index);
                }
                
                var Progress = Items[e.Index] as ModProgress;                

                if (!Progress.HasError)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Orange)), 105, 5 + Top, GetGlobalProgress(Progress.GlobalDone), 30);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Red)), 105, 5 + Top, GetGlobalProgress(100), 30);
                }                

                e.Graphics.DrawRectangle(Pens.Orange, 3, 5 + Top, Progress.PercentDone, 1);
                e.Graphics.DrawString(Progress.Name, IFont, Brushes.White, 105, 3 + Top);

                if (Progress.Image != null) e.Graphics.DrawImage(Progress.Image, 3, 5 + Top);

                e.Graphics.DrawString(Progress.Mbs, InfoFont, Brushes.White, 105, 10 + Top, new StringFormat(StringFormatFlags.DirectionRightToLeft));

                if (!Progress.HasError)
                {
                    e.Graphics.DrawString(string.Format("{0}%", Progress.PercentDone), InfoFont, Brushes.White, 105, 22 + Top, new StringFormat(StringFormatFlags.DirectionRightToLeft));
                }                

                if (!Progress.HasError)
                {
                    e.Graphics.DrawString(Progress.Action, InfoFont, Brushes.White, 3, 21 + Top);
                }
                else
                {
                    e.Graphics.DrawString("Error", InfoFont, Brushes.Red, 3, 21 + Top);
                }
                


                Brush Brush = Brushes.Orange;

                if (Progress.HasError) Brush = Brushes.Red;
                
                e.Graphics.DrawString(Progress.Status, e.Font, Brush, 105, 20 + Top);                                
            }       
        }
    }
}
