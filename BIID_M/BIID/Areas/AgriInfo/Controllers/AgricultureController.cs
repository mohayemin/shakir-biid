using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BIID.Controllers;
using BIID.Entities;

namespace BIID.Areas.AgriInfo.Controllers
{
    [Authorize]
    public class AgricultureController : BiidFinalBaseController
    {
        //
        // GET: /AgriInfo/Agriculture/

        public ActionResult Index()
        {

            var districts = this.ImplCustomerProfile.GetAllDistrcts();

            ViewData["districtsInCustomerSave"] = districts;

            var sectors = from c in this.AgriculturalService.Sectors
                          select c;

            SelectList sl = new SelectList(sectors);

            ViewBag.names = sl;
            ViewData["sectors"] = sectors;

            return View();
        }

        public ActionResult QuickSearch(int sectorId, int categoryId, int itemId, int contentId, string searchTerm)
        {
            List<Variety> model = SearchInVariety(itemId, searchTerm);
            var firstOrDefault = model.FirstOrDefault();
            if (firstOrDefault != null)
            {
                Type t = firstOrDefault.GetType();
            }

            if (itemId == 1)
                return Json(
        model.Select(x => new { id = x.Id, varietyName = x.VarietyName, kharip1 = x.Kharip1, kharip2 = x.Kharip2, robi = x.RobiIndustrious, allTheYear = x.AlltheYear, supplierId = x.DetailsSupplierId }),
        JsonRequestBehavior.AllowGet
    );
            else if ((itemId == 2))
            {
                return Json(
        model.Select(x => new { id = x.Id, varietyName = x.VarietyName, kharip1 = x.Kharip1, kharip2 = x.Kharip2, robi = x.RobiIndustrious, allTheYear = x.AlltheYear, supplierId = x.DetailsSupplierId }),
        JsonRequestBehavior.AllowGet);
            }
            else return null;
        }

        //write 10 functions like this for 10 tables of the lowest level(2 ta kore dichi)

        public JsonResult VarietyJsonReturner(int itemId)
        {
            var model = this.AgriculturalService.GetVarietyByItemId(itemId);


            var s =
                model.Select(
                    x =>
                    new
                        {
                            id = x.Id,
                            varietyName = x.VarietyName,
                            kharip1 = x.Kharip1,
                            kharip2 = x.Kharip2,
                            robiIndustries = x.RobiIndustrious,
                            allTheYear = x.AlltheYear,
                            detailsSupplierId = this.DirectoryService.GetDetailsSupplierInfoBySupplierId(x.DetailsSupplierId).Name,
                            remarks = x.Remarks,
                            itemId = x.ItemId
                        });

            return Json(new{varietyJson=s},JsonRequestBehavior.AllowGet);

        }

        public JsonResult AddressJson(string supplierName)
        {

            int supplierId = this.DirectoryService.GetSupplierIdByName(supplierName);

            var supplierAddresses = this.DirectoryService.GetSupplierAddressBySupplierId(supplierId);

            var s =
                    supplierAddresses.Select(
                        x =>
                        new
                        {
                          id = x.DetailsSupplierId,
                          upazilla = this.DirectoryService.GetDistrict(x.DistrictId).Name,
                          district = this.DirectoryService.GetUpozilla(x.UpozillaId).Name,
                          address = x.Address,
                          webaddress = x.WebAddress

                        });

            return Json(new { supplierAddressesJson = s }, JsonRequestBehavior.AllowGet);

            return null;
        }
        public JsonResult PlantingJsonReturner(int itemId)
        {
            var model = this.AgriculturalService.GetPlantingByItemId(itemId);
            var plantingJs =
                model.Select(
                    x =>
                    new
                        {
                            id = x.Id,
                            soilType = x.SoliType,
                            plantingtime = x.PlantingTime,
                            plantingSystem = x.PlantingSystems,
                            plantingSpace = x.PlantingSpace,
                            seeding = x.Seeding,
                            remarks = x.Remarks
                        });
            return Json( new{ plantingJson = plantingJs},JsonRequestBehavior.AllowGet);

        }

