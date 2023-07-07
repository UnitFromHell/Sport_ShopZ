using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sport_ShopZ.Models;
using SportShopAPI.Models;
using System.Diagnostics;
using System.Text;

namespace Sport_ShopZ.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<User> userList = new List<User>();
            using(var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync("https://localhost:7002/api/Users/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userList = JsonConvert.DeserializeObject<List<User>>(apiResponse);
                }
            }
            return View(userList);
        }

        public async Task<IActionResult> Manufacture()
        {
            List<Manufacture> userList = new List<Manufacture>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7002/api/Manufactures/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userList = JsonConvert.DeserializeObject<List<Manufacture>>(apiResponse);
                }
            }
            return View(userList);
        }
        public ViewResult GetUsers() => View();
        
        [HttpPost]
        public async Task<IActionResult> GetUsers(int id)
        {
            User user = new User();
            using(var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync("https://localhost:7002/api/Users/" + id))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        user = JsonConvert.DeserializeObject<User>(apiResponse);
                    }
                    else
                    {
                        ViewBag.StatusCode = response.StatusCode;
                    }
                }
                return View(user);
            }
        }    
        public ViewResult AddUsers() => View();
        [HttpPost]
        public async Task<IActionResult> AddUsers(User user)
        {
            User recivedUser = new User();
            using(var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                using(var response = await httpClient.PostAsync("https://localhost:7002/api/Users/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    recivedUser = JsonConvert.DeserializeObject<User>(apiResponse);
                }
            }
            return View(recivedUser);
        }
        public async Task<IActionResult> UpdateUsers(int id)
        {
            User user = new User();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7002/api/Users/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(apiResponse);
                }
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUsers(User user, int id)
        {
            User receivedShop = new User();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("https://localhost:7002/api/Shops/" + id, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    receivedShop = JsonConvert.DeserializeObject<User>(apiResponse);
                }
            }
            return View(receivedShop);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUsers(int IdUser)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:7002/api/Shops/" + IdUser))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }


        public ViewResult GetManufactures() => View();
        [HttpPost]
        public async Task<IActionResult> GetManufactures(int id)
        {
            Manufacture manufacture = new Manufacture();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7002/api/Manufactures/" + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        manufacture = JsonConvert.DeserializeObject<Manufacture>(apiResponse);
                    }
                    else
                    {
                        ViewBag.StatusCode = response.StatusCode;
                    }
                }
                return View(manufacture);
            }
        }
        public ViewResult AddManufactures() => View();
        [HttpPost]
        public async Task<IActionResult> AddManufactures(Manufacture manufacture)
        {
            Manufacture recivedManufacture = new Manufacture();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(manufacture), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:7002/api/Manufactures/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    recivedManufacture = JsonConvert.DeserializeObject<Manufacture>(apiResponse);
                }
            }
            return View(recivedManufacture);
        }
        public async Task<IActionResult> UpdateManufactures(int id)
        {
            Manufacture manufacture = new Manufacture();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7002/api/Manufactures/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    manufacture = JsonConvert.DeserializeObject<Manufacture>(apiResponse);
                }
            }
            return View(manufacture);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateManufactures(User user, int id)
        {
            Manufacture receivedManufacture = new Manufacture();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("https://localhost:7002/api/Manufactures/" + id, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    receivedManufacture = JsonConvert.DeserializeObject<Manufacture>(apiResponse);
                }
            }
            return View(receivedManufacture);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteManufactures(int IdMAnufacture)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:7002/api/Manufactures/" + IdMAnufacture))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Manufacture");
        }

        public async Task<IActionResult> Order()
        {
            List<Order> orderList = new List<Order>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7002/api/Orders/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    orderList = JsonConvert.DeserializeObject<List<Order>>(apiResponse);
                }
            }
            return View(orderList);
        }

        public ViewResult GetOrders() => View();

        [HttpPost]
        public async Task<IActionResult> GetOrders(int id)
        {
            Order order = new Order();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7002/api/Orders/" + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        order = JsonConvert.DeserializeObject<Order>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View(order);
        }

        public ViewResult AddOrders() => View();

        [HttpPost]
        public async Task<IActionResult> AddOrders(Order order)
        {
            Order recivedOrder = new Order();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:7002/api/Orders/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    recivedOrder = JsonConvert.DeserializeObject<Order>(apiResponse);
                }
            }
            return View(recivedOrder);
        }

        public async Task<IActionResult> UpdateOrders(int id)
        {
            Order order = new Order();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7002/api/Orders/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    order = JsonConvert.DeserializeObject<Order>(apiResponse);
                }
            }
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrders(Order order, int id)
        {
            Order receivedOrder = new Order();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("https://localhost:7002/api/Orders/" + id, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    receivedOrder = JsonConvert.DeserializeObject<Order>(apiResponse);
                }
            }
            return View(receivedOrder);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrders(int IdOrder)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:7002/api/Orders/" + IdOrder))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Order");
        }
        public async Task<IActionResult> Product()
        {
            List<Product> productList = new List<Product>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7002/api/Products/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productList = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
                }
            }
            return View(productList);
        }
        public ViewResult GetProducts() => View();

        [HttpPost]
        public async Task<IActionResult> GetProducts(int id)
        {
            Product product = new Product();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7002/api/Products/" + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        product = JsonConvert.DeserializeObject<Product>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View(product);
        }

        public ViewResult AddProducts() => View();

        [HttpPost]
        public async Task<IActionResult> AddProducts(Product product)
        {
            Product recivedProduct = new Product();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:7002/api/Products/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    recivedProduct = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }
            return View(recivedProduct);
        }

        public async Task<IActionResult> UpdateProducts(int id)
        {
            Product product = new Product();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7002/api/Products/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    product = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProducts(Product product, int id)
        {
            Product receivedProduct = new Product();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("https://localhost:7002/api/Products/" + id, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    receivedProduct = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }
            return View(receivedProduct);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProducts(int IdProduct)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:7002/api/Products/" + IdProduct))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Product");
        }


        public async Task<IActionResult> TypeProduct()
        {
            List<TypeProduct> productTypeList = new List<TypeProduct>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7002/api/TypeProducts/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productTypeList = JsonConvert.DeserializeObject<List<TypeProduct>>(apiResponse);
                }
            }
            return View(productTypeList);
        }
        public ViewResult GetProductTypes() => View();

        [HttpPost]
        public async Task<IActionResult> GetProductTypes(int id)
        {
            TypeProduct productType = new TypeProduct();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7002/api/TypeProducts/" + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        productType = JsonConvert.DeserializeObject<TypeProduct>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View(productType);
        }

        public ViewResult AddProductTypes() => View();

        [HttpPost]
        public async Task<IActionResult> AddProductTypes(TypeProduct productType)
        {
            TypeProduct recivedProductType = new TypeProduct();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(productType), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:7002/api/TypeProducts/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    recivedProductType = JsonConvert.DeserializeObject<TypeProduct>(apiResponse);
                }
            }
            return View(recivedProductType);
        }

        public async Task<IActionResult> UpdateProductTypes(int id)
        {
            TypeProduct productType = new TypeProduct();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7002/api/TypeProducts/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productType = JsonConvert.DeserializeObject<TypeProduct>(apiResponse);
                }
            }
            return View(productType);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductTypes(TypeProduct productType, int id)
        {
            TypeProduct receivedProductType = new TypeProduct();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(productType), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("https://localhost:7002/api/TypeProducts/" + id, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    receivedProductType = JsonConvert.DeserializeObject<TypeProduct>(apiResponse);
                }
            }
            return View(receivedProductType);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProductTypes(int IdProductType)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:7002/api/TypeProducts/" + IdProductType))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("ProductType");
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}