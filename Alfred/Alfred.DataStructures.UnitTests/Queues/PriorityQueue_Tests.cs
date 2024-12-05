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
    }
}
