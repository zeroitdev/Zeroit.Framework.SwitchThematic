// ***********************************************************************
// Assembly         : Zeroit.Framework.SwitchThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Meph.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using Zeroit.Framework.SwitchThematic.ThemeManagers;

namespace Zeroit.Framework.SwitchThematic.Controls
{

    /// <summary>
    /// Class ZeroitSwitchThematic.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public partial class ZeroitSwitchThematic
    {


        #region " Control Help - MouseState & Flicker Control"

        /// <summary>
        /// Mephes the on resize.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MephOnResize(System.EventArgs e)
        {
            Size = new Size(50, 24);

        }

        #endregion

        /// <summary>
        /// Mephes the toggle switch.
        /// </summary>
        private void MephToggleSwitch()
        {
            Size = new Size(50, 24);
            Invalidate();
        }

        /// <summary>
        /// Mephes the on paint.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void MephOnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle onoffRect = new Rectangle(0, 0, Width - 1, Height - 1);

            G.SmoothingMode = Smoothing;
            G.TextRenderingHint = TextRendering;

            G.Clear(Parent.BackColor);

            LinearGradientBrush bodyGrad = new LinearGradientBrush(onoffRect, Color.FromArgb(40, 40, 40), Color.FromArgb(45, 45, 45), 90);
            G.FillPath(bodyGrad, Draw.RoundRect(onoffRect, 4));
            G.DrawPath(new Pen(Color.FromArgb(15, 15, 15)), Draw.RoundRect(onoffRect, 4));
            G.DrawPath(new Pen(Color.FromArgb(50, 50, 50)), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), 4));

            if (Checked)
            {
                G.FillPath(new SolidBrush(Color.FromArgb(80, Color.Green)), Draw.RoundRect(new Rectangle(4, 2, 25, Height - 5), 4));
                G.FillPath(new SolidBrush(Color.FromArgb(35, 35, 35)), Draw.RoundRect(new Rectangle(2, 2, 25, Height - 5), 4));
                G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(20, 20, 20))), Draw.RoundRect(new Rectangle(2, 2, 25, Height - 5), 4));
                switch (State)
                {
                    case MouseState.None:
                        G.DrawString("On", new Font("Tahoma", 8, FontStyle.Regular), Brushes.Silver, new Point(16, Height - 12), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                    case MouseState.Over:
                        G.DrawString("On", new Font("Tahoma", 8, FontStyle.Regular), Brushes.White, new Point(16, Height - 12), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                    case MouseState.Down:
                        G.DrawString("On", new Font("Tahoma", 8, FontStyle.Regular), Brushes.Silver, new Point(16, Height - 12), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                }
            }
            else
            {
                G.FillPath(new SolidBrush(Color.FromArgb(60, Color.Red)), Draw.RoundRect(new Rectangle((Width / 2) - 7, 2, Width - 25, Height - 5), 4));
                G.FillPath(new SolidBrush(Color.FromArgb(35, 35, 35)), Draw.RoundRect(new Rectangle((Width / 2) - 5, 2, Width - 23, Height - 5), 4));
                G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(20, 20, 20))), Draw.RoundRect(new Rectangle((Width / 2) - 5, 2, Width - 23, Height - 5), 4));
                switch (State)
                {
                    case MouseState.None:
                        G.DrawString("Off", new Font("Tahoma", 8, FontStyle.Regular), Brushes.Silver, new Point(34, Height - 11), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                    case MouseState.Over:
                        G.DrawString("Off", new Font("Tahoma", 8, FontStyle.Regular), Brushes.White, new Point(34, Height - 11), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                    case MouseState.Down:
                        G.DrawString("Off", new Font("Tahoma", 8, FontStyle.Regular), Brushes.Silver, new Point(34, Height - 11), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                }
            }

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }


    }

}

