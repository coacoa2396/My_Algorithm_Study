﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructure
{
    public class List<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;
        private int count;
        public bool IsFull { get { return count == items.Length; } }
        public List()
        {
            items = new T[DefaultCapacity];
            count = 0;
        }
        
        public List(int capacity)
        {
            items = new T[capacity];
            count = 0;
        }
        public int Capacity { get { return items.Length; } }
        public int Count { get { return count; } }


        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();

                return items[index];
            }
            set
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();

                items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (IsFull)       // 가득 차 있는 경우
                Grow();

            items[count++] = item;
        }

        public void Insert(int index, T item)
        {
            // 예외처리 필요 : 크기를 벗어나게 중간에 끼워넣는 것은 불가능
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException("index");
            
            if (IsFull)
                Grow();

            Array.Copy(items, index, items, index + 1, count - index);

            items[index] = item;
            count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            // 예외처리 필요 : 크기를 벗어나게 중간에 빼는 것은 불가능
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException("index");

            count--;
            //Array.Copy(items, index + 1, items, index);
        }
         
        public int IndexOf(T item)
        {
            for(int i = 0; i < count; i++)
            {
                if (item.Equals(items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public int FindIndex(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException();

            for (int i = 0; i < count; i++)
            {
                if (match(items[i]))
                    return i;
            }
            return -1;
        }

        private void Grow()
        {            
            T[] newItems = new T[items.Length * 2];
            Array.Copy(items, newItems, items.Length);
            items = newItems;                 
        }



    }
}
