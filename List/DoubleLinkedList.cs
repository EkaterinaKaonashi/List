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
        public void RemoveLastElement()
        {
            //проверка не пустой ли список
            Length--;
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
            Length -= xElements;
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
            //DoubleLinkedNode current = _head;
            //DoubleLinkedNode next = current.Next;
            //next.Previous = current;
            //DoubleLinkedNode tmp;

            //while (!(current is null))
            //{
            //    tmp = current.Next;
            //    current.Previous = current.Next;
            //    current.Next = tmp;
            //    current = current.Previous;
            //}
            //_head = GetDoubleNodeByIndex(0);
            //_tail = current;
            //_tail = _head;




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
