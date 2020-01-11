using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using WebApplication1.Models;

namespace WebApplication.Models.DAL
{
    public class DBservices
    {
        public SqlDataAdapter da;
        public DataTable dt;

        public DBservices()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public SqlConnection connect(String conString)
        {

            // read the connection string from the configuration file
            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }

        public List<Pizza> getAllPizzas(string kosher)
        {
            int kosherInt = 0;
            List<Pizza> PizzasList = new List<Pizza>();
            SqlConnection con = null;
            if (kosher == "true")
            {
                kosherInt = 1;
            }

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file
                
                String selectSTR = "SELECT * FROM Pizza_ WHERE kosher='" + kosherInt + "'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Pizza p = new Pizza();

                    p.Id = Convert.ToInt32(dr["id"]);
                    p.Name = (string)dr["name"];
                    p.Kosher = (bool)dr["kosher"];

                    PizzasList.Add(p);
                }

                return PizzasList;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }

        public int didOrderBefore(string phonenumber)
        {
            
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM Orders_ WHERE phonenumber='" + phonenumber + "'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end


                if (dr.Read())
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }
        public int insert(Order order)
        {
            int didOrder = didOrderBefore(order.Phonenumber);

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCommand(order);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                //return numEffected;
                return didOrder;
            }
            catch (Exception ex)
            {
                return 0;
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();

                }
            }

        }
        private String BuildInsertCommand(Order order)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', {1}, '{2}', '{3}', {4})", order.Phonenumber, Convert.ToInt32(order.SelfPickup), order.Address, order.Name, order.PizzaId);
            String prefix = "INSERT INTO Orders_ " + "(phonenumber, selfpickup, address, name, pizzaid) ";
            command = prefix + sb.ToString();
            return command;

    }
        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

            return cmd;
        }
    }
}