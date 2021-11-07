﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace project_clothes_dao
{
    public class DataHelper
    {
        string stcon;
        SqlConnection con;
        public DataHelper()
        {
            stcon = ConfigurationManager.ConnectionStrings["strconnect"].ConnectionString;
            con = new SqlConnection(stcon);
        }
        public void Open()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void Close()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public DataTable getDataTable(string query)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            return dt;
        }
        public SqlDataReader storeReaders(string store_name, params object[] param)
        {
            Open();
            SqlCommand cm;
            try
            {
                cm = new SqlCommand(store_name, con);
                cm.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cm);
                for (int i = 1; i < cm.Parameters.Count; i++)
                {
                    if (param[i - 1].ToString() == "00000000-0000-0000-0000-000000000000")
                    {
                        param[i - 1] = Guid.Empty;
                    }
                    cm.Parameters[i].Value = param[i - 1];
                }
                SqlDataReader dr = cm.ExecuteReader();
                return dr;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

    }
}
