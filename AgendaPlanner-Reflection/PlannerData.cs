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
    class PlannerData
    {
        private string title;
        private string time;
        private string resultDet;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
        public string ResultDet
        {
            get { return resultDet;}
            set { resultDet = value; }
        }
        public override string ToString()
        {
            return ResultDet + " | " + Title + "\nTime: " + Time;
        }
    }
}