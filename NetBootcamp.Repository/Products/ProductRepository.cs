namespace NetBootcamp.Repository.Products
{
    public class ProductRepository(AppDbContext context) : GenericRepository<Product>(context), IProductRepository
    {
        public async Task UpdateProductName(string name, int id)
        {
            var product = await GetById(id);
            product!.Name = name;
            await Update(product);
        }
    }
}
