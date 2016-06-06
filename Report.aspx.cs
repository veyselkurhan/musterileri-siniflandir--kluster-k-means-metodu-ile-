using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Report : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection("Data Source=PRO2000-PRO2000\\SQLEXPRESS; Initial Catalog=mis463; Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {
        conn.Open();
        Repeater1.DataSource = getdata();
        Repeater1.DataBind();
        conn.Close();
    }

    private DataSet getdata()//userın açtığı başlıkları topla.
    {
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = " select Count(clusterID) AS IDD, clusterID, ROUND(AVG(NetTotal),2) AS avgnettotal, ROUND(AVG(TotalDiscounts),2) AS avgtotaldiscount,  ROUND(AVG(reversedays),2) AS avgDays,  ROUND(AVG(Frequency),2) AS avgFrequency, ROUND(AVG(amountPerTransaction),2) AS avgAmountPerTr from Customers "+Session["query"].ToString()+" GROUP BY clusterID order by clusterID";

        
        SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
        da.Fill(ds);
        return ds;
    }
}