using System;
using System.Collections.Generic;
using System.Text;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptBusinessLogic.Interfaces
{
    public interface ICurrenceStorage
    {
        List<CurrenceViewModel> GetFullList();
        List<CurrenceViewModel> GetFilteredList(CurrenceBindingModel model);
        CurrenceViewModel GetElement(CurrenceBindingModel model);
        void Insert(CurrenceBindingModel model);
        void Update(CurrenceBindingModel model);
        void Delete(CurrenceBindingModel model);
    }
}
