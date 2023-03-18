namespace book.part1.csharptypesystem;

class csharptypesystem
{
    public static void csharptypesystemFunc()
    {
        byte first = 255;
        int second = 255;
        long third = 255;
        uint fourth = 255;
        ulong fifth = 255;
        short sixth = 255;
        ushort seventh = 255;
        string eighth = "this is string";
        char ninth = 'a';
        float tenth = 3.2f;
        double eleventh = 3.2;
        decimal twelvth = 3.15m;
        bool thirteenth = true;
        sbyte fourteenth = 127;
        // displaying contents of each variable
        Console.WriteLine(first + " " + second + " " + third + " " + fourth + " " + fifth + " " + sixth + " " + seventh + " " + 
                          eighth + " " + ninth + " " + tenth + " " + eleventh + " " + twelvth
                          + " " + thirteenth + " " + fourteenth);
        // The Variable Shop Returns
        // assigning different literal value to each variable
        first = 0;
        second = -255;
        third = -255;
        fourth = 510;
        fifth = 510;
        sixth = -255;
        seventh = 510;
        eighth = "new string is here";
        ninth = 'b';
        tenth = -3.2f;
        eleventh = -3.200;
        twelvth = -3.200001m;
        thirteenth = false;
        fourteenth = -128;
        // displaying contents of each variable
        Console.WriteLine("New values are: " + first + " " + second + " " + third + " " + fourth + " " + fifth + " " + sixth + " " + seventh + " " + 
                          eighth + " " + ninth + " " + tenth + " " + eleventh + " " + twelvth
                          + " " + thirteenth + " " + fourteenth);
    }
}

