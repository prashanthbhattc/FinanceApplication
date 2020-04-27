using Fis.Entities;
using Fis.Repository.Context;
using Fis.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fis.Repository.Implimentations
{
    public class CampaignRepository : ICampaignRepository
    {
        private FisDataContext context;

        public CampaignRepository(FisDataContext context)
        {
            this.context = context;
        }
        public void DeleteCampaign(long campaignId)
        {
            var campaign = GetCampaignByID(campaignId);
            if (campaign != null)
                context.Campaigns.Remove(campaign);
            throw new NotImplementedException();
        }

        public IEnumerable<Campaign> GetCampaign()
        {
            throw new NotImplementedException();
        }

        public Campaign GetCampaignByID(long campaignId)
        {
            throw new NotImplementedException();
        }

        public void InsertStudent(Campaign campaign)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateCampaign(Campaign campaign)
        {
            throw new NotImplementedException();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
