using AlfredQueues = Alfred.DataStructures.Queues;

namespace Alfred.DataStructures.UnitTests.Queues
{
    public class PriorityQueue_Tests
    {
        [Fact]
        public void Push_ShouldIncreaseCount()
        {
            // Arrange
            var queue = new AlfredQueues.PriorityQueue<int, int>(AlfredQueues.PriorityType.MaxFirst);
            // Act
            queue.Push(Tuple.Create(1, 1));
            // Assert
            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void Pop_ShouldDecreaseCount()
        {
            // Arrange
            var queue = new AlfredQueues.PriorityQueue<int, int>(AlfredQueues.PriorityType.MaxFirst);
            queue.Push(Tuple.Create(1, 1));
            queue.Push(Tuple.Create(2, 2));
            queue.Push(Tuple.Create(3, 3));
            // Act
            queue.Pop();
            // Assert
            Assert.Equal(2, queue.Count);
        }

        [Fact]
        public void Pop_ShouldReturnHighestPriorityItem()
        {
            // Arrange
            var queue = new AlfredQueues.PriorityQueue<int, int>(AlfredQueues.PriorityType.MaxFirst);
            queue.Push(Tuple.Create(1, 1));
            queue.Push(Tuple.Create(2, 2));
            queue.Push(Tuple.Create(3, 3));
            // Act
            var item = queue.Pop();
            // Assert
            Assert.Equal(3, item.Item2);
        }

        [Fact]
        public void Pop_ShouldThrow_WhenEmpty()
        {
            // Arrange
            var queue = new AlfredQueues.PriorityQueue<int, int>(AlfredQueues.PriorityType.MaxFirst);
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => queue.Pop());
        }

        [Fact]
        public void Count_ShouldBeZero_WhenEmpty()
        {
            // Arrange
            var queue = new AlfredQueues.PriorityQueue<int, int>(AlfredQueues.PriorityType.MaxFirst);
            // Act & Assert
            Assert.Equal(0, queue.Count);
        }

        [Fact]
        public void Peek_ShouldReturnHighestPriorityItem()
        {
            // Arrange
            var queue = new AlfredQueues.PriorityQueue<int, int>(AlfredQueues.PriorityType.MaxFirst);
            queue.Push(Tuple.Create(1, 1));
            queue.Push(Tuple.Create(2, 2));
            queue.Push(Tuple.Create(3, 3));
            // Act
            var item = queue.Peek();
            // Assert
            Assert.Equal(3, item.Item2);
        }

        [Fact]
        public void Peek_ShouldThrow_WhenEmpty()
        {
            // Arrange
            var queue = new AlfredQueues.PriorityQueue<int, int>(AlfredQueues.PriorityType.MaxFirst);
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        [Fact]
        public void Pop_ShouldReturnLowestPriorityItem()
        {
            // Arrange
            var queue = new AlfredQueues.PriorityQueue<int, int>(AlfredQueues.PriorityType.MinFirst);
            queue.Push(Tuple.Create(1, 1));
            queue.Push(Tuple.Create(2, 2));
            queue.Push(Tuple.Create(3, 3));
            // Act
            var item1 = queue.Pop();
            var item2 = queue.Pop();
            // Assert
            Assert.Equal(1, item1.Item2);
            Assert.Equal(2, item2.Item2);
        }

        [Fact]
        public void Peek_ShouldReturnLowestPriorityItem()
        {
            // Arrange
            var queue = new AlfredQueues.PriorityQueue<int, int>(AlfredQueues.PriorityType.MinFirst);
            queue.Push(Tuple.Create(1, 1));
            queue.Push(Tuple.Create(2, 2));
            queue.Push(Tuple.Create(3, 3));
            // Act
            var item = queue.Peek();
            // Assert
            Assert.Equal(1, item.Item2);
        }

        [Fact]
        public void Peek_ShouldNotDecreaseCount()
        {
            // Arrange
            var queue = new AlfredQueues.PriorityQueue<int, int>(AlfredQueues.PriorityType.MinFirst);
            queue.Push(Tuple.Create(1, 1));
            queue.Push(Tuple.Create(2, 2));
            queue.Push(Tuple.Create(3, 3));
            // Act
            queue.Peek();
            // Assert
            Assert.Equal(3, queue.Count);
        }
    }
}
