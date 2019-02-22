using System;
using ContractService.Entities;

namespace ContractService.Services
{
    class ContractProcessing
    {
        private IOnlinePaymentService _onlinePaymentService;

        public ContractProcessing(IOnlinePaymentService service)
        {
            _onlinePaymentService = service;
        }

        public void ProcessContract(Contract contract, int months)
        {
            double valueInstallment = contract.Value / months;
            for (int i = 1; i <= months; i++)
            {
                double amount = valueInstallment + _onlinePaymentService.PaymentFee(_onlinePaymentService.Interest(valueInstallment, i)) + _onlinePaymentService.Interest(valueInstallment, i);
                DateTime dueDate = contract.Date.AddDays(30.0);
                contract.installments.Add(new Installment(dueDate, amount));
            }
        }
    }
}
