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

        public BorderPerProduct Find(int id)
        {
            return bordersPerProductRepository.GetBordersPerProductById(id).Result;
        }

        public void Add(BorderPerProduct bordersPerProduct)
        {
            bordersPerProductRepository.AddBordersPerProduct(bordersPerProduct);
        }

        public void Update(BorderPerProduct bordersPerProduct)
        {
            bordersPerProductRepository.UpdateBordersPerProduct(bordersPerProduct);
        }

        public void Delete(int id)
        {
            bordersPerProductRepository.DeleteBordersPerProduct(id);
        }
    }
}
