using Alfred.DataStructures.Lists;

namespace Alfred.DataStructures.UnitTests.Lists
{
    public class ArrayListOptimizedExecutionTimeEnumerator_Tests
    {
        [Fact]
        public void ArrayListOptimizedExecutionTimeEnumerator_MoveNext_Test()
        {
            // Arrange
            var list = new ArrayListOptimizedExecutionTime<int>();
            list.Insert(0, 1);
            list.Insert(1, 2);
            list.Insert(2, 3);
            var enumerator = list.GetEnumerator();
            // Act
            var result1 = enumerator.MoveNext();
            var result2 = enumerator.MoveNext();
            var result3 = enumerator.MoveNext();
            var result4 = enumerator.MoveNext();
            // Assert
            Assert.True(result1);
            Assert.True(result2);
            Assert.True(result3);
            Assert.False(result4);
        }
    }
}
