using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab2___Data_Sorting_Module
{
    public class BubbleSort<T> : ISorter<T> where T : IComparable<T>
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///FOR ARRAYS OF VALUE TYPES AND STRINGS
        public void SortAscending(T[] ArrayToSort)
        {
            bool sorted = false;
            int numberOfElements = ArrayToSort.Length; 
            while(sorted != true)
            {
                sorted = true;
                for (int index = 0; index < numberOfElements - 1; index++)
                {
                    if (ArrayToSort[index].CompareTo(ArrayToSort[index + 1]) > 0)
                    {
                        // Swap elements if they are in the wrong order
                        T temporaryVariableForSwitchingValues = ArrayToSort[index];
                        ArrayToSort[index] = ArrayToSort[index + 1];
                        ArrayToSort[index + 1] = temporaryVariableForSwitchingValues;
                        sorted = false;
                    }
                }
            }
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///FOR LISTS OF VALUE TYPES AND STRINGS
        public void SortAscending(List<T> ListToSort)
        {

            bool sorted = false;
            int numberOfElements = ListToSort.Count;
            while (sorted != true)
            {
                sorted = true;
                for (int index = 0; index < numberOfElements - 1; index++)
                {
                    if (ListToSort[index].CompareTo(ListToSort[index + 1]) > 0)
                    {
                        T temporaryVariableForSwitchingValues = ListToSort[index];
                        ListToSort[index] = ListToSort[index + 1];
                        ListToSort[index + 1] = temporaryVariableForSwitchingValues;
                        sorted = false;
                    }
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///FOR ARRAYS OF OBJECT TYPES
        public void SortAscending(T[] ArrayToSort, Func<T, T, int> comparisonFunction)
        {
            bool sorted = false;
            int numberOfElements = ArrayToSort.Length; 
            while(sorted != true)
            {
                sorted = true;
                for (int index = 0; index<numberOfElements - 1; index++)
                {
                    if (comparisonFunction(ArrayToSort[index], ArrayToSort[index + 1]) > 0)
                    {
                        // Swap elements if they are in the wrong order
                        T temporaryVariableForSwitchingValues = ArrayToSort[index];
                        ArrayToSort[index] = ArrayToSort[index + 1];
                        ArrayToSort[index + 1] = temporaryVariableForSwitchingValues;
                        sorted = false;
                    }
}
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///FOR LISTS OF OBJECT TYPES
        public void SortAscending(List<T> ListToSort, Func<T, T, int> comparisonFunction)
        {

            bool sorted = false;
            int numberOfElements = ListToSort.Count;
            while (sorted != true)
            {
                sorted = true;
                for (int index = 0; index < numberOfElements - 1; index++)
                {
                    if (comparisonFunction(ListToSort[index], ListToSort[index + 1]) > 0)
                    {
                        T temporaryVariableForSwitchingValues = ListToSort[index];
                        ListToSort[index] = ListToSort[index + 1];
                        ListToSort[index + 1] = temporaryVariableForSwitchingValues;
                        sorted = false;
                    }
                }
            }
        }
    }
}
