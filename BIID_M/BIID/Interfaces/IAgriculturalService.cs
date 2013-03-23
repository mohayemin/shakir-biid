using System.Collections.Generic;
using BIID.Entities;

namespace BIID.Interfaces
{
    interface IAgriculturalService
    {
        
        List<Category> GetCategoriesBySectorId(int sectorId);

        List<Item> GetItemsByCategoryId(int categoryId);

        Item GetItemByItemId(int itemId);

        Sector GetSectorByItemId(int itemId);

        List<Variety> GetVarietyByItemId(int itemId);
        List<DiseaseAndPestManagement> GetDiseaseAndPestManagementByItemId(int itemId);
        List<EquipmentAndTechnology> GetEquipmentAndTechnologyByItemId(int itemId);
        List<Fertilizer> GetFertilizerByItemId(int itemId);
        List<HarvestingManagement> GetHarvestingManagementByItemId(int itemId);
        List<LivestockFeedPreservation> GetLivestockFeedPreservationByItemId(int itemId);
        List<NutritionalStatu> GetNutritionalstatusByItemId(int itemId);
        List<Planting> GetPlantingByItemId(int itemId);
        List<PreparationOfFeed> GetPreparationOfFeedByItemId(int itemId);
        List<SeedProduction> GetSeedProductionByItemId(int itemId);
        List<Tip> GetTipsByItemId(int itemId);
        List<AgriculturalCulturalOperation> GetAgriculturalCulturalOperationByItemId(int itemId);
        List<BirdAndLivestockCulturalOperation> GetBirdAndLivestockCulturalOperationByItemId(int itemId);
        List<BirdAndLiveStockVaccination> GetBirdAndLiveStockVaccinationByItemId(int itemId);
        List<FishCulturalOperation> GetFishCulturalOperationByItemId(int itemId);

        List<Content> GetContentsBySectorId(int sectorId);




        Sector GetSectorById(int sectorId);

      //  List<Variety> SearchInTableWithTerm(string tableName, string term);

        //List<ContentName> GetContentByItemId(int itemid);
        List<Content> GetContentByContentNameId(int contantNameId);
        List<Content> GetAllContents();

        List<Variety> GetAllVariety();
        List<Planting> GetAllPlanting();
        List<AgriculturalCulturalOperation> GetAllAgriculturalCulturalOp();
        List<HarvestingManagement> GetAllHarvestingManagement();
        List<Sector> GetAllSectors();
        List<Category> GetAllCategories();

        List<Item> GetAllItems();

        int GetItemIdByName(string itemName);
    }
}
