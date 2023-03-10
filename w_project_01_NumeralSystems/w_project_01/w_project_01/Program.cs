using System;//i used math.pow 

namespace NumericalSystems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number in decimal, octal, or hexadecimal format");
            string input = Console.ReadLine();

            double decimalValue = ConvertToDecimal(input);
            Console.WriteLine("Decimal: {0}", decimalValue);

            string binaryValue = ConvertToBinary(decimalValue);
            Console.WriteLine("Binary: {0}", binaryValue);

            string octalValue = ConvertToOctal(decimalValue);
            Console.WriteLine("Octal: {0}", octalValue);

            string hexValue = ConvertToHexadecimal(decimalValue);
            Console.WriteLine("Hexadecimal: {0}", hexValue);
        }

        private static string ConvertToHexadecimal(double decimalValue)
        {
            int integerPart = (int)decimalValue;

            double fractionalPart = decimalValue - integerPart;

            string integerPartHex = "";
            while (integerPart > 0)
            {
                int remainder = integerPart % 16;
                integerPart = integerPart / 16;
                integerPartHex = remainder.ToString("X") + integerPartHex;
            }

            string fractionalPartHex = "";
            while (fractionalPart > 0)
            {
                fractionalPart = fractionalPart * 16;
                int wholeNumber = (int)fractionalPart;
                fractionalPartHex = fractionalPartHex + wholeNumber.ToString("X");
                fractionalPart = fractionalPart - wholeNumber;
            }

            if (fractionalPartHex.Length > 0 && fractionalPartHex.Length > 10)
            {
                return "0x" + integerPartHex + "." + fractionalPartHex;
            }
            else if (fractionalPartHex.Length > 0)
            {
                return "0x" + integerPartHex + "." + fractionalPartHex;
            }
            else
            {
                return "0x" + integerPartHex;
            }
        }

        private static string ConvertToOctal(double decimalValue)
        {
            int integerPart = (int)decimalValue;

            double fractionalPart = decimalValue - integerPart;

            string integerPartOctal = "";
            while (integerPart > 0)
            {
                int remainder = integerPart % 8;
                integerPart = integerPart / 8;
                integerPartOctal = remainder.ToString() + integerPartOctal;
            }

            string fractionalPartOctal = "";

            while (fractionalPart > 0)
            {
                fractionalPart = fractionalPart * 8;
                int wholeNumber = (int)fractionalPart;
                fractionalPartOctal = fractionalPartOctal + wholeNumber.ToString();
                fractionalPart = fractionalPart - wholeNumber;
            }

            if (fractionalPartOctal.Length > 0 && fractionalPartOctal.Length < 10)
            {
                return "0" + integerPartOctal + "." + fractionalPartOctal;
            }
            else if (fractionalPartOctal.Length > 0)
            {
                return "0" + integerPartOctal + "." + fractionalPartOctal;
            }
            else
            {
                return "0" + integerPartOctal;
            }
        }

        private static string ConvertToBinary(double decimalValue)
        {
            int integerPart = (int)decimalValue;
            double fractionalPart = decimalValue - integerPart;
            string integerPartBinary = "";
            while (integerPart > 0)
            {
                int remainder = integerPart % 2;
                integerPartBinary = remainder + integerPartBinary;
                integerPart = integerPart / 2;
            }
            string fractionalPartBinary = "";
            while (fractionalPart > 0)
            {
                if (fractionalPartBinary.Length > 32)
                {
                    fractionalPartBinary = fractionalPartBinary;
                    break;
                }
                double result = fractionalPart * 2;
                if (result >= 1)
                {
                    fractionalPartBinary += "1";
                    fractionalPart = result - 1;
                }
                else
                {
                    fractionalPartBinary += "0";
                    fractionalPart = result;
                }
            }
            string binaryValue = integerPartBinary;
            if (fractionalPartBinary.Length > 0 && fractionalPartBinary.Length > 10)
            {
                binaryValue += "." + fractionalPartBinary;
            }
            else if (fractionalPartBinary.Length > 0)
            {
                binaryValue += "." + fractionalPartBinary;
            }

            return binaryValue;
        }

        private static double ConvertToDecimal(string input)
        {
            if (input.Contains("."))
            {
                if (input.StartsWith("0x"))
                {
                    string[] parts = input.Split('.');
                    string integerPart = parts[0].Substring(2);
                    string fractionalPart = parts[1];


                    double result = 0;
                    int power = 0;

                    for (int i = integerPart.Length - 1; i >= 0; i--)
                    {
                        char c = integerPart[i];
                        int digit = Convert.ToInt32(c.ToString(), 16);
                        result += digit * Math.Pow(16, power);
                        power++;
                    }

                    power = -1;

                    for (int i = 0; i < fractionalPart.Length; i++)
                    {
                        char c = fractionalPart[i];
                        int digit = Convert.ToInt32(c.ToString(), 16);
                        result += digit * Math.Pow(16, power);
                        power--;
                    }

                    return result;
                }
                else if (input.StartsWith("0"))
                {
                    string[] parts = input.Split('.');
                    string integerPart = parts[0].Substring(1);
                    string fractionalPart = parts[1];

                    double result = 0;
                    int power = 0;

                    for (int i = integerPart.Length - 1; i >= 0; i--)
                    {
                        char c = integerPart[i];
                        int digit = Convert.ToInt32(c.ToString());
                        result += digit * Math.Pow(8, power);
                        power++;
                    }

                    power = -1;

                    for (int i = 0; i < fractionalPart.Length; i++)
                    {
                        char c = fractionalPart[i];
                        int digit = Convert.ToInt32(c.ToString());
                        result += digit * Math.Pow(8, power);
                        power--;
                    }

                    return result;
                }
                else
                {
                    return double.Parse(input);
                }
            }
            else
            {
                if (input.StartsWith("0x"))
                {
                    return Convert.ToInt32(input, 16);
                }
                else
                {
                    if (input.StartsWith("0"))
                    {
                        return Convert.ToInt32(input.Remove(0, 1), 8);
                    }
                    else
                    {
                        return Convert.ToInt32(input);
                    }
                }
            }
        }
    }
}
