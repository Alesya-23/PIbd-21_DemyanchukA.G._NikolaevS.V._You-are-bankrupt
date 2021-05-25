using System;
using System.Collections.Generic;
using System.Text;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.Interfaces;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptBusinessLogic.BusinessLogics
{
    public class CreditProgramLogic
    { private readonly ICreditProgramStorage _packageStorage;
        public CreditProgramLogic(ICreditProgramStorage packageStorage)
        {
            _packageStorage = packageStorage;
        }
        public List<CreditProgramViewModel> Read(CreditProgramBindingModel model)
        {
            if (model == null)
            {
                return _packageStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<CreditProgramViewModel> { _packageStorage.GetElement(model)};
            }
            return _packageStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(CreditProgramBindingModel model)
        {
            var element = _packageStorage.GetElement(new CreditProgramBindingModel
            {
                CreditProgramName = model.CreditProgramName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть кредитная программа с таким названием");
            }
            if (model.Id.HasValue)
            {
                _packageStorage.Update(model);
            }
            else
            {
                _packageStorage.Insert(model);
            }
        }
        public void Delete(CreditProgramBindingModel model)
        {
            var element = _packageStorage.GetElement(new CreditProgramBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _packageStorage.Delete(model);
        }
    }
}
