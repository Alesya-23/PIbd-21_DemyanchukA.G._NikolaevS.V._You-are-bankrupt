using System;
using System.Collections.Generic;
using System.Text;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.HelperModels;
using YouBankruptBusinessLogic.Interfaces;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptBusinessLogic.BusinessLogics
{
    public class ReportLogicSupplier
    {
        private readonly ISupplierStorage _supplierStorage;
        private readonly ICurrenceStorage _currenceStorage;
        private readonly IPaymentStorage _paymentStorage;
        private readonly ICreditingStorage _creditingStorage;
        private readonly ICreditProgramStorage _creditProgramStorage;
        private readonly IPurchasesCurrenceStorage _purchasesCurrence;

        public ReportLogicSupplier(ISupplierStorage supplierStorage, ICurrenceStorage currence,
            IPaymentStorage payment, ICreditingStorage crediting, ICreditProgramStorage creditProgram,
            IPurchasesCurrenceStorage PurchasesCurrence)
        {
            _supplierStorage = supplierStorage;
            _currenceStorage = currence;
            _paymentStorage = payment;
            _creditingStorage = crediting;
            _creditProgramStorage = creditProgram;
            _purchasesCurrence = PurchasesCurrence;
        }
        /// <summary>
        /// Получение списка закупок за определенный период по 15 связанной с 18 - отчёт
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportPurharenceViewModel> GetPurchares(ReportBindingModelSupplier model)
        {
            var listAll = new List<ReportPurharenceViewModel>();
            //var supplier = _supplierStorage.GetElement(new SupplierBindingModel { Id = model.SupplierId });


            //var listPurchases = _purchasesCurrence.GetFilteredList(new PurchasesCurrenceBindingModel { SupplierId = model.SupplierId, DateFrom = model.DateFrom, DateTo = model.DateTo });
            //foreach (var purchase in listPurchases)
            //{
            //    foreach (var pp in purchase.Currenses)
            //    {
            //        listAll.Add(new ReportPercharesViewModel
            //        {
            //            Date = purchase.DateBuy,
            //            CurrenceName = pp.Value.Item1,
            //            Count = pp.Value.Item2
            //        });
            //    }
            //}
            //var listCreditings = _creditingStorage.GetFilteredList(new CreditingBindingModel { SupplierId = model.SupplierId, DateFrom = model.DateFrom, DateTo = model.DateTo });
            //foreach (var visit in listCreditings)
            //{
            //    foreach (var vp in visit.CreditPayments)
            //    {
            //        listAll.Add(new ReportPercharesViewModel
            //        {
            //            TypeOfService = "Посещение",
            //            DateOfService = visit.Date,
            //            ProcedureName = vp.Value,
            //        });
            //    }
            //}
            return listAll;
        }

        /// <summary>
        /// Получение списка. (По сущности 18 на основе 13) Пользователь может получить 
        /// //список по зачислениям средств к платам на основе выбранных записей валют. 
        /// </summary>
        /// <returns></returns>
        public List<ReportCurrencePaymentViewModel> GetPaymentList(ReportCurrencePaymentBindingModel model)
        {
            var listCrediting = _creditingStorage.GetFullList();
            var list = new List<ReportCurrencePaymentViewModel>();

            foreach (var credit in listCrediting)
            {
                //выбрать список платежей
                foreach (var pay in credit.CreditPayments)
                {
                    if (pay.Value == model.CurrenceId)
                    {
                        var listPayment = _paymentStorage.GetFilteredList(new PaymentBindingModel { CreditId = credit.Id});
                        if (listPayment.Count > 0 && listPayment != null)
                        {
                            foreach (var payment in listPayment)
                            {
                                list.Add(new ReportCurrencePaymentViewModel
                                {
                                    //нужен ли мне тут остаток??
                                    CurrenceName = credit.CurrenceName,
                                    Date = (DateTime)payment.DatePayment,
                                    Cost = payment.Sum,
                                    CreditingId = credit.Id
                                });

                            }
                        }
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Сохранение покупок в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SavePurchaseListToWordFile(ReportBindingModelSupplier model, string name, int id)
        {
            SaveToWordSupplier.CreateDoc(new WordInfoSupplier
            {
                FileName = model.FileName,
                Title = "Сведения по выдачам",
                Payments = GetPaymentList(new ReportCurrencePaymentBindingModel { CurrenceName = name, CurrenceId = id })
            });
        }
        /// <summary>
        /// Сохранение покупок в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SavePurchaseListToExcelFile(ReportBindingModelSupplier model, string name, int id)
        {
            SaveToExelSupplier.CreateDoc(new ExcelInfoSupplier
            {
                FileName = model.FileName,
                Title = "Сведения по выдачам",
                Payments = GetPaymentList(new ReportCurrencePaymentBindingModel { CurrenceName = name, CurrenceId = id })
            });
        }
        /// <summary>
        /// Сохранение процедур в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SavePaymentToPdfFile(ReportBindingModelSupplier model)
        {
            SaveToPdfSupplier.CreateDoc(new PdfInfoSupplier
            {
                FileName = model.FileName,
                Title = "Список закупок, связанных с платами",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                PurchasesCurreces = GetPurchares(model)
            });
        }
    }
}