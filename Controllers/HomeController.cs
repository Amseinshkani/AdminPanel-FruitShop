using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


public class HomeController : Controller
{
    private readonly Context _Context;

    protected readonly IWebHostEnvironment _env;

    public static long id;


    public HomeController(Context db, IWebHostEnvironment env)
    {
        _Context = db;
        _env = env;
    }



    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Regester()
    {
        return View();
    }

    public IActionResult Regestersign(MVAdmin MAdmin)
    {
        if (MAdmin.Admin == "Amsein" && MAdmin.PassWord == 256174)
        {
            return RedirectToAction("InputAdmin");
        }
        else
        {
            return View("ErrorRegester");
        }
    }

    public IActionResult ErrorRegester(MVAdmin MAdmin)
    {
        if (MAdmin.Admin == "Amsein" && MAdmin.PassWord == 256174)
        {
            return RedirectToAction("InputAdmin");
        }
        else
        {
            return View("ErrorRegester");
        }
    }

    public IActionResult Showing()
    {
        ViewBag.Show = _Context.tblProducts.ToList();
        return View(ViewBag.Show);
    }

    public IActionResult InputAdmin()
    {
        return View();
    }

    public async Task<IActionResult> InputAdminAddAsync(MVProduct MProduct)
    {
        ///upload file
        string FileExtension = Path.GetExtension(MProduct.upimg.FileName);
        string NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtension);
        var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
        using (var stream = new FileStream(path, FileMode.Create))
        {
            await MProduct.upimg.CopyToAsync(stream);
        }

        /// end upload file
        TblProduct tbl =
            new TblProduct()
            {
                Id = MProduct.Id,
                Name = MProduct.Name,
                upimg = NewFileName,
                Price = MProduct.Price,
                Count = MProduct.Count
            };

        _Context.tblProducts.Add(tbl);
        _Context.SaveChanges();
        return RedirectToAction("Showing");
    }

    public IActionResult signup()
    {
        return View();
    }

    public IActionResult signupadd(MVUser MUser)
    {

        TblUser A =
            new TblUser()
            {
                Id = MUser.Id,
                UserName = MUser.UserName,
                PassWord = MUser.PassWord
            };
        _Context.tblUsers.Add(A);
        _Context.SaveChanges();
        return RedirectToAction("Login");
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Loginin(int passWord, string userName)
    {
        var select =_Context.tblUsers.Where(a =>a.PassWord == passWord && a.UserName == userName).SingleOrDefault();

        id =_Context.tblUsers.Where(a => a.PassWord == passWord && a.UserName == userName).Select(a => a.Id).FirstOrDefault();

        if (select != null)
        {
            return RedirectToAction("Showing");
        }
        else
        {
            return RedirectToAction("LoginError");
        }
    }

    public IActionResult LoginError()
    {
        return View();
    }

    public IActionResult LoginErrorr(int passWord, string userName)
    {
        var select =_Context.tblUsers.Where(a => a.PassWord == passWord && a.UserName == userName).SingleOrDefault();

        if (select != null)
        {
            return RedirectToAction("Showing");
        }
        else
        {
            return RedirectToAction("LoginError");
        }
    }

        public IActionResult Buyings(int Id)
        {
            var b = _Context.tblProducts.Where(a => a.Id == Id).FirstOrDefault();

          

          
               MVProduct m=new MVProduct();
               m.Id=b.Id;
               m.Name=b.Name;
               m.Price=b.Price;
               m.Count=b.Count;
               m.Requestedweight=b.Requestedweight;
               m.totalweight=b.totalweight;
               m.img=b.upimg;

             
          



          




            return View(m);
        }
[HttpPost]
    public IActionResult sabadm(MVProduct V)
    {
        var Select = _Context.tblProducts.Where(a => a.Id == V.Id).SingleOrDefault();
        if (Select.Count >= V.Count)
        {
            Select.Count = Select.Count - V.Requestedweight;
            
            _Context.tblProducts.Update(Select);
            _Context.SaveChanges();

            Tbl_Factor f =new Tbl_Factor()
            {
              
                Name=V.Name,
                Count=V.Count,
                Price=V.Price,
                totalweight=V.totalweight,
                sum=V.Requestedweight*V.Price,
                Requestedweight=V.Requestedweight,
                upimg="test"
                

            };
             _Context.tbl_Factors.Add(f);
            _Context.SaveChanges();

           
            return RedirectToAction("sabad");
        }
        else
        {
            ViewBag.alert = "این مقدار در انبار موجود نیست";
            return RedirectToAction("Sabadvazn");
        }
        return View();
    }

    public IActionResult Sabadvazn()
        {
            return View();
        }
    

    public IActionResult DSabad(int Id)
    {
        var Select = _Context.tblProducts.Where(a => a.Id == Id).SingleOrDefault();
        _Context.tblProducts.Remove(Select);
        _Context.SaveChanges();
        return View();
    }

    public IActionResult sabad()
    {
        ViewBag.b=_Context.tbl_Factors.OrderByDescending(a=>a.Id).ToList();
        return View();

    }


}