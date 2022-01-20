﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;
using Wallet.Entities.GobalError;
using Wallet.Logger;

namespace WalletApi.Middlewares
{
    public static class GlobalExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerMessage logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.InnerException.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}
