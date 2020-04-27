using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fis.Web.ViewModels.CampaignViewModels
{
    public class CreateCampaignViewModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage ="Please Enter Campaign Name")]
        [Display(Name="Campaign Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Campaign Date")]
        [Display(Name = "Campaign Date")]
        public DateTime DateTime { get; set; }
        [Required(ErrorMessage = "Please Enter Campaign Place")]
        [Display(Name = "Campaign Place")]
        public string Place { get; set; }
    }
}
