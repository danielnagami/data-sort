using DataSort.Models;
using DataSort.Services;
using DataSort.Services.Sort;
using System;
using System.Collections.Generic;

namespace DataSort
{
    class Program
    {
        static IList<MenuItem> menuItems;
        static Image[] imageList;
        static void Main(string[] args)
        {
            ISort itemSelected;
            menuItems = GetMenuItems();

            while (true)
            {
                imageList = JSONLoader.ReadJSON();

                PrintMenuItems(menuItems);
                var option = Console.ReadLine();

                int.TryParse(option, out int optionValue);

                if (optionValue == 0)
                {
                    break;
                }

                if (optionValue > menuItems.Count)
                {
                    break;
                }

                itemSelected = Execute(optionValue);
                Console.ReadKey();
            }
        }

        private static ISort Execute(int optionValue)
        {
            ISort selectedItem;
            MenuItem menuItem = menuItems[optionValue - 1];
            Type classType = menuItem.ClassType;
            selectedItem = (ISort)Activator.CreateInstance(classType);

            Console.WriteLine();
            string title = $"Executing: {menuItem.Title}";
            Console.WriteLine(title);
            Console.WriteLine(new string('=', title.Length));

            int[] array = { };

            if (imageList != null)
                array = JSONLoader.GetTheArray(1, imageList);

            selectedItem.Execute(array, 0, array.Length - 1);

            if (!(selectedItem is IMenuOption))
                AscendingOrDescending(array);

            Console.WriteLine();
            Console.WriteLine("Tap something to continue...");
            return selectedItem;
        }

        private static void AscendingOrDescending(int[] array)
        {
            Console.WriteLine("Do you want to print it by ascending or descending?\nDigit 1 for ascending and 2 for descending");
            string orderBy = Console.ReadLine();
            switch (orderBy)
            {
                case "1":
                    for (int i = 0; i < array.Length; i++)
                    {
                        Console.WriteLine(array[i]);
                    };
                    break;
                case "2":
                    for (int i = array.Length - 1; i >= 0; i--)
                    {
                        Console.WriteLine(array[i]);
                    };
                    break;
                default:
                    AscendingOrDescending(array);
                    break;
            }
        }

        private static void PrintMenuItems(IList<MenuItem> menuItems)
        {
            int i = 1;
            Console.WriteLine("Chose an option");
            Console.WriteLine("===================");
            Console.WriteLine("0 - Exit");
            foreach (var menuItem in menuItems)
            {
                Console.WriteLine((i++).ToString() + " - " + menuItem.Title);
            }
        }

        private static IList<MenuItem> GetMenuItems()
        {
            return new List<MenuItem>
            {
                new MenuItem("Generate new JSON", typeof(JSONGenerator)),
                new MenuItem("Quick Sort", typeof(QuickSort)),
                new MenuItem("Merge Sort", typeof(MergeSort)),
                new MenuItem("Selection Sort", typeof(SelectionSort))
            };
        }
    }
    class MenuItem
    {
        public MenuItem(string title, Type classType)
        {
            Title = title;
            ClassType = classType;
        }

        public string Title { get; set; }
        public Type ClassType { get; set; }
    }
}