﻿// -----------------------------------------------------------------------
// <copyright file="OrderByDirection.cs" company="MicroLite">
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
namespace MicroLite.Extensions.WebApi.Query
{
    /// <summary>
    /// The valid order by directions.
    /// </summary>
    public enum OrderByDirection
    {
        /// <summary>
        /// The results are to be filtered by the named property in ascending order.
        /// </summary>
        Ascending = 0,

        /// <summary>
        /// The results are to be filtered by the named property in descending order.
        /// </summary>
        Descending = 1
    }
}