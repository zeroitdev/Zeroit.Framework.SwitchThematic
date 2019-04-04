// ***********************************************************************
// Assembly         : Zeroit.Framework.SwitchThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Login.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.SwitchThematic.Controls
{

    /// <summary>
    /// Class ZeroitSwitchThematic.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public partial class ZeroitSwitchThematic
    {


        #region "Declarations"

        /// <summary>
        /// Occurs when [toggle changed].
        /// </summary>
        public event ToggleChangedEventHandler ToggleChanged;
        /// <summary>
        /// Delegate ToggleChangedEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        public delegate void ToggleChangedEventHandler(object sender);
        /// <summary>
        /// The login mouse x loc
        /// </summary>
        private int LoginMouseXLoc;
        /// <summary>
        /// The login toggle location
        /// </summary>
        private int loginToggleLocation = 0;
        /// <summary>
        /// The login base color
        /// </summary>
        private Color loginBaseColor = Color.FromArgb(42, 42, 42);
        /// <summary>
        /// The login border color
        /// </summary>
        private Color loginBorderColor = Color.FromArgb(35, 35, 35);
        /// <summary>
        /// The login text color
        /// </summary>
        private Color loginTextColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// The login non toggled text color
        /// </summary>
        private Color loginNonToggledTextColor = Color.FromArgb(125, 125, 125);

        /// <summary>
        /// The login toggled color
        /// </summary>
        private Color loginToggledColor = Color.FromArgb(23, 119, 151);
        #endregion

        #region "Properties & Events"

        /// <summary>
        /// Gets or sets the base colour.
        /// </summary>
        /// <value>The base colour.</value>
        [Category("Colours")]
        public Color BaseColour
        {
            get { return loginBaseColor; }
            set
            {
                loginBaseColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border colour.
        /// </summary>
        /// <value>The border colour.</value>
        [Category("Colours")]
        public Color BorderColour
        {
            get { return loginBorderColor; }
            set
            {
                loginBorderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text colour.
        /// </summary>
        /// <value>The text colour.</value>
        [Category("Colours")]
        public Color TextColour
        {
            get { return loginTextColor; }
            set
            {
                loginTextColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the non toggled text colourder colour.
        /// </summary>
        /// <value>The non toggled text colourder colour.</value>
        [Category("Colours")]
        public Color NonToggledTextColourderColour
        {
            get { return loginNonToggledTextColor; }
            set
            {
                loginNonToggledTextColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the toggled colour.
        /// </summary>
        /// <value>The toggled colour.</value>
        [Category("Colours")]
        public Color ToggledColour
        {
            get { return loginToggledColor; }
            set
            {
                loginToggledColor = value;
                Invalidate();
            }
        }

        ////public enum Toggles
        ////{
        ////    Toggled,
        ////    NotToggled
        ////}

        //public event ToggledChangedEventHandler ToggledChanged;
        //public delegate void ToggledChangedEventHandler();

        /// <summary>
        /// Logins the on mouse move.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void LoginOnMouseMove(MouseEventArgs e)
        {
            LoginMouseXLoc = e.Location.X;
            Invalidate();
            if (e.X < Width - 40 && e.X > 40)
                Cursor = Cursors.IBeam;
            else
                Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Logins the on mouse down.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void LoginOnMouseDown(MouseEventArgs e)
        {
            if (LoginMouseXLoc > Width - 39)
            {
                //_Toggled = Toggles.Toggled;
                if(Checked)
                    ToggledValue();
            }
            else if (LoginMouseXLoc < 39)
            {
                //_Toggled = Toggles.NotToggled;
                if(!Checked)
                    ToggledValue();
            }
            Invalidate();
        }

        //public Toggles Toggled
        //{
        //    get { return _Toggled; }
        //    set
        //    {
        //        _Toggled = value;
        //        Invalidate();
        //    }
        //}

        /// <summary>
        /// Toggleds the value.
        /// </summary>
        private void ToggledValue()
        {
            if (Convert.ToBoolean(Checked))
            {
                if (loginToggleLocation < 100)
                {
                    loginToggleLocation += 10;
                }
            }
            else
            {
                if (loginToggleLocation > 0)
                {
                    loginToggleLocation -= 10;
                }
            }
            Invalidate();
        }

        #endregion

        #region "Draw Control"

        /// <summary>
        /// Logs the in on off switch.
        /// </summary>
        private void LogInOnOffSwitch()
        {
            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            //BackColor = Color.FromArgb(54, 54, 54);
        }


        /// <summary>
        /// Logins the on paint.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void LoginOnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;

            G.Clear(Parent.BackColor);
            G.SmoothingMode = Smoothing;
            G.PixelOffsetMode = PixelOffsetMode;
            G.TextRenderingHint = TextRendering;
            G.InterpolationMode = InterpolationMode.HighQualityBicubic;
            G.FillRectangle(new SolidBrush(loginBaseColor), new Rectangle(0, 0, 39, Height));
            G.FillRectangle(new SolidBrush(loginBaseColor), new Rectangle(Width - 40, 0, Width, Height));
            G.FillRectangle(new SolidBrush(loginBaseColor), new Rectangle(38, 9, Width - 40, 5));
            Point[] P = {
            new Point(0, 0),
            new Point(39, 0),
            new Point(39, 9),
            new Point(Width - 40, 9),
            new Point(Width - 40, 0),
            new Point(Width - 2, 0),
            new Point(Width - 2, Height - 1),
            new Point(Width - 40, Height - 1),
            new Point(Width - 40, 14),
            new Point(39, 14),
            new Point(39, Height - 1),
            new Point(0, Height - 1),
            new Point()
        };
            G.DrawLines(new Pen(loginBorderColor, 2), P);
            if (Checked)
            {
                G.FillRectangle(new SolidBrush(loginToggledColor), new Rectangle(Convert.ToInt32(Width / 2), 10, Convert.ToInt32(Width / 2 - 38), 3));
                G.FillRectangle(new SolidBrush(loginToggledColor), new Rectangle(Width - 39, 2, 36, Height - 5));
                G.DrawString("ON", new Font("Microsoft Sans Serif", 7, FontStyle.Bold), new SolidBrush(loginTextColor), new Rectangle(2, -1, Convert.ToInt32(Width - 20 + 20 / 3), Height), new StringFormat
                {
                    Alignment = StringAlignment.Far,
                    LineAlignment = StringAlignment.Center
                });
                G.DrawString("OFF", new Font("Microsoft Sans Serif", 7, FontStyle.Bold), new SolidBrush(loginNonToggledTextColor), new Rectangle(Convert.ToInt32(20 - 20 / 3 - 6), -1, Convert.ToInt32(Width - 20 + 20 / 3), Height), new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                });
            }
            else if (!Checked)
            {
                G.DrawString("OFF", new Font("Microsoft Sans Serif", 7, FontStyle.Bold), new SolidBrush(loginTextColor), new Rectangle(Convert.ToInt32(20 - 20 / 3 - 6), -1, Convert.ToInt32(Width - 20 + 20 / 3), Height), new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                });
                G.DrawString("ON", new Font("Microsoft Sans Serif", 7, FontStyle.Bold), new SolidBrush(loginNonToggledTextColor), new Rectangle(2, -1, Convert.ToInt32(Width - 20 + 20 / 3), Height), new StringFormat
                {
                    Alignment = StringAlignment.Far,
                    LineAlignment = StringAlignment.Center
                });
            }
            G.DrawLine(new Pen(loginBorderColor, 2), new Point(Convert.ToInt32(Width / 2), 0), new Point(Convert.ToInt32(Width / 2), Height));

        }

        #endregion

    }

}

