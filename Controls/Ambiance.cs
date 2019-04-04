// ***********************************************************************
// Assembly         : Zeroit.Framework.SwitchThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Ambiance.cs" company="Zeroit Dev Technologies">
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

        #region  Enums

        /// <summary>
        /// Enum AmbianceType
        /// </summary>
        public enum AmbianceType
        {
            /// <summary>
            /// The on off
            /// </summary>
            OnOff,
            /// <summary>
            /// The yes no
            /// </summary>
            YesNo,
            /// <summary>
            /// The io
            /// </summary>
            IO
        }

        #endregion

        #region  Variables

        //public delegate void AmbianceAmbianceToggledChangedEventHandler();
        //private AmbianceAmbianceToggledChangedEventHandler AmbianceToggledChangedEvent;

        //public event AmbianceAmbianceToggledChangedEventHandler AmbianceToggledChanged
        //{
        //    add
        //    {
        //        AmbianceToggledChangedEvent = (AmbianceAmbianceToggledChangedEventHandler)System.Delegate.Combine(AmbianceToggledChangedEvent, value);
        //    }
        //    remove
        //    {
        //        AmbianceToggledChangedEvent = (AmbianceAmbianceToggledChangedEventHandler)System.Delegate.Remove(AmbianceToggledChangedEvent, value);
        //    }
        //}

        //private bool _AmbianceToggled;
        /// <summary>
        /// The toggle type
        /// </summary>
        private AmbianceType toggleType;
        /// <summary>
        /// The bar
        /// </summary>
        private Rectangle Bar;
        /// <summary>
        /// The c handle
        /// </summary>
        private Size cHandle = new Size(15, 20);

        #endregion

        #region Constructor

        /// <summary>
        /// Ambiances the switch.
        /// </summary>
        private void AmbianceSwitch()
        {
            Size = new Size(79, 27);
        }

        #endregion

        #region  Properties

        //public bool AmbianceToggled
        //{
        //    get
        //    {
        //        return _AmbianceToggled;
        //    }
        //    set
        //    {
        //        _AmbianceToggled = value;
        //        Invalidate();
        //        this.CheckChanged(EventArgs.Empty);
        //    }
        //}

        /// <summary>
        /// Gets or sets the type of the ambiance toggle.
        /// </summary>
        /// <value>The type of the ambiance toggle.</value>
        public AmbianceType AmbianceToggleType
        {
            get
            {
                return toggleType;
            }
            set
            {
                toggleType = value;
                Invalidate();
            }
        }

        #endregion

        #region  EventArgs

        /// <summary>
        /// Ambiances the on resize.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AmbianceOnResize(EventArgs e)
        {
            Width = 79;
            Height = 27;
        }

        /// <summary>
        /// Ambiances the on mouse up.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void AmbianceOnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            Checked = !Checked;
            Focus();
        }

        #endregion

        /// <summary>
        /// Ambiances the on paint.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void AmbianceOnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            G.SmoothingMode = Smoothing;
            G.Clear(Parent.BackColor);

            int SwitchXLoc = 3;
            Rectangle ControlRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
            GraphicsPath ControlPath = Draw.RoundRect(ControlRectangle, 4);

            LinearGradientBrush BackgroundLGB = default(LinearGradientBrush);
            if (Checked)
            {
                SwitchXLoc = 37;
                BackgroundLGB = new LinearGradientBrush(ControlRectangle, Color.FromArgb(231, 108, 58), Color.FromArgb(236, 113, 63), 90.0F);
            }
            else
            {
                SwitchXLoc = 0;
                BackgroundLGB = new LinearGradientBrush(ControlRectangle, Color.FromArgb(208, 208, 208), Color.FromArgb(226, 226, 226), 90.0F);
            }

            // Fill inside background gradient
            G.FillPath(BackgroundLGB, ControlPath);

            // Draw string
            switch (AmbianceToggleType)
            {
                case AmbianceType.OnOff:
                    if (Checked)
                    {
                        G.DrawString("ON", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.WhiteSmoke, Bar.X + 18, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("OFF", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.DimGray, Bar.X + 59, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
                case AmbianceType.YesNo:
                    if (Checked)
                    {
                        G.DrawString("YES", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.WhiteSmoke, Bar.X + 18, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("NO", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.DimGray, Bar.X + 59, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
                case AmbianceType.IO:
                    if (Checked)
                    {
                        G.DrawString("I", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.WhiteSmoke, Bar.X + 18, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("O", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.DimGray, Bar.X + 59, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
            }

            Rectangle SwitchRectangle = new Rectangle(SwitchXLoc, 0, Width - 38, Height);
            GraphicsPath SwitchPath = Draw.RoundRect(SwitchRectangle, 4);
            LinearGradientBrush SwitchButtonLGB = new LinearGradientBrush(SwitchRectangle, Color.FromArgb(253, 253, 253), Color.FromArgb(240, 238, 237), LinearGradientMode.Vertical);

            // Fill switch background gradient
            G.FillPath(SwitchButtonLGB, SwitchPath);

            // Draw borders
            if (Checked == true)
            {
                G.DrawPath(new Pen(Color.FromArgb(185, 89, 55)), SwitchPath);
                G.DrawPath(new Pen(Color.FromArgb(185, 89, 55)), ControlPath);
            }
            else
            {
                G.DrawPath(new Pen(Color.FromArgb(181, 181, 181)), SwitchPath);
                G.DrawPath(new Pen(Color.FromArgb(181, 181, 181)), ControlPath);
            }

            e.Graphics.DrawImage((Bitmap) B.Clone(), 0, 0);
        }


    }
}
