﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class SchemaOrgEntity : BaseEntity
    {     
        public int? UpvoteCountLd { get; set; }

        public int? DownvoteCountLd { get; set; }
    }
}