//using YouBankruptBusinessLogic.BindingModels;
//using YouBankruptBusinessLogic.Interfaces;
//using YouBankruptBusinessLogic.ViewModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using YouBankruptBusinessLogic.HelperModels;

//namespace YouBankruptBusinessLogic.BusinessLogics
//{
//    public class ReportPurhaesCurrenceLogic
//    {
//        private readonly IPurcharesCurrenceStorage _purcharescurrenceStorage;
//        private readonly ICurrenceStorage _currenceStorage;
//        private readonly ICreditProgramStorage _creditProgramStorage;
//        private readonly IPaymentStorage _paymentStorage;

//        public ReportPurhaesCurrenceLogic(IPurcharesCurrenceStorage currentntStorage, ICreditProgramStorage creditProgram,
//     IPaymentStorage paymentStorage, ICurrenceStorage currenceStorage)
//        {
//            _purcharescurrenceStorage = currentntStorage;
//            _currenceStorage = currenceStorage;
//            _creditProgramStorage = creditProgram;
//            _paymentStorage = paymentStorage;
//        }

//        public List<ReportPurhacesCurrenseByTransactionViewModel> GetPurhacesPayment(ReportPurhacesCurrenseByTransactionBindingModel model)
//        {
//            purharence = _purcharescurrenceStorage.GetFilteredList();
//            currences = _currenceStorage.GetFilteredList();
//            creditProgram = _creditProgramStorage.GetFilteredList();
//            purharence = _purcharescurrenceStorage.GetFilteredList();

//            var list = new List<ReportPurhacesCurrenseByTransactionViewModel>();
//            foreach (var purcharecCurrence in purharence)
//            {
//                var record = new ReportPurhacesCurrenseByTransactionViewModel
//                {
//                   CurrenceName = purharence.CurrenceName
//                };
//                foreach (var currence in currences)
//                {
//                    if (purcharecCurrence.ReceptMedecines.ContainsKey(currence.Id))
//                    {
//                        record.CurrenceName = currence.CurrenceName;
//                        foreach (var creditingProgram in creditPrograms)
//                        {
//                            if (creditProgram.ProcedureMedicines.ContainsKey(currence.Id))
//                            {
//                                record.CurrenceName = creditProgram.CurrenceId;
//                                list.Add(record);
//                            }
//                        }
//                    }
//                }
//            }
//            return list;
//        }
//        public void SaveToPdfFile(ReportPurhacesCurrenseByTransactionBindingModel model)
//        {
//            SaveToPdf.CreateDoc(new PdfInfoSupplier
//            {
//                FileName = model.FileName,
//                Title = "Отчет по закупкам валюты",
//                DateFrom = model.DateFrom.Value,
//                DateTo = model.DateTo.Value,
//                PurchasesCurreces = GetPurhacesPayment(model)
//            });
//        }
//    }
//}