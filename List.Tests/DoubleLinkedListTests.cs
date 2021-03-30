using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace List.Tests
{
    class DoubleLinkedListTests
    {
        [TestCase(3, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 5, 4, 5 })]
        [TestCase(0, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 1, 2, 3, 4, 5 })]
        [TestCase(4, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 5 })]
        [TestCase(5, 6, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        //[TestCase(6, 6, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 6 })] написать тесты негативные и исключение 

        public void AddByIndexTest(int index, int value, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            actual.AddByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 2, 1, 2, 3 })]
        public void AddByZeroIndexTest(int[] actualAr, int value, int[] arExpected)
        {
            DoubleLinkedList actual = new DoubleLinkedList(actualAr);
            DoubleLinkedList expected = new DoubleLinkedList(arExpected);

            actual.AddFirst(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 5 })]
        public void AddTest(int value, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        public void RemoveLastElementTest(int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            actual.RemoveLastElement();

            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        public void RemoveFirstElementTest(int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            actual.RemoveFirstElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 4, 5 })]
        public void RemoveByIndexTest(int index, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            actual.RemoveByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3 })]
        public void RemoveXElementsByEndTest(int x, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            actual.RemoveByEndXElements(x);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5 })]
        public void RemoveXElementsByStartTest(int x, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            actual.RemoveByStartXElements(x);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 5 })]
        public void RemoveByIndexXElementsntsTest(int index, int xElement, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            actual.RemoveByIndexXElements(index, xElement);

            Assert.AreEqual(expected, actual);
        }

        //[TestCase(new int[] { 1, 4, 6, 2, 5, 4 }, new int[] { 4, 5, 2, 6, 4, 1 })]
        //[TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        //public void ReverseTest(int[] array, int[] expectedAr)
        //{
        //    DoubleLinkedList actual = new DoubleLinkedList(array);
        //    DoubleLinkedList expected = new DoubleLinkedList(expectedAr);

        //    actual.Reverse();

        //    Assert.AreEqual(expected, actual);
        //}
    }
}