        public JsonResult FertilizerJsonReturner(int itemId)
        {
            var model = this.AgriculturalService.GetFertilizerByItemId(itemId);

            return
                Json(
                    model.Select(
                        x =>
                        new
                            {
                                id = x.Id,
                                particulars = x.Particulars,
                                totalAmount = x.TotalAmount,
                                fertilizer1 = x.Fertilizer1,
                                fertilizer2 = x.Fertilizer2,
                                fertilizer3 = x.Fertilizer3,
                                fertilizer4 = x.Fertilizer4,
                                fertilizer5 = x.Fertilizer5,
                                precaution = x.Precaution,
                                remarks = x.Remarks,
                                itemId = x.ItemId
                            }), JsonRequestBehavior.AllowGet);


        }
        public JsonResult DiseasesAndPasteJsonReturner(int itemId)
        {
            var model = this.AgriculturalService.GetDiseaseAndPestManagementByItemId(itemId);

            return
                Json(
                    model.Select(
                        x =>
                        new
                            {
                                id = x.Id,
                                name = x.Name,
                                symtoms = x.Symptoms,
                                preventive = x.Preventive,
                                controlmeasures = x.ControlMeasures,
                                detailssupplierId = x.DetailsSupplierId,
                                remarks = x.Remarks,
                                itemId = x.ItemId
                            }), JsonRequestBehavior.AllowGet);

        }


        public JsonResult HarvestingManagementJsonReturner(int itemId)
        {
            var model = this.AgriculturalService.GetHarvestingManagementByItemId(itemId);
            return
                Json(
                    model.Select(
                        x =>
                        new
                            {
                                id = x.Id,
                                harvestingtime = x.HarvestingTime,
                                systems = x.Systems,
                                procedures = x.Procedures,
                                threshing = x.Threshing,
                                packaging = x.Packaging,
                                storage = x.Storage,
                                remarks = x.Remarks,
                                itemId = x.ItemId
                            }), JsonRequestBehavior.AllowGet);


        }


        public JsonResult LivestockFeedPreservationJsonReturner(int itemId)
        {
            var model = this.AgriculturalService.GetLivestockFeedPreservationByItemId(itemId);
            return
                Json(
                    model.Select(
                        x =>
                        new
                            {
                                id = x.Id,
                                ingradient = x.Ingradient,
                                amount = x.Amount,
                                process = x.Process,
                                duration = x.Duration,
                                feeduse = x.FeedUse,
                                precaution = x.Precaution,
                                remarks = x.Remarks,
                                itemId = x.ItemId
                            }), JsonRequestBehavior.AllowGet);
        }


