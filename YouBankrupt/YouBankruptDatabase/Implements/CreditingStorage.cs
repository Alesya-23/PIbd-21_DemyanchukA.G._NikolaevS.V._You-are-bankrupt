using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.Interfaces;
using YouBankruptBusinessLogic.ViewModels;
using YouBankruptDatabaseImplement.Models;
using YouBankruptDatabaseImplements;

namespace YouBankruptDatabaseImplement.Implements
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
                    TransactionWithCustomerId = rec.TransactionWithCustomerId
                })
               .ToList();
            }
        }

        public void Delete(CreditingBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                Crediting element = context.Creditings.FirstOrDefault(rec => rec.Id == model.Id);
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
                var creiting = context.Creditings.FirstOrDefault(rec => rec.Id == model.Id);
                return creiting != null ?
                new CreditingViewModel
                {
                    Id = creiting.Id,
                    Sum = creiting.Sum,
                    TransactionWithCustomerId = creiting.TransactionWithCustomerId
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
               .Select(rec => new CreditingViewModel
               {
                   Id = rec.Id,
                   Sum = rec.Sum,
                   TransactionWithCustomerId = rec.TransactionWithCustomerId
               })
                .ToList();
            }
        }

        public void Insert(CreditingBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                context.Creditings.Add(CreateModel(model, new Crediting()));
                context.SaveChanges();
            }
        }

        public void Update(CreditingBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                var element = context.Creditings.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        private Crediting CreateModel(CreditingBindingModel model, Crediting crediting)
        {
            crediting.Sum = model.Sum;
            crediting.TransactionWithCustomerId = model.TransactionWithCustomerId; 
            return crediting;
        }
    }
}
