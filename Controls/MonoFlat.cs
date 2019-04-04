// ***********************************************************************
// Assembly         : Zeroit.Framework.SwitchThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="MonoFlat.cs" company="Zeroit Dev Technologies">
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
        /// Enum MonoMonoTypes
        /// </summary>
        public enum MonoMonoTypes
        {
            /// <summary>
            /// The check mark
            /// </summary>
            CheckMark,
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



        /// <summary>
        /// The toggle mono type
        /// </summary>
        private MonoMonoTypes ToggleMonoType;

        /// <summary>
        /// The meph width
        /// </summary>
        private int mephWidth;
        /// <summary>
        /// The meph height
        /// </summary>
        private int mephHeight;

        #endregion
        #region  Properties



        /// <summary>
        /// Gets or sets the type of the mono.
        /// </summary>
        /// <value>The type of the mono.</value>
        public MonoMonoTypes MonoType
        {
            get
            {
                return ToggleMonoType;
            }
            set
            {
                ToggleMonoType = value;
                Invalidate();
            }
        }

        #endregion
        #region  EventArgs

        /// <summary>
        /// Monoes the on resize.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MonoOnResize(EventArgs e)
        {
            this.Size = new Size(76, 33);
        }

        /// <summary>
        /// Monoes the switch.
        /// </summary>
        private void MonoSwitch()
        {
            this.Size = new Size(76, 33);
        }

        #endregion


        /// <summary>
        /// The meph bar
        /// </summary>
        Rectangle MephBar;

        /// <summary>
        /// Monoes the on paint.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void MonoOnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            System.Drawing.Graphics G = e.Graphics;

            G.SmoothingMode = Smoothing;
            G.Clear(Parent.BackColor);
            mephWidth = Width - 1;
            mephHeight = Height - 1;

            
            GraphicsPath GP = default(GraphicsPath);
            GraphicsPath GP2 = new GraphicsPath();
            Rectangle BaseRect = new Rectangle(0, 0, mephWidth, mephHeight);
            Rectangle ThumbRect = new Rectangle(mephWidth / 2, 0, 38, mephHeight);

            G.SmoothingMode = (System.Drawing.Drawing2D.SmoothingMode)2;
            G.PixelOffsetMode = (System.Drawing.Drawing2D.PixelOffsetMode)2;
            G.TextRenderingHint = (System.Drawing.Text.TextRenderingHint)5;
            G.Clear(BackColor);

            GP = Draw.RoundRect(BaseRect, 4);
            ThumbRect = new Rectangle(4, 4, 36, mephHeight - 8);
            GP2 = Draw.RoundRect(ThumbRect, 4);
            G.FillPath(new SolidBrush(Color.FromArgb(66, 76, 85)), GP);
            G.FillPath(new SolidBrush(Color.FromArgb(32, 41, 50)), GP2);

            if (Checked)
            {
                GP = Draw.RoundRect(BaseRect, 4);
                ThumbRect = new Rectangle((mephWidth / 2) - 2, 4, 36, mephHeight - 8);
                GP2 = Draw.RoundRect(ThumbRect, 4);
                G.FillPath(new SolidBrush(Color.FromArgb(181, 41, 42)), GP);
                G.FillPath(new SolidBrush(Color.FromArgb(32, 41, 50)), GP2);
            }

            // Draw string
            switch (ToggleMonoType)
            {
                case MonoMonoTypes.CheckMark:
                    if (Checked)
                    {
                        G.DrawString("ü", new Font("Wingdings", 18, FontStyle.Regular), Brushes.WhiteSmoke, MephBar.X + 18, MephBar.Y + 19, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("r", new Font("Marlett", 14, FontStyle.Regular), Brushes.DimGray, MephBar.X + 59, MephBar.Y + 18, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
                case MonoMonoTypes.OnOff:
                    if (Checked)
                    {
                        G.DrawString("ON", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.WhiteSmoke, MephBar.X + 18, MephBar.Y + 16, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("OFF", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.DimGray, MephBar.X + 57, MephBar.Y + 16, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
                case MonoMonoTypes.YesNo:
                    if (Checked)
                    {
                        G.DrawString("YES", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.WhiteSmoke, MephBar.X + 19, MephBar.Y + 16, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("NO", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.DimGray, MephBar.X + 56, MephBar.Y + 16, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
                case MonoMonoTypes.IO:
                    if (Checked)
                    {
                        G.DrawString("I", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.WhiteSmoke, MephBar.X + 18, MephBar.Y + 16, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("O", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.DimGray, MephBar.X + 57, MephBar.Y + 16, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
            }
        }

    }
}
