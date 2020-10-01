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
using Syncfusion.Android.TreeView;

namespace TreeviewAndroid
{
   public class NodeImageAdapter : TreeViewAdapter
    {
        public NodeImageAdapter()
        {
        }

        protected override View CreateContentView(TreeViewItemInfoBase itemInfo)
        {
            var gridView = new NodeImageView(TreeView.Context);
            return gridView;
        }

        protected override void UpdateContentView(View view, TreeViewItemInfoBase itemInfo)
        {
            var grid = view as NodeImageView;
            var treeViewNode = itemInfo.Node;
            if (grid != null)
            {
                var label1 = grid.GetChildAt(1) as ContentLabel;

                if (label1 != null)
                {
                    label1.Text = (treeViewNode.Content as MusicInfo).ItemName.ToString();
                }
            }
        }
    }
}
