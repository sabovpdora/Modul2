using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Labka.Models;

namespace Labka.Models
{
    public class Singleton : ApiController
    {
        public HistoryDatabase1Entities db;
        private Singleton()
        {
            this.db = new HistoryDatabase1Entities();
        }
        private static Singleton _instance;
        public static Singleton GetInstance()
        {
            if (_instance == null)
                _instance = new Singleton();
            return _instance;
        }
        public List<Message_history> GetHistory()
        {
            return this.db.Message_history.ToList();
        }
        public List<Message_history> PostMessange(Message_history message)
        {
            this.db.Message_history.Add(message);
            this.db.SaveChanges();
            return this.db.Message_history.ToList();
        }
        public void DeleteHistory()
        {
            foreach (Message_history mh in db.Message_history)
            {
                db.Message_history.Remove(mh);
            }
            db.SaveChanges();
        }
    }
}
