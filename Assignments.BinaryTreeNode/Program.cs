namespace Assignments.BinaryTreeNode
{
    public class Program
    {
        private static void CalculateBranchSums(BinaryTreeNode node, int runningSum, List<int> sums)
        {
            if (node == null)
                return;

            int newRunningSum = runningSum + node.Value;

            if (node.Left == null && node.Right == null)
            {
                sums.Add(newRunningSum);
                return;
            }

            CalculateBranchSums(node.Left, newRunningSum, sums);
            CalculateBranchSums(node.Right, newRunningSum, sums);
        }

        private static List<int> BranchSums(BinaryTreeNode root)
        {
            List<int> sums = new List<int>();
            CalculateBranchSums(root, 0, sums);
            return sums;
        }

        public static void Main()
        {
            var root = new BinaryTreeNode(1);

            root.Left = new BinaryTreeNode(2);
            root.Right = new BinaryTreeNode(3);

            root.Left.Left = new BinaryTreeNode(4);
            root.Left.Right = new BinaryTreeNode(5);
            root.Right.Left = new BinaryTreeNode(6);
            root.Right.Right = new BinaryTreeNode(7);

            root.Left.Left.Left = new BinaryTreeNode(8);
            root.Left.Left.Right = new BinaryTreeNode(9);

            root.Left.Right.Left = new BinaryTreeNode(10);

            var sums = BranchSums(root);
            Console.WriteLine(string.Join(", ", sums)); 
        }
    }
}