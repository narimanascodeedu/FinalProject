﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace MotorOil.Application.Extensions
{
    public static partial class Extension
    {
        static public string GetImagePhysicalPath(this IHostEnvironment env,string fileName)
        {
            return Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", fileName);
        }

        static public void ArchiveImage(this IHostEnvironment env, string fileName)
        {
            var imageActualPath = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", fileName);

            if (File.Exists(imageActualPath))
            {
                var imageNewPath = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", $"archive-{DateTime.Now.AddHours(4)}-{fileName}");
                File.Move(imageActualPath,imageNewPath);
            }
        }

        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            return request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }

        public static bool IsValidState(this IActionContextAccessor ctx)
        {
            return ctx.ActionContext.ModelState.IsValid;
        }
    }
}
