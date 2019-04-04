// ***********************************************************************
// Assembly         : Zeroit.Framework.SwitchThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="BaseContainer.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Text;
using System.Windows.Forms;
using Zeroit.Framework.SwitchThematic.ThemeManagers;

namespace Zeroit.Framework.SwitchThematic.Controls
{

    //[Designer(typeof(ZeroitSwitchThematicDesigner))]
    /// <summary>
    /// Class ZeroitSwitchThematic.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [ToolboxItem(true)]
    public partial class ZeroitSwitchThematic : Control
    {

        #region Private Fields

        /// <summary>
        /// The switch style
        /// </summary>
        private SwitchStyles switchStyle = SwitchStyles.Ambiance;
        /// <summary>
        /// The state
        /// </summary>
        private MouseState State = MouseState.None;

        #endregion

        #region Public Properties

        #region Smoothing Mode

        /// <summary>
        /// The smoothing
        /// </summary>
        private SmoothingMode smoothing = SmoothingMode.HighQuality;

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get { return smoothing; }
            set
            {
                smoothing = value;
                Invalidate();
            }
        }

        #endregion

        #region TextRenderingHint

        #region Add it to OnPaint / Graphics Rendering component

        //e.Graphics.TextRenderingHint = textrendering;
        #endregion

        /// <summary>
        /// The textrendering
        /// </summary>
        TextRenderingHint textrendering = TextRenderingHint.ClearTypeGridFit;

        /// <summary>
        /// Gets or sets the text rendering.
        /// </summary>
        /// <value>The text rendering.</value>
        public TextRenderingHint TextRendering
        {
            get { return textrendering; }
            set
            {
                textrendering = value;
                Invalidate();
            }
        }


        #endregion

        #region Interpolation Mode

        /// <summary>
        /// The interpolation mode
        /// </summary>
        private InterpolationMode interpolationMode = InterpolationMode.HighQualityBicubic;

        /// <summary>
        /// Gets or sets the interpolation mode.
        /// </summary>
        /// <value>The interpolation mode.</value>
        public InterpolationMode InterpolationMode
        {
            get { return interpolationMode; }
            set
            {
                interpolationMode = value;
                Invalidate();
            }
        }

        #endregion

        #region Pixel Offset
        /// <summary>
        /// The pixel offset mode
        /// </summary>
        private PixelOffsetMode pixelOffsetMode = PixelOffsetMode.None;

        /// <summary>
        /// Gets or sets the pixel offset mode.
        /// </summary>
        /// <value>The pixel offset mode.</value>
        public PixelOffsetMode PixelOffsetMode
        {
            get { return pixelOffsetMode; }
            set
            {
                pixelOffsetMode = value;
                Invalidate();
            }
        }



        #endregion

