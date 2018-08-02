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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.add_details);
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
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            }

            return base.OnOptionsItemSelected(item);
        }

    }
}