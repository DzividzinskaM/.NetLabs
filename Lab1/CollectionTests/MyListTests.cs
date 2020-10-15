using NUnit.Framework;
using Collection;
using System;
using System.Collections;
using System.Linq;


namespace CollectionTests
{
    [TestFixture(typeof(int))]
    public class MyListTests<T>
    {
        MyList<T> lst;
        [SetUp]
        public void Setup()
        {
            lst = new MyList<T>();
        }


        [Test]
        [TestCase(1)]
        public void Add_AddItemToEmptyList_ListWithOneElement(T item)
        {
            lst.Add(item);

            Assert.Contains(item, lst.ToList());
        }

        [Test]
        [TestCase(1)]
        public void Add_AddItemUsingExpanding_AddItemsAndDoubledCapacity(T item)
        {
            int startCapacity = 2;
            int expectedCapacity = 4;
            lst = new MyList<T>(startCapacity);

            lst.Add(item);
            lst.Add(item);
            lst.Add(item);

            Assert.AreEqual(expectedCapacity, lst.Capacity);
        }

        [Test]
        [TestCase(1)]
        public void Clear_ClearNotEmptyList_SetCountZero(T item)
        {
            lst.Add(item);

            lst.Clear();

            Assert.IsEmpty(lst);
        }


        [Test]
        public void Clear_ClearEmptyList_SetCountZero()
        {
            lst.Clear();

            Assert.IsEmpty(lst);
        }


        [Test]
        [TestCase(1,2,2)]
        public void Contains_FindExistItem_ReturnTrue(T item1, T item2, T findedItem)
        {
            lst.Add(item1);
            lst.Add(item2);
            lst.Add(item1);

            bool actualValue = lst.Contains(findedItem);

            Assert.IsTrue(actualValue);
        }

        [Test]
        [TestCase(1,2,3)]
        public void Contains_FindNotExistValue_ReturnFalse
            (T item1, T item2, T findedItem)
        {
            lst.Add(item1);
            lst.Add(item2);
            lst.Add(item1);

            bool actualValue = lst.Contains(findedItem);

            Assert.IsFalse(actualValue);
        }

        [Test]
        [TestCase(1,0)]
        public void CopyTo_CopyToArrayWithSaneSizeFromStartList_CopyToArray
            (T startItem, int index)
        {
            lst.Add(startItem);
            lst.Add(startItem);
            lst.Add(startItem);
            T[] arr = new T[lst.Count];
            T[] expectedArr = new T[lst.Count];
            expectedArr.SetValue(startItem, 0);
            expectedArr.SetValue(startItem, 1);
            expectedArr.SetValue(startItem, 2);

            lst.CopyTo(arr, index);

            CollectionAssert.AreEqual(expectedArr, arr);
        }

        [Test]
        [TestCase(1)]
        public void CopyTo_CopyToNullArrayWithIndex_ShouldThrowArgumentNullException
            (T startItem)
        {
            lst.Add(startItem);
            lst.Add(startItem);
            lst.Add(startItem);
            T[] arr = null;

            Assert.Throws<ArgumentNullException>(() => lst.CopyTo(arr, 0));
        }

        [Test]
        [TestCase(1)]
        public void CopyTo_CopyToNullArray_ShouldThrowArgumentNullException
            (T startItem)
        {
            lst.Add(startItem);
            lst.Add(startItem);
            lst.Add(startItem);
            T[] arr = null;

            Assert.Throws<ArgumentNullException>(() => lst.CopyTo(arr));
        }

        [Test]
        [TestCase(1,2)]
        public void CopyTo_CopyToWithBiggerIndex_ShouldThrowArgumentException
            (T startItem, int index)
        {
            lst.Add(startItem);
            lst.Add(startItem);
            lst.Add(startItem);
            T[] arr = new T[lst.Count];

            Assert.Throws<ArgumentException>(() => lst.CopyTo(arr, index));
        }

        [Test]
        [TestCase(1)]
        public void CopyTo_CopyToSmallerArray_ShouldThrowArgumentException
            (T startItem)
        {
            lst.Add(startItem);
            lst.Add(startItem);
            lst.Add(startItem);
            T[] arr = new T[lst.Count-1];

            Assert.Throws<ArgumentException>(() => lst.CopyTo(arr));
        }

        [Test]
        [TestCase(1, -1)]
        public void CopyTo_CopyToWithIndexLessThenZero_ShouldThrowArgumentOutOfRangeException
           (T startItem, int index)
        {
            lst.Add(startItem);
            lst.Add(startItem);
            lst.Add(startItem);
            T[] arr = new T[lst.Count];

            Assert.Throws<ArgumentOutOfRangeException>(() => lst.CopyTo(arr, index));
        }



        [Test]
        [TestCase(1,2)]
        public void Remove_RemoveOnlyOneExistItem_ReturnTrue
            (T item, T removedItem)
        {
            lst.Add(item);
            lst.Add(removedItem);
            lst.Add(item);

            bool actualValue = lst.Remove(removedItem);

            Assert.IsTrue(actualValue);
            CollectionAssert.DoesNotContain(lst.ToList(), removedItem);
        }

        [Test]
        [TestCase(1,2)]
        public void Remove_RemoveFirstFindedItem_ReturnTrue
            (T item, T removedItem)
        {
            lst.Add(item);
            lst.Add(removedItem);
            lst.Add(item);
            lst.Add(removedItem);

            bool actualValue = lst.Remove(removedItem);

            Assert.IsTrue(actualValue);
            Assert.Contains(removedItem, lst.ToList());
        }