        /// <summary>
        /// Gets or sets the switch style.
        /// </summary>
        /// <value>The switch style.</value>
        /// <exception cref="ArgumentOutOfRangeException">value - null</exception>
        public SwitchStyles SwitchStyle
        {
            get { return switchStyle; }
            set {

                switch (value)
                {
                    case SwitchStyles.Ambiance:
                        AmbianceSwitch();
                        break;
                    case SwitchStyles.Aresio:
                        AresioSwitch();
                        break;
                    case SwitchStyles.ASC:
                        ASCSwitch();
                        break;
                    case SwitchStyles.Butter:
                        ButterscotchToggle();
                        break;
                    case SwitchStyles.Light:
                        LightSwitch();
                        break;
                    case SwitchStyles.Login:
                        LogInOnOffSwitch();
                        break;
                    case SwitchStyles.Meph:
                        MephToggleSwitch();
                        break;
                    case SwitchStyles.Metro:
                        MetroDiskToggle();
                        break;
                    case SwitchStyles.Mono:
                        MonoSwitch();
                        break;
                    case SwitchStyles.Redeem:
                        RedemptionToggle();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
                switchStyle = value;
                Invalidate();
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSwitchThematic"/> class.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public ZeroitSwitchThematic()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            DoubleBuffered = true;

            switch (SwitchStyle)
            {
                case SwitchStyles.Ambiance:
                    AmbianceSwitch();
                    break;
                case SwitchStyles.Aresio:
                    AresioSwitch();
                    break;
                case SwitchStyles.ASC:
                    ASCSwitch();
                    break;
                case SwitchStyles.Butter:
                    ButterscotchToggle();
                    break;
                case SwitchStyles.Light:
                    LightSwitch();
                    break;
                case SwitchStyles.Login:
                    LogInOnOffSwitch();
                    break;
                case SwitchStyles.Meph:
                    MephToggleSwitch();
                    break;
                case SwitchStyles.Metro:
                    MetroDiskToggle();
                    break;
                case SwitchStyles.Mono:
                    MonoSwitch();

                    break;
                case SwitchStyles.Redeem:
                    RedemptionToggle();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            switch (SwitchStyle)
            {
                case SwitchStyles.Ambiance:
                    break;
                case SwitchStyles.Aresio:
                    break;
                case SwitchStyles.ASC:
                    break;
                case SwitchStyles.Butter:
                    break;
                case SwitchStyles.Light:
                    break;
                case SwitchStyles.Login:
                    LoginOnMouseMove(e);
                    break;
                case SwitchStyles.Meph:
                    break;
                case SwitchStyles.Metro:
                    break;
                case SwitchStyles.Mono:
                    break;
                case SwitchStyles.Redeem:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            switch (SwitchStyle)
            {
                case SwitchStyles.Ambiance:
                    AmbianceOnPaint(e);
                    break;
                case SwitchStyles.Aresio:
                    AresioOnPaint(e);
                    break;
                case SwitchStyles.ASC:
                    ASCOnPaint(e);
                    break;
                case SwitchStyles.Butter:
                    ButterOnPaint(e);
                    break;
                case SwitchStyles.Light:
                    LightPaintHook(e);
                    break;
                case SwitchStyles.Login:
                    LoginOnPaint(e);
                    break;
                case SwitchStyles.Meph:
                    MephOnPaint(e);
                    break;
                case SwitchStyles.Metro:
                    MetroOnPaint(e);
                    break;
                case SwitchStyles.Mono:
                    MonoOnPaint(e);
                    break;
                case SwitchStyles.Redeem:
                    RedemptionOnPaint(e);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Click" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnClick(System.EventArgs e)
        {
            _checked = !_checked;
            if (checkedChanged != null)
            {
                checkedChanged(this, EventArgs.Empty);
            }
            base.OnClick(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            
            switch (SwitchStyle)
            {
                case SwitchStyles.Ambiance:
                    
                    break;
                case SwitchStyles.Aresio:
                    
                    break;
                case SwitchStyles.ASC:
                    ASCOnMouseDown(e);
                    break;
                case SwitchStyles.Butter:
                    break;
                case SwitchStyles.Light:
                    break;
                case SwitchStyles.Login:
                    LoginOnMouseDown(e);
                    break;
                case SwitchStyles.Meph:
                    break;
                case SwitchStyles.Metro:
                    break;
                case SwitchStyles.Mono:
                    break;
                case SwitchStyles.Redeem:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);

            State = MouseState.Over;
            
            Checked = !Checked;
            Focus();

            switch (SwitchStyle)
            {
                case SwitchStyles.Ambiance:
                    AmbianceOnMouseUp(e);
                    break;
                case SwitchStyles.Aresio:
                    break;
                case SwitchStyles.ASC:
                    break;
                case SwitchStyles.Butter:
                    break;
                case SwitchStyles.Light:
                    break;
                case SwitchStyles.Login:
                    break;
                case SwitchStyles.Meph:
                    break;
                case SwitchStyles.Metro:
                    break;
                case SwitchStyles.Mono:
                    break;
                case SwitchStyles.Redeem:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Invalidate();

        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            switch (SwitchStyle)
            {
                case SwitchStyles.Ambiance:
                    AmbianceOnResize(e);
                    break;
                case SwitchStyles.Aresio:
                    break;
                case SwitchStyles.ASC:
                    break;
                case SwitchStyles.Butter:
                    break;
                case SwitchStyles.Light:
                    break;
                case SwitchStyles.Login:
                    break;
                case SwitchStyles.Meph:
                    MephOnResize(e);
                    break;
                case SwitchStyles.Metro:
                    MetroOnResize(e);
                    break;
                case SwitchStyles.Mono:
                    MonoOnResize(e);
                    break;
                case SwitchStyles.Redeem:
                    RedemptionOnResize(e);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.TextChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        //public event CheckedChangedEventHandler CheckedChanged;
        //public delegate void CheckedChangedEventHandler(object sender);

        /// <summary>
        /// The checked
        /// </summary>
        private bool _checked;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitSwitchThematic"/> is checked.
        /// </summary>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        public bool Checked
        {
            get { return _checked; }
            set
            {
                _checked = value;
                Invalidate();
                this.CheckChanged(this,EventArgs.Empty);
            }
        }

        #region Event Creation

        /////Implement this in the Property you want to trigger the event///////////////////////////
        // 
        //  For Example this will be triggered by the Value Property
        //
        //  public int Value
        //   { 
        //      get { return _value;}
        //      set
        //         {
        //          
        //              _value = value;
        //
        //              this.CheckChanged(EventArgs.Empty);
        //              Invalidate();
        //          }
        //    }
        //
        ////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// The checked changed
        /// </summary>
        private CheckedChangedEventHandler checkedChanged;

        /// <summary>
        /// Delegate CheckedChangedEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void CheckedChangedEventHandler(object sender, EventArgs e);

        /// <summary>
        /// Triggered when the Value changes
        /// </summary>

        public event CheckedChangedEventHandler CheckedChanged
        {
            add
            {
                this.checkedChanged = this.checkedChanged + value;
            }
            remove
            {
                this.checkedChanged = this.checkedChanged - value;
            }
        }

        /// <summary>
        /// Checks the changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void CheckChanged(object sender,EventArgs e)
        {
            if (this.checkedChanged == null)
                return;
            this.checkedChanged((object)this, e);
        }

        #endregion

        #endregion

        #region Draw Borders
        //protected void DrawBorders(Pen p1, Pen p2, Rectangle rect)
        //{
        //    G.DrawRectangle(p1, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
        //    G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3);
        //}

        //protected void DrawBorders(Graphics G, Pen p1, int offset)
        //{
        //    DrawBorders(G, p1, 0, 0, Width, Height, offset);
        //}
        //protected void DrawBorders(Graphics G, Pen p1, Rectangle r, int offset)
        //{
        //    DrawBorders(G, p1, r.X, r.Y, r.Width, r.Height, offset);
        //}
        //protected void DrawBorders(Graphics G, Pen p1, int x, int y, int width, int height, int offset)
        //{
        //    DrawBorders(G, p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
        //}

        //protected void DrawBorders(Graphics G, Pen p1)
        //{
        //    DrawBorders(G, p1, 0, 0, Width, Height);
        //}
        //protected void DrawBorders(Graphics G, Pen p1, Rectangle r)
        //{
        //    DrawBorders(G, p1, r.X, r.Y, r.Width, r.Height);
        //}
        //protected void DrawBorders(Graphics G, Pen p1, int x, int y, int width, int height)
        //{
        //    G.DrawRectangle(p1, x, y, width - 1, height - 1);
        //}

        #endregion

        #region Private Methods

        /// <summary>
        /// To the pen.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>Pen.</returns>
        public Pen ToPen(Color color)
        {
            return new Pen(color);
        }

        /// <summary>
        /// To the brush.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>Brush.</returns>
        public Brush ToBrush(Color color)
        {
            return new SolidBrush(color);
        }

        #endregion

        #region Draw Borders
        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="p1">The p1.</param>
        /// <param name="p2">The p2.</param>
        /// <param name="rect">The rect.</param>
        protected void DrawBorders(Graphics G, Pen p1, Pen p2, Rectangle rect)
        {
            G.DrawRectangle(p1, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
            G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3);
        }

        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="p1">The p1.</param>
        /// <param name="offset">The offset.</param>
        protected void DrawBorders(Graphics G, Pen p1, int offset)
        {
            DrawBorders(G, p1, 0, 0, Width, Height, offset);
        }
        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="p1">The p1.</param>
        /// <param name="r">The r.</param>
        /// <param name="offset">The offset.</param>
        protected void DrawBorders(Graphics G, Pen p1, Rectangle r, int offset)
        {
            DrawBorders(G, p1, r.X, r.Y, r.Width, r.Height, offset);
        }
        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="p1">The p1.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="offset">The offset.</param>
        protected void DrawBorders(Graphics G, Pen p1, int x, int y, int width, int height, int offset)
        {
            DrawBorders(G, p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
        }

        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="p1">The p1.</param>
        protected void DrawBorders(Graphics G, Pen p1)
        {
            DrawBorders(G, p1, 0, 0, Width, Height);
        }
        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="p1">The p1.</param>
        /// <param name="r">The r.</param>
        protected void DrawBorders(Graphics G, Pen p1, Rectangle r)
        {
            DrawBorders(G, p1, r.X, r.Y, r.Width, r.Height);
        }
        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="p1">The p1.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        protected void DrawBorders(Graphics G, Pen p1, int x, int y, int width, int height)
        {
            G.DrawRectangle(p1, x, y, width - 1, height - 1);
        }

        #endregion
    }
}
