using System;
using System.Reflection;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*int someNumber;
            someNumber = int.Parse(Console.ReadLine());
            for(int i= 0; i< someNumber; i++)
            {
                if(i%2 == 0)
                    Console.WriteLine(someFunction(i));
            }*/
            while (true)
            {
                DateTime current_datetime = DateTime.Now;
                string current_datetime_as_string = current_datetime.ToString();
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                Console.WriteLine("Decimal: " + current_datetime_as_string);
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //current_time_string_elements[0] - date; current_time_string_elements[1] = time(ai hour;minutes;seconds), current_time_string_elements[2] = am/pm
                string[] current_datetime_string_elements = current_datetime_as_string.Split(" ");
                string[] current_date_string = current_datetime_string_elements[0].Split("/");
                string[] current_time_string = current_datetime_string_elements[1].Split(":");
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                int[] current_time_hex = { -1, -1, -1 };
                current_time_hex = convert_hex_to_string_array(current_time_string);
                int[] current_date_hex = { -1, -1, -1 };
                current_date_hex = convert_hex_to_string_array(current_date_string);
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                string current_datetime_string_elements_hex = "";
                for(int index = 0;index<current_date_string.Length-1; index++)
                {
                    current_datetime_string_elements_hex += Convert.ToString(current_date_hex[index]);
                    current_datetime_string_elements_hex += "/";
                }
                current_datetime_string_elements_hex += Convert.ToString(current_date_hex[2]);
                current_datetime_string_elements_hex += " ";
                for (int index = 0; index < current_time_string.Length-1; index++)
                {
                    current_datetime_string_elements_hex += Convert.ToString(current_time_hex[index]);
                    current_datetime_string_elements_hex += ":";
                }
                current_datetime_string_elements_hex += Convert.ToString(current_time_hex[2]);
                current_datetime_string_elements_hex += " ";
                current_datetime_string_elements_hex += current_datetime_string_elements[2];
                Console.WriteLine("Hexadecimal: " + current_datetime_string_elements_hex);
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                Console.Write("Binary: ");
                int integer;
                for(int index = 0; index < current_date_string.Length-1;index++)
                {
                    integer = Convert.ToInt32(current_date_string[index], 10);
                    Console.Write(Convert.ToString(integer, 2));
                    Console.Write("/");
                }
                integer = Convert.ToInt32(current_date_string[2], 10);
                Console.Write(Convert.ToString(integer, 2));
                Console.Write(" ");
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                for (int index = 0; index < current_time_string.Length - 1; index++)
                {
                    integer = Convert.ToInt32(current_time_string[index], 10);
                    Console.Write(Convert.ToString(integer, 2));
                    Console.Write(":");
                }
                integer = Convert.ToInt32(current_time_string[2], 10);
                Console.Write(Convert.ToString(integer, 2));
                Console.Write(" ");
                Console.Write(current_datetime_string_elements[2]);
                Console.Write("\n");
                Console.Write("\n");

                //Console.WriteLine(current_time_string[2]);
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        /*static int someFunction(int someNumber)
        {
            return someNumber * 2;
        }*/

        static int[] convert_hex_to_string_array(string[] array) 
        {
            int[] hex_array = { -1, -1, -1 };
            for (int index = 0; index < array.Length; index++)
            {
                hex_array[index] = Convert.ToInt32(array[index], 16);
            }
            return hex_array;
        }
    }
}
