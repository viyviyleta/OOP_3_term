using System;
using System.Linq;

public class OneDimensionalArray
{
    private int[] array;

    public class Production
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }

        public Production(int id, string name)
        {
            Id = id;
            OrganizationName = name;
        }

        public override string ToString()
        {
            return $"Организация: {OrganizationName}, ID: {Id}";
        }
    }

    public class Developer
    {
        public int Id { get; set; }

        private int pipidastr;
        public string FullName { get; set; }
        public string Department { get; set; }

        public Developer(int id, string name, string departmenr)
        {
            Id = id;
            FullName = name;
            Department = departmenr;
        }

        public override string ToString()
        {
            return $"Организация {Department}, Имя {FullName}, ID {Id}";
        }
    }

    public Production production { get; set; }
    public Developer developer { get; set; }

    public OneDimensionalArray(int[] array)
    {
        this.array = array;
        this.production = new Production(1, "TV");
        this.developer = new Developer(2006, "Babich Violetta", "BSTU");
    }

    public int this[int index]
    {
        get { return array[index]; } 
        set { array[index] = value; } 
    }


    // Операторы перегрузки 
    public static OneDimensionalArray operator -(OneDimensionalArray arr, int scalar)
    {
        int[] result = arr.array.Select(x => x - scalar).ToArray();
        return new OneDimensionalArray(result);
    }

    public static bool operator >(OneDimensionalArray arr, int value)
    {
        return arr.array.Contains(value);
    }

    public static bool operator <(OneDimensionalArray arr, int value)
    {
        return !arr.array.Contains(value);
    }

    public static bool operator ==(OneDimensionalArray arr1, OneDimensionalArray arr2)
    {
        return arr1.array.Equals(arr2.array);
    }

    public static bool operator !=(OneDimensionalArray arr1, OneDimensionalArray arr2)
    {
        return !arr1.array.Equals(arr2.array);
    }

    public static OneDimensionalArray operator +(OneDimensionalArray arr1, OneDimensionalArray arr2)
    {
        int[] result = arr1.array.Concat(arr2.array).ToArray();
        return new OneDimensionalArray(result);
    }

    public override string ToString()
    {
        return string.Join(",", array);
    }

    public override bool Equals(object obj)
    {
        if(obj is OneDimensionalArray)
        {
            var other = (OneDimensionalArray)obj;
            return array.SequenceEqual(other.array);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return array.GetHashCode();
    }
}
