using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

/// <summary>
/// Summary description for DaBase
/// </summary>
public class DaBase
{
    int numberOfAttribute;
    List<string> atributes = new List<string>(); // hangi attributeları alacaksa bu diziyi kullannacağız;
    List<Points> noktalar = new List<Points>();
    

    List<Kluster> kluster = new List<Kluster>();// kluster sayısı belirsiz
    List<Points> enUzakNoktalar = new List<Points>();
    List<Points> enUzakNoktalar2 = new List<Points>();
    // enUzaknoktaların sayısı belli değil ilk klusterler oluştururken kullanılacack 
    SqlConnection conn;
    SqlDataAdapter adp;
    SqlCommand cmd = new SqlCommand();
    DataTable dt = new DataTable();
    Points meanPoint = new Points();
    double max = 0;
    List<string> filters = new List<string>(); // filtreler listesi 
    string query;

    double Realmax = 0;
    double Realmax2 = 0;

    public void setQuery(string s)
    {
        query = s;
    }

    public string getQuery()
    {
        return query;
    }

    public void setKlusterNumber(int a) // kaç tane kluster isteniliyorsa o kadar kluster oluşturuluyor ve en uzak nokta oluşturulur
    {
        for (int b = 0; b < a; b++)
        {
            kluster.Add(new Kluster());
            enUzakNoktalar.Add(new Points());

        }

    }
    public List<Points> noktas()
    {
        return noktalar;
    }
    public List<Points> gosterkluster()
    {
        return kluster[1].getPointos();
    }
    public DaBase(string s)
    {

        conn = new SqlConnection(s);
    }
    public void atriAtama(List<string> s) // atributeları bu metodla atıyoruz
    {
        foreach (string sa in s)
        {
            atributes.Add(sa);
        }

    }
    public void filterAtama(string s)// filtreler teker teker filters listesine ekleniyor
    {
        filters.Add(s);
    }
    public void DataTableOlusturma(List<double> list) // rowları çekme istenilen attributelarla
    {

        int counter = 0;
        string atribute = " "; // burada attributeları bunun içine atıp select sorgusunda kullanacağız
        foreach (string at in atributes)
        {
            if (counter == 0)
            {
                atribute += list[counter].ToString()+"*"+at+" AS "+at;
            }
            else
            {
                atribute += ", " + list[counter].ToString() + "*" + at+ " AS " + at;
            }
            counter++;

        }

        string filtera = "";
        for (int a = 0; a < filters.Count; a++)
        {
            if (a == 0) filtera = filters[a];
            else
            {
                filtera += " and " + filters[a];
            }
        }

        numberOfAttribute = counter;
        conn.Open(); string s;
        if (filters.Count() == 0)
        {
            s = filtera;
        }
        else
        {
            s = "where " + filtera;
        }
        cmd.CommandText = "select customerId ," + atribute + " from Customers " + s;
        setQuery(s);
        adp = new SqlDataAdapter(cmd.CommandText, conn);

        adp.Fill(dt);

        NoktalarOlusturma();
        conn.Close();
    }


    public void NoktalarOlusturma()
    {
        foreach (DataRow dr in dt.Rows)
        {
            Points p = new Points();
            p.setCustomerId(Convert.ToInt16(dr["CustomerId"]));
            foreach (string s in atributes)
            {
                p.setAttribute(Convert.ToDouble(dr[s]));

            }
            noktalar.Add(p);
        }
        EnuzakNoktaBul2();// noktalar oluşturduktan sonra en uzak noktaları oluşturuyorum
    }



   /* public void setKluster()
    {
        int a = noktalar.Count / kluster.Count;
        int counter = 0;
        int countera = 1;
        for (int b = 0; b < noktalar.Count; b++)
        {
            if (counter != kluster.Count - 1)
            {
                if (countera == a)
                {
                    counter++;
                    countera = 0;
                }
                kluster[counter].setPoints(noktalar[b]);
            }

            else kluster[counter].setPoints(noktalar[b]);
            countera++;
        }
    }*/


    public void meanBulma()
    {

        List<double> attr = new List<double>();

        int counter = 0;
        foreach (Points p in noktalar)
        {
            for (int a = 0; a < p.getAttributes().Count; a++)
            {
                if (counter == 0) attr.Add(p.getAttributes().ElementAt(a));
                else attr[a] += p.getAttributes().ElementAt(a);
            }
            counter++;
        }
        for (int a = 0; a < attr.Count; a++)
        {
            attr[a] = attr[a] / noktalar.Count;
            attr[a] = Math.Round(attr[a], 6);
        }

        Points mean = new Points();
        mean.setAttribute(attr);
        this.setMeanPoint(mean);
    }
    public void setMeanPoint(Points p)
    {
        this.meanPoint = p;
    }

    public List<Points> Maxsorgula(List<Points> max, Points p)
    {
        List<int> say = new List<int>();

        for (int a = 0; a < max.Count; a++)
        {
            if (UzaklikBul(getMeanPoint(), p) > UzaklikBul(getMeanPoint(), max[a]))
            {
                say.Add(a);
            }
        }
        if (say.Count == 0) return max;
        else
        {
            double min = 0;

            int counter = 0;
            for (int a = 0; a < say.Count; a++)
            {
                if (a == 0) min = UzaklikBul(getMeanPoint(), max[say[a]]);
                else if (min > UzaklikBul(getMeanPoint(), max[say[a]]))
                {
                    min = UzaklikBul(getMeanPoint(), max[say[a]]);
                    counter = a;
                }
            }
            max[say[counter]] = p;
        }

        return max;
    }
    public Points getMeanPoint()
    {
        return meanPoint;
    }
    public void enuzakBUlma4()
    {
        meanBulma();
        List<Points> max = new List<Points>();

        List<Points> min = new List<Points>();

        for (int a = 0; a < enUzakNoktalar.Count; a++)
        {
            max.Add(noktalar[a]);

        }
        for (int a = max.Count; a < noktalar.Count; a++)

            max = Maxsorgula(max, noktalar[a]);


        for (int a = 0; a < enUzakNoktalar.Count; a++)
        {
            enUzakNoktalar[a] = max[a];
        }
        for (int a = 0; a < enUzakNoktalar.Count; a++)
            kluster[a].setMean(enUzakNoktalar[a]);

    }
 

