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
    public class PlannerData
    {
        private string title;
        private string desc;
        private string loc;
        private string starts;
        private string ends;
        private int id;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Location
        {
            get { return loc; }
            set { loc = value; }
        }
        public string Description
        {
            get { return desc;}
            set { desc = value; }
        }
        public string Starts
        {
            get { return starts; }
            set { starts = value; }
        }
        public string Ends
        {
            get { return ends; }
            set { ends = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public override string ToString()
        {
            return " "+ Starts +" | "+ Title + " " + Location + "\n "+ Ends +" | "+ Description;
        }
    }
}