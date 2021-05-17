using System;
using System.Collections.Generic;
using System.Text;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptBusinessLogic.Interfaces
{
    public interface ICreditProgramStorage
    {
        List<CreditProgramViewModel> GetFullList();
        List<CreditProgramViewModel> GetFilteredList(CreditProgramBindingModel model);
        CreditProgramViewModel GetElement(CreditProgramBindingModel model);
        void Insert(CreditProgramBindingModel model);
        void Update(CreditProgramBindingModel model);
        void Delete(CreditProgramBindingModel model);
    }
}
