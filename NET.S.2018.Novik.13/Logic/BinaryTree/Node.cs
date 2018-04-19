using System;

namespace Logic.BinaryTree
{
    /// <summary>
    /// Provides properties to use this class in <see cref="BinarySearchTree{T}"/>.
    /// </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    internal class Node<T>
    {
        public Node(Node<T> left, Node<T> rigth, T value)
        {
            this.Left = left;
            this.Rigth = rigth;
            this.Value = value;
        }

        #region properties

        internal Node<T> Left { get; set; }

        internal Node<T> Rigth { get; set; }

        internal T Value { get; set; }

        #endregion
    }
}
