using System;
using System.Collections.Generic;

namespace TestSort.Trees
{
    public class BinarySearchTree<TKey> where TKey : IComparable
    {
        public TreeNode<TKey> Root { get; private set; }

        public BinarySearchTree()
        {
            Root = null;
        }

        public BinarySearchTree(TreeNode<TKey> root)
        {
            Root = root;
        }

        public TreeNode<TKey> Search(TKey key)
        {
            return SearchWithDirection(key).Node;
        }

        public void Insert(TKey key)
        {
            var searchWithDirection = SearchWithDirection(key);
            if (searchWithDirection.Parent == null)
            {
                Root = new TreeNode<TKey>(key);
                return;
            }

            if(searchWithDirection.Direction == TreeNodeDirection.Left)
            {
                if (searchWithDirection.Parent.Left != null) return;
                searchWithDirection.Parent.SetLeft(key);
            }
            else
            {
                if (searchWithDirection.Parent.Right != null) return;
                searchWithDirection.Parent.SetRight(key);
            }
        }

        public void Delete(TKey key)
        {
            var searchWithDirection = SearchWithDirection(key);
            if (searchWithDirection.Parent == null)
            {
                Root = null;
                return;
            }

            if (searchWithDirection.Node == null)
            {
                return;
            }

            var node = searchWithDirection.Node;

            if (node.Left == null)
            {
                Transplant(node, node.Right);
            }
            else if (node.Right == null)
            {
                Transplant(node, node.Left);
            }
            else
            {
                var min = Min(node.Right);
                if (!min.Parent.Equals(node))
                {
                    Transplant(min, min.Right);
                    min.SetRight(node.Right);
                    min.Right.SetParent(min);
                }

                Transplant(node, min);
                min.SetLeft(node.Left);
            }
        }

        public TreeNode<TKey> Min(TreeNode<TKey> node = null)
        {
            var parent = node ?? Root;
            while(parent.Left != null)
            {
                parent = parent.Left;
            }

            return parent;
        }

        public TreeNode<TKey> Max(TreeNode<TKey> node = null)
        {
            var parent = node ?? Root;
            while (parent.Right != null)
            {
                parent = parent.Right;
            }

            return parent;
        }

        public TreeNode<TKey> Successor(TKey key)
        {
            var searchResult = SearchWithDirection(key);

            var node = searchResult.Node ?? searchResult.Parent;

            if (node == null) return null; 

            if (node.Right != null) return Min(node.Right);

            var parent = node.Parent;

            while(parent != null && node.Equals(parent.Right))
            {
                node = parent;
                parent = parent.Parent;
            }

            return parent;
        }

        public TreeNode<TKey> Predecessor(TKey key)
        {
            var searchResult = SearchWithDirection(key);

            var node = searchResult.Node?.Left ?? searchResult.Node;

            if (node == null) return null;

            if (node.Left != null) return Max(node.Left);

            var parent = node.Parent;

            while (parent != null && node.Equals(parent.Left))
            {
                node = parent;
                parent = parent.Parent;
            }

            return parent;
        }

        public IEnumerable<TKey> InorderWalk()
        {
            return InorderWalkFrom(Root);
        }

        public bool CheckIsSearchTree()
        {
            var emunerator = InorderWalk().GetEnumerator();

            var current = emunerator.Current;

            if (current == null) return true;

            var previous = current;
            while (emunerator.MoveNext())
            {
                current = emunerator.Current;
                if (previous.CompareTo(current) > 0)
                {
                    return false;
                }

                previous = current;
            }

            return true;
        }

        private SearchResult<TKey> SearchWithDirection(TKey key)
        {
            TreeNode<TKey> parent = null;
            var current = Root;
            var direction = TreeNodeDirection.Left;
            while (current != null && !current.Key.Equals(key))
            {
                parent = current;
                if (current.Key.CompareTo(key) >= 0)
                {
                    current = current.Left;
                    direction = TreeNodeDirection.Left;
                }
                else
                {
                    current = current.Right;
                    direction = TreeNodeDirection.Right;
                }
            }

            return new SearchResult<TKey>(parent, current, direction);
        }

        private void Transplant(TreeNode<TKey> from, TreeNode<TKey> to)
        {
            if (from.Parent == null)
            {
                Root = to;
            }
            else if (from.Equals(from.Parent.Left))
            {
                from.Parent.SetLeft(to);
            }
            else
            {
                from.Parent.SetRight(to);
            }
        }

        private IEnumerable<TKey> InorderWalkFrom(TreeNode<TKey> from)
        {
            if (from == null) yield break;

            foreach(var item in InorderWalkFrom(from.Left))
            {
                yield return item;
            }

            yield return from.Key;

            foreach (var item in InorderWalkFrom(from.Right))
            {
                yield return item;
            }
        }
    }
}
