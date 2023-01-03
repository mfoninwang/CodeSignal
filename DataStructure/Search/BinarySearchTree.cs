namespace CodeSignal.DataStructure.Search;

public class BinarySearchTree
{
    public Node Search(Node root, int value)
    {
        if (root == null || root.Value == value)
        {
            return root;
        }

        if (value < root.Value)
        {
            return Search(root.Left, value);
        }

        return Search(root.Right, value);
    }
}

public class Node
{
    public Node(int value)
    {
        Value = value;
    }

    public Node Left { get; set; }
    public Node Right { get; set; }
    public int Value { get; set; }
}

public class BreathFirstSearch
{
    public Node root;

    public BreathFirstSearch()
    {
        //root = null;
    }

    public void PrintLevelOrder()
    {
        int i;
        int h = GetTotalLevel(root);

        for (i = 0; i < h; i++)
        {
            PrintGivenLevel(root, i);
        }
    }

    public int GetTotalLevel(Node node)
    {
        if (node == null)
        {
            return 0;
        }
        else
        {
            return 1 + Math.Max(GetTotalLevel(node.Left), GetTotalLevel(node.Right));
        }
    }

    void PrintGivenLevel(Node root, int level)
    {
        if (root == null)
            return;

        if (level == 0)
        {
            Console.WriteLine(root.Value + " ");
        }

        else if (level > 0)
        {
            PrintGivenLevel(root.Left, level - 1);
            PrintGivenLevel(root.Right, level - 1);
        }
    }

}