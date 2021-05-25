using System;
using System.Collections.Generic;
using System.Text;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.Interfaces;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptBusinessLogic.BusinessLogic
{
    public class TransactionLogic
    {
        private readonly ITransactionStorage _transactionStorage;

        public TransactionLogic(ITransactionStorage storage)
        {
            _transactionStorage = storage;
        }

        public List<TransactionViewModel> Read(TransactionBindingModel model)
        {
            if (model == null)
            {
                return _transactionStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<TransactionViewModel> { _transactionStorage.GetElement(model) };
            }
            return _transactionStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(TransactionBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _transactionStorage.Update(model);
            }
            else
            {
                _transactionStorage.Insert(model);
            }
        }

        public void Delete(TransactionBindingModel model)
        {
            var element = _transactionStorage.GetElement(new TransactionBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Сделака не найдено");
            }
            _transactionStorage.Delete(model);
        }

    }
}
