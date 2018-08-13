using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Interop;
using Java.Lang;

namespace AgendaPlanner_Reflection
{
    public class ExpandableListViewAdapter : BaseExpandableListAdapter
    {
        private Context Context;
        private List<PlannerData> listGroup;
        private Dictionary<PlannerData, List<string>> child;
        Database db = new Database();
        public ExpandableListViewAdapter(Context context, List<PlannerData> plannerData)
        {
            Context = context;
            listGroup = plannerData;
        }
        public override bool IsEmpty => base.IsEmpty;
        public override int GroupCount
        {
            get
            {
                return listGroup.Count;
            }
        }

        public override bool HasStableIds
        {
            get
            {
                return false;
            }
        }

        public override Java.Lang.Object GetChild(int groupPostion, int childPosition)
        {
            return null;
        }

        public override long GetChildId(int groupPosition, int childPosition)
        {
            return listGroup[groupPosition].ID;
        }

        public override int GetChildrenCount(int groupPosition)
        {

            return 1;
        }
        // this is for the child that will following the group or the parent
        // the id of the child is the same as parent
        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            var row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(Context).Inflate(Resource.Layout.child, null, false);
            }
            Button btnEdit = row.FindViewById<Button>(Resource.Id.button1);
            Button btnDelete = row.FindViewById<Button>(Resource.Id.button2);

            btnDelete.Click +=
                delegate
                {
                    db.deleteQueryData(listGroup[groupPosition]);
                    listGroup = db.selectTableData();
                    
                    Log.Info("textPosition", groupPosition.ToString());
                    Intent i = new Intent(Context, typeof(PlannerList));
                    Context.StartActivity(i);
                };
            btnEdit.Click +=
                delegate
                {
                    Intent i = new Intent(Context, typeof(AddDetailsActivity));
                    i.PutExtra("editID",listGroup[groupPosition].ID);
                    Context.StartActivity(i);
                };
            return row;
        }

        public override Java.Lang.Object GetGroup(int groupPosition)
        {
            return null;
        }

        public override long GetGroupId(int groupPosition)
        {
            return listGroup[groupPosition].ID;
        }
        // this is for the parent 
        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            View row = convertView;
            ViewHolder holder;
            if (listGroup.Count > 0)
            {
                // if not created yet
                if (row == null)
                {
                    //creating a view
                    row = LayoutInflater.From(Context).Inflate(Resource.Layout.ListAdapter, parent, false);
                    holder = new ViewHolder()
                    {
                        //initialising
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

                    //finding the item on the template
                    PlannerData item = listGroup[groupPosition];

                    holder.Title.Text = item.Title;
                    holder.Description.Text = item.Location;
                    holder.Location.Text = item.Description;
                    holder.Starts.Text = item.Starts;
                    holder.Ends.Text = item.Ends;
                    Log.Info("i", groupPosition.ToString() + " " + listGroup.Count());
                }
                return row;
            }
            else
                return null;
        }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


        public override bool Equals(Java.Lang.Object obj)
        {
            return base.Equals(obj);
        }

        protected override void JavaFinalize()
        {
            base.JavaFinalize();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

      
        public override void UnregisterDataSetObserver(DataSetObserver observer)
        {
            base.UnregisterDataSetObserver(observer);
        }

        protected ExpandableListViewAdapter(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {

        }
    }
}