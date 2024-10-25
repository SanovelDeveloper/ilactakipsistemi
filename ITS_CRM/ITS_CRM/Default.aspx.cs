using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Net;
using System.Net.Mail;
using System.DirectoryServices;

namespace ITS_CRM
{
  public partial class _Default : System.Web.UI.Page
  {
    public string sConnectionString = ConfigurationManager.ConnectionStrings["ITS_CRMConnectionString"].ConnectionString;
    public DataSet dsEczaneKayitlari;
    public DataSet dsIlacListesi;
  
    private void EczaneKayitlariniYenile()
    {
      SqlConnection conMain = new SqlConnection(sConnectionString);
      conMain.Open();
      try
      {
        SqlCommand scmData = new SqlCommand();
        scmData.Connection = conMain;
        scmData.CommandText = "Customer_Ticket_Browse;1";
        scmData.CommandType = CommandType.StoredProcedure;
        scmData.Parameters.Add(new SqlParameter("@top", ddlKayitAdedi.SelectedValue));

        SqlDataAdapter sdaData = new SqlDataAdapter(scmData);
        dsEczaneKayitlari = new DataSet();
        sdaData.Fill(dsEczaneKayitlari);
      }
      finally
      {
        conMain.Close();
      }          
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
      EczaneKayitlariniYenile();
      divUyari.InnerHtml = "";
    }

    protected void btnKaydet_Click(object sender, EventArgs e)
    {
      if (edtEczaneAdi.Text == "") 
      {
        divUyari.InnerHtml = "<script>alert('Eczane adı girmek zorundasınız!');</script>";
        return;
      }
      
      if (hidSDSId.Value == "0")
      {
        divUyari.InnerHtml = "<script>alert('Eczane bilgilerini listeden seçerek giriniz!');</script>";
        return;
      }
      
      SqlConnection conMain = new SqlConnection(sConnectionString);
      conMain.Open();
      try
      {
        SqlCommand scmData = new SqlCommand();
        scmData.Connection = conMain;
        scmData.CommandText = "Customer_Ticket_Insert;1";
        scmData.CommandType = CommandType.StoredProcedure;       
        scmData.Parameters.Add(new SqlParameter("@tck_customer_name", edtEczaneAdi.Text));
        scmData.Parameters.Add(new SqlParameter("@tck_pharmacist_name", edtEczaciAdiSoyadi.Text));        
        scmData.Parameters.Add(new SqlParameter("@tck_province", edtIlce.Text));
        scmData.Parameters.Add(new SqlParameter("@tck_city", edtIl.Text));
        scmData.Parameters.Add(new SqlParameter("@tck_phone_1", edtTelefonNumarasi1.Text));
        scmData.Parameters.Add(new SqlParameter("@tck_phone_2", edtTelefonNumarasi2.Text));
        scmData.Parameters.Add(new SqlParameter("@tck_customer_email_address", edtEPostaAdresi.Text));
        scmData.Parameters.Add(new SqlParameter("@tck_user_email_address", Request.ServerVariables["AUTH_USER"].ToString()));
        scmData.Parameters.Add(new SqlParameter("@tck_brick", edtBrick.Text));        
        scmData.Parameters.Add(new SqlParameter("@tck_sds_id", Convert.ToInt32(hidSDSId.Value)));        
        scmData.ExecuteNonQuery();

        edtEczaneAdi.Text = "";
        edtEczaciAdiSoyadi.Text = "";
        edtIlce.Text = "";
        edtIl.Text = "";
        edtTelefonNumarasi1.Text = "";
        edtTelefonNumarasi2.Text = "";
        edtEPostaAdresi.Text = "";
        edtAdresi.Text = "";
        
        EczaneKayitlariniYenile();                
      }
      finally
      {
        conMain.Close();
      }      
    }

