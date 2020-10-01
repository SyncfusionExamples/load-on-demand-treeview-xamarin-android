using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Syncfusion.Android.TreeView;
using Syncfusion.TreeView.Engine;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;


namespace TreeviewAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            SfTreeView treeView = FindViewById<SfTreeView>(Resource.Id.sfTreeView1);
            MusicInfoRepository viewModel = new MusicInfoRepository();
            treeView.LoadOnDemand += TreeView_LoadOnDemandEvent;
            treeView.ItemsSource = viewModel.Menu;
            treeView.Adapter = new NodeImageAdapter();

        }
        private async void TreeView_LoadOnDemandEvent(object sender, LoadOnDemandEventArgs e)
        {
            if (e.Action == Action.RequestStatus)
            {
                e.HasChildNodes = (e.Node.Content as MusicInfo).HasChild;
            }

            else if (e.Action == Action.PopulateNodes)
            {
                var viewModel = new MusicInfoRepository();
                var node = e.Node;
                if (node.ChildNodes.Count > 0)
                {
                    node.IsExpanded = true;
                    return;
                }

                node.ShowExpanderAnimation = true;
                await Task.Delay(2000);
                MusicInfo musicInfo = node.Content as MusicInfo;
                var items = viewModel.GetSubMenu(musicInfo.ID);
                node.PopulateChildNodes(items);
                if (items.Count() > 0)
                    node.IsExpanded = true;
                node.ShowExpanderAnimation = false;
            }
        }
    }
}

