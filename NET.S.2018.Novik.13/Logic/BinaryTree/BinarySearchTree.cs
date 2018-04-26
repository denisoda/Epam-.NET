using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.BinaryTree
{
    public class BinarySearchTree<T>
        where T : IComparable<T>
    {
        #region Fields

        private Node<T> root;
        private IComparer<T> comparer;

        #endregion

        #region Constructors

        public BinarySearchTree()
        {
        }

        public void DefaultComparer()
        {
            
        }

        public BinarySearchTree(IComparer<T> comparer)
        {
            if (comparer is null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            this.comparer = comparer;
        }

        public void Add(T value)
        {
            if ()
        }

        public void Remove(T value)
        {

        }

        public int Search()
        {
            return 0;
        }

        #endregion

        #region Properties

        public int Count { get; set; }

        #endregion

        #region public methods

        #endregion

        #region private methods

        private bool IsEmpty => this.Count == 0;

        private void Add()
        {

        }

        #endregion
    }
}
