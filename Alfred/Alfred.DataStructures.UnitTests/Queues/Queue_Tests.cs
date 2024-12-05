using AlfredDataStructures = Alfred.DataStructures.Queues;

namespace Alfred.DataStructures.UnitTests.Queues
{
    public class Queue_Tests
    {
        [Fact]
        public void Push_ShouldIncreaseCount()
        {
            // Arrange
            var queue = new AlfredDataStructures.Queue<int>();
            // Act
            queue.Push(1);
            // Assert
            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void Pop_ShouldDecreaseCount()
        {
            // Arrange
            var queue = new AlfredDataStructures.Queue<int>(new int[] { 1, 2, 3 });
            // Act
            queue.Pop();
            // Assert
            Assert.Equal(2, queue.Count);
        }

        [Fact]
        public void Pop_ShouldReturnFirstItem()
        {
            // Arrange
            var queue = new AlfredDataStructures.Queue<int>(new int[] { 1, 2, 3 });
            // Act
            var item = queue.Pop();
            // Assert
            Assert.Equal(1, item);
        }

        [Fact]
        public void Pop_ShouldThrow_WhenEmpty()
        {
            // Arrange
            var queue = new AlfredDataStructures.Queue<int>();
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => queue.Pop());
        }

        [Fact]
        public void Count_ShouldBeZero_WhenEmpty()
        {
            // Arrange
            var queue = new AlfredDataStructures.Queue<int>();
            // Act & Assert
            Assert.Equal(0, queue.Count);
        }

        [Fact]
        public void Peek_ShouldReturnFirstItem()
        {
            // Arrange
            var queue = new AlfredDataStructures.Queue<int>(new int[] { 1, 2, 3 });
            // Act
            var item = queue.Peek();
            // Assert
            Assert.Equal(1, item);
        }

        [Fact]
        public void Peek_ShouldNotDecreaseCount()
        {
            // Arrange
            var queue = new AlfredDataStructures.Queue<int>(new int[] { 1, 2, 3 });
            // Act
            queue.Peek();
            // Assert
            Assert.Equal(3, queue.Count);
        }
    }
}
