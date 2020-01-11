using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using WebApplication1.Models;

/// <summary>
/// DBServices is a class created by me to provides some DataBase Services
/// </summary>
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

    public Country getCountryByName(string name)
    {
        //List<Country> countriesList = new List<Country>();
        Country c = new Country();
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Countries WHERE name='" + name + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end



            //while (dr.Read())
            //{   // Read till the end of the data into a row
            if (dr.Read())
            {
                c.Id = Convert.ToInt32(dr["id"]);
                c.Name = (string)dr["name"];
                c.Lang = (string)dr["lang"];
                c.Continent = (string)dr["continent"];
                return c;
            } else
            {
                return null;
            }
            
            

           
            //}


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

    public List<Country> getAllCountries()
    {
        List<Country> countriesList = new List<Country>();
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Countries";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Country c = new Country();

                c.Id = Convert.ToInt32(dr["id"]);
                c.Name = (string)dr["name"];
                c.Lang = (string)dr["lang"];
                c.Continent = (string)dr["continent"];
                countriesList.Add(c);
            }

            return countriesList;
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

    public List<Country> getByContinent(string name)
    {
        List<Country> countriesList = new List<Country>();
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Countries WHERE continent='" + name + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Country c = new Country();

                c.Id = Convert.ToInt32(dr["id"]);
                c.Name = (string)dr["name"];
                c.Lang = (string)dr["lang"];
                c.Continent = (string)dr["continent"];
                countriesList.Add(c);
            }

            return countriesList;
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
    public DBservices readCountries()
    {
        SqlConnection con = null;
        try
        {
            con = connect("DBConnectionString");
            da = new SqlDataAdapter("select * from Countries", con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
        }

        catch (Exception ex)
        {
            // write errors to log file
            // try to handle the error
            throw ex;
        }

        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }


        return this;

    }

    public void update()
    {
        da.Update(dt);
    }
}



