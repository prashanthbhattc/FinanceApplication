﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fis.Ui.Areas.Common.Models
{
    public class LoginViewModel
    {
        [Required,DataType(DataType.Password)]
        public string UserName { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }

    public class RegisterViewModel
    {

    }
}
