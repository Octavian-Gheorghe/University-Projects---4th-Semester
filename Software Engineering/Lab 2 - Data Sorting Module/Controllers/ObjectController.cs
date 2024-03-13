
using Lab2___Data_Sorting_Module.Sorting_Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2___Data_Sorting_Module.Controllers
{
    public class FacebookAccountController : IController<FacebookAccount>
    {
        public Repository<FacebookAccount> Repository { get; set; }
        public FacebookAccountController(Repository<FacebookAccount> Repository) 
        {
            this.Repository = Repository;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Func<FacebookAccount, FacebookAccount, int> compareByUsername = (Account1, Account2) => Account1.Username.CompareTo(Account2.Username);
        public Func<FacebookAccount, FacebookAccount, int> compareByPassword = (Account1, Account2) => Account1.Password.CompareTo(Account2.Password);
        public Func<FacebookAccount, FacebookAccount, int> compareByEmail = (Account1, Account2) => Account1.Email.CompareTo(Account2.Email);
        public Func<FacebookAccount, FacebookAccount, int> compareByAge = (Account1, Account2) => Account1.Age.CompareTo(Account2.Age);
        public Func<FacebookAccount, FacebookAccount, int> CompareByUsername
        {
            get { return compareByUsername; }
        }

        public Func<FacebookAccount, FacebookAccount, int> CompareByPassword
        {
            get { return compareByPassword; }
        }

        public Func<FacebookAccount, FacebookAccount, int> CompareByEmail
        {
            get { return compareByEmail; }
        }

        public Func<FacebookAccount, FacebookAccount, int> CompareByAge
        {
            get { return compareByAge; }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void PrintList()
        {
            Console.WriteLine("The elements are: ");
            foreach (var element in this.Repository.RepositoryList)
            {
                //the "password" string is just for another sorting function in this example
                Console.WriteLine($"FacebookAccount: {element.Username} // {element.Email} // {element.Age} // {element.Password}");
            }
        }
        public void PrintArray()
        {
            Console.WriteLine("The elements are: ");
            foreach (var element in this.Repository.RepositoryArray)
            {
                //the "password" string is just for another sorting function in this example
                Console.WriteLine($"FacebookAccount: {element.Username} // {element.Email} // {element.Age} // {element.Password}");
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///ARRAYS
        public void BubbleSort(Func<FacebookAccount, FacebookAccount,int> function)
        {
            if (this.Repository.RepositoryArray != null)
            {
                ISorter<FacebookAccount> sorter = new BubbleSort<FacebookAccount>();
                sorter.SortAscending(this.Repository.RepositoryArray, function);
            }
            else
            {
                ISorter<FacebookAccount> sorter = new BubbleSort<FacebookAccount>();
                sorter.SortAscending(this.Repository.RepositoryList, function);
            }
        }
        public void GnomeSort(Func<FacebookAccount, FacebookAccount, int> function)
        {
            if (this.Repository.RepositoryArray != null)
            {
                ISorter<FacebookAccount> sorter = new GnomeSort<FacebookAccount>();
                sorter.SortAscending(this.Repository.RepositoryArray, function);
            }
            else
            {
                ISorter<FacebookAccount> sorter = new GnomeSort<FacebookAccount>();
                sorter.SortAscending(this.Repository.RepositoryList, function);
            }
        }
        public void HeapSort(Func<FacebookAccount, FacebookAccount, int> function)
        {
            if (this.Repository.RepositoryArray != null)
            {
                ISorter<FacebookAccount> sorter = new HeapSort<FacebookAccount>();
                sorter.SortAscending(this.Repository.RepositoryArray, function);
            }
            else
            {
                ISorter<FacebookAccount> sorter = new HeapSort<FacebookAccount>();
                sorter.SortAscending(this.Repository.RepositoryList, function);
            }
        }
        public void MergeSort(Func<FacebookAccount, FacebookAccount, int> function)
        {
            if (this.Repository.RepositoryArray != null)
            {
                ISorter<FacebookAccount> sorter = new MergeSort<FacebookAccount>();
                sorter.SortAscending(this.Repository.RepositoryArray, function);
            }
            else
            {
                ISorter<FacebookAccount> sorter = new MergeSort<FacebookAccount>();
                sorter.SortAscending(this.Repository.RepositoryList, function);
            }
        }
        public void QuickSort(Func<FacebookAccount, FacebookAccount, int> function)
        {
            if (this.Repository.RepositoryArray != null)
            {
                ISorter<FacebookAccount> sorter = new QuickSort<FacebookAccount>();
                sorter.SortAscending(this.Repository.RepositoryArray, function);
            }
            else
            {
                ISorter<FacebookAccount> sorter = new QuickSort<FacebookAccount>();
                sorter.SortAscending(this.Repository.RepositoryList, function);
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
