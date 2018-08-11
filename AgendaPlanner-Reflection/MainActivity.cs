using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Content;

namespace AgendaPlanner_Reflection
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{
        Database db;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.activity_main);

			Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            db = new Database();
            db.createDatabase();
			FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
            PlannerData data = new PlannerData()
            {
                Location = "Location",
                Starts = "Start",
                Ends = "End",
                Title = "Title",
                Description = "Description"

            };
            db.insertIntoTable(data);
            PlannerData data1 = new PlannerData()
            {
                Location = "Location",
                Starts = "Start",
                Ends = "End",
                Title = "Title",
                Description = "Description"

            };
            db.insertIntoTable(data1);
            PlannerData data2 = new PlannerData()
            {
                Location = "Location",
                Starts = "Start",
                Ends = "End",
                Title = "Title",
                Description = "Description"

            };
            db.insertIntoTable(data2);
            Intent j = new Intent(this, typeof(PlannerList));
            StartActivity(j);
        }

		public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_plus)
            {
                Intent i = new Intent(this, typeof(AddDetailsActivity));
                StartActivity(i);
            }
            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

