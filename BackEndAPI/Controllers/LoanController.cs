using Microsoft.AspNetCore.Mvc;
using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using System.Net;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private ILoanDAL loanDAL;

        public LoanController()
        {
            loanDAL = new LoanDALImpl();
        }


        // GET: api/<LoanController>
        //[Authorize]
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<Loan> loans = loanDAL.GetAll().ToList();
                List<LoanModel> result = new List<LoanModel>();
                foreach (Loan loan in loans)
                {
                    result.Add(objectToModelConvert(loan));
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
        //[Authorize]
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                Loan loan = loanDAL.Get(id);
                if (loan != null)
                {
                    return new JsonResult(objectToModelConvert(loan))
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                else
                {
                    return new JsonResult(new { message = "The ID is not correct" })
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
        //[Authorize]
        [HttpPost]
        public JsonResult Post([FromBody] LoanModel loan)
        {
            try
            {
                bool result = loanDAL.Add(ModelToObjectConvert(loan));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(loan))
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error including Loan" })
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = ex.Message })
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        // PUT api/<LoanController>/5
        //[Authorize]
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] LoanModel loan)
        {
            try
            {
                bool result = loanDAL.Update(ModelToObjectConvert(loan));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(loan))
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error to Update Loan" })
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = ex.Message })
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        // DELETE api/<LoanController>/5
        //[Authorize]
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Loan loan = new Loan()
                {
                    IdLoan = id
                };
                bool result = loanDAL.Remove(loan);
                if (result)
                {
                    return new JsonResult(new { message = "The data is deleted" })
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error to Delete Loan" })
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = ex.Message })
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        // DELETE api/<LoanController>/5
        //[Authorize]
        [Route("AllDelete/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(Boolean), StatusCodes.Status200OK)]
        public JsonResult AllDelete(int id)
        {
            try
            {
                bool result = loanDAL.RemoveAll(id);
                if (result)
                {
                    return new JsonResult(new { message = "The data is deleted" })
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error to Delete Loan" })
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = ex.Message })
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        private LoanModel objectToModelConvert(Loan loan)
        {

            return new LoanModel
            {
                IdLoan = loan.IdLoan,
                Idcustomers = loan.Idcustomers,
                StarDate = loan.StarDate,
                EndDate = loan.EndDate,
                InteresRate = loan.InteresRate,
                LoanAmount = loan.LoanAmount,
                CurrentAmount = loan.CurrentAmount,
                MonthlyAmount = loan.MonthlyAmount,
                NextDueDate = loan.NextDueDate,
                BankFees = loan.BankFees,
                LoansDescription = loan.LoansDescription,
                IdloansType = loan.IdloansType,
                IdCurrencies = loan.IdCurrencies,
                IdLoansState = loan.IdLoansState
            };
        }

        private Loan ModelToObjectConvert(LoanModel loanModel)
        {

            return new Loan
            {
                IdLoan = loanModel.IdLoan,
                Idcustomers = loanModel.Idcustomers,
                StarDate = loanModel.StarDate,
                EndDate = loanModel.EndDate,
                InteresRate = loanModel.InteresRate,
                LoanAmount = loanModel.LoanAmount,
                CurrentAmount = loanModel.CurrentAmount,
                MonthlyAmount = loanModel.MonthlyAmount,
                NextDueDate = loanModel.NextDueDate,
                BankFees = loanModel.BankFees,
                LoansDescription = loanModel.LoansDescription,
                IdloansType = loanModel.IdloansType,
                IdCurrencies = loanModel.IdCurrencies,
                IdLoansState = loanModel.IdLoansState
            };
        }
    }
}
