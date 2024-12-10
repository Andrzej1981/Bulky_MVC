using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Utility
{
    public class SD
    {
        public const string Role_Customer = "Klient";
        public const string Role_Company = "Firma";
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Pracownik";

        public const string StatusPending = "Oczekuje";
        public const string StatusApproved = "Zatwierdzone";
        public const string StatusInProcess = "Przetwarzane";
        public const string StatusShipped = "Wysłane";
        public const string StatusCancelled = "Anulowane";
        public const string StatusRefunded = "Zwrócone";

        public const string PaymantStatusPending = "Oczekujące";
        public const string PaymantStatusApproved = "Zatwierdzone";
        public const string PaymantStatusDelayedPayment = "Zatwierdzone-Opóźniona-Płatność";
        public const string PaymantStatusRejected = "Odrzucone";

        public const string SessionCart = "SessionShoppingCart";

    }
}
