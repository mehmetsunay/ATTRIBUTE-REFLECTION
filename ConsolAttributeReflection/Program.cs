using System;

namespace ConsolAttributeReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            person p1 = new person()
            {
                Name = "Gürkan",Age=45
            };

            Console.WriteLine(Control.Check(p1));
            Console.ReadLine();
           
        }
    }
   public  class person
    {   [Zorunlu]
        public string Name;
        [Zorunlu]
        public string ID;
        [Zorunlu]
        public int Age;

    }

    //[AttributeUsage(AttributeTargets.Field,AllowMultiple =false)]
    public class ZorunluAttribute : Attribute { }

    public static class Control
    {

        public static bool Check(person ins)
        {
            Type type = ins.GetType();
            foreach( var item in type.GetFields())
            {

                object[] attributes = item.GetCustomAttributes(typeof(ZorunluAttribute), true);

            if(attributes.Length!=0)
                {
                    object value = item.GetValue(ins);

                    if(value==null)
                    {
                        return false;

                    }

                }

            }
            return true;

        }




    }
       


}
