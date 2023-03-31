namespace book.part2.generics.generics;

public class generics
{
    public static void Start()
    {
        /*
         Generics solve the problem of making classes or methods that would differ only by the types
         they use.
         Defining generic class: public class List<T> { public T GetItemAt(int index) { ... } ... }
         You can also make generic methods and generic types with multiple type parameters
         */

        List<int> numbers = new List<int>();
        numbers.Add(1);
        numbers.Add(2);
        for (int index = 0; index < numbers._items.Length; index++)
        {
            Console.WriteLine(numbers.GetItemAt(index));
        }
            
    }
}
// Generic List class
public class List<T>
{
    public T[] _items = new T[0];

    public T GetItemAt(int index) => _items[index];
    public void SetItemAt(int index, T value) => _items[index] = value;

    public void Add(T newValue)
    {
        T[] updated = new T[_items.Length + 1];

        for (int index = 0; index < _items.Length; index++)
            updated[index] = _items[index];

        updated[^1] = newValue;

        _items = updated;
    }
}

public class GameObject { }

public class Asteroid { }

// generic type constraint
public class GenericType<T, U> where T : GameObject where U : Asteroid { }