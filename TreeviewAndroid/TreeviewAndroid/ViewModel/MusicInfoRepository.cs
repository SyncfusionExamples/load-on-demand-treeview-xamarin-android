using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    [Preserve(AllMembers = true)]

    public class MusicInfoRepository
    {
        #region Properties

        public ObservableCollection<MusicInfo> Menu { get; set; }

        #endregion

        #region Constructor
        public MusicInfoRepository()
        {
            this.Menu = this.GetMenuItems();
        }
        #endregion

        #region methods

        private ObservableCollection<MusicInfo> GetMenuItems()
        {
            ObservableCollection<MusicInfo> menuItems = new ObservableCollection<MusicInfo>();
            menuItems.Add(new MusicInfo() { ItemName = "Discover Music", HasChild = true, ID = 1 });
            menuItems.Add(new MusicInfo() { ItemName = "Sales and Events", HasChild = true, ID = 2 });
            menuItems.Add(new MusicInfo() { ItemName = "Categories", HasChild = true, ID = 3 });
            menuItems.Add(new MusicInfo() { ItemName = "MP3 Albums", HasChild = true, ID = 4 });
            menuItems.Add(new MusicInfo() { ItemName = "Fiction Book Lists", HasChild = true, ID = 5 });
            return menuItems;
        }

        public IEnumerable<MusicInfo> GetSubMenu(int id)
        {
            ObservableCollection<MusicInfo> menuItems = new ObservableCollection<MusicInfo>();
            if (id == 1)
            {
                menuItems.Add(new MusicInfo() { ItemName = "Hot Singles", HasChild = false, ID = 11 });
                menuItems.Add(new MusicInfo() { ItemName = "Rising Artists", HasChild = false, ID = 12 });
                menuItems.Add(new MusicInfo() { ItemName = "Live Music", HasChild = false, ID = 13 });
                menuItems.Add(new MusicInfo() { ItemName = "More in Music", HasChild = true, ID = 14 });
            }
            else if (id == 2)
            {
                menuItems.Add(new MusicInfo() { ItemName = "100 Albums - $10 Each", HasChild = false, ID = 21 });
                menuItems.Add(new MusicInfo() { ItemName = "Hip-Hop and R&B Sale", HasChild = false, ID = 22 });
                menuItems.Add(new MusicInfo() { ItemName = "CD Deals", HasChild = false, ID = 23 });
            }
            else if (id == 3)
            {
                menuItems.Add(new MusicInfo() { ItemName = "Songs", HasChild = false, ID = 31 });
                menuItems.Add(new MusicInfo() { ItemName = "Bestselling Albums", HasChild = false, ID = 32 });
                menuItems.Add(new MusicInfo() { ItemName = "New Releases", HasChild = false, ID = 33 });
                menuItems.Add(new MusicInfo() { ItemName = "MP3 Albums", HasChild = false, ID = 34 });

            }
            else if (id == 4)
            {
                menuItems.Add(new MusicInfo() { ItemName = "Rock Music", HasChild = false, ID = 41 });
                menuItems.Add(new MusicInfo() { ItemName = "Gospel", HasChild = false, ID = 42 });
                menuItems.Add(new MusicInfo() { ItemName = "Latin Music", HasChild = false, ID = 43 });
                menuItems.Add(new MusicInfo() { ItemName = "Jazz", HasChild = false, ID = 44 });
            }
            else if (id == 5)
            {
                menuItems.Add(new MusicInfo() { ItemName = "Hunger Games", HasChild = true, ID = 4 });
                menuItems.Add(new MusicInfo() { ItemName = "Pride and Prejudice", HasChild = false, ID = 52 });
                menuItems.Add(new MusicInfo() { ItemName = "Harry Potter", HasChild = false, ID = 53 });
                menuItems.Add(new MusicInfo() { ItemName = "Game Of Thrones", HasChild = false, ID = 54 });
            }
            else if (id == 14)
            {
                menuItems.Add(new MusicInfo() { ItemName = "Music Trade-In", HasChild = true, ID = 5 });
                menuItems.Add(new MusicInfo() { ItemName = "Redeem a Gift card", HasChild = false, ID = 142 });
                menuItems.Add(new MusicInfo() { ItemName = "Band T-Shirts", HasChild = false, ID = 143 });
            }
            return menuItems;
        }
        #endregion
    }
}