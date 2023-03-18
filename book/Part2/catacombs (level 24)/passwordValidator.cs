namespace book.part2.catacombs.passwordValidator;

public class PasswordValidator
{
    public static void passwordValidatorFunc()
    {
        passwordValidator PV = new passwordValidator();
        while (true)
        {
            Console.Write("Enter a password: ");
            string? password = Console.ReadLine();
            if(PV.IsValid(password)) Console.WriteLine("Valid");
            else Console.WriteLine("Not valid");
        }
    }
}

class passwordValidator
{
    public bool IsValid(string password)
    {
        if (password.Length < 6) return false;
        if (password.Length > 13) return false;
        if (!HasLowerCase(password)) return false;
        if (!HasUpperCase(password)) return false;
        if (!HasDigit(password)) return false;
        if (Contains(password, 'T')) return false;
        if (Contains(password, '&')) return false;

        return true;
    }
    
    public bool HasLowerCase(string password)
    {
        foreach (char letter in password)
            if(char.IsLower(letter)) return true;
        
        return false;
    }

    public bool HasUpperCase(string password)
    {
        foreach (char letter in password)
            if(char.IsUpper(letter)) return true;

        return false;
    }
    
    public bool HasDigit(string password)
    {
        foreach (char letter in password)
            if(char.IsDigit(letter)) return true;

        return false;
    }

    public bool Contains(string password, char targetLetter)
    {
        foreach (char letter in password)
            if (letter == targetLetter) return true;

        return false;
    }
}