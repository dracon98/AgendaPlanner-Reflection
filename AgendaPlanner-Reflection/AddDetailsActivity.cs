using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Content;
using Java.Util;
using Java.Text;
using static Android.App.DatePickerDialog;
using Android.Text;
using static Android.App.TimePickerDialog;
using Android.Util;
using System.Collections.Generic;

namespace AgendaPlanner_Reflection
{
    [Activity(Label = "DetailsActivity")]

    public class AddDetailsActivity : AppCompatActivity,IOnDateSetListener,IOnTimeSetListener
    {
        EditText start, end, title, description, location, start_time, end_time;
        Database db;
        private const int Date_dialog = 1;
        private const int End_dialog = 2;
        private const int Time_dialog = 3;
        private const int Endt_dialog = 4;
        int DialogId = 0;
        DateTime nowTime;
        int year, month, day;
        int hour, min;
        int id;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //initialising
            base.OnCreate(savedInstanceState);
            db = new Database();
            SetContentView(Resource.Layout.add_details);
            start = FindViewById<EditText>(Resource.Id.event_start_date);
            end = FindViewById<EditText>(Resource.Id.event_end_date);
            start_time = FindViewById<EditText>(Resource.Id.event_start_time);
            end_time = FindViewById<EditText>(Resource.Id.event_end_time);
            title = FindViewById<EditText>(Resource.Id.event_title);
            description = FindViewById<EditText>(Resource.Id.event_description);
            location = FindViewById<EditText>(Resource.Id.event_location);
            
            // action bar
            if (ActionBar != null)
            {
                ActionBar.SetDisplayHomeAsUpEnabled(true);
                ActionBar.SetDisplayShowHomeEnabled(true);
            }
            //initialising
            start.Clickable = true;
            end.Clickable = true;
            nowTime = DateTime.Now;
            start.Text = nowTime.Day + "/" + nowTime.Month + "/" + nowTime.Year;
            end.Text = nowTime.Day + "/" + nowTime.Month + "/" + nowTime.Year;
            day = nowTime.Day;
            month = nowTime.Month;
            year = nowTime.Year;
            hour = nowTime.Hour;
            min = nowTime.Minute;
            Intent i = Intent;
            //getting extra from intent
            id = i.GetIntExtra("editID", 0);
            string sid = i.GetStringExtra("stringDate");
            // if the activity get the extra
            if (sid != null)
            {
                start.Text = sid;
                string[] tokens = sid.Split('-');
                day = int.Parse(tokens[0]);
                month = int.Parse(tokens[1]);
                year = int.Parse(tokens[2]);
                end.Text = sid;
            }
            // if the activity get the extra
            if (id != 0)
            {
                List<PlannerData> source = db.selectQueryTable(id);
                title.Text = source[0].Title;
                description.Text = source[0].Description;
                location.Text = source[0].Location;
                string[] tokens = source[0].Starts.Split('-');
                start.Text = tokens[0];
                start_time.Text = tokens[1];
                string[] tokensE = source[0].Ends.Split('-');
                end.Text = tokensE[0];
                end_time.Text = tokensE[1];
            }
            //on click of the start edit text
            // chaning the identification of dialog id
            start.Click +=
            delegate
            {
                DialogId = 1;
                ShowDialog(Date_dialog);
            };
            //on click of the end edit text
            // chaning the identification of dialog id
            end.Click+=delegate
            {
                DialogId = 2;
                Calendar now = Calendar.Instance;
                ShowDialog(End_dialog);
            };
            //on click of the start time edit text
            // chaning the identification of dialog id
            start_time.Click += delegate
            {
                DialogId = 3;
                Calendar now = Calendar.Instance;
                ShowDialog(Time_dialog);
            };
            //on click of the end time edit text
            // chaning the identification of dialog id
            end_time.Click += delegate
            {
                DialogId = 4;
                Calendar now = Calendar.Instance;
                ShowDialog(Endt_dialog);
            };
        }
        //creating menu
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            //taking the resource from the menu folder
            MenuInflater.Inflate(Resource.Menu.details_menu, menu);
            return true;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            //when click it will add data to data base
            int id = item.ItemId;
            if (id == Resource.Id.action_add)
            {
                if (location.Text != "" && start.Text != "" && end.Text != "" && title.Text != "" && description.Text != "")
                {
                    PlannerData data = new PlannerData()
                    {
                        Location = location.Text,
                        Starts = start.Text+"-"+start_time.Text,
                        Ends = end.Text+"-"+end_time.Text,
                        Title = title.Text,
                        Description = description.Text
                    };
                    //if the data already inside the data base then
                    if (id != 0)
                    {
                        db.updateIntoTable(data);
                    }
                    else
                        db.insertIntoTable(data);// if not
                    //move to another activity
                    Intent i = new Intent(this, typeof(PlannerList));
                    StartActivity(i);
                }
                else
                    Toast.MakeText(this, "Any text box including date and time cannot be empty", ToastLength.Long).Show();//creating a toast
            }

