using System.Windows;
using Unity;
using Unity.Lifetime;
using YouBankruptBusinessLogic.BusinessLogic;
using YouBankruptBusinessLogic.BusinessLogics;
using YouBankruptBusinessLogic.Interfaces;
using YouBankruptDatabaseImplement.Implements;
using YouBankruptDatabaseImplements.Implements;

namespace YouBankruptProviderView
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

            //MailLogic.MailConfig(new MailConfig ...

            currentContainer.Resolve<LogIn>().Show();
        }


        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
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
