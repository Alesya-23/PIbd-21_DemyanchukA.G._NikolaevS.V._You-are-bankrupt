using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.Interfaces;
using YouBankruptBusinessLogic.ViewModels;
using YouBankruptDatabaseImplement.Models;

namespace YouBankruptDatabaseImplement.Implements
{
    public class TransactionWithCustomerStorage : ITransactionWithCustomerStorage
    {
        public void Delete(TransactionWithCustomerBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                TransactionWithCustomer element = context.TransactionWithCustomers.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.TransactionWithCustomers.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public TransactionWithCustomerViewModel GetElement(TransactionWithCustomerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new YouBankruptDatabase())
            {
                var transaction = context.TransactionWithCustomers
                .Include(rec => rec.Payments)
                .ThenInclude(rec => rec.TransactionWithCustomerId)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return transaction != null ?
                new TransactionWithCustomerViewModel
                {
                    Id = transaction.Id,
                    CustomerId = transaction.CustomerId,
                    CustomerFullName = transaction.CustomerFullName,
                   /* Payments = transaction.Payments.ToDictionary(
                        recPC => recPC.Id, recPC => (recPC.TransactionWithCustomerId, recPC.Sum)
                    )*/
                } 
                : null;
            }
        }

        public List<TransactionWithCustomerViewModel> GetFilteredList(TransactionWithCustomerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new YouBankruptDatabase())
            {
                return context.TransactionWithCustomers
                .Include(rec => rec.Payments)
                .ThenInclude(rec => rec.TransactionWithCustomerId)
                .Where(rec => rec.Id.Equals(model.Id))
                .ToList()
                .Select(rec => new TransactionWithCustomerViewModel
                {
                    Id = rec.Id,
                    CustomerFullName = rec.CustomerFullName,
                    CustomerId = rec.CustomerId,
                    CreditProgramId = rec.CreditProgramId
                 /*   Payments = rec.Payments
                .ToDictionary(recPC => recPC.Id, recPC =>
                (recPC.TransactionWithCustomerId, recPC.Sum))
                */})
                .ToList();
            }
        }

        public List<TransactionWithCustomerViewModel> GetFullList()
        {
            throw new NotImplementedException();

            /*
            using (var context = new YouBankruptDatabase())
            {
                return context.TransactionWithCustomers
                .Include(rec => rec.Payments)
                .ThenInclude(rec => rec.Pa)
                .ToList()
                .Select(rec => new SnackViewModel
                {
                    Id = rec.Id,
                    SnackName = rec.SnackName,
                    Price = rec.Price,
                    SnackComponents = rec.SnackComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (recPC.Component?.ComponentName, recPC.Count))
                })
               .ToList();
            }
            */
        }

        public void Insert(TransactionWithCustomerBindingModel model)
        {
            throw new NotImplementedException();
            
            
            /*
            using (var context = new YouBankruptDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Snack snack = new Snack
                        {
                            SnackName = model.SnackName,
                            Price = model.Price
                        };
                        context.Snacks.Add(snack);
                        context.SaveChanges();
                        CreateModel(model, snack, context);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            */

        }

        public void Update(TransactionWithCustomerBindingModel model)
        {
            throw new NotImplementedException();


            /*
             using (var context = new AbstractDinerDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Snack snack = new Snack
                        {
                            SnackName = model.SnackName,
                            Price = model.Price
                        };
                        context.Snacks.Add(snack);
                        context.SaveChanges();
                        CreateModel(model, snack, context);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
             */
        }
    }
}
