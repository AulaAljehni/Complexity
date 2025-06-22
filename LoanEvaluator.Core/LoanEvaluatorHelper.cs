namespace LoanEvaluator
{
    public class LoanEvaluatorHelper
    {
        public string GetLoanEligibility(int income, bool hasJob, int creditScore, int dependents, bool ownsHouse)
        {
            if (income < 2000)
                return "Not Eligible";

            if (hasJob)
                return EvaluateWithJob(creditScore, dependents);
            else
                return EvaluateWithoutJob(creditScore, income, ownsHouse, dependents);
        }

        private string EvaluateWithJob(int creditScore, int dependents)
        {
            if (creditScore >= 700)
                return EvaluateDependents(dependents);
            else if (creditScore >= 600)
                return "Not Eligible"; 

            return "Not Eligible";
        }

        private string EvaluateDependents(int dependents)
        {
            if (dependents == 0)
                return "Eligible";
            else if (dependents <= 2)
                return "Review Manually";

            return "Not Eligible";
        }

        private string EvaluateWithoutJob(int creditScore, int income, bool ownsHouse, int dependents)
        {
            if (creditScore >= 750 && income > 5000 && ownsHouse)
                return "Eligible";
            else if (creditScore >= 650 && dependents == 0)
                return "Review Manually";

            return "Not Eligible";
        }
    }
}