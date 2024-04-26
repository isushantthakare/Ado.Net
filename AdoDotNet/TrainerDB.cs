using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Linq.Expressions;

namespace AdoDotNet
{
    public class TrainerDB
    {

        string connectionString = null;

        public TrainerDB()
        {
            connectionString =
                ConfigurationManager.ConnectionStrings["ADONETDB"].ConnectionString;
        }
        //Select All Trainers
        public void AllTrainers(out List<Trainers> trainers, out List<Students> students)
        {
            #region record from one table
            //List<Trainers> trainers = new List<Trainers>();
            //string connectionString = "server=LAPTOP-H107MBND\\SQLEXPRESS;database=ADONETDB;integrated security=true";
            //SqlConnection con = new SqlConnection(connectionString);
            //con.Open();

            //string cmdText = "select id,Name,city,Experience from trainer";
            //SqlCommand cmd = new SqlCommand(cmdText, con);
            //SqlDataReader reader = cmd.ExecuteReader();

            //if (reader.HasRows)
            //{ 
            // while(reader.Read())
            //    {
            //   Trainers t = new Trainers();
            //        t.ID = (int)reader["id"];
            //        t.Name = reader["Name"].ToString();
            //        t.City = reader["city"].ToString();
            //        t.Experience = (int)reader["Experience"];


            //        trainers.Add(t);
            //    }
            //}
            //con.Close();
            //return trainers;
            #endregion record from one table
            #region Selecting records from two tables
            //    trainers = new List<Trainers>();
            //    students = new List<Students>();
            //    string connectionString = "server=LAPTOP-H107MBND\\SQLEXPRESS;database=ADONETDB; integrated security=true";
            //    SqlConnection con = new SqlConnection(connectionString);
            //    string cmdText = "select id,Name,city,Experience from trainer;select RollNumber, Name,Gender,TrainerId from Students";
            //    SqlCommand cmd = new SqlCommand(cmdText, con);
            //    con.Open();
            //    SqlDataReader reader=cmd.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        Trainers t = new Trainers()
            //        {
            //            ID = (int)reader["id"],
            //            Name = reader["name"].ToString(),
            //            City = reader["City"].ToString(),
            //            Experience = (int)reader["Experience"]
            //        };

            //        trainers.Add(t);
            //    }
            //    reader.NextResult();

            //    while (reader.Read())
            //    {
            //        Students ss = new Students()
            //        {
            //            RollNumber =(int) reader["RollNumber"],
            //            Name = reader["Name"].ToString(),
            //            Gender = reader["Gender"].ToString(),
            //            TrainerId =(int) reader["TrainerId"]
            //        };
            //        students.Add(ss);
            //    }
            //con.Close();
            #endregion Selecting records from two tables
            trainers = new List<Trainers>();
            students = new List<Students>();
            string connectionString = "server=LAPTOP-H107MBND\\SQLEXPRESS;database=ADONETDB;integrated security=true";
            SqlConnection con = new SqlConnection(connectionString);
            string cmdText = "select id,Name,city,Experience from trainer;select RollNumber,Name,Gender,TrainerId from Students";
            SqlDataAdapter adapter = new SqlDataAdapter(cmdText, con);

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        var row = ds.Tables[0].Rows[i];
                        Trainers t = new Trainers()
                        {
                            ID = (int)row["id"],
                            Name = row["Name"].ToString(),
                            City = row["city"].ToString(),
                            Experience = (int)row["Experience"],
                        };

                        trainers.Add(t);
                    }
                }
                if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        var row = ds.Tables[1].Rows[i];
                        Students s = new Students()
                        {
                            RollNumber = (int)row["RollNumber"],
                            Name = row["Name"].ToString(),
                            Gender = row["Gender"].ToString(),
                            TrainerId = (int)row["TrainerId"],
                        };

                        students.Add(s);
                    }
                }
            }
        }
        public Trainers GetTrainerById(int id)
        {
            Trainers trainers1 = null;
            string connectionString = "server=LAPTOP-H107MBND\\SQLEXPRESS;database=ADONETDB;integrated security=true";
            SqlConnection con = new SqlConnection(connectionString);
            string cmdText = $"select id,Name,city,Experience from trainer where id ={id}";
            SqlCommand cmd = new SqlCommand(cmdText, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {


                trainers1 = new Trainers();
                trainers1.ID = (int)reader["id"];
                trainers1.Name = reader["Name"].ToString();
                trainers1.City = reader["city"].ToString();
                trainers1.Experience = (int)reader["Experience"];

                break;
            }
            con.Close();
            return trainers1;

        }
        public bool UpdateTrainer(Trainers trainers)
        {
            string connectionString = "server=LAPTOP-H107MBND\\SQLEXPRESS;database=ADONETDB;integrated security=true";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("uspUpdateTrainer1", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", trainers.ID);
            cmd.Parameters.AddWithValue("@Name", trainers.Name);
            cmd.Parameters.AddWithValue("@City", trainers.City);
            cmd.Parameters.AddWithValue("@Experience", trainers.Experience);

            SqlParameter status = new SqlParameter()
            {
                ParameterName = "@Status",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Output,
            };
            cmd.Parameters.Add(status);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return (bool)status.Value;
        }
        public bool DeleteTrainer(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ADONETDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("uspDeleteTrainer1", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);


            SqlParameter status = new SqlParameter()
            {
                ParameterName = "@Status",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Output,
            };
            cmd.Parameters.Add(status);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return (bool)status.Value;


        }

        public bool BulkDataCopy()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("select * from Trainer", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                string destinationConString = ConfigurationManager.ConnectionStrings["ArchiveDB"].ConnectionString;
                SqlConnection destinationCon = new SqlConnection(destinationConString);
                SqlBulkCopy copy = new SqlBulkCopy(destinationCon);
                copy.DestinationTableName = "dbo.Trainer";

                destinationCon.Open();
                copy.WriteToServer(reader);
                con.Close();
                destinationCon.Close();
                return true;

            }
            catch
            {
                return false;
            }
        }

    }
}
                
                

    

    
            

    
