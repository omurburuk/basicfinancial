using BasicFinancial.Models.Response;
using BasicFinancial.Controllers.Mobile; 
using Microsoft.AspNetCore.Mvc; 
using BasicFinancial.Core.Services;
using AutoMapper;
using BasicFinancial.DTO;
using BasicFinancial.Validators;
using BasicFinancial.Core.Models;

namespace BasicFinancial.Controllers
{
    [Route("api/mobile/v1/[controller]")]
    [ApiController]
    [Helper.Authorize]
    public class AccountController : MainController
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _mapper = mapper;
            _accountService = accountService;
        }

        // GET: api/account
        [HttpGet]
        public async Task<ActionResult<ServiceResponse>> GetAccounts()
        { 
            var accounts = await _accountService.GetAllWithCustomer();
            var accountResources = _mapper.Map<IEnumerable<Account>, IEnumerable<AccountDTO>>(accounts);
            return Ok(accountResources);
        } 
        

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDTO>> GetAccountById(int id)
        {
            var account = await _accountService.GetAccountById(id);
            var accountResource = _mapper.Map<Account, AccountDTO>(account);

            return Ok(accountResource);
        }
        [HttpPost("")]
        public async Task<ActionResult<AccountDTO>> CreateAccount([FromBody] SaveAccountDTO saveAccountResource)
        {
            var validator = new SaveAccountResourceValidator();
            var validationResult = await validator.ValidateAsync(saveAccountResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var accountToCreate = _mapper.Map<SaveAccountDTO, Account>(saveAccountResource);

            var newAccount = await _accountService.CreateAccount(accountToCreate);

            var account = await _accountService.GetAccountById(newAccount.Id);

            var accountResource = _mapper.Map<Account, AccountDTO>(account);

            return Ok(accountResource);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<AccountDTO>> UpdateAccount(int id, [FromBody] SaveAccountDTO saveAccountResource)
        {
            var validator = new SaveAccountResourceValidator();
            var validationResult = await validator.ValidateAsync(saveAccountResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var accountToBeUpdate = await _accountService.GetAccountById(id);

            if (accountToBeUpdate == null)
                return NotFound();

            var account = _mapper.Map<SaveAccountDTO, Account>(saveAccountResource);

            await _accountService.UpdateAccount(accountToBeUpdate, account);

            var updatedAccount = await _accountService.GetAccountById(id);
            var updatedAccountResource = _mapper.Map<Account, AccountDTO>(updatedAccount);

            return Ok(updatedAccountResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            if (id == 0)
                return BadRequest();

            var account = await _accountService.GetAccountById(id);

            if (account == null)
                return NotFound();

            await _accountService.DeleteAccount(account);

            return NoContent();
        } 
    }
}
