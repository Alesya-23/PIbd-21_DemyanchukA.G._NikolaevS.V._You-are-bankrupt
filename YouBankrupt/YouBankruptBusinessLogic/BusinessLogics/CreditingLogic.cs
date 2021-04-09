using System;
using System.Collections.Generic;
using System.Text;
using YouBankruptBusinessLogic.Interfaces;
using YouBankruptBusinessLogic.ViewModels;
using YouBankruptBusinessLogic.BindingModels;

namespace YouBankruptBusinessLogic.BusinessLogic
{
    public class CreditingLogic
    {
        private readonly ICreditingStorage _creditingStorage;

        public CreditingLogic(ICreditingStorage creditingStorage)
        {
            _creditingStorage = creditingStorage;
        }

        public List<CreditingViewModel> Read(CreditingBindingModel model)
        {
            if (model == null)
            {
                return _creditingStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<CreditingViewModel> { _creditingStorage.GetElement(model) };
            }
            return _creditingStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(CreditingBindingModel model)
        {
            
            throw new NotImplementedException();
        }

        public void Delete(CreditingBindingModel model)
        {
            var element = _creditingStorage.GetElement(new CreditingBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Клиент не найден");
            }
            _creditingStorage.Delete(model);
        }
    }
}
