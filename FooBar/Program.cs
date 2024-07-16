<<<<<<< HEAD
﻿class Program
{
    static void Main()
    {
        for (int n = 0; n <= 15; n++)
        {
            string a = "";

            if (n != 0 && n % 3 == 0)
            {
                a += "Foo";
            }
            if (n != 0 && n % 5 == 0)
            {
                a += "Bar";
            }
            if (a == "")
            {
                a = n.ToString();
            }

            Console.WriteLine(a);
        }
    }
=======
﻿class Program
{
    static void Main()
    {
        for (int n = 0; n <= 15; n++)
        {
            string a = "";

            if (n != 0 && n % 3 == 0)
            {
                a += "Foo";
            }
            if (n != 0 && n % 5 == 0)
            {
                a += "Bar";
            }
            if (a == "")
            {
                a = n.ToString();
            }

            Console.WriteLine(a);
        }
    }
>>>>>>> 1e47bfd56709bc1ca886ff290086b12714cdf0ec
}