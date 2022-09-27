using RespayMLS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.Interface
{
    public interface IPaymentMethodRepository
    {
        PaymentMethod GetPaymentMethod(int Id);

        ICollection<PaymentMethod> GetAllPaymentMethods();

        PaymentMethod AddPaymentMethod(PaymentMethod paymentMethod);

        PaymentMethod UpdatePaymentMethod(PaymentMethod paymentMethod);

        void Delete(int Id);
    }
}
