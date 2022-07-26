using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {


        private LoanDALImpl LoanDAL;

        public LoanController()
        {
            LoanDAL = new LoanDALImpl();
        }

        // GET: api/<LoanController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<Loan> loanes = LoanDAL.GetAll().ToList();
                List<LoanModel> result = new List<LoanModel>();
                foreach (Loan loan in loanes)
                {
                    LoanModel loanModel = ObjectToModelConvert(loan);
                    result.Add(loanModel);
                }
                return new JsonResult(result)
                {
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

     

        // GET api/<LoanController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                Loan loan = LoanDAL.Get(id);
                if (loan != null)
                {
                    return new JsonResult(loan)
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                else
                {
                    return new JsonResult("Error: The ID is not correct")
                    {
                        StatusCode = (int)HttpStatusCode.NotFound
                    };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }
        // POST api/<LoanController>
        [HttpPost]
        public JsonResult Post([FromBody] LoanModel loanModel)
        {
            try
            {
                Loan loan = ModelToObjectConvert(loanModel);

                bool result = LoanDAL.Update(loan);

                if (result)
                {
                    return new JsonResult(loan)
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                else
                {
                    return new JsonResult("Error: Information is not correct")
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        // PUT api/<LoanController>/5
        [HttpPut("{id}")]
        public JsonResult Put([FromBody] LoanModel loanModel)
        {
            try
            {
                Loan loan = ModelToObjectConvert(loanModel);

                bool result = LoanDAL.Add(loan);

                if (result)
                {
                    return new JsonResult(loan)
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                else
                {
                    return new JsonResult("Error: Information is not correct")
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }


        // DELETE api/<LoanController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Loan loan = new Loan()
                {
                    LoansId = id
                };

                bool result = LoanDAL.Remove(loan);

                if (result)
                {
                    return new JsonResult("Ok: The data is deleted")
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                else
                {
                    return new JsonResult("Error: Information is not correct")
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        private LoanModel ObjectToModelConvert(Loan loan)
        {
            LoanModel loanModel = new LoanModel()
            {
                LoansId = loan.LoansId,
                UserId = loan.UserId,
                CorrencyId = loan.CorrencyId,
                LoansStatesId = loan.LoansStatesId,
                Description = loan.Description,
                LoanAmount = loan.LoanAmount,
                MontlyPayment = loan.MontlyPayment,
                StartDate = loan.StartDate, 
                EndDate = loan.EndDate,    
                InterestRate = loan.InterestRate,
                BankFees = loan.BankFees,
                NextDueDate = loan.NextDueDate
            };
            return loanModel;
        }

        private Loan ModelToObjectConvert(LoanModel loanModel)
        {
            Loan loan = new Loan()
            {
                LoansId = loanModel.LoansId,
                UserId = loanModel.UserId,
                CorrencyId = loanModel.CorrencyId,
                LoansStatesId = loanModel.LoansStatesId,
                Description = loanModel.Description,
                LoanAmount = loanModel.LoanAmount,
                MontlyPayment = loanModel.MontlyPayment,
                StartDate = loanModel.StartDate,
                EndDate = loanModel.EndDate,
                InterestRate = loanModel.InterestRate,
                BankFees = loanModel.BankFees,
                NextDueDate = loanModel.NextDueDate
            };
            return loan;
        }
    }

}