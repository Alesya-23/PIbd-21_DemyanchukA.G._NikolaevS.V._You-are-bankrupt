using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Unity.Lifetime;
using YouBankruptBusinessLogic.BusinessLogics;
using YouBankruptBusinessLogic.Interfaces;
using YouBankruptDatabaseImplements.Implements;

namespace YouBankruptSupplierView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
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

            return currentContainer;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var container = BuildUnityContainer();
            var welcomeWindow = container.Resolve<MainWindow>();
            welcomeWindow.Show();
        }
    }
}