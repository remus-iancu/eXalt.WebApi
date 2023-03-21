using eXalt.DomainApi;
using eXalt.DomainApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eXalt.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private IDomainProvider _domainProvider;

        public BankAccountController(IDomainProvider domainProvider)
        {
            _domainProvider = domainProvider;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BankAccount>> GetAccounts()
        {
            IEnumerable<BankAccount> list = Enumerable.Empty<BankAccount>();
            try
            {
                list = _domainProvider.GetBankAccounts();
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex.Message}");
            }

            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public ActionResult<decimal> GetCurrentAccountBalance(int id)
        {
            decimal result = 0;
            try
            {
                result = _domainProvider.GetBalance(id);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex.Message}");
            }

            return Ok(result);
        }

        [HttpGet("{accountId:int}/transactions")]
        public ActionResult<IEnumerable<AccountTransaction>> GetAccountTransactions(int accountId)
        {
            IEnumerable<AccountTransaction> list = Enumerable.Empty<AccountTransaction>();
            try
            {
                list = _domainProvider.GetAccountTransactions(accountId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex.Message}");
            }

            return Ok(list);
        }

        [HttpPatch("{accountId:int}")]
        public ActionResult AddRemoveMoney(int accountId, [FromBody] decimal amount)
        {
            try
            {
                if (amount >= 0)
                {
                    _domainProvider.MakeDeposit(accountId, amount);
                }
                else
                {
                    _domainProvider.MakeWithdrawal(accountId, amount);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex.Message}");
            }

            return Ok();
        }
    }
}
