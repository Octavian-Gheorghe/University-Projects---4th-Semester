using Lab2___Data_Sorting_Module.Controllers;
using Lab2___Data_Sorting_Module.Sorting_Algorithm;
using System;
using System.Diagnostics;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Lab2___Data_Sorting_Module
{
    static class ShuffleClass
    {
        private static Random random = new Random();

        public static void ShuffleList<T>(this IList<T> list)
        {
            int ListLength = list.Count;
            while (ListLength > 1)
            {
                ListLength--;
                int randomIndex = random.Next(ListLength + 1);
                T value = list[randomIndex];
                list[randomIndex] = list[ListLength];
                list[ListLength] = value;
            }
        }
    }
    internal class Program
    {
        static bool CompareListsOfUsers(List<FacebookAccount> list1, List<FacebookAccount> list2)
        {
            for (int index = 0; index < list1.Count; index++)
            {
                if (list1[index].Username != list2[index].Username ||
                    list1[index].Email != list2[index].Email ||
                    list1[index].Password != list2[index].Password ||
                        list1[index].Age != list2[index].Age)
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //SETUP
            List<int> IntegerList = new List<int> { 42, 19, 73, 56, 88, 5, 29, 67, 12, 41, 93, 25, 60, 38, 72, 15, 83, 48, 10, 64, 27, 54, 36, 77, 9, 50, 22, 68, 91, 33 };
            List<int> IntegerListCopy = new List<int>(IntegerList);
            string[] StringArray = {"abc", "ABC", "asdgsayudjhbae", "sadbyauewkqjdxh", "absfyuewqghubfgqhj", "nbueyjqbkuchsauobkc h", "hqywdgjasbdbwqjlbdhqj", "fasgdghwb"};
            string[] OrderedString = { "abc", "ABC", "asdgsayudjhbae", "sadbyauewkqjdxh", "absfyuewqghubfgqhj", "nbueyjqbkuchsauobkc h", "hqywdgjasbdbwqjlbdhqj", "fasgdghwb" };
            Array.Sort(OrderedString);
            FacebookAccount f1 = new FacebookAccount("Lp9sRQa2kF", "john.doe123@example.com", "K@p7r&dX2!", 47);
            FacebookAccount f2 = new FacebookAccount("h3GmN8dWxJ", "alice.smith789@gmail.com", "P#l9sA!qW3", 63);
            FacebookAccount f3 = new FacebookAccount("bZu7yYvQcL", "samuel.jones456@hotmail.com", "Y^o6u*R8oP", 31);
            FacebookAccount f4 = new FacebookAccount("tR5oP2eQ1h", "emily.white22@yahoo.com", "Z!x2y#9T1", 55);
            FacebookAccount f5 = new FacebookAccount("XfA6nU4iKz", "chris.miller999@outlook.com", "B@3s!LpQ8", 22);
            FacebookAccount f6 = new FacebookAccount("mD8lO7gHsQ", "lisa.brown1234@gmail.com", "M%a6sH2eR", 76);
            FacebookAccount f7 = new FacebookAccount("vI1wE9rYpZ", "mark.wilson77@yahoo.com", "7wD!9oXzR", 40);
            FacebookAccount f8 = new FacebookAccount("kT3cN6uS2R", "jessica.green555@hotmail.com", "G*4tE1c@h", 59);
            FacebookAccount f9 = new FacebookAccount("qB4pL5jG7a", "robert.jenkins22@example.com", "F#5i2b&oL", 27);
            FacebookAccount f10 = new FacebookAccount("oF2eV9xP6u", "olivia.taylor888@gmail.com", "D^r1aG7oN", 71);
            List<FacebookAccount> listOfUsers = new List<FacebookAccount> { f1, f2, f3, f4, f5, f6, f7, f8, f9, f10 };
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Repository<int> IntegerListRepo = new Repository<int>(IntegerList);
            Repository<string> StringArrayRepo = new Repository<string>(StringArray);
            Repository<FacebookAccount> FacebookAccountRepository = new Repository<FacebookAccount>(listOfUsers);
            ValueTypeStringController<int> integerListController;
            ValueTypeStringController<string> stringArrayController;
            FacebookAccountController facebookAccountController;
            integerListController = new ValueTypeStringController<int>(IntegerListRepo);
            stringArrayController = new ValueTypeStringController<string>(StringArrayRepo);
            facebookAccountController = new FacebookAccountController(FacebookAccountRepository);
            List<FacebookAccount> facebookAccountsDeepCopy = facebookAccountController.Repository.RepositoryList.ConvertAll(account => new FacebookAccount(account.Username, account.Email, account.Password, account.Age));
            //facebookAccountsDeepCopy = facebookAccountsDeepCopy.OrderBy(account => account.Username).ToList();
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///TESTS FOR INTEGER LIST (checking time)
            ///integerListController.PrintList();

            //make sure to modify the filepath for the specific user, as i do not think it will work otherwise (nevertheless, these are just tests that end up having no significance)
            string folderPath = Directory.GetCurrentDirectory();
            string fileName = "TimeTakenBySorts.txt";
            string filepath = "C:\\Users\\Octavian\\Desktop\\Software Engineering\\Projects\\Lab2 - Data Sorting Module\\Lab2 - Data Sorting Module\\TimeTakenBySorts.txt";
                //Path.Combine(folderPath, fileName);
            //Each time, the steps are:
            /*
             * We modify the controller list to the copy we made at the beginning, such that each sorting is done on the same list
             * We create a stopwatch used to track how long it takes for each sort. The stopwatch begins before we do the sort function and ends immediately after
             * We print the time taken for the specific sort (if asked, we will also show that the sorting is succesful, otherwise, we comment the print function)
             * We log into the txt file how long each sorting took
             */
            //Bubble sort
            //Avg complexity: O(n^2)
            using (StreamWriter writer = File.AppendText(filepath))
            {
                writer.WriteLine("======================================================================================================================================");
            }

            integerListController.Repository.RepositoryList = IntegerListCopy;
            Stopwatch BubbleWatch = new Stopwatch(); 
            BubbleWatch.Start();
            integerListController.BubbleSort();
            BubbleWatch.Stop();
            Console.WriteLine($"Time taken for a bubble sort of integers: {BubbleWatch}ms");
            using (StreamWriter writer = File.AppendText(filepath))
            {
                writer.WriteLine($"Time taken for a bubble sort of integers: {BubbleWatch}ms");
            }
            ///integerListController.PrintList();
            
            //Gnome sort
            //Avg complexity: O(n^2)
            integerListController.Repository.RepositoryList = IntegerListCopy;
            Stopwatch GnomeWatch = new Stopwatch();
            GnomeWatch.Start();
            integerListController.GnomeSort();
            GnomeWatch.Stop();
            Console.WriteLine($"Time taken for a gnome sort of integers: {GnomeWatch}ms");
            using (StreamWriter writer = File.AppendText(filepath))
            {
                writer.WriteLine($"Time taken for a gnome sort of integers: {GnomeWatch}ms");
            }
            ///integerListController.PrintList();
            
            //Heap sort
            //Avg complexity: O(n * log(n))
            integerListController.Repository.RepositoryList = IntegerListCopy;
            Stopwatch HeapWatch = new Stopwatch();
            HeapWatch.Start();
            integerListController.HeapSort();
            HeapWatch.Stop();
            Console.WriteLine($"Time taken for a heap sort of integers: {HeapWatch}ms");
            using (StreamWriter writer = File.AppendText(filepath))
            {
                writer.WriteLine($"Time taken for a heap sort of integers: {HeapWatch}ms");
            }
            ///integerListController.PrintList();
            
            //Merge sort
            //Avg complexity: O(n * log(n))
            integerListController.Repository.RepositoryList = IntegerListCopy;
            Stopwatch MergeWatch = new Stopwatch();
            MergeWatch.Start();
            integerListController.MergeSort();
            MergeWatch.Stop();
            Console.WriteLine($"Time taken for a merge sort of integers: {MergeWatch}ms");
            using (StreamWriter writer = File.AppendText(filepath))
            {
                writer.WriteLine($"Time taken for a merge sort of integers: {MergeWatch}ms");
            }
            ///integerListController.PrintList();
            
            //Quick sort
            //Avg complexity: O(n * log(n))
            integerListController.Repository.RepositoryList = IntegerListCopy;
            Stopwatch QuickWatch = new Stopwatch();
            QuickWatch.Start();
            integerListController.QuickSort();
            QuickWatch.Stop();
            Console.WriteLine($"Time taken for a quick sort of integers: {QuickWatch}ms");
            using (StreamWriter writer = File.AppendText(filepath))
            {
                writer.WriteLine($"Time taken for a quick sort of integers: {QuickWatch}ms");
            }
            ///integerListController.PrintList();
            
            using (StreamWriter writer = File.AppendText(filepath))
            {
                writer.WriteLine("======================================================================================================================================");
            }
            Console.WriteLine();
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///TESTS FOR STRING ARRAYS (checking sorting accuracy)
            /*Each time, the steps are the following:
             * We shuffle the array as to have a new, fresh array ready to be sorted again
             * We apply each of the sorts on the array
             * We compare that array sorted by a function to an array that was sorted at the beginning with the system function Array.Sort
             * We print out a message depending on wether the sort was succesful or not
             * We print the sorted array (victory lap)
             */
            Console.WriteLine("The original String");
            stringArrayController.PrintArray();
            Console.WriteLine();

            //Bubble Sort
            Random.Shared.Shuffle(stringArrayController.Repository.RepositoryArray);
            stringArrayController.BubbleSort();
            if (stringArrayController.Repository.RepositoryArray.SequenceEqual(OrderedString))
                Console.WriteLine("The string array is succesfully sorted by the bubble sort");
            else
                Console.WriteLine("Failure");
            stringArrayController.PrintArray();
            Console.WriteLine();

            //Gnome Sort
            Random.Shared.Shuffle(stringArrayController.Repository.RepositoryArray);
            stringArrayController.GnomeSort();
            if (stringArrayController.Repository.RepositoryArray.SequenceEqual(OrderedString))
                Console.WriteLine("The string array is succesfully sorted by the gnome sort");
            else
                Console.WriteLine("Failure");
            stringArrayController.PrintArray();
            Console.WriteLine();

            //Heap Sort
            Random.Shared.Shuffle(stringArrayController.Repository.RepositoryArray);
            stringArrayController.HeapSort();
            if (stringArrayController.Repository.RepositoryArray.SequenceEqual(OrderedString))
                Console.WriteLine("The string array is succesfully sorted by the heap sort");
            else
                Console.WriteLine("Failure");
            stringArrayController.PrintArray();
            Console.WriteLine();

            //Merge Sort
            Random.Shared.Shuffle(stringArrayController.Repository.RepositoryArray);
            stringArrayController.MergeSort();
            if (stringArrayController.Repository.RepositoryArray.SequenceEqual(OrderedString))
                Console.WriteLine("The string array is succesfully sorted by the merge sort");
            else
                Console.WriteLine("Failure");
            stringArrayController.PrintArray();
            Console.WriteLine();

            //Quick Sort
            Random.Shared.Shuffle(stringArrayController.Repository.RepositoryArray);
            stringArrayController.QuickSort();
            if (stringArrayController.Repository.RepositoryArray.SequenceEqual(OrderedString))
                Console.WriteLine("The string array is succesfully sorted by the quick sort");
            else
                Console.WriteLine("Failure");
            stringArrayController.PrintArray();
            Console.WriteLine();
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///TESTS FOR THE FACEBOOK ACCOUNT OBJECT LIST
            /*Here, we want to emphasize how the sorting change based on what field we are sorting on
             * We shuffle the elements of the lists in order to more thoroughly check the sorting process
             * We will show the sorted lists, but only by bubble sort (if asked, we will show for the others too)
             * We then sort a deepcopied list with the same elements, based on the field we just compared our own repository on using OrderBy
             * we check wether the order of the element in the repo and the deepcopied list is the same, and if so, we have succeded
             */
            //Bubble Sort - Username
            Console.WriteLine("Bubble Sort - Username");
            ShuffleClass.ShuffleList(stringArrayController.Repository.RepositoryArray);
            facebookAccountController.BubbleSort(facebookAccountController.CompareByUsername);
            facebookAccountsDeepCopy = facebookAccountsDeepCopy.OrderBy(account => account.Username).ToList();
            facebookAccountController.PrintList();
            if (CompareListsOfUsers(facebookAccountsDeepCopy, facebookAccountController.Repository.RepositoryList) == false)
                Console.WriteLine("Failure");
            else
                Console.WriteLine("List of users correctly sorted by this field");
            Console.WriteLine();

            //Bubble Sort - Email
            Console.WriteLine("Bubble Sort - Email");
            ShuffleClass.ShuffleList(stringArrayController.Repository.RepositoryArray);
            facebookAccountController.BubbleSort(facebookAccountController.CompareByEmail);
            facebookAccountsDeepCopy = facebookAccountsDeepCopy.OrderBy(account => account.Email).ToList();
            facebookAccountController.PrintList();
            if (CompareListsOfUsers(facebookAccountsDeepCopy, facebookAccountController.Repository.RepositoryList) == false)
                Console.WriteLine("Failure");
            else
                Console.WriteLine("List of users correctly sorted by this field");
            Console.WriteLine();

            //Bubble Sort - Passwoerd
            Console.WriteLine("Bubble Sort - Password");
            ShuffleClass.ShuffleList(stringArrayController.Repository.RepositoryArray);
            facebookAccountController.BubbleSort(facebookAccountController.CompareByPassword);
            facebookAccountsDeepCopy = facebookAccountsDeepCopy.OrderBy(account => account.Password).ToList();
            facebookAccountController.PrintList();
            if (CompareListsOfUsers(facebookAccountsDeepCopy, facebookAccountController.Repository.RepositoryList) == false)
                Console.WriteLine("Failure");
            else
                Console.WriteLine("List of users correctly sorted by this field");
            Console.WriteLine();

            //Bubble Sort - Age
            Console.WriteLine("Bubble Sort - Age");
            ShuffleClass.ShuffleList(stringArrayController.Repository.RepositoryArray);
            facebookAccountController.BubbleSort(facebookAccountController.CompareByAge);
            facebookAccountsDeepCopy = facebookAccountsDeepCopy.OrderBy(account => account.Age).ToList();
            facebookAccountController.PrintList();
            if (CompareListsOfUsers(facebookAccountsDeepCopy, facebookAccountController.Repository.RepositoryList) == false)
                Console.WriteLine("Failure");
            else
                Console.WriteLine("List of users correctly sorted by this field");
            Console.WriteLine();

            //in case i am asked to prove that convertall also creates a deepcopy
            /*foreach(FacebookAccount account in facebookAccountsDeepCopy)
            {
                Console.WriteLine(account.Username);
            }*/

            //Gnome Sort - Username
            Console.WriteLine("Gnome Sort - Username");
            ShuffleClass.ShuffleList(stringArrayController.Repository.RepositoryArray);
            facebookAccountController.GnomeSort(facebookAccountController.CompareByUsername);
            facebookAccountsDeepCopy = facebookAccountsDeepCopy.OrderBy(account => account.Username).ToList();
            if (CompareListsOfUsers(facebookAccountsDeepCopy, facebookAccountController.Repository.RepositoryList) == false)
                Console.WriteLine("Failure");
            else
                Console.WriteLine("List of users correctly sorted by this field");

            //Gnome Sort - Email
            Console.WriteLine("Gnome Sort - Email");
            ShuffleClass.ShuffleList(stringArrayController.Repository.RepositoryArray);
            facebookAccountController.GnomeSort(facebookAccountController.CompareByEmail);
            facebookAccountsDeepCopy = facebookAccountsDeepCopy.OrderBy(account => account.Email).ToList();
            if (CompareListsOfUsers(facebookAccountsDeepCopy, facebookAccountController.Repository.RepositoryList) == false)
                Console.WriteLine("Failure");
            else
                Console.WriteLine("List of users correctly sorted by this field");

            //Gnome Sort - Password
            Console.WriteLine("Gnome Sort - Email");
            ShuffleClass.ShuffleList(stringArrayController.Repository.RepositoryArray);
            facebookAccountController.HeapSort(facebookAccountController.CompareByPassword);
            facebookAccountsDeepCopy = facebookAccountsDeepCopy.OrderBy(account => account.Password).ToList();
            if (CompareListsOfUsers(facebookAccountsDeepCopy, facebookAccountController.Repository.RepositoryList) == false)
                Console.WriteLine("Failure");
            else
                Console.WriteLine("List of users correctly sorted by this field");

            //Gnome Sort - Age
            Console.WriteLine("Gnome Sort - Email");
            ShuffleClass.ShuffleList(stringArrayController.Repository.RepositoryArray);
            facebookAccountController.HeapSort(facebookAccountController.CompareByAge);
            facebookAccountsDeepCopy = facebookAccountsDeepCopy.OrderBy(account => account.Age).ToList();
            if (CompareListsOfUsers(facebookAccountsDeepCopy, facebookAccountController.Repository.RepositoryList) == false)
                Console.WriteLine("Failure");
            else
                Console.WriteLine("List of users correctly sorted by this field");


            //Heap Sort - Username
            Console.WriteLine("Heap Sort - Username");
            ShuffleClass.ShuffleList(stringArrayController.Repository.RepositoryArray);
            facebookAccountController.HeapSort(facebookAccountController.CompareByUsername);
            facebookAccountsDeepCopy = facebookAccountsDeepCopy.OrderBy(account => account.Username).ToList();
            if (CompareListsOfUsers(facebookAccountsDeepCopy, facebookAccountController.Repository.RepositoryList) == false)
                Console.WriteLine("Failure");
            else
                Console.WriteLine("List of users correctly sorted by this field");

            //Heap Sort - Email
            Console.WriteLine("Heap Sort - Email");
            ShuffleClass.ShuffleList(stringArrayController.Repository.RepositoryArray);
            facebookAccountController.HeapSort(facebookAccountController.CompareByEmail);
            facebookAccountsDeepCopy = facebookAccountsDeepCopy.OrderBy(account => account.Email).ToList();
            if (CompareListsOfUsers(facebookAccountsDeepCopy, facebookAccountController.Repository.RepositoryList) == false)
                Console.WriteLine("Failure");
            else
                Console.WriteLine("List of users correctly sorted by this field");

            //Heap Sort - Password
            Console.WriteLine("Heap Sort - Password");
            ShuffleClass.ShuffleList(stringArrayController.Repository.RepositoryArray);
            facebookAccountController.HeapSort(facebookAccountController.CompareByPassword);
            facebookAccountsDeepCopy = facebookAccountsDeepCopy.OrderBy(account => account.Password).ToList();
            if (CompareListsOfUsers(facebookAccountsDeepCopy, facebookAccountController.Repository.RepositoryList) == false)
                Console.WriteLine("Failure");
            else
                Console.WriteLine("List of users correctly sorted by this field");

            //Heap Sort - Age
            Console.WriteLine("Heap Sort - Age");
            ShuffleClass.ShuffleList(stringArrayController.Repository.RepositoryArray);
            facebookAccountController.HeapSort(facebookAccountController.CompareByAge);
            facebookAccountsDeepCopy = facebookAccountsDeepCopy.OrderBy(account => account.Age).ToList();
            if (CompareListsOfUsers(facebookAccountsDeepCopy, facebookAccountController.Repository.RepositoryList) == false)
                Console.WriteLine("Failure");
            else
                Console.WriteLine("List of users correctly sorted by this field");


            //Merge Sort - Username
            Console.WriteLine("Merge Sort - Username");
            ShuffleClass.ShuffleList(stringArrayController.Repository.RepositoryArray);
            facebookAccountController.MergeSort(facebookAccountController.CompareByUsername);
            facebookAccountsDeepCopy = facebookAccountsDeepCopy.OrderBy(account => account.Username).ToList();
            if (CompareListsOfUsers(facebookAccountsDeepCopy, facebookAccountController.Repository.RepositoryList) == false)
                Console.WriteLine("Failure");
            else
                Console.WriteLine("List of users correctly sorted by this field");

            //Merge Sort - Email
            Console.WriteLine("Merge Sort - Email");
            ShuffleClass.ShuffleList(stringArrayController.Repository.RepositoryArray);
            facebookAccountController.MergeSort(facebookAccountController.CompareByEmail);
            facebookAccountsDeepCopy = facebookAccountsDeepCopy.OrderBy(account => account.Email).ToList();
            if (CompareListsOfUsers(facebookAccountsDeepCopy, facebookAccountController.Repository.RepositoryList) == false)
                Console.WriteLine("Failure");
            else
                Console.WriteLine("List of users correctly sorted by this field");

            //Merge Sort - Password
            Console.WriteLine("Merge Sort - Password");
            ShuffleClass.ShuffleList(stringArrayController.Repository.RepositoryArray);
            facebookAccountController.MergeSort(facebookAccountController.CompareByPassword);
            facebookAccountsDeepCopy = facebookAccountsDeepCopy.OrderBy(account => account.Password).ToList();
            if (CompareListsOfUsers(facebookAccountsDeepCopy, facebookAccountController.Repository.RepositoryList) == false)
                Console.WriteLine("Failure");
            else
                Console.WriteLine("List of users correctly sorted by this field");

            //Merge Sort - Age
            Console.WriteLine("Merge Sort - Age");
            ShuffleClass.ShuffleList(stringArrayController.Repository.RepositoryArray);
            facebookAccountController.MergeSort(facebookAccountController.CompareByAge);
            facebookAccountsDeepCopy = facebookAccountsDeepCopy.OrderBy(account => account.Age).ToList();
            if (CompareListsOfUsers(facebookAccountsDeepCopy, facebookAccountController.Repository.RepositoryList) == false)
                Console.WriteLine("Failure");
            else
                Console.WriteLine("List of users correctly sorted by this field");


            //Quick Sort - Username
            Console.WriteLine("Quick Sort - Username");
            ShuffleClass.ShuffleList(stringArrayController.Repository.RepositoryArray);
            facebookAccountController.QuickSort(facebookAccountController.CompareByUsername);
            facebookAccountsDeepCopy = facebookAccountsDeepCopy.OrderBy(account => account.Username).ToList();
            if (CompareListsOfUsers(facebookAccountsDeepCopy, facebookAccountController.Repository.RepositoryList) == false)
                Console.WriteLine("Failure");
            else
                Console.WriteLine("List of users correctly sorted by this field");

            //Quick Sort - Email
            Console.WriteLine("Quick Sort - Email");
            ShuffleClass.ShuffleList(stringArrayController.Repository.RepositoryArray);
            facebookAccountController.QuickSort(facebookAccountController.CompareByEmail);
            facebookAccountsDeepCopy = facebookAccountsDeepCopy.OrderBy(account => account.Email).ToList();
            if (CompareListsOfUsers(facebookAccountsDeepCopy, facebookAccountController.Repository.RepositoryList) == false)
                Console.WriteLine("Failure");
            else
                Console.WriteLine("List of users correctly sorted by this field");

            //Quick Sort - Password
            Console.WriteLine("Quick Sort - Password");
            ShuffleClass.ShuffleList(stringArrayController.Repository.RepositoryArray);
            facebookAccountController.QuickSort(facebookAccountController.CompareByPassword);
            facebookAccountsDeepCopy = facebookAccountsDeepCopy.OrderBy(account => account.Password).ToList();
            if (CompareListsOfUsers(facebookAccountsDeepCopy, facebookAccountController.Repository.RepositoryList) == false)
                Console.WriteLine("Failure");
            else
                Console.WriteLine("List of users correctly sorted by this field");

            //Quick Sort - Age
            Console.WriteLine("Quick Sort - Age");
            ShuffleClass.ShuffleList(stringArrayController.Repository.RepositoryArray);
            facebookAccountController.QuickSort(facebookAccountController.CompareByAge);
            facebookAccountsDeepCopy = facebookAccountsDeepCopy.OrderBy(account => account.Age).ToList();
            if (CompareListsOfUsers(facebookAccountsDeepCopy, facebookAccountController.Repository.RepositoryList) == false)
                Console.WriteLine("Failure");
            else
                Console.WriteLine("List of users correctly sorted by this field");
        }
    }
}
