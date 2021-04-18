using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.IRepository;
using ScadaWeb.IService;
using ScadaWeb.Model;
 

namespace ScadaWeb.Service
{
    public class DonationService : BaseService<DonationModel>, IDonationService
    {
        public IDonationRepository DonationRepository { get; set; }

        public dynamic GetAll()
        {
         
            
            return GetAll("","");
        }

        public IEnumerable<DonationModel> GetSumPriceTop(int num)
        {
            return DonationRepository.GetSumPriceTop(num);
        }

        public DonationModel GetConsoleNumShow()
        {
            return DonationRepository.GetConsoleNumShow();
        }

        public dynamic GetListByFilter(DonationModel filter, PageInfo pageInfo)
        {
            throw new NotImplementedException();
        }
    }
}
