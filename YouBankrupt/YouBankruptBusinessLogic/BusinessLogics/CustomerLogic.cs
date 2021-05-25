

using System;
using System.Collections.Generic;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.Interfaces;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptBusinessLogic.BusinessLogic
{
    public class CustomerLogic
    {
        private readonly ICustomerStorage _customerStorage;

        public CustomerLogic(ICustomerStorage customerStorage)
        {
            _customerStorage = customerStorage;
        }

        public List<CustomerViewModel> Read(CustomerBindingModel model)
        {
            if (model == null)
            {
                return _customerStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<CustomerViewModel> { _customerStorage.GetElement(model) };
            }
            return _customerStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(CustomerBindingModel model)
        {
            var element = _customerStorage.GetElement(new CustomerBindingModel
            {
                Email = model.Email,
                CustomerFullName = model.CustomerFullName,
                Password = model.Password,
            });
            if(element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть пользователь с такими данными");
            }
            if (model.Id.HasValue)
            {
                _customerStorage.Update(model);
            }
            else
            {
                _customerStorage.Insert(model);
            }
        }

        public void Delete(CustomerBindingModel model)
        {
            var element = _customerStorage.GetElement(new CustomerBindingModel { Id = model.Id });
            if(element == null)
            {
                throw new Exception("Пользователь не найден");
            }
            _customerStorage.Delete(model);
        }
    }
}
