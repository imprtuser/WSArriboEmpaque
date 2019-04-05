using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;

namespace WSArriboService
{
    /// <summary>
    /// Descripción breve de WSArriboService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSArriboService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public void getPlants()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                DataTable dtPlants = new DataTable();

                dtPlants = DataAccess.executeStoreProcedureDataTable("spr_PackWedge_GetPlants", parameters, "dbConn");
                Context.Response.Write(JsonConvert.SerializeObject(dtPlants, Formatting.Indented));
                Context.Response.ContentType = "text/plain; charset=UTF-8";
            }
            catch (Exception)
            {

                throw;
            }
        }

        [WebMethod]
        public void getFolios(int idPlant, String folio, String dateIni, String dateFin, int idFolioHeader)
        {
            try
            {
                DataSet ds = new DataSet();
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                if(idPlant > 0)
                {
                    parameters.Add("@idPlant", idPlant);
                }

                if (!String.IsNullOrEmpty(folio))
                {
                    parameters.Add("@folio" , folio);
                }

                if (!String.IsNullOrEmpty(dateIni))
                {
                    parameters.Add("@dateIni", dateIni);
                }

                if (!String.IsNullOrEmpty(dateFin))
                {
                    parameters.Add("@dateFin", dateFin);
                }

                if (idFolioHeader > 0)
                {
                    parameters.Add("@idFolioHeader", idFolioHeader);
                }

                ds = DataAccess.executeStoreProcedureDataSet("spr_PackWedge_GetFolios", parameters, "dbConn");

                Context.Response.Write(JsonConvert.SerializeObject(ds, Formatting.Indented));
                Context.Response.ContentType = "text/plain; charset=UTF-8";

            }
            catch (Exception ex)
            {
                Context.Response.Write("{\n" +
                    "  \"table1\": [\n" +
                    "    {\n" +
                        "      \"responseType\": 2,\n" +
                        "      \"descriptionResponse\": \"Error\",\n" +
                        "      \"message\": \"" + ex.ToString() + "\"\n" +
                    "    }\n" +
                    "  ]\n" +
                "}");
            }
        }

        [WebMethod]
        public void pingToWS()
        {
             Context.Response.Write("1");
        }


        [WebMethod]
        public void saveInfoFolio(String xmlFoliosHeader, String xmlFoliosDetails)
        {
            try
            {
                DataTable dt = new DataTable();
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@xmlFoliosHeader", xmlFoliosHeader);
                parameters.Add("@xmlFoliosDetails", xmlFoliosDetails);

                String message = String.Empty;
                String descriptionType = String.Empty;
                int response = 0;

                dt = DataAccess.executeStoreProcedureDataTable("spr_PackWedge_InsUpInfoFolio", parameters, "dbConn");

                if (dt.Rows.Count > 0)
                {
                    response = Convert.ToInt32(dt.Rows[0]["responseType"].ToString());
                    descriptionType = dt.Rows[0]["descriptionType"].ToString();
                    message = dt.Rows[0]["message"].ToString();
                    if (response == 1)
                    {
                        Context.Response.Write("{\n" +
                          "  \"table1\": [\n" +
                              "    {\n" +
                              "      \"responseType\": \"" + response + "\",\n" +
                              "      \"descriptionResponse\": \"" + descriptionType + "\",\n" +
                              "      \"message\": \"" + message + "\"\n" +
                              "    }\n" +
                          "  ]\n" +
                        "}");

                    }else if (response == 2)
                    {
                        Context.Response.Write("{\n" +
                          "  \"table1\": [\n" +
                              "    {\n" +
                              "      \"responseType\": \"" + response + "\",\n" +
                              "      \"descriptionResponse\": \"" + descriptionType + "\",\n" +
                              "      \"message\": \"" + message + "\"\n" +
                              "    }\n" +
                          "  ]\n" +
                        "}");
                    }
                }
            }
            catch (Exception ex)
            {
                Context.Response.Write("{\n" +
                    "  \"table1\": [\n" +
                    "    {\n" +
                        "      \"responseType\": 2,\n" +
                        "      \"descriptionResponse\": \"Error\",\n" +
                        "      \"message\": \"" + ex.ToString() + "\"\n" +
                    "    }\n" +
                    "  ]\n" +
                "}");
            }
        }


        [WebMethod]
        public void getInfoFolio(String folio)
        {
            try
            {
                DataSet ds = new DataSet();

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@vFolio", folio);

                ds = DataAccess.executeStoreProcedureDataSet("spr_PackWedge_GetInfoFolio", parameters, "dbConn");

                Context.Response.Write(JsonConvert.SerializeObject(ds, Formatting.Indented));
                Context.Response.ContentType = "text/plain; charset=UTF-8";

            
            }
            catch (Exception ex)
            {
                Context.Response.Write("{\n" +
               "  \"table1\": [\n" +
                 "    {\n" +
                   "      \"responseType\": 2,\n" +
                   "      \"descriptionResponse\": \"ErrorWS\",\n" +
                   "      \"message\": \"" + ex.ToString() + "\"\n" +
                 "    }\n" +
               "  ]\n" +
             "}");
            }
        }

        [WebMethod]
        public void getInfoFoliosByID(int idFolioHeader)
        {
            try
            {
                DataSet ds = new DataSet();

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@idFolioHeader", idFolioHeader);

                ds = DataAccess.executeStoreProcedureDataSet("spr_PackWedge_GetInfoFoliosByID", parameters, "dbConn");

                Context.Response.Write(JsonConvert.SerializeObject(ds, Formatting.Indented));
                Context.Response.ContentType = "text/plain; charset=UTF-8";
            }
            catch (Exception ex)
            {
                Context.Response.Write("{\n" +
                "  \"table1\": [\n" +
                  "    {\n" +
                    "      \"responseType\": 2,\n" +
                    "      \"descriptionResponse\": \"ErrorWS\",\n" +
                    "      \"message\": \"" + ex.ToString() + "\"\n" +
                  "    }\n" +
                "  ]\n" +
              "}");
            }
        }


        [WebMethod]
        public void Login(String user, String password)
        {
            try
            {
                DataTable dt = null;
                int response = 0;
                String message = String.Empty;
                String description = String.Empty;
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@vUser", user);
                parameters.Add("@vPassword", password);

                if (ActiveDirectoryAuthentification(user, password))
                {
                    parameters.Add("@activeDirectory", 1);
                    dt = DataAccess.executeStoreProcedureDataTable("spr_PackWedge_Login", parameters, "dbConn");
                }
                else
                {
                    parameters.Add("@activeDirectory", 0);
                    dt = DataAccess.executeStoreProcedureDataTable("spr_PackWedge_Login", parameters, "dbConn");
                }

                Context.Response.ContentType = "text/plain; charset=UTF-8";
                if (dt.Rows.Count > 0)
                {
                    response = Convert.ToInt32(dt.Rows[0]["responseType"].ToString());
                    description = dt.Rows[0]["descriptionType"].ToString();
                    message = dt.Rows[0]["message"].ToString();

                    if (response == 1)
                    {

                        Context.Response.Write("{\n" +
                        "  \"table1\": [\n" +
                            "    {\n" +
                            "      \"responseType\": \"" + response + "\",\n" +
                            "      \"descriptionResponse\": \"" + description + "\",\n" +
                            "      \"message\": \"" + message + "\"\n" +
                            "    }\n" +
                        "  ]\n" +
                        "}");
                    }
                    else if(response == 2)
                    {

                        Context.Response.Write("{\n" +
                       "  \"table1\": [\n" +
                           "    {\n" +
                           "      \"responseType\": \"" + response + "\",\n" +
                           "      \"descriptionResponse\": \"" + description + "\",\n" +
                           "      \"message\": \"" + message + "\"\n" +
                           "    }\n" +
                       "  ]\n" +
                       "}");
                    }
                   
                }
                else
                {
                    Context.Response.Write("{\n" +
                    "  \"table1\": [\n" +
                      "    {\n" +
                        "      \"responseType\": 2,\n" +
                        "      \"descriptionResponse\": \"Error\",\n" +
                        "      \"message\": \"An error has ocurred.\"\n" +
                      "    }\n" +
                    "  ]\n" +
                  "}");
                }
            }
            catch (Exception ex)
            {
                Context.Response.Write("{\n" +
                "  \"table1\": [\n" +
                  "    {\n" +
                    "      \"responseType\": 2,\n" +
                    "      \"descriptionResponse\": \"Error\",\n" +
                    "      \"message\": \"" + ex.ToString() + "\"\n" +
                  "    }\n" +
                "  ]\n" +
              "}");
            }
        }

        public Boolean ActiveDirectoryAuthentification(String user, String password)
        {
            try
            {
                bool bIsOnActiveDirectory = false;
                try
                {
                    bIsOnActiveDirectory = isOnActiveDirectory(user, password);
                }
                catch
                {

                    return false;
                }

                if (bIsOnActiveDirectory)
                { return true; }
                else
                {

                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private Boolean isOnActiveDirectory(String user, String password)
        {
            string domain = ConfigurationManager.AppSettings["USADomain"];
            string domainAndUsername = domain + @"\" + user;
            DirectoryEntry entry = new DirectoryEntry(string.Format("LDAP://{0}:389", domain), domainAndUsername, password);
            DirectorySearcher search = new DirectorySearcher(entry);
            search.Filter = "(SAMAccountName=" + user + ")";
            search.PropertiesToLoad.Add("cn");
            try
            {
                SearchResult result = search.FindOne();
                if (result != null)
                    return true;
            }
            catch
            { }

            domain = ConfigurationManager.AppSettings["GDLDomain"];
            domainAndUsername = domain + @"\" + user;
            entry = new DirectoryEntry(string.Format("LDAP://{0}:389", domain), domainAndUsername, password);
            search = new DirectorySearcher(entry);
            search.Filter = "(SAMAccountName=" + user + ")";
            search.PropertiesToLoad.Add("cn");
            try
            {
                SearchResult result = search.FindOne();
                return result == null ? false : true;
            }
            catch
            {
                return false;
            }
        }

    }

}
