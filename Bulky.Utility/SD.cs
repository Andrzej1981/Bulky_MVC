using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Utility
{
    public class SD
    {
        public const string Role_Customer = "Customer";
        public const string Role_Company = "Company";
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Employee";

        public const string StatusPending = "Pending";
        public const string StatusApproved = "Approved";
        public const string StatusInProcess = "Processing";
        public const string StatusShipped = "Shipped";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";

        public const string PaymantStatusPending = "Pending";
        public const string PaymantStatusApproved = "Approved";
        public const string PaymantStatusDelayedPayment = "ApprovedForDelayedPayment";
        public const string PaymantStatusRejected = "Rejected";

        public const string SessionCart = "SessionShoppingCart";

    }
}
