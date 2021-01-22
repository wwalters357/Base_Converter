using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace App_Test
{
    public class Number
    {
        public Number(string x , int b1, int b2)
        {
            this.Value = x;
            this.Base_Number = b1;
            this.New_Base_Number = b2;
        }

        private Number()
        {

        }

        private static Number instance = null;
        public static Number Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Number();
                }
                return instance;
            }
        }

        // No individual digit can be greater than the Base number.
        private bool Is_Base_Valid()
        {
            try
            {
                foreach (char c in Value)
                {
                    int x = Convert_Char_To_Int(c);
                    if (x > Base_Number || x < 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine(Number.Instance);
                return false;
            }
        }

        // Shortcut available if bases are (2,8) (2,16) (8,2) (16,2)
        private int Is_Shortcut_Available()
        {
            if (Base_Number == 2 && New_Base_Number == 8)
            {
                return 1;
            }
            else if (Base_Number == 2 && New_Base_Number == 16)
            {
                return 2;
            }
            else if (Base_Number == 8 && New_Base_Number == 2)
            {
                return 3;
            }
            else if (Base_Number == 16 && New_Base_Number == 2)
            {
                return 4;
            }
            else
            {
                return -1;
            }
        }

        
        public string Shortcut(int option)
        {
            switch (option) 
            {
                case 1: // (2, 8)
                    return Convert_Binary_To_OctalHexadecimal(Value, 3);
                case 2: // (2, 16)
                    return Convert_Binary_To_OctalHexadecimal(Value, 4);
                case 3: // (8, 2)
                    return Convert_OctalHexadecimal_To_Binary(Value, 3);
                case 4: // (16, 2)
                    return Convert_OctalHexadecimal_To_Binary(Value, 4);
            }
            return null;
        }

        //-------------------------------------------------------------------------------
        //-------------------------- Conversion Methods ---------------------------------
        //-------------------------------------------------------------------------------

        public string Convert_Binary_To_OctalHexadecimal(string number, int grouping)
        {
            int diff = (grouping - number.Length % grouping) % grouping;
            string binary = new String('0', diff) + number;
            int size = binary.Length / grouping;
            char[] result = new char[size];
            for (int i = 0; i < size; i++)
            {
                string section = binary.Substring(grouping * i, grouping);
                int sum = 0;
                for (int j = grouping - 1; j >= 0; j--)
                {
                    if (section[j] == '1')
                    {
                        sum += (int)(Math.Pow(2, (grouping - j - 1)));
                    }
                }
                result[i] = Convert_Int_To_Char(sum);
            }
            return new string(result);
        }

        public string Convert_OctalHexadecimal_To_Binary(string number, int grouping)
        {
            string result = "";
            foreach (char c in number)
            {
                string section = "";
                int x = Convert_Char_To_Int(c);
                for (int i = grouping - 1; i >= 0; i--)
                {
                    int spot = (int)Math.Pow(2, i);
                    if (x >= spot)
                    {
                        x -= spot;
                        section += '1';
                    }
                    else
                    {
                        section += '0';
                    }
                }
                result += section;
            }
            return Trim_Front(result);
        }

        public BigInteger Convert_To_Decimal()
        {
            BigInteger result = BigInteger.Zero;
            string number = Value;
            int count = 0;
            Console.WriteLine(result);
            for (int i = number.Length - 1; i >= 0; i--)
            {
                char x = char.ToUpper(number[i]);
                int digit = Convert_Char_To_Int(x);
                result +=  digit * (int)Math.Pow(Base_Number, count++);
            }
            return result;
        }

        public char[] Convert_From_Decimal(BigInteger x)
        {
            int Base = New_Base_Number;
            int size = (int)(BigInteger.Divide(x, Base) + Base);
            char[] number = new char[size];
            int count = 0;
            int digit = 0;
            while (BigInteger.Divide(x, Base) > 0)
            {
                if (count >= size)
                {
                    Array.Resize(ref number, number.Length * 2);
                    size *= 2;
                }
                digit = (int) BigInteger.Remainder(x, Base);
                number[count++] = Convert_Int_To_Char(digit);
                x = BigInteger.Divide(x, Base);
            }
            digit = (int)BigInteger.Remainder(x, Base);
            number[count] = Convert_Int_To_Char(digit);
            return new string(number, 0, count + 1).ToCharArray();
        }

        private int Convert_Char_To_Int(char c)
        {
            c = char.ToUpper(c);
            int num = (int)c;
            if (num >= (int)'A')
            {
                return num - (int)'A' + 10;
            }
            else
            {
                return num - (int)'0';
            }
        }

        private char Convert_Int_To_Char(int digit)
        {
            if (digit < 10)
            {
                return (char)(digit + (int)'0');
            }
            else
            {
                switch (digit)
                {
                    case 10:
                        return 'A';
                    case 11:
                        return 'B';
                    case 12:
                        return 'C';
                    case 13:
                        return 'D';
                    case 14:
                        return 'E';
                    case 15:
                        return 'F';
                    default:
                        return 'X';
                }
            }
        }

        public string Trim_Front(string number)
        {
            while (number[0] == '0')
            {
                number = number.Remove(0, 1);
            }
            return number;
        }

        public char[] Reverse_Array(char[] number)
        {
            int m = number.Length / 2;
            for (int i = 0; i < m; i++)
            {
                char temp = number[number.Length - 1 - i];
                number[number.Length - 1 - i] = number[i];
                number[i] = temp;
            }
            return number;
        }

        public string Convert_Number()
        {
            // Check if an appropriate base is used for specified number
            if (!Is_Base_Valid())
            {
                return "Invalid number, No digit can be greater than the base.";
            }
            int option = 0;
            if ((option = Is_Shortcut_Available()) == -1)
            {
                return new String(Reverse_Array(Convert_From_Decimal(Convert_To_Decimal())));
            }
            else
            {
                return Shortcut(option);
            }
        }

        public int Base_Number { get; set; }

        public int New_Base_Number { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return "Value: " + Value + "\nFrom Base: " + Base_Number + "\nTo Base: " + New_Base_Number;
        }
    }
}
