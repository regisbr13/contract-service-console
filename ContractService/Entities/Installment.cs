using System;

namespace ContractService.Entities
{
    class Installment
    {
        public DateTime DueDate { get; set; }
        public double Quantia { get; private set; }

        public Installment(DateTime dueDate, double quantia)
        {
            DueDate = dueDate;
            Quantia = quantia;
        }
    }
}
