using System;
using System.Text;
using System.Collections.Generic;
namespace List
{
    public class LinkedList
    {

        public int Length { get; private set; }

        private Node _head;
        private Node _tail;

        public int this[int index]
        {
            get
            {
                Node current = GetNodeByIndex(index);
                return current.Value;
            }
            set
            {
                Node current = GetNodeByIndex(index);
                current.Value = value;  

            }
        }

        public LinkedList()
        {
            Length = 0;
            _head = null;
            _tail = null;
        }


        public LinkedList(int value)
        {
            CreateListWithOneElement(value);
        }

        public LinkedList (int[] values)
        {
            Length = values.Length;
            _head = new Node(values[0]);
            _tail = _head;

            if (values.Length != 0)
            {

                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new Node(values[i]);
                    _tail = _tail.Next;
                }

            }
            else
            {
               _head = null;
                _tail = null;
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

        public void AddByIndex(int index, int value)
        {
            CheckIndex( index);
            if (Length == 0)
            {
                CreateListWithOneElement(value);
            }
            else if (index == 0)
            {
                Node current = new Node(value);
                current.Next = _head;
                _head = current;
                Length++;
            }
            else if (index == Length)
            {
                _tail.Next = new Node(value);
                _tail = _tail.Next;
                Length++;
            }
            else
            {

                Node current = GetNodeByIndex(index-1);

                Node tmp = new Node(value);
                tmp.Next = current.Next;
                current.Next = tmp;
                Length++;
            }

        }


        public void RemoveLastElement()
        {
            Length--;
        }

        public void RemoveFirstElement()
        {
            Node current = _head;
            _head = current.Next;
            Length--;
        }
        public void RemoveByIndex(int index)
        {
            CheckIndex(index);
            Node preIndex = GetNodeByIndex(index-1); // тут получаем индекс , который перед нужным
            Node current = GetNodeByIndex(index);

            preIndex.Next = current.Next;
            Length--;

        }

        public void RemoveByEndXElements(int xElements)
        {
            Length -= xElements;
        }

        public void RemoveByStartXElements(int xElements )
        {

            for (int i = xElements; i > 0; i--)
            {
                RemoveFirstElement();
            }
        }

        public void RemoveByIndexXElements(int index,int xElements)
        {
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

            Node current = _head;

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
            Node tmp = GetNodeByIndex(index);
            tmp.Value = value;
        }

        public void Reverse()
        {
            Node pre = null;
            Node current = _head;

            Node next = null;
            while (current != null)
            {
                next = current.Next;

                current.Next = pre;
                pre = current;
                current = next;

            }
            _head = pre;
            _tail = current;  
           
        }

        public (int, int) MaxValue()
        {
            int indexOfMaxValue = 0;
            Node current = _head;
            Node maxValue = _head;


            for (int i = 1; i < Length; i++)
            {
                if(maxValue.Value < current.Next.Value) 
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
           
            Node current = _head;
            Node minValue = _head;
            int indexOfMinValue = 0;
            int min = 0;
            
            for (int i =1; i < Length; i ++)
            {
                if(minValue.Value > current.Next.Value)
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
            Node current ;
            Node next ;
            Node pre ;
            for(int i = 1; i < Length; i++)
            {
                current = _head;
                next = current.Next;
                pre = null;

                for (int j = 0; j < Length-i; j++)
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
            Node current;
            Node next;
            Node pre;
            for (int i = 1; i < Length; i++)
            {
                current = _head;
                next = current.Next;
                pre = null;

                for(int j = 0; j < Length - i; j++)
                {
                    if(current.Value < next.Value)
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
            for(int i = 1; i < Length; i++)
            {

                index = RemoveByValueFisrt(value);
                if(index < Length)
                {
                    count++;
                }

            }
            return count;
        }

        public void AddLinkedListByFirstIndex( LinkedList insertList)
        {
            AddLinkedListByIndex(0, insertList);
        }

         public void AddLinkedListToEnd(LinkedList insertList)
        {
            AddLinkedListByIndex(Length, insertList);
        }


        public void AddLinkedListByIndex(int index, LinkedList insertList)
        {
            CheckIndex(index);  
            LinkedList copyList = CopyList(insertList);
            Node currentCopy = copyList._head;
            Node tailCopy = copyList._tail;

            Node preIndex = GetNodeByIndex(index - 1);
            Node curIndex = GetNodeByIndex(index);


            if (index == 0)
            {
                tailCopy.Next = this._head;
                _head = currentCopy;
            }
            else
            {
                preIndex.Next = currentCopy;
                tailCopy.Next = curIndex;
            }

            this.Length += copyList.Length;
        }

        public override bool Equals(object obj)
        {
            LinkedList list = (LinkedList)obj;
            if( this.Length != list.Length)
            {
                return false;   
            }
            Node currentThis = _head;
            Node currentList = list._head;

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

            return true;
        }
        public override string ToString()
        {
            string s = "";
            if (Length != 0)
            {
                Node current = _head;
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

       
            private Node GetNodeByIndex(int index)
        {
            Node current = _head;
            for (int i = 1; i <= index; i++)
            {
                current = current.Next;
            }

            return current;
        }
        private void CreateListWithOneElement(int value)
        {
            Length = 1;
            _head = new Node(value);
            _tail = _head;
        }

        private void CheckIndex(int index)
        {
            if(index < 0 && index >= Length)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private LinkedList CopyList(LinkedList list)
        {
            LinkedList copyList = new LinkedList();

            for (int i = 0; i < list.Length; i++)
            {
                copyList.Add(list[i]);
            }
            return copyList;
        }
        private void CheckArrayIsNotEmpty()
        {
            if (Length == 0)
            {
                throw new Exception("Array is empty");
            }
        }
    }
}
