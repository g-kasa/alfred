using AlfredStacks = Alfred.DataStructures.Queues;

namespace Alfred.DataStructures.UnitTests.Queues
{
    public class Stack_Tests
    {
        [Fact]
        public void Push_ShouldIncreaseCount()
        {
            // Arrange
            var stack = new AlfredStacks.Stack<int>();
            // Act
            stack.Push(1);
            // Assert
            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Pop_ShouldDecreaseCount()
        {
            // Arrange
            var stack = new AlfredStacks.Stack<int>([1, 2, 3]);
            // Act
            stack.Pop();
            // Assert
            Assert.Equal(2, stack.Count);
        }

        [Fact]
        public void Pop_ShouldReturnLastItem()
        {
            // Arrange
            var stack = new AlfredStacks.Stack<int>([1, 2, 3]);
            // Act
            var item = stack.Pop();
            // Assert
            Assert.Equal(3, item);
        }

        [Fact]
        public void Pop_ShouldThrow_WhenEmpty()
        {
            // Arrange
            var stack = new AlfredStacks.Stack<int>();
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void Count_ShouldBeZero_WhenEmpty()
        {
            // Arrange
            var stack = new AlfredStacks.Stack<int>();
            // Act & Assert
            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void Peek_ShouldReturnLastItem()
        {
            // Arrange
            var stack = new AlfredStacks.Stack<int>([1, 2, 3]);
            // Act
            var item = stack.Peek();
            // Assert
            Assert.Equal(3, item);
        }

        [Fact]
        public void Peek_ShouldThrow_WhenEmpty()
        {
            // Arrange
            var stack = new AlfredStacks.Stack<int>();
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Fact]
        public void Peek_ShouldNotDecreaseCount()
        {
            // Arrange
            var stack = new AlfredStacks.Stack<int>([1, 2, 3]);
            // Act
            stack.Peek();
            // Assert
            Assert.Equal(3, stack.Count);
        }
    }
}
