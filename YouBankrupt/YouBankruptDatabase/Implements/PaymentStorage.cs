using System;
using System.Collections.Generic;
using System.Linq;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.Interfaces;
using YouBankruptDatabaseImplements.Models;
using YouBankruptDatabaseImplements;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptDatabaseImplement.Implements
{
    public class PaymentStorage : IPaymentStorage
    {
        public void Delete(PaymentBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                Payment element = context.Payments.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Payments.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public PaymentViewModel GetElement(PaymentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new YouBankruptDatabase())
            {
                var payment = context.Payments.FirstOrDefault(rec => rec.Id == model.Id);
                return payment != null ?
                new PaymentViewModel
                {
                    Id = payment.Id,
                    Sum = payment.Sum,
                    DatePayment = payment.DatePayment,
                    CurrenceName = context.Currences.FirstOrDefault(recCurrnece => recCurrnece.Id == payment.CurrenceId).CurrenceName,
                } :
               null;
            }
        }

        public List<PaymentViewModel> GetFilteredList(PaymentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new YouBankruptDatabase())
            {
                return context.Payments
                .Where(rec => rec.CustomerId == model.CustomerId)
                .Select(rec => new PaymentViewModel
                {
                    Id = rec.Id,
                    Sum = rec.Sum,
                    DatePayment = rec.DatePayment,
                    CurrenceName = context.Currences.FirstOrDefault(recCurrnece => recCurrnece.Id == rec.CurrenceId).CurrenceName,
                })
                .ToList();
            }
        }

        public List<PaymentViewModel> GetFullList()
        {
            using (var context = new YouBankruptDatabase())
            {
                return context.Payments
                    .Select(rec => new PaymentViewModel
                    {
                        Id = rec.Id,
                        Sum = rec.Sum,
                        DatePayment = rec.DatePayment,
                        CurrenceName = context.Currences.FirstOrDefault(recCurrnece => recCurrnece.Id == rec.CurrenceId).CurrenceName,
                    })
               .ToList();
            }
        }

        public void Insert(PaymentBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                context.Payments.Add(CreateModel(model, new Payment()));
                context.SaveChanges();
            }
        }

        public void Update(PaymentBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                var element = context.Payments.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        private Payment CreateModel(PaymentBindingModel model, Payment payment)
        {
            payment.Sum = model.Sum;
            payment.DatePayment = model.DatePayment;
            payment.CustomerId = (int)model.CustomerId;
            payment.CurrenceId = model.CurrenceId;
            payment.CreditId = model.CreditId;
            payment.PurchasesCurrenceId = model.PurchasesCurrenceId;
            return payment;
        }
    }
}
