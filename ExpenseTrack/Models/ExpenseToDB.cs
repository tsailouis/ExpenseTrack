using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ExpenseTrack.Models
{
    public class ExpenseToDB
    {
        private string ConnectionString { get; set; }

        public ExpenseToDB()
        {
            this.ConnectionString = WebConfigurationManager.ConnectionStrings["DBconnect"].ConnectionString;
        }

        /// <summary>
        /// Gets all authors.
        /// </summary>
        /// <returns></returns>
        public List<ExpenseTrackModels> GetAllAccountBook()
        {
            var result = new List<ExpenseTrackModels>();

            const string sqlStatement = "Select  Amounttt,Dateee,Remarkkk,Categoryyy From AccountBook ";

            using (var conn = new SqlConnection(this.ConnectionString))
            using (var command = new SqlCommand(sqlStatement, conn))
            {
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 180;

                if (conn.State != ConnectionState.Open) conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //好處只有這裡弱型別,前面都用選的不會打錯
                        var item = new ExpenseTrackModels
                        {
                            Money = int.Parse(reader["Amounttt"].ToString()),
                            CreateDate = DateTime.Parse(reader["Dateee"].ToString()),
                            Description = reader["Remarkkk"].ToString(),
                            PayType= reader["Categoryyy"].ToString()
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }



        /// <summary>
        ///  GetAllAccountBook_DataBaseFirst
        /// </summary>
        /// <returns></returns>
        public List<ExpenseTrackModels> GetAllAccountBook_EF_DataBaseFirst()
        {

            FromDataBaseConn EF_DataBaseFirst =new FromDataBaseConn();
            var result = (from c in EF_DataBaseFirst.AccountBook
                          select new ExpenseTrackModels
                          {
                              CreateDate= c.Dateee,
                              Money = c.Amounttt,
                              PayType = c.Categoryyy.ToString(),
                              Description=c.Remarkkk
                          }).Take(10).ToList();
                        


            return result;
        }
    }
}