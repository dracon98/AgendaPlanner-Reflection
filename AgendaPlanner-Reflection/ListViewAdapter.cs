using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace AgendaPlanner_Reflection
{
    public class ViewHolder : Java.Lang.Object {
        private TextView title;
        private TextView desc;
        private TextView loc;
        private TextView starts;
        private TextView ends;
        private TextView id;

        public TextView Title
        {
            get { return title; }
            set { title = value; }
        }
        public TextView Location
        {
            get { return loc; }
            set { loc = value; }
        }
        public TextView Description
        {
            get { return desc; }
            set { desc = value; }
        }
        public TextView Starts
        {
            get { return starts; }
            set { starts = value; }
        }
        public TextView Ends
        {
            get { return ends; }
            set { ends = value; }
        }
        public TextView Id
        {
            get { return id; }
            set { id = value; }
        }
    }
    public class ListViewAdapter : BaseAdapter<PlannerData>
    {
        private Context Context;
        private List<PlannerData> plannerList;


        public ListViewAdapter()
        {
        }

        public ListViewAdapter(Context context, List<PlannerData> plannerlist)
        {
            Context = context;
            plannerList = plannerlist;
        }
        public override int Count
        {
            get
            {
                return plannerList.Count;
            }
        }

        public override PlannerData this[int position]
        {
            get { return plannerList[position]; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            ViewHolder holder;
            if (row == null)
            {
                row = LayoutInflater.From(Context).Inflate(Resource.Layout.ListAdapter, parent, false);
                holder = new ViewHolder()
                {
                    Location = row.FindViewById<TextView>(Resource.Id.textview5),
                    Title = row.FindViewById<TextView>(Resource.Id.textview3),
                    Description = row.FindViewById<TextView>(Resource.Id.textview4),
                    Starts = row.FindViewById<TextView>(Resource.Id.textview1),
                    Ends = row.FindViewById<TextView>(Resource.Id.textview2)
                };
                row.Tag = holder;
            }
            else
            {
                holder = (ViewHolder)row.Tag;
            }
            PlannerData item = this[position];

            holder.Title.Text = item.Title;
            holder.Description.Text = item.Location;
            holder.Location.Text = item.Description;
            holder.Starts.Text = item.Starts;
            holder.Ends.Text = item.Ends;
            Log.Info("i", position.ToString()+" "+plannerList.Count());
            return row;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
    }

}