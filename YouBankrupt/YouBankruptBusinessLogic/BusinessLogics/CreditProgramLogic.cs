using System;
using System.Collections.Generic;
using System.Text;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.Interfaces;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptBusinessLogic.BusinessLogics
{
    public class CreditProgramLogic
    { private readonly ICreditProgramStorage creditProgramStoarage;
     private readonly ITransactionStorage transactionStorage;
        public CreditProgramLogic(ICreditProgramStorage creditProgramStorage, ITransactionStorage transaction)
        {
            creditProgramStoarage = creditProgramStorage;
            transactionStorage = transaction ;
        }
        public List<CreditProgramViewModel> Read(CreditProgramBindingModel model)
        {
            if (model == null)
            {
                return creditProgramStoarage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<CreditProgramViewModel> { creditProgramStoarage.GetElement(model)
};
            }
            return creditProgramStoarage.GetFilteredList(model);
        }
        public void CreateOrUpdate(CreditProgramBindingModel model)
        {
            var element = creditProgramStoarage.GetElement(new CreditProgramBindingModel
            {
                CreditProgramName = model.CreditProgramName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть кредитная программа с таким названием");
            }
            if (model.Id.HasValue)
            {
                creditProgramStoarage.Update(model);
            }
            else
            {
                creditProgramStoarage.Insert(model);
            }
        }
        public void Delete(CreditProgramBindingModel model)
        {
            var element = creditProgramStoarage.GetElement(new CreditProgramBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            creditProgramStoarage.Delete(model);
        }


        public void Linking(CreditProgramLinkingBindingModel model)
        {
            var crediting = creditProgramStoarage.GetElement(new CreditProgramBindingModel
            {
                Id = model.CreditingProgramId
            });

            var transaction = transactionStorage.GetElement(new TransactionBindingModel
            {
                Id = model.TransactionId
            });

            if (crediting == null)
            {
                throw new Exception("Не найдена программа");
            }

            if (transaction == null)
            {
                throw new Exception("Не найдена сделка");
            }

            if (crediting.TranzactionId.HasValue)
            {
                throw new Exception("Данная сделка уже привязана к кредитной программе");
            }

            creditProgramStoarage.Update(new CreditProgramBindingModel
            {
                Id = crediting.Id,
                CreditProgramName = crediting.CreditProgramName,
                Persent = crediting.Persent,
                PaymentTerm = crediting.PaymentTerm,
                Currenses = crediting.Currenses,
                SupplierId = crediting.SupplierId,
               TranzactionId = model.TransactionId
            });
        }
    }
}