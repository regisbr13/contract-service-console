using System;
using System.Globalization;
using ContractService.Entities;
using ContractService.Services;

namespace ContractService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter contract data");
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Date (dd/MM/yyyy): ");
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Console.Write("Contract value: ");
                double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Contract contract = new Contract(number, date, value);

                Console.Write("Enter number of installments: ");
                int months = int.Parse(Console.ReadLine());

                ContractProcessing service = new ContractProcessing(new PaypalService());
                service.ProcessContract(contract, months);

                Console.WriteLine("Installments:");
                foreach (Installment installment in contract.installments)
                {
                    Console.WriteLine(installment);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro inesperado: " + e.Message);
            }
            
        }
    }
}
