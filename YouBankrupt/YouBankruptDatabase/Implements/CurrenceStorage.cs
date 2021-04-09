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
    public class CurrenceStorage : ICurrenceStorage
    {
        public List<CurrenceViewModel> GetFullList()
        {
            using (var context = new YouBankruptDatabase())
            {
                return context.Currences
                .Select(rec => new CurrenceViewModel
                {
                    Id = (int)rec.Id,
                    CurrenceName = rec.CurrenceName
                })
               .ToList();
            }
        }
        public List<CurrenceViewModel> GetFilteredList(CurrenceBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new YouBankruptDatabase())
            {
                return context.Currences
                .Where(rec => rec.CurrenceName.Contains(model.CurrenceName))
               .Select(rec => new CurrenceViewModel
               {
                   Id = (int)rec.Id,
                   CurrenceName = rec.CurrenceName
               })
                .ToList();
            }
        }
        public CurrenceViewModel GetElement(CurrenceBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new YouBankruptDatabase())
            {
                var currence = context.Currences
                .FirstOrDefault(rec => rec.CurrenceName == model.CurrenceName ||
               rec.Id == model.Id);
                return currence != null ?
                new CurrenceViewModel
                {
                    Id = (int)currence.Id,
                    CurrenceName = currence.CurrenceName
                } :
               null;
            }
        }
        public void Insert(CurrenceBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                context.Currences.Add(CreateModel(model, new Currence()));
                context.SaveChanges();
            }
        }
        public void Update(CurrenceBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                var element = context.Currences.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(CurrenceBindingModel model)
        {
            using (var context = new YouBankruptDatabase())
            {
                Currence element = context.Currences.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Currences.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Currence CreateModel(CurrenceBindingModel model, Currence currence)
        {
            currence.CurrenceName = model.CurrenceName;
            return currence;
        }
    }
}