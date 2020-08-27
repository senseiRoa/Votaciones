using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Demokratianweb.Service
{
    public class LoadHtmlTemplate
    {
        public static string loadtemplate(string rootPath, HtmlTemplate template)
        {
            var name = "";
            switch (template)
            {
                case HtmlTemplate.ForgotPassword:
                    name = "htmlTemplateForgotPassword.html";
                    break;
                case HtmlTemplate.ConfirmEmail:
                    name = "htmlTemplateConfirmEmail.html";
                    break;
                default:
                    break;
            }
            var path = Path.Combine(rootPath, "htmTemplate", name);
            string file = File.ReadAllText(path);
            return file;

        }
    }

    public enum HtmlTemplate
    {
        ForgotPassword,
        ConfirmEmail
    }
}
