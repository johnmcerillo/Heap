using BinaryHeap;
using Xunit;

namespace BinaryHeapTests
{
    public class BinaryHeapTests
    {
        [Fact]
        public void AscendingSequenceTest()
        {
            var bh = new BinaryHeap<int>();
            var count = 1024;
            for(var i = 0; i <= count; i++)
            {
                bh.Push(i);
            }
            for(var i = count; 0 <= i; i--)
            {
                Assert.Equal(i, bh.Pop());
            }
        }

        [Fact]
        public void AscendingSequenceWithReplacementTest()
        {
            var bh = new BinaryHeap<int>();
            for(var i = 64; i <= 127; i++)
            {
                bh.Push(i);
            }
            for(var i = 0; i < 32; i++)
            {
                bh.Replace(i);
            }
            for(var i = 95; 64 <= i; i--)
            {
                Assert.Equal(i, bh.Pop());
            }
            for(var i = 31; 0 <= i; i--)
            {
                Assert.Equal(i, bh.Pop());
            }
        }

        [Fact]
        public void AscendingSequenceConstructorTest()
        {
            var ascending = new int[64];

            for(var i = 0; i < ascending.Length; i++)
            {
                ascending[i] = i;
            }

            var bh = new BinaryHeap<int>(ascending);

            for(var i = ascending.Length - 1; 0 <= i; i--)
            {
                Assert.Equal(i, bh.Pop());
            }

        }

        [Fact]
        public void HeapsortTest()
        {
            var descending = new int[64];
            for(var i = 63; 0 <= i; i--)
            {
                descending[i] = 63 - i;
            }

            BinaryHeap<int>.Heapsort(descending);
            var ascending = descending;

            for(var i = 0; i < ascending.Length; i++)
            {
                Assert.Equal(i, ascending[i]);
            }
        }
    }
}
