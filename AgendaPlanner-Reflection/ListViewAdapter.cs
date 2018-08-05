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
using Java.Lang;

namespace AgendaPlanner_Reflection
{
    public class ViewHolder : Java.Lang.Object
    {
        public TextView txtTitle { get; set; }
        public TextView txtDescription { get; set; }
        public TextView txtLocation { get; set; }
        public TextView txtStart { get; set; }
        public TextView txtEnds { get; set; }
    }
    public class ListViewAdapter:BaseAdapter
    {
        private Activity activity;
        private List<PlannerData> plannerList;

        public ListViewAdapter()
        {
        }

        public ListViewAdapter(Activity activity, List<PlannerData> plannerList)
        {
            this.activity = activity;
            this.plannerList = plannerList;
        }

        protected ListViewAdapter(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override int Count
        {
            get
            {
                return plannerList.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return plannerList[1].Id; 
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.ListAdapter,parent,false);
            var txtTitle = view.FindViewById<TextView>(Resource.Id.textview3);
            var txtDescription = view.FindViewById<TextView>(Resource.Id.textview4);
            var txtLocation = view.FindViewById<TextView>(Resource.Id.textview5);
            var txtStart = view.FindViewById<TextView>(Resource.Id.textview1);
            var txtEnds = view.FindViewById<TextView>(Resource.Id.textview2);

            txtTitle.Text = plannerList[position].Title;
            txtLocation.Text = plannerList[position].Location;
            txtDescription.Text = plannerList[position].Description;
            txtStart.Text = plannerList[position].Starts;
            txtEnds.Text = plannerList[position].Ends;
            return view;
        }
    }
}