using System;
using System.Collections.Generic;
using System.Text;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.Interfaces;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptBusinessLogic.BusinessLogics
{
    public class CurrenceLogic
    {
        private readonly ICurrenceStorage _currenceStorage;
        public CurrenceLogic(ICurrenceStorage currenceStorage)
        {
            _currenceStorage = currenceStorage;
        }
        public List<CurrenceViewModel> Read(CurrenceBindingModel model)
        {
            if (model == null)
            {
                return _currenceStorage.GetFullList();
            }
            if (!model.Id.HasValue)
            {
                return _currenceStorage.GetFilteredList(model);
            }
            return new List<CurrenceViewModel> { _currenceStorage.GetElement(model) };
        }
        public void CreateOrUpdate(CurrenceBindingModel model)
        {
            var element = _currenceStorage.GetElement(new CurrenceBindingModel
            {
                CurrenceName = model.CurrenceName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть валюта с таким названием");
            }
            if (model.Id.HasValue)
            {
                _currenceStorage.Update(model);
            }
            else
            {
                _currenceStorage.Insert(model);
            }
        }
        public void Delete(CurrenceBindingModel model)
        {
            var element = _currenceStorage.GetElement(new CurrenceBindingModel
            {
                Id =
           model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _currenceStorage.Delete(model);
        }
    }
}
