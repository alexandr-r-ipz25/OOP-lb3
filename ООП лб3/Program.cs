namespace OOP_lb3
{
    interface IParent
    {
        string Info();
        decimal CalculateTax();
    }

    class Child1 : IParent, IComparable<Child1>
    {
        public decimal Income { get; set; }
        public decimal TaxRate { get; set; }

        public Child1(decimal income, decimal taxRate)
        {
            Income = income;
            TaxRate = taxRate;
        }

        public string Info()
        {
            return $"Income: {Income:F2}, Tax rate: {TaxRate:F2}%";
        }

        public decimal CalculateTax()
        {
            return Income * TaxRate / 100;
        }

        public int CompareTo(Child1 other)
        {
            if (other == null)
                return 1;

            return Income.CompareTo(other.Income);
        }
    }

    class Child2 : IParent, IComparable<Child2>
    {
        public decimal Revenue { get; set; }
        public decimal Cost { get; set; }
        public decimal AdditionalExpenses { get; set; }
        public decimal TaxRate { get; set; }

        public Child2(decimal revenue, decimal cost,
                      decimal additionalExpenses, decimal taxRate)
        {
            Revenue = revenue;
            Cost = cost;
            AdditionalExpenses = additionalExpenses;
            TaxRate = taxRate;
        }

        public string Info()
        {
            return $"Revenue: {Revenue:F2}, Cost: {Cost:F2}, " +
                   $"Additional expenses: {AdditionalExpenses:F2}, " +
                   $"Tax rate: {TaxRate:F2}%";
        }

        public decimal CalculateTax()
        {
            decimal profit = Revenue - Cost - AdditionalExpenses;
            return profit * TaxRate / 100;
        }

        public int CompareTo(Child2 other)
        {
            if (other == null)
                return 1;

            return CalculateTax().CompareTo(other.CalculateTax());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Child1[] individuals = new Child1[5];
            Child2[] companies = new Child2[5];

            for (int i = 0; i < individuals.Length; i++)
            {
                decimal income = random.Next(30000, 150001);
                decimal taxRate = random.Next(5, 21);

                individuals[i] = new Child1(income, taxRate);
            }

            for (int i = 0; i < companies.Length; i++)
            {
                decimal revenue = random.Next(400000, 1000001);
                decimal cost = random.Next(100000, 300001);
                decimal expenses = random.Next(20000, 100001);
                decimal taxRate = random.Next(5, 21);

                companies[i] = new Child2(
                    revenue, cost, expenses, taxRate);
            }

            Console.WriteLine("INDIVIDUAL TAXES");
            Console.WriteLine("------------------------------");

            foreach (Child1 person in individuals)
            {
                Console.WriteLine(person.Info());
                Console.WriteLine($"Tax amount: {person.CalculateTax():F2}");
                Console.WriteLine();
            }

            Array.Sort(individuals);

            Console.WriteLine("INDIVIDUAL TAXES SORTED BY INCOME");
            Console.WriteLine("--------------------------------");

            foreach (Child1 person in individuals)
            {
                Console.WriteLine(person.Info());
                Console.WriteLine($"Tax amount: {person.CalculateTax():F2}");
                Console.WriteLine();
            }

            Console.WriteLine("CORPORATE TAXES");
            Console.WriteLine("------------------------------");

            foreach (Child2 company in companies)
            {
                Console.WriteLine(company.Info());
                Console.WriteLine($"Tax amount: {company.CalculateTax():F2}");
                Console.WriteLine();
            }

            Array.Sort(companies);

            Console.WriteLine("CORPORATE TAXES SORTED BY TAX AMOUNT");
            Console.WriteLine("------------------------------------");

            foreach (Child2 company in companies)
            {
                Console.WriteLine(company.Info());
                Console.WriteLine($"Tax amount: {company.CalculateTax():F2}");
                Console.WriteLine();
            }

            Console.WriteLine("Program completed successfully.");
            Console.ReadKey();
        }
    }
}
