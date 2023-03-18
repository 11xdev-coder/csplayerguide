namespace book.part2.tuples;

class Tuples
{
    public static void TuplesFunc()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
        Console.Clear();
        Console.Title = "Tuples";
        Console.Beep(2000, 250);
        Console.WriteLine("LEVEL 17");
        string lol;
        int sussyNumber;
        string text;
        var someTuple = (lol: "lol", sussyNumber: 69, "item");
        Console.WriteLine($"lol is {someTuple.lol}, sussy number {someTuple.sussyNumber}, {someTuple.Item3}");
        (string, int, string) getTuple() => (lol: "lol", sussyNumber: 69, "item");
        someTuple = getTuple();
        Console.WriteLine($"again some nerd text: lol is {someTuple.lol}, sussy number {someTuple.sussyNumber}, {someTuple.Item3}");
        // Deconstructing Tuple (unpacking)
        (lol, sussyNumber, text) = someTuple;
        (seasoning, mainIngredient, foodType) food;
        // food type
        Console.Write("pick a food type \n" +
                      "1 - soup  \n" +
                      "2 - stew  \n" +
                      "3 - gumbo  \n" +
                      "ur choice: ");
        int choicedFoodType = Convert.ToInt32(Console.ReadLine());
        foodType finalFoodType = choicedFoodType switch   
        {
            1 => foodType.soup,
            2 => foodType.stew,
            3 => foodType.gumbo
        };
        // main ingredient
        Console.Write("pick main ingredient  \n" +
                      "1 - mushrooms  \n" +
                      "2 - chicken  \n" +
                      "3 - carrots  \n" +
                      "4 - potatoes  \n" +
                      "ur choice: ");
        int choicedMainIngredient = Convert.ToInt32(Console.ReadLine());
        mainIngredient finalMainIngredient = choicedFoodType switch   
        {
            1 => mainIngredient.mushroom,
            2 => mainIngredient.chicken,
            3 => mainIngredient.carrot,
            4 => mainIngredient.potato
        };
        // seasoning
        Console.Write("pick seasoning  \n" +
                      "1 - spicy  \n" +
                      "2 - salty  \n" +
                      "3 - sweet  \n" +
                      "ur choice: ");
        int choicedSeasoning = Convert.ToInt32(Console.ReadLine());
        seasoning finalSeasoning = choicedFoodType switch   
        {
            1 => seasoning.spicy,
            2 => seasoning.salty,
            3 => seasoning.sweet
        };

        food = (Seasoning: finalSeasoning, MainIngredient: finalMainIngredient,  FoodType: finalFoodType);
        (seasoning seasoningResult, mainIngredient mainIngredientResult, foodType foodTypeResult) = food;
        Console.WriteLine($"{seasoningResult} {mainIngredientResult} {foodTypeResult}");
    }
}

enum foodType
{
    soup,
    stew,
    gumbo
}
enum mainIngredient
{
    mushroom,
    chicken,
    carrot,
    potato
}
enum seasoning
{
    spicy,
    salty,
    sweet
}