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
    public class CreditProgramStorage : ICreditProgramStorage
    {
        public List<CreditProgramViewModel> GetFullList()
        {
            using (var context = new YouBankruptDatabase())
            {
                return context.CreditPrograms
                .Include(rec => rec.CreditProgramCurrences)
               .ThenInclude(rec => rec.Currence)
               .ToList()
               .Select(rec => new CreditProgramViewModel
               {
                   Id = (int)rec.Id,
                   CreditProgramName = rec.CreditProgramName,
                   Persent = rec.Persent,
                   PaymentTerm = rec.PaymentTerm,
               })
               .ToList();
            }
        }
        public List<CreditProgramViewModel> GetFilteredList(CreditProgramBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new YouBankruptDatabase())
            {
                return context.CreditPrograms
                .Include(rec => rec.CreditProgramCurrences)
               .ThenInclude(rec => rec.Currence)
               .Where(rec => rec.CreditProgramName.Contains(model.CreditProgramName))
               .ToList()
               .Select(rec => new CreditProgramViewModel
               {
                   Id = (int)rec.Id,
                   CreditProgramName = rec.CreditProgramName,
                   Persent = rec.Persent,
                   PaymentTerm = rec.PaymentTerm
               })
               .ToList();
            }
        }
        public CreditProgramViewModel GetElement(CreditProgramBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new YouBankruptDatabase())
            {
                var credit = context.CreditPrograms
                .Include(rec => rec.CreditProgramCurrences)
               .ThenInclude(rec => rec.Currence)
               .FirstOrDefault(rec => rec.CreditProgramName == model.CreditProgramName || rec.Id
               == model.Id);
                return credit != null ?
                new CreditProgramViewModel
                {
                    Id = (int)credit.Id,
                    CreditProgramName = credit.CreditProgramName,
                    Persent = credit.Persent,
                    PaymentTerm = credit.PaymentTerm,
                } :
               null;
            }
        }
        public void Insert(CreditProgramBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreditProgram p = new CreditProgram
                        {
                            CreditProgramName = model.CreditProgramName,
                            Persent = model.Persent,
                            PaymentTerm = model.PaymentTerm
                        };
                        context.CreditPrograms.Add(p);
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
        public void Update(CreditProgramBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.CreditPrograms.FirstOrDefault(rec => rec.Id ==
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
        public void Delete(CreditProgramBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                CreditProgram element = context.CreditPrograms.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.CreditPrograms.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private CreditProgram CreateModel(CreditProgramBindingModel model, CreditProgram creditProgram,
       YouBankruptDatabase context)
        {
            creditProgram.CreditProgramName = model.CreditProgramName;
            creditProgram.Persent = model.Persent;
            creditProgram.PaymentTerm = model.PaymentTerm;
            if (model.Id.HasValue)
            {
                var creditProgramCurrence = context.CreditProgramCurrences.Where(rec =>
               rec.CreditProgramId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.CreditProgramCurrences.RemoveRange(creditProgramCurrence.Where(rec =>
               !model.Currenses.ContainsKey(rec.CurrenceId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateCurrence in creditProgramCurrence)
                {
                    //updateCurrence.Count = model.Currenses[updateCurrence.CurrenceId].Item2;
                    model.Currenses.Remove(updateCurrence.CurrenceId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var pc in model.Currenses)
            {
                context.CreditProgramCurrences.Add(new CreditProgramCurrence
                {
                    CreditProgramId = (int)creditProgram.Id,
                    CurrenceId = pc.Key,
                });
                context.SaveChanges();
            }
            return creditProgram;
        }
    }
}
