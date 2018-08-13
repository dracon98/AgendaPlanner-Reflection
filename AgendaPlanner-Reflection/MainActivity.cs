using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Content;
using Java.Util;
using Android.Util;

namespace AgendaPlanner_Reflection
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
	public class MainActivity : AppCompatActivity
	{
        Database db;
        CalendarView cv;
        string Time;
        protected override void OnCreate(Bundle savedInstanceState)
		{
            //initialising
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.activity_main);
			Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            cv = FindViewById<CalendarView>(Resource.Id.calendarView1);
            
            SetSupportActionBar(toolbar);
            db = new Database();
            db.createDatabase();
			FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);

            //click oon fab
            fab.Click += FabOnClick;
            //anychange event to calendar view
            cv.DateChange += (s, e) =>
            {
                int day = e.DayOfMonth;
                int month = e.Month;
                int year = e.Year;
                Time = day + "/" + month + "/" + year;
                Intent i = new Intent(this, typeof(AddDetailsActivity));
                i.PutExtra("stringDate", Time);
                StartActivity(i);
            };
        }
        //option menu
		public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }
        //if the button on the option menu is click
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_list)
            {
                Intent i = new Intent(this, typeof(PlannerList));
                StartActivity(i);
            }
            return base.OnOptionsItemSelected(item);
        }
        //event for fab button
        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            Intent i = new Intent(this, typeof(AddDetailsActivity));
            StartActivity(i);
        }
	}
}

