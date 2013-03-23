using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BIID.Entities;
using BIID.Interfaces;
using BIID.Models;

namespace BIID.Implementations
{

    public class ImplAgriculturalService : DbBaseClass, IAgriculturalService
    {
        #region
        public List<Category> GetCategoriesBySectorId(int sectorId)
        {
            var categories = (from cat in  Categories
                              where cat.SectorId == sectorId
                              select cat).ToList();

            return categories;

        }
        #endregion
        public List<Item> GetItemsByCategoryId(int categoryId)
        {
            var items = (from item in  Items
                         where item.CategoryId == categoryId
                         select item).ToList();
            return items;

        }

        public Item GetItemByItemId(int itemId)
        {
            return  Items.Find(itemId);
        }

        public Sector GetSectorByItemId(int itemId)
        {
            var item =  Items.Find(itemId);

            var category = item.Category;

            var sector = category.Sector;

            return sector;
        }


        public List<Variety> GetVarietyByItemId(int itemId)
        {

            var varieties = (from variety in  Varieties
                             where variety.ItemId == itemId
                             select variety).ToList();
            return varieties;

        }





        public List<DiseaseAndPestManagement> GetDiseaseAndPestManagementByItemId(int itemId)
        {
            var diseaseandPestmanagements = (from diseaseandPestmanagement in  DiseaseAndPestManagements
                                             where diseaseandPestmanagement.ItemId == itemId
                                             select diseaseandPestmanagement).ToList();

            return diseaseandPestmanagements;
        }

        public List<EquipmentAndTechnology> GetEquipmentAndTechnologyByItemId(int itemId)
        {

            var equipmentandtechnologies = (from equipmentandtechnology in  EquipmentAndTechnologies
                                            where equipmentandtechnology.ItemId == itemId
                                            select equipmentandtechnology).ToList();
            return equipmentandtechnologies;
        }

        public List<Fertilizer> GetFertilizerByItemId(int itemId)
        {
            var fertilizers = (from fertilizer in  Fertilizers
                               where fertilizer.ItemId == itemId
                               select fertilizer).ToList();
            return fertilizers;
        }

        public List<HarvestingManagement> GetHarvestingManagementByItemId(int itemId)
        {
            var harvestingmanagements = (from harvestingmanagement in  HarvestingManagements
                                         where harvestingmanagement.ItemId == itemId
                                         select harvestingmanagement).ToList();
            return harvestingmanagements;
        }

        public List<LivestockFeedPreservation> GetLivestockFeedPreservationByItemId(int itemId)
        {
            var livestockfeedpreservations = (from livestockpreservation in  LivestockFeedPreservations
                                              where livestockpreservation.ItemId == itemId
                                              select livestockpreservation).ToList();
            return livestockfeedpreservations;
        }

        public List<NutritionalStatu> GetNutritionalstatusByItemId(int itemId)
        {
            var nutritionalstatus = (from nutritionalstatu in  NutritionalStatus
                                     where nutritionalstatu.ItemId == itemId
                                     select nutritionalstatu).ToList();
            return nutritionalstatus;
        }

        public List<Planting> GetPlantingByItemId(int itemId)
        {
            var plantings = (from planting in  Plantings
                             where planting.ItemId == itemId
                             select planting).ToList();
            return plantings;
        }

        public List<PreparationOfFeed> GetPreparationOfFeedByItemId(int itemId)
        {
            var preparationoffeeds = (from preparationoffeed in  PreparationOfFeeds
                                      where preparationoffeed.ItemId == itemId
                                      select preparationoffeed).ToList();
            return preparationoffeeds;
        }

        public List<SeedProduction> GetSeedProductionByItemId(int itemId)
        {
            var seedproductions = (from seedproduction in  SeedProductions
                                   where seedproduction.ItemId == itemId
                                   select seedproduction).ToList();
            return seedproductions;


        }

        public List<Tip> GetTipsByItemId(int itemId)
        {
            var tips = (from tip in  Tips
                        where tip.ItemId == itemId
                        select tip).ToList();
            return tips;
        }

