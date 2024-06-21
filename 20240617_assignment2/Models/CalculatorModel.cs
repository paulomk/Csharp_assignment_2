using System.ComponentModel.DataAnnotations;

namespace _20240617_assignment2.Models
{
    public class CalculatorModel
    {
        [Required(ErrorMessage = "Enter an amount to calculate")]
        [Range(0.01, int.MaxValue,ErrorMessage = "Invalid amount. Please, enter an amount greater than 0")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Entere yearly interest rate")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Invalid rate. Please, enter a rate greater or equal to 0.01")]
        public decimal InterestRatePerYear { get; set; }

        [Required(ErrorMessage = "Enter periods in months")]
        [Range(1,500, ErrorMessage = "Invalid period. Enter a value between 1 and 500")]
        public int PeriodsInMonth { get; set; }

        public double CalculateAnnuityFutureValue()
        {
            if (Amount <=0 || InterestRatePerYear <= 0 || PeriodsInMonth <= 0)
            {
                return 0;
            }
            else { 
                double convertedRate = ConvertRateYearlyToMonthly();
                double fv = ((double)Amount * (Math.Pow(1 + convertedRate, PeriodsInMonth) - 1) / convertedRate);
                return fv;
            }
        }

        public double CalculateAnnuityPresentValue()
        {

            if (Amount <= 0 || InterestRatePerYear <= 0 || PeriodsInMonth <= 0)
            {
                return 0;
            }
            double convertedRate = ConvertRateYearlyToMonthly();
            double pv = (double)Amount * (1 - Math.Pow(1 + convertedRate, -PeriodsInMonth)) / convertedRate;
            return pv;
        }

        /**
         * Converts an Yearly rate to one in a monthly basis using the own object attributes
         */
        private double ConvertRateYearlyToMonthly()
        {
            double ratePerMonth = Math.Pow(1 + (double)InterestRatePerYear/100, 1.0 / 12) - 1; // 1.0 is mandatory instead of 1, as integers are truncated
            return ratePerMonth;
        }
    }
}

