﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppParameterValidate.Customs;
using WebAppParameterValidate.Models;

namespace WebAppParameterValidate.Controllers
{
    public class HomeController : Controller
    {
        protected override IActionInvoker CreateActionInvoker()
        {
            IActionInvoker actionInvoker = base.CreateActionInvoker();
            if (actionInvoker is ControllerActionInvoker)
            {
                return new ParameterValidationActionInvoker();
            }
            else
            {
                return new ParameterValidationAsynActionInvoker();
            }
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add(
            [Display(Name="第一个参数")]
            [Range(10,20,ErrorMessage ="{0}必须在{1}和{2}之间")]
            [ModelBinder(typeof(ParameterValidationModelBinder))]
            double operand1,
            [Display(Name="第二个参数")]
            [Range(10,20,ErrorMessage ="{0}必须在{1}和{2}之间")]
            [ModelBinder(typeof(ParameterValidationModelBinder))]
            double operand2
            )
        {
            double result = 0.00;
            if (ModelState.IsValid)
            {
                result = operand1 + operand2;
            }
            return View(new OperationData
            {
                Operand1=operand1,
                Operand2=operand2,
                Operator="Add",
                result=result
            });
        }
    }
}