// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
namespace Melvor_Calculator
{
    public class Calculation
    {
        static void print(object s)
        {
            Console.WriteLine(s);
        }
        static float LevelCalculator(float TargetLevel, float CurrentEXP, out float T)
        {
            float L = TargetLevel;

            float TotalEXP = (float)(MathF.Pow(L, 2f) - L + 600f * ((MathF.Pow(2f, L / 7f) - MathF.Pow(2f, 1f / 7f)) / (MathF.Pow(2f, 1f / 7f) - 1f))) / 8;
            T = TotalEXP;
            print("Current EXP is: " + CurrentEXP);
            TotalEXP -= CurrentEXP;
            print("Target level: " + TargetLevel + "\nEXP needed to reach target level: " + MathF.Round(TotalEXP));
            return TotalEXP;
        }
        static float ExpPerSecondCalculator(float ExpPerCompletion, float SecondsPerCompletion, float CompletionRate, out float TEPS, out float NCR)
        {
            float ExpPerSecond;
            if (SecondsPerCompletion == 1)
            {
                 ExpPerSecond = ExpPerCompletion;
            }
            else
            {
                ExpPerSecond = ExpPerCompletion / SecondsPerCompletion;
            }
            print(ExpPerSecond);
            float NewCompletionRate = 1 / (CompletionRate / 100);
            NCR = NewCompletionRate;
            //1 over ___
            print("1\n-\n"+NewCompletionRate);
            float TrueExpPerSecond = ExpPerSecond / NewCompletionRate;
            TEPS = TrueExpPerSecond;
            //print("Your 'true' exp per second " + TrueExpPerSecond + "/s");
            return TrueExpPerSecond;
        }
        static void TimeToGetLevelsCalculator(float TrueExpPerSecond, float TotalEXP, float SecondsPerCompletion, out float Time, out float TotalCompletions)
        {

            Time = TotalEXP / TrueExpPerSecond;
            TotalCompletions = Time / SecondsPerCompletion;
            //print("It will take " + MathF.Ceiling(TotalCompletions) + " Completions");
        }
        void GetInput(out float a, out float b, out float c, string? p = "")
        {
            try
            {
                Console.WriteLine("Enter your current level: ");
                a = (float)Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter your current EXP level (optional): ");
                ConsoleKey k = Console.ReadKey().Key;
                if (k != ConsoleKey.Enter)
                {
                    p = k.ToString()[1] + Console.ReadLine();

                    b = (float)Convert.ToDouble(p);
                }
                else
                    b = -1;
                Console.WriteLine("Enter your target level: ");
                c = (float)Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error: user too dumb and put in something other than a number");
                GetInput(out a, out b, out c);
            }
        }
        void GetInput2(out float a, out float b, out float c)
        {
            try
            {
                Console.WriteLine("Enter the exp gain per completion: ");
                a = (float)Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter your time per completion (seconds): ");
                b = (float)Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter your completion percent (optional & full number not decimal): ");
                ConsoleKey k = Console.ReadKey().Key;
                if (k != ConsoleKey.Enter)
                    c = (float)Convert.ToDouble((k.ToString() + Console.ReadLine()));
                else
                    c = 100;
            }
            catch (Exception)
            {
                Console.WriteLine("Error: user too dumb and put in something other than a number");
                GetInput2(out a, out b, out c);
            }
        }
        public static string FullCalculator(float EL, float TL, float EGPC, float TPC, float CR, out float TEPS, out float TotalCompletions,out float NCR, out float TotalEXP)
        {
            float Time;
            if (CR >= 0)
            {
                CR = 100;
            }
            //GetInput(out CL, out EL, out TL);
            //GetInput2(out EGPC, out TPC, out CR);
            TimeToGetLevelsCalculator(
                ExpPerSecondCalculator(EGPC, TPC, CR, out TEPS, out NCR),
                LevelCalculator(TL, EL, out TotalEXP),
                TPC, out Time, out TotalCompletions);

            if (Time / 60 >= 1)
            {
                if (Time / 60 / 60 >= 1)
                {
                    if (Time / 60 / 60 / 24 >= 1)
                    {
                        if (Time / 60 / 60 / 24 / 7 >= 1)
                        {
                            if (Time / 60 / 60 / 24 / 7 / (52 / 12f) >= 1)
                            {
                                if (Time / 60 / 60 / 25 / 7 / 52 >= 1)
                                {
                                    int years = (int)Time / 4492800;
                                    int months = ((int)Time % 4492800) / 345600;
                                    int weeks = ((int)Time % 345600) / 604800;
                                    int days = ((int)Time % 604800) / 86400;
                                    int a = ((int)Time % 86400) / 3600;
                                    int b = ((int)Time % 3600) / 60;
                                    float c = Time % 60;
                                    return ("It will take you " + years + " years, " + months + " months, " + weeks + " weeks, " + days + " days, " + a + " hours, " + b + " minutes, " + MathF.Round(c) + " seconds to complete");
                                }
                                else
                                {
                                    int months = ((int)Time) / 345600;
                                    int weeks = ((int)Time % 345600) / 604800;
                                    int days = ((int)Time % 604800) / 86400;
                                    int a = ((int)Time % 86400) / 3600;
                                    int b = ((int)Time % 3600) / 60;
                                    float c = Time % 60;
                                    return ("It will take you " + months + " months, " + weeks + " weeks, " + days + " days, " + a + " hours, " + b + " minutes, " + MathF.Round(c) + " seconds to complete");
                                }
                            }
                            else
                            {
                                int weeks = ((int)Time / 604800);
                                int days = ((int)Time % 604800) / 86400;
                                int a = ((int)Time % 86400) / 3600;
                                int b = ((int)Time % 3600) / 60;
                                float c = Time % 60;
                                return ("It will take you " + weeks + " weeks, " + days + " days, " + a + " hours, " + b + " minutes, " + MathF.Round(c) + " seconds to complete");
                            }
                        }
                        else
                        {
                            int days = (int)Time / 86400;
                            int a = ((int)Time % 86400) / 3600;
                            int b = ((int)Time % 3600) / 60;
                            float c = Time % 60;
                            return ("It will take you " + days + " days, " + a + " hours, " + b + " minutes, " + MathF.Round(c) + " seconds to complete");
                        }
                    }
                    else
                    {
                        int a = (int)Time / 3600;
                        int b = ((int)Time % 3600) / 60;
                        float c = Time % 60;
                        return ("It will take you " + a + " hours, " + b + " minutes, " + MathF.Round(c) + " seconds to complete");
                    }
                }
                else
                {
                    int a = (int)Time / 60;
                    float b = Time % 60;
                    return ("It will take you " + a + " minutes, " + MathF.Round(b) + " seconds to complete");
                }
            }
            else
            {
                return ("It will take you " + MathF.Round(Time) + " seconds to complete");
            }
        }
    }
}