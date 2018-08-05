using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace AgendaPlanner_Reflection
{   [Activity]
    class PlannerList : Activity
    {
        ListView listData;
        Database db = new Database();
        private List<PlannerData> source = new List<PlannerData>();

        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_ListView);
            listData = FindViewById<ListView>(Resource.Id.listView1);
            source = db.selectTableData();
            var ListAdapter = new ListViewAdapter(this, source);
            listData.Adapter = ListAdapter;
            listData.TextFilterEnabled = true;
            listData.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                Toast.MakeText(Application, ((TextView)args.View).Text, ToastLength.Short).Show();
                
            };
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            return true;
        }

    }
}