
using PowerPlantEntity;

public class Program
{
    static void Main(string[] args)
    {
        PowerPlant powerPlant = new PowerPlant();
        powerPlant.Warning += WarningToConsole;
        powerPlant.Warning += SucceedToConsole;

        int numberOfInvokes = 10;
        while (numberOfInvokes > 0)
        {
            powerPlant.HeadUp();
            numberOfInvokes--;
        }

	}

	public static void SucceedToConsole()
	{
		Console.Out.WriteLine("Success!");
	}

	public static void WarningToConsole()
    {
        Console.Out.WriteLine("Warning!");
    }

}
