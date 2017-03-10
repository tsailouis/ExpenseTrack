using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpenseTrack.Models
{
    public class ExpenseTrackModels
    {
     
        //public string PayType { get; set; }
        [DataType(DataType.Currency)]
        [Required]
        [Display(Name = "金額")]
        public int Money { get; set; }

        [Display(Name = "日期")]
        public DateTime CreateDate { get; set; }

        [DataType(DataType.MultilineText)]

        [Display(Name = "備註")]
        public string Description { get; set; }


        public string PayType { get; set; }
    }

    public class ExpenseList
    {
        public List<ExpenseTrackModels> GetData()
        {
            try
            {
                List<ExpenseTrackModels> trackList = new List<ExpenseTrackModels>();
                for (int i =1; i < 100; i++)
                {
                    ExpenseTrackModels expen = new ExpenseTrackModels();
                    expen.PayType = (((i % 2 )==0) ? "支出" : "收入");
                    expen.Money = i * 100;
                    expen.CreateDate = DateTime.Now;
                    expen.Description = "備註";
                    trackList.Add(expen);
                }
                return trackList;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }

        }
    }
}