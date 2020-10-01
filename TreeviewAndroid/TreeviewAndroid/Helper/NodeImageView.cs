using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TreeviewAndroid
{
    public class NodeImageView : LinearLayout
    {
        #region Fields

        private ContentLabel label1, label2;


        #endregion

        #region Constructor

        public NodeImageView(Context context) : base(context)
        {
            this.Orientation = Orientation.Horizontal;
            label1 = new ContentLabel(context);

            label1.Gravity = GravityFlags.CenterVertical;
            label2 = new ContentLabel(context);

            label2.Gravity = GravityFlags.CenterVertical;
            this.AddView(label1);
            this.AddView(label2);
        }

        #endregion

        #region Methods

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            var density = Resources.DisplayMetrics.Density;
            var measuredwidth = (int)(40 * density);
            var measuredheight = (int)(45 * density);
            var labelwidth = Math.Abs(widthMeasureSpec - measuredwidth);
            this.label1.SetMinimumHeight(measuredheight);
            this.label1.SetMinimumWidth(measuredwidth);
            this.label1.Measure(labelwidth, measuredheight);
            this.label2.SetMinimumHeight(measuredheight);
            this.label2.SetMinimumWidth(labelwidth);
            this.label2.Measure(labelwidth, measuredheight);

            //this.label2.Layout(measuredwidth, 0, r - measuredwidth, measuredheight);
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            var density = Resources.DisplayMetrics.Density;
            var measuredwidth = (int)(40 * density);
            var measuredheight = (int)(45 * density);

            this.label1.Layout(0, 0, measuredwidth, measuredheight);
            this.label2.Layout(measuredwidth, 0, r - measuredwidth, measuredheight);

        }

        #endregion
    }

    internal class ContentLabel : TextView
    {
        public ContentLabel(Context context) : base(context)
        {
            //      this.LayoutParameters = new ViewGroup.LayoutParams((this.Parent as View).Width, (this.Parent as View).Height);

        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            this.SetMeasuredDimension(widthMeasureSpec, heightMeasureSpec);
        }

        protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
        {
            base.OnLayout(changed, left, top, right, bottom);
        }
    }
}
    

    