    protected void btnNotKaydet_Click(object sender, EventArgs e)
    {
      SqlConnection conMain = new SqlConnection(sConnectionString);
      conMain.Open();
      try
      {
        SqlCommand scmData = new SqlCommand();
        scmData.Connection = conMain;
        scmData.CommandText = "Customer_Ticket_Notes_Update;1";
        scmData.CommandType = CommandType.StoredProcedure;
        scmData.Parameters.Add(new SqlParameter("@tck_id", Convert.ToInt32(hidTckId.Value)));
        scmData.Parameters.Add(new SqlParameter("@tck_notes", edtNot.Text));
        scmData.ExecuteNonQuery();

        edtNot.Text = "";
      }
      finally
      {
        conMain.Close();
      }            
    }

    protected void btnMailGonder_Click(object sender, EventArgs e)
    {
      try
      {        
        if ((ddlEPostaAdresi.SelectedIndex == 0 && edtMailEpostaAdresi.Text == "") || edtMail.Text == "") return;
        
        string sUser = Request.ServerVariables["AUTH_USER"].ToString();
        sUser = sUser.Split('\\')[1];

        DirectorySearcher search = new DirectorySearcher();
        search.Filter = String.Format("(SAMAccountName={0})", sUser);
        search.PropertiesToLoad.Add("cn");
        SearchResult result = search.FindOne();   
        string sUserName = result.Properties["cn"][0].ToString();       
        
        MailMessage msgMail = new MailMessage();
        if (edtMailEpostaAdresi.Text == "")
          msgMail.To.Add(new MailAddress(ddlEPostaAdresi.SelectedItem.Value.ToString(), ddlEPostaAdresi.SelectedItem.ToString()));
        else          
          msgMail.To.Add(new MailAddress(edtMailEpostaAdresi.Text, ddlEPostaAdresi.SelectedItem.ToString()));
        for (int i = 0; i < cblMailBilgiler.Items.Count; i++)
          if (cblMailBilgiler.Items[i].Selected)
            msgMail.CC.Add(new MailAddress(cblMailBilgiler.Items[i].Value, cblMailBilgiler.Items[i].Text));        
        msgMail.From = new MailAddress(sUser + "@sanovel.com.tr", sUserName);
        msgMail.Subject = edtMailBaslik.Text;
        msgMail.Priority = MailPriority.High;
        msgMail.IsBodyHtml = false;
        msgMail.Body = edtMail.Text;  
        SmtpClient Mail = new SmtpClient("mail.sanovel.com.tr", 587);
        Mail.Credentials = new NetworkCredential("destek@sanovel.com.tr", "dst4545");
        Mail.Send(msgMail);
      }
      catch (Exception ex)
      {
        divUyari.InnerHtml = "<script>alert('" + ex.Message.Replace(Environment.NewLine, "") + "');</script>"; 
        return;
      }     
      divUyari.InnerHtml = "<script>alert('Mail gönderildi.');</script>";       
      
      try
      {
        SqlConnection conMain = new SqlConnection(sConnectionString);
        conMain.Open();
        try
        {
          SqlCommand scmData = new SqlCommand();
          scmData.Connection = conMain;
          scmData.CommandText = "Sended_Email_Log_Insert;1";
          scmData.CommandType = CommandType.StoredProcedure;
          scmData.Parameters.Add(new SqlParameter("@tma_tck_id", Convert.ToInt32(hidTckId.Value)));
          if (edtMailEpostaAdresi.Text == "")
            scmData.Parameters.Add(new SqlParameter("@tma_email_address", ddlEPostaAdresi.SelectedItem.Value.ToString()));
          else
            scmData.Parameters.Add(new SqlParameter("@tma_email_address", edtMailEpostaAdresi.Text));          
          scmData.ExecuteNonQuery();
        }
        finally
        {
          conMain.Close();
        }           
      }
      catch (Exception ex)
      {
        divUyari.InnerHtml = "<script>alert('" + ex.Message.Replace(Environment.NewLine, "") + "');</script>";
        return;
      }     
      
      edtMailEpostaAdresi.Text = "";
      edtMail.Text = "";
      edtMailBaslik.Text = "";
    }
  }
}
