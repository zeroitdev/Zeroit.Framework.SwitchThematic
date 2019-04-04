// ***********************************************************************
// Assembly         : Zeroit.Framework.SwitchThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Light.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.SwitchThematic.Controls
{

    /// <summary>
    /// Class ZeroitSwitchThematic.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public partial class ZeroitSwitchThematic
    {


        #region " Properties "

        #endregion

        /// <summary>
        /// Lights the switch.
        /// </summary>
        private void LightSwitch()
        {
            Size = new Size(90, 16);
            //MinimumSize = new Size(16, 16);
            //MaximumSize = new Size(600, 16);
            
        }

        /// <summary>
        /// Draws the gradient.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="angle">The angle.</param>
        private void DrawGradient(Graphics G,Color c1, Color c2, int x, int y, int width, int height, int angle)
        {
            LinearGradientBrush linBrush = new LinearGradientBrush(new Rectangle(x, y, width, height), c1, c2, angle);

            G.FillRectangle(linBrush, new Rectangle(x, y, width, height));
        }
        /// <summary>
        /// Lights the paint hook.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void LightPaintHook(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            G.SmoothingMode = Smoothing;

            G.Clear(this.Parent.BackColor);

            HatchBrush hb = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(20, Color.White), Color.Transparent);
            DrawGradient(G, Color.FromArgb(196, 196, 196), Color.FromArgb(230, 230, 230), 0, 0, 30, 15, 270);
            DrawGradient(G, Color.FromArgb(35, Color.Black), Color.Transparent, 0, 0, 15, 15, 180);
            DrawGradient(G,Color.FromArgb(35, Color.Black), Color.Transparent, 15, 0, 16, 15, 0);
            G.FillRectangle(hb, 1, 1, Width, Height);
            switch (Checked)
            {
                case true:
                    DrawGradient(G, Color.FromArgb(62, 62, 62), Color.FromArgb(4, 128, 7), 0, 0, 13, 15, 90);
                    DrawGradient(G, Color.FromArgb(4, 128, 7), Color.FromArgb(17, 196, 21), 3, 3, 9, 9, 90);
                    DrawGradient(G, Color.FromArgb(17, 196, 21), Color.FromArgb(4, 128, 7), 4, 4, 7, 7, 90);
                    G.DrawRectangle(Pens.LightGray, new Rectangle(0, 0, 13, 14));
                    break;
                case false:
                    DrawGradient(G, Color.FromArgb(160, 0, 0), Color.FromArgb(109, 16, 16), 15, 0, 13, 15, 90);
                    DrawGradient(G, Color.FromArgb(109, 16, 16), Color.FromArgb(212, 20, 20), 18, 3, 9, 9, 90);
                    DrawGradient(G, Color.FromArgb(212, 20, 20), Color.FromArgb(109, 16, 16), 19, 4, 7, 7, 90);
                    G.DrawRectangle(Pens.LightGray, new Rectangle(15, 0, 13, 14));
                    break;
            }

            DrawBorders(G,Pens.Gray, Pens.LightGray, new Rectangle(0, 0, 30, 15));
            //DrawText(HorizontalAlignment.Left, this.ForeColor, 32, 0);

            

            e.Graphics.DrawImage((Bitmap) B.Clone(), 0, 0);

            e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), 32, 0, new StringFormat()
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near
            });
        }

        

    }

}

