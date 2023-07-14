using AutoMapper;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Monefy.Domain.Contracts;
using Monefy.Entities;

namespace Monefy.Application.Implementation
{
    public class WalletAppService : IWalletAppService
    {
        private readonly IMapper _mapper;
        private readonly IWalletBusinessService _walletBusinessService;

        public WalletAppService(IMapper mapper, IWalletBusinessService walletBusinessService)
        {
            _mapper = mapper;
			_walletBusinessService = walletBusinessService;
   
        }

        public async Task<WalletDTO> CreateWalletAsync(WalletDTO walletDTO)
        {
            await _walletBusinessService.CreateWalletAsync(_mapper.Map<EntityWallet>(walletDTO));
            return walletDTO;
        }

        public async Task<IEnumerable<WalletDTO>> GetAllWalletsAsync()
        {
            var walletList = await _walletBusinessService.GetAllWalletsAsync();
            return _mapper.Map<IEnumerable<WalletDTO>>(walletList);
        }

        public async Task<WalletDTO> GetWalletByIdAsync(int id)
        {
            var wallet = await _walletBusinessService.GetWalletByIdAsync(id);
            return _mapper.Map<WalletDTO>(wallet);
        }

        public async Task<IEnumerable<WalletDTO>> GetUsersWalletAsync(int id)
        {
            var usersWallet = await _walletBusinessService.GetUsersWalletAsync(id);
            return _mapper.Map < IEnumerable<WalletDTO>>(usersWallet);
        }

        public async Task<IEnumerable<IncomeDTO>> GetWalletIncomesAsync(int walletId, DateTime initialDate, DateTime finalDate)
        {
            var incomes = await _walletBusinessService.GetWalletIncomesAsync(walletId, initialDate, finalDate);
            return _mapper.Map<IEnumerable<IncomeDTO>>(incomes);
        }

        public async Task<IEnumerable<ExpenseDTO>> GetWalletExpensesAsync(int walletId, DateTime initialDate, DateTime finalDate)
        {
            var expenses = await _walletBusinessService.GetWalletExpensesAsync(walletId, initialDate, finalDate);
            return _mapper.Map<IEnumerable<ExpenseDTO>>(expenses);
        }

        public async Task<WalletDTO> UpdateWalletAsync(WalletDTO walletDTO)
        {
            await _walletBusinessService.UpdateWalletAsync(_mapper.Map<EntityWallet>(walletDTO));
            return walletDTO;
        }

        public async Task<WalletDTO> DeleteWalletAsync(int id)
        {
            await _walletBusinessService.DeleteWalletAsync(id);
            return _mapper.Map<WalletDTO>(id);
        }

        public async Task<IEnumerable<ExpensesCategoryDTO>> GetCategoriesWithExpenses(int id, DateTime initialDate, DateTime finalDate)
        {
            var total = await _walletBusinessService.GetCategoriesWithExpenses(id, initialDate, finalDate);
            return _mapper.Map<IEnumerable<ExpensesCategoryDTO>>(total);
        }
    }
}
