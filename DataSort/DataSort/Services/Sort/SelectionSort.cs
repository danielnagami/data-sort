namespace DataSort.Services.Sort
{
    public class SelectionSort : ISort
    {
        public void Execute(int[] array, int v1 = 0, int v2 = 0)
        {
            int smallest;
            for (int i = 0; i < array.Length - 1; i++)
            {
                smallest = i;

                for (int index = i + 1; index < array.Length; index++)
                {
                    if (array[index] < array[smallest])
                    {
                        smallest = index;
                    }
                }
                Swap(i, smallest, array);
            }
        }

        private void Swap(int first, int second, int[] array)
        {
            int temporary = array[first];
            array[first] = array[second];
            array[second] = temporary;
        }
    }
}
