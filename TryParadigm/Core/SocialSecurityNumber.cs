public class SocialSecurityNumber
{
    public int Locale { get; private set; }
    public int TwoPart { get; private set; }
    public int Identifier { get; private set; }

    public static SocialSecurityNumber Empty { get; set; } = new SocialSecurityNumber();

    private SocialSecurityNumber() { }

    private SocialSecurityNumber(string input)
    {
        // Do some sort of parsing, possibly could throw an exception.  Purposely or Exceptionally.
    }

    public static SocialSecurityNumber Parse(string input)
    {
        return new SocialSecurityNumber(input);
    }

    public static bool TryParse(string input, out SocialSecurityNumber ssn)
    {
        ssn = Empty;
        try
        {
            ssn = new SocialSecurityNumber(input);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public override string ToString() => $"{Locale}-{TwoPart}-{Identifier}";
}