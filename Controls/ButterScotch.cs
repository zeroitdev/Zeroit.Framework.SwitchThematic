// ***********************************************************************
// Assembly         : Zeroit.Framework.SwitchThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ButterScotch.cs" company="Zeroit Dev Technologies">
//    This program is for creating a Switch control.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

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
        /// Butterscotches the toggle.
        /// </summary>
        private void ButterscotchToggle()
        {
            Size = new Size(80, 25);
        }

        /// <summary>
        /// Butters the on paint.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void ButterOnPaint(PaintEventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            Rectangle outerrect = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle maininnerrect = new Rectangle(7, 7, Width - 15, Height - 15);
            LinearGradientBrush buttonrect = new LinearGradientBrush(outerrect, Color.FromArgb(100, 90, 80), Color.FromArgb(48, 43, 39), 90);
            base.OnPaint(e);
            g.Clear(BackColor);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.FillPath(new SolidBrush(Color.FromArgb(40, 37, 33)), Draw.RoundRect(outerrect, 5));
            g.DrawPath(new Pen(Color.FromArgb(0, 0, 0)), Draw.RoundRect(outerrect, 5));
            g.FillPath(new SolidBrush(Color.FromArgb(26, 25, 21)), Draw.RoundRect(maininnerrect, 3));
            g.DrawPath(new Pen(Color.FromArgb(0, 0, 0)), Draw.RoundRect(maininnerrect, 3));
            if (Checked)
            {
                g.FillPath(buttonrect, Draw.RoundRect(new Rectangle(3, 3, Convert.ToInt32((Width / 2) - 3), Height - 7), 7));
                g.DrawString("ON", new Font("Segoe UI", 10, FontStyle.Bold), new SolidBrush(Color.FromArgb(246, 180, 12)), new Rectangle(2, 2, Convert.ToInt32((Width / 2) - 1), Height - 5), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }
            else
            {
                g.FillPath(buttonrect, Draw.RoundRect(new Rectangle(Convert.ToInt32((Width / 2) - 3), 3, Convert.ToInt32((Width / 2) - 3), Height - 7), 7));
                g.DrawString("OFF", new Font("Segoe UI", 10, FontStyle.Bold), new SolidBrush(Color.FromArgb(246, 180, 12)), new Rectangle(Convert.ToInt32((Width / 2) - 2), 2, Convert.ToInt32((Width / 2) - 1), Height - 5), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }
            e.Graphics.DrawImage(b, new Point(0, 0));
            
        }

    }


}

