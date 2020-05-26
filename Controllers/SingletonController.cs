using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Labka.Models;

namespace Labka.Controllers
{
    public class SingletonController : ApiController
    {
        public HistoryDatabase1Entities db = new HistoryDatabase1Entities();
        public Singleton Singleton = Singleton.GetInstance();
        public IHttpActionResult Post([FromBody] Message_history message_history)
        {
            try
            {
                return Ok(Singleton.PostMessange(message_history));
            }
            catch (Exception error)
            {
                return InternalServerError(error);
            }
        }
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(Singleton.GetHistory());
            }
            catch (Exception error)
            {
                return InternalServerError(error);
            }
        }
        public void Delete()
        {
            Singleton.DeleteHistory();
        }
    }
}

    

