using System;
public abstract class BaseList<T> where T : IComparable
{
    protected int count = 0;
    public int Count
    {
        get { return count; }
    }//дописать
    public abstract void Add(T a);
    public abstract void Delete(int pos);
    public abstract void Insert(int pos, T a);
    public abstract void Clear();

    /*int CompareTo(BaseList<T> other)
    {
        if (count == other.Count)
            return 0;
        if (count > other.Count)
            return 1;
        if (count < other.Count)
            return -1;
    }
    */
    public abstract int Lenght();
    public abstract T this[int i]
    { set; get; }
    public abstract void Print();
    public void Assign(BaseList<T> sourceList)//A.Assign(B) => A превращается в В
    {
        Clear();
        for (int i = 0; i < sourceList.Count; i++)
        {
            Add(sourceList[i]);
        }
    }
    public void AssignTo(BaseList<T> destList)//A.Assign(B) => B превращается в A
    {
        destList.Assign(this);
    }
    public abstract BaseList<T> Clone();
    public virtual void Sort()
    {
        for (int current = 0; current < count - 1; current++)
        {
            int minIndex = current;

            for (int i = current + 1; i < count; i++)
                if (this[minIndex].CompareTo(this[i]) == 1)
                    minIndex = i;



            T buf = this[current];
            this[current] = this[minIndex];
            this[minIndex] = buf;
        }
    }
    public bool EqualsTo(BaseList<T> otherList)
    {
        if (this.Count != otherList.Count)
            return false;
        for (int i = 0; i < otherList.Count; i++)
            if (this[i].CompareTo(otherList[i]) != 1)
                return false;

        return true;
    }
}
