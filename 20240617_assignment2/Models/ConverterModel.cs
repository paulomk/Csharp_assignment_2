using System.ComponentModel.DataAnnotations;

namespace _20240617_assignment2.Models
{
    public class ConverterModel
    {
        [Required(ErrorMessage ="No informed")]
        public decimal? Amount { get; set; }
        public decimal Rate { get; set; } = 1.10M;

        [Required(ErrorMessage = "not informed")]
         public string? ConversionType {  get; set; }

        public decimal ConvertAmount()
        {
            decimal converted = 0;
            if (Amount == null)
            {
                return converted;
            }

            if (ConversionType?.Equals("CAD") == true)
            {
                converted = (decimal)Amount / Rate;
            }
            else if (ConversionType?.Equals("AUD") == true)
            {
                converted = (decimal)Amount * Rate;
            }
            return converted;

        }
    }
}