        [Test]
        [TestCase(1,2)]
        public void Remove_RemoveNotExistItem_ReturnFalse
            (T item, T removedItem)
        {
            lst.Add(item);
            lst.Add(item);
            lst.Add(item);
            CollectionAssert.DoesNotContain(lst.ToList(), removedItem);

            bool actualValue = lst.Remove(removedItem);

            Assert.IsFalse(actualValue);
            CollectionAssert.DoesNotContain(lst.ToList(), removedItem);
        }

        [Test]
        [TestCase(1,2)]
        public void IndexOf_FindIndexOfExistItem_ReturnIndex
            (T item, T findedItem)
        {
            lst.Add(item);
            lst.Add(item);
            lst.Add(findedItem);
            lst.Add(item);
            int expectedValue = lst.ToList().IndexOf(findedItem);

            int actualValue = lst.IndexOf(findedItem);

            Assert.AreEqual(expectedValue, actualValue);            
        }

        [Test]
        [TestCase(1, 2)]
        public void IndexOf_FindIndexOfFirstExistItem_ReturnFirstIndex
            (T item, T findedItem)
        {
            lst.Add(item);
            lst.Add(item);
            lst.Add(findedItem);
            lst.Add(item);
            lst.Add(findedItem);
            lst.Add(item);
            int expectedValue = lst.ToList().IndexOf(findedItem);

            int actualValue = lst.IndexOf(findedItem);

            Assert.AreEqual(expectedValue, actualValue);
        }


        [Test]
        [TestCase(1, 2)]
        public void IndexOf_FindIndexOfNotExistItem_ReturnMinusOne
            (T item, T findedItem)
        {
            lst.Add(item);
            lst.Add(item);
            lst.Add(item);
            lst.Add(item);
            int expectedValue = -1;

            int actualValue = lst.IndexOf(findedItem);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        [TestCase(10, 0, 100)]
        [TestCase(10, 1, 20)]
        public void Insert_InsertItemToNotEmptyList_InsertItem
            (T startItem, int index, T newItem)
        {
            lst.Add(startItem);
            lst.Add(startItem);
            lst.Add(startItem);

            lst.Insert(index, newItem);

            Assert.Contains(newItem, lst.ToList());
        }

        [Test]
        [TestCase(10, -1, 100)]
        [TestCase(10, -5, 20)]

        public void Insert_InsertItemWhenIndexLessThenZero_ShouldTrowArgumentOutOfRangeException
            (T startItem, int index, T newItem)
        {
            lst.Add(startItem);
            lst.Add(startItem);
            lst.Add(startItem);

            Assert.Throws<ArgumentOutOfRangeException>(() => lst.Insert(index, newItem));

        }

        [Test]
        [TestCase(10, 10, 100)]
        [TestCase(10, 4, 20)]
        public void Insert_InsertItemWhenIndexMoreThenCurrentCount_ShouldTrowArgumentOutOfRangeException
            (T startItem, int index, T newItem)
        {
            lst.Add(startItem);
            lst.Add(startItem);
            lst.Add(startItem);

            Assert.Throws<ArgumentOutOfRangeException>(() => lst.Insert(index, newItem));

        }

        [Test]
        [TestCase(1,2,3,2)]
        public void RemoveAt_RemoveSingleItemByIndex_RemoveItemFromList
            (T item1, T item2, T item3, int removedIndex)
        {
            lst.Add(item1);
            lst.Add(item2);
            lst.Add(item3);
            lst.Add(item2);
            T removedElement = lst[removedIndex];

            lst.RemoveAt(removedIndex);

            CollectionAssert.DoesNotContain(lst.ToList(), removedElement);
        }

        [Test]
        [TestCase(1, 2, 3, 2)]
        public void RemoveAt_RemoveItemByIndex_RemoveItemFromList
            (T item1, T item2, T item3, int removedIndex)
        {
            lst.Add(item1);
            lst.Add(item2);
            lst.Add(item3);
            lst.Add(item3);
            lst.Add(item2);
            MyList<T> expectedLst = new MyList<T>();
            expectedLst.Add(item1);
            expectedLst.Add(item2);
            expectedLst.Add(item3);
            expectedLst.Add(item2);

            lst.RemoveAt(removedIndex);

            CollectionAssert.AreEqual(expectedLst.ToList(), lst.ToList());
        }

        [Test]
        [TestCase(100,-1)]
        [TestCase(25, 200)]
        public void RemoveAt_RemoveWhenIndexLessThenZeroAndMoreThenCount_ShouldTrowArgumentOutOfRangeException
            (T item, int index)
        {
            lst.Add(item);
            lst.Add(item);
            lst.Add(item);

            Assert.Throws<ArgumentOutOfRangeException>(() => lst.RemoveAt(index));
        }

        [Test]
        [TestCase(1,2,100)]
        public void updateItemEvent_CheckCallingEvent_ReturnTrue
            (T startItem, int index, T newItem)
        {
            bool callEvent = false;
            lst.Add(startItem);
            lst.Add(startItem);
            lst.Add(startItem);
            lst.Add(startItem);
            lst.updateItemEvent += (source, e) =>  callEvent = true;

            lst.Update(index, newItem);

            Assert.IsTrue(callEvent);     
        }


    }
}