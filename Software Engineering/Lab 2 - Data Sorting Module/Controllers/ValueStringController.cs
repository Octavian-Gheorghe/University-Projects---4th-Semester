using Lab2___Data_Sorting_Module.Sorting_Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2___Data_Sorting_Module.Controllers
{

    public class ValueTypeStringController<T> where T : IComparable<T>
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Repository<T> Repository { get; set; }
        public ValueTypeStringController(Repository<T> Repository)
        {
            this.Repository = Repository;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void PrintList()
        {
            foreach (var element in this.Repository.RepositoryList)
            {
                Console.Write($"{element}; ");
            }
            Console.WriteLine();
        }
        public void PrintArray()
        {
            foreach (var element in this.Repository.RepositoryArray)
            {
                Console.Write($"{element}; ");
            }
            Console.WriteLine();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///ARRAYS
        public void BubbleSort()
        {
            if (this.Repository.RepositoryArray != null)
            {
                ISorter<T> sorter = new BubbleSort<T>();
                sorter.SortAscending(this.Repository.RepositoryArray);
            }
            else
            {
                ISorter<T> sorter = new BubbleSort<T>();
                sorter.SortAscending(this.Repository.RepositoryList);
            }
        }

        public void GnomeSort()
        {
            if (this.Repository.RepositoryArray != null)
            {
                ISorter<T> sorter = new GnomeSort<T>();
                sorter.SortAscending(this.Repository.RepositoryArray);
            }
            else
            {
                ISorter<T> sorter = new GnomeSort<T>();
                sorter.SortAscending(this.Repository.RepositoryList);
            }
        }
        public void HeapSort()
        {
            if (this.Repository.RepositoryArray != null)
            {
                ISorter<T> sorter = new HeapSort<T>();
                sorter.SortAscending(this.Repository.RepositoryArray);
            }
            else
            {
                ISorter<T> sorter = new HeapSort<T>();
                sorter.SortAscending(this.Repository.RepositoryList);
            }
        }
        public void MergeSort()
        {
            if (this.Repository.RepositoryArray != null)
            {
                ISorter<T> sorter = new MergeSort<T>();
                sorter.SortAscending(this.Repository.RepositoryArray);
            }
            else
            {
                ISorter<T> sorter = new MergeSort<T>();
                sorter.SortAscending(this.Repository.RepositoryList);
            }
        }
        public void QuickSort()
        {
            if (this.Repository.RepositoryArray != null)
            {
                ISorter<T> sorter = new QuickSort<T>();
                sorter.SortAscending(this.Repository.RepositoryArray);
            }
            else
            {
                ISorter<T> sorter = new QuickSort<T>();
                sorter.SortAscending(this.Repository.RepositoryList);
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
