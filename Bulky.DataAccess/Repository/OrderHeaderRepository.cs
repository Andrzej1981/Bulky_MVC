using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using BulkyWeb.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderHeaderRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
     
        public void Update(OrderHeader obj)
        {
            _db.OrderHeaders.Update(obj); 
        }

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            var orderfromDb = _db.OrderHeaders.FirstOrDefault(x => x.Id == id);
            if (orderfromDb != null) 
            {
                orderfromDb.OrderStatus = orderStatus;
                if(!string.IsNullOrEmpty(paymentStatus))
                {
                    orderfromDb.PaymentStatus = paymentStatus;
                }
            }

        }

        public void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId)
        {
            var orderfromDb = _db.OrderHeaders.FirstOrDefault(x => x.Id == id);
            if (!string.IsNullOrEmpty(sessionId))
            {
                orderfromDb.SessionId = sessionId;
            }

            if (!string.IsNullOrEmpty(paymentIntentId))
            {
                orderfromDb.PaymentIntentId = paymentIntentId;
                orderfromDb.PaymentDate = DateTime.Now;
            }
        }
    }
}
