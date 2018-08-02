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

namespace AgendaPlanner_Reflection
{   [Activity]
    class PlannerList : ListActivity
    {
        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            List<PlannerData> plannerList = new List<PlannerData>();
            PlannerData plannerData1 = new PlannerData();
            plannerData1.Title = "Title";
            plannerData1.ResultDet = "+/-";
            plannerData1.Time = "Time Detail";
            PlannerData plannerData2 = new PlannerData();
            plannerData2.Title = "Meeting with Client";
            plannerData2.ResultDet = "-";
            plannerData2.Time = "09.00 - 10.00";
            PlannerData plannerData3 = new PlannerData();
            plannerData3.Title = "Training with trainer";
            plannerData3.ResultDet = "+";
            plannerData3.Time = "12.00 - 13.00";
            plannerList.Add(plannerData1);
            plannerList.Add(plannerData2);
            plannerList.Add(plannerData3);
            ListAdapter = new ArrayAdapter<PlannerData>(this, Android.Resource.Layout.SimpleListItem1, plannerList);
            ListView.TextFilterEnabled = true;
            ListView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                Toast.MakeText(Application, ((TextView)args.View).Text, ToastLength.Short).Show();
                Intent i = new Intent(this,typeof(AddDetailsActivity));
                i.PutExtra("text", ((TextView)args.View).Text);
                StartActivity(i);
            };
        }
    }
}