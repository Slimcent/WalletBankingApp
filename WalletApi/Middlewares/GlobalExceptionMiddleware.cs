using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using Wallet.Entities.Enumerators;
using Wallet.Entities.GobalMessage;
using Wallet.Logger;
using Wallet.Services.Exceptions;

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
                    //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        var status = ResponseStatus.FATAL_ERROR;

                        switch (contextFeature.Error)
                        {
                            case InvalidDataException:
                            case InvalidOperationException:
                            case ArgumentException:
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                status = ResponseStatus.APP_ERROR;
                                break;
                            case NotFoundException:
                                context.Response.StatusCode = StatusCodes.Status404NotFound;
                                status = ResponseStatus.NOT_FOUND;
                                break;
                            default:
                                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                                break;
                        }

                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            Status = status,
                            Message = contextFeature.Error.InnerException.Message
                            //StatusCode = context.Response.StatusCode,
                            //Message = contextFeature.Error.InnerException.Message
                        }.ToString());

                        await context.Response.CompleteAsync();
                    }
                });
            });
        }
    }
}
