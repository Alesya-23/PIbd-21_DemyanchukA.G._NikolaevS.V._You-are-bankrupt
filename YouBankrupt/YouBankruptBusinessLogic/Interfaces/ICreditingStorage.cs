using System;
using System.Collections.Generic;
using System.Text;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptBusinessLogic.Interfaces
{
    public interface ICreditingStorage
    {
        List<CreditingViewModel> GetFullList();

        List<CreditingViewModel> GetFilteredList(CreditingBindingModel model);

        CreditingViewModel GetElement(CreditingBindingModel model);

        void Insert(CreditingBindingModel model);

        void Update(CreditingBindingModel model);

        void Delete(CreditingBindingModel model);
    }
}
