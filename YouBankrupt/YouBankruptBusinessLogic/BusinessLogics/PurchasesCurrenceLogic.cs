using System;
using System.Collections.Generic;
using System.Text;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.Interfaces;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptBusinessLogic.BusinessLogics
{
    public class PurchasesCurrenceLogic
    {
        private readonly IPurchasesCurrenceStorage _purchasesCurrenceStorage;
        public PurchasesCurrenceLogic(IPurchasesCurrenceStorage currenceStorage)
        {
            _purchasesCurrenceStorage = currenceStorage;
        }
        public List<PurchasesCurrenceViewModel> Read(PurchasesCurrenceBindingModel model)
        {
            if (model == null)
            {
                return _purchasesCurrenceStorage.GetFullList();
            }
            if (!model.Id.HasValue)
            {
                return _purchasesCurrenceStorage.GetFilteredList(model);
            }
            return new List<PurchasesCurrenceViewModel> { _purchasesCurrenceStorage.GetElement(model) };
        }
        public void CreateOrUpdate(PurchasesCurrenceBindingModel model)
        {
            var element = _purchasesCurrenceStorage.GetElement(new PurchasesCurrenceBindingModel
            {
               PurchasesName = model.PurchasesName,
                DateBuy = model.DateBuy
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Такая поставка уже есть!");
            }
            if (model.Id.HasValue)
            {
                _purchasesCurrenceStorage.Update(model);
            }
            else
            {
                _purchasesCurrenceStorage.Insert(model);
            }
        }
        public void Delete(PurchasesCurrenceBindingModel model)
        {
            var element = _purchasesCurrenceStorage.GetElement(new PurchasesCurrenceBindingModel
            {
                Id =
           model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _purchasesCurrenceStorage.Delete(model);
        }
        public List<DateTime> GetPickDate(PurchasesCurrenceBindingModel model)
        {

            var list = _purchasesCurrenceStorage.GetFilteredList(model);

            List<DateTime> dateOfDay = new List<DateTime>();
            bool end = false;
            while (!end) // создали список дат на этот день (потом их будем удалять если они совпадают с эл-ми list)
            {
                DateTime date = new DateTime(model.DateBuy.Year, model.DateBuy.Month, model.DateBuy.Day);
                dateOfDay.Add(date);
            }

            foreach (var item in list)
            {
                DateTime date = new DateTime(model.DateBuy.Year, model.DateBuy.Month, model.DateBuy.Day);
                if (dateOfDay.Contains(date))
                {
                    dateOfDay.Remove(date);
                }
            }
            return dateOfDay;
        }
    }
}
