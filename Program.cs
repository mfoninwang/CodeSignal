using CodeSignal.DataStructure.Search;
using CodeSignal.DataStructure.Sort;
using CodeSignal.HackerRank;

//Console.WriteLine("Hello, World!");
//Console.WriteLine(AddBorder(new string[] { "abc", "ded" }));
//Console.WriteLine(CheckPalindrome("aabaa"));
//Console.WriteLine(AreSimilar(new int[] { 1, 2, 2 }, new int[] { 2, 1, 1 }));

//Console.WriteLine(CalPoints(new string[] { "5", "2", "C", "D", "+" }));
//Console.WriteLine(IsValid("()[]{}"));
//Console.WriteLine(alternatingSums(new int[] { 1, 2, 2 }));
//BFS();
//DiagDifference();

InterviewPreparationKit.CountingSort(new List<int> { 1, 1, 3, 2, 1 });



int[] sortedArr = BubbleSort.Sort(new int[] { 4, 3, 5, 2, 1 });

static bool CheckPalindrome(string inputString)
{
    //char [] CharArr = inputString.ToCharArray();
    //char [] revCharArray = inputString.Reverse().ToArray();

    //for (int i = 0; i < CharArr.Length; i++)
    //{
    //    if (CharArr[i] != revCharArray[i])
    //        return false;
    //}
    //return true;

    return inputString.SequenceEqual(inputString.Reverse());
}

static int[] alternatingSums(int[] a)
{
    int team1 = 0;
    int team2 = 0;

    for (int i = 1; i <= a.Length; i += 2)
    {
        team1 += a[i - 1];
        team2 += i == a.Length ? 0 : a[i];
    }

    // alternative solution

    //int position = 1;
    //while (position <= a.Length)
    //{
    //    team1 += a[position - 1]; // odd position
    //    team2 += position == a.Length ? 0 : a[position]; // even position
    //    position += 2;
    //}

    int[] result = new int[2] { team1, team2 };

    return result;
}

static string[] AddBorder(string[] picture)
{
    int len = picture[0].Length + 2;
    string rep = string.Concat(Enumerable.Repeat("*", len));

    string[] result = new string[] { rep };
    for (int i = 0; i < picture.Length; i++)
    {
        string newStr = $"*{picture[i]}*";
        result = result.Append(newStr).ToArray();
    }

    result = result.Append(rep).ToArray(); ;
    return result;
}

static bool AreSimilar1(int[] a, int[] b)
{
    if (a.SequenceEqual(b)) return true;

    for (int i = 0; i < b.Length; i++)
    {
        int temp = b[i];
        int[] newArr = new int[b.Length];

        for (int j = 0; j < b.Length; j++)
        {
            newArr[i] = newArr[j];
            newArr[j] = temp;

            if (a.SequenceEqual(newArr)) return true;
            b.CopyTo(newArr, 0); // reset array

            //Array.Copy(b, i, newArr, 0, b.Length); // reset array
        }
    }

    return false;
}

static bool AreSimilar(int[] a, int[] b)
{
    var _list = b.ToList();


    for (int i = 0; i < a.Length; i++)
    {
        if (_list.Contains(a[i])) _list.Remove(a[i]);
    }

    int _flag = 0;
    for (int i = 0; i < a.Length; i++)
    {
        if (a[i] != b[i]) _flag++;
    }

    return !_list.Any() && _flag < 3;
}


// ["5", "2", "C", "D", "+"]
static int CalPoints(string[] ops)
{
    List<int> resultList = new();
    for (int i = 0; i < ops.Length; i++)
    {
        switch (ops[i])
        {
            case "D":
                int newScore = 2 * resultList.Last();
                resultList.Add(newScore);
                break;
            case "C":
                resultList.RemoveAt(resultList.Count - 1);
                break;
            case "+":
                int newAdd = resultList.TakeLast(2).Sum();
                resultList.Add(newAdd);
                break;
            default:
                resultList.Add(int.Parse(ops[i]));
                break;
        }
    }

    return resultList.Sum();
}

// "{ [ ( ) ] }" - valid 
// "( ) { [ } ( ) ] " - Invalid
static bool IsValid(string s)
{
    if (s.Length % 2 != 0) return false;
    if (s.Count(x => x == '(') != s.Count(x => x == ')')) return false;
    if (s.Count(x => x == '{') != s.Count(x => x == '}')) return false;
    if (s.Count(x => x == '[') != s.Count(x => x == ']')) return false;

    int len = s.Length, count = 0;

    LinkedList<string> linkedlist = new();


    while (count <= len / 2)
    {
        if (s.IndexOf('{') == s.IndexOf('}') - 1)
            s = s.Remove(s.IndexOf('{'), 2);

        if (s.IndexOf('[') == s.IndexOf(']') - 1)
            s = s.Remove(s.IndexOf('['), 2);

        if (s.IndexOf('(') == s.IndexOf(')') - 1)

            s = s.Remove(s.IndexOf('('), 2);

        if (s.Length == 0) return true;
        count++;
    }

    return s.Length == 0;
}

static void BFS()
{
    BreathFirstSearch tree = new();

    tree.root = new Node(1);
    tree.root.Left = new Node(2);
    tree.root.Right = new Node(3);
    tree.root.Left.Left = new Node(4);
    tree.root.Left.Right = new Node(5);
    tree.root.Right.Left = new Node(6);
    tree.root.Right.Right = new Node(7);

    Console.WriteLine("BFS traversal of tree is ");

    tree.PrintLevelOrder();
    Console.WriteLine();
}

static void MinMaxSum()
{
    List<int> list = new() { 254961783, 604179258, 462517083, 967304281, 860273491 };
    list.Sort();
    List<int> distinctList = list.Distinct().ToList();

    foreach (var item in distinctList)
    {
        if (list.Count(x => x == item) > 1) Console.WriteLine(" Unique item is {0} {1}", item);
    };

    long minSum = list.Take(4).Sum(x => Convert.ToInt64(x));
    Int64 maxSum = list.TakeLast(4).Sum(x => Convert.ToInt64(x));

    Console.WriteLine("{0} {1}", minSum, maxSum);
}

static void DiagDifference()
{
    int n = Convert.ToInt32(Console.ReadLine().Trim());

    List<List<int>> arr = new List<List<int>>();

    for (int i = 0; i < n; i++)
    {
        arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
    }

    int result = InterviewPreparationKit.DiagonalDifference(arr);

    Console.WriteLine(result);
}

