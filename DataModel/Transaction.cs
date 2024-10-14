using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Appcode;
using WebApplication1.Models;


namespace WebApplication1.DataModel
{
    public class Transaction
    {
        public DBConnection TrnDBConn;
        private readonly IConfiguration _configuration;

        public ServiceResponse GetOrders()
        {
            ServiceResponse objRes = new ServiceResponse();
            List<Customer> LstOrg = new List<Customer>();
            string Query;
            try
            {
                TrnDBConn = new DBConnection();
                TrnDBConn.OpenConnection();
                DataTable dt = new DataTable();

                Query = @"SELECT * FROM Customers WHERE CustomerId = CustomerId AND Email = Email";

                //dt = TrnDBConn.ExecuteDataSet(Query, CommandType.Text).Tables[0];
                Customer ObjOrd = new Customer();
                for (int loop = 0; loop < dt.Rows.Count; loop++)
                {
                    
                    ObjOrd.CustomerId = Convert.ToString(dt.Rows[loop]["CustomerId"]);   

                    LstOrg.Add(ObjOrd);
                }
                if (ObjOrd.CustomerId == null)
                {
                    return BadRequest("Customer not found or email does not match.");
                }
                Query = @"SELECT oi.Quantity, oi.Price, 
                                       CASE WHEN o.ContainsGift = 1 THEN 'Gift' ELSE p.ProductName END AS Product
                                       FROM OrderItems oi
                                       JOIN Products p ON oi.ProductId = p.ProductId
                                       JOIN Orders o ON o.OrderId = oi.OrderId
                                       WHERE oi.OrderId = OrderId";
                //dt = TrnDBConn.ExecuteDataSet(Query, CommandType.Text).Tables[0];
                if (LstOrg.Count > 0)
                {
                    objRes.Response = LstOrg;
                    //objRes.Response = LstOrg;
                    objRes.StatusCode = "200";
                    objRes.Message = "Sucess";

                }
                else
                {
                    objRes.Response = null;
                    objRes.StatusCode = "401";
                    objRes.Message = "No Records Found";
                }
            }
            catch (Exception ex)
            {
                objRes.Response = null;
                objRes.StatusCode = "401";
                objRes.Message = "Error occurred while processing your request.";
                //CLog.Write("C:" + System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.FullName + "-M:" + System.Reflection.MethodInfo.GetCurrentMethod().Name + "-S:" + ex.Source.ToString() + "-Ms:" + ex.Message.ToString());
            }
            finally
            {
                TrnDBConn.CloseConnection();
                TrnDBConn.Dispose();
            }
            return objRes;
        }

        private ServiceResponse BadRequest(string v)
        {
            throw new NotImplementedException();
        }
    }

}