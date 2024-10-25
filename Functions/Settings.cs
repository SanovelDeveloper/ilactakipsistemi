using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using LINQ;
using System.Diagnostics;

namespace Functions
{
    public class Settings
    {
        private static char Environment;

        public class ServiceAddresses
        {
            public string Production;
            public string Deactivation;
            public string Export;
            public string Sales;
            public string CancelSales;
            public string Confirmation;
            public string PTSSend;
            public string PTSReceive;
            public string PTSTransferHelper;
            public string Token;
            public string SalesPageIndex;


            public ServiceAddresses()
            {
                using (var lITS = new ITSDataContext(Global.ConnectionString) { CommandTimeout = 120000 })
                {
                    Production = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "production_declaration_address").First().set_setting_variable;
                    Deactivation = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "deactivation_declaration_address").First().set_setting_variable;
                    Export = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "export_declaration_address").First().set_setting_variable;
                    Sales = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "sales_declaration_address").First().set_setting_variable;
                    CancelSales = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "cancel_sales_declaration_address").First().set_setting_variable;
                    Confirmation = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "confirmation_address").First().set_setting_variable;
                    PTSSend = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "pts_address").First().set_setting_variable;
                    PTSReceive = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "pts_receiver_address").First().set_setting_variable;
                    PTSTransferHelper = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "pts_transfer_helper_address").First().set_setting_variable;
                    Token = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "token_address").First().set_setting_variable;
                    SalesPageIndex = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "send_sales_pageindex").First().set_setting_variable;
                }
            }
        }

        public class ITSSecurity
        {
            public string SanovelUser;
            public string SanovelPassword;
            public string SanovelGLN;

            public string AsetUser;
            public string AsetPassword;
            public string AsetGLN;

            public string AdilnaUser;
            public string AdilnaPassword;
            public string AdilnaGLN;

            public string ArvenUser;
            public string ArvenPassword;
            public string ArvenGLN;

            public ITSSecurity()
            {
                using (var lITS = new ITSDataContext(Global.ConnectionString) { CommandTimeout = 120000 })
                {
                    SanovelUser = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "sanovel_user").First().set_setting_variable;
                    SanovelPassword = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "sanovel_password").First().set_setting_variable;
                    SanovelGLN = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "sanovel_gln").First().set_setting_variable;

                    AsetUser = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "aset_user").First().set_setting_variable;
                    AsetPassword = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "aset_password").First().set_setting_variable;
                    AsetGLN = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "aset_gln").First().set_setting_variable;

                    AdilnaUser = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "adilna_user").First().set_setting_variable;
                    AdilnaPassword = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "adilna_password").First().set_setting_variable;
                    AdilnaGLN = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "adilna_gln").First().set_setting_variable;

                    ArvenUser = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "arven_user").First().set_setting_variable;
                    ArvenPassword = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "arven_password").First().set_setting_variable;
                    ArvenGLN = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "arven_gln").First().set_setting_variable;
                }
            }
        }

        public class Directories
        {
            public string Incoming;
            public string Outgoing;
            public string Temp;

            public Directories()
            {
                using (var lITS = new ITSDataContext(Global.ConnectionString) { CommandTimeout = 120000 })
                {
                    Incoming = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "incoming_files").First().set_setting_variable;
                    Outgoing = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "outgoing_files").First().set_setting_variable;
                    Temp = lITS.Global_Settings.Where(s => s.set_environment == Environment && s.set_setting_name == "temp_files").First().set_setting_variable;
                }
            }
        }

        public string ProxyAddress;
        public string ProxyPort;
        public int DeclarationCount;

        public ServiceAddresses Services;
        public ITSSecurity Security;
        public Directories Directory;

        private string sFileName = "settings.xml";

        public void ReadSettings()
        {
            XmlTextReader xmlReader = new XmlTextReader(sFileName);

            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    switch (xmlReader.Name)
                    {
                        case "proxy_address":
                            ProxyAddress = xmlReader.ReadString();
                            break;
                        case "proxy_port":
                            ProxyPort = xmlReader.ReadString();
                            break;
                        case "declaration_count":
                            DeclarationCount = Convert.ToInt32(xmlReader.ReadString());
                            break;

                    }
                }
            }
            xmlReader.Close();
        }

        public string GetErrorMessage(string HataKodu)
        {
            string sErrorMessage = "";
            using (var lITS = new ITSDataContext(Global.ConnectionString) { CommandTimeout = 120000 })
            {
                var tErrors = lITS.Global_Error_Lists.Where(e => e.erl_error_code == HataKodu).ToList();
                if (tErrors.Count > 0)
                    sErrorMessage = tErrors.First().erl_error_message;
            }
            return sErrorMessage;
        }

        public void WriteSettings()
        {
            XmlTextWriter xmlWriter = new XmlTextWriter(sFileName, System.Text.UTF8Encoding.UTF8);
            xmlWriter.Formatting = Formatting.Indented;
            try
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("settings");

                xmlWriter.WriteStartElement("proxy");
                xmlWriter.WriteElementString("proxy_address", ProxyAddress);
                xmlWriter.WriteElementString("proxy_port", ProxyPort);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("declaration");
                xmlWriter.WriteElementString("declaration_count", DeclarationCount.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndDocument();

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                xmlWriter.Close();
            }
        }

        public Settings(char AEnvironment)
        {
            Environment = AEnvironment;
            if (AEnvironment == 'T') sFileName = "settings_test.xml";
            else sFileName = "settings.xml";

            string path = Process.GetCurrentProcess().MainModule.FileName;
            path = path.Substring(0, path.LastIndexOf("\\"));
            sFileName = path + @"\" + sFileName;

            Services = new ServiceAddresses();
            Security = new ITSSecurity();
            Directory = new Directories();

            ReadSettings();
        }
    }
}
