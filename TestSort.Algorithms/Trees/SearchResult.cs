using System;

namespace TestSort.Algorithms.Trees
{
    public class SearchResult<TKey> where TKey : IComparable
    {
        public SearchResult(
            TreeNode<TKey> parent,
            TreeNode<TKey> node,
            TreeNodeDirection direction)
        {
            Parent = parent;
            Node = node;
            Direction = direction;
        }

        public TreeNode<TKey> Parent { get; }
        public TreeNode<TKey> Node { get; }
        public TreeNodeDirection Direction { get; }
    }
}
