using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DataModel;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }
        public ServiceResponse GetOrders()
        {
            ServiceResponse ObjSR = new ServiceResponse();
            try
            {
                Transaction ObjTrans = new Transaction();
                ObjSR = ObjTrans.GetOrders();
                ObjTrans = null;
            }
            catch (Exception ex)
            {
                //Transaction.WriteLog(ex.ToString());
                ObjSR.Response = null;
                ObjSR.StatusCode = "401";
                ObjSR.Message = "Error occurred while processing your request.";
                //Transaction.WriteLog("M :" + System.Reflection.MethodBase.GetCurrentMethod() + ";Exception :" + ex.Message.ToString());

            }
            finally
            {
                string sLog = JsonConvert.SerializeObject(ObjSR);
                //Transaction.WriteLog("GetOrders:" + sLog);
            }

            return ObjSR;
        }



    }
}