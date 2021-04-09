using System;
using System.Collections.Generic;
using System.Text;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptBusinessLogic.Interfaces
{
    public interface ISupplierStorage
    {
        List<SupplierViewModel> GetFullList();

        List<SupplierViewModel> GetFilteredList(SupplierBindingModel model);

        SupplierViewModel GetElement(SupplierBindingModel model);

        void Insert(SupplierBindingModel model);

        void Update(SupplierBindingModel model);

        void Delete(SupplierBindingModel model);
    }
}
