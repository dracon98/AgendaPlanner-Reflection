using Android.Content;
using Android.Database.Sqlite;
using Android.Database;
using SQLite;
using Android.Util;
using System.Collections.Generic;
using System.Linq;

namespace AgendaPlanner_Reflection
{
    public class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool createDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "events.db")))
                {
                    connection.CreateTable<PlannerData>();
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQL", ex.Message);
                return false;
            }
        }
        public bool insertIntoTable(PlannerData plannerData)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "events.db")))
                {
                    connection.Insert(plannerData);
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQL", ex.Message);
                return false;
            }
        }
        public List<PlannerData> selectTableData()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "events.db")))
                {
                    return connection.Table<PlannerData>().ToList();
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQL", ex.Message);
                return null;
            }
        }
        public bool deleteTableData(PlannerData plannerData)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "events.db")))
                {
                    connection.Delete(plannerData);
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQL", ex.Message);
                return false;
            }
        }
        public bool updateIntoTable(PlannerData plannerData)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "events.db")))
                {
                    connection.Query<PlannerData>("UPDATE PlannerData set Title=?,Loc=?,Desc=?,Start=?,End=?", plannerData.Title, plannerData.Location, plannerData.Description, plannerData.Starts, plannerData.Ends);
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQL", ex.Message);
                return false;
            }
        }
        public bool deleteQueryData(PlannerData plannerData)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "events.db")))
                {
                    connection.Query<PlannerData>("DELETE FROM PlannerData WHERE Id=?", plannerData.ID);
                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQL", ex.Message);
                return false;
            }
        }
        public List<PlannerData> selectQueryTable(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "events.db")))
                {
                    return connection.Query<PlannerData>("SELECT * FROM PlannerData Where Id=?", id).ToList();
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                Log.Info("SQL", ex.Message);
                return null;
            }
        }
    }
}