using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Kluster
/// </summary>
public class Kluster
{
    List<Points> points = new List<Points>();
    Points mean;
    int customerId;
    double Zfatura;
    double Ztotal;
    public Kluster()
    {

    }
    public Kluster(int a, double f, double t)
    {
        customerId = a;
        Zfatura = f;
        Ztotal = t;


    }
    public void setMean(Points p)
    {
        mean = p;
    }
    public Points getMean()
    {
        return mean;
    }
    public void setPoints(Points p)
    {
        points.Add(p);
    }
    public List<Points> getPointos()
    {
        return points;
    }
    public int getPoints()
    {
        return points.Count;
    }
    public int meanHesapla()
    {
        List<double> attr = new List<double>();

        int counter = 0;
        foreach (Points p in points)
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
            attr[a] = attr[a] / points.Count;
            attr[a] = Math.Round(attr[a], 6);
        }

        Points mean = new Points();
        mean.setAttribute(attr);
        this.setMean(mean);
        return counter;
    }
    public void clearPoints()
    {
        points = new List<Points>();
    }
}