using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ElectricAssignmentyear2.Classes
{
    internal class Customers
    {
        public int CustNo { get; set; }
        public string CustName { get; set; }
        public string Sex { get; set; }
        public string CustAddress { get; set; }


        public bool Insert()
        {
            bool check = false;
            using (SqlConnection con = new SqlConnection(AddConnection.Getconnection()))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Customers]" +
                    "([CustNo],[CustName],[Sex],[CustAddress]) VALUES" +
                    "(@CustNo,@CustName, @Sex, @CustAddress)", con);

                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustNo", CustNo);
                cmd.Parameters.AddWithValue("@CustName", CustName);
                cmd.Parameters.AddWithValue("@Sex", Sex);
                cmd.Parameters.AddWithValue("@CustAddress", CustAddress);

                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    check = true;
                }
                catch (Exception)
                {
                    check = false;
                }

                return check;
            }
        }
        public bool Update()
        {
            bool check = false;
            using (SqlConnection con = new SqlConnection(AddConnection.Getconnection()))
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Customers]
                                                           SET [CustName] = @CustName
                                                              ,[Sex] = @Sex                                                              
                                                              ,[CustAddress] = @CustAddress                                                                                                                            
                                                         WHERE CustNo = @CustNo", con);
                cmd.Parameters.AddWithValue("@CustNo", CustNo);
                cmd.Parameters.AddWithValue("@CustName", CustName);
                cmd.Parameters.AddWithValue("@Sex", Sex);
                cmd.Parameters.AddWithValue("@CustAddress", CustAddress);

                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    check = true;
                }
                catch (Exception)
                {
                    check = false;
                }
                return check;
            }

        }
        public bool Delete()
        {
            bool check = false;
            using (SqlConnection con = new SqlConnection(AddConnection.Getconnection()))
            {
                SqlCommand cmd = new SqlCommand(@"DELETE FROM [dbo].[Customers]
                                                  WHERE CustNo = @CustNo", con);
                cmd.Parameters.AddWithValue("@CustNo", CustNo);
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    check = true;
                }
                catch (Exception)
                {
                    check = false;
                }
                return check;
            }
        }
        public bool Search()
        {
            bool check = false;
            using (SqlConnection con = new SqlConnection(AddConnection.Getconnection()))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT [CustNo],[CustName],[Sex],[CustAddress]" +
                                 "FROM[dbo].[Customers] Where CustNo = @CustNo", con);
                cmd.Parameters.AddWithValue("@CustNo", @CustNo);
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                SqlDataReader sqlDr = cmd.ExecuteReader();
                sqlDr.Read();
                if (sqlDr.HasRows)
                {
                    CustNo = int.Parse(sqlDr.GetValue(0).ToString());
                    CustName = sqlDr.GetValue(1).ToString();
                    Sex = sqlDr.GetValue(2).ToString();
                    CustAddress = sqlDr.GetValue(3).ToString();
                    check = true;
                }
                else
                {
                    check = false;          
                }
                return check;
            }
        }

        
    }
}
