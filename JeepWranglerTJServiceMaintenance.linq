<Query Kind="Statements" />

Console.WriteLine("Enter your Jeep Wrangler TJ's current mileage");
int currentMileage = Int32.Parse(Console.ReadLine());

// Round up to the next scheduled maintenance: https://stackoverflow.com/questions/3920553/how-to-round-up-value-c-sharp-to-the-nearest-integer
double nextScheduledMaintenance = Math.Ceiling(currentMileage / 7500.0) * 7500;
double prevScheduledMaintenance = Math.Ceiling(currentMileage / 7500.0) * 7500 - 7500;

List<string> maintenances = new List<string>();

if (nextScheduledMaintenance % 7500 == 0)
{
	maintenances.Add("Change the engine oil");
	maintenances.Add("Replace engine oil filter");
	maintenances.Add("Lubricate the steering linkage (tie rod ends)");
};

if (nextScheduledMaintenance % 15000 == 0)
{
	maintenances.Add("Lubricate the steering and suspension ball joints");
};

if (nextScheduledMaintenance % 22500 == 0)
{
	maintenances.Add("Inspect the brake linings");
};

if (nextScheduledMaintenance % 30000 == 0)
{
	maintenances.Add("Replace engine air filter");
	maintenances.Add("Replace spark plugs");
	maintenances.Add("Inspect drive belt, adjust tension as necessary");
	maintenances.Add("Drain and refill automatic transmission fluid");
	maintenances.Add("Drain and refill transfer case fluid");
};

if (nextScheduledMaintenance % 37500 == 0)
{
	maintenances.Add("Drain and refill manual transmission fluid");
};

if (nextScheduledMaintenance >= 45000)
{
	if (nextScheduledMaintenance == 45000)
	{
		maintenances.Add("Flush and replace engine coolant at 36 months regardless of mileage");
	}
	
	else if ((nextScheduledMaintenance - 45000) % 30000 == 0) //begins each 30,00 miles after the first flush
	{
		maintenances.Add("Flush and replace engine coolant if it has been 30,000 miles (48 000 km) or 24 months since last change");
	};
};

if (nextScheduledMaintenance >= 52500)
{
	if (nextScheduledMaintenance == 52500)
	{
		maintenances.Add("Flush and replace engine coolant if not done at 36 months");
	}
	
	if ((nextScheduledMaintenance - 52500) % 30000 == 0) //reminder begins each 30,00 miles after the first flush
	{
		maintenances.Add("Flush and replace engine coolant if it has been 30,000 miles (48 000 km) or 24 months since last change");
	}
};

if (nextScheduledMaintenance % 60000 == 0)
{
	maintenances.Add("Replace ignition cables");
};


Console.WriteLine($"Your car miliage is: {String.Format("{0:n0}", currentMileage)}\n");
Console.WriteLine($"=====================================================================\n");
Console.WriteLine($"Your next scheduled maintenances due at {String.Format("{0:n0}", nextScheduledMaintenance)} miles ({String.Format("{0:n0}", Math.Floor((nextScheduledMaintenance * 1.60934)/1200) * 1200)} km)\n"); //check the math

Console.WriteLine($"Your will need perform the following service maintenances on your vehicle:");
foreach (string maintenance in maintenances)
{
	Console.WriteLine($" [  ]  {maintenance}");
}

Console.WriteLine($"\n=====================================================================\n");
Console.WriteLine($"Your previous scheduled maintenances was due at {String.Format("{0:n0}", prevScheduledMaintenance)} miles ({String.Format("{0:n0}", Math.Floor((prevScheduledMaintenance * 1.60934) / 1200) * 1200)} km)\n"); //check the math