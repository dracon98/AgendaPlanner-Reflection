using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
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
            
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_ListView);
            listData = FindViewById<ExpandableListView>(Resource.Id.listView1);
            source = db.selectTableData();
            if (source != null)
            {
                ListAdapter = new ExpandableListViewAdapter(this, source);
                Log.Info("txt", source.Count().ToString());
                listData.SetAdapter(ListAdapter);
                listData.TextFilterEnabled = true;
                listData.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
                {
                    
                };
            }
        }
    }
}