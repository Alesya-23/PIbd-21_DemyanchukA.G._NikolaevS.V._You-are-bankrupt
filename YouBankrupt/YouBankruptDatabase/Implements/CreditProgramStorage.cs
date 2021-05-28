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
                .Include(rec => rec.Supplier)
                .Include(rec => rec.Transaction)
                .Include(rec => rec.CreditProgramCurrences)
                .ThenInclude(rec => rec.Currence)
                .ToList()
                .Select(rec => new CreditProgramViewModel
                {
                    Id = (int)rec.Id,
                    SupplierId = (int)rec.SupplierId,
                    CreditProgramName = rec.CreditProgramName,
                    Persent = rec.Persent,
                    PaymentTerm = rec.PaymentTerm,
                    TranzactionId = rec.TranzactionId,
                    Currenses = rec.CreditProgramCurrences
                .ToDictionary(recPC => recPC.CurrenceId, recPC =>
               (recPC.Currence?.CurrenceName))
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
               .Include(rec => rec.Supplier)
                .Include(rec => rec.Transaction)
               .Include(rec => rec.CreditProgramCurrences)
               .ThenInclude(rec => rec.Currence)
               .Where(rec => rec.SupplierId == model.SupplierId)
               .ToList()
               .Select(rec => new CreditProgramViewModel
               {
                   Id = (int)rec.Id,
                   SupplierId = (int)rec.SupplierId,
                   CreditProgramName = rec.CreditProgramName,
                   Persent = rec.Persent,
                   PaymentTerm = rec.PaymentTerm,
                   TranzactionId = rec.TranzactionId,
                   Currenses = rec.CreditProgramCurrences
                .ToDictionary(recPC => recPC.CurrenceId, recPC =>
               (recPC.Currence?.CurrenceName))
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
               .Include(rec => rec.Supplier)
                .Include(rec => rec.Transaction)
               .Include(rec => rec.CreditProgramCurrences)
               .ThenInclude(rec => rec.Currence)
               .FirstOrDefault(rec => rec.CreditProgramName == model.CreditProgramName || rec.Id
               == model.Id);
                return credit != null ?
                new CreditProgramViewModel
                {
                    Id = (int)credit.Id,
                    SupplierId = (int)credit.SupplierId,
                    CreditProgramName = credit.CreditProgramName,
                    Persent = credit.Persent,
                    PaymentTerm = credit.PaymentTerm,
                    TranzactionId = credit.TranzactionId,
                    Currenses = credit.CreditProgramCurrences
                .ToDictionary(recPC => recPC.CurrenceId, recPC =>
               (recPC.Currence?.CurrenceName))
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
                        CreateModel(model, new CreditProgram(), context);
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
            creditProgram.SupplierId = model.SupplierId;
            creditProgram.TranzactionId = model.TranzactionId;
            creditProgram.Persent = model.Persent;
            creditProgram.PaymentTerm = model.PaymentTerm;
            if (creditProgram.Id == null)
            {
                context.CreditPrograms.Add(creditProgram);
                context.SaveChanges();
            }
            if (model.Id.HasValue)
            {
                var CreditProgramCurrence = context.CreditProgramCurrences.Where(rec => rec.CreditProgramId == model.Id.Value).ToList();
                context.CreditProgramCurrences.RemoveRange(CreditProgramCurrence.Where(rec =>
                !model.Currenses.ContainsKey(rec.CurrenceId)).ToList());

                foreach (var updateCurrence in CreditProgramCurrence)
                {
                    model.Currenses.Remove(updateCurrence.CurrenceId);
                }

                context.SaveChanges();

            }
            // добавили новые
            foreach (var pp in model.Currenses)
            {
                context.CreditProgramCurrences.Add(new CreditProgramCurrence
                {
                    CreditProgramId = (int)creditProgram.Id,
                    CurrenceId = pp.Key,

                });
                context.SaveChanges();
            }
            return creditProgram;
        }
    }
}
