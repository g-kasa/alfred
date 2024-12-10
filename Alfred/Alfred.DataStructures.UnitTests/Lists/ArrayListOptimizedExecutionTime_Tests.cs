using Alfred.DataStructures.Lists;

namespace Alfred.DataStructures.UnitTests.Lists
{
    public class ArrayListOptimizedExecutionTime_Tests
    {
        [Fact]
        public void Insert_TestLengthIncrementWithValidPositionIndex()
        {
            // Arrange
            var list = new ArrayListOptimizedExecutionTime<int>();
            var positionIndex = 0;
            var value = 1;

            // Act
            list.Insert(positionIndex, value);

            // Assert
            Assert.Equal(1, list.Length);
        }

        [Fact]
        public void Insert_TestLengthIncrementWithNegativePositionIndex()
        {
            // Arrange
            var list = new ArrayListOptimizedExecutionTime<int>();
            var positionIndex = -1;
            var value = 1;
            // Act
            var action = () => list.Insert(positionIndex, value);
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public void Insert_TestLengthIncrementWithPositionIndexGreaterThanLength()
        {
            // Arrange
            var list = new ArrayListOptimizedExecutionTime<int>();
            var positionIndex = 1;
            var value = 1;
            // Act
            list.Insert(positionIndex, value);
            // Assert
            Assert.Equal(1, list.Length);
        }

        [Fact]
        public void Insert_TestLengthIncrementWithPositionIndexGreaterThanCapacity()
        {
            // Arrange
            var list = new ArrayListOptimizedExecutionTime<int>();
            var positionIndex = 10;
            var value = 1;
            // Act
            list.Insert(positionIndex, value);
            // Assert
            Assert.Equal(1, list.Length);
        }

        [Fact]
        public void Insert_TestValueInsertedInTheMiddle()
        {
            // Arrange
            var list = new ArrayListOptimizedExecutionTime<int>();
            list.Insert(0, 1);
            list.Insert(1, 2);
            list.Insert(2, 3);
            list.Insert(3, 4);
            list.Insert(4, 5);
            var positionIndex = 2;
            var value = 100;
            // Act
            list.Insert(positionIndex, value);
            // Assert
            Assert.Equal(1, list[0]);
            Assert.Equal(2, list[1]);
            Assert.Equal(value, list[positionIndex]);
            Assert.Equal(3, list[3]);
            Assert.Equal(4, list[4]);
            Assert.Equal(5, list[5]);
        }

        [Fact]
        public void Insert_TestInsertionOfMoreValuesThanCapacity()
        {
            // Arrange
            var list = new ArrayListOptimizedExecutionTime<int>(2);
            // Act
            list.Insert(0, 1);
            list.Insert(1, 2);
            list.Insert(2, 3);
            list.Insert(3, 4);
            list.Insert(4, 5);

            // Assert
            Assert.Equal(5, list.Length);
            Assert.Equal(1, list[0]);
            Assert.Equal(2, list[1]);
            Assert.Equal(3, list[2]);
            Assert.Equal(4, list[3]);
            Assert.Equal(5, list[4]);
        }

        [Fact]
        public void RemoveAt_TestLengthDecrement()
        {
            // Arrange
            var list = new ArrayListOptimizedExecutionTime<int>();
            list.Insert(0, 1);
            list.Insert(1, 2);
            list.Insert(2, 3);
            list.Insert(3, 4);
            list.Insert(4, 5);
            // Act
            list.RemoveAt(2);
            // Assert
            Assert.Equal(4, list.Length);
        }

        [Fact]
        public void RemoveAt_TestValueRemovedIsReturned()
        {
            // Arrange
            var list = new ArrayListOptimizedExecutionTime<int>();
            list.Insert(0, 1);
            list.Insert(1, 2);
            list.Insert(2, 3);
            list.Insert(3, 4);
            list.Insert(4, 5);
            var positionIndex = 2;
            // Act
            var value = list.RemoveAt(positionIndex);
            // Assert
            Assert.Equal(3, value);
        }

        [Fact]
        public void RemoveAt_TestShiftingForRemainingValues()
        {
            // Arrange
            var list = new ArrayListOptimizedExecutionTime<int>();
            list.Insert(0, 1);
            list.Insert(1, 2);
            list.Insert(2, 3);
            list.Insert(3, 4);
            list.Insert(4, 5);
            var positionIndex = 2;
            // Act
            list.RemoveAt(positionIndex);
            // Assert
            Assert.Equal(1, list[0]);
            Assert.Equal(2, list[1]);
            Assert.Equal(4, list[2]);
            Assert.Equal(5, list[3]);
        }

        [Fact]
        public void RemoveAt_TestRemoveAtWithNegativePositionIndex()
        {
            // Arrange
            var list = new ArrayListOptimizedExecutionTime<int>();
            var positionIndex = -1;
            // Act
            Action action = () => list.RemoveAt(positionIndex);
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public void RemoveAt_TestRemoveAtWithPositionIndexGreaterThanLength()
        {
            // Arrange
            var list = new ArrayListOptimizedExecutionTime<int>();
            list.Insert(0, 1);
            list.Insert(1, 2);
            var positionIndex = 2;
            // Act
            Action action = () => list.RemoveAt(positionIndex);
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public void GetEnumerator_Test()
        {
            // Arrange
            var list = new ArrayListOptimizedExecutionTime<int>();
            list.Insert(0, 1);
            list.Insert(1, 2);
            list.Insert(2, 3);
            list.Insert(3, 4);
            list.Insert(4, 5);
            // Act
            var enumerator = list.GetEnumerator();
            // Assert
            Assert.NotNull(enumerator);
            Assert.Equal(typeof(ArrayListOptimizedExecutionTimeEnumerator<int>), enumerator.GetType());
        }

        [Fact]
        public void IndexOf_ShouldNotFindItem()
        {
            // Arrange
            var list = new ArrayListOptimizedExecutionTime<int>([1, 2, 3, 4, 5]);
            var item = 6;
            // Act
            var index = list.IndexOf(item);
            // Assert
            Assert.Equal(-1, index);
        }

        [Fact]
        public void IndexOf_ShouldFindItem()
        {
            // Arrange
            var list = new ArrayListOptimizedExecutionTime<int>([1, 2, 3, 4, 5]);
            var item = 3;
            // Act
            var index = list.IndexOf(item);
            // Assert
            Assert.Equal(2, index);
        }

        [Fact]
        public void IndexOf_ShouldThrowArgumentNullException()
        {
            // Arrange
            var list = new ArrayListOptimizedExecutionTime<string>();
            // Act
            Action action = () => list.IndexOf(null!);
            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void IndicesOf_ShouldNotFindItem()
        {
            // Arrange
            var list = new ArrayListOptimizedExecutionTime<int>([1, 2, 3, 4, 5]);
            var item = 6;
            // Act
            var indices = list.IndicesOf(item);
            // Assert
            Assert.Empty(indices);
        }

        [Fact]
        public void IndicesOf_ShouldFindItem()
        {
            // Arrange
            var list = new ArrayListOptimizedExecutionTime<int>([1, 2, 3, 4, 5]);
            var item = 3;
            // Act
            var indices = list.IndicesOf(item);
            // Assert
            Assert.Single(indices);
            Assert.Equal(2, indices.First());
        }

        [Fact]
        public void IndicesOf_ShouldFindMultipleItems()
        {
            // Arrange
            var list = new ArrayListOptimizedExecutionTime<int>([1, 2, 3, 4, 5, 3]);
            var item = 3;
            // Act
            var indices = list.IndicesOf(item);
            // Assert
            Assert.Equal(2, indices.Count());
            Assert.Equal(2, indices.ElementAt(0));
            Assert.Equal(5, indices.ElementAt(1));
        }

        [Fact]
        public void IndicesOf_ShouldThrowArgumentNullException()
        {
            // Arrange
            var list = new ArrayListOptimizedExecutionTime<string>();
            // Act
            var indices = list.IndicesOf(null!);
            Action action = () => indices.Count();
            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }
    }
}
