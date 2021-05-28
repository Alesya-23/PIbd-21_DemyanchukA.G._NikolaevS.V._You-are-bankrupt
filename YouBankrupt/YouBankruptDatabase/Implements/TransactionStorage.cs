using System;
using System.Collections.Generic;
using System.Linq;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.Interfaces;
using YouBankruptBusinessLogic.ViewModels;
using YouBankruptDatabaseImplements.Models;
using YouBankruptDatabaseImplements;
using Microsoft.EntityFrameworkCore;

namespace YouBankruptDatabaseImplement.Implements
{
    public class TransactionStorage : ITransactionStorage
    {
        public void Delete(TransactionBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                Transaction element = context.Transactions.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Transactions.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public TransactionViewModel GetElement(TransactionBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using(var context = new YouBankruptDatabase())
            {
                var transaction = context.Transactions
                    .Include(rec => rec.Customer)
                    .Include(rec => rec.Crediting)
                    .Include(rec => rec.CreditProgram)
                    .FirstOrDefault(rec => rec.Id == model.Id);
                return transaction != null ?
                    new TransactionViewModel
                    {
                        Id = transaction.Id,
                        CreditingId = transaction.CreditingId,
                        CustomerName = context.Customers.FirstOrDefault(recCustomer => recCustomer.Id == transaction.CustomerId).CustomerFullName,
                       // CreditProgramName = context.CreditPrograms.FirstOrDefault(recCreditProgram => recCreditProgram.Id == model.CreditProgramId).CreditProgramName,
                        DateFrom = transaction.DateFrom,
                        //CreditProgramId = transaction.CreditProgramId
                    } :
                    null;
            }
        }

        public List<TransactionViewModel> GetFilteredList(TransactionBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new YouBankruptDatabase())
            {
                return context.Transactions
                .Include(rec => rec.Customer)
                .Include(rec => rec.CreditProgram)
                .Include(rec => rec.Crediting)
                 .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.CustomerId == model.CustomerId || rec.DateFrom == model.DateFrom) ||
                (model.DateFrom.HasValue && model.DateTo.HasValue && (rec.CustomerId == model.CustomerId
                && rec.DateFrom.Date >= model.DateFrom.Value.Date && rec.DateFrom.Date <= model.DateTo.Value.Date)))
                .ToList()
                .Select(rec => new TransactionViewModel
                {
                    Id = rec.Id,
                    CustomerName = context.Customers.FirstOrDefault(recCustomer => recCustomer.Id == rec.CustomerId).CustomerFullName,
                    CreditingId = rec.CreditingId,
                    CreditProgramName = context.CreditPrograms.FirstOrDefault(recCreditProgram => recCreditProgram.Id == rec.CreditProgramId).CreditProgramName,
                    DateFrom = rec.DateFrom,
                    DateTo = rec.DateTo,
                    CreditProgramId = rec.CreditProgramId
                }).ToList();
            }
        }

        public List<TransactionViewModel> GetFullList()
        {
            using(var context = new YouBankruptDatabase())
            {
                return context.Transactions
                    .Include(rec => rec.Customer)
                    .Include(rec => rec.Crediting)
                    .Include(rec => rec.CreditProgram)
                    .Select(rec => new TransactionViewModel
                    {
                        Id = rec.Id,
                        CustomerName = context.Customers.FirstOrDefault(recCustomer => recCustomer.Id == rec.CustomerId).CustomerFullName,
                        CreditProgramName = context.CreditPrograms.FirstOrDefault(recCreditProgram => recCreditProgram.Id == rec.CreditProgramId).CreditProgramName,
                        CreditingId = rec.CreditingId,
                        DateFrom = rec.DateFrom,
                        DateTo = rec.DateTo,
                        CreditProgramId = rec.CreditProgramId
            })
                .ToList();
            }
        }

        public void Insert(TransactionBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Transactions.Add(CreateModel(model, new Transaction()));
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

        public void Update(TransactionBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Transactions.FirstOrDefault(rec => rec.Id == model.Id);
                        if(element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, new Transaction());
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

        private Transaction CreateModel(TransactionBindingModel model, Transaction transaction)
        {
            transaction.CreditingId = (int)model.CreditingId;
            transaction.CustomerId = (int)model.CustomerId;
            transaction.CreditProgramId = model.CreditProgramId;
            transaction.CreditProgramId = (int)model.CreditProgramId;
            transaction.DateFrom = (DateTime)model.DateFrom;
            transaction.DateTo = (DateTime)model.DateTo;
            return transaction;
        }
    }
}
