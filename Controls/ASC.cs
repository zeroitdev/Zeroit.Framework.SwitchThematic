// ***********************************************************************
// Assembly         : Zeroit.Framework.SwitchThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ASC.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
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


        /// <summary>
        /// Ascs the switch.
        /// </summary>
        private void ASCSwitch()
        {
            Size = new Size(40, 17);
        }


        /// <summary>
        /// Ascs the on paint.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void ASCOnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            G.SmoothingMode = Smoothing;
            G.Clear(Parent.BackColor);

            int slope = (Height - 1) / 2;
            Height = 17;

            Rectangle mainRect = new Rectangle(0, 0, Width - 1, Height - 1);
            GraphicsPath mainPath = Draw.RoundRect(mainRect, 6);

            if (_checked)
            {
                LinearGradientBrush bgBrush = new LinearGradientBrush(mainRect, Color.FromArgb(10, 30, 50), Color.FromArgb(5, 80, 140), 90f);
                G.FillPath(bgBrush, mainPath);
                Rectangle switchRect = new Rectangle(Width - 14, 3, 10, 10);
                LinearGradientBrush switchBrush = new LinearGradientBrush(switchRect, Color.FromArgb(100, 220, 250), Color.FromArgb(15, 150, 220), 90f);
                G.FillEllipse(switchBrush, switchRect);
                int textY = ((Height - 1) / 2) - Convert.ToInt32((G.MeasureString("On", new Font("Arial", 8)).Height / 2) + 1);
                G.DrawString("On", new Font("Arial", 8), new SolidBrush(Color.FromArgb(180, 180, 180)), new Point(5, textY));
                G.DrawPath(new Pen(Color.FromArgb(5, 80, 140)), mainPath);
            }
            else
            {
                LinearGradientBrush bgBrush = new LinearGradientBrush(mainRect, Color.FromArgb(40, 40, 40), Color.FromArgb(80, 80, 80), 90f);
                G.FillPath(bgBrush, mainPath);
                Rectangle switchRect = new Rectangle(3, 3, 10, 10);
                LinearGradientBrush switchBrush = new LinearGradientBrush(switchRect, Color.FromArgb(150, 150, 150), Color.FromArgb(120, 120, 120), 90f);
                G.FillEllipse(switchBrush, switchRect);
                int textY = ((Height - 1) / 2) - Convert.ToInt32((G.MeasureString("Off", new Font("Arial", 8)).Height / 2) + 1);
                G.DrawString("Off", new Font("Arial", 8), new SolidBrush(Color.FromArgb(180, 180, 180)), new Point(15, textY));
                G.DrawPath(new Pen(Color.FromArgb(80, 80, 80)), mainPath);
            }

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
        }

        /// <summary>
        /// Ascs the on mouse down.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void ASCOnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {

            if (_checked)
            {
                _checked = false;
            }
            else
            {
                _checked = true;
            }

            if (checkedChanged != null)
            {
                checkedChanged(this, EventArgs.Empty);
            }
            Invalidate();

        }



    }
}
