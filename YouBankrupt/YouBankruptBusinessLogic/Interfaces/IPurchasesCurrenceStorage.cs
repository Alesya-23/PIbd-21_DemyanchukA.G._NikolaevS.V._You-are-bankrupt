using System;
using System.Collections.Generic;
using System.Text;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptBusinessLogic.Interfaces
{
    public interface IPurchasesCurrenceStorage
    {
        List<PurchasesCurrenceViewModel> GetFullList();
        List<PurchasesCurrenceViewModel> GetFilteredList(PurchasesCurrenceBindingModel model);
        PurchasesCurrenceViewModel GetElement(PurchasesCurrenceBindingModel model);
        void Insert(PurchasesCurrenceBindingModel model);
        void Update(PurchasesCurrenceBindingModel model);
        void Delete(PurchasesCurrenceBindingModel model);
    }
}
