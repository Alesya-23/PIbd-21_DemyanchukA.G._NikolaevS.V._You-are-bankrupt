using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.Interfaces;
using YouBankruptBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace YouBankruptBusinessLogic.BusinessLogics
{
    public class SupplierLogic
    {
        private readonly ISupplierStorage _SupplierStorage; 

        public SupplierLogic(ISupplierStorage SupplierStorage)
        {
            _SupplierStorage = SupplierStorage;
        }

        public List<SupplierViewModel> Read(SupplierBindingModel model)
        {
            if (model == null)
            {
                return _SupplierStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<SupplierViewModel> { _SupplierStorage.GetElement(model) };
            }
            return _SupplierStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(SupplierBindingModel model)
        {
            var element = _SupplierStorage.GetElement(new SupplierBindingModel
            {
                Email = model.Email

            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть клиент с таким логином");
            }
            if (model.Id.HasValue)
            {
                _SupplierStorage.Update(model);
            }
            else
            {
                _SupplierStorage.Insert(model);
            }
        }
        public void Delete(SupplierBindingModel model)
        {
            var element = _SupplierStorage.GetElement(new SupplierBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Клиент не найден");
            }
            _SupplierStorage.Delete(model);
        }
    }
}
