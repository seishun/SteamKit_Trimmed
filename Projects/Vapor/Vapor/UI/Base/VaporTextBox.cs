﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Vapor
{
    class VaporTextBox : TextBox
    {
        public VaporTextBox()
        {
            this.BackColor = Color.FromArgb( 58, 58, 58 );
            this.ForeColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;

        }

        protected override void OnPaint( PaintEventArgs e )
        {
            base.OnPaint( e );
            e.Graphics.DrawRectangle( Pens.White, new Rectangle( 0, 0, this.Width - 1, this.Height - 1 ) );
        }
    }
}
