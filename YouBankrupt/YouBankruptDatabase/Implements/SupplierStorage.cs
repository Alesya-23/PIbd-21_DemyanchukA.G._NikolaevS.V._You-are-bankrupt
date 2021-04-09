using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.Interfaces;
using YouBankruptBusinessLogic.ViewModels;
using YouBankruptDatabaseImplements.Models;

namespace YouBankruptDatabaseImplements.Implements
{
    public class SupplierStorage : ISupplierStorage
    {
        public List<SupplierViewModel> GetFullList()
        {
            using (var context = new YouBankruptDatabase())
            {
                return context.Suppliers.Select(rec => new SupplierViewModel
                {
                    Id = rec.Id,
                    SupplierFullName = rec.SupplierFullName,
                    Email = rec.Email,
                    Password = rec.Password,
                })
                .ToList();
            }
        }

        public List<SupplierViewModel> GetFilteredList(SupplierBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new YouBankruptDatabase())
            {
                return context.Suppliers
                .Where(rec => rec.Email == model.Email && rec.Password == rec.Password)
                .Select(rec => new SupplierViewModel
                {
                    Id = rec.Id,
                    SupplierFullName = rec.SupplierFullName,
                    Email = rec.Email,
                    Password = rec.Password,
                })
                .ToList();
            }
        }

        public SupplierViewModel GetElement(SupplierBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new YouBankruptDatabase())
            {
                var client = context.Suppliers.
                FirstOrDefault(rec => rec.Email == model.Email ||
                rec.Id == model.Id);
                return client != null ?
                new SupplierViewModel
                {
                    Id = client.Id,
                    SupplierFullName = client.SupplierFullName,
                    Email = client.Email,
                    Password = client.Password,
                } :
                null;
            }
        }

        public void Insert(SupplierBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                context.Suppliers.Add(CreateModel(model, new Supplier(), context));
                context.SaveChanges();
            }
        }

        public void Update(SupplierBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                var element = context.Suppliers.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Клиент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
            }
        }

        public void Delete(SupplierBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                Supplier element = context.Suppliers.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Suppliers.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Клиент не найден");
                }
            }
        }

        private Supplier CreateModel(SupplierBindingModel model, Supplier client, YouBankruptDatabase database)
        {
            client.SupplierFullName = model.SupplierFullName;
            client.Email = model.Email;
            client.Password = model.Password;
            return client;
        }
    }
}

