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
    [Activity(Label = "DetailsActivity")]

    public class AddDetailsActivity : AppCompatActivity
    {
        EditText start;
        EditText end;
        EditText title;
        EditText description;
        EditText location;
        Database db;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            db = new Database();
            SetContentView(Resource.Layout.add_details);
            start = FindViewById<EditText>(Resource.Id.event_start_date);
            end = FindViewById<EditText>(Resource.Id.event_end_date);
            title = FindViewById<EditText>(Resource.Id.event_title);
            description = FindViewById<EditText>(Resource.Id.event_description);
            location = FindViewById<EditText>(Resource.Id.event_location);
            // Create your application here
            if (ActionBar != null)
            {
                ActionBar.SetDisplayHomeAsUpEnabled(true);
                ActionBar.SetDisplayShowHomeEnabled(true);
            }

        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.details_menu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_add)
            {
                PlannerData data = new PlannerData();
                data.Location = location.Text;
                data.Starts = start.Text;
                data.Ends = end.Text;
                data.Title = title.Text;
                data.Description = description.Text;
                db.insertIntoTable(data);
                Intent i = new Intent(this, typeof(PlannerList));
                StartActivity(i);
            }

            return base.OnOptionsItemSelected(item);
        }

    }
}