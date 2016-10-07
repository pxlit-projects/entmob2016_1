﻿using front_end.Domain;
using front_end.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Services
{
    public class BordersPerProductService
    {
        private BordersPerProductRepository bordersPerProductRepository;

        public BordersPerProductService()
        {
            bordersPerProductRepository = new BordersPerProductRepository();
        }

        public List<BordersPerProduct> All()
        {
            return bordersPerProductRepository.GetAllBordersPerProducts().Result.ToList();
        }

        public BordersPerProduct Find(int id)
        {
            return bordersPerProductRepository.GetBordersPerProductById(id).Result;
        }

        public void Add(BordersPerProduct bordersPerProduct)
        {
            bordersPerProductRepository.AddBordersPerProduct(bordersPerProduct);
        }

        public void Update(BordersPerProduct bordersPerProduct)
        {
            bordersPerProductRepository.UpdateBordersPerProduct(bordersPerProduct);
        }

        public void Delete(int id)
        {
            bordersPerProductRepository.DeleteBordersPerProduct(id);
        }
    }
}
