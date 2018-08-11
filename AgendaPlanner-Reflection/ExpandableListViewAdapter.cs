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
            return childPosition;
        }

        public override int GetChildrenCount(int groupPosition)
        {

            return 1;
        }

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
                    db.deleteTableData(listGroup[groupPosition]);
                    NotifyDataSetChanged();
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

        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            View row = convertView;
            ViewHolder holder;
            if (listGroup.Count > 0)
            {
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
                PlannerData item = listGroup[groupPosition];

                holder.Title.Text = item.Title;
                holder.Description.Text = item.Location;
                holder.Location.Text = item.Description;
                holder.Starts.Text = item.Starts;
                holder.Ends.Text = item.Ends;
                Log.Info("i", groupPosition.ToString() + " " + listGroup.Count());
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

        protected override Java.Lang.Object Clone()
        {
            return base.Clone();
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

        public override bool AreAllItemsEnabled()
        {
            return base.AreAllItemsEnabled();
        }

        public override int GetChildType(int groupPosition, int childPosition)
        {
            return base.GetChildType(groupPosition, childPosition);
        }

        public override long GetCombinedChildId(long groupId, long childId)
        {
            return base.GetCombinedChildId(groupId, childId);
        }

        public override long GetCombinedGroupId(long groupId)
        {
            return base.GetCombinedGroupId(groupId);
        }

        public override int GetGroupType(int groupPosition)
        {
            return base.GetGroupType(groupPosition);
        }

        public override void NotifyDataSetChanged()
        {
            base.NotifyDataSetChanged();
            listGroup.Clear();
            listGroup = db.selectTableData();
        }

        public override void NotifyDataSetInvalidated()
        {
            base.NotifyDataSetInvalidated();
        }

        public override void OnGroupCollapsed(int groupPosition)
        {
            base.OnGroupCollapsed(groupPosition);
        }

        public override void OnGroupExpanded(int groupPosition)
        {
            base.OnGroupExpanded(groupPosition);
        }

        public override void RegisterDataSetObserver(DataSetObserver observer)
        {
            base.RegisterDataSetObserver(observer);
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