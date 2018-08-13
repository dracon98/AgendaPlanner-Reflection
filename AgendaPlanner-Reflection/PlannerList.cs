using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace AgendaPlanner_Reflection
{   [Activity]
    class PlannerList:AppCompatActivity
    {
        ExpandableListView listData;
        Database db = new Database();
        ExpandableListViewAdapter ListAdapter;
         List<PlannerData> source = new List<PlannerData>();
        
        protected override void OnCreate(Bundle bundle)
        {
            //initialisation
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_ListView);
            listData = FindViewById<ExpandableListView>(Resource.Id.listView1);
            ViewGroup header = (ViewGroup)LayoutInflater.Inflate(Resource.Layout.header, listData, false);
            source = db.selectTableData();
            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
            //if the list for listview is not empty 
            if (source != null)
            {
                //sorting the list
                source.OrderBy(o => o.Starts).ToList();
                ListAdapter = new ExpandableListViewAdapter(this, source);// creating adapter
                listData.SetAdapter(ListAdapter);//set adapter
                Log.Info("txt", source.Count().ToString());
                listData.TextFilterEnabled = true;
            }
        }
        //menu or for the top of the screen
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            //creating a menu from the Menu folder
            MenuInflater.Inflate(Resource.Menu.list_menu, menu);
            return true;
        }
        // event for button inside of the menu on the top of the screen
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_calendar)
            {
                //move to another activity from this
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            }
            return base.OnOptionsItemSelected(item);
        }
        //event triggered when fab is clicked
        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            Intent i = new Intent(this, typeof(AddDetailsActivity));
            StartActivity(i);
        }
    }
}