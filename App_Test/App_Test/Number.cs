using System;

namespace App_Test
{
    public class Number
    {
        public Number(int x , int b1, int b2)
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

        public int Convert_To_Decimal()
        {
            int count = 1;
            int number = (int) Value;
            int result = number % 10;
            while ((number /= 10) > 0)
            {
                result += number % 10 * (int) Math.Pow(Base_Number, count);
                count++;
            }
            return result;
        }

        public char[] Convert_From_Decimal(int x)
        {
            int b = New_Base_Number;
            int size = (int) (x / b + b);
            char[] number = new char[size];
            int count = 0;
            while ((x / b) > 0)
            {
                if (count >= size)
                {
                    Array.Resize(ref number, number.Length * 2);
                    size *= 2;
                }
                number[count] = (char)(x % b + 48);
                x /= b;
                count++;
            }
            number[count] = (char)(x % b + 48);
            return new String(number, 0, count + 1).ToCharArray();
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
            return new String( Reverse_Array( Convert_From_Decimal( Convert_To_Decimal() ) ) );

        }

        public int Base_Number { get; set; }

        public int New_Base_Number { get; set; }

        public double Value { get; set; }

        public string toString()
        {
            return "Value: " + Value + " Base: " + Base_Number;
        }
    }
}
