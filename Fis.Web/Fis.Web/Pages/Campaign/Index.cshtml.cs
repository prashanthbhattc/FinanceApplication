using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fis.Manager.Interfaces;
using Fis.Web.ViewModels.CampaignViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fis.Web.Pages.Campaign
{
    public class IndexModel : PageModel
    {

        private readonly ICampaignFacade _campaignFacade;

        public IReadOnlyList<Entities.Campaign> Campaigns;

        [BindProperty]
        public CreateCampaignViewModel CreateCampaign { set; get; }
        public IndexModel(ICampaignFacade campaignFacade)
        {
            _campaignFacade = campaignFacade;
        }
        public async Task OnGetAsync(int? id)
        {
            if(id.HasValue)
            {
                var camp = await _campaignFacade.GetByIdAsync(id.Value);
                CreateCampaign = new CreateCampaignViewModel {
                    Id=camp.Id,
                    DateTime=camp.DateTime,
                    Name=camp.Name,
                    Place=camp.Place
                };

            }
            Campaigns= await _campaignFacade.ListAllAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                var campaign = new Entities.Campaign {
                    Name= CreateCampaign.Name,
                    Place=CreateCampaign.Place,
                    DateTime=CreateCampaign.DateTime
                };
                if(CreateCampaign.Id.HasValue)
                {
                    campaign.Id = CreateCampaign.Id.Value;
                    await _campaignFacade.UpdateAsync(campaign);
                }
                else
                await _campaignFacade.AddAsync(campaign);
                return RedirectToPage("Index");

            }
            return RedirectToPage("Index");
        }
    }
}