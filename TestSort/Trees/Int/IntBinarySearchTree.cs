namespace TestSort.Trees.Int
{
    public class IntBinarySearchTree : BinarySearchTree<int>
    {
        public IntBinarySearchTree() : base() { }

        public IntBinarySearchTree(int rootKey)
            : base(new TreeNode<int>(rootKey))
        {
        }
    }
}
