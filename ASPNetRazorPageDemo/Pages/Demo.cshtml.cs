using ASPNetRazorPageDemo.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ASPNetRazorPageDemo.Pages
{
    public class DemoModel : PageModel
    {
        public string Message { get; set; }
        public List<string> MessageList { get; set; }

        public void OnGet()
        {
            Message = "On Demo Page";
        }

        public ActionResult OnPostSend()
        {
            
                string name_of_dormitoryPosted = " ";
                int dormitory_typePosted = 1;
                double min_price_of_roomPosted = 0;
                double max_price_of_roomPosted = 10000;
                int room_areaPosted = 0;
                int langIDPosted = 0;

                string facility_TVPosted = " ";
                string facility_InternetPosted = " ";
                string facility_Wc_showerPosted = " ";
                string facility_KitchenettePosted = " ";
                string facility_bedPosted = " ";

                string facility_air_conditionPosted = " ";
                string facility_central_acPosted = " ";
                string facility_refrigeratorPosted = " ";
                string facility_laundryPosted = " ";
                string facility_cafeteriaPosted = " ";
                string facility_room_telPosted = " ";
                 string facility_generatorPosted = " ";



            {
                MemoryStream stream = new MemoryStream();
                Request.Body.CopyTo(stream);
                stream.Position = 0;

                using (StreamReader reader = new StreamReader(stream))
                {
                    string requestBody = reader.ReadToEnd();
                    if (requestBody.Length > 0)
                    {
                        var obj = JsonConvert.DeserializeObject<PostData2>(requestBody);
                        if (obj != null)
                        {
                            name_of_dormitoryPosted = obj.name_of_dormitory;
                            dormitory_typePosted = obj.dormitory_type;
                            min_price_of_roomPosted = obj.min_price_of_room;
                            max_price_of_roomPosted = obj.max_price_of_room;
                            room_areaPosted = obj.room_area;
                            langIDPosted = obj.langId;

                            facility_TVPosted = obj.facility_TV;
                            facility_InternetPosted = obj.facility_Internet;
                            facility_Wc_showerPosted = obj.facility_Wc_shower;
                            facility_KitchenettePosted = obj.facility_Kitchenette;
                            facility_bedPosted = obj.facility_bed;

                            facility_air_conditionPosted = obj.facility_air_condition;
                            facility_central_acPosted = obj.facility_central_ac;
                            facility_refrigeratorPosted = obj.facility_refrigerator;
                            facility_laundryPosted = obj.facility_laundry;
                            facility_cafeteriaPosted = obj.facility_cafeteria;
                            facility_room_telPosted = obj.facility_room_tel;
                            facility_generatorPosted = obj.facility_generator;



    }
                    }
                }
            }


           List<PostData> arr = new List<PostData>();
            List<string> tr_acct_num, usd_acct_num;
            List<Facility> faci= new List<Facility>();
            List<string> listDormitories = new List<string>();
            List<string> listRoom = new List<string>();

            

            using (var context = new fees_and_facilitiesContext())
            {
                var dormitories = context.DormitoriesTable
                                    .Include(dormitory_trans => dormitory_trans.DormitoriesTableTranslation)
                                    .Include(dormitory_room => dormitory_room.RoomTable)

                                    .ToList();



               
                usd_acct_num = new List<string>();
                usd_acct_num.Add("Account No: 6820-57259db");
                usd_acct_num.Add("IBAN: TR04 0006 4000 0026 8200 057259db");

                context.DormitoriesTable.ToList().ForEach(dorm =>
                {
                    dorm.DormitoriesTableTranslation.Where(r=> r.LanguageId ==langIDPosted).ToList().ForEach(dorm_trans =>
                    {

                        


                        context.RoomTable.Where(r=> r.DormitoryId == dorm.Id).Include(r => r.RoomTableTranslation).Include(r => r.RoomFacility).ToList().ForEach(room_t =>
                          {
                              

                              room_t.RoomTableTranslation.Where(r => r.LanguageId == langIDPosted).ToList().ForEach(room_trans =>
                              {
                                  tr_acct_num = new List<string>();
                                  ///  tr_acct_num.Add("Account No: 6820-174392db");
                                  //tr_acct_num.Add("IBAN: TR39 0006 4000 0016 8200 174392db");
                                  usd_acct_num = new List<string>();
                                  string usdd = "";
                                  string trr = "";
                                  //usd_acct_num.Add("Account No: 6820-57259db");
                                  //usd_acct_num.Add("IBAN: TR04 0006 4000 0026 8200 057259db");

                                  context.DormitoryBankAccountTable.Include(r => r.BankCurrencyTable).Where(c => c.DormitoryId == room_t.DormitoryId && room_trans.RoomTableNonTransId==room_t.Id).ToList().ForEach(dorm_bank_acc =>
                                     {
                                         dorm_bank_acc.BankCurrencyTable.Where(c=> c.CurrencyName =="USD").ToList().ForEach(bk_curr =>
                                         {
                                             usdd += dorm_bank_acc.BankName;
                                             context.AccountParameterValues.Where(c => c.CurrencyId == bk_curr.Id).Include(c => c.AccountParameterValuesTranslation).ToList().ForEach(acct_param_val =>
                                             {
                                                 acct_param_val.AccountParameterValuesTranslation.Where(c => c.LanguageId == langIDPosted).ToList().ForEach(acc_param_val_trans =>
                                                 {
                                                     // acc_param_val_trans.Value;

                                                     context.AccountInformationParameter.Include(c => c.AccountInformationParameterTranslation).Where(c => c.Id == acct_param_val.ParameterId).ToList().ForEach(acc_info_param =>
                                                     {
                                                         acc_info_param.AccountInformationParameterTranslation.Where(c => c.LanguageId == langIDPosted).ToList().ForEach(acc_info_param_trans =>
                                                         {
                                                             usdd += "<br>" + acc_info_param_trans.Parameter + ":" + acc_param_val_trans.Value;
                                                             //acc_info_param_trans.Parameter;
                                                         });
                                                     });
                                                 });
                                             });

                                             usd_acct_num.Add(usdd);
                                             usdd = "";

                                         });



                                         dorm_bank_acc.BankCurrencyTable.Where(c => c.CurrencyName == "TL").ToList().ForEach(bk_curr =>
                                         {
                                             trr += dorm_bank_acc.BankName;

                                             context.AccountParameterValues.Where(c => c.CurrencyId == bk_curr.Id).Include(c => c.AccountParameterValuesTranslation).ToList().ForEach(acct_param_val =>
                                             {
                                                 acct_param_val.AccountParameterValuesTranslation.Where(c => c.LanguageId == langIDPosted).ToList().ForEach(acc_param_val_trans =>
                                                 {
                                                     // acc_param_val_trans.Value;

                                                     context.AccountInformationParameter.Include(c => c.AccountInformationParameterTranslation).Where(c => c.Id == acct_param_val.ParameterId).ToList().ForEach(acc_info_param =>
                                                     {
                                                         acc_info_param.AccountInformationParameterTranslation.Where(c => c.LanguageId == langIDPosted).ToList().ForEach(acc_info_param_trans =>
                                                         {
                                                             trr += "<br>" + acc_info_param_trans.Parameter + ":" + acc_param_val_trans.Value;
                                                             //acc_info_param_trans.Parameter;
                                                         });
                                                     });
                                                 });
                                             });

                                             tr_acct_num.Add(trr);
                                             trr = "";

                                         });
                                     });

                                     faci = new List<Facility>();

                                     context.RoomFacility.Where(r => r.RoomId == room_t.Id ).Include(r => r.Facility).ToList().ForEach(room_faci =>
                                      {
                                          context.FacilityTable.Where(r => r.Id == room_faci.FacilityId ).Include(r => r.FacilityTableTranslation).ToList().ForEach(facii =>
                                            {
                                                facii.FacilityTableTranslation.Where(r=> r.LanguageId== langIDPosted).ToList().ForEach(faci_trans =>
                                                {
                                                    string facility_o = "";
                                                    context.FacilityOption.Where(r=>r.FacilityId== room_faci.FacilityId && facii.Id==room_faci.FacilityId )
                                                                .Include(r=> r.FacilityOptionTranslation).ToList().ForEach(faci_op =>
                                                    {
                                                        faci_op.FacilityOptionTranslation
                                                            .Where(r => r.LanguageId == langIDPosted && r.FacilityOptionNonTransId==room_faci.FacilityOptionId)
                                                              
                                                        .ToList().ForEach(faci_op_trans =>
                                                           {
                                                               facility_o+= " | "+faci_op_trans.FacilityOption;
                                                              
                                                           });

                                                    });

                                                    faci.Add(new Facility { facility_name = faci_trans.FacilityTitle+ facility_o, facility_icon_url = facii.FacilityIconUrl });




                                                });
                                              });
                                        
                                         
                                      });

                                  


                                     

                                     faci.Add(new Facility { facility_name = "Room Area: "+ room_t.RoomArea+" m"+ "<sup style=\"font-size: smaller; \">2</sup>", facility_icon_url = "./Dormitories_files/kitchen.png" });
                                     faci.Add(new Facility { facility_name = "Price: "+dorm.RoomPriceCurrencySymbol+" "+room_t.RoomPrice, facility_icon_url = "./Dormitories_files/thumbnail(3).png" });


                                     arr.Add(new PostData
                                     {
                                         name_of_dormitory = dorm_trans.DormitoryName,
                                         name_of_room = room_trans.RoomTitle+" ("+dorm_trans.GenderAllocation+")",
                                         url_of_room_image =room_t.RoomPictureUrl,
                                         facility = faci,
                                         dormitory_type = dorm.DormitoryTypeId,
                                         price_of_room = room_t.RoomPrice,
                                         room_area = room_t.RoomArea,
                                         dormitory_account = dorm_trans.DormitoryName,
                                         bank_name = "bank name",
                                         turkish_lira_account_number = tr_acct_num,
                                         usd_account_number = usd_acct_num,
                                         dormitory_website = "dormitory website"
                                     });
                                 });

                          });


                       

                    });
                });

          
            


           
        



    }
            tr_acct_num = new List<string>();
            tr_acct_num.Add("Account No: 6820-174392db");
            tr_acct_num.Add("IBAN: TR39 0006 4000 0016 8200 174392db");

            usd_acct_num = new List<string>();
            usd_acct_num.Add("Account No: 6820-57259db");
            usd_acct_num.Add("IBAN: TR04 0006 4000 0026 8200 057259db");

            faci = new List<Facility>();
            faci.Add(new Facility { facility_name = "buckets", facility_icon_url = "./Dormitories_files/thumbnail(3).png" });
            faci.Add(new Facility { facility_name = "broom", facility_icon_url = "./Dormitories_files/thumbnail(3).png" });
            faci.Add(new Facility { facility_name = "broom", facility_icon_url = "./Dormitories_files/thumbnail(5).png" });
            faci.Add(new Facility { facility_name = "broom", facility_icon_url = "./Dormitories_files/thumbnail(4).png" });
            faci.Add(new Facility { facility_name = "broom", facility_icon_url = "./Dormitories_files/thumbnail(4).png" });

            arr.Add(new PostData
            {
                name_of_dormitory = "Sample dormitory",
                name_of_room = "Sample room",
                url_of_room_image = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TEK%20K%C4%B0%C5%9E%C4%B0L%C4%B0K%20EXCLUS%C4%B0VE.jpg?RenditionID=7",
                facility = faci,
                room_area = 25,
                dormitory_type =1,
                dormitory_account = "dormitory_account",
                bank_name = "bank name",
                price_of_room = 2700,
                turkish_lira_account_number = tr_acct_num,
                usd_account_number = usd_acct_num,
                dormitory_website = "dormitory website"
            });

            //var faci_query = from Facility f in arr
            //                 where (f.facility_name.Contains("TV"))
            //                 select f;
            //var query = from PostData s in arr
            //            where (s.facility.
            //            select s;

            //var query = from s in arr
            //            where s.Facility.Any(c => c.facility_name.contains("TV"))
            //            select s;

            //  PostData query = arr.fin
            ArrayList sa = new ArrayList();
            //sa.Add("Kitchenette | Flats");
            //sa.Add("TV | In room");
            //sa.Add("Central conditioning system | Cooling");

            sa.Add(facility_TVPosted);
            sa.Add(facility_InternetPosted );
            sa.Add(facility_Wc_showerPosted);
            sa.Add(facility_KitchenettePosted);
            sa.Add(facility_bedPosted);

            sa.Add(facility_air_conditionPosted);
            sa.Add(facility_central_acPosted);
            sa.Add(facility_refrigeratorPosted);
            sa.Add(facility_laundryPosted);
            sa.Add(facility_cafeteriaPosted);
            sa.Add(facility_room_telPosted);
            sa.Add(facility_generatorPosted);

            //string name_of_dormitoryPosted = " ";
            

            
            var query = arr;

            if(room_areaPosted == 0)
            {

                if (dormitory_typePosted == 0)
                {
                    foreach (var q in sa)
                        query = query
                       .Where(item =>
                          item.name_of_dormitory.Contains(name_of_dormitoryPosted) &&

                        
                          item.price_of_room >= min_price_of_roomPosted && item.price_of_room <= max_price_of_roomPosted &&
                          item.facility.Any(fac => fac.facility_name.Contains(q.ToString())))
                       .ToList();
                }
                else
                {
                    foreach (var q in sa)
                        query = query
                       .Where(item =>
                          item.name_of_dormitory.Contains(name_of_dormitoryPosted) &&
                          item.dormitory_type == dormitory_typePosted &&
                        
                          item.price_of_room >= min_price_of_roomPosted && item.price_of_room <= max_price_of_roomPosted &&
                          item.facility.Any(fac => fac.facility_name.Contains(q.ToString())))
                       .ToList();
                }
            }
            else
            {

                if (dormitory_typePosted == 0)
                {
                    foreach (var q in sa)
                        query = query
                       .Where(item =>
                          item.name_of_dormitory.Contains(name_of_dormitoryPosted) &&

                          item.room_area == room_areaPosted &&
                          item.price_of_room >= min_price_of_roomPosted && item.price_of_room <= max_price_of_roomPosted &&
                          item.facility.Any(fac => fac.facility_name.Contains(q.ToString())))
                       .ToList();
                }
                else
                {
                    foreach (var q in sa)
                        query = query
                       .Where(item =>
                          item.name_of_dormitory.Contains(name_of_dormitoryPosted) &&
                          item.dormitory_type == dormitory_typePosted &&
                          item.room_area == room_areaPosted &&
                          item.price_of_room >= min_price_of_roomPosted && item.price_of_room <= max_price_of_roomPosted &&
                          item.facility.Any(fac => fac.facility_name.Contains(q.ToString())))
                       .ToList();
                }
            }




          

            return new JsonResult(query);
        }
    }

    public class PostData2
    {
        public string name_of_dormitory { get; set; }
        public int dormitory_type { get; set; }

        public double min_price_of_room { get; set; }
        public double max_price_of_room { get; set; }
        public int room_area { get; set; }
        public int langId { get; set; }

        public string facility_TV { get; set; }
        public string facility_Internet { get; set; }
        public string facility_Wc_shower { get; set; }
        public string facility_Kitchenette { get; set; }
        public string facility_bed { get; set; }

        public string facility_air_condition { get; set; }
        public string facility_central_ac { get; set; }
        public string facility_refrigerator { get; set; }
        public string facility_laundry { get; set; }
        public string facility_cafeteria { get; set; }
        public string facility_room_tel { get; set; }
        public string facility_generator { get; set; }

    }

    public class PostData
    {
        public string name_of_dormitory { get; set; }
        public string name_of_room { get; set; }
        public double price_of_room { get; set; }
        public int dormitory_type { get; set; }
        public int room_area { get; set; }
        public string url_of_room_image { get; set; }
        public List<Facility> facility { get; set; }
        public string dormitory_account { get; set; }
        public string bank_name { get; set; }
        public List<string> turkish_lira_account_number { get; set; }
        public List<string> usd_account_number { get; set; }
        public string dormitory_website { get; set; }

    }

    public class Facility
    {
        public string facility_name { get; set;  }
        public string facility_icon_url { get; set; }
    }
}