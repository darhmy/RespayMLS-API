using Microsoft.EntityFrameworkCore;
using RespayMLS.Core.Interface;
using RespayMLS.Core.Models;
using RespayMLS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Domain.Repository
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly RespayMLSDbContext _respayMLSDbContext;

        public PaymentMethodRepository(RespayMLSDbContext respayMLSDbContext)
        {
            _respayMLSDbContext = respayMLSDbContext;
        }
        public PaymentMethod AddPaymentMethod(PaymentMethod paymentMethod)
        {
            _respayMLSDbContext.PaymentMethods.Add(paymentMethod);

            _respayMLSDbContext.SaveChanges();

            return paymentMethod;
        }

        public void Delete(int Id)
        {
            var getPaymentMethod = _respayMLSDbContext.PaymentMethods.Find(Id);

            _respayMLSDbContext.PaymentMethods.Remove(getPaymentMethod);

            _respayMLSDbContext.SaveChanges();
        }

        public ICollection<PaymentMethod> GetAllPaymentMethods()
        {
            return _respayMLSDbContext.PaymentMethods.ToList();
        }

        public PaymentMethod GetPaymentMethod(int Id)
        {
            var getPaymentMethod = _respayMLSDbContext.PaymentMethods.Find(Id);

            return getPaymentMethod;
        }

        public PaymentMethod UpdatePaymentMethod(PaymentMethod paymentMethod)
        {
            _respayMLSDbContext.Entry(paymentMethod).State = EntityState.Modified;

            _respayMLSDbContext.SaveChanges();

            return paymentMethod;
        }
    }
}
