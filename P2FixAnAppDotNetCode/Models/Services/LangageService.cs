using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// Fourni des méthodes de services pour gérer la langue de l'application
    /// </summary>
    public class LangageService : ILangageService
    {
        /// <summary>
        /// Positionne la langue de l'interface utilisateur
        /// </summary>
        public void ChangeLangageInterfaceUtilisateur(HttpContext context, string langage)
        {
            string culture = SetCulture(langage);
            MettreAJourLeCookieDeCulture(context, culture);
        }

        /// <summary>
        /// Positionne la culture
        /// </summary>
        public string SetCulture(string langage)
        {
            string culture = "";
            // TODO completer le code
            // Le langage par défaut est "en", le Français est "fr" et l'espagnol est "es".
            // PCh - Ajout sélection langage avec un switch cases
            switch (langage)
            {
                case "Anglais" or "English" or "Inglés":
                    culture = "en-GB";
                    break;
                case "Français" or "French" or "Francés":
                    culture = "fr-FR";
                    break;
                case "Espagnol" or "Spanish" or "Español":
                    culture = "es-ES";
                    break;

            }

            return culture;
        }

        /// <summary>
        /// Met à jour le cookie de culture
        /// </summary>
        public void MettreAJourLeCookieDeCulture(HttpContext context, string culture)
        {
            context.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)));
        }
    }
}
