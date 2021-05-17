using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.Interfaces;
using YouBankruptBusinessLogic.ViewModels;
using YouBankruptDatabaseImplements.Models;

namespace YouBankruptDatabaseImplements.Implements
{
    public class PurchasesCurrenceStorage : IPurchasesCurrenceStorage
    {
        public List<PurchasesCurrenceViewModel> GetFullList()
        {
            using (var context = new YouBankruptDatabase())
            {
                return context.PurchasesCurrences
                .Include(rec => rec.PurchasesCurrenceCurrences)
               .ThenInclude(rec => rec.Currence)
               .ToList()
               .Select(rec => new PurchasesCurrenceViewModel
               {
                   Id = (int)rec.Id,
                   PurchasesName = rec.PurchasesName,
                   DateBuy = rec.DateBuy,
                   Summ = rec.Summ,
                   Currenses = rec.PurchasesCurrenceCurrences
                .ToDictionary(recPC => recPC.CurrenceId, recPC =>
               (recPC.Currence?.CurrenceName, recPC.Count))
               })
               .ToList();
            }
        }
        public List<PurchasesCurrenceViewModel> GetFilteredList(PurchasesCurrenceBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new YouBankruptDatabase())
            {
                return context.PurchasesCurrences
                .Include(rec => rec.PurchasesCurrenceCurrences)
               .ThenInclude(rec => rec.Currence)
               .Where(rec => rec.PurchasesName.Contains(model.PurchasesName))
               .ToList()
               .Select(rec => new PurchasesCurrenceViewModel
               {
                   Id = (int)rec.Id,
                   PurchasesName = rec.PurchasesName,
                   DateBuy = rec.DateBuy,
                   Summ = rec.Summ,
                   Currenses = rec.PurchasesCurrenceCurrences
                .ToDictionary(recPC => recPC.CurrenceId, recPC =>
               (recPC.Currence?.CurrenceName, recPC.Count))
               })
               .ToList();
            }
        }
        public PurchasesCurrenceViewModel GetElement(PurchasesCurrenceBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new YouBankruptDatabase())
            {
                var purchasesCurrence = context.PurchasesCurrences
                .Include(rec => rec.PurchasesCurrenceCurrences)
               .ThenInclude(rec => rec.Currence)
               .FirstOrDefault(rec => rec.PurchasesName == model.PurchasesName || rec.Id
               == model.Id);
                return purchasesCurrence != null ?
                new PurchasesCurrenceViewModel
                {
                    Id = (int)purchasesCurrence.Id,
                    PurchasesName = purchasesCurrence.PurchasesName,
                    DateBuy = purchasesCurrence.DateBuy,
                    Summ = purchasesCurrence.Summ,
                    Currenses = purchasesCurrence.PurchasesCurrenceCurrences
                .ToDictionary(recPC => recPC.CurrenceId, recPC =>
               (recPC.Currence?.CurrenceName, recPC.Count))
                } :
               null;
            }
        }
        public void Insert(PurchasesCurrenceBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        PurchasesCurrence p = new PurchasesCurrence
                        {
                            PurchasesName = model.PurchasesName,
                            DateBuy = model.DateBuy,
                            Summ = model.Summ,
                        };
                        context.PurchasesCurrences.Add(p);
                        context.SaveChanges();
                        CreateModel(model, p, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Update(PurchasesCurrenceBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.PurchasesCurrences.FirstOrDefault(rec => rec.Id ==
                       model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, element, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(PurchasesCurrenceBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                PurchasesCurrence element = context.PurchasesCurrences.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.PurchasesCurrences.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private PurchasesCurrence CreateModel(PurchasesCurrenceBindingModel model, PurchasesCurrence purchasesCurrence,
       YouBankruptDatabase context)
        {
            purchasesCurrence.PurchasesName = model.PurchasesName;
            purchasesCurrence.DateBuy = model.DateBuy;
            purchasesCurrence.Summ = model.Summ;
            if (model.Id.HasValue)
            {
                var purchasesCurrenceCurrence = context.PurchasesCurrenceCurrences.Where(rec =>
               rec.PurchasesCurrenceId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.PurchasesCurrenceCurrences.RemoveRange(purchasesCurrenceCurrence.Where(rec =>
               !model.Currenses.ContainsKey(rec.CurrenceId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateCurrence in purchasesCurrenceCurrence)
                {
                    updateCurrence.Count = model.Currenses[updateCurrence.CurrenceId].Item2;
                    model.Currenses.Remove(updateCurrence.CurrenceId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var pc in model.Currenses)
            {
                context.PurchasesCurrenceCurrences.Add(new PurchasesCurrenceCurrence
                {
                    PurchasesCurrenceId = (int)purchasesCurrence.Id,
                    CurrenceId = pc.Key,
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            return purchasesCurrence;
        }
    }
}
