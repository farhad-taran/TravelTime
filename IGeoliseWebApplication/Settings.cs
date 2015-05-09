using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace IGeoliseWebApplication
{
    public static class Settings
    {
        public static readonly string UserFolderName = ConfigurationManager.AppSettings["UnobtrusiveJavaScriptEnabled"];
    }
}