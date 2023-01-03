namespace CodeSignal.DataStructure.Sort
{
    public class SelectionSort
    {
        public static int[] Sort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int min = arr[i];
                int minIndex = 0;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < min)
                    {
                        min = arr[j];
                        minIndex = j;
                    }
                }
                arr[minIndex] = arr[i];
                arr[i] = min;
            }
            return arr;
        }
    }
}
