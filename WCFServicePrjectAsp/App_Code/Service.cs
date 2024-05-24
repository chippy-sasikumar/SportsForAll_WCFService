using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
	connectionclass ob = new connectionclass();
	public int BalanceCheck(int accno, int uid)
    {
		string str = "select AccBalance from tbAccount where AccNumber=" + accno + " and UserId=" + uid + "";
		SqlDataReader dr = ob.fnReader(str);
		int accbal = 0;
		
        while (dr.Read())
        {
			accbal = Convert.ToInt32(dr["AccBalance"].ToString());
        }
		return accbal;
    }
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}
}
