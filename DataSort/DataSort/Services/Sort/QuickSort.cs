namespace DataSort.Services.Sort
{
    public class QuickSort : ISort
    {
        public  void Execute(int[] arr, int v1, int v2)
        {
            int down, high, middle, pivot, repository;
            down = v1;
            high = v2;
            middle = (int)((down + high) / 2);

            pivot = arr[middle];

            while (down <= high)
            {
                while (arr[down] < pivot)
                    down++;
                while (arr[high] > pivot)
                    high--;
                if (down < high)
                {
                    repository = arr[down];
                    arr[down++] = arr[high];
                    arr[high--] = repository;
                }
                else
                {
                    if (down == high)
                    {
                        down++;
                        high--;
                    }

                }
            }

            if (high > v1)
                Execute(arr, v1, high);
            if (down < v2)
                Execute(arr, down, v2);
        }
    }
}
