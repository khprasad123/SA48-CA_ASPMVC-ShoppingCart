﻿using System.Web;
using System.Web.Mvc;

namespace ADO.net_Lecture_Example
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
