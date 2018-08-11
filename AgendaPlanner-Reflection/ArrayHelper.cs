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
{
    public class ArrayHelper
    {
        public static void getListView(ListView listview)
        {
            ListViewAdapter adapter = new ListViewAdapter();
            if (adapter == null)
            {
                return;
            }
            int totalheight=0;
            for (int i=0; i < adapter.Count; i++)
            {
                View item = adapter.GetView(i, null, listview);
                item.Measure(0, 0);
                totalheight += item.MeasuredHeight;
            }
            ViewGroup.LayoutParams param = listview.LayoutParameters;
            param.Height = totalheight + (listview.DividerHeight * (listview.Count - 1));
            listview.LayoutParameters = param;

        }
    }
}