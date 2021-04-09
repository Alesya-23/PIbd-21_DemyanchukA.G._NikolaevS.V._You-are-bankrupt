using System;
using System.Collections.Generic;
using System.Text;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptBusinessLogic.Interfaces
{
    public interface ITransactionWithCustomerStorage
    {
        List<TransactionWithCustomerViewModel> GetFullList();

        List<TransactionWithCustomerViewModel> GetFilteredList(TransactionWithCustomerBindingModel model);

        TransactionWithCustomerViewModel GetElement(TransactionWithCustomerBindingModel model);

        void Insert(TransactionWithCustomerBindingModel model);

        void Update(TransactionWithCustomerBindingModel model);

        void Delete(TransactionWithCustomerBindingModel model);
    }
}
