﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StreamingWebshop.Core.Entity
{
    public class Products
    {

        //Possibly need other kinds of product entities mb (pc hardware, cams, screens...)
        public int Id { get; set; }

        public string Name {get; set; }

        public string Description { get; set; }

        public double Price { get; set; }





    }
}
