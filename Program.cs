using System;

public class Program
{
    public static void Main()
    {
        Controller controller = new Controller();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var commandArgs = input.Split(' ');
            string command = commandArgs[0];
            List<string> args = commandArgs.Skip(1).ToList();

            string result = "";

            switch (command)
            {
                case "AddCategory":
                    result = controller.AddCategory(args);
                    break;
                case "AddJobOffer":
                    result = controller.AddJobOffer(args);
                    break;
                case "GetAverageSalary":
                    result = controller.GetAverageSalary(args);
                    break;
                case "GetOffersAboveSalary":
                    result = controller.GetOffersAboveSalary(args);
                    break;
                case "GetOffersWithoutSalary":
                    result = controller.GetOffersWithoutSalary(args);
                    break;
            }

            Console.WriteLine(result);
        }
    }
}
