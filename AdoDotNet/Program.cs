using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TrainerDB db = new TrainerDB();
            //// List<Trainers> trainers = db.AllTrainers();
            //List <Trainers> trainers;
            //List<Students> students;
            //db.AllTrainers(out trainers, out students);
            //Console.WriteLine("*** All Trainers From DataBase***");
            //foreach(var t in trainers)
            //{
            //    Console.WriteLine($" Id : {t.ID} Name:{t.Name} City:{t.City} Experience:{t.Experience}");
            //}
            //Console.WriteLine("*** All Trainers From DataBase***");
            //foreach (var s in students)
            //{ 
            //Console.WriteLine($" Roll NUmber {s.RollNumber} Name{s.Name} Gender{s.Gender} TrainerId:{s.TrainerId} ");
            //}

            //Console.WriteLine("Plz Enter Trainer Id");
            //    int trainerId=int.Parse(Console.ReadLine());
            //Trainers trainers1 = db.GetTrainerById(trainerId);
            //if (trainers1 != null)
            //{
            //    Console.WriteLine($"ID : {trainers1.ID} Name:{trainers1.Name} City:{trainers1.City} Experience:{trainers1.Experience}");
            //}
            //else
            //{
            //    Console.WriteLine($"Trainer not found for id :{trainerId}");
            //}
            //Console.ReadLine();


            //Console.WriteLine("plz enter a Name to search student");
            //string name = Console.ReadLine();

            //string ConnectionString = "server=LAPTOP-H107MBND\\SQLEXPRESS;database=ADONETDB;integrated security=true";
            //SqlConnection con = new SqlConnection(ConnectionString);
            ////parameter less
            ////string query = $"select * from Students where RollNumber = {rollNumber}";
            ////parameterised 
            ////string query = $"select * from Students where RollNumber = @RollNumber";
            ////SqlCommand cmd = new SqlCommand(query, con);
            ////cmd.Parameters.AddWithValue("@RollNumber", rollNumber);
            //string query = $"select * from Students where Name = @Name";
            //SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@Name", name);
            //con.Open();
            //SqlDataReader reader = cmd.ExecuteReader();

            //if(reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //       Students s = new Students()
            //       {
            //           RollNumber = (int)reader["RollNumber"],
            //           Name = reader["Name"].ToString(),
            //           Gender = reader["Gender"].ToString(),
            //           TrainerId = (int)reader["RollNumber"],
            //       };

            //        Console.WriteLine($"RollNumber: {s.RollNumber} Name: {s.Name} Gender: {s.Gender} TrainerId: {s.TrainerId} ");
            //        break;
            //    }

            //}
            //else {
            //    Console.WriteLine($" Students Not found for RollNumber :{name}");
            //}
            //con.Close();

            //Console.WriteLine("Plz enter Trainer ID");
            //int id = int.Parse(Console.ReadLine());

            //TrainerDB db1 = new TrainerDB();
            //Trainers trainers2 = db1.GetTrainerById(id);
            //Console.WriteLine($"Existing Trainer : ID:{trainers2.ID} Name: {trainers2.Name} City: {trainers2.City}" +
            //    $"Experience: {trainers2.Experience}");
            //string choice = "";
            //do
            //{
            //    Console.WriteLine("Plz enter Property Name To update");
            //    string name1 = Console.ReadLine();
            //    Console.WriteLine($"plz enter new value for {name1}");
            //    string newValue = Console.ReadLine();

            //    switch (name1.ToUpper())
            //    {
            //        case "NAME":
            //            trainers2.Name= newValue;
            //            break;
            //        case "CITY":
            //            trainers2.City = newValue;
            //            break;
            //        case "EXPERIENCE":
            //            trainers2.Experience = int.Parse(newValue);
            //            break;
            //        default: Console.WriteLine("Invalid Property Name");
            //                break;
            //    }
            //    Console.WriteLine("Do You Want To Continue");
            //    choice = Console.ReadLine().ToUpper();


            //} while (choice == "Y" || choice == "YES");
            //bool status = db1.UpdateTrainer(trainers2);
            //if (status)
            //{
            //    Console.WriteLine("Trainer details Updated Successfully.");
            //}
            //else
            //{
            //    Console.WriteLine("Trainer Update Failed");
            //}


            //            Console.WriteLine("plz enter trainer id to delete");
            //            int id = int.Parse(Console.ReadLine());

            //            TrainerDB db = new TrainerDB();
            //            bool status = db.DeleteTrainer(id);

            //            if (status)
            //            {
            //                Console.WriteLine($" Trainer With id {id} is deleted successfully ");

            //            }
            //            else
            //            {
            //                Console.WriteLine($"Unable to delete trainer with id : {id}");
            //            }
            //;

            Console.WriteLine($"Data Copy Started @{DateTime.Now}..");
            TrainerDB db = new TrainerDB();
            bool status = db.BulkDataCopy();
            if( status )
            {
                Console.WriteLine($"Data Copy Completed  @{DateTime.Now}..");

            }
            else
            {
                Console.WriteLine($"Data Copy Stopped Due to Error @{DateTime.Now}..");
            }
            Console.ReadLine() ;
        }
    }
}
