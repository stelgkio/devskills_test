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
        public string FirstName { get;  }
        /// <example>Gautrey</example>
        public string LastName { get;  }
        /// <example>09 Westend Terrace</example>
        public string Address { get;  }
        /// <example>60668</example>
        public int AssessedIncome { get;  }
        /// <example>11585</example>
        public int BalanceOfDebt { get;  }
        /// <example>true</example>
        public bool Complaints { get; }
    }

}
