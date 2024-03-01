using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Core.Helpers
{
    public static class NumberToWords
    {
        private static readonly string[] ones =
        {
            "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"
        };

        private static readonly string[] teens =
        {
            "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
        };

        private static readonly string[] tens =
        {
            "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
        };

        public static string ConvertToWords(int number)
        {
            if (number < 0)
                return "Minus " + ConvertToWords(-number);

            if (number < 10)
                return ones[number];

            if (number < 20)
                return teens[number - 10];

            if (number < 100)
                return tens[number / 10] + (number % 10 != 0 ? " " + ones[number % 10] : "");

            if (number < 1000)
                return ones[number / 100] + " Hundred" + (number % 100 != 0 ? " and " + ConvertToWords(number % 100) : "");

            if (number < 1000000)
                return ConvertToWords(number / 1000) + " Thousand" + (number % 1000 != 0 ? " " + ConvertToWords(number % 1000) : "");

            if (number < 1000000000)
                return ConvertToWords(number / 1000000) + " Million" + (number % 1000000 != 0 ? " " + ConvertToWords(number % 1000000) : "");

            return ConvertToWords(number / 1000000000)  + " Billion" + (number % 1000000000 != 0 ? " " + ConvertToWords(number % 1000000000): "");
        }
    }
}
