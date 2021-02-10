using CrudOperation.Interfaces;
using CrudOperation.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperation.Controllers
{
    public class StudentController : Controller
    {
        #region Instant field
        private IStudentRepository _studentRepo;
        #endregion

        #region Property
        public int CountStudents { get; set; }
        #endregion

        #region Constructor
        public StudentController(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        #endregion

        #region Action Methods
        
        public IActionResult Index(string searchCriteria)
        {

            var dicStudents = _studentRepo.GetAllStudents();
            // if search criteria is not empty then find the filter data
            if(!String.IsNullOrEmpty(searchCriteria))
            {
                dicStudents = _studentRepo.FilterName(searchCriteria);
            }

            int CountStudents = dicStudents.Count;

            // Before pass data into View , we VM (because contains complex data in it)
            StudentVm vm = new StudentVm()
            {
                Students = dicStudents,
                TotalCount = CountStudents,
               
            };
            // here we pass Student View Model
            return View(vm);
        }
      
        #endregion




    }
}
