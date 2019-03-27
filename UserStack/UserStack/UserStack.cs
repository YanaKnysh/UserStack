using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserStack
{
    public class UserStack<T> :  IEnumerator<T>, IEnumerable<T>
    {
        private T[] array;
        private int count;
        private int top;
        int position;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public T Current
        {
            get
            {
                if (position > top)
                {
                    throw new InvalidOperationException();
                }

                return array[position];
            }
        }

        object IEnumerator.Current => (position >= top) ? throw new InvalidOperationException() : array[position];

        public UserStack() : this(10)
        {
        }

        public UserStack(int n)
        {
            array = new T[n];
            top = -1;
            count = 0;
            position = -1;
        }

        public void Push(T item)
        {
            top++;

            if (top == array.Length)
            {
                Resize();
            }

            count++;
            array[top] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("UserStack is empty");
            }

            count--;
            top--;

            return array[top + 1];

        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("UserStack is empty");
            }

            return array[top];
        }

        private bool IsEmpty()
        {
            return top == -1 ? true : false;
        }

        private void Resize()
        {
            T[] newArr = new T[array.Length * 2];

            for (int i = 0; i < array.Length; i++)
            {
                newArr[i] = array[i];
            }

            array = newArr;
        }

        public bool MoveNext()
        {
            if(position < top)
            {
                position++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose()
        {
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this as IEnumerator<T>;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this as IEnumerator<T>;
        }
    }
}
