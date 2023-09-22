using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricAssignmentyear2.Classes
{
    internal class Orders
    {
        //Orders
        public int OrdNo { get; set; }
        public DateTime OrdDate { get; set; }
        public int CustNo { get; set; }
        public int EmpNo { get; set; }
        public string Location { get; set; }
        public string OrdStatus { get; set; }
        //OrderDetails
        public int ItemNo { get; set; }
        public float Qty { get; set; }
        public float UP { get; set; }
        public float Total { get; set; }

        public bool Insert()
        {
            bool check = false;
            using (SqlConnection conn = new SqlConnection(AddConnection.Getconnection()))
            {
                SqlCommand cmd1 = new SqlCommand("INSERT INTO [dbo].[Orders]" +
                    "([OrdNo],[OrdDate],[CustNo],[EmpNo],[Locations],[OrdStatus]) VALUES" +
                    "(@OrdNo,CONVERT(date,@OrdDate, 103),@CustNo,@EmpNo,@Location,@OrdStatus)", conn);

                cmd1.Parameters.AddWithValue("@OrdNo", OrdNo);
                cmd1.Parameters.AddWithValue("@OrdDate", OrdDate);
                cmd1.Parameters.AddWithValue("@CustNo", CustNo);
                cmd1.Parameters.AddWithValue("@EmpNo", EmpNo);
                cmd1.Parameters.AddWithValue("@Location", Location);
                cmd1.Parameters.AddWithValue("@OrdStatus", OrdStatus);

                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                try
                {
                    cmd1.ExecuteNonQuery();
                    check = true;
                }
                catch (Exception)
                {
                    check = false;
                }
                return check;
            }
        }
        public bool InsertOrdDetails()
        {
            bool check = false;
            using (SqlConnection conn = new SqlConnection(AddConnection.Getconnection()))
            {
                SqlCommand cmd2 = new SqlCommand("INSERT INTO [dbo].[OrdDetails]" +
                    "([OrdNo],[ItemNo],[Qty],[UP],[Total]) VALUES" +
                    "(@OrdNo,@ItemNo,@Qty,@UP,@Total)", conn);

                cmd2.Parameters.AddWithValue("@OrdNo", OrdNo);
                cmd2.Parameters.AddWithValue("@ItemNo", ItemNo);
                cmd2.Parameters.AddWithValue("@Qty", Qty);
                cmd2.Parameters.AddWithValue("@UP", UP);
                cmd2.Parameters.AddWithValue("@Total", Total);

                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                try
                {
                    cmd2.ExecuteNonQuery();
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
            using (SqlConnection conn = new SqlConnection(AddConnection.Getconnection()))
            {
                SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[Orders]
                                                           SET [OrdDate] = @OrdDate
                                                              ,[CustNo] = @CustNo                                                              
                                                              ,[EmpNo] = @EmpNo
                                                            ,[Locations]=@Location
                                                            ,[OrdStatus]=@OrdStatus
                                                         WHERE OrdNo = @OrdNo", conn);

                cmd1.Parameters.AddWithValue("@OrdNo", OrdNo);
                cmd1.Parameters.AddWithValue("@OrdDate", OrdDate);
                cmd1.Parameters.AddWithValue("@CustNo", CustNo);
                cmd1.Parameters.AddWithValue("@EmpNo", EmpNo);
                cmd1.Parameters.AddWithValue("@Location", Location);
                cmd1.Parameters.AddWithValue("@OrdStatus", OrdStatus);

                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                try
                {
                    cmd1.ExecuteNonQuery();
                    check = true;
                }
                catch (Exception)
                {
                    check = false;
                }
                return check;
            }

        }
        public bool UpdateOrdDetails()
        {
            bool check = false;
            using (SqlConnection conn = new SqlConnection(AddConnection.Getconnection()))
            {
                SqlCommand cmd2 = new SqlCommand(@"UPDATE [dbo].[Items]
                                                           SET [Qty] = @Qty,                                                              
                                                               [UP] = @UP,
                                                               [Total]=@Total
                                                         WHERE ItemNo = @ItemNo", conn);
                cmd2.Parameters.AddWithValue("@ItemNo", ItemNo);
                cmd2.Parameters.AddWithValue("@Qty", Qty);
                cmd2.Parameters.AddWithValue("@UP", UP);
                cmd2.Parameters.AddWithValue("@Total", Total);

                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                try
                {
                    cmd2.ExecuteNonQuery();
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
            using (SqlConnection conn = new SqlConnection(AddConnection.Getconnection()))
            {
                SqlCommand cmd = new SqlCommand(@"DELETE FROM [dbo].[Orders]
                                                  WHERE OrdNo = @OrdNo", conn);
                cmd.Parameters.AddWithValue("@OrdNo", OrdNo);
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
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
            using (SqlConnection conn = new SqlConnection(AddConnection.Getconnection()))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT [OrdNo],[OrdDate],[CustNo],[EmpNo],[Locations],[OrdStatus]" +
                                 "FROM[dbo].[Orders] Where OrdNo = @OrdNo", conn);
                cmd.Parameters.AddWithValue("@OrdNo", @OrdNo);
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                SqlDataReader sqlDr = cmd.ExecuteReader();
                sqlDr.Read();
                if (sqlDr.HasRows)
                {
                    OrdNo = int.Parse(sqlDr.GetValue(0).ToString());
                    OrdDate = DateTime.Parse(sqlDr.GetValue(1).ToString());
                    CustNo = int.Parse(sqlDr.GetValue(2).ToString());
                    EmpNo = int.Parse(sqlDr.GetValue(3).ToString());
                    Location = sqlDr.GetValue(4).ToString();
                    OrdStatus = sqlDr.GetValue(5).ToString();
                    check = true;
                }
                else
                {
                    check = false;
                }
                return check;
            }
        }
        public DataTable SearchDetails()
        {
            //DECLARE
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            //INPUT            
            using (SqlConnection conn = new SqlConnection(AddConnection.Getconnection()))
            {
                SqlCommand cmd = new SqlCommand(
                   @"SELECT OD.[ItemNo],I.ItemName,OD.[Qty],OD.[UP],OD.[Total]" +
                    " From Items I INNER JOIN [OrdDetails] OD" +
                    " ON I.ItemNo = OD.ItemNo" +
                    " where OD.OrdNo=" + OrdNo + ";", conn);
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                dataTable = new DataTable();
                dataAdapter = new SqlDataAdapter(cmd);

                //PROCESS
                dataAdapter.Fill(dataTable);
                conn.Close();
            }
            //OUTPUT
            return dataTable;
        }
    }
}
