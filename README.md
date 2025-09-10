# load-on-demand-treeview-xamarin-android

This repository demonstrates how to implement load-on-demand functionality in the Xamarin.Forms SfTreeView control. It provides a sample implementation that dynamically loads child nodes as parent nodes are expanded, optimizing performance and resource usage for large hierarchical data sets.

## Sample

### Main Activity
```csharp
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
```

## Requirements to run the demo

To run the demo, refer to [System Requirements for Xamarin](https://help.syncfusion.com/xamarin/system-requirements)

## Troubleshooting
### Path too long exception
If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.
