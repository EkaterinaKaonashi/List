using System;
namespace List
{
    public class ArrayList
    {
        public int Length { get; private set; }

        public int Capacity => _array.Length;

        private int[] _array;

        public ArrayList()
        {
            Length = 0; 
            _array = new int[10];
        } //23.1

        public ArrayList(int value)
        {
            Length = 1;
            _array = new int[10];
            _array[0] = value;
        } //23.2

        public ArrayList(int[] array)
        {
            _array = new int[array.Length];
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = array[i];
            }

            Length = array.Length;

        } //23.4

        public int this[int index]
        {

            get
            {
                if (index > Length && index < 0)
                {
                    throw new ArgumentOutOfRangeException("Индекс вне массива");
                }
                return _array[index];
            }

            set
            {
                if (index > Length && index < 0)
                {
                    throw new ArgumentOutOfRangeException("Индекс вне массива");
                }

                _array[index] = value;
            }
        } // 11 Индексатор

        public void Add(int value)
        {
          AddByIndex(Length, value);
        } //1

        public void AddByZeroIndex(int value)
        {
            AddByIndex(0, value);
        } //2

        public void AddByIndex(int index, int value)
        {
            UpSize();
            Length++;

            for (int i = 0; i < Length; i++)
            {
                if (i == index)
                {
                    ShiftToRight(index);
                    _array[index] = value;
                }
            }
        } //3

        public void RemoveLastElement()
        {
            Length--;
        } //4

        public void RemoveFirstElement()
        {
            RemoveByIndex(0);
        }  // 5

        public void RemoveByIndex(int index) // 6
        {
            ShiftToLeft(index);
            Length--;
            DownSize();
        }

        public void RemoveXElementsByEnd(int x) //7
        {
            Length -= x;
        }

        public void RemoveXElementsByStart(int x) // 8
        {
            ClearByIndexXElements(x, 0);
        }

        public void ClearByIndexXElements(int x, int startPoint )
        {
            if (x + startPoint> Length  )
            {
                throw new ArgumentException("Переданное число больше длинны массива");
            }
            for (int i = x; i > 0; i--)
            {
                RemoveByIndex(startPoint );
            }
        }  // 9

        public int arrayLength()
        {
            return Length;
        } // 10

        public int FirstIndexByValue(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    return i;
                }
            }
            return -1;
        } //12

        public void ChangeValueByIndex(int index, int value)
        {
            _array[index] = value;
        }  //13

        public void Reverse()
        {
            int tmpValue = 0;
            for (int i = 0; i < Length / 2; i++)
            {
                tmpValue = _array[i];
                _array[i] = _array[Length - 1 - i];
                _array[Length - 1 - i] = tmpValue;
            }

        } //14

        public int MaxValue()
        {
            CheckArrayIsNotEmpty();
            int maxValue = _array[0];

            for (int i = 0; i < Length; i++)
            {
                if (_array[i] > maxValue)
                {
                    maxValue = _array[i];
                }
            }
            return maxValue;
        } //15


        public int MinValue()
        {
            CheckArrayIsNotEmpty();
            int minValue = _array[0];

            for (int i = 0; i < Length; i++)
            {
                if (_array[i] < minValue)
                {
                    minValue = _array[i];
                }
            }

            return minValue;
        } //16

        public int IndexOfMaxValue()
        {
            CheckArrayIsNotEmpty();

            int indexOfMaxValue = 0;

            for (int i = 0; i < Length; i++)
            {
                if (_array[i] > _array[indexOfMaxValue])
                {
                    indexOfMaxValue = i;
                }
            }

            return indexOfMaxValue;
        } //17

        public int IndexOfMinValue()
        {
            CheckArrayIsNotEmpty();
            int indexOfMinValue = 0;

            for (int i = 0; i < Length; i++)
            {
                if (_array[i] < _array[indexOfMinValue])
                {
                    indexOfMinValue = i;
                }
            }

            return indexOfMinValue;
        } //18

        public void SortAscending()
        {
            for (int i = 1; i < Length; i++)
            {
                for (int j = 0; j < Length - i; j++)
                {
                    int tmp;

                    if (_array[j + 1] < _array[j])
                    {
                        tmp = _array[j];
                        _array[j] = _array[j + 1];
                        _array[j + 1] = tmp;
                    }
                }
            }
        } //19
        

        public void SortDescending()
        {
            for (int i = 1; i < Length; i++)
            {
                for (int j = 0; j < Length - i; j++)
                {
                    int tmp;

                    if (_array[j + 1] > _array[j])
                    {
                        tmp = _array[j];
                        _array[j] = _array[j + 1];
                        _array[j + 1] = tmp;
                    }
                }
            }
        } //20

        public int RemoveByValueFisrt(int value)
        {


            //for (int i = 0; i < Length; i++)
            //{
            //    if (value == _array[i])
            //    {
            //        index = i;
            //        ShiftToLeft(i);
            //        Length--;
            //        return index;
            //    }
            //}
            int index = RemoveByValueAll(value, 1);


            return index; 
        } //21

        public int RemoveByValueAll(int value ,int removeFirst = 0)
        {
            int count = 0;

            for (int i = 0; i < Length; i++)
            {
                if(_array[i] == value)
                {
                    ShiftToLeft(i);
                    Length--;
                    count++;
                    if (removeFirst == 1)
                    {
                        return count;
                    }
                }
                
            }

            return count;
        } //22

        public void AddArrayListInEnd(ArrayList insertArray)
        {
            AddArrayListByIndex(Length, insertArray);

        } // 24

        public void AddArrayListByFirstIndex(ArrayList insertArray)
        {
            AddArrayListByIndex(0, insertArray);
        } //25

        public void AddArrayListByIndex(int index, ArrayList insertArray)
        {
            int oldLength = Length;

            UpSize(insertArray.Length);

            Length += insertArray.Length;

            for (int i = oldLength; i >= index; i--)
            {
                _array[i + insertArray.Length] = _array[i];
            }

            for (int i = 0; i < insertArray.Length; i++)
            {
                _array[i + index] = insertArray[i];
            }

        } //26





        private void UpSize(int value = 1)
        {
            if (Length + value > _array.Length)
            {

                int newLength = (int)((_array.Length + value) * 1.33d + 1);

                ChangeArraySize(newLength);
            }
        }

        private void DownSize()
        {
            if (Length * 1.33 + 1 < _array.Length)
            {
                int newLength = (int)(_array.Length * 0.67d);

                ChangeArraySize(newLength);
            }
        }
        private void CheckArrayIsNotEmpty()
        {
            if (Length is 0)
            {
                throw new Exception("Массив пустой");
            }
        }

        private void ShiftToRight(int index = 0, int step = 1)
        {

            for (int i = Length; i > index; i--)
            {
                _array[i] = _array[i - step];
            }
        }

        private void ShiftToLeft(int index = 0, int step = 1)
        {
            for (int i = index; i < Length - 1; i++)
            {
                _array[i] = _array[i + step];

            }
            _array[Length - 1] = 0;
        }

        private void ChangeArraySize(int newLength)
        {
            int[] tmpArray = new int[newLength];

            for (int i = 0; i < Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < Length; i++)
            {
                s += _array[i] + " ";
            }
            return s;

        }

        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if (Length != arrayList.Length)
            {
                return false;
            }
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] != arrayList[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
