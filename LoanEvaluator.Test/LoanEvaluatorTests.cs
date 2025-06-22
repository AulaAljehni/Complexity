using Xunit;
using LoanEvaluator;

namespace LoanEvaluator.Test;

 public class LoanEvaluatorTests
 {

 [Fact]
        public void Test_LoanNotEligible_LowIncome()
        {
            var evaluator = new LoanEvaluatorHelper();
            var result = evaluator.GetLoanEligibility(1500, true, 650, 1, false);
            Assert.Equal("Not Eligible", result);
        }

        [Fact]
        public void Test_LoanEligible_WithJob_HighCreditScore_NoDependents()
        {
            var evaluator = new LoanEvaluatorHelper();
            var result = evaluator.GetLoanEligibility(3000, true, 750, 0, false);
            Assert.Equal("Eligible", result);
        }

        [Fact]
        public void Test_LoanReviewManually_WithJob_MediumCreditScore_TwoDependents()
        {
            var evaluator = new LoanEvaluatorHelper();
            var result = evaluator.GetLoanEligibility(3000, true, 700, 2, false);
            Assert.Equal("Review Manually", result);
        }

        [Fact]
        public void Test_LoanNotEligible_WithJob_LowCreditScore()
        {
            var evaluator = new LoanEvaluatorHelper();
            var result = evaluator.GetLoanEligibility(3000, true, 580, 1, false);
            Assert.Equal("Not Eligible", result);
        }

        [Fact]
        public void Test_LoanEligible_WithoutJob_HighCreditScore_OwnsHouse()
        {
            var evaluator = new LoanEvaluatorHelper();
            var result = evaluator.GetLoanEligibility(6000, false, 800, 0, true);
            Assert.Equal("Eligible", result);
        }

        [Fact]
        public void Test_LoanReviewManually_WithoutJob_MediumCreditScore_NoDependents()
        {
            var evaluator = new LoanEvaluatorHelper();
            var result = evaluator.GetLoanEligibility(4000, false, 670, 0, false);
            Assert.Equal("Review Manually", result);
        }

        [Fact]
        public void Test_LoanNotEligible_WithoutJob_LowCreditScore()
        {
            var evaluator = new LoanEvaluatorHelper();
            var result = evaluator.GetLoanEligibility(4000, false, 600, 1, false);
            Assert.Equal("Not Eligible", result);
        }

        [Theory]
    [InlineData(1500, true, 650, 1, false, "Not Eligible")]      
    [InlineData(3000, true, 750, 0, false, "Eligible")]            
    [InlineData(3000, true, 700, 2, false, "Review Manually")]     
    [InlineData(3000, true, 580, 1, false, "Not Eligible")]        
    [InlineData(6000, false, 800, 0, true, "Eligible")]      
    [InlineData(4000, false, 670, 0, false, "Review Manually")]            
    [InlineData(4000, false, 600, 1, false, "Not Eligible")]          
    public void GetLoanEligibility_ShouldReturnExpectedResult(
        int income, bool hasJob, int creditScore, int dependents, bool ownsHouse, string expected)
    {

        var evaluator = new LoanEvaluatorHelper();
        var result = evaluator.GetLoanEligibility(income, hasJob, creditScore, dependents, ownsHouse);

        
        Assert.Equal(expected, result);
    }

    }

 