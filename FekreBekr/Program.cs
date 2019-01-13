using ConsoleExtender;

namespace FekreBekr
{
	internal static class Program
	{
		static Program()
		{
		}

		internal static string GetRandomNumber(int length)
		{
			string result = string.Empty;

			System.Random random =
				new System.Random(System.DateTime.Now.Millisecond);

			for (int index = 1; index <= length; index++)
			{
				int randomInt =
					random.Next(minValue: 1, maxValue: 9);

				result += randomInt;
			}

			return result;
		}

		static void Main(string[] args)
		{
			//var fonts = ConsoleHelper.ConsoleFonts;

			//for (int f = 0; f < fonts.Length; f++)
			//{
			//	System.Console.WriteLine("{0}: X={1}, Y={2}", fonts[f].Index, fonts[f].SizeX, fonts[f].SizeY);
			//}

			//ConsoleHelper.SetConsoleFont(15);

			//System.Console.WriteLine("Hello, World!");

			//System.Console.ReadLine();

			//ConsoleHelper.SetConsoleIcon(SystemIcons.Information);

			System.Console.Title = "FEKRE BEKR!";
			System.Console.Clear();

			System.Console.Write("Difficulty? ");
			string difficultyString = System.Console.ReadLine();
			int difficulty = System.Convert.ToInt32(difficultyString);

			string question =
				GetRandomNumber(length: difficulty);

			// TODO: In real game the below code should be commented!
			//System.Console.WriteLine(question);

			int level = 0;

			while (true)
			{
				level++;

				System.Console.ResetColor();

				System.Console.WriteLine();
				System.Console.WriteLine("[GUESS]");
				string guess = System.Console.ReadLine();

				bool win = true;

				for (int index = 0; index <= guess.Length - 1; index++)
				{
					if (guess[index] == question[index])
					{
						System.Console.BackgroundColor = System.ConsoleColor.Green;
						System.Console.ForegroundColor = System.ConsoleColor.Black;

						System.Console.Write("+");
					}
					else
					{
						win = false;

						if (question.Contains(guess[index].ToString()))
						{
							System.Console.BackgroundColor = System.ConsoleColor.Yellow;
							System.Console.ForegroundColor = System.ConsoleColor.Black;

							System.Console.Write("-");
						}
						else
						{
							System.Console.BackgroundColor = System.ConsoleColor.Red;
							System.Console.ForegroundColor = System.ConsoleColor.Black;

							System.Console.Write("*");
						}
					}
				}

				if (win)
				{
					System.Console.WriteLine();
					System.Console.WriteLine($"Congratulation! You Won in level { level }!");

					break;
				}
			}

			System.Console.WriteLine();
			System.Console.Write("Press [ENTER] To Exit... ");
			System.Console.ReadLine();
		}
	}
}
