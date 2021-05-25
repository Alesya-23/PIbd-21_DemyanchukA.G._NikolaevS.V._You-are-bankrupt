using System;
using System.Collections.Generic;
using System.Text;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptBusinessLogic.Interfaces
{
    public interface ITransactionStorage
    {
        List<TransactionViewModel> GetFullList();

        List<TransactionViewModel> GetFilteredList(TransactionBindingModel model);

        TransactionViewModel GetElement(TransactionBindingModel model);

        void Insert(TransactionBindingModel model);

        void Update(TransactionBindingModel model);

        void Delete(TransactionBindingModel model);
    }
}
