using System.Globalization;

namespace ApplicationLibrary
{
	public class AppClass
   {
      public static void Report_As_Equilateral()
      {
         Console.Write("Equilateral ");
      }
      public static void Report_As_Isosceles()
      {
         Console.Write("Isosceles ");
      }
      public static void Report_As_Right()
      {
         Console.Write("Right ");
      }
      public static void Report_As_None()
      {
         Console.Write("None ");
      }
      public static void Report_As_Error()
      {
         Console.Write("Error ");
      }

        public static void Report_As_Christmas()
        {
            Console.Write("Merry Christmas Mr Grinch ");
        }

        public static bool isEqualTo(double A, double B, double margin)
		{
			return Math.Abs(A - B) < margin;
		}

        public static bool is_In_Range(double A, double B, double C)
        {
			double min_value = Math.Pow(10, -100);
			double max_value = Math.Pow(10, 100);
			bool in_Range = true;

            if (A < min_value || A > max_value || B < min_value || B > max_value || C < min_value || C > max_value) 
            {
                in_Range = false;
            }
            return in_Range;
        }

        public static bool is_Triangle(double A, double B, double C)
		{
			bool result = false;
			if ((A+B)>C && (B+C)>A && (A+C)>B)
				{
				result = true;
			}
			return result;
		}

		public static bool is_Equilateral(double A, double B, double C)
		{
			bool result = false;
			if (isEqualTo(A,B,0.001) && isEqualTo(A, C, 0.001) && isEqualTo(C, B, 0.001))
			{
				result = true;
			}
			return result;
				
		}

        public static bool is_Christmas(double A, double B, double C)
        {
            bool result = false;
			double year = 23;
			double month = 12;
			double date = 24;

            if (isEqualTo(A, year, 0.001) || isEqualTo(B, month, 0.001) || isEqualTo(C, date, 0.001))
            {
                result = true;
            }
			return result;
        }

        public static bool is_Isosceles(double A, double B, double C)
        {
            bool result = false;
            if (isEqualTo(A, B, 0.001) || isEqualTo(A, C, 0.001) || isEqualTo(C, B, 0.001))
            {
                result = true;
            }
			return result;
        }

        public static bool is_Right(double A, double B, double C)
        {
            bool result = false;
			double a = Math.Acos((B * B + C * C - A * A) / (2 * B * C));
			double b = Math.Acos((A*A + C * C - B*B) / (2 * A * C));
			double c = Math.Acos((B * B + A*A- C*C) / (2 * B * A));

            if (isEqualTo(a, Math.PI/2, 0.001) || isEqualTo(b, Math.PI/2, 0.001) || isEqualTo(c, Math.PI/2, 0.001))
            {
                result = true;
            }
			return result;
        }

        public static void Triangle(double A, double B, double C)
      {
			bool is_Reported = false;

			if (is_In_Range(A, B, C) == false)
			{
				Report_As_Error();
				return;
			}

         if (is_Triangle(A, B, C) == false)
			{
				Report_As_Error();
				return;
			}

		 if (is_Equilateral(A,B,C))
			{
				Report_As_Equilateral();
				is_Reported = true;
			} else if (is_Isosceles(A, B, C))
			{
				Report_As_Isosceles();
				is_Reported = true;
			}

		 if(is_Right(A, B, C))
			{
				Report_As_Right();
				is_Reported = true;
			}

		 if (is_Christmas(A, B, C))
			{
				Report_As_Christmas();
				is_Reported = true;
			}

		 if (is_Reported == false)
			{
				Report_As_None();
			}


      }
   
		public static void Main(string[] args)
		{
			if(args.Length == 3)
			{
				double[] InputValues = new double[3];

				for(int i = 0; i < 3; ++i)
				{
					bool ParseCheck = double.TryParse(args[i], NumberStyles.Any, CultureInfo.InvariantCulture, out _);
					
					if(args[i].Contains(',') || !ParseCheck)
					{
						AppClass.Report_As_Error();
						System.Environment.Exit(1);
					}
					else
					{
						InputValues[i] = double.Parse(args[i], System.Globalization.CultureInfo.InvariantCulture);	
					}
				}
				
				AppClass.Triangle(InputValues[0], InputValues[1], InputValues[2]);
				
			}
			else
			{
				AppClass.Report_As_Error();
			}
		}
	}
}