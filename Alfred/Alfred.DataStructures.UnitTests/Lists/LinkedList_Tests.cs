using Alfred.DataStructures.Lists;
using AlfredDataStructures = Alfred.DataStructures.Lists;

namespace Alfred.DataStructures.UnitTests.Lists
{
    public class LinkedList_Tests
    {
        [Fact]
        public void Insert_TestLengthIncrementWithValidPositionIndex()
        {
            // Arrange
            var list = new AlfredDataStructures.LinkedList<int>();
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
            var list = new AlfredDataStructures.LinkedList<int>();
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
            var list = new AlfredDataStructures.LinkedList<int>();
            var positionIndex = 1;
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
            var list = new AlfredDataStructures.LinkedList<int>();
            list.Insert(0, 1);
            list.Insert(1, 3);
            var positionIndex = 1;
            var value = 2;
            // Act
            list.Insert(positionIndex, value);
            // Assert
            Assert.Equal(1, list[0]);
            Assert.Equal(2, list[1]);
            Assert.Equal(3, list[2]);
        }

        [Fact]
        public void Insert_TestValueInsertedInTheBeginning()
        {
            // Arrange
            var list = new AlfredDataStructures.LinkedList<int>();
            list.Insert(0, 2);
            list.Insert(1, 3);
            var positionIndex = 0;
            var value = 1;
            // Act
            list.Insert(positionIndex, value);
            // Assert
            Assert.Equal(1, list[0]);
            Assert.Equal(2, list[1]);
            Assert.Equal(3, list[2]);
        }

        [Fact]
        public void Insert_TestValueInsertedInTheEnd()
        {
            // Arrange
            var list = new AlfredDataStructures.LinkedList<int>();
            list.Insert(0, 1);
            list.Insert(1, 2);
            var positionIndex = 2;
            var value = 3;
            // Act
            list.Insert(positionIndex, value);
            // Assert
            Assert.Equal(1, list[0]);
            Assert.Equal(2, list[1]);
            Assert.Equal(3, list[2]);
        }

        [Fact]
        public void RemoveAt_TestLengthDecrementWithValidPositionIndex()
        {
            // Arrange
            var list = new AlfredDataStructures.LinkedList<int>();
            list.Insert(0, 1);
            // Act
            list.RemoveAt(0);
            // Assert
            Assert.Equal(0, list.Length);
        }

        [Fact]
        public void RemoveAt_TestValueRemovedIsReturned()
        {
            // Arrange
            var list = new AlfredDataStructures.LinkedList<int>();
            list.Insert(0, 1);
            // Act
            var value = list.RemoveAt(0);
            // Assert
            Assert.Equal(1, value);
        }

        [Fact]
        public void RemoveAt_TestWithNegativePositionIndex()
        {
            // Arrange
            var list = new AlfredDataStructures.LinkedList<int>();
            var positionIndex = -1;
            // Act
            Action action = () => list.RemoveAt(positionIndex);
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public void RemoveAt_TestWithPositionIndexGreaterThanLength()
        {
            // Arrange
            var list = new AlfredDataStructures.LinkedList<int>();
            var positionIndex = 1;
            // Act
            Action action = () => list.RemoveAt(positionIndex);
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public void RemoveAt_TestRemovalOfValueInTheMiddle()
        {
            // Arrange
            var list = new AlfredDataStructures.LinkedList<int>();
            list.Insert(0, 1);
            list.Insert(1, 2);
            list.Insert(2, 3);
            var positionIndex = 1;
            // Act
            list.RemoveAt(positionIndex);
            // Assert
            Assert.Equal(1, list[0]);
            Assert.Equal(3, list[1]);
        }

        [Fact]
        public void RemoveAt_TestRemovalOfValueInTheBeginning()
        {
            // Arrange
            var list = new AlfredDataStructures.LinkedList<int>();
            list.Insert(0, 1);
            list.Insert(1, 2);
            list.Insert(2, 3);
            var positionIndex = 0;
            // Act
            list.RemoveAt(positionIndex);
            // Assert
            Assert.Equal(2, list[0]);
            Assert.Equal(3, list[1]);
        }

        [Fact]
        public void RemoveAt_TestRemovalOfValueInTheEnd()
        {
            // Arrange
            var list = new AlfredDataStructures.LinkedList<int>();
            list.Insert(0, 1);
            list.Insert(1, 2);
            list.Insert(2, 3);
            var positionIndex = 2;
            // Act
            list.RemoveAt(positionIndex);
            // Assert
            Assert.Equal(1, list[0]);
            Assert.Equal(2, list[1]);
        }

        [Fact]
        public void GetEnumerator_Test()
        {
            // Arrange
            var list = new AlfredDataStructures.LinkedList<int>();
            list.Insert(0, 1);
            list.Insert(1, 2);
            list.Insert(2, 3);
            // Act
            var enumerator = list.GetEnumerator();
            // Assert
            Assert.NotNull(enumerator);
            Assert.Equal(typeof(LinkedListEnumerator<int>), enumerator.GetType());
        }

        [Fact]
        public void IndexOf_ShouldNotFindItem()
        {
            // Arrange
            var list = new AlfredDataStructures.LinkedList<int>([ 1, 2, 3, 4, 5 ]);
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
            var list = new AlfredDataStructures.LinkedList<int>([1, 2, 3, 4, 5]);
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
            var list = new AlfredDataStructures.LinkedList<string>();
            // Act
            Action action = () => list.IndexOf(null);
            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void IndicesOf_ShouldNotFindItem()
        {
            // Arrange
            var list = new AlfredDataStructures.LinkedList<int>([1, 2, 3, 4, 5]);
            var item = 6;
            var index = list.IndexOf(item);
            // Act
            var indices = list.IndicesOf(item);
            // Assert
            Assert.Empty(indices);
        }

        [Fact]
        public void IndicesOf_ShouldFindItem()
        {
            // Arrange
            var list = new AlfredDataStructures.LinkedList<int>([1, 2, 3, 4, 5]);
            var item = 3;
            // Act
            var indices = list.IndicesOf(item);
            // Assert
            Assert.Single(indices);
            Assert.Equal(2, indices.First());
        }

        [Fact]
        public void IndicesOf_ShouldThrowArgumentNullException()
        {
            // Arrange
            var list = new AlfredDataStructures.LinkedList<string>();
            // Act
            var indices = list.IndicesOf(null);
            // Assert
            Assert.Throws<ArgumentNullException>(() => indices.Count());
        }
    }
}
