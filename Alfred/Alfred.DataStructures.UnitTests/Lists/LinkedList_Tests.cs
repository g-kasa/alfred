using Alfred.DataStructures.Lists;
using AlfredDataStructures = Alfred.DataStructures.Lists;

namespace Alfred.DataStructures.UnitTests.Lists
{
    public class LinkedList_Tests
    {
        [Fact]
        public void LinkedList_Insert_TestLengthIncrementWithValidPositionIndex()
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
        public void LinkedList_Insert_TestLengthIncrementWithNegativePositionIndex()
        {
            // Arrange
            var list = new AlfredDataStructures.LinkedList<int>();
            var positionIndex = -1;
            var value = 1;
            // Act
            var action = () => list.Insert(positionIndex, value);
            // Assert
            Assert.Throws<IndexOutOfRangeException>(action);
        }

        [Fact]
        public void LinkedList_Insert_TestLengthIncrementWithPositionIndexGreaterThanLength()
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
        public void LinkedList_Insert_TestValueInsertedInTheMiddle()
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
        public void LinkedList_Insert_TestValueInsertedInTheBeginning()
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
        public void LinkedList_Insert_TestValueInsertedInTheEnd()
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
        public void LinkedList_RemoveAt_TestLengthDecrementWithValidPositionIndex()
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
        public void LinkedList_RemoveAt_TestValueRemovedIsReturned()
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
        public void LinkedList_RemoveAt_TestWithNegativePositionIndex()
        {
            // Arrange
            var list = new AlfredDataStructures.LinkedList<int>();
            var positionIndex = -1;
            // Act
            Action action = () => list.RemoveAt(positionIndex);
            // Assert
            Assert.Throws<IndexOutOfRangeException>(action);
        }

        [Fact]
        public void LinkedList_RemoveAt_TestWithPositionIndexGreaterThanLength()
        {
            // Arrange
            var list = new AlfredDataStructures.LinkedList<int>();
            var positionIndex = 1;
            // Act
            Action action = () => list.RemoveAt(positionIndex);
            // Assert
            Assert.Throws<IndexOutOfRangeException>(action);
        }

        [Fact]
        public void LinkedList_RemoveAt_TestRemovalOfValueInTheMiddle()
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
        public void LinkedList_RemoveAt_TestRemovalOfValueInTheBeginning()
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
        public void LinkedList_RemoveAt_TestRemovalOfValueInTheEnd()
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
        public void LinkedList_GetEnumerator_Test()
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
            Assert.Equal(enumerator.GetType(), typeof(LinkedListEnumerator<int>));
        }
    }
}
