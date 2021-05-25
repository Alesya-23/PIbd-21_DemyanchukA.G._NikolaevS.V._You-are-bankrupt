using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.Interfaces;
using YouBankruptBusinessLogic.ViewModels;
using YouBankruptDatabaseImplements.Models;
using YouBankruptDatabaseImplements;
using Microsoft.EntityFrameworkCore;

namespace YouBankruptDatabaseImplements.Implements
{
    public class CreditingStorage : ICreditingStorage
    {
        public List<CreditingViewModel> GetFullList()
        {
            using (var context = new YouBankruptDatabase())
            {
                return context.Creditings
                .Select(rec => new CreditingViewModel
                {
                    Id = rec.Id,
                    Sum = rec.Sum,
                })
               .ToList();
            }
        }

        public void Delete(CreditingBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                Crediting element = context.Creditings.FirstOrDefault(rec => rec.Id == model.Id && rec.CustomerId == model.CustomerId);
                if (element != null)
                {
                    context.Creditings.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public CreditingViewModel GetElement(CreditingBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new YouBankruptDatabase())
            {
                var creiting = context.Creditings.FirstOrDefault(rec => rec.Id == model.Id && rec.CustomerId == model.CustomerId);
                return creiting != null ?
                new CreditingViewModel
                {
                    Id = creiting.Id,
                    Sum = creiting.Sum,
                    CustomerId = (int)creiting.CustomerId,
                } :
               null;
            }
        }

        public List<CreditingViewModel> GetFilteredList(CreditingBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new YouBankruptDatabase())
            {
                return context.Creditings
                .Where(rec => (rec.CustomerId == model.CustomerId))
                .Select(rec => new CreditingViewModel
                {
                    Id = rec.Id,
                    DateCredit = rec.DateCredit,
                    CustomerId = (int)rec.CustomerId,
                    Sum = rec.Sum,
                    //CreditPayments = rec.Payments.ToDictionary(recP => recP.Id, recDC => recDC.Sum),
                })
                .ToList();
            }
        }

        public void Insert(CreditingBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Creditings.Add(CreateModel(model, new Crediting(), context));
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(CreditingBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var element = context.Creditings.FirstOrDefault(rec => rec.Id == model.Id && rec.CustomerId == model.CustomerId);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    CreateModel(model, element, context);
                    context.SaveChanges();
                    transaction.Commit();
                }
            }
        }

        private Crediting CreateModel(CreditingBindingModel model, Crediting crediting, YouBankruptDatabase context)
        {
            crediting.Sum = model.Sum;
            crediting.DateCredit = model.DateCredit;
            crediting.CustomerId = model.CustomerId;
            if (model.Id.HasValue)
            {

            }
            foreach (var paymant in model.CreditPayments)
            {
                var newPayment = context.Payments.FirstOrDefault(rec => rec.Id == paymant.Key);
                crediting.Payments = new List<Payment>();
                crediting.Payments.Add((Payment)newPayment);
                context.SaveChanges();
            }
            return crediting;
        }
    }
}
