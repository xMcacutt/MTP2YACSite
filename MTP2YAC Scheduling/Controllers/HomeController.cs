using System.Diagnostics;
using System.Globalization;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using MTP2YAC_Scheduling.Models;

namespace MTP2YAC_Scheduling.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult SuccessPage()
    {
        return View();
    }

    public IActionResult Events()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    [HttpPost]
    public IActionResult SubmitForm(SignUpFormData formData)
    {
        // Check ModelState.IsValid if you have validation attributes in your model
        if (ModelState.IsValid)
        {
            if (formData.Event1)
            {
                formData.Event1StartTime =
                    UnixTimeStampToDateTime(long.Parse(formData.Event1StartTime)).ToString("g");
                formData.Event1EndTime =
                    UnixTimeStampToDateTime(long.Parse(formData.Event1EndTime)).ToString("g");
            }

            if (formData.Event2)
            {
                formData.Event2StartTime =
                    UnixTimeStampToDateTime(long.Parse(formData.Event2StartTime)).ToString("g");
                formData.Event2EndTime =
                    UnixTimeStampToDateTime(long.Parse(formData.Event2EndTime)).ToString("g");
            }
            
            if (formData.Event3)
            {
                formData.Event3StartTime =
                    UnixTimeStampToDateTime(long.Parse(formData.Event3StartTime)).ToString("g");
                formData.Event3EndTime =
                    UnixTimeStampToDateTime(long.Parse(formData.Event3EndTime)).ToString("g");
            }
            
            if (formData.Event4)
            {
                formData.Event4StartTime =
                    UnixTimeStampToDateTime(long.Parse(formData.Event4StartTime)).ToString("g");
                formData.Event4EndTime =
                    UnixTimeStampToDateTime(long.Parse(formData.Event4EndTime)).ToString("g");
            }
            
            if (formData.Event5)
            {
                formData.Event5StartTime =
                    UnixTimeStampToDateTime(long.Parse(formData.Event5StartTime)).ToString("g");
                formData.Event5EndTime =
                    UnixTimeStampToDateTime(long.Parse(formData.Event5EndTime)).ToString("g");
            }
            
            // Assuming you want to log to a CSV file
            LogFormDataToCsv(formData);

            // Optionally, you can redirect to a success page or return a success message
            return RedirectToAction("SuccessPage");
        }
        
        foreach (var modelState in ModelState.Values)
        {
            foreach (var error in modelState.Errors)
            {
                _logger.LogError($"Model validation error: {error.ErrorMessage}");
            }
        }


        // If ModelState is not valid, handle the validation errors or return to the form
        return View("Index", formData);
    }

    public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
    {
        // Unix timestamp is seconds past epoch
        DateTime epochDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return epochDateTime.AddMilliseconds(unixTimeStamp);
    }
    
    private void LogFormDataToCsv(SignUpFormData formData)
    {
        // Example CSV logging (you can adjust this based on your requirements)
        const string csvFilePath = @".\logs\Submissions.csv";

        // Ensure directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(csvFilePath));

        // Create CSV file if not exists, and append data
        var appendHeader = !System.IO.File.Exists(csvFilePath);

        using (var writer = new StreamWriter(csvFilePath, true))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            if (appendHeader)
            {
                csv.WriteField("DiscordUsername");
                csv.WriteField("JoinCLM");
                csv.WriteField("CLMStartTime");
                csv.WriteField("CLMEndTime");
                csv.WriteField("JoinTWS");
                csv.WriteField("TWSStartTime");
                csv.WriteField("TWSEndTime");
                csv.WriteField("JoinBNG");
                csv.WriteField("BNGStartTime");
                csv.WriteField("BNGEndTime");
                csv.WriteField("BNGRunningPartner");
                csv.WriteField("JoinCHM");
                csv.WriteField("CHMStartTime");
                csv.WriteField("CHMEndTime");
                csv.WriteField("CHMRunningPartner");
                csv.WriteField("JoinHSD");
                csv.WriteField("HSDStartTime");
                csv.WriteField("HSDEndTime");
                csv.WriteField("HSDRunningPartner");
                csv.NextRecord();
            }
            
            csv.WriteField(formData.DiscordUsername);
            csv.WriteField(formData.Event1);
            csv.WriteField(formData.Event1StartTime);
            csv.WriteField(formData.Event1EndTime);
            csv.WriteField(formData.Event2);
            csv.WriteField(formData.Event2StartTime);
            csv.WriteField(formData.Event2EndTime);
            csv.WriteField(formData.Event3);
            csv.WriteField(formData.Event3StartTime);
            csv.WriteField(formData.Event3EndTime);
            csv.WriteField(formData.Event3RunningPartner);
            csv.WriteField(formData.Event4);
            csv.WriteField(formData.Event4StartTime);
            csv.WriteField(formData.Event4EndTime);
            csv.WriteField(formData.Event4RunningPartner);
            csv.WriteField(formData.Event5);
            csv.WriteField(formData.Event5StartTime);
            csv.WriteField(formData.Event5EndTime);
            csv.WriteField(formData.Event5RunningPartner);
            csv.NextRecord();
        }
    }
}

