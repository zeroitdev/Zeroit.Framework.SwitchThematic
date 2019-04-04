// ***********************************************************************
// Assembly         : Zeroit.Framework.SwitchThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="MetroDisk.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
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


        #region " Variables"

        /// <summary>
        /// The w
        /// </summary>
        private int W;
        /// <summary>
        /// The h
        /// </summary>
        private int H;
        /// <summary>
        /// The o
        /// </summary>
        private _Options O;
        #endregion

        #region " Properties"

        /// <summary>
        /// Enum _Options
        /// </summary>
        [Flags()]
        public enum _Options
        {
            /// <summary>
            /// The style1
            /// </summary>
            Style1,
            /// <summary>
            /// The style2
            /// </summary>
            Style2,
            /// <summary>
            /// The style3
            /// </summary>
            Style3,
            /// <summary>
            /// The style4
            /// </summary>
            Style4,
            //-- TODO: New Style
            /// <summary>
            /// The style5
            /// </summary>
            Style5
            //-- TODO: New Style
        }

        #region " Options"

        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        /// <value>The options.</value>
        [Category("Options")]
        public _Options Options
        {
            get { return O; }
            set { O = value; }
        }



        #endregion



        /// <summary>
        /// Metroes the on resize.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MetroOnResize(EventArgs e)
        {
            Size = new Size(76, 33);
        }

        #region " Mouse States"



        #endregion

        #endregion

        #region " Colors"

        /// <summary>
        /// The base color
        /// </summary>
        private Color BaseColor = Color.FromArgb(35, 168, 109);
        /// <summary>
        /// The base color red
        /// </summary>
        private Color BaseColorRed = Color.FromArgb(220, 85, 96);
        /// <summary>
        /// The bg color
        /// </summary>
        private Color BGColor = Color.FromArgb(84, 85, 86);
        /// <summary>
        /// The toggle color
        /// </summary>
        private Color ToggleColor = Color.FromArgb(45, 47, 49);

        /// <summary>
        /// The text color
        /// </summary>
        private Color TextColor = Color.FromArgb(243, 243, 243);
        #endregion

        /// <summary>
        /// Metroes the disk toggle.
        /// </summary>
        private void MetroDiskToggle()
        {
            
            Size = new Size(44, Height + 1);
            Cursor = Cursors.Hand;
            Size = new Size(76, 33);
        }

        /// <summary>
        /// Metroes the on paint.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void MetroOnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            W = Width - 1;
            H = Height - 1;

            dynamic GP = default(GraphicsPath);
            GraphicsPath GP2 = new GraphicsPath();
            Rectangle Base = new Rectangle(0, 0, W, H);
            Rectangle Toggle = new Rectangle(Convert.ToInt32(W / 2), 0, 38, H);

            G.SmoothingMode = Smoothing;
            G.PixelOffsetMode = PixelOffsetMode;
            G.TextRenderingHint = TextRendering;
            G.Clear(BackColor);

            switch (O)
            {
                case _Options.Style1:
                    //-- Style 1
                    //-- Base
                    GP = Draw.RoundRec(Base, 6);
                    GP2 = Draw.RoundRec(Toggle, 6);
                    G.FillPath(new SolidBrush(BGColor), GP);
                    G.FillPath(new SolidBrush(ToggleColor), GP2);

                    //-- Text
                    G.DrawString("OFF", Font, new SolidBrush(BGColor), new Rectangle(19, 1, W, H), Draw.CenterSF);

                    if (Checked)
                    {
                        //-- Base
                        GP = Draw.RoundRec(Base, 6);
                        GP2 = Draw.RoundRec(new Rectangle(Convert.ToInt32(W / 2), 0, 38, H), 6);
                        G.FillPath(new SolidBrush(ToggleColor), GP);
                        G.FillPath(new SolidBrush(BaseColor), GP2);

                        //-- Text
                        G.DrawString("ON", Font, new SolidBrush(BaseColor), new Rectangle(8, 7, W, H), Draw.NearSF);
                    }
                    break;
                case _Options.Style2:
                    //-- Style 2
                    //-- Base
                    GP = Draw.RoundRec(Base, 6);
                    Toggle = new Rectangle(4, 4, 36, H - 8);
                    GP2 = Draw.RoundRec(Toggle, 4);
                    G.FillPath(new SolidBrush(BaseColorRed), GP);
                    G.FillPath(new SolidBrush(ToggleColor), GP2);

                    //-- Lines
                    G.DrawLine(new Pen(BGColor), 18, 20, 18, 12);
                    G.DrawLine(new Pen(BGColor), 22, 20, 22, 12);
                    G.DrawLine(new Pen(BGColor), 26, 20, 26, 12);

                    //-- Text
                    G.DrawString("r", new Font("Marlett", 8), new SolidBrush(TextColor), new Rectangle(19, 2, Width, Height), Draw.CenterSF);

                    if (Checked)
                    {
                        GP = Draw.RoundRec(Base, 6);
                        Toggle = new Rectangle(Convert.ToInt32(W / 2) - 2, 4, 36, H - 8);
                        GP2 = Draw.RoundRec(Toggle, 4);
                        G.FillPath(new SolidBrush(BaseColor), GP);
                        G.FillPath(new SolidBrush(ToggleColor), GP2);

                        //-- Lines
                        G.DrawLine(new Pen(BGColor), Convert.ToInt32(W / 2) + 12, 20, Convert.ToInt32(W / 2) + 12, 12);
                        G.DrawLine(new Pen(BGColor), Convert.ToInt32(W / 2) + 16, 20, Convert.ToInt32(W / 2) + 16, 12);
                        G.DrawLine(new Pen(BGColor), Convert.ToInt32(W / 2) + 20, 20, Convert.ToInt32(W / 2) + 20, 12);

                        //-- Text
                        G.DrawString("ü", new Font("Wingdings", 14), new SolidBrush(TextColor), new Rectangle(8, 7, Width, Height), Draw.NearSF);
                    }
                    break;
                case _Options.Style3:
                    //-- Style 3
                    //-- Base
                    GP = Draw.RoundRec(Base, 16);
                    Toggle = new Rectangle(W - 28, 4, 22, H - 8);
                    GP2.AddEllipse(Toggle);
                    G.FillPath(new SolidBrush(ToggleColor), GP);
                    G.FillPath(new SolidBrush(BaseColorRed), GP2);

                    //-- Text
                    G.DrawString("OFF", Font, new SolidBrush(BaseColorRed), new Rectangle(-12, 2, W, H), Draw.CenterSF);

                    if (Checked)
                    {
                        //-- Base
                        GP = Draw.RoundRec(Base, 16);
                        Toggle = new Rectangle(6, 4, 22, H - 8);
                        GP2.Reset();
                        GP2.AddEllipse(Toggle);
                        G.FillPath(new SolidBrush(ToggleColor), GP);
                        G.FillPath(new SolidBrush(BaseColor), GP2);

                        //-- Text
                        G.DrawString("ON", Font, new SolidBrush(BaseColor), new Rectangle(12, 2, W, H), Draw.CenterSF);
                    }
                    break;
                case _Options.Style4:
                    //-- TODO: New Styles
                    if (Checked)
                    {
                        //--
                    }
                    break;
                case _Options.Style5:
                    //-- TODO: New Styles
                    if (Checked)
                    {
                        //--
                    }
                    break;
            }


            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            
        }

    }

}