            return base.OnOptionsItemSelected(item);
        }
        //on create override of dialog for both date picker view and time picker view
        protected override Dialog OnCreateDialog(int id)
        {
            switch (id)
            {
                case Date_dialog:
                    {
                        if (id != 0)
                        {
                            List<PlannerData> source = db.selectQueryTable(id);
                            string[] tokens = source[0].Starts.Split('-');
                            string[] date = tokens[0].Split(':');
                            day = int.Parse(date[0]);
                            month = int.Parse(date[1]);
                            year = int.Parse(date[2]);
                        }
                        return new DatePickerDialog(this,this,year,month,day);
                    }
                case End_dialog:
                    {
                        List<PlannerData> source = db.selectQueryTable(id);
                        string[] tokens = source[0].Ends.Split('-');
                        string[] date = tokens[0].Split(':');
                        day = int.Parse(date[0]);
                        month = int.Parse(date[1]);
                        year = int.Parse(date[2]);
                        return new DatePickerDialog(this, this, year, month, day);
                    }
                case Time_dialog:
                    {
                        if (id != 0) {
                            List<PlannerData> source = db.selectQueryTable(id);
                            string[] tokens = source[0].Starts.Split('-');
                            string[] time = tokens[1].Split(':');
                            hour = int.Parse(time[0]);
                            min = int.Parse(time[1]);
                        }
                        return new TimePickerDialog(this, this, hour, min, true);
                    }
                case Endt_dialog:
                    {
                        if (id != 0)
                        {
                            List<PlannerData> source = db.selectQueryTable(id);
                            string[] tokens = source[0].Ends.Split('-');
                            string[] time = tokens[1].Split(':');
                            hour = int.Parse(time[0]);
                            min = int.Parse(time[1]);
                        }
                        return new TimePickerDialog(this, this, hour, min, true);
                    }
            }
            return null;
        }
        //on date set that will be trigger after there is any change with the edit text of date
        public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        {
            this.year = year;
            this.month = month;
            this.day = dayOfMonth;
            if (DialogId == Date_dialog)
            {
                string[] tokens = end.Text.Split('/');
                int end_day = int.Parse(tokens[0]);
                int end_month = int.Parse(tokens[1]);
                int end_year = int.Parse(tokens[2]);
                if (( dayOfMonth > end_day && end_month == month && end_year == year) || (month > end_month && end_year == year) || year > end_year)
                    Toast.MakeText(this, "Sorry the start date cannot exceed the end date", ToastLength.Long).Show();
                else if ((dayOfMonth<nowTime.Day&&month==nowTime.Month&&year==nowTime.Year)||(month<nowTime.Month&&year==nowTime.Year)||year<nowTime.Year)
                    Toast.MakeText(this, "Planner cannot list data in the past", ToastLength.Long).Show();
                else
                    start.Text = day + "/" + month + "/" + year;
            }
            if (DialogId == End_dialog)
            {
                string[] tokens = start.Text.Split('/');
                int start_day = int.Parse(tokens[0]);
                int start_month = int.Parse(tokens[1]);
                int start_year = int.Parse(tokens[2]);
                if ((start_day>dayOfMonth&&start_month==month&&start_year==year)||(start_month>month&&start_year==year)||start_year > year)
                    Toast.MakeText(this, "Sorry the start date cannot exceed the end date", ToastLength.Long).Show();
                else
                    end.Text = day + "/" + month + "/" + year;
            }
        }
        //on date set that will be trigger after there is any change with the edit text of time
        public void OnTimeSet(TimePicker view, int hourOfDay, int minute)
        {
            this.hour = hourOfDay;
            this.min = minute;
            // for the starting time
            if (DialogId == Time_dialog)
            {
                //delimiter
                string[] tokens = end_time.Text.Split(':');
                int end_hour = int.Parse(tokens[0]);
                int end_min = int.Parse(tokens[1]);
                //criteria
                if ((hourOfDay > end_hour || (minute > end_min && end_hour == hourOfDay)) && start.Text == end.Text)
                    Toast.MakeText(this, "Sorry the start time cannot exceed the end date", ToastLength.Long).Show();
                else
                {
                    string time = string.Format("{0:D2}:{1:D2}", hourOfDay, minute);
                    start_time.Text = time;
                }
            }
            // for the end time
            else
            {
                //delimiter
                string[] tokens = start_time.Text.Split(':');
                int start_hour = int.Parse(tokens[0]);
                int start_min = int.Parse(tokens[1]);
                //criteria
                if ((start_hour>hourOfDay||(start_min>minute&&start_hour==hourOfDay)) && start.Text == end.Text)
                    Toast.MakeText(this, "Sorry the start time cannot exceed the end date", ToastLength.Long).Show();
                else
                {
                    string time = string.Format("{0:D2}:{1:D2}", hourOfDay, minute);
                    end_time.Text = time;
                }
                   
            }
        }
    }
}