namespace backend.Contracts
{
  
    public class CreditData
    {
        public CreditData(string firstName, string lastName, string address, int assessedIncome, int balanceOfDebt, bool complaints)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            AssessedIncome = assessedIncome;
            BalanceOfDebt = balanceOfDebt;
            Complaints = complaints;
        }
        /// <example>Emma</example>
        public string FirstName { get; set; }
        /// <example>Gautrey</example>
        public string LastName { get; set; }
        /// <example>09 Westend Terrace</example>
        public string Address { get; set; }
        /// <example>60668</example>
        public int AssessedIncome { get; set; }
        /// <example>11585</example>
        public int BalanceOfDebt { get; set; }
        /// <example>true</example>
        public bool Complaints { get; set; }
    }

}
