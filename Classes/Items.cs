using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricAssignmentyear2.Classes
{
    internal class Items
    {
        public int ItemNo { get; set; }
        public string ItemName { get; set; }
        public float Qty { get; set; }
        public float UP { get; set; }
        public float Total { get; set; }

        public bool Insert()
        {
            bool check = false;
            using (SqlConnection conn = new SqlConnection(AddConnection.Getconnection()))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Items]" +
                    "([ItemNo],[ItemName],[Qty],[UP],[Total]) VALUES" +
                    "(@ItemNo,@ItemName, @Qty, @UP,@Total)", conn);

                cmd.Parameters.AddWithValue("@ItemNo", ItemNo);
                cmd.Parameters.AddWithValue("@ItemName", ItemName);
                cmd.Parameters.AddWithValue("@Qty", Qty);
                cmd.Parameters.AddWithValue("@UP", UP);
                cmd.Parameters.AddWithValue("@Total", Total);

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
        public bool Update()
        {
            bool check = false;
            using (SqlConnection conn = new SqlConnection(AddConnection.Getconnection()))
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Items]
                                                           SET [ItemName] = @ItemName
                                                              ,[Qty] = @Qty                                                              
                                                              ,[UP] = @UP,
                                                            ,[Total]=@Total
                                                         WHERE ItemNo = @ItemNo", conn);
                cmd.Parameters.AddWithValue("@ItemNo", ItemNo);
                cmd.Parameters.AddWithValue("@ItemName", ItemName);
                cmd.Parameters.AddWithValue("@Qty", Qty);
                cmd.Parameters.AddWithValue("@UP", UP);
                cmd.Parameters.AddWithValue("@Total", Total);

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
        public bool Delete()
        {
            bool check = false;
            using (SqlConnection conn = new SqlConnection(AddConnection.Getconnection()))
            {
                SqlCommand cmd = new SqlCommand(@"DELETE FROM [dbo].[Items]
                                                  WHERE ItemNo = @ItemNo", conn);
                cmd.Parameters.AddWithValue("@ItemNo", ItemNo);
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
                SqlCommand cmd = new SqlCommand(@"SELECT [ItemNo],[ItemName],[Qty],[UP],[Total]" +
                                 "FROM[dbo].[Items] Where ItemNo = @ItemNo", conn);
                cmd.Parameters.AddWithValue("@ItemNo", @ItemNo);
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                SqlDataReader sqlDr = cmd.ExecuteReader();
                sqlDr.Read();
                if (sqlDr.HasRows)
                {
                    ItemNo = int.Parse(sqlDr.GetValue(0).ToString());
                    ItemName = sqlDr.GetValue(1).ToString();
                    Qty = float.Parse(sqlDr.GetValue(2).ToString());
                    UP = float.Parse(sqlDr.GetValue(3).ToString());
                    Total = float.Parse(sqlDr.GetValue(4).ToString());
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
