// ***********************************************************************
// Assembly         : Zeroit.Framework.SwitchThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Aresio.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
        /// The toggle location
        /// </summary>
        private int ToggleLocation = 0;
        /// <summary>
        /// The with events field toggle animation
        /// </summary>
        private Timer withEventsField_ToggleAnimation = new Timer { Interval = 1 };
        /// <summary>
        /// Gets or sets the toggle animation.
        /// </summary>
        /// <value>The toggle animation.</value>
        private Timer ToggleAnimation
        {
            get { return withEventsField_ToggleAnimation; }
            set
            {
                if (withEventsField_ToggleAnimation != null)
                {
                    withEventsField_ToggleAnimation.Tick -= AresioAnimation;
                }
                withEventsField_ToggleAnimation = value;
                if (withEventsField_ToggleAnimation != null)
                {
                    withEventsField_ToggleAnimation.Tick += AresioAnimation;


                }
            }

        }


        ///// <summary>
        ///// Occurs when [toggled changed].
        ///// </summary>
        //public event ToggledChangedEventHandler ToggledChanged;
        ///// <summary>
        ///// Delegate ToggledChangedEventHandler
        ///// </summary>
        //public delegate void ToggledChangedEventHandler();
        ///// <summary>
        ///// The toggled
        ///// </summary>

        //private bool _toggled;
        ///// <summary>
        ///// Gets or sets a value indicating whether this <see cref="AresioSwitch"/> is toggled.
        ///// </summary>
        ///// <value><c>true</c> if toggled; otherwise, <c>false</c>.</value>
        //public bool Toggled
        //{
        //    get { return _toggled; }
        //    set
        //    {
        //        _toggled = value;
        //        Invalidate();

        //        if (ToggledChanged != null)
        //        {
        //            ToggledChanged();
        //        }
        //    }
        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="AresioSwitch" /> class.
        /// </summary>
        private void AresioSwitch()
        {
            //aresioBar = new Rectangle(0, 10, Width - 1, Height - 21);
            ToggleAnimation.Start();
        }

        /// <summary>
        /// Creates a handle for the control.
        /// </summary>
        private void AresioCreateHandle()
        {
            ToggleAnimation.Start();
        }

        /// <summary>
        /// Animations the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void AresioAnimation(object sender, EventArgs e)
        {
            if (Checked)
            {
                if (ToggleLocation < 100)
                {
                    ToggleLocation += 10;
                }
            }
            else
            {
                if (ToggleLocation > 0)
                {
                    ToggleLocation -= 10;
                }
            }

            Invalidate();
        }

        /// <summary>
        /// The bar
        /// </summary>
        Size Track = new Size(20, 20);
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        private void AresioOnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            Rectangle aresioBar = new Rectangle(10, 10, Width - 21, Height - 21);
            G.Clear(Parent.BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            DesignFunctions.PillStyle styles = new DesignFunctions.PillStyle();
            styles.Left = true;
            styles.Right = true;
            //Background
            LinearGradientBrush BackLinear = new LinearGradientBrush(new Point(0, Convert.ToInt32((Height / 2) - (Track.Height / 2))), new Point(0, Convert.ToInt32((Height / 2) + (Track.Height / 2))), Color.FromArgb(50, Color.Black), Color.Transparent);
            //G.FillPath(BackLinear, RoundRect(0, CInt((Height / 2) - 4), Width - 1, 8, 3))

            G.FillPath(BackLinear, (GraphicsPath)DesignFunctions.Pill(0, Convert.ToInt32(Height / 2 - Track.Height / 2), Width - 1, Track.Height - 2, new DesignFunctions.PillStyle
            {
                Left = true,
                Right = true
            }));

            G.FillPath(BackLinear, (GraphicsPath)DesignFunctions.Pill(0, Convert.ToInt32(Height / 2 - Track.Height / 2), Width - 1, Track.Height - 2, new DesignFunctions.PillStyle
            {
                Left = true,
                Right = true
            }));
            G.DrawPath(DesignFunctions.ToPen(50, Color.Black), (GraphicsPath)DesignFunctions.Pill(0, Convert.ToInt32(Height / 2 - Track.Height / 2), Width - 1, Track.Height - 2, new DesignFunctions.PillStyle
            {
                Left = true,
                Right = true
            }));

            BackLinear.Dispose();

            //Fill
            if (ToggleLocation > 0)
            {
                G.FillPath(new LinearGradientBrush(new Point(0, Convert.ToInt32((Height / 2) - Track.Height / 2)), new Point(1, Convert.ToInt32((Height / 2) + Track.Height / 2)), Color.FromArgb(250, 200, 70), Color.FromArgb(250, 160, 40)), (GraphicsPath)DesignFunctions.Pill(1, Convert.ToInt32((Height / 2) - Track.Height / 2), Convert.ToInt32(aresioBar.Width * (ToggleLocation / 100)) + Convert.ToInt32(Track.Width / 2), Track.Height - 3, new DesignFunctions.PillStyle
                {
                    Left = true,
                    Right = true
                }));
                G.DrawPath(DesignFunctions.ToPen(100, Color.White), (GraphicsPath)DesignFunctions.Pill(1, Convert.ToInt32((Height / 2) - Track.Height / 2 + 1), Convert.ToInt32(aresioBar.Width * (ToggleLocation / 100)) + Convert.ToInt32(Track.Width / 2), Track.Height - 5, new DesignFunctions.PillStyle
                {
                    Left = true,
                    Right = true
                }));
            }

            if (Checked)
            {
                G.DrawString("ON", new Font("Arial", 6, FontStyle.Bold), DesignFunctions.ToBrush(150, Color.Black), new Rectangle(0, -1, Width - Track.Width + Track.Width / 3, Height), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }
            else
            {
                G.DrawString("OFF", new Font("Arial", 6, FontStyle.Bold), DesignFunctions.ToBrush(150, Color.Black), new Rectangle(Track.Width - Track.Width / 3, -1, Width - Track.Width + Track.Width / 3, Height), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }

            //Button
            G.FillEllipse(Brushes.White, aresioBar.X + Convert.ToInt32(aresioBar.Width * (ToggleLocation / 100)) - Convert.ToInt32(Track.Width / 2), aresioBar.Y + Convert.ToInt32((aresioBar.Height / 2)) - Convert.ToInt32(Track.Height / 2), Track.Width, Track.Height);
            G.DrawEllipse(DesignFunctions.ToPen(50, Color.Black), aresioBar.X + Convert.ToInt32(aresioBar.Width * (ToggleLocation / 100) - Convert.ToInt32(Track.Width / 2)), aresioBar.Y + Convert.ToInt32((aresioBar.Height / 2)) - Convert.ToInt32(Track.Height / 2), Track.Width, Track.Height);
        }

        
    }

}
