
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task2;
using Task2.Models2;

namespace paygateway.Controllers
{
    public class PaymentController : Controller
    {

        // GET: Payment/Create
        public ActionResult Makepayment()
        {
            return View();
        }

        // POST: Payment/Create
        [HttpPost]
        public ActionResult Makepayment(Table_2 paygateway)
        {
            int amount = Convert.ToInt32(paygateway.Amount);
            int charges;

            // TODO: Blank or empty textbox verification

            if (string.IsNullOrEmpty(paygateway.Amount) || string.IsNullOrEmpty(paygateway.Transferto))
            {
                paygateway.ErrorMessage = "One or more Required filed not filled";

                // TODO: Return back for Currection
                return View("Makepayment", paygateway);

            }
            else
            {
               


                    // TODO: Formtion of an instance of Data base
                    using (parkwayDbEntities db = new parkwayDbEntities())
                    {

                        // TODO: Verification of the sender Acount number
                        var senders = db.Table_1.OrderByDescending(o => o.Id).ToList();
                    
                    var sender = senders.FirstOrDefault(x => x.Account == paygateway.Account);
                        




                        if (sender != null)
                        {

                                int balance = Convert.ToInt32(sender.Balance);

                                int trans;
                                // TODO: Do transaction for the Same bank users
                                if (paygateway.Transferto.Contains("Same Bank"))
                                {
                                    balance = balance - amount;

                                    sender.Balance = Convert.ToString(balance);
                                    sender.Amount = Convert.ToString(amount);
                                    sender.Transfer_Amount = paygateway.Amount;
                                    sender.Charges = "";
                                    sender.Debit_Amount = paygateway.Amount;


                                    db.Table_1.Add(sender);
                                    db.SaveChanges();


                                    ModelState.Clear();
                                    paygateway.Account =
                                    paygateway.Amount =
                                    paygateway.Transferto = "";

                                    ViewBag.Amount = amount;
                                    paygateway.ErrorMessage = " has been Successfully Sent, and Charges: 10";
                                    return View("Makepayment", paygateway);
                                }


                                // TODO: Do transaction for the Other bank users
                                else
                                {

                                    // TODO: Do transaction for amount btween 1-5000
                                    if (amount >= 1 && amount <= 5010)
                                    {
                                        charges = 10;
                                        trans = amount - charges;
                                        balance = balance - trans;


                                        sender.Balance = Convert.ToString(balance);
                                        sender.Amount = Convert.ToString(amount);
                                        sender.Transfer_Amount = Convert.ToString(trans);
                                        sender.Charges = Convert.ToString(charges); ;
                                        sender.Debit_Amount = paygateway.Amount;


                                        db.Table_1.Add(sender);
                                        db.SaveChanges();


                                        ModelState.Clear();
                                        paygateway.Account =
                                        paygateway.Amount =
                                        paygateway.Transferto = "";

                                        ViewBag.Amount = trans;
                                        paygateway.ErrorMessage = " has been Successfully Sent, and Charges: 10";
                                        return View("Makepayment", paygateway);
                                        // return View("Makepayment", paygateway);
                                    }

                                    // TODO: Do transaction for amount btween 5001-50000
                                    else if (amount > 5010 && amount <= 50025)
                                    {

                                        charges = 25;
                                        trans = amount - charges;
                                        balance = balance - amount;



                                        sender.Balance = Convert.ToString(balance);
                                        sender.Amount = Convert.ToString(amount);
                                        sender.Transfer_Amount = Convert.ToString(trans);
                                        sender.Charges = Convert.ToString(charges); ;
                                        sender.Debit_Amount = paygateway.Amount;

                                        db.Table_1.Add(sender);
                                        db.SaveChanges();

                                        ViewBag.Amount = trans;

                                        ModelState.Clear();
                                        paygateway.Account =
                                        paygateway.Amount =
                                        paygateway.Transferto = "";

                                        paygateway.ErrorMessage = " has been Successfully Sent, and Charges: 25";
                                        return View("Makepayment", paygateway);
                                        // return View("Makepayment", paygateway);

                                    }

                                    // TODO: Do transaction for amount Above 50000
                                    else if (amount > 50025)
                                    {

                                        charges = 50;
                                        trans = amount - charges;
                                        balance = balance - amount;

                                        sender.Balance = Convert.ToString(balance);
                                        sender.Amount = Convert.ToString(amount);
                                        sender.Transfer_Amount = Convert.ToString(trans);
                                        sender.Charges = Convert.ToString(charges); ;
                                        sender.Debit_Amount = paygateway.Amount;
                                        

                                        db.Table_1.Add(sender);
                                        db.SaveChanges();

                                        ViewBag.Amount = trans;

                                        ModelState.Clear();
                                        paygateway.Account =
                                        paygateway.Amount =
                                        paygateway.Transferto = "";

                                        paygateway.ErrorMessage = " has been Successfully Sent, and Charges: 50";
                                        return View("Makepayment", paygateway);
                                        // return View("Makepayment", paygateway);

                                    }
                                }
                            

                        }
                        else if(sender==null)
                        {
                            paygateway.ErrorMessage = "Account not found";

                            return RedirectToAction("Makepayment", paygateway);
                        }
                    }

                paygateway.ErrorMessage = "Account not found";

                return RedirectToAction("Makepayment", paygateway);

            }
        }
        // GET: Payment/Edit/5


    }
}
