using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using PiDevCRM.Domain.Entities;
using PiDevCRM.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace PiDevCRM.Web.Controllers
{
    public class ProductController : Controller
    {

        public ProductService PS;
        public StoreService SS;
        public CategoryService cs;
        public DiscountService DS;
        public PackService Pas;
        public StockService sto;

        public ProductController()
        {
            PS = new ProductService();
            
            SS = new StoreService();
            cs = new CategoryService();
            DS = new DiscountService();
            Pas = new PackService();
            sto = new StockService();
        }

        public ActionResult Dashboard() {
            var list = PS.GetAll();
            List<int> repartitions = new List<int>();
            var prices = list.Select(x=>x.Category.CategoryName);
            foreach (var item in prices)
            {
                repartitions.Add(list.Count(x=>x.Category.CategoryName == item));
            }
            var rep = repartitions;
            ViewBag.PRICES = prices;
            ViewBag.REP = repartitions.ToList();

            return View();
        }












        // GET: Product
        public ActionResult Index()
        {
            //Product p = new Product();
            //if (p.IdDiscount == null)
            //{
            //    p.Price = p.Price * p.Discount.Pourcentage;
            //}
            return View(PS.ListProdTrie());
        }
        public ActionResult Indexpdf()
        {
         
            return View(PS.GetAll());
        }

        [HttpPost]
        [ValidateInput(false)]
        public FileResult Export(string GridHtml)
        {
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(GridHtml);
               
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                pdfDoc.AddTitle("product list");
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                
                pdfDoc.Open();
               
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", "Grid.pdf");
            }
        }

        public ActionResult IndexFrontPAck() {
            return View(Pas.GetAll());
        }






        public ActionResult EditCart(int id)
        {
            Product Prod = PS.GetById(id);


            if (Prod == null)
            {

                return HttpNotFound();
            }
            return View(Prod);
        }

        [HttpPost]
        public ActionResult EditCart(Product p)
        {

            Product prod = PS.GetById(p.IdProduct);

            prod.NameProduct = p.NameProduct;
            prod.Price = p.Price;
            prod.IdDiscount = p.IdDiscount;
            if (ModelState.IsValid)
            {

                PS.Add(prod);
                PS.Commit();
                return RedirectToAction("Index");
            }

            return View();
        }




        //public ActionResult Report(Product product) {
        //    ProductReport productreport = new ProductReport();
        //    byte[] abytes = productreport.prepareReport(Getproducts());
        //    return File(abytes, "application/pdf");


        //}
        //public List<Product> Getproducts()
        //{
        //    List<Product> liste = new List<Product>();
        //    Product p = new Product();
        //    for (int i = 1; i < 6; i++) {
        //        p = new Product();
        //        p.IdProduct = i;
        //        p.NameProduct = "name" + i;
        //        p.Description = "description" + i;
        //        liste.Add(p);

        //    }
        //    return liste;
        //}

        public ActionResult IndexStore()
        {



            return View("~/Views/Store/index.cshtml");
        }

        public ActionResult IndexFront()
        {
            //Product p = new Product();
            //if (p.IdDiscount == null)
            //{
            //    p.Price = p.Price * p.Discount.Pourcentage;
            //}
            return View(PS.GetAll());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product prod = PS.GetById(id);
            if (prod == null) {
                return HttpNotFound();
            }
            return View(prod);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            var listCategories = cs.GetAll();
            ViewBag.Category = new SelectList(listCategories, "IdCategory", "CategoryName");
            return View();
            
        }

        public ActionResult CreateDiscount()
        {
            var ListDisc = DS.GetAll();
            ViewBag.Discs = new SelectList(ListDisc, "IdDiscount", "Pourcentage");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product,HttpPostedFileBase file)
        {
            try
            {
                product.ImageProduct = file.FileName;
                var fileName = "";
                if (file.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/uploads/"), file.FileName);
                    file.SaveAs(path);
                }
                PS.Add(product);
                PS.Commit();



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
       

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product Prod = PS.GetById(id);
            var listCategories = cs.GetAll();
            ViewBag.Category = new SelectList(listCategories, "IdCategory", "CategoryName");

            var ListP = Pas.GetAll();
            ViewBag.packs = new SelectList(ListP, "IdPack", "PackName");

            var ListD = DS.GetAll();
            ViewBag.discs = new SelectList(ListD, "IdDiscount", "Pourcentage");

            var Liststocks = sto.GetAll();
            ViewBag.stocks = new SelectList(Liststocks, "Ref_Stock", "stockname");


            if (Prod == null)
            {

                return HttpNotFound();
            }
            //ViewBag.Category = new SelectList(listCategories, "IdCategory", "CategoryName");
            //ViewBag.IdCategory = new SelectList(PS.unitofwork.dataContext.Categories, "IdCategory", "CategoryName", Prod.IdCategory);
            //ViewBag.Category = new SelectList(P);
            return View(Prod);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product p)
        {

            Product prod = PS.GetById(p.IdProduct);

            prod.NameProduct = p.NameProduct;
            prod.Price = p.Price;
            prod.Description = p.Description;
            prod.IdStock = p.IdStock;
            prod.IdPack = p.IdPack;
            prod.IdCategory = p.IdCategory;
            prod.IdDiscount = p.IdDiscount;
            if (ModelState.IsValid)
            {
                
                PS.Update(prod);
                PS.Commit();
                return RedirectToAction("Index");
            }

            return View();





            //    try
            //    {
            //        //p = PS.GetById(id);
            //        PS.Update(p);
            //        PS.Commit();
            //        return RedirectToAction("Index");
            //    }
            //    catch
            //    {
            //        return View();
            //    }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product prod = PS.GetById(id);
            if (prod == null)
            {
                return HttpNotFound();
            }
            return View(prod);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            Product pro = PS.GetById(id);
            PS.Delete(pro);
            PS.Commit();
            return RedirectToAction("Index");

        }
    }
}
