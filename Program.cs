using System;

class Program
{
    static double Period(double x)
    {
        return x - Math.Floor(x / 360) * 360;
    }

    static double Sink(double x)
    {
        x = Period(x);
        if ((x >= 45 && x <= 135) || (x >= 315))
        {
            return 1;
        }
        else if (x >= 225 && x <= 315)
        {
            return -1;
        }
        else if (x <= 45 || x >= 315)
        {
            return Math.Tan(x * Math.PI / 180);
        }
        else if (x >= 135 && x <= 225)
        {
            return -Math.Tan(x * Math.PI / 180);
        }
        else
        {
            throw new ArgumentException("Invalid input.");
        }
    }

    static double Cosk(double x)
    {
        x = Period(x);
        if (x <= 45 || x >= 315)
        {
            return 1;
        }
        else if (x >= 135 && x <= 225)
        {
            return -1;
        }
        else if (x >= 45 && x <= 135)
        {
            return Math.Cos(x * Math.PI / 180) / Math.Sin(x * Math.PI / 180);
        }
        else if (x >= 225 && x <= 315)
        {
            return -Math.Cos(x * Math.PI / 180) / Math.Sin(x * Math.PI / 180);
        }
        else
        {
            throw new ArgumentException("Invalid input.");
        }
    }

    static double Arcsink(double x)
    {
        if (x < -1 || x > 1)
        {
            throw new ArgumentException("Arcsink x is only defined for -1 <= x <= 1.");
        }

        return Math.Atan(x) * 180 / Math.PI;
    }

    static double Arccosk(double x)
    {
        if (x < -1 || x > 1)
        {
            throw new ArgumentException("Arccosk x is only defined for -1 <= x <= 1.");
        }

        double result = Math.Atan(1 / x) * 180 / Math.PI;
        if (x < 0)
        {
            result += 180;
        }
        return result;
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Vad skulle du vilja veta? (svara med heltal bredvid dessa alternativ)");
            Console.WriteLine("1. Ett värde för Sink (sinuskvadraticus)");
            Console.WriteLine("2. Ett värde för Cosk (cosinuskvadraticus)");
            Console.WriteLine("3. Ett värde för Arcsink (arcsinuskvadraticus)");
            Console.WriteLine("4. Ett värde för Arccosk (arccosinuskvadraticus)");
            Console.WriteLine("5. Avsluta program");
            try
            {
                int svar = int.Parse(Console.ReadLine());
                if (svar == 5)
                {
                    break;
                }
                else if (svar > 0 && svar < 5)
                {
                    switch (svar)
                    {
                        case 1:
                            Console.WriteLine("Ange det värde du vill veta för Sink");
                            double y = double.Parse(Console.ReadLine());
                            double sinkResult = Sink(y);
                            Console.WriteLine("Sink({0}) = {1}", y, sinkResult);
                            break;
                        case 2:
                            Console.WriteLine("Ange det värde du vill veta för Cosk");
                            double x = double.Parse(Console.ReadLine());
                            double coskResult = Cosk(x);
                            Console.WriteLine("Cosk({0}) = {1}", x, coskResult);
                            break;
                        case 3:
                            Console.WriteLine("Ange det värde du vill veta för Arcsink");
                            double b = double.Parse(Console.ReadLine());
                            double arcsinkResult = Arcsink(b);
                            Console.WriteLine("Arcsink({0}) = {1}", b, arcsinkResult);
                            break;
                        case 4:
                            Console.WriteLine("Ange det värde du vill veta för Arccosk");
                            double a = double.Parse(Console.ReadLine());
                            double arccoskResult = Arccosk(a);
                            Console.WriteLine("Arccosk({0}) = {1}", a, arccoskResult);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Fel inmatning. Försök igen och följ instruktioner.");
                }

            }
            catch
            {
                Console.WriteLine("Fel inmatning. Försök igen och följ instruktioner.");
            }

        }
    }
}
