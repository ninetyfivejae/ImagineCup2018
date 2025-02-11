﻿using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;

namespace ImagineCupProject
{
    /// <summary>
    /// _112DataPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class _112DataPage : Page
    {
        int send112Number = 0;
        int send110Number = 0;

        public _112DataPage()
        {
            InitializeComponent();
            PrintData(); 
        }

        public void PrintData()
        {
            try
            {
                var cb = new SqlConnectionStringBuilder();
                cb.DataSource = "mynewserver-20171214.database.windows.net";
                cb.UserID = "ServerAdmin";
                cb.Password = "JaeShin12!";
                cb.InitialCatalog = "mySampleDatabase";

                string sql;
                using (var connection = new SqlConnection(cb.ConnectionString))
                {
                    connection.Open();
                    sql = "select * from sendTo112";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        timeTo112.Text += reader.GetString(1) + "\n";
                        locationTo112.Text += reader.GetString(2) + "\n";
                        callerNumberTo112.Text += reader.GetString(3) + "\n";
                        problemTo112.Text += reader.GetString(5) + "\n"; 
                        send112Number++;
                        
                    }
                    reader.Close();
                    connection.Close();
                }
                sendTo112Text.Text += "            TotalNumber = " + send112Number + "\n";

                using (var connection = new SqlConnection(cb.ConnectionString))
                {
                    connection.Open();
                    sql = "select * from sendTo110";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        timeTo110.Text += reader.GetString(1) + "\n";
                        locationTo110.Text += reader.GetString(2) + "\n";
                        callerNumberTo110.Text += reader.GetString(3) + "\n";
                        problemTo110.Text += reader.GetString(5) + "\n";
                        send110Number++;

                    }
                    reader.Close();
                    connection.Close();
                }
                sendTo110Text.Text += "            TotalNumber = " + send110Number + "\n";

            }
            catch (SqlException er)
            {
                //MessageBox.Show(er.ToString());
            }
        }
    }
}
