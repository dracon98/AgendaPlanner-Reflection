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
    class StudentsListActivity : ListActivity
    {
        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            List<StudentData> studentList = new List<StudentData>();
            StudentData studentData1 = new StudentData();
            studentData1.Title = "Title";
            studentData1.ResultDet = "+/-";
            studentData1.Time = "Time Detail";
            StudentData studentData2 = new StudentData();
            studentData2.Title = "Meeting with Client";
            studentData2.ResultDet = "-";
            studentData2.Time = "09.00 - 10.00";
            StudentData studentData3 = new StudentData();
            studentData3.Title = "Training with trainer";
            studentData3.ResultDet = "+";
            studentData3.Time = "12.00 - 13.00";
            studentList.Add(studentData1);
            studentList.Add(studentData2);
            studentList.Add(studentData3);
            ListAdapter = new ArrayAdapter<StudentData>(this, Android.Resource.Layout.SimpleListItem1, studentList);
            ListView.TextFilterEnabled = true;
            ListView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                Toast.MakeText(Application, ((TextView)args.View).Text, ToastLength.Short).Show();
                Intent i = new Intent(this,typeof(Details));
                i.PutExtra("text", ((TextView)args.View).Text);
                StartActivity(i);
            };
        }
    }
}