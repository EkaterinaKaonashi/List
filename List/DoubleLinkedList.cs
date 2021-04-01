using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class DoubleLinkedList
    {
        public int Length { get; private set; }

        private DoubleLinkedNode _head;
        private DoubleLinkedNode _tail;

        public int this [int index]
        {
            get
            {
                DoubleLinkedNode current = GetDoubleNodeByIndex(index);
                return current.Value;
            }
            set
            {
                DoubleLinkedNode current = GetDoubleNodeByIndex(index);
                current.Value = value;
            }

        }

        public DoubleLinkedList()
        {
            CreateEmptyDoubleLinkedList();
        }

        public DoubleLinkedList(int value)
        {
            CreateDoubleLinkedListWithOneElment(value);

        }

        private void CreateDoubleLinkedListWithOneElment(int value)
        {
            Length = 1;
            _head = new DoubleLinkedNode(value);
            _tail = _head;
        }

        public DoubleLinkedList(int[] values)
        {
           // нужна проверка , что входящий массив не нал
            _head = new DoubleLinkedNode(values[0]);
            _tail = _head;

            if(values.Length != 0)
            {
                Length = values.Length;

                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new DoubleLinkedNode(values[i]);
                    _tail.Next.Previous = _tail;
                    _tail = _tail.Next;
                }
            }
            else
            {
                CreateEmptyDoubleLinkedList();
            }

        }
        public void Add(int value)
        {
            AddByIndex(Length, value);
        }
        public void AddFirst(int value)
        {
            AddByIndex(0, value);
        }

        public void AddByIndex(int index ,int value )
        {
            CheckIndex( index);
            DoubleLinkedNode tmp;
            DoubleLinkedNode NodeBeforeIndex;
            DoubleLinkedNode current;
            if (Length == 0)
            {
                CreateDoubleLinkedListWithOneElment(value);
            }
            else if (index == 0)
            {
                tmp = new DoubleLinkedNode(value);
                current = GetDoubleNodeByIndex(index);

                current.Previous = tmp;
                tmp.Next = current;
                _head = tmp;
                Length++;


            }
            else if(index == Length)
            {
                tmp = new DoubleLinkedNode(value);
                Length++;
                current = GetDoubleNodeByIndex(index);
               current.Next = tmp;
                tmp.Previous =current;
                _tail = tmp;

            }



            else
            {
                tmp = new DoubleLinkedNode(value);
                NodeBeforeIndex = GetDoubleNodeByIndex(index - 1);
                current = GetDoubleNodeByIndex(index);

                NodeBeforeIndex.Next = tmp;
                tmp.Next = current;
                current.Previous = tmp;
                tmp.Previous = NodeBeforeIndex;
                Length++;
            }

        }
        public void RemoveLastElement(int xElements = 1)
        {
            DoubleLinkedNode current = GetDoubleNodeByIndex(Length -1 - xElements );
            DoubleLinkedNode preCur = GetDoubleNodeByIndex(Length - 1  - (xElements +1));

            _tail = current;
            current.Previous = preCur;
            Length-=xElements;

            //проверка не пустой ли список
           
        }
        public void RemoveFirstElement()
        {
            DoubleLinkedNode current = _head;
            _head = current.Next;
            Length--;
        }
        public void RemoveByIndex(int index)
        {
            CheckIndex(index);

            if (index == 0)
            {
                RemoveFirstElement();

            }
            else if (index == Length - 1)
            {
                RemoveLastElement();
            }
            else
            {
                DoubleLinkedNode current = GetDoubleNodeByIndex(index);
                DoubleLinkedNode currentPre = GetDoubleNodeByIndex(index - 1);
                currentPre.Next = current.Next;
                current.Next.Previous = currentPre;
                Length--;
            }  
        }
        public void RemoveByEndXElements(int xElements)
        {
            RemoveLastElement(xElements);
        }

        public void RemoveByStartXElements(int xElements)
        {

            for (int i = xElements; i > 0; i--)
            {
                RemoveFirstElement();
            }
        }

        public void RemoveByIndexXElements(int index, int xElements)
        {
            // можно оптимизировать?
            CheckIndex(index);
            if (index + xElements > Length)
            {
                throw new ArgumentException("Переданное число больше длинны массива");
            }
            for (int i = xElements; i > 0; i--)
            {
                RemoveByIndex(index);
            }

        }

        public int FirstIndexByValue(int value)
        {
            int index = 0;

            DoubleLinkedNode current = _head;

            for (int i = 1; i < Length; i++)
            {
                current = current.Next;
                if (current.Value == value)
                {
                    index = i;
                    break;
                }
            }


            return index;
        }

        public int getLength()
        {
            return Length;
        }

        public void ChangeValueByIndex(int index, int value)
        {
            CheckIndex(index);
            DoubleLinkedNode tmp = GetDoubleNodeByIndex(index);
            tmp.Value = value;
        }
        public void Reverse()
        {
            DoubleLinkedNode current = _head;

            ////next.Previous = current;
            DoubleLinkedNode tmp = null;

            while (!(current is null))
            {
                tmp = current.Previous;
                current.Previous = current.Next;
                current.Next = tmp;
                current = current.Previous;

            }
            if (!(tmp is null))
            {
                _tail = GetDoubleNodeByIndex(0);
                _head = tmp.Previous;
                
            }

        }
        public (int, int) MaxValue()
        {
            int indexOfMaxValue = 0;
            DoubleLinkedNode current = _head;
            DoubleLinkedNode maxValue = _head;


            for (int i = 1; i < Length; i++)
            {
                if (maxValue.Value < current.Next.Value)
                {
                    maxValue = current.Next;
                    indexOfMaxValue = i;

                }
                current = current.Next;
            }
            int maxV = maxValue.Value;
            return (maxV, indexOfMaxValue);
        }

        public (int, int) MinValue()
        {

            DoubleLinkedNode current = _head;
            DoubleLinkedNode minValue = _head;
            int indexOfMinValue = 0;
            int min = 0;

            for (int i = 1; i < Length; i++)
            {
                if (minValue.Value > current.Next.Value)
                {
                    minValue = current.Next;
                    indexOfMinValue = i;
                    min = minValue.Value;

                }
                current = current.Next;

            }

            return (min, indexOfMinValue);
        }

        public int IndexOfMaxValue()
        {
            var result = MaxValue();
            int index = result.Item2;
            return index;

        }

        public int IndexOfMinValue()
        {
            var result = MinValue();
            int index = result.Item2;
            return index;
        }

        public void SortAscending()
        {
            int tmp;
            DoubleLinkedNode current;
            DoubleLinkedNode next;
            DoubleLinkedNode pre;
            for (int i = 1; i < Length; i++)
            {
                current = _head;
                next = current.Next;
                pre = null;

                for (int j = 0; j < Length - i; j++)
                {
                    if (current.Value > next.Value)
                    {
                        tmp = next.Value;
                        next.Value = current.Value;
                        current.Value = tmp;
                    }

                    pre = current;
                    current = next;
                    next = next.Next;

                }
            }

        }
        public void SortDescending()
        {
            int tmp;
            DoubleLinkedNode current;
            DoubleLinkedNode next;
            DoubleLinkedNode pre;
            for (int i = 1; i < Length; i++)
            {
                current = _head;
                next = current.Next;
                pre = null;

                for (int j = 0; j < Length - i; j++)
                {
                    if (current.Value < next.Value)
                    {
                        tmp = current.Value;
                        current.Value = next.Value;
                        next.Value = tmp;
                    }

                    pre = current;
                    current = next;
                    next = next.Next;
                }

            }
        }
        public int RemoveByValueFisrt(int value)
        {

            int indexOfValue = FirstIndexByValue(value);
            RemoveByIndex(indexOfValue);

            return indexOfValue;
        }
        public int RemoveByValueAll(int value)
        {
            int count = 0;
            int index;
            for (int i = 1; i < Length; i++)
            {

                index = RemoveByValueFisrt(value);
                if (index < Length)
                {
                    count++;
                }

            }
            return count;
        }

        public void AddDoubleLinkedListByIndex(int index, DoubleLinkedList insertList)
        {
            CheckIndex(index);
            DoubleLinkedList copyList = CopyList(insertList);
            DoubleLinkedNode currentCopy = copyList._head;
            DoubleLinkedNode tailCopy = copyList._tail;

            DoubleLinkedNode preIndex = GetDoubleNodeByIndex(index - 1);
            DoubleLinkedNode curIndex = GetDoubleNodeByIndex(index);


            if (index == 0)
            {
                tailCopy.Next = this._head;
                _head = currentCopy;
            }
            else
            {
                currentCopy.Previous = curIndex;
                tailCopy.Next = curIndex;
                curIndex.Next = currentCopy;
            }

            this.Length += copyList.Length;
        }




        private DoubleLinkedList CopyList(DoubleLinkedList list)
        {
            DoubleLinkedList copyList = new DoubleLinkedList();

            for (int i = 0; i < list.Length; i++)
            {
                copyList.Add(list[i]);
            }
            return copyList;
        }
        private DoubleLinkedNode GetDoubleNodeByIndex(int index)
        {
            DoubleLinkedNode current;

            if (index < Length / 2)
            {
                current = _head;
                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
                return current;
            }
            else
            {
                current = _tail;
                for (int i = Length - 2; i >= index; i--)
                {
                    current = current.Previous;
                }
                return current;
            }
        }

        public override bool Equals(object obj)
        {
            DoubleLinkedList list = (DoubleLinkedList)obj;
            if (this.Length != list.Length)
            {
                return false;
            }
            DoubleLinkedNode currentThis = _head;
            DoubleLinkedNode currentList = list._head;

            if (currentThis.Value != currentList.Value)
            {
                return false;
            }

            while (!(currentThis.Next is null))
            {
                currentList = currentList.Next;
                currentThis = currentThis.Next;
                if (currentThis.Value != currentList.Value)
                {
                    return false;
                }
            }

            currentThis = _tail;
            currentList = list._tail;

            if (currentThis.Value != currentList.Value)
            {
                return false;
            }

            while (!(currentThis.Previous is null))
            {
                currentList = currentList.Previous;
                currentThis = currentThis.Previous;
                if (currentThis.Value != currentList.Value)
                {
                    return false;
                }
            }


            return true;
        }
        public override string ToString()
        {
            string s = "";
            if (Length != 0)
            {
                DoubleLinkedNode current = _head;
                s += current.Value;
                while (!(current.Next is null))
                {
                    current = current.Next;
                    s += " " + current.Value;
                }
                return s;
            }
            return s;

        }

        private void CreateEmptyDoubleLinkedList()
        {
            Length = 0;
            _head = null;
            _tail = null;
        }
        private void CheckIndex(int index)
        {
            if (index < 0 && index >= Length)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
