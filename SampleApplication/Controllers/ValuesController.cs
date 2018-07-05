// <copyright file="ValuesController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SampleApplication.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]

    /// <summary> Values Controller </summary>
    /// <returns>returns</returns>
    public class ValuesController : Controller
    {
        // GET api/values/5
        [HttpGet("{id}")]
        /// <summary>Get All values based on ID</summary>
        /// <returns>returns a value</returns>
        public string Get(int id)
        {
            return "value";
        }
    }
}
