using frontend.Domain;
using frontend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
{
    public class BordersPerProductService : IBordersPerProductService
    {
        private BordersPerProductRepository bordersPerProductRepository;

        public BordersPerProductService()
        {
            bordersPerProductRepository = new BordersPerProductRepository();
        }

        public List<BorderPerProduct> All()
        {
            return bordersPerProductRepository.GetAllBordersPerProducts().Result.ToList();
        }

        public BorderPerProduct Find(int product_id, int variable_id)
        {
            return bordersPerProductRepository.GetBordersPerProductById(product_id, variable_id).Result;
        }

        public void Add(BorderPerProduct bordersPerProduct)
        {
            bordersPerProductRepository.AddBordersPerProduct(bordersPerProduct);
        }
    }
}
