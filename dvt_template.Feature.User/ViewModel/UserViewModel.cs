﻿using System;
using System.Collections.Generic;
using System.Text;

namespace dvt_template.Feature.User.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? DepartmentId { get; set; }
    }
}
