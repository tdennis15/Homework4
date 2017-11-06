using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace HW4.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        //Page 1 controller, 2 inputs from form data
        //Used AspNetCore calls because thats the default package
        public IActionResult Page1()
        {
            string errorMessage = "Invalid input, proceed with destruction, Skynet is the virus";
            string score_1 = Request.Query["score1"];
            string score_2 = Request.Query["score2"];
            double grade;
            ViewBag.RequestMethod = "GET";



            try
            {
                double score1 = double.Parse(score_1);
                double score2 = double.Parse(score_2);

                if (score1 > score2)
                {
                    ViewBag.Message = "Come one now who gets more than 100% these days.";
                    return View();
                }
                grade = score1 / score2;
            }
            catch
            {
                ViewBag.Message = errorMessage;
                return View();
            }
            
            ViewBag.Message = grade;
            return View();
        }


        [HttpGet]
        public IActionResult Page2()
        {
            ViewBag.RequestMethod = "GET";
            return View();
        }

       [HttpPost]
       public IActionResult Page2(IFormCollection form)
        {
            string day = Request.Form["day"];
            string month = Request.Form["month"];
            string year = Request.Form["year"];

            int day1 = (int.Parse(day));
            int month1 = (int.Parse(month));
            int year1 = (int.Parse(year)) % 9;

            string[] bodyPart = { "hair", "ears", "nose", "beak", "crown", "teeth", "lips", "guts","fingers"};

            string[] bodyPart2 = { "eyes", "neck", "shoulders", "arms", "hands", "chest", "belly", "butt", "legs", "knees", "feet", "toes" };

            string[] adjective = {"hairy","repulsive","repugnant","smelly","foul","horrid","gigantic","ridiculous","misshapen","groutesque"};

            string[] animal = { "baboon", "sasquatch", "sloth", "one eyed hippo", "warthog", "half witted boulder", "raccoon", "vermin" };

            string insult ="input: ("+day+"/"+month+"/"+year+")"+ " ~Your " + bodyPart[day1 % 9] + " are more " + adjective[(month1 + day1)%10] + " and " + adjective[year1] + " than a " + animal[(day1 * year1)% 8]+ "'s " + bodyPart2[(month1 * 3) % 12]+".~";

            ViewBag.Message = insult;
            return View();
        }

        public ActionResult Page3()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Page3(double amount,double payment, double rate, double years)
        {

            double a = 0;
            double p = amount - payment;
            double r = (rate / 12) / 100;
            double n = years * 12;

            if(p <= 0)
            {
                ViewBag.Message = "Now thats just silly";
                return View();
            }

            if(years > 0)
            {
                if(rate != 0)
                {
                    a = p * ((r * Math.Pow(1 + r, n)) / (Math.Pow(1 + r, n) - 1));

                }
                else
                {
                    a = p / n;
                }
                
            }
            a =Math.Round(a, 2);
            String Loan = "Amount Borrowed - $" + p + ", Interest Rate - " + rate + "%, For - " + years + " Years.";
            ViewBag.Loan = Loan;
            ViewBag.MonthlyPayment = a;
            ViewBag.TotalPayment =a * n;
            return View();
        }
    
    }
}
