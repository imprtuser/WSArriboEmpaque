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

        //[WebMethod]
        //public void getPlants()
        //{
        //    try
        //    {
        //        Dictionary<string, object> parameters = new Dictionary<string, object>();
        //        DataTable dtPlants = new DataTable();

        //        dtPlants = DataAccess.executeStoreProcedureDataTable("spr_PackWedge_GetPlants", parameters, "dbConn");
        //        Context.Response.Write(JsonConvert.SerializeObject(dtPlants, Formatting.Indented));
        //        Context.Response.ContentType = "text/plain; charset=UTF-8";
        //    }
        //    catch (Exception ex)
        //    {
        //        Context.Response.Write("{\n" +
        //           "  \"table1\": [\n" +
        //           "    {\n" +
        //               "      \"responseType\": 2,\n" +
        //               "      \"descriptionResponse\": \"Error\",\n" +
        //               "      \"message\": \"" + ex.ToString() + "\"\n" +
        //           "    }\n" +
        //           "  ]\n" +
        //       "}");
        //    }
        //}

        //[WebMethod]
        //public void getFoliosV2(int idPlant, String folio, String dateIni, String dateFin, int idFolioHeader)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        Dictionary<string, object> parameters = new Dictionary<string, object>();
        //        if(idPlant > 0)
        //        {
        //            parameters.Add("@idPlant", idPlant);
        //        }

        //        if (!String.IsNullOrEmpty(folio))
        //        {
        //            parameters.Add("@folio" , folio);
        //        }

        //        if (!String.IsNullOrEmpty(dateIni))
        //        {
        //            parameters.Add("@dateIni", dateIni);
        //        }

        //        if (!String.IsNullOrEmpty(dateFin))
        //        {
        //            parameters.Add("@dateFin", dateFin);
        //        }

        //        if (idFolioHeader > 0)
        //        {
        //            parameters.Add("@idFolioHeader", idFolioHeader);
        //        }

        //        ds = DataAccess.executeStoreProcedureDataSet("spr_PackWedge_GetFoliosV2", parameters, "dbConn");

        //        Context.Response.Write(JsonConvert.SerializeObject(ds, Formatting.Indented));
        //        Context.Response.ContentType = "text/plain; charset=UTF-8";

        //    }
        //    catch (Exception ex)
        //    {
        //        Context.Response.Write("{\n" +
        //            "  \"table1\": [\n" +
        //            "    {\n" +
        //                "      \"responseType\": 2,\n" +
        //                "      \"descriptionResponse\": \"Error\",\n" +
        //                "      \"message\": \"" + ex.ToString() + "\"\n" +
        //            "    }\n" +
        //            "  ]\n" +
        //        "}");
        //    }
        //}

        //[WebMethod]
        //public void getFolios(int idPlant, String folio, String dateIni, String dateFin)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        Dictionary<string, object> parameters = new Dictionary<string, object>();
        //        if (idPlant > 0)
        //        {
        //            parameters.Add("@idPlant", idPlant);
        //        }

        //        if (!String.IsNullOrEmpty(folio))
        //        {
        //            parameters.Add("@folio", folio);
        //        }

        //        if (!String.IsNullOrEmpty(dateIni))
        //        {
        //            parameters.Add("@dateIni", dateIni);
        //        }

        //        if (!String.IsNullOrEmpty(dateFin))
        //        {
        //            parameters.Add("@dateFin", dateFin);
        //        }

        //        ds = DataAccess.executeStoreProcedureDataSet("spr_PackWedge_GetFolios", parameters, "dbConn");

        //        Context.Response.Write(JsonConvert.SerializeObject(ds, Formatting.Indented));
        //        Context.Response.ContentType = "text/plain; charset=UTF-8";

        //    }
        //    catch (Exception ex)
        //    {
        //        Context.Response.Write("{\n" +
        //            "  \"table1\": [\n" +
        //            "    {\n" +
        //                "      \"responseType\": 2,\n" +
        //                "      \"descriptionResponse\": \"Error\",\n" +
        //                "      \"message\": \"" + ex.ToString() + "\"\n" +
        //            "    }\n" +
        //            "  ]\n" +
        //        "}");
        //    }
        //}




        //[WebMethod]
        //public void saveInfoFolioV2(String xmlFoliosHeader, String xmlFoliosDetails)
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        Dictionary<string, object> parameters = new Dictionary<string, object>();
        //        parameters.Add("@xmlFoliosHeader", xmlFoliosHeader);
        //        parameters.Add("@xmlFoliosDetails", xmlFoliosDetails);

        //        String message = String.Empty;
        //        String descriptionType = String.Empty;
        //        int response = 0;

        //        dt = DataAccess.executeStoreProcedureDataTable("spr_PackWedge_InsUpInfoFolioV2", parameters, "dbConn");

        //        if (dt.Rows.Count > 0)
        //        {
        //            response = Convert.ToInt32(dt.Rows[0]["responseType"].ToString());
        //            descriptionType = dt.Rows[0]["descriptionType"].ToString();
        //            message = dt.Rows[0]["message"].ToString();
        //            if (response == 1)
        //            {
        //                Context.Response.Write("{\n" +
        //                  "  \"table1\": [\n" +
        //                      "    {\n" +
        //                      "      \"responseType\": \"" + response + "\",\n" +
        //                      "      \"descriptionResponse\": \"" + descriptionType + "\",\n" +
        //                      "      \"message\": \"" + message + "\"\n" +
        //                      "    }\n" +
        //                  "  ]\n" +
        //                "}");

        //            }else if (response == 2)
        //            {
        //                Context.Response.Write("{\n" +
        //                  "  \"table1\": [\n" +
        //                      "    {\n" +
        //                      "      \"responseType\": \"" + response + "\",\n" +
        //                      "      \"descriptionResponse\": \"" + descriptionType + "\",\n" +
        //                      "      \"message\": \"" + message + "\"\n" +
        //                      "    }\n" +
        //                  "  ]\n" +
        //                "}");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Context.Response.Write("{\n" +
        //            "  \"table1\": [\n" +
        //            "    {\n" +
        //                "      \"responseType\": 2,\n" +
        //                "      \"descriptionResponse\": \"Error\",\n" +
        //                "      \"message\": \"" + ex.ToString() + "\"\n" +
        //            "    }\n" +
        //            "  ]\n" +
        //        "}");
        //    }
        //}


        //[WebMethod]
        //public void saveInfoFolio(String xmlFoliosHeader, String xmlFoliosDetails)
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        Dictionary<string, object> parameters = new Dictionary<string, object>();
        //        parameters.Add("@xmlFoliosHeader", xmlFoliosHeader);
        //        parameters.Add("@xmlFoliosDetails", xmlFoliosDetails);

        //        String message = String.Empty;
        //        String descriptionType = String.Empty;
        //        int response = 0;

        //        dt = DataAccess.executeStoreProcedureDataTable("spr_PackWedge_InsUpInfoFolio", parameters, "dbConn");

        //        if (dt.Rows.Count > 0)
        //        {
        //            response = Convert.ToInt32(dt.Rows[0]["responseType"].ToString());
        //            descriptionType = dt.Rows[0]["descriptionType"].ToString();
        //            message = dt.Rows[0]["message"].ToString();
        //            if (response == 1)
        //            {
        //                Context.Response.Write("{\n" +
        //                  "  \"table1\": [\n" +
        //                      "    {\n" +
        //                      "      \"responseType\": \"" + response + "\",\n" +
        //                      "      \"descriptionResponse\": \"" + descriptionType + "\",\n" +
        //                      "      \"message\": \"" + message + "\"\n" +
        //                      "    }\n" +
        //                  "  ]\n" +
        //                "}");

        //            }
        //            else if (response == 2)
        //            {
        //                Context.Response.Write("{\n" +
        //                  "  \"table1\": [\n" +
        //                      "    {\n" +
        //                      "      \"responseType\": \"" + response + "\",\n" +
        //                      "      \"descriptionResponse\": \"" + descriptionType + "\",\n" +
        //                      "      \"message\": \"" + message + "\"\n" +
        //                      "    }\n" +
        //                  "  ]\n" +
        //                "}");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Context.Response.Write("{\n" +
        //            "  \"table1\": [\n" +
        //            "    {\n" +
        //                "      \"responseType\": 2,\n" +
        //                "      \"descriptionResponse\": \"Error\",\n" +
        //                "      \"message\": \"" + ex.ToString() + "\"\n" +
        //            "    }\n" +
        //            "  ]\n" +
        //        "}");
        //    }
        //}


        //[WebMethod]
        //public void getInfoFolioV2(String folio)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();

        //        Dictionary<string, object> parameters = new Dictionary<string, object>();
        //        parameters.Add("@vFolio", folio);

        //        ds = DataAccess.executeStoreProcedureDataSet("spr_PackWedge_GetInfoFolioV2", parameters, "dbConn");

        //        Context.Response.Write(JsonConvert.SerializeObject(ds, Formatting.Indented));
        //        Context.Response.ContentType = "text/plain; charset=UTF-8";

            
        //    }
        //    catch (Exception ex)
        //    {
        //        Context.Response.Write("{\n" +
        //       "  \"table1\": [\n" +
        //         "    {\n" +
        //           "      \"responseType\": 2,\n" +
        //           "      \"descriptionResponse\": \"ErrorWS\",\n" +
        //           "      \"message\": \"" + ex.ToString() + "\"\n" +
        //         "    }\n" +
        //       "  ]\n" +
        //     "}");
        //    }
        //}


        //[WebMethod]
        //public void getInfoFolio(String folio)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();

        //        Dictionary<string, object> parameters = new Dictionary<string, object>();
        //        parameters.Add("@vFolio", folio);

        //        ds = DataAccess.executeStoreProcedureDataSet("spr_PackWedge_GetInfoFolio", parameters, "dbConn");

        //        Context.Response.Write(JsonConvert.SerializeObject(ds, Formatting.Indented));
        //        Context.Response.ContentType = "text/plain; charset=UTF-8";


        //    }
        //    catch (Exception ex)
        //    {
        //        Context.Response.Write("{\n" +
        //       "  \"table1\": [\n" +
        //         "    {\n" +
        //           "      \"responseType\": 2,\n" +
        //           "      \"descriptionResponse\": \"ErrorWS\",\n" +
        //           "      \"message\": \"" + ex.ToString() + "\"\n" +
        //         "    }\n" +
        //       "  ]\n" +
        //     "}");
        //    }
        //}


        //[WebMethod]
        //public void getInfoFoliosByID(int idFolioHeader)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();

        //        Dictionary<string, object> parameters = new Dictionary<string, object>();
        //        parameters.Add("@idFolioHeader", idFolioHeader);

        //        ds = DataAccess.executeStoreProcedureDataSet("spr_PackWedge_GetInfoFoliosByID", parameters, "dbConn");

        //        Context.Response.Write(JsonConvert.SerializeObject(ds, Formatting.Indented));
        //        Context.Response.ContentType = "text/plain; charset=UTF-8";
        //    }
        //    catch (Exception ex)
        //    {
        //        Context.Response.Write("{\n" +
        //        "  \"table1\": [\n" +
        //          "    {\n" +
        //            "      \"responseType\": 2,\n" +
        //            "      \"descriptionResponse\": \"ErrorWS\",\n" +
        //            "      \"message\": \"" + ex.ToString() + "\"\n" +
        //          "    }\n" +
        //        "  ]\n" +
        //      "}");
        //    }
        //}


        //[WebMethod]
        //public void getInfoFoliosByIDV2(int idFolioHeader)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();

        //        Dictionary<string, object> parameters = new Dictionary<string, object>();
        //        parameters.Add("@idFolioHeader", idFolioHeader);

        //        ds = DataAccess.executeStoreProcedureDataSet("spr_PackWedge_GetInfoFoliosByIDV2", parameters, "dbConn");

        //        Context.Response.Write(JsonConvert.SerializeObject(ds, Formatting.Indented));
        //        Context.Response.ContentType = "text/plain; charset=UTF-8";
        //    }
        //    catch (Exception ex)
        //    {
        //        Context.Response.Write("{\n" +
        //        "  \"table1\": [\n" +
        //          "    {\n" +
        //            "      \"responseType\": 2,\n" +
        //            "      \"descriptionResponse\": \"ErrorWS\",\n" +
        //            "      \"message\": \"" + ex.ToString() + "\"\n" +
        //          "    }\n" +
        //        "  ]\n" +
        //      "}");
        //    }
        //}





        //VERSION 4.0.1
        [WebMethod]
        public void getNetLibsPesaje_401(int cajas, int librasGross, int idTarePlant, int idTareBox)
        {
            try
            {
                DataTable dt = new DataTable();
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@iBoxes", cajas);
                parameters.Add("@iPoundsGross", librasGross);
                parameters.Add("@idTarePlant", idTarePlant);
                parameters.Add("@idTareBox", idTareBox);

                dt = DataAccess.executeStoreProcedureDataTable("spr_PackWedge_getNetLibsWeighing_401", parameters, "dbConn");

                Context.Response.Write(JsonConvert.SerializeObject(dt, Formatting.Indented));
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
               "}"); ;
            }
        }


        [WebMethod]
        public void filterFoliosByID_401(int idFolioHeader, int idPlant, String dateIni, String dateFin)
        {
            try
            {
                DataSet ds = new DataSet();
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                if (idFolioHeader > 0)
                {
                    parameters.Add("@idFolioHeader", idFolioHeader);
                }

                if (idPlant > 0)
                {
                    parameters.Add("@idPlant", idPlant);
                }

                if (!String.IsNullOrEmpty(dateIni))
                {
                    parameters.Add("@dateIni", dateIni);
                }

                if (!String.IsNullOrEmpty(dateFin))
                {
                    parameters.Add("@dateFin", dateFin);
                }

                ds = DataAccess.executeStoreProcedureDataSet("spr_PackWedge_GetFoliosByID_401", parameters, "dbConn");

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
        public void saveInfoFolio_401(String xmlFoliosHeader, String xmlFoliosDetails)
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

                dt = DataAccess.executeStoreProcedureDataTable("spr_PackWedge_InsUpInfoFolio_401", parameters, "dbConn");

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

                    }
                    else if (response == 2)
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
                    else if (response == 3)
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
        public void getInfoFoliosByID_401(int idFolioHeader)
        {
            try
            {
                DataSet ds = new DataSet();

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@idFolioHeader", idFolioHeader);

                ds = DataAccess.executeStoreProcedureDataSet("spr_PackWedge_GetInfoFoliosByID_401", parameters, "dbConn");

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
        public void getInfoFolio_401(String folio)
        {
            try
            {
                DataSet ds = new DataSet();

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@vFolio", folio);

                ds = DataAccess.executeStoreProcedureDataSet("spr_PackWedge_GetInfoFolio_401", parameters, "dbConn");

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
        public void pingToWS_401()
        {
            Context.Response.Write("1");
        }

        [WebMethod]
        public void getFolios_401(int idPlant, String folio, String dateIni, String dateFin, int idFolioHeader)
        {
            try
            {
                DataSet ds = new DataSet();
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                if (idPlant > 0)
                {
                    parameters.Add("@idPlant", idPlant);
                }

                if (!String.IsNullOrEmpty(folio))
                {
                    parameters.Add("@folio", folio);
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

                ds = DataAccess.executeStoreProcedureDataSet("spr_PackWedge_GetFolios_401", parameters, "dbConn");

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
        public void getPlants_401()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                DataTable dtPlants = new DataTable();

                dtPlants = DataAccess.executeStoreProcedureDataTable("spr_PackWedge_GetPlants_401", parameters, "dbConn");
                Context.Response.Write(JsonConvert.SerializeObject(dtPlants, Formatting.Indented));
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
        public void Login_401(String user, String password)
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
                    dt = DataAccess.executeStoreProcedureDataTable("spr_PackWedge_Login_401", parameters, "dbConn");
                }
                else
                {
                    parameters.Add("@activeDirectory", 0);
                    dt = DataAccess.executeStoreProcedureDataTable("spr_PackWedge_Login_401", parameters, "dbConn");
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
