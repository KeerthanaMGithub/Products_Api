﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Newtonsoft.Json;
using Products_Api.Models;
using System.Data;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Xml;
using System.Collections.Generic;
using System;
//Created by Keerthana M on 20/04/2024
namespace Products_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       
        //To Get Products List
        [HttpGet()]
        [Route("Products")]
        public async Task<IActionResult> Products()
        {
            List<ProductData> products1 = new List<ProductData>();
            products1.Add(new ProductData { id = 1, name = "Apple", description = "Apple_Description", price = 120 });
            return Ok(products1);
        }

        //To Post Products List
        [HttpPost()]
        [Route("Products")]
        public async Task<IActionResult> Product(int pId,string pName,string pDescription,decimal pPrice,string jsonstr)
        {
            List<ProductData> Products = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductData>>(jsonstr);
            List<ProductData> products1 = new List<ProductData>();
            try
            {                
                products1.Add(new ProductData { id = pId+1, name = pName, description = pDescription, price = pPrice });
                Products.AddRange(products1);
                string result = JsonConvert.SerializeObject(Products);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(Products);
            }         
        }

        //To Update Products List
        [HttpPut()]
        [Route("Products")]
        public async Task<IActionResult> Products_Update(int pId, string pName, string pDescription, decimal pPrice, string jsonstr)
        {
            List<ProductData> products1 = new List<ProductData>();
            try
            {
                List<ProductData> Products = JsonConvert.DeserializeObject<List<ProductData>>(jsonstr);
                for (var i = 0; i < Products.Count; i++)
                {
                    if(i==pId)
                    {
                        Products[i].name = pName;
                        Products[i].description = pDescription;
                        Products[i].price = pPrice;
                    }
                }
                string result = JsonConvert.SerializeObject(Products);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return Ok(products1);
            }                           
        }

        //To Delete Products List
        [HttpDelete()]
        [Route("Products")]
        public async Task<IActionResult> Products_Delete(int pId, string jsonstr)
        {            
            List<ProductData> Products = JsonConvert.DeserializeObject<List<ProductData>>(jsonstr);
            Products.RemoveAt(pId);
            for (var i = 0; i < Products.Count; i++)
            {   
                Products[i].id = i+1;                    
            }
            return Ok(Products);
        }


    }
}