    public void EnuzakNoktaBul2() //burada nekadar kluster varsa o kadar en uzak nokta oluşturuyor
    {
        List<Points> enUzaklar = enUzakNoktalar;
        int counter = 0;
        for (int a = 0; a < noktalar.Count; a++)
        {
            enUzaklar[0] = noktalar[a];
            enUzaklar = EnuzakNoktaBul3(counter, enUzaklar);


            if (getMax() > getRealMax())
            {
                SetRealMax(getMax());

                for (int c = 0; c < enUzaklar.Count; c++)
                    enUzakNoktalar[c] = enUzaklar[c];
            }
           
            SetMax(0);
        }
        for (int a = 0; a < enUzakNoktalar.Count; a++) // burada enuzak noktaları klusterın meane eşitliyorum
        {
            kluster[a].setMean(enUzakNoktalar[a]);
        }
    }

    
 
    public List<Points> EnuzakNoktaBul3(int counter, List<Points> enUzaklar)
    {
        List<Points> ekleme = new List<Points>();
        List<Points> sahteNoktalar = new List<Points>();
        for (int a = 0; a < noktalar.Count; a++)
            sahteNoktalar.Add(noktalar[a]);
        double max = 0;
        double min = 0;
        double ort = 0;

        double[] maxa = new double[enUzaklar.Count - 1];
        double maxi = 0;

        double d = 0;
        bool c = false;
        for (int b = 0; b < sahteNoktalar.Count; b++)
        {
            for (int a = 0; a < enUzaklar.Count - 1; a++)
            {
                if (maxa[a] == 0)
                {
                    maxa[a] = UzaklikBul(enUzaklar[counter], sahteNoktalar.ElementAt(b));
                    enUzaklar[a + 1] = sahteNoktalar[b];
                    sahteNoktalar[b] = new Points();
                    break;

                }
                else if (maxa[a] < UzaklikBul(enUzaklar[counter], sahteNoktalar.ElementAt(b)))
                {
                    maxa[a] = UzaklikBul(enUzaklar[counter], sahteNoktalar.ElementAt(b));
                    enUzaklar[a + 1] = sahteNoktalar[b];
                    sahteNoktalar[b] = new Points();
                    break;
                }

            }

        }
    
        for (int a = 0; a < enUzaklar.Count - 1; a++)
        {
            for (int b = a + 1; b < enUzaklar.Count; b++)
            {
                d += UzaklikBul(enUzaklar[a], enUzaklar[b]);
            }
        }



        SetMax(d);
        return enUzaklar;
    }
    
    public void SetMax(double d)
    {
        this.max = d;
    }
    public double getMax()
    {
        return this.max;
    }
    public void SetRealMax(double d)
    {
        this.Realmax = d;
    }
    public double getRealMax()
    {
        return this.Realmax;
    }
    public void SetRealMax2(double d)
    {
        this.Realmax2 = d;
    }
    public double getRealMax2()
    {
        return this.Realmax2;
    }
    public double UzaklikBul(Points p, Points p1)
    {
        List<double> po = p.getAttributes();
        List<double> po1 = p1.getAttributes();
        double uzaklik = 0;

        for (int a = 0; a < numberOfAttribute; a++)
        {
            uzaklik += Math.Pow((po.ElementAt(a) - po1.ElementAt(a)), 2);
        }
        return uzaklik;
    }
   /* public void setAtamaKluster()
    {
        for (int a = 0; a < enUzakNoktalar.Count; a++) // burada enuzak noktaları klusterın meane eşitliyorum
        {
            kluster[a].setMean(enUzakNoktalar[a]);
        }
        foreach (Points p in noktalar)
        {
            bulKluser(p);
        }
        meanHes();

    }
    */

    public void bulKluser(Points p)
    {

        int d = 0;
        double min = 0;
        for (int a = 0; a < kluster.Count; a++)
        {
            if (a == 0) min = UzaklikBul(p, kluster[a].getMean());
            else if (min > UzaklikBul(p, kluster[a].getMean()))
            {
                min = UzaklikBul(p, kluster[a].getMean());
                d = a;
            }


        }
        p.setklusterID(d);
        kluster[d].setPoints(p);

    }


    public void updataKLuster()
    {
        conn.Open();
        foreach (Points p in noktalar)
        {
            cmd = new SqlCommand("update customers set clusterID=" + (p.getKlusterID() + 1).ToString() + " where CustomerId=" + p.getCustomerID().ToString(), conn);
            cmd.ExecuteNonQuery();

        }
        conn.Close();
    }
    public void setAtamaKluster2()
    {

        for (int a = 0; a < kluster.Count; a++)
            kluster[a].clearPoints();

        foreach (Points p in noktalar)
        {
            bulKluser(p);

        }


    }
    public void meanHes()
    {
        for (int a = 0; a < kluster.Count; a++)
        {
            kluster[a].meanHesapla();
        }
    }
    public int meanHes(int a)
    {
        return kluster[a].meanHesapla();

    }
    public int getKluster(int a)
    {
        return kluster[a].getPoints();
    }
 
    public Points getKlusterMean(int a)
    {
        return kluster[a].getMean();
    }
   
}
