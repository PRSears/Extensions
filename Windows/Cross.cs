using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.ComponentModel;
//using System.Windows;

namespace Extender.Windows
{
    /// <remarks>
    /// A structure used to describe the points of a cross.
    /// </remarks>
    public struct Cross
    {
        /// <summary>
        /// X co-ordinate of the starting point of the horizontal component of the cross.
        /// </summary>
        public double h_X1 { get; set; }
        /// <summary>
        /// Y co-ordinate of the starting point of the horizontal component of the cross.
        /// </summary>
        public double h_Y1 { get; set; }
        /// <summary>
        /// X co-ordinate of the end point of the horizontal component of the cross.
        /// </summary>
        public double h_X2 { get; set; }
        /// <summary>
        /// Y co-ordinate of the end point of the horizontal component of the cross.
        /// </summary>
        public double h_Y2 { get; set; }

        /// <summary>
        /// X co-ordinate of the starting point of the vertical component of the cross.
        /// </summary>
        public double v_X1 { get; set; }
        /// <summary>
        /// Y co-ordinate of the starting point of the vertical component of the cross.
        /// </summary>
        public double v_Y1 { get; set; }
        /// <summary>
        /// X co-ordinate of the end point of the vertical component of the cross.
        /// </summary>
        public double v_X2 { get; set; }
        /// <summary>
        /// Y co-ordinate of the end point of the vertical component of the cross.
        /// </summary>
        public double v_Y2 { get; set; }

        public System.Windows.Point Horizontal_Start
        {
            get
            {
                return new System.Windows.Point(h_X1, h_Y1);
            }
            set
            {
                this.h_X1 = value.X;
                this.h_Y1 = value.Y;
            }
        }

        public System.Windows.Point Horizontal_End
        {
            get
            {
                return new System.Windows.Point(h_X2, h_Y2);
            }
            set
            {
                this.h_X2 = value.X;
                this.h_Y2 = value.Y;
            }
        }
        public System.Windows.Point Vertical_Start
        {
            get
            {
                return new System.Windows.Point(v_X1, v_Y1);
            }
            set
            {
                this.v_X1 = value.X;
                this.v_Y1 = value.Y;
            }
        }

        public System.Windows.Point Vertical_End
        {
            get
            {
                return new System.Windows.Point(v_X2, v_Y2);
            }
            set
            {
                this.v_X2 = value.X;
                this.v_Y2 = value.Y;
            }
        }

        /// <summary>
        /// [Readonly] Gets the size of the cross.
        /// </summary>
        public System.Windows.Size Size
        {
            get
            {
                return new System.Windows.Size
                (
                    Math.Abs(h_X2 - h_X1),
                    Math.Abs(v_Y2 - v_Y1)
                );
            }
        }
    }
}
