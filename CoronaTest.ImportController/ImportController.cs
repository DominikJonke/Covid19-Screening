using CoronaTest.Core.Entities;
using CoronaTest.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoronaTest.ImportController
{
    public class ImportController
    {
        public static IEnumerable<Campaign> ReadFromCsv()
        {
            var csvCampaign = "Campaign.csv";
            var csvTestCenter = "TEstCenter.csv";

            string[][] matrixTestCenter = MyFile.ReadStringMatrixFromCsv(csvTestCenter, true);
            string[][] matrixCampaigns = MyFile.ReadStringMatrixFromCsv(csvCampaign, true);

            var testCenters = matrixTestCenter
                .Select(grp => new TestCenter
                {
                    Name = grp[0],
                    City = grp[1],
                    Plz = grp[2],
                    Street = grp[3],
                    SlotCapacity = Int32.Parse(grp[4])
                })
                .ToDictionary(t => t.Name);

            var campaigns = matrixCampaigns
                .Select(grp => new Campaign
                {
                    Examination = Int32.Parse(grp[0]),
                    From = DateTime.Parse(grp[1]),
                    To = DateTime.Parse(grp[2]),
                    Name = grp[3],
                    AvailableTestCenter = grp[4].Split(',').Select(t => testCenters[t]).ToList()
                })
                .ToArray();

            return campaigns;
        }
    }
}
