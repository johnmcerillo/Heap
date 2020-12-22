using System;

namespace BinaryHeap
{
    public class BinaryHeap<T> where T : IComparable
    {
        private T[] m_Heap;
        private int m_Size;

        public BinaryHeap() {
            m_Heap = new T[8];
            m_Size = 0;
        }

        public BinaryHeap(T[] unsortedArr)
        {
            m_Heap = unsortedArr;
            m_Size = unsortedArr.Length;
            for(var i = (m_Heap.Length) / 2 - 1; 0 <= i; i--)
            {
                Heapify(i);
            }
        }

        public static void Heapsort(T[] unsortedArr)
        {
            var bh = new BinaryHeap<T>(unsortedArr);
            var i = unsortedArr.Length - 1;
            while(0 < i)
            {
                unsortedArr[i] = bh.Pop();
                i--;
            }
        }

        private static int Left(int i)
        {
            return 2 * i + 1;
        }

        private static int Right(int i)
        {
            return 2 * i + 2;
        }

        private static int Parent(int i)
        {
            return (i + 1) / 2 - 1;
        }

        private void Heapify(int iParent)
        {
            int iLeftChild;
            while ((iLeftChild = Left(iParent)) < m_Size)
            {
                var iRightChild = Right(iParent);
                var iBestChild = m_Size <= iRightChild || m_Heap[iRightChild].CompareTo(m_Heap[iLeftChild]) < 0 ? iLeftChild : iRightChild;
                var parentObject = m_Heap[iParent];
                if(0 <= parentObject.CompareTo(m_Heap[iBestChild])) return;
                m_Heap[iParent] = m_Heap[iBestChild];
                m_Heap[iBestChild] = parentObject;
                iParent = iBestChild;
            }
        }

        public void Push(T key)
        {
            if(m_Heap.Length <= m_Size)
            {
                var oldHeap = m_Heap;
                m_Heap = new T[2 * oldHeap.Length];
                Array.Copy(oldHeap, m_Heap, oldHeap.Length);
            }

            m_Heap[m_Size] = key;
            var iChild = m_Size++;

            while(0 < iChild)
            {
                var iParent = Parent(iChild);
                var parentObj = m_Heap[iParent];
                if (0 <= parentObj.CompareTo(m_Heap[iChild])) break;
                m_Heap[iParent] = m_Heap[iChild];
                m_Heap[iChild] = parentObj;
                iChild = iParent;
            }
        }

        public T Pop()
        {
            if(m_Size <= 0) throw new InvalidOperationException("Cannot pop from an empty heap");
            var root = m_Heap[0];
            m_Size--;
            if(m_Size == 0) return root;
            m_Heap[0] = m_Heap[m_Size];
            Heapify(0);
            return root;
        }

        public T Replace(T key)
        {
            if (m_Size <= 0) throw new InvalidOperationException("Cannot replace in an empty heap");
            var root = m_Heap[0];
            m_Heap[0] = key;
            Heapify(0);
            return root;
        }

    }
}
