using NUnit.Framework;
using System;

namespace List.Tests
{
    public class LinkedListTests
    {

        [TestCase(5, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 5 })]
        public void AddTest(int value, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList (expectedArray);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(3, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 5, 4, 5 })]
        [TestCase(0, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 1, 2, 3, 4, 5 })]
        [TestCase(4, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5,5 })]
        [TestCase(5, 6, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 ,6})]

        public void AddByIndexTest(int index, int value, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.AddByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 2, 1, 2, 3 })]
        public void AddByZeroIndexTest(int[] actualAr, int value, int[] arExpected)
        {
            LinkedList actual = new LinkedList(actualAr);
            LinkedList expected = new LinkedList(arExpected);

            actual.AddFirst(value);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        public void RemoveLastElementTest(int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveLastElement();

            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        public void RemoveFirstElementTest(int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveFirstElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 4, 5 })]
        public void RemoveByIndexTest(int index, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3 })]
        public void RemoveXElementsByEndTest(int x, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveByEndXElements(x);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5 })]
        public void RemoveXElementsByStartTest(int x, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveByStartXElements(x);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2,2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 5 })]
        public void RemoveByIndexXElementsntsTest(int index, int xElement, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveByIndexXElements(index, xElement);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 4, 6, 2, 5, 4 }, new int[] { 4, 5, 2, 6, 4, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        public void ReverseTest(int[] array, int[] expectedAr)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedAr);

            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, new int[] { 1, 4, 6, 2, 5, 4 }, 2)]
        [TestCase(4, new int[] { 1, 4, 6, 2, 5, 4 }, 1)]
        public void FirstIndexByValueTest(int value, int[] array, int expected)
        {
            LinkedList ar = new LinkedList(array);
            int actual = ar.FirstIndexByValue(value);

            Assert.AreEqual(expected, actual);

        }

        [TestCase(3, 6, new int[] { 3, 4, 6, 4, 2, 5, 4 }, new int[] { 3, 4, 6, 6, 2, 5, 4 })]
        public void ChangeValueByIndexTest(int index, int value, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.ChangeValueByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 4, 6, 2, 5, 4 }, 6)]
        public void MaxValueTest(int[] array, int expected)
        {
            LinkedList tmpArray = new LinkedList(array);

            var res = tmpArray.MaxValue();
            int actual = res.Item1;
            
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 4, 6, 2, 5, 4 }, 2)]
        [TestCase(new int[] { 3, 4, 3, 2, 5, 7, 9, 7, 6, 0, 6, 2, 5, 4 }, 0)]
        public void MinValueTest(int[] array, int expected)
        {
            LinkedList tmpArray = new LinkedList(array);
            var res = tmpArray.MinValue();
            int actual = res.Item1;


            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 3, 4, 6, 2, 5, 4 }, 2)]
        [TestCase(new int[] { 3, 4, 3,2,5,7,9,7,6,0,6, 2, 5, 4 }, 6)]
        public void IndexOfMaxValueTest(int[] array, int expected)
        {
            LinkedList tmpArray = new LinkedList(array);

            int actual = tmpArray.IndexOfMaxValue();

            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { 3, 4, 6, 2, 5, 4 }, 3)]
        public void IndexOfMinValue(int[] array, int expected)
        {
            LinkedList tmpArray = new LinkedList(array);

            int actual = tmpArray.IndexOfMinValue();
           

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] {10,9,8,4,4,7,6,5,5,3,2,1}, new int[] { 1,2,3,4,4,5,5,6,7,8,9,10 })]
        [TestCase(new int[] { 3, 4, 6, 2, 5, 4 }, new int[] { 2, 3, 4, 4, 5, 6 })]
        public void SortAscendingTest(int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.SortAscending();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 4, 6, 2, 5, 4 }, new int[] { 6, 5, 4, 4, 3, 2 })]
        public void SortDescendingTest(int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.SortDescending();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, new int[] { 3, 4, 6, 2, 5, 4 }, new int[] { 3, 6, 2, 5, 4 })]
        public void RemoveByValueFisrtTest(int value, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveByValueFisrt(value);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(4, new int[] { 3, 4, 6, 4, 2, 5, 4 }, new int[] { 3, 6, 2, 5 }, 3)]
        public void RemoveByValueAllTest(int value, int[] array, int[] expectedArray, int expectedCount)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            int actualCount = actual.RemoveByValueAll(value);

            Assert.AreEqual(expected, actual);
            //Assert.AreEqual(expectedCount, actualCount);

        }

        [TestCase(2, new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 5, 6, 7, 8, 9, 10, 3, 4 })]
        [TestCase(3, new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 5, 6, 7, 8, 9, 10, 4 })]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5, 6, }, new int[] { 9, 9, 9 }, new int[] { 1, 2, 3, 9, 9, 9, 4, 5, 6, })]
        public void AddLinkedListByIndexTest(int index, int[] array, int[] insertArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList insert = new LinkedList(insertArray);

            actual.AddLinkedListByIndex(index, insert);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5, 6, 7, 8 }, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]

        public void AddLinkedListByZeroIndexTest(int[] array, int[] insertArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList insert = new LinkedList(insertArray);

            actual.AddLinkedListByFirstIndex(insert);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1,2,3,4}, new int[] { 5,6,7,8 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        public void AddLinkedListByEndTest(int[] array, int[] insertArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList insert = new LinkedList(insertArray);

            actual.AddLinkedListToEnd(insert);

            Assert.AreEqual(expected, actual);
        }


    }
}
