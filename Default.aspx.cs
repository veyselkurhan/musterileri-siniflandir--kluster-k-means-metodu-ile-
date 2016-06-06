using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    DaBase db;
    protected void Page_Load(object sender, EventArgs e)
    {

        string connectionString = "Data Source=PRO2000-PRO2000\\SQLEXPRESS; Initial Catalog=mis463; Integrated Security=True";
        db = new DaBase(connectionString);



    }
    protected void cluster_Click(object sender, EventArgs e)
    {

        int numberOfClusters = Convert.ToInt16(txtClusters.Text);

        List<string> atributes = new List<string>();
        List<double> weights = new List<double>();


        if (cbFrequency.Checked == true)
        {
            if (DropDownList2.SelectedItem.Text == "2015")
            {
                atributes.Add("ftotal15");
            }
            else
            {
                atributes.Add("Zfatura");
            }
            weights.Add(Convert.ToDouble(txtFrequency.Text));
        }

        if (cbRecency.Checked == true)
        {
            atributes.Add("Zdays");
            weights.Add(Convert.ToDouble(txtRecency.Text));
        }

        if (cbMonetary.Checked == true)
        {
            atributes.Add("Ztotal");
            weights.Add(Convert.ToDouble(txtMonetary.Text));
        }

        if (cbDiscount.Checked == true)
        {
            atributes.Add("Zperc");
            weights.Add(Convert.ToDouble(txtDiscount.Text));

        }
        if (cbAmount.Checked == true)
        {
            atributes.Add("ZamountPerTr");
            weights.Add(Convert.ToDouble(txtAmount.Text));

        }

        if (DropDownList1.SelectedItem.Text == "Turkey")
        {
            db.filterAtama("COUNTRY like '%TÜRKİYE%'");
        }
        else if (DropDownList1.SelectedItem.Text == "Abroad")
        {
            db.filterAtama("COUNTRY not like '%TÜRKİYE%'");
        }
        else if (DropDownList1.SelectedItem.Text == "")
        {
            db.filterAtama("");
        }
      
        if (txtCity.Text != "") db.filterAtama("CITY like '%" + txtCity.Text + "%'");

          
        db.atriAtama(atributes);//şiuanlık bunları atadım;
        db.setKlusterNumber(numberOfClusters);

        db.DataTableOlusturma(weights);

        /*  Points asad = db.getKlusterMean(0);
          foreach (double d in asad.getAttributes())
          {
              Label1.Text += "; " + d.ToString();
          }
          Points asad2 = db.getKlusterMean(1);
          foreach (double d in asad2.getAttributes())
          {
              Label2.Text += "; " + d.ToString();
          }
          Points asad3 = db.getKlusterMean(2);
          foreach (double d in asad3.getAttributes())
          {
              Label3.Text += "; " + d.ToString();
          }
          */
        int iteration = Convert.ToInt16(txtIteration.Text);

        for (int ite = 0; ite < iteration; ite++)
        {
            db.setAtamaKluster2();
            db.meanHes();
        }

        //  Label4.Text = db.getKluster(2).ToString();
        //  Label5.Text = db.getKluster(0).ToString();
        //  Label6.Text = db.getKluster(1).ToString();
        //  Label7.Text = db.getKluster(3).ToString();
        //  Label8.Text = db.getKluster(4).ToString();

        db.updataKLuster();
        Session["query"] = db.getQuery();
        Response.Redirect("Report.aspx");

    }

    protected void cbFrequency_CheckedChanged(object sender, EventArgs e)
    {
        if (cbFrequency.Checked == true)
        {
            txtFrequency.Text = "1";
            txtFrequency.Enabled = true;
        }
        else
        {
            txtFrequency.Text = "";
            txtFrequency.Enabled = false;
        }

    }
    protected void cbRecency_CheckedChanged(object sender, EventArgs e)
    {

        if (cbRecency.Checked == true)
        {
            txtRecency.Text = "1";
            txtRecency.Enabled = true;
        }
        else
        {
            txtRecency.Text = "";
            txtRecency.Enabled = false;
        }

    }
    protected void cbMonetary_CheckedChanged(object sender, EventArgs e)
    {
        if (cbMonetary.Checked == true)
        {
            txtMonetary.Text = "1";
            txtMonetary.Enabled = true;
        }
        else
        {
            txtMonetary.Text = "";
            txtMonetary.Enabled = false;
        }
    }
    protected void cbDiscount_CheckedChanged(object sender, EventArgs e)
    {

        if (cbDiscount.Checked == true)
        {
            txtDiscount.Text = "1";
            txtDiscount.Enabled = true;
        }
        else
        {
            txtDiscount.Text = "";
            txtDiscount.Enabled = false;
        }
    }
    protected void cbAmount_CheckedChanged(object sender, EventArgs e)
    {
        if (cbAmount.Checked == true)
        {
            txtAmount.Text = "1";
            txtAmount.Enabled = true;
        }
        else
        {
            txtAmount.Text = "";
            txtAmount.Enabled = false;
        }
    }

    protected void cbRegion_CheckedChanged(object sender, EventArgs e)
    {
        if (cbRegion.Checked == true)
        {
            DropDownList1.Enabled = true;
        }
        else
        {
            DropDownList1.Enabled = false;
        }
    }
    protected void cbTime_CheckedChanged(object sender, EventArgs e)
    {
        if (cbTime.Checked == true)
        {
            DropDownList2.Enabled = true;
        }
        else
        {
            DropDownList2.Enabled = false;
        }
    }
    protected void cbCity_CheckedChanged(object sender, EventArgs e)
    {
        if (cbCity.Checked == true)
        {
            txtCity.Text = "Ankara";
            txtCity.Enabled = true;
        }
        else
        {
            txtCity.Text = "";
            txtCity.Enabled = false;
        }
    }
}