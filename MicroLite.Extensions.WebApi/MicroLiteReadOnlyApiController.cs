﻿// -----------------------------------------------------------------------
// <copyright file="MicroLiteReadOnlyController.cs" company="MicroLite">
// Copyright 2012 Trevor Pilley
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// </copyright>
// -----------------------------------------------------------------------
namespace MicroLite.Extensions.WebApi
{
    using System.Web.Http;
    using MicroLite.Infrastructure;

    /// <summary>
    /// Provides access to a MicroLite IReadOnlySession in addition to the base ASP.NET WebApi controller.
    /// </summary>
    public abstract class MicroLiteReadOnlyApiController : ApiController, IHaveReadOnlySession
    {
        /// <summary>
        /// Gets or sets the <see cref="IReadOnlySession"/> for the current HTTP request.
        /// </summary>
        public IReadOnlySession Session
        {
            get;
            set;
        }
    }
}