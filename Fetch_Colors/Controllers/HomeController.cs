using Fetch_Colors.Helpers;
using Fetch_Colors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Fetch_Colors.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiHelper _apiHelper;

        public HomeController(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<ActionResult> Index()
        {
            var model = new List<ColorListModel>();
            string apiUrl = $"https://reqres.in/api/example?per_page=2";
            var initialResponse = await _apiHelper.Fetch<ColorApiModel>(apiUrl);

            int numberOfPages = initialResponse.TotalPages;
            var colors = new List<ColorModel>();

            for (int i = 1; i <= numberOfPages; i++)
            {
                string apiUrlWithPage = $"{apiUrl}&page={i}";
                var response = await _apiHelper.Fetch<ColorApiModel>(apiUrlWithPage);
                colors.AddRange(response.Colors);
            }

            var colorsDevisibleByThree = colors.Where(c => IsFirstPartOfPantoneValueDevisibleBy(3, c.PantoneValue))
                .OrderBy(c => c.Year);
            model.Add(new ColorListModel
            {
                ListHeader = "Devisible by three",
                Colors = colorsDevisibleByThree
            });

            var colorsDevisibleByTwo = colors.Except(colorsDevisibleByThree)
                .Where(c => IsFirstPartOfPantoneValueDevisibleBy(2, c.PantoneValue))
                .OrderBy(c => c.Year);
            model.Add(new ColorListModel
            {
                ListHeader = "Devisible by two",
                Colors = colorsDevisibleByTwo
            });

            model.Add(new ColorListModel
            {
                ListHeader = "Other",
                Colors = colors.Except(colorsDevisibleByThree).Except(colorsDevisibleByTwo).OrderBy(c => c.Year)
            });

            return View(model);
        }

        private bool IsFirstPartOfPantoneValueDevisibleBy(int devideBy, string pantoneValue)
        {
            if (!Regex.Match(pantoneValue, @"^\d{2}-\d{4}$").Success)
            {
                throw new Exception("The pantoneValue is not in the correct format");
            }
            var firstPartOfPantoneValue = int.Parse(pantoneValue.Split('-').First());
            return firstPartOfPantoneValue % devideBy == 0;
        }

    }
}