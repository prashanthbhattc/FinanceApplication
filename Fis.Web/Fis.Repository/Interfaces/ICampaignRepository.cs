using Fis.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fis.Repository.Interfaces
{
   public interface ICampaignRepository
    {
       
            IEnumerable<Campaign> GetCampaign();
            Campaign GetCampaignByID(long campaignId);
            void InsertStudent(Campaign campaign);
            void DeleteCampaign(long campaignId);
            void UpdateCampaign(Campaign campaign);
            void Save();
        
    }
}
