using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Unity.Lifetime;
using YouBankruptBusinessLogic.BusinessLogic;
using YouBankruptBusinessLogic.BusinessLogics;
using YouBankruptBusinessLogic.Interfaces;
using YouBankruptDatabaseImplement.Implements;
using YouBankruptDatabaseImplements.Implements;

namespace YouBankruptSupplierView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer currentContainer = BuildUnityContainer();

            var mainWindow = currentContainer.Resolve<WindowInital>();
            mainWindow.Show();
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            //кредитная программа
            currentContainer.RegisterType<ICreditProgramStorage, CreditProgramStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<CreditProgramLogic>(new
            HierarchicalLifetimeManager());
            //валюта
            currentContainer.RegisterType<ICurrenceStorage, CurrenceStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<CurrenceLogic>(new
            HierarchicalLifetimeManager());
            //закупка
            currentContainer.RegisterType<IPurchasesCurrenceStorage, PurchasesCurrenceStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<PurchasesCurrenceLogic>(new
            HierarchicalLifetimeManager());
            //поставщик
            currentContainer.RegisterType<ISupplierStorage, SupplierStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<SupplierLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogicSupplier>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<ICreditingStorage, CreditingStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICustomerStorage, CustomerStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPaymentStorage, PaymentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPaymentStorage, PaymentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ITransactionStorage, TransactionStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICreditProgramStorage, CreditProgramStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<CustomerLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<CreditingLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<PaymentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<TransactionLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<CreditProgramLogic>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}