using System;
using System.Collections.Generic;

namespace ContractService.Entities
{
    class Contract
    {
        public int Number { get; private set; }
        public DateTime Date { get; set; }
        public double Value { get; private set; }
        public List<Installment> installments;

        public Contract(int number, DateTime date, double value)
        {
            Number = number;
            Date = date;
            Value = value;
            installments = new List<Installment>();
        }
    }
}
