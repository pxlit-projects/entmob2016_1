using frontend.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Repository
{
    public class ProductsPerCargoRepository : IProductsPerCargoRepository
    {
        public HttpClient Client { get; set; }

        public IProductRepository ProductRepository { get; set; }

        public ICargoRepository CargoRepository { get; set; }

        public ProductsPerCargoRepository()
        {
            ProductRepository = new ProductRepository();
            CargoRepository = new CargoRepository();
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Global.IP_ADRESS);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<ProductPerCargo>> GetAllProductsPerCargos()
        {
            var products = await ProductRepository.GetAllProducts();
            List<ProductPerCargo> productPerCargos = new List<ProductPerCargo>();
            products.ForEach(p => p.Cargos.ForEach(c => productPerCargos.Add(c)));
            return productPerCargos;
        }

        public async Task<ProductPerCargo> GetProductsPerCargoById(int cargo_id, int product_id)
        {
            var productPerCargos = await GetAllProductsPerCargos();
            var productPerCargo = productPerCargos.FirstOrDefault(p => p.Id.Cargo_id == cargo_id && p.Id.Product_id == product_id);
            return productPerCargo;
        }

        public async void AddProductsPerCargo(ProductPerCargo productsPerCargo)
        {
            var product = await ProductRepository.GetProductById(productsPerCargo.Product.Product_id);
            var cargo = await CargoRepository.GetCargoById(productsPerCargo.Cargo.Cargo_id);
            product.Cargos.Add(productsPerCargo);
            cargo.Products.Add(productsPerCargo);
            ProductRepository.UpdateProduct(product);
            CargoRepository.UpdateCargo(cargo);
        }
    }
}
