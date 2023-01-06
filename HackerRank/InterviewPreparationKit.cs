namespace CodeSignal.HackerRank
{
    public class InterviewPreparationKit
    {

        public static int DiagonalDifference(List<List<int>> arr)
        {
            int len = arr.Count;
            int sumLeft = 0;
            int sumRight = 0;

            for (int i = 0; i < len; i++)
            {
                sumRight += arr[i][i];
                sumLeft += arr[i][len - 1 - i];
            }

            return Math.Abs(sumLeft - sumRight);
        }

        public static List<int> CountingSort(List<int> arr)
        {
            int max = arr.Max();
            List<int> result = new(max);
            List<int> freqArr = new(100);

            for (int i = 0; i <= max; i++)
                result.Add(i);

            for (int i = 0; i < 100; i++)
            {
                freqArr.Add(0);
            }

            for (int i = 0; i < arr.Count; i++)
            {
                int index = result.FindIndex(x=>x==arr[i]);
                freqArr[index] = freqArr[index] + 1;
            }


            return freqArr;    
        }

        public static int TowerBreakers(int n, int m)
        {
            int[] towers = new int[n];

            for (int i = 0; i < n; i++)
            {
                towers[i] = m;
            }

            for (int i = 0; i < n; i++)
            {

                int y = towers[i] - 1;
            }
            return 0;
        }
    }


}
