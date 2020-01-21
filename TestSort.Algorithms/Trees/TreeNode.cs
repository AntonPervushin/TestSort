using System;

namespace TestSort.Algorithms.Trees
{
    public class TreeNode<TKey> : IEquatable<TreeNode<TKey>>
        where TKey : IComparable
    {
        public TKey Key { get; }
        public TreeNode<TKey> Parent { get; private set; }
        public TreeNode<TKey> Left { get; private set; }
        public TreeNode<TKey> Right { get; private set; }

        public TreeNode(
            TKey key,
            TreeNode<TKey> parent,
            TreeNode<TKey> left,
            TreeNode<TKey> right)
        {
            Key = key;
            Parent = parent;
            Left = left;
            Right = right;
        }

        public TreeNode(TKey key) : this(key, null, null, null) { }

        public void SetLeft(TKey key)
        {
            SetLeft(new TreeNode<TKey>(key, this, null, null));
        }

        public void SetLeft(TreeNode<TKey> node)
        {
            Left = node;
            if (node == null) return;
            node.Parent = this;
        }

        public void SetRight(TKey key)
        {
            SetRight(new TreeNode<TKey>(key, this, null, null));
        }

        public void SetRight(TreeNode<TKey> node)
        {
            Right = node;
            if (node == null) return;
            node.Parent = this;
        }

        public bool Equals(TreeNode<TKey> other)
        {
            if (ReferenceEquals(this, other)) return true;
            return Key.CompareTo(other.Key) == 0;
        }

        public override bool Equals(object obj)
        {
            var node = obj as TreeNode<TKey>;
            if (node == null) return false;
            return Equals(node);
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }
    }
}
