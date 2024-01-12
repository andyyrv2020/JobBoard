using System;
using System.Collections.Generic;
using System.Linq;

public class Controller
{
    private Dictionary<string, Category> categories;

    public Controller()
    {
        categories = new Dictionary<string, Category>();
    }

    public string AddCategory(List<string> args)
    {
        string name = args[0];

        try
        {
            var category = new Category(name);
            categories.Add(name, category);
            return $"Created Category {name}!";
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
    }

    public string AddJobOffer(List<string> args)
    {
        string categoryName = args[0];
        string jobTitle = args[1];
        string company = args[2];
        double salary = double.Parse(args[3]);
        string type = args[4];

        try
        {
            if (type == "onsite")
            {
                string city = args[5];
                var onsiteOffer = new OnSiteJobOffer(jobTitle, company, salary, city);
                categories[categoryName].AddJobOffer(onsiteOffer);
            }
            else if (type == "remote")
            {
                bool fullyRemote = bool.Parse(args[5]);
                var remoteOffer = new RemoteJobOffer(jobTitle, company, salary, fullyRemote);
                categories[categoryName].AddJobOffer(remoteOffer);
            }

            return $"Created JobOffer {jobTitle} in Category {categoryName}!";
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
    }

    public string GetAverageSalary(List<string> args)
    {
        string categoryName = args[0];

        double averageSalary = categories[categoryName].AverageSalary();

        return $"The average salary is: {averageSalary:F2} BGN";
    }

    public string GetOffersAboveSalary(List<string> args)
    {
        string categoryName = args[0];
        double salary = double.Parse(args[1]);

        var offers = categories[categoryName].GetOffersAboveSalary(salary);

        return string.Join("\n", offers.Select(offer => offer.ToString()));
    }

    public string GetOffersWithoutSalary(List<string> args)
    {
        string categoryName = args[0];

        var offers = categories[categoryName].GetOffersWithoutSalary();

        return string.Join("\n", offers.Select(offer => offer.ToString()));
    }
}