        public JsonResult NutritionalStatusJsonReturner(int itemId)
        {
            var model = this.AgriculturalService.GetNutritionalstatusByItemId(itemId);
            return
                Json(
                    model.Select(
                        x =>
                        new
                            {
                                id = x.Id,
                                amountofnutrient = x.AmountOfNutrient,
                                foodvalue = x.FoodValue,
                                remarks = x.Remarks,
                                itemId = x.ItemId
                            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult PreparationOfFeedJsonReturner(int itemId)
        {
            var model = this.AgriculturalService.GetPreparationOfFeedByItemId(itemId);
            return
                Json(
                    model.Select(
                        x =>
                        new
                            {
                                id = x.Id,
                                feedname = x.FeedName,
                                ingredient = x.Ingredient,
                                amount = x.Amount,
                                process = x.Process,
                                precaution = x.Precaution,
                                feedclass = x.FeedClass,
                                typesoffeed = x.TypesOfFeed,
                                remarks = x.Remarks,
                                itemId = x.ItemId
                            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult SeedProductionJsonReturner(int itemId)
        {
            var model = this.AgriculturalService.GetSeedProductionByItemId(itemId);
            return
                Json(
                    model.Select(
                        x =>
                        new
                            {
                                id = x.Id,
                                procedureodseed = x.ProcedureOfSeed,
                                condition = x.Condition,
                                seedstorage = x.SeedStorage,
                                remarks = x.Remarks,
                                itemId = x.ItemId
                            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult EquipmentAndTechnologyJsonReturner(int itemId)
        {
            var model = this.AgriculturalService.GetEquipmentAndTechnologyByItemId(itemId);
            return
                Json(
                    model.Select(
                        x =>
                        new
                            {
                                id = x.Id,
                                nameofequipment = x.NameOfEquipment,
                                brief = x.Brief,
                                howtouse = x.HowToUse,
                                precaution = x.Precaution,
                                availability = x.Availability,
                                remarks = x.Remarks,
                                itemId = x.ItemId
                            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult TipsJsonReturner(int itemId)
        {
            var model = this.AgriculturalService.GetTipsByItemId(itemId);
            return
                Json(
                    model.Select(
                        x =>
                        new {id = x.Id, tipstopic = x.TipsTopic, tips = x.Tips, remarks = x.Remarks, itemId = x.ItemId}),
                    JsonRequestBehavior.AllowGet);
        }


        public JsonResult BirdAndLivestockVaccinationJsonReturner(int itemId)
        {
            var model = this.AgriculturalService.GetBirdAndLiveStockVaccinationByItemId(itemId);
            return
                Json(
                    model.Select(
                        x =>
                        new
                            {
                                id = x.Id,
                                age = x.Age,
                                nameofdisease = x.NameOfDisease,
                                nameofvaccine = x.NameOfVaccine,
                                applicationprocedure = x.ApplicationProcedure,
                                precaution = x.Precaution,
                                remarks = x.Remarks,
                                itemId = x.ItemId
                            }), JsonRequestBehavior.AllowGet);

        }

        public JsonResult AgriculturalCulturalOperationJsonReturner(int itemId)
        {
            var model = this.AgriculturalService.GetAgriculturalCulturalOperationByItemId(itemId);
            var agriculturalCulturalOpJs =
                model.Select(
                    x =>
                    new
                        {
                            id = x.Id,
                            nameofoperation = x.NameOfOperation,
                            earlystage = x.EarlyStage,
                            midstage = x.MidStage,
                            beforefinalstage = x.BeforeFinalStage,
                            finalstage = x.FinalStage,
                            remarks = x.Remarks,
                            itemId = x.ItemId
                        });
            return Json(new {agriculturalCulturalOpJson = agriculturalCulturalOpJs}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BirdAndLivestokeCulturalOperationJsonReturner(int itemId)
        {
            var model = this.AgriculturalService.GetBirdAndLivestockCulturalOperationByItemId(itemId);
            return
                Json(
                    model.Select(
                        x =>
                        new
                            {
                                id = x.Id,
                                stagename = x.StageName,
                                housemanagement = x.HouseManagement,
                                lightmanagement = x.LightManagement,
                                heatmanagement = x.HeatManagement,
                                foodmanagement = x.FoodManagement,
                                farmmanagement = x.FarmManagement,
                                precaution = x.Precaution,
                                remarks = x.Remarks,
                                itemId = x.ItemId
                            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult FishCulturalOperationJsonReturner(int itemId)
        {
            var model = this.AgriculturalService.GetFishCulturalOperationByItemId(itemId);
            return
                Json(
                    model.Select(
                        x =>
                        new
                            {
                                id = x.Id,
                                managementname = x.ManagementName,
                                pondmanagement = x.PondManagement,
                                watermanagement = x.WaterManagement,
                                foodmanagement = x.FoodManagement,
                                density = x.Density,
                                process = x.Process,
                                agelimit = x.AgeLimit,
                                precaution = x.Precaution,
                                remarks = x.Remarks,
                                itemId = x.ItemId
                            }), JsonRequestBehavior.AllowGet);
        }



        public List<Variety> SearchInVariety(int itemId, string term)
        {
            var model = this.AgriculturalService.GetVarietyByItemId(itemId);
            return model;
        }


        // egula muctadir er basay korci

        //public string GetJson(DataTable dt)
        //{
        //    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        //    var rows = new List<Dictionary<string, object>>();
        //    Dictionary<string, object> row = null;

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        row = new Dictionary<string, object>();
        //        foreach (DataColumn col in dt.Columns)
        //        {
        //            row.Add(col.ColumnName, dr[col]);
        //        }
        //        rows.Add(row);
        //    }
        //    return serializer.Serialize(rows);
        //}

        public ActionResult Categories(int sectorId)
        {
            var categories = this.AgriculturalService.GetCategoriesBySectorId(sectorId);

            return Json(
         categories.Select(x => new { value = x.Id, text = x.Name }),
         JsonRequestBehavior.AllowGet
     );

        }

        public ActionResult Items(int categoryId)
        {

            var items = this.AgriculturalService.GetItemsByCategoryId(categoryId);

            return Json(
                items.Select(x => new { value = x.Id, text = x.Name }),
                JsonRequestBehavior.AllowGet
                );
        }


        public ActionResult ContentName(int itemId)
        {
            var item = this.AgriculturalService.GetItemByItemId(itemId);
            var sector = this.AgriculturalService.GetSectorByItemId(item.Id);
            var contents = this.AgriculturalService.GetContentsBySectorId(sector.Id);



            return Json(
               contents.Select(x => new { value = x.ContentName, text = x.ContentName }),
               JsonRequestBehavior.AllowGet
               );
        }

        public ActionResult SelectAllJsonReturner(int itemId)
        {
            

            var varietyList = this.AgriculturalService.GetVarietyByItemId(itemId);
            var plantingList = this.AgriculturalService.GetPlantingByItemId(itemId);
            var agriculturalCulturalOp = this.AgriculturalService.GetAgriculturalCulturalOperationByItemId(itemId);
            var harvestingmanagementOp = this.AgriculturalService.GetHarvestingManagementByItemId(itemId);
         var diseaseandpestOp = this.AgriculturalService.GetDiseaseAndPestManagementByItemId(itemId);
            var fertilizerOp = this.AgriculturalService.GetFertilizerByItemId(itemId);
            var seedproductionOp = this.AgriculturalService.GetSeedProductionByItemId(itemId);
            var nutritionalstatusOp = this.AgriculturalService.GetNutritionalstatusByItemId(itemId);
            var equipmentAndtechnologyOp = this.AgriculturalService.GetEquipmentAndTechnologyByItemId(itemId);
            var tipsOp = this.AgriculturalService.GetTipsByItemId(itemId);

            var varietyJs =
                varietyList.Select(
                    x =>
                    new
                        {
                            id = x.Id,
                            varietyName = x.VarietyName,
                            kharip1 = x.Kharip1,
                            kharip2 = x.Kharip2,
                            robiIndustries = x.RobiIndustrious,
                            allTheYear = x.AlltheYear,
                            detailsSupplierId = this.DirectoryService.GetDetailsSupplierInfoBySupplierId(x.DetailsSupplierId).Name,
                            remarks = x.Remarks,
                            itemId = x.ItemId
                        });


            var plantingJs =
                plantingList.Select(
                    x =>
                    new
                        {
                            id = x.Id,
                            soilType = x.SoliType,
                            plantingtime = x.PlantingTime,
                            plantingSystem = x.PlantingSystems,
                            plantingSpace = x.PlantingSpace,
                            seeding = x.Seeding,
                            remarks = x.Remarks
                        });
            var agriculturalCulturalOpJs = agriculturalCulturalOp.Select(x =>
                                                                         new
                                                                             {
                                                                                 id = x.Id,
                                                                                 nameofoperation = x.NameOfOperation,
                                                                                 earlystage = x.EarlyStage,
                                                                                 midstage = x.MidStage,
                                                                                 beforefinalstage = x.BeforeFinalStage,
                                                                                 finalstage = x.FinalStage,
                                                                                 remarks = x.Remarks,
                                                                                 itemId = x.ItemId
                                                                             });

            var harvestingmanagementJs = harvestingmanagementOp.Select(x =>

                                                                       new
                                                                           {
                                                                               id = x.Id,
                                                                               harvestingtime = x.HarvestingTime,
                                                                               systems = x.Systems,
                                                                               procedures = x.Procedures,
                                                                               threshing = x.Threshing,
                                                                               packaging = x.Packaging,
                                                                               storage = x.Storage,
                                                                               remarks = x.Remarks,
                                                                               itemId = x.ItemId
                                                                           });

            var diseaseandpestJs = diseaseandpestOp.Select(x =>
                                                           new
                                                               {
                                                                   id = x.Id,
                                                                   name = x.Name,
                                                                   symtoms = x.Symptoms,
                                                                   preventive = x.Preventive,
                                                                   controlmeasures = x.ControlMeasures,
                                                                   detailssupplierId = x.DetailsSupplierId,
                                                                   remarks = x.Remarks,
                                                                   itemId = x.ItemId
                                                               });

            var fertilizerJs = fertilizerOp.Select(x =>
                                                   new
                                                       {
                                                           id = x.Id,
                                                           particulars = x.Particulars,
                                                           totalAmount = x.TotalAmount,
                                                           fertilizer1 = x.Fertilizer1,
                                                           fertilizer2 = x.Fertilizer2,
                                                           fertilizer3 = x.Fertilizer3,
                                                           fertilizer4 = x.Fertilizer4,
                                                           fertilizer5 = x.Fertilizer5,
                                                           precaution = x.Precaution,
                                                           remarks = x.Remarks,
                                                           itemId = x.ItemId
                                                       });


            var seedproductionOpJs = seedproductionOp.Select(x => new
                                                                      {
                                                                          id = x.Id,
                                                                          procedureodseed = x.ProcedureOfSeed,
                                                                          condition = x.Condition,
                                                                          seedstorage = x.SeedStorage,
                                                                          remarks = x.Remarks,
                                                                          itemId = x.ItemId
                                                                      });


            var nutrutionalstatusOpJs = nutritionalstatusOp.Select(x => new
                                                                            {
                                                                                id = x.Id,
                                                                                amountofnutrient = x.AmountOfNutrient,
                                                                                foodvalue = x.FoodValue,
                                                                                remarks = x.Remarks,
                                                                                itemId = x.ItemId
                                                                            });


            var equipmentAndtechnologyOpJs = equipmentAndtechnologyOp.Select(x => new
                                                                                      {
                                                                                          id = x.Id,
                                                                                          nameofequipment = x.NameOfEquipment,
                                                                                          brief = x.Brief,
                                                                                          howtouse = x.HowToUse,
                                                                                          precaution = x.Precaution,
                                                                                          availability = x.Availability,
                                                                                          remarks = x.Remarks,
                                                                                      });

            var tipsOpJs = tipsOp.Select(x => new
                                                  {
                                                      id = x.Id,
                                                      tipstopic = x.TipsTopic,
                                                      tips = x.Tips,
                                                      remarks = x.Remarks,
                                                      itemId = x.ItemId
                                                  });

            return Json(new { varietyJson = varietyJs, plantingJson = plantingJs, agriculturalCulturalOpJson = agriculturalCulturalOpJs, harvestingmanagementOpJson = harvestingmanagementJs, diseaseandpestOpJson=diseaseandpestJs,
                              fertilizerOpJson = fertilizerJs,
                              seedproductionOpJson = seedproductionOpJs,
                              nutritionalstatusOpJson = nutrutionalstatusOpJs,
                              equipmentAndtechnologyOpJson = equipmentAndtechnologyOpJs,
                              tipsOpJson=tipsOpJs
            }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult ContentSearch(int itemId, string tableName)
        {
            string searchTerm = "";
            
            switch (tableName)
            {
                case "planting":
                    
                    return PlantingJsonReturner(itemId);
                case "variety":
                    return VarietyJsonReturner(itemId);
                case "fertilizer":
                    return FertilizerJsonReturner(itemId);
                case"diseaseandpestmanagement":
                    return DiseasesAndPasteJsonReturner(itemId);
                case"nutritionalstatus":
                    return NutritionalStatusJsonReturner(itemId);
                case"agriculturalculturaloperation":
                    return AgriculturalCulturalOperationJsonReturner(itemId);
                case"birdandlivestockculturaloperation":
                    return BirdAndLivestokeCulturalOperationJsonReturner(itemId);
                case "fishculturaloperation":
                    return FishCulturalOperationJsonReturner(itemId);
                case "livestockfeedpreservation":
                    return LivestockFeedPreservationJsonReturner(itemId);
                case "tips":
                    return TipsJsonReturner(itemId);
                case "equipmentandtechnology":
                    return EquipmentAndTechnologyJsonReturner(itemId);
                case"preparetionoffeed":
                    return PreparationOfFeedJsonReturner(itemId);
                case "seedproduction":
                    return SeedProductionJsonReturner(itemId);
                case "harvestingmanagement":
                    return HarvestingManagementJsonReturner(itemId);

                case "selectAll":
                    return SelectAllJsonReturner(itemId);


            }

            return null;
        }



        //egula korte hobe
        //public JsonResult ContentSearch(int itemId)
        //{
        //    var Contents = (from c in base.AgriculturalService.Contents
        //                    where c.It == itemId
        //                    select c).ToList();
        //    return Json(Contents, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult ContentSearchTest()
        //{
        //    var contents = new List<Content>()
        //                       {
        //                           new Content() {}
        //                       };

        //    // return Json(content, JsonRequestBehavior.AllowGet);

        //}

        public ActionResult QuickSearchInBox(string searchTerm)
        {
            int itemId = this.AgriculturalService.GetItemIdByName(searchTerm);

            var varietyList = this.AgriculturalService.GetVarietyByItemId(itemId);
            var plantingList = this.AgriculturalService.GetPlantingByItemId(itemId);
            var agriculturalCulturalOperations =
                this.AgriculturalService.GetAgriculturalCulturalOperationByItemId(itemId);


            //var varietyList =
            //        AgriculturalService.GetAllVariety().Where(x => x.Item.Name == searchTerm || x.Kharip1 == searchTerm || x.Kharip2 == searchTerm || x.Remarks == searchTerm || x.RobiIndustrious == searchTerm || x.VarietyName == searchTerm || x.DetailsSupplierInfo.Name == searchTerm);

            //   var plantingList =
            //        this.AgriculturalService.GetAllPlanting().Where(
            //            x =>
            //            x.Item.Name == searchTerm || x.PlantingSpace == searchTerm || x.PlantingSystems == searchTerm ||
            //            x.PlantingTime == searchTerm || x.Remarks == searchTerm || x.Seeding == searchTerm ||
            //            x.SoliType == searchTerm);

            //   var agriculturalCulturalOperations =
            //         this.AgriculturalService.GetAllAgriculturalCulturalOp().Where(
            //            x =>
            //            x.Item.Name == searchTerm || x.MidStage == searchTerm || x.NameOfOperation == searchTerm ||
            //            x.Remarks == searchTerm || x.BeforeFinalStage == searchTerm || x.EarlyStage == searchTerm ||
            //            x.FinalStage == searchTerm);

              //var  harvestingManagements =
              //      this.AgriculturalService.GetAllHarvestingManagement().Where(
              //          x =>
              //          x.Item.Name == searchTerm || x.Packaging == searchTerm || x.Procedures == searchTerm ||
              //          x.Remarks == searchTerm || x.Storage == searchTerm || x.Systems == searchTerm ||
              //          x.Threshing == searchTerm || x.HarvestingTime == searchTerm);


              var varietyJs =
                varietyList.Select(
                    x =>
                    new
                    {
                        id = x.Id,
                        varietyName = x.VarietyName,
                        kharip1 = x.Kharip1,
                        kharip2 = x.Kharip2,
                        robiIndustries = x.RobiIndustrious,
                        allTheYear = x.AlltheYear,
                        detailsSupplierId = this.DirectoryService.GetDetailsSupplierInfoBySupplierId(x.DetailsSupplierId).Name,
                        remarks = x.Remarks,
                        itemId = x.ItemId
                    });


              var plantingJs =
                  plantingList.Select(
                      x =>
                      new
                      {
                          id = x.Id,
                          soilType = x.SoliType,
                          plantingtime = x.PlantingTime,
                          plantingSystem = x.PlantingSystems,
                          plantingSpace = x.PlantingSpace,
                          seeding = x.Seeding,
                          remarks = x.Remarks
                      });
              var agriculturalCulturalOpJs = agriculturalCulturalOperations.Select(x =>
                                                                           new
                                                                           {
                                                                               id = x.Id,
                                                                               nameofoperation = x.NameOfOperation,
                                                                               earlystage = x.EarlyStage,
                                                                               midstage = x.MidStage,
                                                                               beforefinalstage = x.BeforeFinalStage,
                                                                               finalstage = x.FinalStage,
                                                                               remarks = x.Remarks,
                                                                               itemId = x.ItemId
                                                                           });

              //var harvestingmanagementJs = harvestingManagements.Select(x =>

              //                                                           new
              //                                                           {
              //                                                               id = x.Id,
              //                                                               harvestingtime = x.HarvestingTime,
              //                                                               systems = x.Systems,
              //                                                               procedures = x.Procedures,
              //                                                               threshing = x.Threshing,
              //                                                               packaging = x.Packaging,
              //                                                               storage = x.Storage,
              //                                                               remarks = x.Remarks,
              //                                                               itemId = x.ItemId
              //                                                           });

            return
                Json(
                    new
                        {
                            varietyJson = varietyJs,
                            plantingJson = plantingJs,
                            agriculturalCulturalOperationsJson = agriculturalCulturalOpJs
                           
                        }, JsonRequestBehavior.AllowGet);
        }




    }
}