        public List<AgriculturalCulturalOperation> GetAgriculturalCulturalOperationByItemId(int itemId)
        {
            var agriculturaloperations = (from agriculturaloperation in  AgriculturalCulturalOperations
                                          where agriculturaloperation.ItemId == itemId
                                          select agriculturaloperation).ToList();
            return agriculturaloperations;
        }

        public List<BirdAndLivestockCulturalOperation> GetBirdAndLivestockCulturalOperationByItemId(int itemId)
        {
            var birdandlivestockculturaloperations = (from birdandlivestockculturaloperation in  BirdAndLivestockCulturalOperations
                                                      where birdandlivestockculturaloperation.ItemId == itemId
                                                      select birdandlivestockculturaloperation).ToList();
            return birdandlivestockculturaloperations;


        }

        public List<BirdAndLiveStockVaccination> GetBirdAndLiveStockVaccinationByItemId(int itemId)
        {
            var birdandlivestockvaccinations = (from birdandlivestockvaccination in  BirdAndLiveStockVaccinations
                                                where birdandlivestockvaccination.ItemId == itemId
                                                select birdandlivestockvaccination).ToList();
            return birdandlivestockvaccinations;
        }

        public List<FishCulturalOperation> GetFishCulturalOperationByItemId(int itemId)
        {
            var fishculturaloperations = (from fishculturaloperation in  FishCulturalOperations
                                          where fishculturaloperation.ItemId == itemId
                                          select fishculturaloperation).ToList();
            return fishculturaloperations;
        }

        public List<Content> GetContentsBySectorId(int sectorId)
        {
            var model = from m in Contents
                        where m.SectorId == sectorId
                        select m;
            return model.ToList();
        }

        public Sector GetSectorById(int sectorId)
        {
            var sector = (from s in  Sectors
                          where s.Id == sectorId
                          select s).FirstOrDefault();

            return sector;
        }

        public List<Content> GetContentByContentNameId(int contantNameId)
        {
            throw new NotImplementedException();
        }


        public List<Content> GetAllContents()
        {
            var contents = (from m in  Contents
                            select m).ToList();

            return contents;
        }

        public List<Variety> GetAllVariety()
        {
            var listOfVariety = (from m in  Varieties
                                 select m).ToList();
            return listOfVariety;
        }

        public List<Planting> GetAllPlanting()
        {
            var listOfPlanting = (from m in  Plantings
                                  select m).ToList();
            return listOfPlanting;
        }

        public List<AgriculturalCulturalOperation> GetAllAgriculturalCulturalOp()
        {
            var listOfAgriCulOp = (from m in  AgriculturalCulturalOperations
                                   select m).ToList();

            return listOfAgriCulOp;
        }

        public List<HarvestingManagement> GetAllHarvestingManagement()
        {
            var listOfHarvestingMgmt = (from m in  HarvestingManagements
                                        select m).ToList();

            return listOfHarvestingMgmt;
        }

        public List<Sector> GetAllSectors()
        {
            var listOfSectors = (from m in  Sectors
                                 select m).ToList();
            return listOfSectors;
        }

        public List<Category> GetAllCategories()
        {
            var listOfCategories = (from m in  Categories
                                    select m).ToList();
            return listOfCategories;
        }

        public List<Item> GetAllItems()
        {
            var items = (from m in  Items
                         select m).ToList();
            return items;
        }

        public int GetItemIdByName(string itemName)
        {
            var item = (from m in  Items
                        where m.Name == itemName
                        select m).FirstOrDefault();
            return item.Id;
        }


        //public List<Variety> SearchInVarietyWithTerm(string tableName, string term)
        //{
        //    var list = (from m in  Varieties
        //               select m).Contains(term);

        //    var flist  = list.Contains(m => m.)

        //    return null;


        //}

        public Content GetContentById(int contentId)
        {
            var content = (from c in Contents
                           where c.Id == contentId
                           select c).FirstOrDefault();
            return content;

        }

       



        public bool Like(string s, string pattern, RegexOptions options = RegexOptions.IgnoreCase)
        {
            return Regex.IsMatch(s, pattern, options);
        }

        

    }

}