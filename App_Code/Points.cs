using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Points
/// </summary>
public class Points
{
    List<double> attr = new List<double>();
    int customerID;
    int klusterId = 0;
    public Points()
    {

        //
        // TODO: Add constructor logic here
        //
    }
    public void setAttribute(double d)
    {
        attr.Add(Math.Round(d, 6));
    }
    public void setklusterID(int a)
    {
        klusterId = a;
    }
    public int getKlusterID()
    {
        return klusterId;
    }
    public void setCustomerId(int customerID)
    {
        this.customerID = customerID;
    }
    public int getCustomerID()
    {
        return customerID;
    }
    public void setAttribute(List<double> a)
    {
        foreach (double d in a)
            attr.Add(d);
    }
    public List<double> getAttributes()
    {
        return attr;
    }

}