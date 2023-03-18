namespace book.part1.variables;

class Variables
{
    public static void VariablesFunc()
    {
        Console.Title = "Variables";
        Console.Beep(2000, 250);

        int binaryLiteral = 0b00001101;
        int hexadecimalLiteral = 0xFF00FF;
        char baseball = '⚾';

        Console.WriteLine(binaryLiteral + " is 13 but in binary");
        Console.WriteLine(hexadecimalLiteral + " is magenta color but in hexadecimal");
        Console.WriteLine(baseball + " is single unicode character");

        char a = '\u0061';
        Console.WriteLine(a + " is a but in hexadecimal unicode number");

        // float has 6 to 7 digits of precision
        // double has 15 to 16 digits of precision
        // decimal has 28 to 29 digits of precision

        float floatNumber = 3.14f; // f or F at the end makes it a float literal
        decimal decimalNumber = 3.14m; // m or M at the end makes it a decimal literal

        double avogadrosNumber = 6.022e23;
        Console.WriteLine("Avogadro's number is " + avogadrosNumber);
        
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }
}
