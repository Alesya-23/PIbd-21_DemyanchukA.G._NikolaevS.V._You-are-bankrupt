using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.Interfaces;
using YouBankruptBusinessLogic.ViewModels;
using YouBankruptDatabaseImplements;
using YouBankruptDatabaseImplements.Models;

namespace YouBankruptDatabaseImplement.Implements
{
    public class CustomerStorage : ICustomerStorage
    {
        public void Delete(CustomerBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                Customer element = context.Customers.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Customers.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public CustomerViewModel GetElement(CustomerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new YouBankruptDatabase())
            {
                var customer = context.Customers.FirstOrDefault(rec => rec.Id == model.Id);
                return customer != null ?
                new CustomerViewModel
                {
                    Id = (int)customer.Id,
                    CustomerFullName = customer.CustomerFullName,
                    Email = customer.Email,
                    Password = customer.Password
                } :
                null;
            }
        }

        public List<CustomerViewModel> GetFilteredList(CustomerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new YouBankruptDatabase())
            {
                return context.Customers
                .Where(rec => rec.Email == model.Email && rec.Password == model.Password)
                .Select(rec => new CustomerViewModel
                {
                    Id = (int)rec.Id,
                    CustomerFullName = rec.CustomerFullName,
                    Email = rec.Email,
                    Password = rec.Password
                })
                .ToList();
            }
        }

        public List<CustomerViewModel> GetFullList()
        {
            using (var context = new YouBankruptDatabase())
            {
                return context.Customers
                    .Include(rec => rec.Id)
                    .Include(rec => rec.Email)
                    .Include(rec => rec.Password)
                    .Include(rec => rec.CustomerFullName)
                    .Select(rec => new CustomerViewModel
                    {
                        Id = (int)rec.Id,
                        CustomerFullName = rec.CustomerFullName,
                        Email = rec.Email,
                        Password = rec.Password
                    })
               .ToList();
            }
        }

        public void Insert(CustomerBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Customers.Add(CreateModel(model, new Customer()));
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

        public void Update(CustomerBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                var element = context.Customers.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        private Customer CreateModel(CustomerBindingModel model, Customer customer)
        {
            customer.CustomerFullName = model.CustomerFullName;
            customer.Email = model.Email;
            customer.Password = model.Password;
            return customer;
        }
    }
}
