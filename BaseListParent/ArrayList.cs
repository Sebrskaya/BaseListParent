using System;
using System.Reflection;

public class ArrayList<T> : BaseList<T> where T : IComparable
{
    //public int count = 0;
    private T[] array = null;

    public override T this[int i]
    {
        get
        {
            CheckIndex(i);
            return array[i];
        }
        set
        {
            CheckIndex(i);
            array[i] = value;
        }
    }

    public void Expand()
    {
        if (array == null)
        {
            array = new T[1];
            return;
        }
        if (count < array.Length)
            return;
        T[] buf = new T[array.Length * 2];
        Array.Copy(array, 0, buf, 0, count);
        array = buf;
    }
    public override void Print()
    {
        if (array == null)
            return;
        //Console.WriteLine("Список:");
        for (int i = 0; i < count; i++)
            Console.Write(array[i] + " ");
        Console.Write("\n");
    }
    public override void Add(T a)
    {
        Expand();
        array[count] = a;
        count++;
    }
    public override void Insert(int pos, T a)
    {
        CheckIndex(pos, 1);

        if ((array == null & pos == 0) | pos == count)// Если массив пустой или позиция на следущей от последней ячейки, то Add()
        {
            Add(a);
            return;
        }
        if (pos > count | pos < 0 | (array == null & pos != 0))//проверка
            return;

        //Все остальные случаи
        Expand();
        for (int i = count; i >= pos; i--)
            if (i != 0)
                array[i] = array[i - 1];
        array[pos] = a;
        count++;
    }

    public override void Delete(int pos)
    {
        if (pos >= count | pos < 0)
            return;

        for (int i = pos; i < count; i++)
            if (count != 1)
            {
                Expand();
                array[i] = array[i + 1];
            }

        count--;
    }
    public override int Lenght()
    {
        //Console.WriteLine("Length of list: " + count);
        return count;
    }
    public override void Clear()
    {
        count = 0;
    }
    public override BaseList<T> Clone()
    {
        ArrayList<T> list = new ArrayList<T>();
        list.Assign(this);
        return list;
    }
}
