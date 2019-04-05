using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.ComponentModel;

/// <summary>
/// Descripción breve de DataAccess
/// </summary>
public static class DataAccess
{
    //public DataAccess()
    //{
    //    //
    //    // TODO: Agregar aquí la lógica del constructor
    //    //
    //}

    private static string connectionString()
    {
        return ConfigurationManager.ConnectionStrings["dbConn"].ToString();
        /*String pk_App = ConfigurationManager.AppSettings["PK_App"].ToString();
        String Db = ConfigurationManager.AppSettings["Db"].ToString();
        String valueReturn = "";

        NsSecurity.Connection WS = new NsSecurity.Connection();
        valueReturn = WS.dllConecction(pk_App, Db);

        return valueReturn;*/
    }

    private static string connectionString(String Pk_App, String Db)
    {
        NsSecurity.Connection WS = new NsSecurity.Connection();
        return WS.dllConecction(Pk_App, Db);
        //return ConfigurationManager.ConnectionStrings[ConnectionName].ToString();
    }

    private static string connectionString(String Conection)
    {
        /*NsSecurity.Connection WS = new NsSecurity.Connection();
        return WS.dllConecction(Pk_App, Db);*/
        return ConfigurationManager.ConnectionStrings[Conection].ToString();
    }

    public static DataTable executeStoreProcedureDataTableNew(string spName, Dictionary<string, object> parameters, String conection) //String Pk_App, String Db)
    {

        //SqlConnection dbconnx = new SqlConnection(connectionString(Pk_App, Db));
        SqlConnection dbconnx = new SqlConnection(connectionString(conection));
        SqlCommand cmdx = new SqlCommand(spName, dbconnx);

        SqlDataAdapter sqlDAx = new SqlDataAdapter(cmdx);
        DataTable dtx = new DataTable();

        cmdx.CommandType = CommandType.StoredProcedure;
        cmdx.CommandTimeout = 1000;

        foreach (string item in parameters.Keys)
        {
            cmdx.Parameters.AddWithValue(item, parameters[item]);
        }

        try
        {

            dbconnx.Open();
            sqlDAx.Fill(dtx);
            dbconnx.Close();
            return dtx;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
        finally
        {
            if (dbconnx.State != ConnectionState.Closed)
            {
                dbconnx.Close();
            }
        }
    }

    /// <summary>
    /// Execute any store procedure
    /// </summary>
    /// <param name="spName">Store Procedure Name</param>
    /// <param name="parameters">Parameters Dictionary (string,object)</param>
    /// <returns></returns>
    public static DataTable executeStoreProcedureDataTable(string spName, Dictionary<string,object> parameters)
    {

        SqlConnection dbconn = new SqlConnection(connectionString());
        SqlCommand cmd = new SqlCommand(spName, dbconn);

        SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 3000;

        foreach (string item in parameters.Keys)
        {
            cmd.Parameters.AddWithValue(item, parameters[item]);
        }

        try
        {

            dbconn.Open();
            sqlDA.Fill(dt);
            dbconn.Close();
            return dt;
        }
        catch (Exception ex)
        {
           
            throw new Exception(ex.Message);
        }
        finally
        {
            if (dbconn.State != ConnectionState.Closed)
            {
                dbconn.Close();
            }
        }
    }

    public static DataTable executeStoreProcedureDataTable(string spName, Dictionary<string, object> parameters, String connectionName)// String Pk_App, String Db)
    {

        SqlConnection dbconn = new SqlConnection(connectionString(connectionName));
        //SqlConnection dbconn = new SqlConnection(connectionString(Pk_App, Db));
        SqlCommand cmd = new SqlCommand(spName, dbconn);

        SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;

        foreach (string item in parameters.Keys)
        {
            cmd.Parameters.AddWithValue(item, parameters[item]);
        }

        try
        {
            dbconn.Open();
            sqlDA.Fill(dt);
            dbconn.Close();
            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (dbconn.State != ConnectionState.Closed)
            {
                dbconn.Close();
            }
        }
    }

    /* public static DataTable executeStoreProcedureDataTable(string spName, Dictionary<string, object> parameters, String Conection)
     {

         //SqlConnection dbconn = new SqlConnection(connectionString(connectionName));
         SqlConnection dbconn = new SqlConnection(connectionString(Conection));
         SqlCommand cmd = new SqlCommand(spName, dbconn);

         SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
         DataTable dt = new DataTable();

         cmd.CommandType = CommandType.StoredProcedure;
         cmd.CommandTimeout = 1000;

         foreach (string item in parameters.Keys)
         {
             cmd.Parameters.AddWithValue(item, parameters[item]);
         }

         try
         {
             dbconn.Open();
             sqlDA.Fill(dt);
             dbconn.Close();
             return dt;
         }
         catch (Exception ex)
         {
             throw new Exception(ex.Message);
         }
         finally
         {
             if (dbconn.State != ConnectionState.Closed)
             {
                 dbconn.Close();
             }
         }
     }*/


    public static DataSet executeStoreProcedureDataSet(string spName, Dictionary<string, object> parameters, String connectionName)// String Pk_App, String Db)
    {
        SqlConnection dbconn = new SqlConnection(connectionString(connectionName));
        SqlCommand cmd = new SqlCommand(spName, dbconn);

        SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;

        foreach (string item in parameters.Keys)
        {
            cmd.Parameters.AddWithValue(item, parameters[item]);
        }

        try
        {
            dbconn.Open();
            sqlDA.Fill(ds);
            dbconn.Close();
            sqlDA.Dispose();
            cmd.Dispose();

            for (int i = 0; i < ds.Tables.Count; ++i)
            {
                ds.Tables[i].TableName = string.Format("table{0}", i + 1);
            }

            return ds;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (dbconn.State != ConnectionState.Closed)
            {
                dbconn.Close();
            }
        }
    }


    public static DataSet executeStoreProcedureDataSet(string spName, Dictionary<string, object> parameters)
    {

        SqlConnection dbconn = new SqlConnection(connectionString());
        SqlCommand cmd = new SqlCommand(spName, dbconn);

        SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;

        foreach (string item in parameters.Keys)
        {
            cmd.Parameters.AddWithValue(item, parameters[item]);
        }

        try
        {
            dbconn.Open();
            sqlDA.Fill(ds);
            dbconn.Close();
            sqlDA.Dispose();
            cmd.Dispose();

            for (int i = 0; i < ds.Tables.Count; ++i)
            {
                ds.Tables[i].TableName = string.Format("table{0}",i+1);
            }

            return ds;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (dbconn.State != ConnectionState.Closed)
            {
                dbconn.Close();
            }
        }
    }

    public static void executeStoreProcedureNonQuery(string spName, Dictionary<string, object> parameters)
    {

        SqlConnection dbconn = new SqlConnection(connectionString());
        SqlCommand cmd = new SqlCommand(spName, dbconn);
        DataTable dt = new DataTable();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;

        foreach (string item in parameters.Keys)
        {
            cmd.Parameters.AddWithValue(item, parameters[item]);
        }

        try
        {
            dbconn.Open();
            cmd.ExecuteNonQuery();
            dbconn.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (dbconn.State != ConnectionState.Closed)
            {
                dbconn.Close();
            }
        }
    }

    public static void executeStoreProcedureNonQuery(string spName, Dictionary<string, object> parameters, String pkApp, String Db)
    {

        //SqlConnection dbconn = new SqlConnection(connectionString(connectionName));
        SqlConnection dbconn = new SqlConnection(connectionString(pkApp, Db));
        SqlCommand cmd = new SqlCommand(spName, dbconn);
        DataTable dt = new DataTable();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;

        foreach (string item in parameters.Keys)
        {
            cmd.Parameters.AddWithValue(item, parameters[item]);
        }

        try
        {
            dbconn.Open();
            cmd.ExecuteNonQuery();
            dbconn.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (dbconn.State != ConnectionState.Closed)
            {
                dbconn.Close();
            }
        }
    }


    public static float executeStoreProcedureFloat(string spName, Dictionary<string, object> parameters)
    {

        SqlConnection dbconn = new SqlConnection(connectionString());
        SqlCommand cmd = new SqlCommand(spName, dbconn);

        SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;

        foreach (string item in parameters.Keys)
        {
            cmd.Parameters.AddWithValue(item, parameters[item]);
        }

        try
        {
            dbconn.Open();
            sqlDA.Fill(dt);
            dbconn.Close();
            return float.Parse(dt.Rows[0][0].ToString());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (dbconn.State != ConnectionState.Closed)
            {
                dbconn.Close();
            }
        }
    }

    public static int executeStoreProcedureInt(string spName, Dictionary<string, object> parameters)
    {

        SqlConnection dbconn = new SqlConnection(connectionString());
        SqlCommand cmd = new SqlCommand(spName, dbconn);

        SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;

        foreach (string item in parameters.Keys)
        {
            cmd.Parameters.AddWithValue(item, parameters[item]);
        }

        try
        {
            dbconn.Open();
            sqlDA.Fill(dt);
            dbconn.Close();
            return int.Parse(dt.Rows[0][0].ToString());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (dbconn.State != ConnectionState.Closed)
            {
                dbconn.Close();
            }
        }
    }

    public static DataTable ToDataTable<T>(this List<T> iList)
    {
        DataTable dataTable = new DataTable();
        PropertyDescriptorCollection propertyDescriptorCollection =
            TypeDescriptor.GetProperties(typeof(T));
        for (int i = 0; i < propertyDescriptorCollection.Count; i++)
        {
            PropertyDescriptor propertyDescriptor = propertyDescriptorCollection[i];
            Type type = propertyDescriptor.PropertyType;

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                type = Nullable.GetUnderlyingType(type);


            dataTable.Columns.Add(propertyDescriptor.Name, type);
        }
        object[] values = new object[propertyDescriptorCollection.Count];
        foreach (T iListItem in iList)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = propertyDescriptorCollection[i].GetValue(iListItem);
            }
            dataTable.Rows.Add(values);
        }
        return dataTable;
    }

}
